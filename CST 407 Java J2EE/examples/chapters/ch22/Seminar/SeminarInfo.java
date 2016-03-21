// SeminarInfo.java
// SeminarInfo is a Jini service that provides information
// about Seminars offered throughout the week.
package com.deitel.advjhtp1.jini.seminar.service;

// Java core packages
import java.io.*;
import java.rmi.server.UnicastRemoteObject;
import java.rmi.RemoteException;
import java.util.StringTokenizer;

// Deitel packages
import com.deitel.advjhtp1.jini.seminar.Seminar;

public class SeminarInfo extends UnicastRemoteObject 
   implements BackendInterface {
      
   // Strings that represent days of the week
   private static final String MONDAY = "MONDAY";
   private static final String TUESDAY = "TUESDAY";
   private static final String WEDNESDAY = "WEDNESDAY";
   private static final String THURSDAY = "THURSDAY";
   private static final String FRIDAY = "FRIDAY";
   
   // SeminarInfo no-argument constructor
   public SeminarInfo() throws RemoteException {}
   
   // get Seminar information for given day 
   public Seminar getSeminar( String date ) 
      throws RemoteException 
   {
      String[] titles = new String[] { "", "", "", "", "" };
      String[] locations = new String[] { "", "", "", "", "" };

      // read seminar information from text file
      try {
         String fileName = SeminarInfo.class.getResource(
            "SeminarInfo.txt" ).toString();
         fileName = fileName.substring( 6 );

         FileInputStream inputStream = 
            new FileInputStream( fileName );
         
         BufferedReader reader = new BufferedReader(
            new InputStreamReader( inputStream ));
         
         String line = reader.readLine();
        
         // read seminar info from the file
         for ( int lineNo = 0; ( line != null ) 
            && ( lineNo < 5 ); lineNo++ ) {            
            StringTokenizer tokenizer = 
               new StringTokenizer( line, ";" );      
           
            titles[ lineNo ] = tokenizer.nextToken();
            locations[ lineNo ] = tokenizer.nextToken();
            line = reader.readLine();
         }
      }
      
      // handle exception loading Seminar file
      catch ( FileNotFoundException fileException ) {
         fileException.printStackTrace();
      }

      // handle exception reading from Seminar file
      catch ( IOException ioException ) {
         ioException.printStackTrace();
      }

      // match given day of the week to available seminars
      if ( date.equalsIgnoreCase( MONDAY ) ) {
         return new Seminar( titles[ 0 ], locations[ 0 ] );
      } 
      else if ( date.equalsIgnoreCase( TUESDAY ) ) {
         return new Seminar( titles[ 1 ], locations[ 1 ] );
      } 
      else if ( date.equalsIgnoreCase( WEDNESDAY ) ) {
         return new Seminar( titles[ 2 ], locations[ 2 ] );
      } 
      else if ( date.equalsIgnoreCase( THURSDAY ) ) {
         return new Seminar( titles[ 3 ], locations[ 3 ] );
      }
      else if ( date.equalsIgnoreCase( FRIDAY ) ) {
         return new Seminar( titles[ 4 ], locations[ 4 ] );
      }
      else {
         return new Seminar( "Empty", "Not available" );
      }

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