// SeminarInfoJoinService.java
// SeminarInfoJoinService uses a JoinManager to find lookup
// services, register the Seminar service with the lookup 
// services and manage lease renewal.
package com.deitel.advjhtp1.jini.utilities.join;

// Java core packages
import java.rmi.RMISecurityManager;
import java.rmi.RemoteException;
import java.io.IOException;

// Jini core packages
import net.jini.core.lookup.ServiceID;
import net.jini.core.entry.Entry;

// Jini extension packages
import net.jini.lookup.entry.Name;
import net.jini.lease.LeaseRenewalManager;
import net.jini.lookup.JoinManager;
import net.jini.discovery.LookupDiscoveryManager;
import net.jini.lookup.ServiceIDListener;

// Deitel packages
import com.deitel.advjhtp1.jini.seminar.service.*;
import com.deitel.advjhtp1.jini.utilities.entry.*;

public class SeminarInfoJoinService implements ServiceIDListener {
   
   // SeminarInfoJoinService constructor
   public SeminarInfoJoinService()
   {
      // use JoinManager to register SeminarInfo service 
      // and manage lease
      try {
         
         // create LookupDiscoveryManager for discovering
         // lookup services
         LookupDiscoveryManager lookupManager = 
            new LookupDiscoveryManager( new String[] { "" }, 
               null, null );
               
         // create and set Entry name for service
         Entry[] entries = new Entry[ 1 ];
         entries[ 0 ] = new SeminarProvider( "Deitel" );
         
         // create JoinManager
         JoinManager manager = new JoinManager( createProxy(),
            entries, this, lookupManager, 
            new LeaseRenewalManager() );
      }

      // handle exception creating JoinManager
      catch ( IOException exception ) {
         exception.printStackTrace();
      }
      
   } // end SeminarInfoJoinService constructor

   // create seminar service proxy
   private SeminarInterface createProxy()
   {
      // get SeminarProxy for SeminarInfo service
      try {
         return new SeminarProxy( new SeminarInfo() );
      }

      // handle exception creating SeminarProxy
      catch ( RemoteException exception ) {
         exception.printStackTrace();
      }

      return null;
      
   } // end method createProxy

   // receive notification of ServiceID assignment
   public void serviceIDNotify( ServiceID serviceID )
   {
      System.err.println( "Service ID: " + serviceID );
   }

   // launch SeminarInfoJoinService
   public static void main( String args[] ) 
   {
      // set SecurityManager
      if ( System.getSecurityManager() == null ) {
         System.setSecurityManager( new RMISecurityManager() );
      }
      
      // create SeminarInfoJoinService
      new SeminarInfoJoinService();
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
