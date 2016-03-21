// Fig: JavaSpaceFinder.java
// This application unicast discovers the JavaSpaces service.
package com.deitel.advjhtp1.javaspace.common;

// Jini core packages
import net.jini.core.discovery.LookupLocator;
import net.jini.core.lookup.*;
import net.jini.core.entry.Entry;

// Jini extension package
import net.jini.space.JavaSpace;

// Java core packages
import java.io.*;
import java.rmi.*;
import java.net.*;

// Java extension package
import javax.swing.*;

public class JavaSpaceFinder {

   private JavaSpace space;

   public JavaSpaceFinder( String jiniURL )
   {
      LookupLocator locator = null;
      ServiceRegistrar registrar = null;

      System.setSecurityManager( new RMISecurityManager() );

      // get the lookup service locator at "jini://hostname" 
      // use default port and the registrar for the locator
      try {
         locator = new LookupLocator( jiniURL );
         registrar = locator.getRegistrar();
      } 
 
      // handle exception invalid jini URL
      catch ( MalformedURLException malformedURLException ) {
         malformedURLException.printStackTrace();
      }

      // handle exception I/O
      catch ( java.io.IOException ioException ) {
         ioException.printStackTrace();
      }
 
      // handle exception finding class
      catch ( ClassNotFoundException classNotFoundException ) {
         classNotFoundException.printStackTrace();
      }

      // specify the service requirement
      Class[] types = new Class[] { JavaSpace.class };
      ServiceTemplate template = 
         new ServiceTemplate( null, types, null );
     
      // find the service       
      try {
         space = 
            ( JavaSpace ) registrar.lookup( template );
      } 
 
      // handle exception getting JavaSpace
      catch ( RemoteException remoteException ) {
         remoteException.printStackTrace();
      }

      // does not find any matching service
      if ( space == null ) {
         System.out.println( "No matching service" );
      }

   } // end JavaSpaceFinder constructor

   public JavaSpace getJavaSpace()
   {
      return space;
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