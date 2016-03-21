// Fig. 8.28: ResultSetTableModel.java
// A TableModel that supplies ResultSet data to a JTable.
package com.deitel.advjhtp1.jdbc;

// Java core packages
import java.sql.*;
import java.util.*;

// Java extension packages
import javax.swing.table.*;

// ResultSet rows and columns are counted from 1 and JTable 
// rows and columns are counted from 0. When processing 
// ResultSet rows or columns for use in a JTable, it is 
// necessary to add 1 to the row or column number to manipulate
// the appropriate ResultSet column (i.e., JTable column 0 is 
// ResultSet column 1 and JTable row 0 is ResultSet row 1).
public class ResultSetTableModel extends AbstractTableModel {
   private Connection connection;
   private Statement statement;
   private ResultSet resultSet;
   private ResultSetMetaData metaData;
   private int numberOfRows;
   
   // initialize resultSet and obtain its meta data object;
   // determine number of rows
   public ResultSetTableModel( String driver, String url, 
      String query ) throws SQLException, ClassNotFoundException
   {
      // load database driver class
      Class.forName( driver );

      // connect to database
      connection = DriverManager.getConnection( url );

      // create Statement to query database
      statement = connection.createStatement( 
         ResultSet.TYPE_SCROLL_INSENSITIVE,
         ResultSet.CONCUR_READ_ONLY );

      // set query and execute it
      setQuery( query );
   }

   // get class that represents column type
   public Class getColumnClass( int column )
   {
      // determine Java class of column
      try {
         String className = 
            metaData.getColumnClassName( column + 1 );
         
         // return Class object that represents className
         return Class.forName( className );
      }
      
      // catch SQLExceptions and ClassNotFoundExceptions
      catch ( Exception exception ) {
         exception.printStackTrace();
      }
      
      // if problems occur above, assume type Object 
      return Object.class;
   }

   // get number of columns in ResultSet
   public int getColumnCount() 
   {      
      // determine number of columns
      try {
         return metaData.getColumnCount(); 
      }
      
      // catch SQLExceptions and print error message
      catch ( SQLException sqlException ) {
         sqlException.printStackTrace();
      }
      
      // if problems occur above, return 0 for number of columns
      return 0;
   }

   // get name of a particular column in ResultSet
   public String getColumnName( int column )
   {       
      // determine column name
      try {
         return metaData.getColumnName( column + 1 );  
      }
      
      // catch SQLExceptions and print error message
      catch ( SQLException sqlException ) {
         sqlException.printStackTrace();
      }
      
      // if problems, return empty string for column name
      return "";
   }

   // return number of rows in ResultSet
   public int getRowCount() 
   { 
      return numberOfRows;
   }

   // obtain value in particular row and column
   public Object getValueAt( int row, int column )
   { 
      // obtain a value at specified ResultSet row and column
      try {
         resultSet.absolute( row + 1 );
         
         return resultSet.getObject( column + 1 );
      }
      
      // catch SQLExceptions and print error message
      catch ( SQLException sqlException ) {
         sqlException.printStackTrace();
      }
      
      // if problems, return empty string object
      return "";
   }
   
   // close Statement and Connection
   protected void finalize()
   {
      // close Statement and Connection
      try {
         statement.close();
         connection.close();
      }
      
      // catch SQLExceptions and print error message
      catch ( SQLException sqlException ) {
         sqlException.printStackTrace();
      }
   }
   
   // set new database query string
   public void setQuery( String query ) throws SQLException 
   {
      // specify query and execute it
      resultSet = statement.executeQuery( query );

      // obtain meta data for ResultSet
      metaData = resultSet.getMetaData();

      // determine number of rows in ResultSet
      resultSet.last();                   // move to last row
      numberOfRows = resultSet.getRow();  // get row number      
      
      // notify JTable that model has changed
      fireTableStructureChanged();
   }
}  // end class ResultSetTableModel



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
