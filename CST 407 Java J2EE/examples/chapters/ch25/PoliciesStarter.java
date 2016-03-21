// Fig: PoliciesStarter.java
// This application demonstrates how to obtain the proxies of
// management policies.
package com.deitel.advjhtp1.jiro.DynamicService.client;

// Java core package
import java.rmi.*;

// Jiro packages
import javax.fma.common.*;

// Deitel packages
import com.deitel.advjhtp1.jiro.DynamicService.policy.*;

public class PoliciesStarter {

   // PoliciesStarter constructor
   public PoliciesStarter( String domain ) {
   
      OutofPaperPolicy paperPolicyProxy;
      LowTonerPolicy tonerPolicyProxy;

      // set security manager
      if ( System.getSecurityManager() == null )
         System.setSecurityManager( new RMISecurityManager() );

      // obtain station address
      StationAddress stationAddress = 
         new StationAddress( domain, 
            null, null, null, null, null, null, null );

      // get the proxies of management policies
      try {
         paperPolicyProxy = 
            new OutofPaperPolicyImplProxy( stationAddress );
         tonerPolicyProxy = 
            new LowTonerPolicyImplProxy( stationAddress );
      }

      // handle exception getting proxies and starting policies
      catch ( RemoteException exception ) {
         exception.printStackTrace();
      }

   } // end PoliciesStarter constructor

   // method main
   public static void main( String args[] )
   {
      String domain = "";

      // get the domain name
      if ( args.length != 1 ) {
         System.out.println( 
            "Usage: PoliciesStarter Domain" );
         System.exit( 1 );
      }
      else 
         domain = args[ 0 ];

      PoliciesStarter policiesStarter = 
         new PoliciesStarter( domain );

   } // end main method
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
