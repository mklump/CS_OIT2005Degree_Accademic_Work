// DeitelMessenger.java
// DeitelMessenger uses a ClientGUI and RMIMessageManager to
// implement an RMI-based chat client.
package com.deitel.messenger.rmi.client;

// Java core packages
import java.rmi.RMISecurityManager;

// Deitel packages
import com.deitel.messenger.*;

public class DeitelMessenger {
   
   // launch DeitelMessenger application
   public static void main ( String args[] ) throws Exception 
   {     
      // install RMISecurityManager
      System.setSecurityManager( new RMISecurityManager() );
      
      MessageManager messageManager;
      
      // create new DeitelMessenger
      if ( args.length == 0 )
         messageManager = new RMIMessageManager( "localhost" );
      else
         messageManager = new RMIMessageManager( args[ 0 ] );  
      
      // finish configuring window and display it
      ClientGUI clientGUI = new ClientGUI( messageManager );
      clientGUI.pack();
      clientGUI.setResizable( false );
      clientGUI.setVisible( true );      
   }
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
