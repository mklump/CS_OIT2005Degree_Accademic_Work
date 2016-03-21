// JNIStaticMain.java
// Loads the native library, creates a new instance of the
// Java wrapper class and calls to print the static members
// of the MathConstants class.

public class JNIStaticMain {

   public static void main( String args[] ) 
   {
      JNIStaticWrapper wrapper = new JNIStaticWrapper();

      // access static members from MathConstants
      wrapper.printStaticMembers( new MathConstants() );
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
