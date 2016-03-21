// UnicastSeminarInfoClient.java
// UnicastSeminarInfoClient uses unicast discovery to locate
// lookup services for the SeminarInfo service.
package com.deitel.advjhtp1.jini.seminar.client;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.io.*;
import java.rmi.*;
import java.net.*;
import java.util.*;

// Java extension packages
import javax.swing.*;

// Jini core packages
import net.jini.core.discovery.LookupLocator;
import net.jini.core.lookup.*;
import net.jini.core.entry.Entry;

// Jini extension packages
import net.jini.lookup.entry.Name;

// Deitel packages
import com.deitel.advjhtp1.jini.seminar.Seminar;
import com.deitel.advjhtp1.jini.seminar.service.SeminarInterface;

public class UnicastSeminarInfoClient extends JFrame {
   
   // Strings representing the days of the week on which 
   // Seminars are offered
   private static final String[] days = { "Monday", "Tuesday",
      "Wednesday", "Thursday", "Friday" };
   
   // hostname and ServiceRegistrar for lookup services
   private String hostname;
   private ServiceRegistrar registrar;
   
   // JButton for finding Seminars
   private JButton findSeminarButton;
   
   // UnicastSeminarInfoClient constructor
   public UnicastSeminarInfoClient( String host )
   {
      super( "UnicastSeminarInfoClient" );
      
      hostname = host; // set target hostname for discovery
      
      // create JButton for finding Seminars
      findSeminarButton = new JButton( "Find Seminar" );
      findSeminarButton.addActionListener(
      
         new ActionListener() {
            
            // discover lookup services, look up SeminarInfo
            // service, prompt user for desired day of the 
            // week and display available Seminars
            public void actionPerformed( ActionEvent event )
            {
               discoverLookupServices();

               SeminarInterface seminarService = 
                  lookupSeminarService();
               
               String day = ( String ) JOptionPane.showInputDialog( 
                  UnicastSeminarInfoClient.this, "Select Day", 
                  "Day Selection", JOptionPane.QUESTION_MESSAGE, 
                  null, days, days[ 0 ] );
               
               showSeminars( seminarService, day );               
            }
         }
         
      ); // end call to addActionListener
      
      JPanel buttonPanel = new JPanel();
      buttonPanel.add( findSeminarButton );
      
      getContentPane().add( buttonPanel, BorderLayout.CENTER );
      
   } // end UnicastSeminarInfoClient constructor

   // discover lookup services using unicast discovery
   private void discoverLookupServices()
   {
      String lookupURL = "jini://" + hostname + "/";

      // Get the lookup service locator at jini://hostname 
      // use default port
      try {
         LookupLocator locator = new LookupLocator( lookupURL );

         // return registrar
         registrar = locator.getRegistrar();
      } 
 
      // handle exceptions discovering lookup services
      catch ( Exception exception ) {
         exception.printStackTrace();
      }
      
   } // end method discoverLookupServices
   
   // lookup SeminarInfo service in given ServiceRegistrar
   private SeminarInterface lookupSeminarService()
   {
      // specify the service requirement
      Class[] types = new Class[] { SeminarInterface.class };
      Entry[] attribute = new Entry[] { new 
         com.deitel.advjhtp1.jini.utilities.entry.SeminarProvider(
            "Deitel" ) };
      ServiceTemplate template = 
         new ServiceTemplate( null, types, attribute );

      // find the service       
      try {
         SeminarInterface seminarInterface = 
            ( SeminarInterface ) registrar.lookup( template );
         return seminarInterface;
      } 
 
      // handle exception looking up SeminarInfo service
      catch ( RemoteException exception ) {
         exception.printStackTrace();
      }
      
      return null;    
      
   } // end method lookupSeminarService
   
   // show Seminar in given SeminarInfo service for given 
   // day of the week 
   private void showSeminars( SeminarInterface seminarService, 
      String day )
   {
      StringBuffer buffer = new StringBuffer();

      // get Seminar from SeminarInfo service 
      if ( seminarService != null ) {
         Seminar seminar = seminarService.getSeminar( day );

         // get subject and location from Seminar object
         buffer.append( "Seminar information: \n" );
         buffer.append( day + ":\n" );
         buffer.append( seminar.getTitle() + "\n" ); // title
         buffer.append( seminar.getLocation() );     // location
      }
      else  // SeminarInfo service does not available
         buffer.append( 
            "SeminarInfo service does not available. \n" );

      // display Seminar information
      JOptionPane.showMessageDialog( this, buffer );

   } // end method showSeminars

   // launch UnicastSeminarInfoClient application
   public static void main ( String args[] )
   {
      // check command-line arguments for hostname
      if ( args.length != 1 ) {
         System.err.println( 
            "Usage: java UnicastSeminarInfoClient hostname" );
      }
      
      // create UnicastSeminarInfoClient for given hostname
      else {
         System.setSecurityManager( new RMISecurityManager() );
         
         UnicastSeminarInfoClient client = 
            new UnicastSeminarInfoClient( args[ 0 ] );
        
         client.setDefaultCloseOperation( EXIT_ON_CLOSE );
         client.pack();
         client.setSize( 250, 65 );
         client.setVisible( true );
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
