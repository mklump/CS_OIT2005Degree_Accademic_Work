// ChatServerImpl.java
// ChatServerImpl implements the ChatServer remote interface
// to provide an RMI-based chat server.
package com.deitel.messenger.rmi.server;

// Java core packages
import java.io.*;
import java.net.*;
import java.rmi.*;
import java.rmi.activation.*;
import java.rmi.server.*;
import java.rmi.registry.*;
import java.util.*;

// Deitel packages
import com.deitel.messenger.rmi.ChatMessage;
import com.deitel.messenger.rmi.client.ChatClient;

public class ChatServerImpl extends Activatable 
   implements ChatServer, StoppableChatServer {
   
   // Set of ChatClient references
   private Set clients = new HashSet();
   
   // server object's name
   private String serverObjectName;
   
   // ChatServerImpl constructor
   public ChatServerImpl( ActivationID id, MarshalledObject data )
      throws RemoteException {
          
       // register activatable object and export on anonymous port
       super( id, 0 );
   }

   // register ChatServerImpl object with RMI registry.
   public void register( String rmiName ) throws RemoteException,
      IllegalArgumentException, MalformedURLException
   {
      // ensure registration name was provided
      if ( rmiName == null )
         throw new IllegalArgumentException( 
            "Registration name cannot be null" );

      serverObjectName = rmiName;
      
      // bind ChatServerImpl object to RMI registry
      try {

         // create RMI registry
         System.out.println( "Creating registry ..." );
         Registry registry  = 
            LocateRegistry.createRegistry( 1099 );
         
         // bind RMI object to default RMI registry
         System.out.println( "Binding server to registry ..." );
         registry.rebind( serverObjectName, this );
      } 
      
      // if registry already exists, bind to existing registry
      catch ( RemoteException remoteException ) {
         System.err.println( "Registry already exists. " +
            "Binding to existing registry ..." );
         Naming.rebind( serverObjectName, this ); 
      }
      
      System.out.println( "Server bound to registry" );
      
   } // end method register
   
   // register new ChatClient with ChatServer
   public void registerClient( ChatClient client ) 
      throws RemoteException 
   {
      // add client to Set of registered clients
      synchronized ( clients ) {
         clients.add( client );
      }
      
      System.out.println( "Registered Client: " + client );
      
   } // end method registerClient
   
   // unregister client with ChatServer
   public void unregisterClient( ChatClient client ) 
      throws RemoteException 
   {
      // remove client from Set of registered clients
      synchronized( clients ) {
         clients.remove( client );
      }
      
      System.out.println( "Unregistered Client: " + client );
      
   } // end method unregisterClient
   
   // post new message to chat server
   public void postMessage( ChatMessage message ) 
      throws RemoteException 
   {      
      Iterator iterator = null;
     
      // get Iterator for Set of registered clients
      synchronized( clients ) {
         iterator = new HashSet( clients ).iterator();
      }
      
      // send message to every ChatClient
      while ( iterator.hasNext() ) {

         // attempt to send message to client
         ChatClient client = ( ChatClient ) iterator.next();

         try {
            client.deliverMessage( message );
         }
      
         // unregister client if exception is thrown
         catch( Exception exception ) {
            System.err.println( "Unregistering absent client." );
            unregisterClient( client );
         }

      } // end while loop

   } // end method postMessage
   
   // notify each client that server is shutting down and 
   // terminate server application
   public void stopServer() throws RemoteException
   {
      System.out.println( "Terminating server ..." );
      
      Iterator iterator = null;
     
      // get Iterator for Set of registered clients
      synchronized( clients ) {
         iterator = new HashSet( clients ).iterator();
      }
      
      // send message to every ChatClient
      while ( iterator.hasNext() ) {
         ChatClient client = ( ChatClient ) iterator.next(); 
         client.serverStopping();
      }      
            
      // create Thread to terminate application after 
      // stopServer method returns to caller
      Thread terminator = new Thread(
         new Runnable() {
            
            // sleep for 5 seconds, print message and terminate
            public void run()
            {
               // sleep
               try {
                  Thread.sleep( 5000 );
               }
               
               // ignore InterruptedExceptions
               catch ( InterruptedException exception ) { 
               }
               
               System.err.println( "Server terminated" );
               System.exit( 0 );
            }
         }
      );
      
      terminator.start(); // start termination thread
      
   } // end method stopServer
}