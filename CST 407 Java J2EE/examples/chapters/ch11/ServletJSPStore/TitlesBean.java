// TitlesBean.java
// Class TitlesBean makes a database connection and retrieves 
// the books from the database.
package com.deitel.advjhtp1.store;

// Java core packages
import java.io.*;
import java.sql.*;
import java.util.*;

// Java extension packages
import javax.naming.*;
import javax.sql.*;

public class TitlesBean implements Serializable {
   private Connection connection;
   private PreparedStatement titlesQuery;
   
   // construct TitlesBean object 
   public TitlesBean() 
   {
      // attempt database connection and setup SQL statements
      try {
         InitialContext ic = new InitialContext();
   
         DataSource source =
            ( DataSource ) ic.lookup(
               "java:comp/env/jdbc/books" );
   
         connection = source.getConnection();

         titlesQuery =
            connection.prepareStatement(
               "SELECT isbn, title, editionNumber, " +
               "copyright, publisherID, imageFile, price " +
               "FROM titles ORDER BY title"
            );
      }

      // process exceptions during database setup
      catch ( SQLException sqlException ) {
         sqlException.printStackTrace();
      }

      // process problems locating data source
      catch ( NamingException namingException ) {
         namingException.printStackTrace();
      }
   }

   // return a List of BookBeans
   public List getTitles()
   {
      List titlesList = new ArrayList();

      // obtain list of titles
      try {
         ResultSet results = titlesQuery.executeQuery();
         
         // get row data
         while ( results.next() ) {
            BookBean book = new BookBean();
            
            book.setISBN( results.getString( "isbn" ) );
            book.setTitle( results.getString( "title" ) );
            book.setEditionNumber( 
               results.getInt( "editionNumber" ) );
            book.setCopyright( results.getString( "copyright" ) );
            book.setPublisherID(
               results.getInt( "publisherID" ) );
            book.setImageFile( results.getString( "imageFile" ) );
            book.setPrice( results.getDouble( "price" ) );

            titlesList.add( book ); 
         }         
      }

      // process exceptions during database query
      catch ( SQLException exception ) {
         exception.printStackTrace();
      }

      // return the list of titles
      finally {
         return titlesList;
      }
   }

   // close statements and terminate database connection
   protected void finalize()
   {
      // attempt to close database connection
      try {
         connection.close();
      }

      // process SQLException on close operation
      catch ( SQLException sqlException ) {
         sqlException.printStackTrace();
      }
   }
}


/***************************************************************
 * (C) Copyright 2001 by Deitel & Associates, Inc. and         *
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
