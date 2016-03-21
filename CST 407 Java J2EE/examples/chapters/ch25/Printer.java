// Printer.java
// This class simulates a printer device on a network.
// deitel package
package com.deitel.advjhtp1.jiro.DynamicService.printer;

// java core package
import java.util.Stack;
import java.rmi.*;
import java.io.*;

// Jiro packages
import javax.fma.services.ServiceFinder;
import javax.fma.services.event.EventService;
import javax.fma.util.*;

public class Printer implements Runnable {   

   private Stack printerStack = new Stack();
   private boolean isPrinting = false;
   private boolean isPaperJam = false;
   private boolean isOnline = true;
   
   // 50 sheets of paper in tray   
   private int paperInTray = 50;   
      
   // 100% full of ink
   private int tonerCartridge = 100; 

   private String currentPrintJob;
   private boolean isAlive = true;

   private EventService eventService;
  
   // printer constructor
   public Printer() 
   {
      // get EventService at gaven management domain
      try {
         eventService = ServiceFinder.getEventService();
      }

      // handle exception getting EventService
      catch ( Exception exception ) {
         Debug.debugException( 
            "getting EventService", exception );
      }
   }
   
   // stops execution of thread
   public void stop() 
   {
      isAlive = false;
   }

   // main life-cycle of the printer. 
   // prints one job from print job stack
   // 1) if offline, it pauses and waits.
   // 2) if online, handles one print job
   public void run() 
   {
      // main loop within thread
      while ( isAlive ) {

         // printer will be offline
         if ( !isOnline ) {

            synchronized ( this ) {

               // waits for printer become online
               try {
                  wait();
               } 
   
               // handle exception waiting
               catch ( InterruptedException exception ) {
                  Debug.debugException( 
                     "printer wait", exception );
               }

            } // end synchronized

         } // end if
                   
         // prints one job from print job stack
         startPrintingProcess();

      } // end while
   }
  
   // start printing process
   private synchronized void startPrintingProcess() 
   {
      // warm up the printer, print top print job from print
      // stack and adjust paper values and toner values
      try {

         // warm up printer for incoming batch of print jobs
         Thread.sleep( 1000 * 2 );
   
         if ( isOnline && ( paperInTray > 0 ) &&
            ( tonerCartridge > 10 ) && ( !isPaperJam ) ) {

            // start the printing process
            currentPrintJob = getNextPrintJob();
            isPrinting = true;
      
            // 12 seconds to print a normal document
            Thread.sleep( 1000 * 12 ); 
      
            // each print job uses 10 pages
            updatePaperInTray( paperInTray - 10 ); 
            updateToner();
            updatePaperJam();
            isPrinting = false;
      
            // make sure no referrences are left dangling
            currentPrintJob = null;

         } // end if
      } 
  
      // handle exception starting printing process
      catch( InterruptedException exception ) {
         Debug.debugException( 
            "starting printing process", exception );
      }

   } // end method startPrintingProcess

   // returns current printed job
   private String getCurrentPrintJob() 
   {
      return currentPrintJob;
   }

   // update amount of paper in paper tray
   private synchronized void updatePaperInTray( int newValue ) 
   {
      paperInTray = newValue;  
      
      // fire event if paper tray low
      if ( paperInTray <= 0 ) {
         System.out.println( "Printer: out of paper. " );
         fireEvent( "OutofPaper" );
      }
   }
  
   // is paper jammed?
   public boolean isPaperJam()
   {
      return isPaperJam;
   }

   // is printer printing?
   public boolean isPrinting()
   {
      return isPrinting;
   }

   // is printer online?
   public boolean isOnline()
   {
      return isOnline;
   }

   // return number of pages in paper tray
   public synchronized int getPaperInTray() 
   {
      return paperInTray;
   }

   // update amount of toner available in toner cartridge
   public synchronized void updateToner() 
   {
      // after every print job, toner levels drop 1%
      tonerCartridge = tonerCartridge - 1;   
      
      // fire event if toner is low
      if ( tonerCartridge <= 10 ) { 
         System.out.println( "Printer: low toner. " );
         fireEvent( "LowToner" );
      }
   }

   // update paper jam
   public synchronized void updatePaperJam()
   {
      if ( Math.random() > 0.9 ) {
         isPaperJam = true;
         System.out.println( "Printer: paper jam. " );
         fireEvent( "PaperJam" );
      }
   }
  
   // return amount of toner in toner cartridge
   public synchronized int getToner() 
   {
      return tonerCartridge;
   }
  
   // replenishe amount of paper in paper tray to specified 
   // value
   public void replenishPaperTray ( int paperStack ) 
   {
      System.out.println( "Printer: adding " + paperStack 
         + " pages to printer ... \n" );
      updatePaperInTray ( paperInTray + paperStack ) ;
   }
  
   // generates a random number of print jobs with varying IDs
   private synchronized void populatePrintStack() 
   {
      int numOfJobs = ( int ) ( Math.random ( ) * 10 ) + 1;
      
      // generate print jobs
      for ( int i = 0; i < numOfJobs ; i++ ) {

         synchronized ( printerStack ) {
            printerStack.add ( "PRINT_JOB_ID #" + i );
         }
      }
   }

   // add toner
   public synchronized void addToner()
   {
      System.out.println( "Printer: adding toner . . . \n" );
      tonerCartridge = 100;
   }

   // cancel pending print jobs
   public synchronized void cancelPendingPrintJobs()  
   {
      synchronized ( printerStack ) {
         printerStack.clear();
      }
   }

   // return next print job in stack, populating the stack 
   // if it is empty
   private synchronized String getNextPrintJob() 
   {
      if ( printerStack.isEmpty() ) {
          populatePrintStack ( );

         // simulates absence of print jobs      
         try {
            Thread.sleep (
               ( int ) ( Math.random() * 1000 * 10 ) );
         } 
 
         // handle exception thread sleep
         catch ( InterruptedException exception ) {
            Debug.debugException( 
               "getting next print job", exception );
         } 
      }
      
      // Remove topmost queued resource.
      String nextJob;

      synchronized ( printerStack ) {
         nextJob = ( String ) printerStack.pop();
      }      

      return nextJob;

   } // end method getNextPrintJob
  
   // return all jobs yet to be printed
   public synchronized String[] getPendingPrintJobs() 
   {
      String[] pendingJobs;
      
      // create array of pending print jobs
      synchronized ( printerStack ) {
         Object[] temp = printerStack.toArray() ;
         pendingJobs = new String[ temp.length ] ;

         for ( int i = 0; i < pendingJobs.length ; i++ ) {
            pendingJobs [ i ] = ( String ) temp[ i ];
         }         
      }   

      return pendingJobs; 
   }
  
   // set printer status to online
   public void setOnline() 
   {
      System.out.println( "Printer: setting online ... \n" );
      isOnline = true;
      
      // notify all waiting states
      synchronized ( this ) {
         notifyAll() ;
      }
   }
  
   // set printer status to offline
   public void setOffline() 
   {
      System.out.println( "Printer: setting offline ... \n" );
      isOnline = false;
   }

   // fire event
   private void fireEvent( String error )
   {
      // post event to EventService
      try {

         // define event
         PrinterErrorEvent event = new PrinterErrorEvent( 
            "com.deitel.advjhtp1.jiro.DynamicService.printer." 
            + "ErrorMessage=" + error, 
            ".Printer.Error." + error );

         // post event
         eventService.post( event );
      }

      // handle exception posting event
      catch ( Exception exception ) {
         Debug.debugException( "posting event", exception );
      }
      
   } // end method fireEvent
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