// IMConstants.java
// contains constants used by IM application
package com.deitel.advjhtp1.p2p;

public interface IMConstants {
   
   public static final String MULTICAST_ADDRESS = "228.5.6.10";

   public static final int MULTICAST_TTL = 30;

   // port on local machine for broadcasting 
   public static final int MULTICAST_SENDING_PORT = 6800;

   // port on local machine for receiving broadcasts
   public static final int MULTICAST_RECEIVING_PORT = 6789;

   // port on multicast ip address to send packets 
   public static final int MULTICAST_LISTENING_PORT = 6789; 

   public static final String HELLO_HEADER = "HELLOIM: ";

   public static final String GOODBYE_HEADER = "GOODBYE: ";

   // time in milliseconds to wait between each multicast
   public static final int MULTICAST_INTERVAL = 10000; 

   // how many MUTLICAST_INTERVALS before LEASE EXPIRATION
   public static final int PEER_TTL = 5;
   
   public static final int MESSAGE_SIZE = 256; 

   public static String BINDING_NAME = "IMSERVICE";

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