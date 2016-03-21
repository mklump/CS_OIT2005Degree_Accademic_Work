// JNIArrayWrapper.java
// Allows access to native methods

public class JNIArrayWrapper {

   // load library JNIArrayLibrary into JVM
   static {
      System.loadLibrary( "JNIArrayLibrary" );
   }

   // native c++ method
   public native int[] newRandomArray( int size );   

   // Java method that uses native method
   public void outputRandomNumbers( int amount ) 
   {
      int randomNumbers[] = newRandomArray( amount );   

      for ( int i = 0 ; i < amount ; i++ ) 
         System.out.println( randomNumbers[ i ] + 
            " random number " + i );
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
