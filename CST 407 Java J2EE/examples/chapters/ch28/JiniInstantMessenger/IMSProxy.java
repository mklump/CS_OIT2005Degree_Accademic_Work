// IMSProxy.java
// IMSProxy interface defines methods that IM services
// must implement
package com.deitel.advjhtp1.jini.IM.service;

//java core packages
import java.rmi.RemoteException;

// Deitel packages
import com.deitel.advjhtp1.jini.IM.Message;
import com.deitel.advjhtp1.jini.IM.IMPeer;

public interface IMSProxy
{
   // get a RMI reference to remote peer
   public IMPeer connect( IMPeer peer ) throws RemoteException;
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