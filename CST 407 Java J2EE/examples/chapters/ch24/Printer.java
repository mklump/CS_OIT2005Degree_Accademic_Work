// Fig. 24.5: Printer.java
// This class provides implementation for interface PrinterMBean
// and registers a managing MBean for the Printer device,
// which is simulated by PrinterSimulator.java.

// deitel package
package com.deitel.advjhtp1.jmx.PrinterManagement;

// Java core package
import java.lang.Thread;
import java.util.ArrayList;

// JMX core packages
import javax.management.*;

// Deitel packages
import com.deitel.advjhtp1.jmx.Printer.*;

public class Printer implements PrinterMBean,
   PrinterEventListener {      

   private PrinterSimulator printerSimulator;
   private static final int PAPER_STACK_SIZE = 50;
   private ObjectInstance eventBroadcasterInstance;
   private ObjectName eventBroadcasterName;
   private ObjectName printerName;
   private MBeanServer mBeanServer;
   
   public Printer()
   {
      // connect to the printer device
      printerSimulator = new PrinterSimulator( this ) ;
      Thread myThread = new Thread( printerSimulator ) ;
      myThread.start();
   
      // find all MBean servers in current JVM
      ArrayList arrayList = 
         MBeanServerFactory.findMBeanServer( null ); 
      
      // retrieve the MBeanServer reference
      if ( arrayList.size() == 0)
         System.out.println( "Cannot find a MBeanServer!" );

      else {

         // get the MBeanServer that has the 
         // PrinterEventBroadcaster MBean registered with it
         for ( int i = 0; i < arrayList.size(); i++ ) {
            MBeanServer foundMBeanServer = 
               ( MBeanServer ) arrayList.get( i );

            // obtain the object name for the 
            // PrinterEventBroadcaster MBean
            try {
               String name = foundMBeanServer.getDefaultDomain()
                  + ":type=" + "PrinterEventBroadcaster";
               eventBroadcasterName = new ObjectName( name );
            } 

            // handle exception when creating ObjectName
            catch ( MalformedObjectNameException exception ) {
               exception.printStackTrace();
            }

            // check whether the PrinterEventBroadcaster MBean is
            // registered with this MBeanServer
            if ( foundMBeanServer.isRegistered( 
               eventBroadcasterName ) ) {
               mBeanServer = foundMBeanServer;
               break;
            } 

         } // end for loop

      } // end if-else to get the MBeanServer reference

   } // end PrinterSimulator constructor
    
   // will stop the printer thread from executing 
   // once execution should stop.  
   public void stop()
   {
      printerSimulator.stop();
   }
    
   // Is it printing?
   public Boolean isPrinting()
   {
      return new Boolean( printerSimulator.isPrinting() );
   }

   // is online?
   public Boolean isOnline()
   {
      return printerSimulator.isOnline();    
   }

   // is paper jammed?
   public Boolean isPaperJam()
   {
      return printerSimulator.isPaperJam();
   }
    
   // is paper tray empty?
   public Integer getPaperTray()
   {
      return printerSimulator.getPaperTray();
   }

   // is toner low?
   public Integer getToner()
   {
      return printerSimulator.getToner();
   }

   // returns ID of print job that is currently printing
   public String getCurrentPrintJob()
   {
      return printerSimulator.getCurrentPrintJob();
   }

   // returns array of all queued up print jobs
   public String[] getPendingPrintJobs()
   {
      return printerSimulator.getPendingPrintJobs();
   }

   // sets status availability of printer
   public void setOnline( Boolean online )
   {
      if ( online.booleanValue() == true ) 
         printerSimulator.setOnline();
      else 
         printerSimulator.setOffline();
   }

   // fills up the paper tray again with paper.
   public void replenishPaperTray()
   {
      printerSimulator.replenishPaperTray (
         Printer.PAPER_STACK_SIZE );
   }

   // cancel pending print jobs
   public void cancelPendingPrintJobs()
   {
      printerSimulator.cancelPendingPrintJobs();
   }

   // start the printing process
   public void startPrinting()
   {
      printerSimulator.startPrintingProcess();
   }

   // send out of paper event to JMX layer
   protected void fireOutOfPaperEvent()
   {
      // construct parameters and signatures
      Object[] parameter = new Object[ 1 ];
      parameter[ 0 ] = new Notification( 
         "PrinterEvent.OUT_OF_PAPER", this, 0L );
      String[] signature = new String[ 1 ];
      signature[ 0 ] = "javax.management.Notification";
      
      // invoke notification
      try {
         mBeanServer.invoke( eventBroadcasterName,
            "sendNotification", parameter, signature ); 
      } 

      // handle exception when invoking method
      catch ( ReflectionException exception ) {
         exception.printStackTrace();
      }

      // handle exception when communicating with MBean
      catch ( MBeanException exception ) {
         exception.printStackTrace();
      } 

      // handle exception if MBean not found
      catch ( InstanceNotFoundException exception ) {
         exception.printStackTrace();
      }           
 
   } // end method outOfPaperEvent
   
   // send low toner event to JMX layer
   protected void fireLowTonerEvent()
   {
      // construct parameters and signatures
      Object[] parameter = new Object[ 1 ];
      parameter[ 0 ] = new Notification( 
         "PrinterEvent.LOW_TONER", this, 0L );
      String[] signature = new String[ 1 ];
      signature[ 0 ] = "javax.management.Notification";
      
      // invoke notification
      try {
         mBeanServer.invoke( eventBroadcasterName,
            "sendNotification", parameter, signature ); 
      } 

      // handle exception when invoking method
      catch ( ReflectionException exception ) {
         exception.printStackTrace();
      }

      // handle exception communicating with MBean
      catch ( MBeanException exception ) {
         exception.printStackTrace();
      }

      // handle exception if MBean not found
      catch ( InstanceNotFoundException exception ) {
         exception.printStackTrace();
      }   
 
   } // end method lowTonerEvent
   
   // send paper jam event to JMX layer
   protected void firePaperJamEvent()
   {
      // construct parameters and signatures
      Object[] parameter = new Object[ 1 ];
      parameter[ 0 ] = new Notification( 
         "PrinterEvent.PAPER_JAM", this, 0L );
      String[] signature = new String[ 1 ];
      signature[ 0 ] = "javax.management.Notification";
      
      // invoke notification
      try {
         mBeanServer.invoke( eventBroadcasterName,
            "sendNotification", parameter, signature ); 
      } 

      // handle exception when invoking method
      catch( ReflectionException exception ) {
         exception.printStackTrace();
      }

      // handle exception communicating with MBean
      catch( MBeanException exception ) {
         exception.printStackTrace();
      } 

      // handle exception if MBean not found
      catch( InstanceNotFoundException exception ) {
         exception.printStackTrace();
      }                 

   } // end method paperJamEvent

   // interface implementation
   public void outOfPaper() 
   {
      // delegate call
      fireOutOfPaperEvent();
   }

   // interface implementation
   public void lowToner() 
   {
      // delegate call
      fireLowTonerEvent();
   }

   // interface implementation
   public void paperJam()
   {
      // delegate call
      firePaperJamEvent();
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
