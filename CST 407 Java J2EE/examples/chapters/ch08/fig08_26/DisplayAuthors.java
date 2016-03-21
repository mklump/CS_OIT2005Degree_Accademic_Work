// Fig. 8.26: DisplayAuthors.java
// Displaying the contents of table authors in database books.
 
// Java core packages
import java.awt.*;
import java.sql.*;
import java.util.*;

// Java extension packages
import javax.swing.*;

public class DisplayAuthors extends JFrame {
   
   // constructor connects to database, queries database,
   // processes results and displays results in window
   public DisplayAuthors() 
   {
      super( "Authors Table of Books Database" );
      
	 // connect to database books and query database
	 try
	 {
	 // load database driver class
	 // load database driver class

	 System.setProperty("db2j.system.home","\"C:\\Program Files\\IBM\\WebSphere Studio\\runtimes\\base_v5\"");

	 Class.forName("com.ibm.db2j.jdbc.DB2jDriver");
	 Connection connection=
	 DriverManager.getConnection("jdbc:db2j:books;upgrade=true");
	 // create Statement for querying database
	 Statement statement = connection.createStatement();
	 ResultSet resultSet =
            statement.executeQuery( "SELECT * FROM authors" );
         
         // process query results
         StringBuffer results = new StringBuffer();
         ResultSetMetaData metaData = resultSet.getMetaData();
         int numberOfColumns = metaData.getColumnCount();
         
         for ( int i = 1; i <= numberOfColumns; i++ ) {
            results.append( metaData.getColumnName( i )
               + "\t" );
         }
         
         results.append( "\n" );
         
         while ( resultSet.next() ) {
            
            for ( int i = 1; i <= numberOfColumns; i++ ) {
               results.append( resultSet.getObject( i ) 
                  + "\t" );
            }
            
            results.append( "\n" );
         }
         
         // close statement and connection
         statement.close();
         connection.close();            

         // set up GUI and display window
         JTextArea textArea = new JTextArea( 
            results.toString() );
         Container container = getContentPane();

         container.add( new JScrollPane( textArea ) );
         
         setSize( 300, 100 );  // set window size
         setVisible( true );   // display window
      }  // end try
      
      // detect problems interacting with the database
      catch ( SQLException sqlException ) {
         JOptionPane.showMessageDialog( null, 
            sqlException.getMessage(), "Database Error",
            JOptionPane.ERROR_MESSAGE );
         
         System.exit( 1 );
      }
      
      // detect problems loading database driver
      catch ( ClassNotFoundException classNotFound ) {
         JOptionPane.showMessageDialog( null, 
            classNotFound.getMessage(), "Driver Not Found",
            JOptionPane.ERROR_MESSAGE );

         System.exit( 1 );
      }
   }  // end DisplayAuthors constructor definition
   
   // launch the application
   public static void main( String args[] )
   {
      DisplayAuthors window = new DisplayAuthors();
      
      window.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );
   }
}  // end class DisplayAuthors


/**************************************************************************
 * (C) Copyright 2001 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
