// JNIArrayMain.java
// Loads the native library, creates a new instance of the
// Java wrapper class, and calls for it to print 10 random
// numbers.

public class JNIArrayMain {

   // instantiate JNIArrayWrapper and call outputRandomNumbers
   public static void main( String args[] ) 
   {
      JNIArrayWrapper wrapper = new JNIArrayWrapper();
    
      // outputs ten random numbers
      wrapper.outputRandomNumbers( 10 );
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