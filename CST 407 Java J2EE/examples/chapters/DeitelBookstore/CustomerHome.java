// CustomerHome.java
// CustomerHome is the home interface for entity EJB Customer.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.rmi.RemoteException;

// Java extension packages
import javax.ejb.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;

public interface CustomerHome extends EJBHome {
    
   // create Customer EJB using given CustomerModel
   public Customer create( CustomerModel customerModel ) 
      throws RemoteException, CreateException;

   // find Customer with given userID and password
   public Customer findByLogin( String userID, String password ) 
      throws RemoteException, FinderException;

   // find Customer with given userID
   public Customer findByUserID( String userID ) 
      throws RemoteException, FinderException;
   
   // find Customer with given customerID
   public Customer findByPrimaryKey( Integer customerID )
      throws RemoteException, FinderException;
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
