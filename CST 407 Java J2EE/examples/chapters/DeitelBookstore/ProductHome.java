// ProductHome.java
// ProductHome is the home interface for entity EJB Product.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.rmi.RemoteException;
import java.util.Collection;

// Java extension packages
import javax.ejb.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;

public interface ProductHome extends EJBHome {
   
   // create Product EJB using given ProductModel
   public Product create( ProductModel productModel ) 
      throws RemoteException, CreateException;

   // find Product with given ISBN
   public Product findByPrimaryKey( String isbn ) 
      throws RemoteException, FinderException;

   // find all Products
   public Collection findAllProducts() 
      throws RemoteException, FinderException;

   // find Products with given title
   public Collection findByTitle( String title ) 
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
