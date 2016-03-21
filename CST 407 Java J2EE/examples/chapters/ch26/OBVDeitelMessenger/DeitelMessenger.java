// DeitelMessenger.java
// DeitelMessenger uses ClientGUI and CORBAMessageManager to
package com.deitel.messenger.obvcorba.client;

// Deitel packages
import com.deitel.messenger.*;

public class DeitelMessenger {
   
   // launch DeitelMessenger application
   public static void main ( String args[] ) throws Exception 
   {     
      // create CORBAMessageManager for communicating with server
      MessageManager messageManager = new CORBAMessageManager( args );

      // configure and display chat window
      ClientGUI clientGUI = new ClientGUI( messageManager );
      clientGUI.setSize( 300, 400 );
      clientGUI.setResizable( false );
      clientGUI.setVisible( true );      
   }
}