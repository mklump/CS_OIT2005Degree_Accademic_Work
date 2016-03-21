// MulticastReceivingThread.java
// Receive and process multicasts from multicast group
package com.deitel.advjhtp1.p2p;

// Java core packages
import java.net.MulticastSocket;
import java.net.*;
import java.io.*;
import java.util.*;

// Deitel packages
import com.deitel.advjhtp1.p2p.PeerDiscoveryListener;

public class MulticastReceivingThread extends Thread 
   implements IMConstants {
   
   // HashMap containing peer names and time to live
   // used to implement leasing
   private HashMap peerTTLMap;

   // LeasingThread reference
   private LeasingThread leasingThread;

   // object that will respond to peer added or removed events
   private PeerDiscoveryListener peerDiscoveryListener;

   // MulticastSocket for receiving broadcast messages
   private MulticastSocket multicastSocket;

   // InetAddress of group for messages
   private InetAddress multicastNetAddress;

   // flag for terminating MulticastReceivingThread
   private boolean keepListening = true;

   // MulticastReceivingThread constructor
   public MulticastReceivingThread( String userName, 
      PeerDiscoveryListener peerEventHandler )
   {
      // invoke superclass constructor to name Thread
      super( "MulticastReceivingThread" );
      
      // set peerDiscoveryListener
      peerDiscoveryListener = peerEventHandler;
   
      // connect MulticastSocket to multicast address and port
      try {
         multicastSocket = 
            new MulticastSocket( MULTICAST_RECEIVING_PORT );

         multicastNetAddress = 
            InetAddress.getByName( MULTICAST_ADDRESS );

         // join multicast group to receive messages
         multicastSocket.joinGroup( multicastNetAddress );

         // set 5 second time-out when waiting for new packets
         multicastSocket.setSoTimeout( 5000 );
      }

      // handle exception connecting to multicast address
      catch( IOException ioException ) {
         ioException.printStackTrace();
      }
      
      peerTTLMap = new HashMap();

      // create Leasing thread which decrements TTL of peers
      leasingThread = new LeasingThread();
      leasingThread.setDaemon( true );
      leasingThread.start();   

   } // end MulticastReceivingThread constructor

   // listen for messages from multicast group
   public void run()
   {
      while( keepListening ) {
        
         // create buffer for incoming message
         byte[] buffer = new byte[ MESSAGE_SIZE ];

         // create DatagramPacket for incoming message
         DatagramPacket packet = new DatagramPacket( buffer, 
            MESSAGE_SIZE );

         // receive new DatagramPacket (blocking call)
         try {
            multicastSocket.receive( packet );
         }

         // handle exception when receive times out
         catch ( InterruptedIOException interruptedIOException ) {

            // continue to next iteration to keep listening
            continue;
         }
           
         // handle exception reading packet from multicast group
         catch ( IOException ioException ) {
            ioException.printStackTrace();
            break;
         }

         // put message data into String
         String message = new String( packet.getData(), 
            packet.getOffset(), packet.getLength() );
         
         // ensure non-null message
         if ( message != null ) {

            // trim extra whitespace from end of message
            message = message.trim();
            
            System.out.println( message );

            // decide if goodbye or hello
            if ( message.startsWith( HELLO_HEADER ) ) {
               processHello( 
                  message.substring( HELLO_HEADER.length() ),
                  packet.getAddress().getHostAddress()
               );
            }

            else if ( message.startsWith( GOODBYE_HEADER ) )
               processGoodbye( message.substring( 
                  GOODBYE_HEADER.length() ) );
         
         } // end if
      
      } // end while
      
      // leave multicast group and close MulticastSocket
      try {
         multicastSocket.leaveGroup( multicastNetAddress );
         multicastSocket.close();
      }

      // handle exception leaving group
      catch ( IOException ioException ) {
         ioException.printStackTrace();
      }
   
   } // end run

   // process hello message from peer
   public void processHello( String peerName, 
      String registryAddress  )
   {
      registryAddress += ( "/" + BINDING_NAME );
      synchronized( peerTTLMap )
      {
         
         // if it is a new peer, call peerAdded event
         if ( !peerTTLMap.containsKey( peerName ) ) {
               peerDiscoveryListener.peerAdded( peerName, 
                  registryAddress);
         }

         // add to map or if present, refresh TTL
         peerTTLMap.put( peerName, new Integer( PEER_TTL ) );
 
      } 
   }
   
   // process goodbye message from peer
   public void processGoodbye( String peerName )
   {
      synchronized( peerTTLMap )
      {
        System.out.println( "Removing peer" + peerName );
        if ( peerTTLMap.containsKey( peerName ) ) {
           peerDiscoveryListener.peerRemoved( peerName );
           peerTTLMap.remove( peerName );
        }
      }
   }

   // periodically decrements the TTL of peers listed
   private class LeasingThread extends Thread
   {
      public void run()
      {
         while ( keepListening )
         {
            // sleep
            try {
               Thread.sleep( MULTICAST_INTERVAL );
            }
            
            // InterruptedException may interrupt Thread Sleep
            catch ( InterruptedException interruptedException ) {
               interruptedException.printStackTrace();
            }

            // lock hashmap while decrementing TTL values
            synchronized( peerTTLMap ) {

               // decrement peers
               Iterator peerIterator = 
                  peerTTLMap.entrySet().iterator();
               
               while ( peerIterator.hasNext() ) {
                  // make new TTL of peer
                  Map.Entry tempMapEntry = 
                     ( Map.Entry ) peerIterator.next();
                 
                  Integer tempIntegerTTL = 
                     ( Integer ) tempMapEntry.getValue();
                  int tempIntTTL = tempIntegerTTL.intValue();
                  
                  // decrement TTL
                  tempIntTTL--;

                  // if lease expired, remove peer
                  if ( tempIntTTL < 0 ) {
                     peerDiscoveryListener.peerRemoved( 
                        ( String ) tempMapEntry.getKey() );
                     peerIterator.remove();
                  }

                  // otherwise set TTL of peer to new value
                  else
                     tempMapEntry.setValue( 
                        new Integer( tempIntTTL ) );
               
               } // end while iterating through peers

            } // end synchronized
         
         } // end while in run method 
      
      } // end run method
   
   } // end class LeasingThread

   // stop listening for multicasts
   public void logout()
   {
      // terminate thread
      keepListening = false;
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
