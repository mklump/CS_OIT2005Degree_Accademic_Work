// IMServiceManager.java
// IMServiceManager uses JoinManager to find Lookup services,
// registers the IMService with the Lookup services,
// manages lease renewal
package com.deitel.advjhtp1.jini.IM;

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
import com.deitel.advjhtp1.jini.IM.service.*;

public class IMServiceManager implements ServiceIDListener {

   JoinManager manager;
   LookupDiscoveryManager lookupManager;
   String serviceName;
   
   // constructor takes name of the service
   public IMServiceManager( String screenName )
   {
      System.setSecurityManager( new RMISecurityManager() );
      
      // sets the serviceName of this service
      serviceName = screenName;
      
      // use JoinManager to register SeminarInfo service 
      // and manage lease
      try {
      
         // create LookupDiscoveryManager for discovering
         // lookup services
         lookupManager = 
            new LookupDiscoveryManager( new String[] { "" }, 
               null, null );
       
         // create and set Entry name for service
         // name used from constructor
         Entry[] entries = new Entry[ 1 ];
         entries[ 0 ] = new Name( serviceName );     
      
         // create JoinManager
         manager = new JoinManager( createProxy(),
         entries, this, lookupManager, 
            new LeaseRenewalManager() );
     }
      
     // handle exception creating JoinManager
     catch ( IOException exception ) {
        exception.printStackTrace();
     }
   } // end SeminarInfoJoinService constructor

   // return the LookupDiscoveryManager created by JoinManager
   public LookupDiscoveryManager getDiscoveryManager()
   {
      return lookupManager;
   }
   
   // create service proxy
   private IMService createProxy()
   {
      // get SeminarProxy for SeminarInfo service
      try {
         return( new IMServiceImpl( serviceName  ) );
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
   
   // informs all lookup services that service is ending
   public void logout()
   {
      manager.terminate();
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