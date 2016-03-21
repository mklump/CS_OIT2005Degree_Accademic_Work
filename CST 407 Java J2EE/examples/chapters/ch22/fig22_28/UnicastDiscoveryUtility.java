// UnicastDiscoveryUtility.java
// Demonstrating how to locate multiple lookup services
// using LookupLocatorDiscovery utility
package com.deitel.advjhtp1.jini.utilities.discovery;

// Java core packages
import java.rmi.*;
import java.io.*;
import java.awt.*;
import java.awt.event.*;
import java.net.*;

// Java swing package
import javax.swing.*;

// Jini core packages
import net.jini.core.lookup.ServiceRegistrar;
import net.jini.core.discovery.LookupLocator;

// Jini extension packages
import net.jini.discovery.LookupLocatorDiscovery;
import net.jini.discovery.DiscoveryListener;
import net.jini.discovery.DiscoveryEvent;

public class UnicastDiscoveryUtility extends JFrame
   implements DiscoveryListener {
      
   private JTextArea outputArea = new JTextArea( 10, 20 );

   // UnicastDiscoveryUtility constructor
   public UnicastDiscoveryUtility( String urls[] )
   {
      super( "UnicastDiscoveryUtility" );

      getContentPane().add( new JScrollPane( outputArea ), 
         BorderLayout.CENTER );

      // discover lookup services using LookupLocatorDiscovery
      try {
         
         // create LookupLocator for each URL
         LookupLocator locators[] = 
            new LookupLocator[ urls.length ];

         for ( int i = 0; i < locators.length ; i++ ) 
            locators[ i ] = new LookupLocator( urls[ i ] );
   
         // create LookupLocatorDiscovery object
         LookupLocatorDiscovery locatorDiscovery = 
            new LookupLocatorDiscovery( locators );

         // register DiscoveryListener
         locatorDiscovery.addDiscoveryListener( this );
         
      } // end try

      // handle invalid Jini URL
      catch ( MalformedURLException exception ) {
         exception.printStackTrace();
      }      

   } // end UnicastDiscoveryUtility constructor
   
   // receive notification of found lookup services
   public void discovered( DiscoveryEvent event )
   {
      // get the proxy registrars for those services
      ServiceRegistrar[] registrars = event.getRegistrars();

      // display information for each lookup service found
      for ( int i = 0; i < registrars.length ; i++ )            
         displayServiceDetails( registrars[ i ] );
      
   } // end method discovered
   
   // display details of given ServiceRegistrar
   private void displayServiceDetails( ServiceRegistrar registrar )
   {
      try {
         final StringBuffer buffer = new StringBuffer();
         
         // get the hostname and port number
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

   // ignore discarded lookup services
   public void discarded( DiscoveryEvent event ) {}

   // launch UnicastDiscoveryUtility application
   public static void main( String args[] ) 
   {
      // set SecurityManager
      if ( System.getSecurityManager() == null )
         System.setSecurityManager( new RMISecurityManager() );
      
      // check command-line arguments for hostnames
      if ( args.length < 1 ) {
         System.err.println( 
            "Usage: java UnicastDiscoveryUtility " +
            "jini://hostname:port [ jini://hostname:port ] ..." );
      }
      
      // launch UnicastDiscoveryUtility for set of hostnames
      else {
         UnicastDiscoveryUtility unicastUtility = 
            new UnicastDiscoveryUtility( args );

         unicastUtility.setDefaultCloseOperation( EXIT_ON_CLOSE );
         unicastUtility.setSize( 300, 300 );
         unicastUtility.setVisible( true );
      }
      
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
