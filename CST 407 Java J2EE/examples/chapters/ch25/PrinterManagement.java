// Fig: PrinterManagement.java
// This class defines the interface for the dynamic service.
package com.deitel.advjhtp1.jiro.DynamicService.service;

// Java core package
import java.rmi.*;
import java.util.*;

// Jini core package
import net.jini.core.event.*;

public interface PrinterManagement 
   extends RemoteEventListener {

   public void addPaper( int amount ) 
      throws RemoteException;

   public boolean isPrinting() throws RemoteException;

   public boolean isPaperJam() throws RemoteException;

   public int getPaperInTray() throws RemoteException;

   public boolean isOnline() throws RemoteException;

   public void cancelPendingPrintJobs() throws RemoteException;

   public void terminateScheduledTasks() throws RemoteException;

   public void addToner() throws RemoteException;

   public String[] getPendingPrintJobs() throws RemoteException;
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