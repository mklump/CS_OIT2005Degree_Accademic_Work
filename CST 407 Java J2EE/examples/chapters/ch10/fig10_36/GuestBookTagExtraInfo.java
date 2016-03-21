// Fig.10.38: GuestBookTagExtraInfo.java
// Class that defines the variable names and types created by
// custom tag handler GuestBookTag.
package com.deitel.advjhtp1.jsp.taglibrary;

// Java core packages
import javax.servlet.jsp.tagext.*;

public class GuestBookTagExtraInfo extends TagExtraInfo {

   // method that returns information about the variables 
   // GuestBookTag creates for use in a JSP
   public VariableInfo [] getVariableInfo( TagData tagData )
   {
      VariableInfo firstName = new VariableInfo( "firstName", 
         "String", true, VariableInfo.NESTED );

      VariableInfo lastName = new VariableInfo( "lastName", 
         "String", true, VariableInfo.NESTED );
      
      VariableInfo email = new VariableInfo( "email", 
         "String", true, VariableInfo.NESTED );
      
      VariableInfo varableInfo [] = 
         { firstName, lastName, email };
      
      return varableInfo;
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