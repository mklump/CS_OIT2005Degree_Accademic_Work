// GeneralDiscoveryUtility.java
// GeneralDiscoveryUtility demonstrates using class 
// LookupDiscoveryManager for performing multicast 
// and unicast discovery.
package com.deitel.advjhtp1.jini.utilities.discovery;

// Java core packages
import java.rmi.*;
import java.io.*;
import java.awt.*;
import java.awt.event.*;
import java.net.*;

// Java standard extensions
import javax.swing.*;
import javax.swing.border.*;

// Jini core packages
import net.jini.core.lookup.ServiceRegistrar;
import net.jini.core.discovery.LookupLocator;

// Jini extension packages
import net.jini.discovery.*;

public class GeneralDiscoveryUtility extends JFrame 
   implements DiscoveryListener {
      
   private LookupDiscoveryManager lookupManager;
   private JTextArea multicastArea = new JTextArea( 15, 20);
   private JTextArea unicastArea = new JTextArea( 15, 20 );

   // GeneralDiscoveryUtility constructor
   public GeneralDiscoveryUtility( String urls[] )
   {
      super( "GeneralDiscoveryUtility" );
      
      // lay out JTextAreas
      JPanel multicastPanel = new JPanel();
      multicastPanel.setBorder( 
         new TitledBorder( "Multicast (Group) Notifications" ) );
      multicastPanel.add( new JScrollPane( multicastArea ) );
      
      JPanel unicastPanel = new JPanel();
      unicastPanel.setBorder( 
         new TitledBorder( "Unicast (Locator) Notifications" ) );
      unicastPanel.add( new JScrollPane( unicastArea ) );
      
      Container contentPane = getContentPane();
      contentPane.setLayout( new FlowLayout() );
      contentPane.add( unicastPanel );
      contentPane.add( multicastPanel );      
      
      // get LookupLocators and LookupDiscoveryManager
      try {
         LookupLocator locators[] = 
            new LookupLocator[ urls.length ];

         // get array of LookupLocators
         for ( int i = 0; i < urls.length ; i++ ) 
            locators[ i ] = new LookupLocator( urls[ i ] );

         // instantiate a LookupDiscoveryManager object
         lookupManager = new LookupDiscoveryManager( 
            DiscoveryGroupManagement.ALL_GROUPS, locators, this );
      }
      
      // handle invalid Jini URL
      catch ( MalformedURLException exception ) {
         exception.printStackTrace();
      }

      // handle exception creating LookupDiscoveryManager
      catch ( IOException exception ) {
         exception.printStackTrace();
      }
      
   } // end GeneralDiscoveryUtility constructor

   // receive notifications of discovered lookup services.
   public void discovered( DiscoveryEvent event )
   {
      // get the proxy registrars for those services
      ServiceRegistrar[] registrars = event.getRegistrars();

      // display information for each lookup service found
      for ( int i = 0; i < registrars.length ; i++ ) {
         
         // display multicast results in multicastArea
         if ( lookupManager.getFrom( registrars[ i ] ) ==
            LookupDiscoveryManager.FROM_GROUP ) {
          
               displayServiceDetails( registrars[ i ],
                  multicastArea );
         }
      
         // display unicast results in unicastArea
         else
            displayServiceDetails( registrars[ i ], unicastArea );
      }
   
   } // end method discovered
   
   // display details of given ServiceRegistrar
   private void displayServiceDetails( 
      ServiceRegistrar registrar, final JTextArea outputArea )
   {
      try {
         final StringBuffer buffer = new StringBuffer();
         
         // get hostname and port number
         buffer.append( "Lookup Service: " );
         buffer.append( "\n   Host: " + 
            registrar.getLocator().getHost() );
         buffer.append( "\n   Port: " + 
            registrar.getLocator().getPort() );
         buffer.append( "\n   Group support: " );

         // get lookup service groups
         String[] groups = registrar.getGroups();

         // get group names; if empty write public
         for ( int i = 0; i < groups.length ; i++ ) {

            if ( groups[ i ].equals( "" ) )
               buffer.append( "public," );
            
            else
               buffer.append( groups[ i ] + "," );
         }
         
         buffer.append( "\n\n" );
                  
         // append information to outputArea
         SwingUtilities.invokeLater(
         
            // create Runnable for appending text
            new Runnable() {
               
               // append text and update caret position
               public void run()
               {
                  outputArea.append( buffer.toString() );
                  outputArea.setCaretPosition( 
                     outputArea.getText().length() );
               }
            }  
            
         ); // end call to invokeLater
         
      } // end try

      // handle exception communicating with lookup service
      catch ( RemoteException exception ) {
         exception.printStackTrace();
      }      
      
   } // end method displayServiceDetails

   // receive discarded lookup service notifications
   public void discarded( DiscoveryEvent event ) {}
   
   // launch GeneralDiscoveryUtility application
   public static void main( String[] args ) 
   {
      // set SecurityManager
      if ( System.getSecurityManager() == null )
         System.setSecurityManager( new RMISecurityManager() );
      
      // launch GeneralDiscoveryUtility for set of hostnames
      GeneralDiscoveryUtility utility = 
         new GeneralDiscoveryUtility( args );
      utility.setDefaultCloseOperation( EXIT_ON_CLOSE );
      utility.pack();
      utility.setVisible( true );
      
   } // end method main
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
