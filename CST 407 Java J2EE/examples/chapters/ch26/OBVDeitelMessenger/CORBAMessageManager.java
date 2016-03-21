// CORBAMessageManager.java
// CORBAMessageManager implements the ChatClient remote 
// interface and manages incoming and outgoing chat messages 
// using IIOP
package com.deitel.messenger.obvcorba.client;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.util.*;

// Java extension packages
import org.omg.CosNaming.*;
import org.omg.CosNaming.NamingContextPackage.*;
import org.omg.CORBA.*;

// Deitel packages
import com.deitel.messenger.*;
import com.deitel.messenger.obvcorba.client.ChatClient;
import com.deitel.messenger.obvcorba.*;
import com.deitel.messenger.obvcorba.server.*;

public class CORBAMessageManager extends _ChatClientImplBase
   implements MessageManager {

   // Any incoming ORB configuration parameters
   String [] configurationParameters;
   
   // listeners for incoming messages and disconnect notifications
   private MessageListener messageListener;
   private DisconnectListener disconnectListener;
 
   // ChatServer for sending and receiving messages
   private ChatServer chatServer;
   
   // CORBAMessageManager constructor
   public CORBAMessageManager( String [] parameters )
   {
       configurationParameters = parameters;
   }
   
   // connect to ChatServer
   public void connect( MessageListener listener ) 
      throws Exception
   {           

      // find ChatServer remote object
      ORB orb = ORB.init( configurationParameters, null );
      org.omg.CORBA.Object corbaObject =
         orb.resolve_initial_references( "NameService" );
      NamingContext naming = 
         NamingContextHelper.narrow( corbaObject );

      // Resolve the object reference in naming
      NameComponent nameComponent =
         new NameComponent( ChatServer.NAME, "" );
      NameComponent path[] = { nameComponent };
      chatServer = 
         ChatServerHelper.narrow( naming.resolve( path ) );

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
         new ChatMessageImpl( fromUser, message );

      // post message to ChatServer
      chatServer.postMessage( chatMessage );

   }  // end method sendMessage 
   
   // process delivery of ChatMessage from ChatServer
   public void deliverMessage( ChatMessage message ) 
   {
      if ( messageListener != null )
         messageListener.messageReceived( message.getSenderName(), 
            message.getMessage() );
   }   
   
   // process server shutting down notification
   public void serverStopping()
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
}   // end of CORBAMessageManager

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
