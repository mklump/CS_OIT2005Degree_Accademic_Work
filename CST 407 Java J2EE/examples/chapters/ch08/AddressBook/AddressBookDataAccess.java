// Fig. 8.34: AddressBookDataAccess.java
// Interface that specifies the methods for inserting,
// updating, deleting and finding records.
package com.deitel.advjhtp1.jdbc.addressbook;

// Java core packages
import java.sql.*;

public interface AddressBookDataAccess {
      
   // Locate specified person by last name. Return 
   // AddressBookEntry containing information.
   public AddressBookEntry findPerson( String lastName );
   
   // Update information for specified person.
   // Return boolean indicating success or failure.
   public boolean savePerson( 
      AddressBookEntry person ) throws DataAccessException;

   // Insert a new person. Return boolean indicating 
   // success or failure.
   public boolean newPerson( AddressBookEntry person )
      throws DataAccessException;
      
   // Delete specified person. Return boolean indicating if 
   // success or failure.
   public boolean deletePerson( 
      AddressBookEntry person ) throws DataAccessException;
      
   // close data source connection
   public void close(); 
}  // end interface AddressBookDataAccess


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
