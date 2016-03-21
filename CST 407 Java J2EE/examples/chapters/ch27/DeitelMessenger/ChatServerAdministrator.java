// ChatServerAdministrator.java
// ChatServerAdministrator is a utility for starting and stopping
// the RMI-IIOP ChatServer implementation.
package com.deitel.messenger.rmi_iiop.server;

// Java core packages
import java.rmi.*;
import java.rmi.activation.*;
import java.util.*;

// Java extension packages
import javax.rmi.*;
import javax.naming.*;

// Deitel packages
import com.deitel.messenger.rmi.server.StoppableChatServer;

public class ChatServerAdministrator {
   
   // set up ChatServer object
   private static void startServer()
   {
      // register ChatServer in Naming Service
      try {
         
         // create ChatServerImpl object
         ChatServerImpl chatServerImpl = new ChatServerImpl();
      
         // create InitialContext for naming service
         Context namingContext = new InitialContext();
         
         System.err.println( "Binding server to naming service..." );
         
         // bind ChatServerImpl object to naming service
         namingContext.rebind( "ChatServer", chatServerImpl );
         
         System.out.println( "Server bound to naming service" );
         
      } // end try
      
      // handle exception registering ChatServer
      catch ( NamingException namingException ) {
         namingException.printStackTrace();
         System.exit( 1 );
      }
      
      // handle exception creating ChatServer
      catch ( RemoteException remoteException ) {
         remoteException.printStackTrace();
         System.exit( 1 );
      }
      
   } // end method startServer
   
   // terminate server
   private static void terminateServer()
   {
      // look up and terminate to ChatServer
      try {
         
         // create naming Context for looking up server
         Context namingContext = new InitialContext();
             
         // find ChatServer remote object
         Object remoteObject = 
            namingContext.lookup( "ChatServer" );
         
         // narrow remoteObject to StoppableChatServer
         StoppableChatServer chatServer = 
            ( StoppableChatServer ) PortableRemoteObject.narrow(
               remoteObject, StoppableChatServer.class );

         // stop ChatServer
         chatServer.stopServer();   
         
         // remove ChatServer from Naming Service
         namingContext.unbind( "ChatServer" );
         
      } // end try
      
      // handle exception looking up ChatServer
      catch ( NamingException namingException ) {
         namingException.printStackTrace();
      } 
      
      // handle exception communicating with ChatServer
      catch ( RemoteException remoteException ) {
         remoteException.printStackTrace();
      }
      
   } // end method terminateServer
   
   // launch ChatServerAdministrator application
   public static void main( String args[] )
   {
      // check command-line arguments and start or stop server
      if ( args[ 0 ].equals( "start" ) )
         startServer();
      
      else if ( args[ 0 ].equals( "stop" ) )
         terminateServer();
      
      // print usage information
      else
         System.err.println( 
            "Usage: java ChatServerAdministrator start | stop" );
      
   } // end method main
}