// ChatServerImpl.java
// ChatServerImpl implements the ChatServer and StoppableChatServer
// remote interfaces using RMI over IIOP.
package com.deitel.messenger.rmi_iiop.server;

// Java core packages
import java.io.*;
import java.util.*;
import java.net.MalformedURLException;
import java.rmi.*;

// Java extension packages
import javax.rmi.*;

// Deitel packages
import com.deitel.messenger.rmi.ChatMessage;
import com.deitel.messenger.rmi.client.ChatClient;
import com.deitel.messenger.rmi.server.*;

public class ChatServerImpl extends PortableRemoteObject 
   implements ChatServer, StoppableChatServer {
   
   // Set of ChatClient references
   private Set clients = new HashSet();
   
   // construct new ChatServerImpl
   public ChatServerImpl() throws RemoteException
   {
      super();
   }
   
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
      synchronized ( clients ) {
         clients.remove( client );
      }
      
      System.out.println( "Unregistered Client: " + client );
      
   } // end method unregisterClient
   
   // post new message to ChatServer
   public void postMessage( ChatMessage message ) 
      throws RemoteException 
   {      
      Iterator iterator = null;
     
      // get Iterator for Set of registered clients
      synchronized ( clients ) {
         iterator = new HashSet( clients ).iterator();
      }
      
      // send message to every ChatClient
      while ( iterator.hasNext() ) {
         ChatClient client = ( ChatClient ) iterator.next();         
         client.deliverMessage( message );
      }
      
   } // end method postMessage
   
   // notify each client that server is shutting down and 
   // terminate server application
   public void stopServer() throws RemoteException
   {
      System.out.println( "Terminating server ..." );
      
      Iterator iterator = null;
     
      // get Iterator for Set of registered clients
      synchronized ( clients ) {
         iterator = new HashSet( clients ).iterator();
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
