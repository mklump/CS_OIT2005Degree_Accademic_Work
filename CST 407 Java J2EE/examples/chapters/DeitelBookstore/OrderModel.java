// OrderModel.java
// OrderModel represents an Order and contains the order ID, 
// date, total cost and a boolean indicating whether or not the
// order has shipped.
package com.deitel.advjhtp1.bookstore.model;

// Java core packages
import java.io.*;
import java.util.*;
import java.text.*;

// third-party packages
import org.w3c.dom.*;

public class OrderModel implements Serializable, 
   XMLGenerator {
      
   // OrderModel properties
   private Integer orderID;
   private Date orderDate;
   private boolean shipped;
   private Collection orderProductModels;
   
   // construct empty OrderModel
   public OrderModel()
   {
      orderProductModels = new ArrayList();
   }

   // set order ID
   public void setOrderID( Integer id ) 
   { 
      orderID = id; 
   }

   // get order ID
   public Integer getOrderID() 
   { 
      return orderID; 
   }

   // set order date
   public void setOrderDate( Date date ) 
   { 
      orderDate = date; 
   }

   // get order date
   public Date getOrderDate() 
   { 
      return orderDate; 
   }

   // get total cost
   public double getTotalCost() 
   { 
      double total = 0.0;
      
      Iterator iterator = orderProductModels.iterator();
      
      // calculate Order's total cost
      while ( iterator.hasNext() ) {
         
         // get next OrderProduct in ShoppingCart
         OrderProductModel orderProductModel = 
            ( OrderProductModel ) iterator.next();
         
         ProductModel productModel = 
            orderProductModel.getProductModel();
         
         // add OrderProduct extended price to total
         total += ( productModel.getPrice() * 
            orderProductModel.getQuantity() );
      }
      
      return total;
   }

   // set shipped flag
   public void setShipped( boolean orderShipped ) 
   { 
      shipped = orderShipped; 
   }

   // get shipped flag
   public boolean getShipped() 
   { 
      return shipped; 
   }

   // set list of OrderProductModels
   public void setOrderProductModels( Collection models )
   { 
      orderProductModels = models; 
   }

   // get OrderProductModels
   public Collection getOrderProductModels() 
   { 
      return Collections.unmodifiableCollection( 
         orderProductModels );
   }

   // get XML representation of Order
   public Element getXML( Document document )
   {
      // create order Element
      Element order = document.createElement( "order" );
      
      // create orderID Element
      Element temp = document.createElement( "orderID" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( getOrderID() ) ) );
      order.appendChild( temp );
      
      // get DateFormat for writing Date to XML document
      DateFormat formatter = DateFormat.getDateTimeInstance(
         DateFormat.DEFAULT, DateFormat.MEDIUM, Locale.US );
      
      // create orderDate Element
      temp = document.createElement( "orderDate" );
      temp.appendChild( document.createTextNode( 
         formatter.format( getOrderDate() ) ) );
      order.appendChild( temp );
      
      NumberFormat costFormatter =
         NumberFormat.getCurrencyInstance( Locale.US );
      
      // create totalCost Element
      temp = document.createElement( "totalCost" );
      temp.appendChild( document.createTextNode( 
         costFormatter.format( getTotalCost() ) ) );
      order.appendChild( temp );
      
      // create shipped Element
      temp = document.createElement( "shipped" );
      
      if ( getShipped() )
         temp.appendChild( 
            document.createTextNode( "yes" ) );
      else
         temp.appendChild( 
            document.createTextNode( "no" ) );
      
      order.appendChild( temp );
      
      // create orderProducts Element
      Element orderProducts = 
         document.createElement( "orderProducts" );
      
      Iterator iterator = getOrderProductModels().iterator();
      
      // add orderProduct element for each OrderProduct
      while ( iterator.hasNext() ) {
         OrderProductModel orderProductModel = 
            ( OrderProductModel ) iterator.next();
         
         orderProducts.appendChild( 
            orderProductModel.getXML( document ) );
      }
      
      order.appendChild( orderProducts );

      return order;
      
   } // end method getXML
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
