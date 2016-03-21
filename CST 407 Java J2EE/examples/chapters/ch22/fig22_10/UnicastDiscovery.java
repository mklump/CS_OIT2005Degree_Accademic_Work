// UnicastDiscovery.java
// UnicastDiscovery is an application that demonstrates Jini
// lookup service discovery for a known host (unicast).
package com.deitel.advjhtp1.jini.discovery;

// Java core packages
import java.rmi.*;
import java.net.*;
import java.io.*;
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;

// Jini core packages
import net.jini.core.discovery.LookupLocator;
import net.jini.core.lookup.ServiceRegistrar;

public class UnicastDiscovery extends JFrame {
   
   private JTextArea outputArea = new JTextArea( 10, 20 );
   private JButton discoverButton;
   
   // hostname for discovering lookup services
   private String hostname; 

   // UnicastDiscovery constructor
   public UnicastDiscovery( String host )
   {
      super( "UnicastDiscovery Output" );
      
      hostname = host; // set target hostname for discovery
      
      // create JButton to discover lookup services
      discoverButton = new JButton( "Discover Lookup Services" );
      discoverButton.addActionListener(      
         new ActionListener() {
            
            // discover lookup services on given host
            public void actionPerformed( ActionEvent event )
            {
               discoverLookupServices();
            }
         }  
      );
      
      Container contentPane = getContentPane();
      contentPane.add( outputArea, BorderLayout.CENTER );
      contentPane.add( discoverButton, BorderLayout.NORTH );

   } // end UnicastDiscovery constructor
 
   // discover lookup services on given host and get details
   // about each lookup service from ServiceRegistrar
   public void discoverLookupServices()
   {
      // construct Jini URL
      String lookupURL = "jini://" + hostname + "/";       

      // connect to the lookup service at lookupURL
      try {
         LookupLocator locator = new LookupLocator( lookupURL );
         outputArea.append( "Connecting to " + lookupURL + "\n" );

         // perform unicast discovery to get ServiceRegistrar
         ServiceRegistrar registrar = 
            locator.getRegistrar();

         // print lookup service information and
         outputArea.append( "Got ServiceRegistrar\n" +
            "  Lookup Service Host: " + locator.getHost() + "\n" +
            "  Lookup Service Port: " + locator.getPort() + "\n" );

         // get groups that lookup service supports
         String[] groups = registrar.getGroups();
         outputArea.append( "Lookup service supports " +
            + groups.length + " group(s):\n" );

         // get group names; if empty, write public
         for ( int i = 0; i < groups.length ; i++ ) {

            if ( groups[ i ].equals( "" ) )
               outputArea.append( "  public\n" );
            
            else
               outputArea.append( "  " + groups[ i ] + "\n" );
         }
      } 
      
      // handle exception if URL is invalid
      catch ( MalformedURLException exception ) {
         exception.printStackTrace();
         outputArea.append( exception.getMessage() );
      }
      
      // handle exception communicating with ServiceRegistrar
      catch ( RemoteException exception ) {
         exception.printStackTrace();
         outputArea.append( exception.getMessage() );
      }

      // handle ClassNotFoundException obtaining ServiceRegistrar
      catch ( ClassNotFoundException exception ) {
         exception.printStackTrace();
         outputArea.append( exception.getMessage() );
      }
      
      // handle IOException obtaining ServiceRegistrar
      catch ( IOException exception ) {
         exception.printStackTrace();
         outputArea.append( exception.getMessage() );
      }       
      
   } // end method discoverLookupServices

   // launch UnicastDiscovery application
   public static void main( String args[] )
   {
      // set SecurityManager
      if ( System.getSecurityManager() == null )
         System.setSecurityManager(
            new RMISecurityManager() );

      // check command-line arguments for hostname
      if ( args.length != 1 ) {
         System.err.println( 
            "Usage: java UnicastDiscovery hostname" );
      }
      
      // create UnicastDiscovery for given hostname
      else {
         UnicastDiscovery discovery = 
            new UnicastDiscovery( args[ 0 ] );
         
         discovery.setDefaultCloseOperation( EXIT_ON_CLOSE );
         discovery.pack();
         discovery.setVisible( true );
      }
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
