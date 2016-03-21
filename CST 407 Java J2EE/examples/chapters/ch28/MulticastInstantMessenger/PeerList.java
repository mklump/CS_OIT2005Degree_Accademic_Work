// PeerList.java
// Starts broadcasting and receiving threads
// and lists all IM peers in a window
package com.deitel.advjhtp1.p2p;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.net.MalformedURLException;
import java.util.*;
import java.util.List;
import java.io.IOException;
import java.rmi.*;

// Java extension packages
import javax.swing.*;
import javax.swing.event.*;

// Deitel Packages
import com.deitel.advjhtp1.jini.IM.service.IMService;
import com.deitel.advjhtp1.jini.IM.client.IMPeerListener;
import com.deitel.advjhtp1.jini.IM.IMPeerImpl;
import com.deitel.advjhtp1.jini.IM.IMPeer;

public class PeerList extends JFrame 
   implements PeerDiscoveryListener, IMConstants {
    
   // initialize userName to anonymous
   private String userName = "anonymous";
   private MulticastSendingThread multicastSender; 
   private MulticastReceivingThread multicastReceiver;
   
   // list variables
   private DefaultListModel peerNames;   // contains peer names
   private List peerStubAddresses;       // contains peer stubs
   private JList peerJList;

   // add peer name and peer stub to lists
   public void peerAdded( String name, String peerStubAddress )
   {
      // add name to peerNames
      peerNames.addElement( name );
       
      // add stub to peerStubAddresses
      peerStubAddresses.add( peerStubAddress );        
      
   } // end method peerAdded


   // removes services from PeerList GUI and data structure
   public void peerRemoved( String name )
   {
      // remove name from peerNames
      int index = peerNames.indexOf( name );
      peerNames.removeElementAt( index );
      
      // remove stub from peerStubAddresses
      peerStubAddresses.remove( index );

   } // end method peerRemoved

   // constructor
   public PeerList()
   {
      super( "Peer List" );

      // get desired userName
      userName = JOptionPane.showInputDialog( 
         PeerList.this, "Please enter your name: " );

      // change title of window
      setTitle( userName + "'s Peer List Window" );

      // Init List data structures
      peerNames = new DefaultListModel();
      peerStubAddresses = new ArrayList();
      
      // init components
      Container container = getContentPane();
      peerJList = new JList( peerNames );
      peerJList.setVisibleRowCount( 5 );
      JButton connectButton = new JButton( "Connect" );

      // do not allow multiple selections
      peerJList.setSelectionMode(
         ListSelectionModel.SINGLE_SELECTION );

      // set up event handler for connectButton
      connectButton.addActionListener(
         new ActionListener() {
          
            public void actionPerformed( ActionEvent event )
            {
               int itemIndex = peerJList.getSelectedIndex();

               String stubAddress = 
                  ( String ) peerStubAddresses.get( itemIndex );
               
               // get RMI reference to IMService and IMPeer
               try {

                  IMService peerStub = 
                     ( IMService ) Naming.lookup( "rmi://" +
                        stubAddress );

                  // set up gui and my peerImpl
                  IMPeerListener gui = 
                     new IMPeerListener( userName );
                  IMPeerImpl me = 
                     new IMPeerImpl( userName );
                  me.addListener( gui );

                  // Connect myGui to remote IMPeer object
                  IMPeer myPeer = peerStub.connect( me );
                  gui.addPeer( myPeer );
               }
               
               // malformedURL passed to lookup
                  catch( MalformedURLException exception ) {
                  JOptionPane.showMessageDialog
                     ( null, "Stub address incorrectly formatted" );
                  exception.printStackTrace();
               }
               

               // Remote object not bound to remote registry
               catch ( NotBoundException notBoundException ) {
                  JOptionPane.showMessageDialog
                     ( null, "Remote object not present in Registry" );
                  notBoundException.printStackTrace();
               }
               
               // connecting may cause RemoteException
               catch ( RemoteException remoteException ) {
                  JOptionPane.showMessageDialog
                     ( null, "Couldn't Connect" );
                  remoteException.printStackTrace();
               }      

            } // end method ActionPerformed
         
         } // end ActionListener anonymous inner class

      ); // end connectButton actionListener

      // set up File menu
      JMenu fileMenu = new JMenu( "File" );
      fileMenu.setMnemonic( 'F' );

      // about Item
      JMenuItem aboutItem = new JMenuItem( "About..." );
      aboutItem.setMnemonic( 'A' );
      aboutItem.addActionListener( 
         new ActionListener() {
            public void actionPerformed( ActionEvent event )
            {
               JOptionPane.showMessageDialog( PeerList.this, 
               "Deitel Instant Messenger" ,
               "About", JOptionPane.PLAIN_MESSAGE );
            }
         }
      );
            
      fileMenu.add( aboutItem );

      // set up JMenuBar and attach File menu
      JMenuBar menuBar = new JMenuBar();
      menuBar.add ( fileMenu );
      setJMenuBar( menuBar );

      // handow window closing event
      addWindowListener(

         new WindowAdapter(){

            public void windowClosing( WindowEvent w )
            {
               System.out.println( "CLOSING WINDOW" );
               
               // disconnects from lookup services
               multicastSender.logout();
               multicastReceiver.logout();
               
               // join threads
               try {
                  multicastSender.join();
                  multicastReceiver.join();
               }
               catch( InterruptedException interruptedException ) {
                  interruptedException.printStackTrace();
               }

               System.exit( 0 );
            }
         }
      );       

      // lay out GUI components     
      peerJList.setFixedCellWidth( 100 );
      JPanel inputPanel = new JPanel();
      inputPanel.add( connectButton );

      container.add( new JScrollPane( peerJList ) ,
         BorderLayout.NORTH );
      container.add( inputPanel, BorderLayout.SOUTH );

      // Initialize threads
      try {
         
         multicastReceiver = 
            new MulticastReceivingThread( userName, this );
         multicastReceiver.start();
         
         multicastSender = 
            new MulticastSendingThread( userName );  
         multicastSender.start();
         
      }
       
      // catch all exceptions and inform user of problem
      catch ( Exception managerException ) {
         JOptionPane.showMessageDialog( null, 
            "Error initializing MulticastSendingThread" +
            "or MulticastReceivingThread" );
         managerException.printStackTrace();
      }
   }
   
   public static void main( String args[] )
   {
      PeerList peerlist = new PeerList();
      peerlist.setSize( 100, 170 );
      peerlist.setVisible( true );
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