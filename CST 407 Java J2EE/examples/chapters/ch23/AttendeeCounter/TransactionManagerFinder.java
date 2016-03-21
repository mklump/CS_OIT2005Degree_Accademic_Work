// Fig: TransactionManagerFinder.java
// This application unicast discovers the 
// TransactionManager service.
package com.deitel.advjhtp1.javaspace.common;

// Jini core packages
import net.jini.core.discovery.LookupLocator;
import net.jini.core.lookup.*;
import net.jini.core.entry.Entry;
import net.jini.core.transaction.server.TransactionManager;

// Java core packages
import java.io.*;
import java.rmi.RMISecurityManager;
import java.net.*;

// Java extension package
import javax.swing.*;

public class TransactionManagerFinder {

   private TransactionManager transactionManager = null;

   public TransactionManagerFinder( String jiniURL )
   {
      LookupLocator locator = null;
      ServiceRegistrar registrar = null;

      System.setSecurityManager( new RMISecurityManager() );

      // get the lookup service locator at "jini://hostname" 
      // use default port
      try {
         locator = new LookupLocator( jiniURL );

         // get the registrar for the locator
         registrar = locator.getRegistrar();

         // specify the service requirement
         Class[] types = new Class[] { 
            TransactionManager.class };
         ServiceTemplate template = 
            new ServiceTemplate( null, types, null );
     
         // find the service       
         transactionManager = 
            (TransactionManager) registrar.lookup( template );
      } 
 
      // handle exception invalid jini URL
      catch ( MalformedURLException malformedURLException ) {
         malformedURLException.printStackTrace();
      }
       
      // handle exception I/O
      catch ( IOException ioException ) {
         ioException.printStackTrace();
      }
 
      // handle exception finding class
      catch ( ClassNotFoundException classNotFoundException ) {
         classNotFoundException.printStackTrace();
      }
 
      // does not find any matching service
      if ( transactionManager == null ) {
         System.out.println( "No matching service" );
      }

   } // end TransactionManagerFinder constructor

   public TransactionManager getTransactionManager()
   {
      return transactionManager;
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