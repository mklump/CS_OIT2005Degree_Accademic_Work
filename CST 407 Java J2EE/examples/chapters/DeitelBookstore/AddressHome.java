// AddressHome.java
// AddressHome is the home interface for entity EJB Address.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.rmi.RemoteException;

// Java extension packages
import javax.ejb.EJBHome;
import javax.ejb.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;

public interface AddressHome extends EJBHome {
    
   // create Address EJB using given AddressModel
   public Address create( AddressModel address ) 
      throws RemoteException, CreateException;

   // find Address with given addressID
   public Address findByPrimaryKey( Integer addressID )
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