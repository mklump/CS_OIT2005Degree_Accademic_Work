// ChatClient.java
// ChatClient is a remote interface that defines methods for a
// chat client to receive messages and status information from
// a ChatServer.
package com.deitel.messenger.rmi.client;

// Java core packages
import java.rmi.*;

// Deitel packages
import com.deitel.messenger.rmi.ChatMessage;

public interface ChatClient extends Remote {
   
   // method called by server to deliver message to client
   public void deliverMessage( ChatMessage message )
      throws RemoteException;
   
   // method called when server shuting down
   public void serverStopping() throws RemoteException;
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
