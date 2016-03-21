// ChatServer.java
// ChatServer is a remote interface that defines how a client 
// registers for a chat, leaves a chat and posts chat messages.
package com.deitel.messenger.rmi.server;

// Java core packages
import java.rmi.*;

// Deitel packages
import com.deitel.messenger.rmi.ChatMessage;
import com.deitel.messenger.rmi.client.ChatClient;

public interface ChatServer extends Remote {
   
   // register new ChatClient with ChatServer
   public void registerClient( ChatClient client )
      throws RemoteException;
   
   // unregister ChatClient with ChatServer
   public void unregisterClient( ChatClient client )
      throws RemoteException;
   
   // post new message to ChatServer
   public void postMessage( ChatMessage message ) 
      throws RemoteException;
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
