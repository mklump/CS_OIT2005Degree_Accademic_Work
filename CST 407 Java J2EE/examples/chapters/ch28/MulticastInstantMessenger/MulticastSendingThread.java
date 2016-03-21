// MulticastSendingThread.java
// Sends a multicast periodically containing a remote reference 
// to the IMServiceImpl object
package com.deitel.advjhtp1.p2p;

// Java core packages
import java.net.MulticastSocket;
import java.net.*;
import java.rmi.*;
import java.rmi.registry.*;
import java.io.*;

// Deitel core packages
import com.deitel.advjhtp1.jini.IM.service.IMServiceImpl;
import com.deitel.advjhtp1.jini.IM.service.IMService;

public class MulticastSendingThread extends Thread 
   implements IMConstants {

   // InetAddress of group for messages
   private InetAddress multicastNetAddress;

   // MulticastSocket for multicasting messages
   private MulticastSocket multicastSocket;

   // Datagram packet to be reused
   private DatagramPacket multicastPacket;

   // stub of local peer
   private IMService peerStub; 
   
   // flag for terminating MulticastSendingThread
   private boolean keepSending = true;
   
   private String userName;
   
   // MulticastSendingThread constructor
   public MulticastSendingThread( String myName )
   {
      // invoke superclass constructor to name Thread
      super( "MulticastSendingThread" );
      
      userName = myName;
     
      // create a registry on default port 1099
      try {
      	   Registry registry = 
            LocateRegistry.createRegistry( 1099 );
         peerStub = new IMServiceImpl( userName );
         registry.rebind( BINDING_NAME, peerStub );
      }
      catch ( RemoteException remoteException ) {
         remoteException.printStackTrace();
      }
      
      try {

         // create MulticastSocket for sending messages
         multicastSocket = 
            new MulticastSocket ( MULTICAST_SENDING_PORT );
         
         // set TTL for Multicast Socket
         multicastSocket.setTimeToLive( MULTICAST_TTL );

         // use InetAddress reserved for multicast group
         multicastNetAddress = InetAddress.getByName(
            MULTICAST_ADDRESS ); 
         
         // create greeting packet
         String greeting = new String( HELLO_HEADER + userName );

         multicastPacket = new DatagramPacket(
            greeting.getBytes(), greeting.getBytes().length, 
            multicastNetAddress, MULTICAST_LISTENING_PORT );
      }
            
      // MULTICAST_ADDRESS IS UNKNOWN HOST
      catch ( java.net.UnknownHostException unknownHostException )
      {
         System.err.println( "MULTICAST_ADDRESS is unknown" );
         unknownHostException.printStackTrace();
      }

      // any other exception
      catch ( Exception exception )
      {
         exception.printStackTrace();
      }
   }
   
   // deliver greeting message to peers
   public void run()
   {
      while ( keepSending ) {

         // deliver greeting
         try {

            // send greeting packet
            multicastSocket.send( multicastPacket );
 
            Thread.sleep( MULTICAST_INTERVAL );
         }

         // handle exception delivering message
         catch ( IOException ioException ) {
            ioException.printStackTrace();
            continue;
         }
         catch ( InterruptedException interruptedException ) {
            interruptedException.printStackTrace();
         }

      } // end while
      
      multicastSocket.close();

   } // end method run

   // send goodbye message
   public void logout()
   {  
      String goodbye = new String( GOODBYE_HEADER + userName );
      System.out.println( goodbye );
      multicastPacket = new DatagramPacket(
         goodbye.getBytes(), goodbye.getBytes().length, 
         multicastNetAddress, MULTICAST_LISTENING_PORT );
     
      try {
         multicastSocket.send( multicastPacket );
         
         Naming.unbind( BINDING_NAME );
      }
      
      // error multicasting
      catch ( IOException ioException ) {
         System.err.println("Couldn't Say Goodbye");
         ioException.printStackTrace();
      }
      
      // unbinding may cause many possible exceptions
      catch ( Exception unbindingException ) {
         unbindingException.printStackTrace();
      }
      
      keepSending = false;

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
