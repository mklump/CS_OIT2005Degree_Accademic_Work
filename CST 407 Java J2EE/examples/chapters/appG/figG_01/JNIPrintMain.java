// JNIPrintMain.java
// Loads the native library, creates a new instance of the
// Java wrapper class, and calls the native methods.

public class JNIPrintMain{

   // uses JNI to print a message
   public static void main( String args[] ) 
   {
      JNIPrintWrapper wrapper = new JNIPrintWrapper();

      // call to native methods through JNIWrapper
      wrapper.printMessage( "Hello World\n" );
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
