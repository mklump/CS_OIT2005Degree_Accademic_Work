// Fig: AttendeeCounter.java
// This class defines the AttendeeCounter Entry object.
package com.deitel.advjhtp1.javaspace.common;

import net.jini.core.entry.Entry;

public class AttendeeCounter implements Entry {

   public String day;
   public Integer counter = new Integer( 0 );

   // empty constructor
   public AttendeeCounter() {}
  
   // constructor has a single String input
   public AttendeeCounter( String seminarDay )
   {
       day = seminarDay;
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