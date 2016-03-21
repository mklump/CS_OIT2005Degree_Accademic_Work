// Order.java
// Order is the remote interface for entity EJB Order.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.rmi.RemoteException;

// Java extension packages
import javax.ejb.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;

public interface Order extends EJBObject {
   
   // get Order details as OrderModel
   public OrderModel getOrderModel() throws RemoteException;
   
   // set shipped flag
   public void setShipped( boolean flag ) 
      throws RemoteException;
   
   // get shipped flag
   public boolean isShipped() throws RemoteException;
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
