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
// JavaBean to store data for a guest in the guestbook.
package com.deitel.advjhtp1.jsp.beans;

public class GuestBean {
   private String firstName, lastName, email;

   // set the guest's first name
   public void setFirstName( String name )
   {
      firstName = name;  
   }
   
   // get the guest's first name
   public String getFirstName()
   {
      return firstName;  
   }

   // set the guest's last name
   public void setLastName( String name )
   {
      lastName = name;  
   }

   // get the guest's last name
   public String getLastName()
   {
      return lastName;  
   }

   // set the guest's email address
   public void setEmail( String address )
   {
      email = address;
   }

   // get the guest's email address
   public String getEmail()
   {
      return email;  
   }
}