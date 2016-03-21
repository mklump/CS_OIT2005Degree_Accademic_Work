// IMServiceImpl.java
// IMServiceImpl implements IMService interface
// is service side of IM application
package com.deitel.advjhtp1.jini.IM.service;

// Java core packages
import java.io.*;
import java.rmi.server.UnicastRemoteObject;
import java.rmi.RemoteException;
import java.util.StringTokenizer;

// Deitel packages
import com.deitel.advjhtp1.jini.IM.IMPeer;
import com.deitel.advjhtp1.jini.IM.IMPeerImpl;
import com.deitel.advjhtp1.jini.IM.Message;
import com.deitel.advjhtp1.jini.IM.client.IMPeerListener;

public class IMServiceImpl extends UnicastRemoteObject 
   implements IMService, Serializable {
   
   private static final long SerialVersionUID = 20010808L;
   private String userName = "Anonymous";
   
   // IMService no-argument constructor
   public IMServiceImpl() throws RemoteException{}
   
   // IMService constructor takes userName
   public IMServiceImpl( String name ) throws RemoteException
   {
      userName = name;
   }
   
   // sets serviceís userName
   public void setUserName( String name ) 
   {
      userName = name;
   }
   
   // return RMI reference to an IMPeer on the receiver side
   public IMPeer connect( IMPeer sender )  
     throws RemoteException
   {
      // Make a GUI and IMPeerImpl to be sent to remote peer
      IMPeerListener listener = 
         new IMPeerListener( userName );
      
      IMPeerImpl me = new IMPeerImpl( userName );
      me.addListener( listener );
      
      // add remote peer to my GUI
      listener.addPeer( sender );
      
      //send my IMPeerImpl to him
      return me;
   
   }  // end method connect
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
