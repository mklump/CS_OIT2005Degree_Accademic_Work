// Fig. 24.6: PrinterSimulator.java
// This class simulates a printer device on a network.

// deitel package
package com.deitel.advjhtp1.jmx.Printer;

// java core package
import java.util.Stack;

public class PrinterSimulator implements Runnable {

   private Stack printerStack = new Stack();
   private boolean isOnline = true;
   private boolean isPrinting = false;
   private boolean isPaperJam = false;
   
   // 50 sheets of paper in tray   
   private Integer paperInTray = new Integer( 50 );   
      
   // 100% full of ink
   private Integer tonerCartridge = new Integer( 100 ); 

   private String currentPrintJob;
   private boolean isAlive = true;
   private PrinterEventListener eventListener;  
  
   // default public constructor
   public PrinterSimulator( 
      PrinterEventListener listener ) 
   {
      eventListener = listener;
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

         // pause if offline
         if ( !isOnline ) {
            synchronized ( this ) {

               // waits for printer become online
               try {
                  wait();
               } 
   
               // if interrupt occurs
               catch ( InterruptedException exception ) {
                  exception.printStackTrace();
                  System.exit( -1 );
               }

            } // end synchronized

         } // end if
                   
         // prints one job from print job stack
         startPrintingProcess();

      } // end while
   }
  
   public void startPrintingProcess() 
   {
      // warm up the printer, print top print job from print
      // stack and adjust paper values and toner values
      try {
         // warm up printer for incoming batch of print jobs
         Thread.sleep( 1000 * 5 );
   
         if ( ( paperInTray.intValue() > 0 ) &&
            ( tonerCartridge.intValue() > 10 ) &&
            ( !isPaperJam ) ) {

            // start the printing process
            currentPrintJob = getNextPrintJob();
            isPrinting = true;
      
            // 12 seconds to print a normal document
            Thread.sleep( 1000 * 12 ); 
      
            // each print job uses 10 pages
            updatePaperInTray( paperInTray.intValue() - 10 ); 
            updateToner();
            updatePaperJam();
            isPrinting = false;
      
            // make sure no references are left dangling
            currentPrintJob = null;
         }
      } 
  
      // if interrupt occurs
      catch ( InterruptedException exception ) {
         exception.printStackTrace();
         System.exit( -1 );
      }

   } // end method startPrintingProcess
  
   // returns current printed job
   public String getCurrentPrintJob() 
   {
      return currentPrintJob;
   }
  
   // is printer online?
   public Boolean isOnline() 
   {
      return new Boolean ( isOnline );
   }

   // update amount of paper in paper tray
   public synchronized void updatePaperInTray( int newValue ) 
   {
      paperInTray = new Integer ( newValue );  
      
      // fire event if paper tray low
      if ( paperInTray.intValue() <= 0 ) {
         eventListener.outOfPaper();
      }
   }
  
   // is paper jammed?
   public Boolean isPaperJam()
   {
      return new Boolean( isPaperJam );
   }

   // cancel pending print jobs
   public void cancelPendingPrintJobs()
   {
      synchronized ( printerStack ) {
         printerStack.clear();
      }
   }

   // update amount of toner available in toner cartridge
   public synchronized void updateToner() 
   {
      // after every print job, toner levels drop 1%
      tonerCartridge = new Integer ( 
            tonerCartridge.intValue() - 1 );   
      
      // fire event if toner is low
      if ( tonerCartridge.intValue() <= 10 ) { 
         eventListener.lowToner();
      }
   }

   public synchronized void updatePaperJam()
   {
      if ( Math.random() > 0.9 ) {
         isPaperJam = true;
         eventListener.paperJam();
      }
   }
  
   // returns number of pages in paper tray
   public synchronized Integer getPaperTray() 
   {
      return paperInTray;
   }
  
   // returns amount of toner in toner cartridge
   public synchronized Integer getToner() 
   {
      return tonerCartridge;
   }
  
   // generates a random number of print jobs with varying IDs
   public void populatePrintStack() 
   {
      int numOfJobs = ( int ) ( Math.random ( ) * 10 ) + 1;
      
      // generate print jobs
      synchronized ( printerStack ) {
         for ( int i = 0 ; i < numOfJobs ; i++ ) {
            printerStack.add ( "PRINT_JOB_ID #" + i );
         }
      }
   }

   // returns next print job in stack, populating the stack 
   // if it is empty
   public String getNextPrintJob() 
   {
      if ( printerStack.isEmpty() ) {
          populatePrintStack ( );

         // simulates absence of print jobs      
         try {
            Thread.sleep (
               ( int ) ( Math.random() * 1000 * 10 ) );
         } 
 
         // if interrupt occurs
         catch ( InterruptedException exception ) {
            exception.printStackTrace() ;
            System.exit ( -1 ) ;
         } 
      }
      
      // Remove topmost queued resource.
      String printJob;

      synchronized ( printerStack ) {
         printJob = ( String ) printerStack.pop();
      }      

      return printJob;

   } // end method getNextPrintJob
  
   // returns all jobs yet to be printed
   public String[] getPendingPrintJobs() 
   {
      String[] pendingPrintJobs;
      
      // create array of pending print jobs
      synchronized ( printerStack ) {
         Object[] temp = printerStack.toArray() ;
         pendingPrintJobs = new String[ temp.length ] ;

         for ( int i = 0 ; i < pendingPrintJobs.length ; i++ ) {
            pendingPrintJobs [ i ] = ( String )temp[ i ];
         }         
      }   

      return pendingPrintJobs; 

   } // end method getPendingPrintJobs
  
   // sets printer status to online
   public void setOnline() 
   {
      isOnline = true;
      
      // notify all waiting states
      synchronized ( this ) {
         notifyAll() ;
      }
   }
  
   // sets printer status to offline
   public void setOffline() 
   {
      isOnline = false;
   }
  
   // replenishes amount of paper in paper tray to specified 
   // value
   public void replenishPaperTray ( int paperStack ) 
   {
      updatePaperInTray( paperStack ) ;
   }
  
   // is printer printing?
   public boolean isPrinting() 
   {
      return isPrinting;
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
