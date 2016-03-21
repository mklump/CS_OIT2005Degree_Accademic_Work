/*
------------------------------------------------------------------
/// Author:         Matthew Klump for CST 407 JAVA J2EE
/// Date Created:   April 29, 2004
/// Last Change Date: April 29, 2004
/// Project:        Assignment #3, 10.4 & 10.8
/// Filename:       GuestBean.java
///
/// Overview:
///       Create a JSP and JDBC-based address book. Used the guest
///       book example of fig. 10.20 through 10.24 as a guide. Your
///       your address book will allow the user to insert entries,
///       delete entries, and search for entries.
///
/// Input:
///       Input is accepted from 
/// Output:
///       The output of this program is displayed 
-------------------------------------------------------------------
*/
// Class GuestDataBean makes a database connection and supports 
// inserting and retrieving data from the database.
package com.deitel.advjhtp1.jsp.beans;

// Java core packages
import java.io.*;
import java.sql.*;
import java.util.*;

public class GuestDataBean {
   private Connection connection;
   private PreparedStatement addRecord, getRecords;
   
   // construct TitlesBean object 
   public GuestDataBean() throws Exception
   {
      // load the Cloudscape driver
      Class.forName( "COM.cloudscape.core.RmiJdbcDriver" );

      // connect to the database
      connection = DriverManager.getConnection(
         "jdbc:rmi:jdbc:cloudscape:guestbook" );

      getRecords =
         connection.prepareStatement(
            "SELECT firstName, lastName, email FROM guests"
         );

      addRecord =
         connection.prepareStatement(
            "INSERT INTO guests ( " +
               "firstName, lastName, email ) " +
            "VALUES ( ?, ?, ? )"
         );
   }

   // return an ArrayList of GuestBeans
   public List getGuestList() throws SQLException
   {
      List guestList = new ArrayList();

      // obtain list of titles
      ResultSet results = getRecords.executeQuery();

      // get row data
      while ( results.next() ) {
         GuestBean guest = new GuestBean();

         guest.setFirstName( results.getString( 1 ) );
         guest.setLastName( results.getString( 2 ) );
         guest.setEmail( results.getString( 3 ) );

         guestList.add( guest ); 
      }         

      return guestList; 
   }
   
   // insert a guest in guestbook database
   public void addGuest( GuestBean guest ) throws SQLException
   {
      addRecord.setString( 1, guest.getFirstName() );
      addRecord.setString( 2, guest.getLastName() );
      addRecord.setString( 3, guest.getEmail() );
      
      addRecord.executeUpdate();
   }

   // close statements and terminate database connection
   protected void finalize()
   {
      // attempt to close database connection
      try {
         getRecords.close();
         addRecord.close();
         connection.close();
      }

      // process SQLException on close operation
      catch ( SQLException sqlException ) {
         sqlException.printStackTrace();
      }
   }
}
