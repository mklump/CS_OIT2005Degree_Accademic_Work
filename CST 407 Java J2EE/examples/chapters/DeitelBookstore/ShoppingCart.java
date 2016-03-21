// ShoppingCart.java
// ShoppingCart is the remote interface for stateful session
// EJB ShoppingCart.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.rmi.RemoteException;
import java.util.Collection;

// Java extension packages
import javax.ejb.EJBObject;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.exceptions.*;

public interface ShoppingCart extends EJBObject {
   
   // get contents of ShoppingCart
   public Collection getContents() throws RemoteException;
   
   // add Product with given ISBN to ShoppingCart
   public void addProduct( String isbn ) 
      throws RemoteException, ProductNotFoundException;
   
   // remove Product with given ISBN from ShoppingCart
   public void removeProduct( String isbn ) 
      throws RemoteException, ProductNotFoundException;
   
   // change quantity of Product in ShoppingCart with 
   // given ISBN to given quantity
   public void setProductQuantity( String isbn, int quantity )
      throws RemoteException, ProductNotFoundException,
         IllegalArgumentException;
   
   // checkout ShoppingCart (i.e., create new Order)
   public Order checkout( String userID ) 
      throws RemoteException, ProductNotFoundException;
   
   // get total cost for Products in ShoppingCart
   public double getTotal() throws RemoteException;
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
