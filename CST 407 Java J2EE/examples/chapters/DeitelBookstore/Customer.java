// Customer.java
// Customer is the remote interface for entity EJB Customer.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.rmi.RemoteException;
import java.util.Collection;

// Java extension packages
import javax.ejb.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.exceptions.*;

public interface Customer extends EJBObject {
   
   // get Customer data as a CustomerModel
   public CustomerModel getCustomerModel() 
      throws RemoteException;
   
   // get Order history for CustomerModel
   public Collection getOrderHistory() 
      throws RemoteException, NoOrderHistoryException;
   
   // get password hint for CustomerModel
   public String getPasswordHint() throws RemoteException;
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
