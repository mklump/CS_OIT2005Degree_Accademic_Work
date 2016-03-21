// SeminarInfoLeaseService.java
// SeminarInfoLeaseService discovers lookup services, registers
// the SeminarInfo service, and creates a LeaseRenewalManager
// to maintain the SeminarInfo service lease.
package com.deitel.advjhtp1.jini.utilities.leasing;

// Java core packages
import java.rmi.RMISecurityManager;
import java.rmi.RemoteException;
import java.io.IOException;

// Jini core packages
import net.jini.core.lookup.*;
import net.jini.core.entry.Entry;
import net.jini.core.lease.Lease;

// Jini extension packages
import net.jini.discovery.*;
import net.jini.lookup.entry.Name;
import net.jini.lease.LeaseRenewalManager;

// Deitel packages
import com.deitel.advjhtp1.jini.seminar.service.*;
import com.deitel.advjhtp1.jini.utilities.entry.SeminarProvider;

public class SeminarInfoLeaseService implements DiscoveryListener {

   private LookupDiscovery discover;
   private ServiceItem item;
   private static final int LEASETIME = 10 * 60 * 1000;

   // SeminarInfoLeaseService constructor
   public SeminarInfoLeaseService()
   {
      // search for lookup services with public group
      try {
         discover = new LookupDiscovery( new String[] { "" } );

         // register DiscoveryListener
         discover.addDiscoveryListener( this );
      }
       
      // handle exception creating LookupDiscovery
      catch ( IOException exception ) {
         exception.printStackTrace();
      }

      // create and set Entry name for service
      Entry[] entries = new Entry[ 1 ];
      entries[ 0 ] = new SeminarProvider( "Deitel" );

      // specify the service's proxy and entry
      item = new ServiceItem( null, createProxy(), entries );
      
   } // end SeminarInfoLeaseService constructor

   // receive notifications of discovered lookup services
   public void discovered ( DiscoveryEvent event )
   {
      ServiceRegistrar[] registrars = event.getRegistrars();

      // register the service with the lookup service
      for ( int i = 0; i < registrars.length; i++ ) {
         
         ServiceRegistrar registrar = registrars[ i ];

         // register the service with the lookup service
         try {
            ServiceRegistration registration = 
               registrar.register( item, LEASETIME );
            
            // create LeaseRenewalmanager
            LeaseRenewalManager leaseManager = 
               new LeaseRenewalManager();

            // renew SeminarInfo lease indefinitely
            leaseManager.renewUntil( registration.getLease(), 
               Lease.FOREVER, null );
            
         }  // end try        
         
         // handle exception registering ServiceItem
         catch ( RemoteException exception ) {
            exception.printStackTrace();
         } 
         
      } // end for
      
   } // end method discovered

   // ignore discarded lookup services
   public void discarded( DiscoveryEvent event ) {}
   
   // create seminar service proxy
   private SeminarInterface createProxy()
   {
      // get BackendInterface reference to SeminarInfo
      try {
         BackendInterface backInterface = new SeminarInfo();
         
         return new SeminarProxy( backInterface );
      }

      // handle exception creating SeminarProxy
      catch ( RemoteException exception ) {
         exception.printStackTrace();
      }

      return null;
      
   } // end method createProxy

   // launch SeminarInfoLeaseService
   public static void main( String args[] )
   {
      // set SecurityManager
      if ( System.getSecurityManager() == null ) {
         System.setSecurityManager( new RMISecurityManager() );
      }
      
      SeminarInfoLeaseService service = 
         new SeminarInfoLeaseService();

      Object keepAlive = new Object();

      // wait on keepAlive Object to keep service running
      synchronized ( keepAlive ) { 

         // keep application alive
         try {
            keepAlive.wait();
         }

         // handle exception if wait interrupted
         catch ( InterruptedException exception ) {
            exception.printStackTrace();
         }

      } // end synchronized block
      
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
