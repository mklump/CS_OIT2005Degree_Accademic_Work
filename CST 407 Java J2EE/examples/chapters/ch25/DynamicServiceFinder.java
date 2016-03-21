// DynamicServiceFinder.java
// This class discovers lookup services and
// gets dynamic service proxy.
package com.deitel.advjhtp1.jiro.DynamicService.common;

// Java core packages
import java.rmi.*;
import java.io.*;

// Jini core packages
import net.jini.core.entry.Entry;
import net.jini.core.lookup.*;

// Jini extension packages
import net.jini.discovery.*;
import net.jini.lookup.entry.ServiceInfo;

// Jiro packages
import javax.fma.util.*;

public class DynamicServiceFinder 
   implements DiscoveryListener {

   private int servicesFound = 0;
   private ServiceRegistrar[] registrars;
   private Entry[] entries;

   // DynamicServiceFinder constructor
   public DynamicServiceFinder ( 
      String domain, Entry[] serviceEntries )
   {
      System.setSecurityManager( new RMISecurityManager() );

      entries = serviceEntries;
      LookupDiscovery lookupDiscovery = null;

      // discover lookup services
      try {
         lookupDiscovery = new LookupDiscovery( 
            new String[] { domain } );
      }

      // catch the IOException
      catch ( IOException exception ) {
         Debug.debugException( 
            "discover lookup service", exception );
      }

      // install a listener
      lookupDiscovery.addDiscoveryListener ( this );

      // wait until woken up by notification
      try {

         synchronized ( this ) {
            wait();
         }
      }

      // handle exception waiting for notification
      catch ( Exception exception ) {
         Debug.debugException( 
            "wait for lookup service", exception );
      }

   } // end DynamicServiceFinder constructor

   // discover new lookup services
   public void discovered ( DiscoveryEvent event )
   {   
      // get the proxy registrars for those services
      registrars = event.getRegistrars();
      
      // wake up all waiting threads
      synchronized ( this ) {
         notifyAll();
      }
   }

   // discover invalid lookup services
   public void discarded( DiscoveryEvent event) {}

   // get dynamic service proxy
   public Object getService()
   {
      // search lookup service to get dynamic service proxy
      try {
         ServiceTemplate template = new ServiceTemplate( 
            null, null, entries );
         Object service = registrars[ 0 ].lookup( template );

         return service;
      }

      // handle exception getting dynamic service proxy
      catch ( Exception exception) {
         Debug.debugException( "getting proxy", exception );
      }

      return null;

   } // end method getService
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
