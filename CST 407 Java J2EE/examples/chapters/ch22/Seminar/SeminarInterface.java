// SeminarInterface.java
// SeminarInterface defines methods available from the SeminarInfo
// Jini service.
package com.deitel.advjhtp1.jini.seminar.service;

// Java core packages
import java.rmi.Remote;

// Deitel packages
import com.deitel.advjhtp1.jini.seminar.Seminar;

public interface SeminarInterface {
   
   // get Seminar for given date
   public Seminar getSeminar( String date );
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