// OrderProductModel.java
// OrderProductModel represents a Product and its quantity in 
// an Order or ShoppingCart.
package com.deitel.advjhtp1.bookstore.model;

// Java core packages
import java.io.*;
import java.util.*;
import java.text.*;

// third-party packages
import org.w3c.dom.*;

public class OrderProductModel implements Serializable, 
   XMLGenerator {
      
   // OrderProductModel properties
   private ProductModel productModel;
   private int quantity;
   private Integer orderID;

   // set ProductModel
   public void setProductModel( ProductModel model ) 
   { 
      productModel = model;
   }

   // get ProductModel
   public ProductModel getProductModel() 
   { 
      return productModel;
   }
   
   // set quantity
   public void setQuantity( int productQuantity )
   {
      quantity = productQuantity;
   }
   
   // get quantity
   public int getQuantity()
   {
      return quantity;
   }
   
   // set orderID
   public void setOrderID( Integer id )
   {
      orderID = id;
   }
   
   // get orderID
   public Integer getOrderID()
   {
      return orderID;
   }

   // get XML representation of OrderProduct
   public Element getXML( Document document )
   {
      // create orderProduct Element
      Element orderProduct = 
         document.createElement( "orderProduct" );
      
      // append ProductModel product Element
      orderProduct.appendChild ( 
         getProductModel().getXML( document ) );
      
      // create quantity Element
      Element temp = document.createElement( "quantity" );      
      temp.appendChild( document.createTextNode( 
         String.valueOf ( getQuantity() ) ) );      
      orderProduct.appendChild( temp );
      
      return orderProduct;
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
