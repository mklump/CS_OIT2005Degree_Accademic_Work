// SeminarProxy.java
// SeminarProxy is a proxy for the SeminarInfo Jini service. 
package com.deitel.advjhtp1.jini.seminar.service;

// Java core packages
import java.io.Serializable;
import java.rmi.*;

// Deitel packages
import com.deitel.advjhtp1.jini.seminar.Seminar;

public class SeminarProxy implements SeminarInterface, 
   Serializable {
      
   private BackendInterface backInterface;

   // SeminarProxy constructor
   public SeminarProxy( BackendInterface inputInterface )
   {
      backInterface = inputInterface;
   }

   // get Seminar for given date through BackendInterface
   public Seminar getSeminar( String date )
   {
      // get Seminar from service through BackendInterface
      try {
         return backInterface.getSeminar( date );
      }

      // handle exception communicating with back-end service
      catch ( RemoteException remoteException ) {
         remoteException.printStackTrace();
      }

      return null;
      
   } // end method getSeminar
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
