// ShoppingCartHome.java
// ShoppingCartHome is the home interface for stateful session 
// EJB ShoppingCart.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.rmi.RemoteException;

// Java extension packages
import javax.ejb.*;

public interface ShoppingCartHome extends EJBHome {
   
   // create new ShoppingCart EJB
   public ShoppingCart create() 
      throws RemoteException, CreateException;
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
