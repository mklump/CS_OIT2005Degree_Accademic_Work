// RMIMessageManager.java
// RMIMessageManager implements the ChatClient remote interface
// and manages incoming and outgoing chat messages using RMI.
package com.deitel.messenger.rmi.client;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.rmi.*;
import java.rmi.server.*;
import java.util.*;

// Deitel packages
import com.deitel.messenger.*;
import com.deitel.messenger.rmi.*;
import com.deitel.messenger.rmi.server.ChatServer;

public class RMIMessageManager extends UnicastRemoteObject 
   implements ChatClient, MessageManager {

   // listeners for incoming messages and disconnect notifications
   private MessageListener messageListener;
   private DisconnectListener disconnectListener;
 
   private String serverAddress;
   private ChatServer chatServer;
   
   // RMIMessageManager constructor
   public RMIMessageManager( String server ) throws RemoteException
   {      
      serverAddress = server;
   }
   
   // connect to ChatServer
   public void connect( MessageListener listener ) 
      throws Exception
   {         
      // look up ChatServer remote object
      chatServer = ( ChatServer ) Naming.lookup(
         "rmi://" + serverAddress + "/ChatServer" );

      // register with ChatServer to receive messages
      chatServer.registerClient( this );
         
      // set listener for incoming messages
      messageListener = listener;
      
   } // end method connect
   
   // disconnect from ChatServer
   public void disconnect( MessageListener listener ) 
      throws Exception
   {
      if ( chatServer == null ) 
         return;
         
      // unregister with ChatServer
      chatServer.unregisterClient( this );

      // remove references to ChatServer and MessageListener
      chatServer = null;
      messageListener = null;
      
   } // end method disconnect
   
   // send ChatMessage to ChatServer
   public void sendMessage( String fromUser, String message ) 
      throws Exception
   {
      if ( chatServer == null )
         return;
      
      // create ChatMessage with message text and userName
      ChatMessage chatMessage = 
         new ChatMessage( fromUser, message );

      // post message to ChatServer
      chatServer.postMessage( chatMessage );
      
   }  // end method sendMessage 
   
   // process delivery of ChatMessage from ChatServer
   public void deliverMessage( ChatMessage message ) 
      throws RemoteException
   {
      if ( messageListener != null )
         messageListener.messageReceived( message.getSender(), 
            message.getMessage() );
   }   
   
   // method called when server shutting down
   public void serverStopping() throws RemoteException 
   {
      chatServer = null;
      fireServerDisconnected( "Server shut down." );
   }
   
   // register listener for disconnect notifications
   public void setDisconnectListener( 
      DisconnectListener listener )
   {
      disconnectListener = listener;
   }
   
   // send disconnect notification
   private void fireServerDisconnected( String message )
   {
      if ( disconnectListener != null )
         disconnectListener.serverDisconnected( message );
   }
}

/**************************************************************************
 * (C) Copyright 2001 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
