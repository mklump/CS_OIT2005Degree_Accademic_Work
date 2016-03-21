// IMService.java
// IMService interface defines the methods
// through which the service proxy
// communicates with the service.
package com.deitel.advjhtp1.jini.IM.service;

// Java core packages
import java.rmi.*;

// Deitel packages
import com.deitel.advjhtp1.jini.IM.IMPeer;

public interface IMService extends Remote {
   
   // return RMI reference to a remote IMPeer 
   public IMPeer connect( IMPeer sender ) 
      throws RemoteException;
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