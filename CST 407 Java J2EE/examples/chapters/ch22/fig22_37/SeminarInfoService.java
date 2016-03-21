// SeminarInfoService.java
// SeminarInfoService discovers lookup services and registers
// the SeminarInfo service with those lookup services.
package com.deitel.advjhtp1.jini.seminar.service;

// Java core packages
import java.rmi.RMISecurityManager;
import java.rmi.RemoteException;
import java.io.IOException;

// Jini core packages
import net.jini.core.lookup.*;
import net.jini.core.entry.Entry;

// Jini extension packages
import net.jini.discovery.*;
import net.jini.lookup.entry.Name;

public class SeminarInfoService implements DiscoveryListener {
   
   private ServiceItem serviceItem;
   private final int LEASETIME = 10 * 60 * 1000;

   // SeminarInfoService constructor
   public SeminarInfoService()
   {
      // search for lookup services with public group
      try {
         LookupDiscovery discover = 
            new LookupDiscovery( new String[] { "" } );
            
         // add listener for DiscoveryEvents
         discover.addDiscoveryListener( this );
      }

      // handle exception creating LookupDiscovery
      catch ( IOException exception ) {
         exception.printStackTrace();
      }

      // create an Entry for this service
      Entry[] entries = new Entry[ 1 ];
      entries[ 0 ] = new
         com.deitel.advjhtp1.jini.utilities.entry.SeminarProvider(
            "Deitel" );

      // set the service's proxy and Entry name
      serviceItem = new ServiceItem(
         null, createProxy(), entries );
      
   } // end SeminarInfoService constructor

   // receive lookup service discovery notifications
   public void discovered( DiscoveryEvent event )
   {
      ServiceRegistrar[] registrars = event.getRegistrars();

      // register service with each lookup service
      for ( int i = 0; i < registrars.length; i++ ) {
         ServiceRegistrar registrar = registrars[ i ];

         // register service with discovered lookup service
         try {
            ServiceRegistration registration = 
               registrar.register( serviceItem, LEASETIME );
         } 

         // catch the remote exception
         catch ( RemoteException exception) {
            exception.printStackTrace();
         }
        
      } // end for
      
   } // end method discovered

   // ignore discarded lookup services
   public void discarded( DiscoveryEvent event ) {}
   
   // create the seminar service proxy
   private SeminarInterface createProxy()
   {
      // get BackendInterface for service and create SeminarProxy
      try {
         return new SeminarProxy( new SeminarInfo() );
      }

      // handle exception creating SeminarProxy
      catch ( RemoteException exception ) {
         exception.printStackTrace();
      }
      
      return null;

   } // end method discovered

   // method main keeps the application alive
   public static void main( String args[] )
   {
      // set SecurityManager
      if ( System.getSecurityManager() == null )
         System.setSecurityManager( new RMISecurityManager() );

      new SeminarInfoService();

      Object keepAlive = new Object();
      
      synchronized ( keepAlive ) {
         
         // keep application alive 
         try {
            keepAlive.wait();
         }

         // handle exception if wait interrupted
         catch ( InterruptedException exception ) {
            exception.printStackTrace();
         }
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
