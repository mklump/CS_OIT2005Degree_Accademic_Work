// PrinterEventListener.java
// This class defines the listener that listens for events
// issued by a printer.
package com.deitel.advjhtp1.jiro.DynamicService.service;

// Java core packages
import java.rmi.*;
import java.rmi.server.UnicastRemoteObject;

// Jini core packages
import net.jini.core.event.*;

public class PrinterEventListener 
   implements RemoteEventListener  {

   private RemoteEventListener eventListener;

   // PrinterEventListener constructor
   public PrinterEventListener( RemoteEventListener listener )
   {
      eventListener = listener;

      // export the stub object
      try {
         UnicastRemoteObject.exportObject( this );
      }

      // handle exception exporting stub
      catch ( RemoteException remoteException ) {
         remoteException.printStackTrace();
      }

   } // end PrinterEventListener constructor

   // receive the notification
   public void notify( RemoteEvent remoteEvent )
      throws UnknownEventException, RemoteException
   {
      // forward notification 
      eventListener.notify( remoteEvent );
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
