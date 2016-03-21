// CartItemBean.java
// Class that maintains a book and its quantity.
package com.deitel.advjhtp1.store;

import java.io.*;

public class CartItemBean implements Serializable {
   private BookBean book;
   private int quantity;
   
   // initialize a CartItemBean
   public CartItemBean( BookBean bookToAdd, int number )
   {
      book = bookToAdd;
      quantity = number;
   }
   
   // get the book (this is a read-only property)
   public BookBean getBook()
   {
      return book;
   }

   // set the quantity
   public void setQuantity( int number )
   {
      quantity = number;
   }

   // get the quantity
   public int getQuantity()
   {
      return quantity;
   }
}

/***************************************************************
 * (C) Copyright 2001 by Deitel & Associates, Inc. and         *
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
