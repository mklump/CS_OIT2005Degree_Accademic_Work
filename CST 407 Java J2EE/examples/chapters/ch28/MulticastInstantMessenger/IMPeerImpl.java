// IMPeerImpl.java
// Implements the IMPeer interface
package com.deitel.advjhtp1.jini.IM;

// Java core packages
import java.io.*;
import java.net.*;
import java.rmi.*;
import java.rmi.server.*;
import java.util.*;

// Deitel Packages
import com.deitel.advjhtp1.jini.IM.Message;
import com.deitel.advjhtp1.jini.IM.client.IMPeerListener;


public class IMPeerImpl extends UnicastRemoteObject 
   implements IMPeer {

   private String name;
   private IMPeerListener output;
   
   // No argument constructor
   public IMPeerImpl() throws RemoteException
   {
      super();
      name = "anonymous";
   }
   // constructor takes userName
   public IMPeerImpl( String myName ) throws RemoteException
   {
      name = myName;
   }
   
   public void addListener( IMPeerListener listener )
   {
      output = listener;
   }
   
   // send message to this peer
   public void sendMessage( Message message ) 
      throws RemoteException
   {
      output.displayMessage( message );
   }
   
   // accessor for name
   public String getName() throws RemoteException
   {
      return name;
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
