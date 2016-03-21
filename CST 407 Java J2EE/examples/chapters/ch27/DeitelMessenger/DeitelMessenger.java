// DeitelMessenger.java
// DeitelMessenger uses ClientGUI and RMIIIOPMessageManager to
// implement an RMI over IIOP chat client.
package com.deitel.messenger.rmi_iiop.client;

// Java core packages
import java.rmi.RMISecurityManager;

// Deitel packages
import com.deitel.messenger.*;

public class DeitelMessenger {
   
   // launch DeitelMessenger application
   public static void main ( String args[] ) throws Exception 
   {     
      // create RMIIIOPMessageManager for communicating with server
      MessageManager messageManager = new RMIIIOPMessageManager();

      // configure and display chat window
      ClientGUI clientGUI = new ClientGUI( messageManager );
      clientGUI.setSize( 300, 400 );
      clientGUI.setResizable( false );
      clientGUI.setVisible( true );      
   }
}