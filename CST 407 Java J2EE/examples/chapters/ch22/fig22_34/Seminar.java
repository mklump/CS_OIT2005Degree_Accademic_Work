// Seminar.java
// Seminar represents a seminar, or lecture, including the 
// Seminar title and location.
package com.deitel.advjhtp1.jini.seminar;

// Java core package
import java.io.Serializable;

public class Seminar implements Serializable
{
   private String title;
   private String location;
   private static final long serialVersionUID = 20010724L;

   // Seminar constructor
   public Seminar( String seminarTitle, String seminarLocation )
   {
      title = seminarTitle;
      location = seminarLocation;
   }

   // get String representation of Seminar object
   public String toString()
   {
      return "Seminar title: " + getTitle() + 
         "; location: " + getLocation();
   }
   
   // get Seminar title
   public String getTitle()
   {
      return title;
   }
   
   // get Seminar location
   public String getLocation()
   {
      return location;
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
