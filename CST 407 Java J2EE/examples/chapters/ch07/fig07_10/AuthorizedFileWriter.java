// AuthorizedFileWriter.java
// AuthorizedFileWriter writes to file using a security manager.
// Permissions must be given via policy files.
package com.deitel.advjhtp1.security.policyfile;

// Java core package
import java.io.*;

public class AuthorizedFileWriter {

   // launch application
   public static void main( String[] args )
   {
      // create and set security manager
      System.setSecurityManager( new SecurityManager() );

      // check command-line arguments for proper usage
      if ( args.length != 2 )
         System.err.println( "Usage: java com.deitel.advjhtp1." +
            "security.policyfile.AuthorizedFileWriter file " +
            "filebody" );

      // write fileBody to file
      else {

         String file = args[ 0 ];
         String fileBody = args[ 1 ];

         // write fileBody to file
         try {

            // create FileWriter
            FileWriter fileWriter = new FileWriter( file );

            fileWriter.write( fileBody );

            fileWriter.close();

            System.exit( 0 );
         } 

         // handle IO exception
         catch ( IOException ioException ) {
            ioException.printStackTrace();
            System.exit( 1 );
         }
      }
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
