// JNIPIMain.java
// Loads the native library, creates a new instance of the
// Java wrapper class and uses native code to call getPI.

public class JNIPIMain {

   public static void main( String args[] ) 
   {
      JNIPIWrapper wrapper = new JNIPIWrapper();

      // Native code retrieves PI from instance of PIContainer
      double pi = wrapper.getPI( new PIContainer() );
      System.out.println( "PI is " + pi );

      // Native code retrieves PI, creates its own PIContainer
      double pi2 = wrapper.getPI();
      System.out.println( "PI2 is " + pi2 ); 
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
