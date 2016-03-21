// Fig. 24.3: PrinterMBean.java
// This interface specifies the methods that will be implemented
// by Printer, which will function as an MBean.

// deitel package
package com.deitel.advjhtp1.jmx.PrinterManagement;

public interface PrinterMBean {

   // is it printing?
   public Boolean isPrinting();
    
   // is it online?
   public Boolean isOnline();

   // is paper jammed?
   public Boolean isPaperJam();

   // returns paper amount in tray
   public Integer getPaperTray();

   // returns ink level in toner cartridge
   public Integer getToner();
   
   // returns ID of print job that is currently printing
   public String getCurrentPrintJob();

   // returns array of all queued up print jobs
   public String [] getPendingPrintJobs(); 

   // sets availability status of printer
   public void setOnline( Boolean online );

   // fills up paper tray again with paper
   public void replenishPaperTray();

   // cancel pending print jobs
   public void cancelPendingPrintJobs();

   // start printing process
   public void startPrinting();
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