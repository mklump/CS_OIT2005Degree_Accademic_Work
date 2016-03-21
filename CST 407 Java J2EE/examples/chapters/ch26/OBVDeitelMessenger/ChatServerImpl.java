// ChatServerImpl.java
// ChatServerImpl implements the ChatServer and StoppableChatServer
package com.deitel.messenger.obvcorba.server;

// Java core packages
import java.io.*;
import java.util.*;
import java.net.MalformedURLException;

// Java extension packages
import org.omg.CosNaming.*;
import org.omg.CosNaming.NamingContextPackage.*;
import org.omg.CORBA.*;

// Deitel packages
import com.deitel.messenger.obvcorba.ChatMessage;
import com.deitel.messenger.obvcorba.client.ChatClient;

public class ChatServerImpl extends _ChatServerImplBase {

   // The ORB that connects us to the network
   private ORB orb;
   
   // Set of ChatClient references
   private Map clients = new HashMap();
   
   // construct new ChatServerImpl
   public ChatServerImpl( String [] args )
      throws Exception
   {
      super();
      register( ChatServer.NAME, args );
   }
   
   // register new ChatClient with ChatServer
   public void registerClient( ChatClient client ) 
   {
      // add client to Set of registered clients
      String key = orb.object_to_string( client );
      synchronized ( clients ) {
         clients.put( key, client );
      }
      
      System.out.println( "Registered Client: " + key );
 
   } // end method registerClient
   
   // unregister client with ChatServer
   public void unregisterClient( ChatClient client ) 
   {
      // remove client from Map of registered clients
      String key = orb.object_to_string( client );
      synchronized ( clients ) {
         clients.remove( key );
      }
      
      System.out.println( "Unregistered Client: " + key );

   } // end method unregisterClient
   
   // post new message to ChatServer
   public void postMessage( ChatMessage message ) 
   {
System.out.println( "In postMessage()" );
      java.util.Iterator iterator = null;
     
      // get Iterator for Set of registered clients
      synchronized ( clients ) {
         iterator = new HashSet( clients.entrySet() ).iterator();
      }
      
      // send message to every ChatClient
      while ( iterator.hasNext() ) {
         ChatClient client = ( ChatClient ) ((Map.Entry)iterator.next()).getValue();
         client.deliverMessage( message );
      }
      
   } // end method postMessage
   
   // Register ChatServerImpl object with Naming Service
   public void register( String serverName, String [] parameters )
      throws NotFound, CannotProceed,
         org.omg.CosNaming.NamingContextPackage.InvalidName,
         org.omg.CORBA.ORBPackage.InvalidName
   {
      if ( serverName == null )
         throw new IllegalArgumentException( 
            "Registration name can not be null" );
 
      // Bind ChatServerImpl object to Naming Service.
      // Create and initialize ORB.
      orb = ORB.init( parameters, null );

      // create servant and register it with ORB
      orb.connect( this );

      org.omg.CORBA.Object corbaObject =
         orb.resolve_initial_references( "NameService" );
      NamingContext naming = 
         NamingContextHelper.narrow( corbaObject );
      NameComponent namingComponent =
         new NameComponent( serverName, "" );
      NameComponent path[] = { namingComponent };
      naming.rebind( path, this );
      System.out.println( "Server bound to naming" );
   }

   // notify each client that server is shutting down and 
   // terminate server application
   public void stopServer()
   {
      System.out.println( "Terminating server ..." );
      
      java.util.Iterator iterator = null;
     
      // get Iterator for Set of registered clients
      synchronized ( clients ) {
         iterator = new HashSet( clients.entrySet() ).iterator();
      }
      
      // send serverStopping message to every ChatClient
      while ( iterator.hasNext() ) {
         ChatClient client = ( ChatClient ) iterator.next();
         client.serverStopping();
         System.err.println( "Disconnected: " + client );
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
               catch ( InterruptedException exception ) {}
               
               System.err.println( "Server terminated" );
               System.exit( 0 );
            }
         }
      );
      
      terminator.start(); // start termination thread
      
   } // end method stopServer
   
   // main method to execute ChatServerImpl
   public static void main( String[] args )
   {
      // set up ChatServerImpl object and bind to Naming Service
      try {

         // create ChatServerImpl object
         ChatServerImpl chatServerImpl = 
            new ChatServerImpl( args );

         java.lang.Object object = new java.lang.Object();

         // keep server alive
         synchronized( object ) {
            object.wait();
         }
      }
   
      // process problems setting up ChatServerImpl object
      catch ( Exception exception ) {
         exception.printStackTrace();
         System.exit( 1 );
      }
      
   }   // end of method main()
}   // end of class ChatServerImpl

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
