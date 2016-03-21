// PrinterManagementImpl.java
// This class schedules turn-on and turn-off printer 
// periodically and issues a log message to LogService
// when error events happen.
package com.deitel.advjhtp1.jiro.DynamicService.service;

// Java core packages
import java.io.Serializable;
import java.rmi.*;
import java.util.*;

// Java standard extensions
import javax.swing.*;

// Jini core packages
import net.jini.core.event.*;
import net.jini.core.entry.*;
import net.jini.core.lease.*;

// Jini extension packages
import net.jini.lease.LeaseRenewalManager;
import net.jini.lookup.entry.*;

// Jiro packages
import javax.fma.services.ServiceFinder;
import javax.fma.services.event.EventService;
import javax.fma.services.log.LogMessage;
import javax.fma.services.log.LogService;
import javax.fma.services.scheduling.SchedulingService;
import javax.fma.services.scheduling.SchedulingService.*;
import javax.fma.util.*;

// Deitel packages
import com.deitel.advjhtp1.jiro.DynamicService.printer.*;

public class PrinterManagementImpl
   implements PrinterManagement {

   private Printer printer;
   private LogService logService = null;
   private Lease observerLease;
   private LeaseRenewalManager leaseRenewalManager;
   private Ticket turnOffPrinter;
   private Ticket turnOnPrinter;

   // default constructor
   public PrinterManagementImpl() 
   {
      System.out.println( "Dynamic service started.\n" );

      // start a printer
      printer = new Printer() ;
      Thread printerThread = new Thread( printer ) ;
      printerThread.start();

      // subscribe to printer events
      try {

         // get the event service
         EventService eventService = 
            ServiceFinder.getEventService();

         // get the log service
         logService = ServiceFinder.getLogService();

         // get a listener
         PrinterEventListener listener = 
            new PrinterEventListener( this );

         // subscribe as an observing listener to event with 
         // topic ".Printer.Error"
         observerLease = eventService.subscribeObserver( 
            ".Printer.Error", listener, null, 10 * 60 * 1000 );

         // renew observer listener's lease
         leaseRenewalManager = new LeaseRenewalManager();
         leaseRenewalManager.renewUntil( 
            observerLease, Lease.FOREVER, null );

         // get the scheduling service
         SchedulingService schedulingService = 
            ServiceFinder.getSchedulingService();

         // define the schedule for turn-off printer task
         // printer is turned off at 8:00PM every friday 
         GregorianCalendar calendar = new GregorianCalendar();
         calendar.set( 2001, 7, 27 );
         Date startDate = calendar.getTime();
         calendar.set( 2003, 7, 27 );
         Date endDate = calendar.getTime();
         int[] monthsOff = { Calendar.JANUARY, 
            Calendar.FEBRUARY, Calendar.MARCH, Calendar.APRIL,
            Calendar.MAY, Calendar.JUNE, Calendar.JULY, 
            Calendar.AUGUST, Calendar.SEPTEMBER, 
            Calendar.OCTOBER, Calendar.NOVEMBER, 
            Calendar.DECEMBER };
         int[] daysOfWeekOff = { Calendar.FRIDAY  };
         int[] hoursOff = { 20 };
         int[] minutesOff = { 0 };
         
         // create the schedule for turn-off printer task
         Schedule turnOffSchedule = 
            schedulingService.newRepeatedDateSchedule( 
               startDate, endDate, monthsOff, null, 
               daysOfWeekOff, hoursOff, minutesOff, 
               calendar.getTimeZone() );

         // create the message description
         LocalizableMessage turnOffMessage =
            new LocalizableMessage( PrinterManagementImpl.class,
               "TurnOffPrinter", null, null );

         // define the handback object of the 
         // turn-off printer task
         MarshalledObject handbackOff = new MarshalledObject(
            new String( "turn-off" ) );

         // schedule task and get the Ticket for 
         // the scheduled task
         turnOffPrinter = schedulingService.scheduleTask( 
            listener, turnOffMessage, turnOffSchedule,
            SchedulingService.NONE, handbackOff );

         // define the schedule for turn-on printer task
         // printer is turned on at 7:00AM every Monday
         calendar = new GregorianCalendar();
         calendar.set( 2001, 7, 27 );
         startDate = calendar.getTime();
         calendar.set( 2003, 7, 27 );
         endDate = calendar.getTime();
         int[] monthsOn = { Calendar.JANUARY, 
            Calendar.FEBRUARY, Calendar.MARCH, Calendar.APRIL,
            Calendar.MAY, Calendar.JUNE, Calendar.JULY,
            Calendar.AUGUST, Calendar.SEPTEMBER, 
            Calendar.OCTOBER, Calendar.NOVEMBER,
            Calendar.DECEMBER };
         int[] daysOfWeekOn = { Calendar.MONDAY  };
         int[] hoursOn = { 7 };
         int[] minutesOn = { 0 };

         // create the schedule for turn-on printer task
         Schedule turnOnSchedule = 
            schedulingService.newRepeatedDateSchedule( 
               startDate, endDate, monthsOn, null, 
               daysOfWeekOn, hoursOn, minutesOn, 
               calendar.getTimeZone() );

         // create the message description
         LocalizableMessage turnOnMessage =
            new LocalizableMessage( PrinterManagementImpl.class,
               "TurnOnPrinter", null, null );

         // define the handback object of the 
         // turn-on printer task
         MarshalledObject handbackOn = new MarshalledObject(
            new String( "turn-on" ) );

         // schedule task and get the Ticket for 
         // the scheduled task
         turnOnPrinter = schedulingService.scheduleTask( 
            listener, turnOnMessage, turnOnSchedule,
            SchedulingService.NONE, handbackOn );

      } // end try

      // handle exception schedulling task
      catch ( Exception exception ) {
         System.out.println( "PrinterManagementImpl: " +
            "Exception occurred when scheduling tasks." );
         System.out.println( "Please read debug file ...\n" );
         Debug.debugException( "schedulling task", exception );
      }
   
   } // end PrinterManagementImpl constructor

   // cancel scheduled tasks
   public void terminateScheduledTasks()
   {
      // cancel turn-on and turn-off printer tasks
      try {
         turnOffPrinter.cancel();
         turnOnPrinter.cancel();
      }

      // handle exception canceling scheduled task
      catch ( Exception exception ) {
         System.out.println( "PrinterManagementImpl: " +
            "Exception occurred when canceling tasks." );
         System.out.println( "Please read debug file ...\n" );
         Debug.debugException( 
            "cancel scheduled task", exception );
      }

   } // end cancel scheduled task

   // add paper to printer
   public void addPaper( int amount )
   {
      System.out.println( 
         "PrinterManagementImpl: Adding paper ...\n" );
      printer.replenishPaperTray( amount );
   }

   // is printer printing?
   public boolean isPrinting()
   {
      return printer.isPrinting();
   }

   // is printer jammed?
   public boolean isPaperJam()
   {
      return printer.isPaperJam();
   }

   // get printer's pages count 
   public int getPaperInTray()
   {
      return printer.getPaperInTray();
   }

   // get pending jobs
   public String[] getPendingPrintJobs()
   {
      return printer.getPendingPrintJobs();   
   }

   // is printer online?
   public boolean isOnline()
   {
      return printer.isOnline();
   }

   // cancel pending printing jobs
   public void cancelPendingPrintJobs()
   {
      System.out.println( "PrinterManagementImpl: "
         + "Canceling pending print jobs ... \n" );
      printer.cancelPendingPrintJobs();
   }

   // receive notifications
   public void notify( RemoteEvent remoteEvent )
      throws UnknownEventException, RemoteException
   {
      String subString = 
         "com.deitel.advjhtp1.jiro.DynamicService.printer";
      String source = ( String ) remoteEvent.getSource();
      source = source.substring( 0, subString.length() );

      // printer event
      if ( source.equals( subString ) )
         eventHandler( remoteEvent );

      else // scheduled task
         performTask( remoteEvent );
   }

   // add toner to printer
   public void addToner()
   {
      System.out.println( 
         "PrinterManagementImpl: Adding toner ...\n" );
      printer.addToner();
   }

   // perform task when scheduled time arrives
   private void performTask( RemoteEvent remoteEvent )
   {
      // perform task
      try {

         // get task type
         String type = 
            ( String ) remoteEvent.getRegistrationObject().get();

         // turn-off printer	
         if ( type.equals( "turn-off" ) ) 
            printer.setOffline();

         // turn-on printer
         else if ( type.equals( "turn-on" ) )
            printer.setOnline();
      }

      // handle exception performing scheduled task
      catch (Exception exception) {
         System.out.println( "PrinterManagementImpl: " +
            "Exception occurred when performing tasks." );
         System.out.println( "Please read debug file ...\n" );
         Debug.debugException(
            "perform scheduled task", exception );
      }

   } // end method performTask

   // handle event
   private synchronized void eventHandler ( 
      RemoteEvent remoteEvent )
   {
      String source = ( String ) remoteEvent.getSource();

      // generate the log message
      Serializable params[] = new Serializable[ 2 ];
      params[ 0 ] = source;
      params[ 1 ] = new Date();

      // define localizable message
      LocalizableMessage localizableMessage = 
         new LocalizableMessage( PrinterManagementImpl.class, 
            "Event", params, Locale.US );

      // define log message
      LogMessage logMessage = new LogMessage(
         localizableMessage, LogMessage.TRACE + ".printer." 
         + source, null );

      // post the log message
      try {
         logService.log( logMessage );
      }

      // handle exception posting log message
      catch ( Exception exception ) {
         System.out.println( "PrinterManagementImpl: " +
            "Exception occurred when posting log message." );
         System.out.println( "Please read debug file ...\n" );
         Debug.debugException( "log service", exception );
      }

   } // end eventHandler

   // entry object
   private Entry[] getLookupEntries()
   {
      return ( new Entry[] {
         new ServiceInfo( "PrinterManagementImpl", 
            "Deitel Association, Inc.",
            "Deitel Association, Inc",
            "1.0", "Model 0", "0.0.0.1" )
         } 
      ); 
   } 
} 

/***************************************************************
 * (C) Copyright 2002 by Deitel & Associates, Inc. and         *
 * Prentice Hall. All Rights Reserved.                         *
 *                                                             *
 * DISCLAIMER: The authors and publisher of this book have     *
 * used their best efforts in preparing the book. These        *
 * efforts include the development, research, and testing of   *
 * the theories and programs to determine their effectiveness. *
 * The authors and publisher make no warranty of any kind,     *
 * expressed or implied, with regard to these programs or to   *
 * the documentation contained in these books. The authors     *
 * and publisher shall not be liable in any event for          *
 * incidental or consequential damages in connection with, or  *
 * arising out of, the furnishing, performance, or use of      *
 * these programs.                                             *
 ***************************************************************/
