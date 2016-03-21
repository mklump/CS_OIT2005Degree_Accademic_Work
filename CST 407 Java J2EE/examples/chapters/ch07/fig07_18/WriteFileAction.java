// WriteFileAction.java
// WriteFileAction is a PrivilegedAction implementation that 
// simply writes a file to the local file system.
package com.deitel.advjhtp1.security.jaas;

// Java core packages
import java.io.*;
import java.security.PrivilegedAction;

public class WriteFileAction implements PrivilegedAction {
   
   // perform the PrivilegedAction
   public Object run() 
   {
      // attempt to write a message to the specified file
      try {
         File file = new File( "D:/", "privilegedFile.txt" );
         FileWriter fileWriter = new FileWriter( file );
         
         // write message to File and close FileWriter
         fileWriter.write( "Welcome to JAAS!" );
         fileWriter.close();
      }
      
      // handle exception writing file
      catch ( IOException ioException ) {
         ioException.printStackTrace();
      }
      
      return null;
      
   } // end method run
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
