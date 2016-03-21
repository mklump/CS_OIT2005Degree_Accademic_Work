// OrderProductPK.java
// OrderProductPK is a primary-key class for entity EJB 
// OrderProduct.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.io.*;

public class OrderProductPK implements Serializable {

   // primary-key fields
   public String ISBN;
   public Integer orderID;
   
   // no-argument constructor
   public OrderProductPK() {}  
   
   // construct OrderProductPK with ISBN and orderID
   public OrderProductPK( String isbn, Integer id )
   {
      ISBN = isbn;
      orderID = id;
   }
   
   // get ISBN 
   public String getISBN() 
   { 
      return ISBN; 
   }
   
   // get orderID
   public Integer getOrderID() 
   { 
      return orderID; 
   }
   
   // calculate hashCode for this Object
   public int hashCode() 
   { 
      return getISBN().hashCode() ^ getOrderID().intValue(); 
   }

   // custom implementation of Object equals method
   public boolean equals( Object object ) 
   {
      // ensure object is instance of OrderProductPK
      if ( object instanceof OrderProductPK ) {         
         OrderProductPK otherKey = 
            ( OrderProductPK ) object;
         
         // compare ISBNs and orderIDs
         return ( getISBN().equals( otherKey.getISBN() ) 
            && getOrderID().equals( otherKey.getOrderID() ) );
      }
      
      return false;
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
