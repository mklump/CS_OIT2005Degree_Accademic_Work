// RMIIIOPMessageManager.java
// RMIIIOPMessageManager implements the ChatClient remote 
// interface and manages incoming and outgoing chat messages 
// using RMI over IIOP.
package com.deitel.messenger.rmi_iiop.client;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.rmi.*;
import java.rmi.server.*;
import java.util.*;

// Java extension packages
import javax.rmi.*;
import javax.naming.*;

// Deitel packages
import com.deitel.messenger.*;
import com.deitel.messenger.rmi.client.ChatClient;
import com.deitel.messenger.rmi.ChatMessage;
import com.deitel.messenger.rmi.server.ChatServer;

public class RMIIIOPMessageManager extends PortableRemoteObject 
   implements ChatClient, MessageManager {

   // listeners for incoming messages and disconnect notifications
   private MessageListener messageListener;
   private DisconnectListener disconnectListener;
 
   // ChatServer for sending and receiving messages
   private ChatServer chatServer;
   
   // RMIMessageManager constructor
   public RMIIIOPMessageManager() throws RemoteException {}
   
   // connect to ChatServer
   public void connect( MessageListener listener ) 
      throws Exception
   {           
      // create naming Context for looking up server
      Context namingContext = new InitialContext();

      // find ChatServer remote object
      Object remoteObject = 
         namingContext.lookup( "ChatServer" );

      chatServer = ( ChatServer ) PortableRemoteObject.narrow(
         remoteObject, ChatServer.class );

      // register client with ChatServer to receive messages
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

      chatServer.unregisterClient( this );
      messageListener = null;

      // notify listener of disconnect
      fireServerDisconnected( "" );

   } // end method disconnect
   
   // send ChatMessage to ChatServer
   public void sendMessage( String fromUser, String message ) 
      throws Exception
   {
      if ( chatServer == null )
         return;
     
      // create ChatMessage with message text and user name
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
   
   // process server shutting down notification
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