// ShoppingCartEJB.java
// Stateful session EJB ShoppingCart represents a Customer's 
// shopping cart.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.util.*;
import java.rmi.RemoteException;
import java.text.DateFormat;

// Java extension packages
import javax.ejb.*;
import javax.naming.*;
import javax.rmi.PortableRemoteObject;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.exceptions.*;

public class ShoppingCartEJB implements SessionBean {
   private SessionContext sessionContext;

   // OrderProductModels (Products & quantities) in ShoppingCart
   private Collection orderProductModels; 

   // create new ShoppingCart
   public void ejbCreate() 
   { 
      orderProductModels = new ArrayList(); 
   }

   // get contents of ShoppingCart
   public Collection getContents() 
   { 
      return orderProductModels; 
   }

   // add Product with given ISBN to ShoppingCart
   public void addProduct( String isbn ) 
      throws ProductNotFoundException, EJBException
   {
      // check if Product with given ISBN is already 
      // in ShoppingCart
      Iterator iterator = orderProductModels.iterator();
      
      while ( iterator.hasNext() ) {
         OrderProductModel orderProductModel = 
            ( OrderProductModel ) iterator.next();
         
         ProductModel productModel = 
            orderProductModel.getProductModel();
         
         // if Product is in ShoppingCart, increment quantity
         if ( productModel.getISBN().equals( isbn ) ) { 
            
            orderProductModel.setQuantity( 
               orderProductModel.getQuantity() + 1 );
            
            return;
         }
         
      } // end while

      // if Product is not in ShoppingCart, find Product with
      // given ISBN and add OrderProductModel to ShoppingCart
      try {
         InitialContext context = new InitialContext();
         
         Object object = context.lookup( 
            "java:comp/env/ejb/Product" );
         
         ProductHome productHome = ( ProductHome )
            PortableRemoteObject.narrow( object, 
               ProductHome.class );
         
         // find Product with given ISBN
         Product product = productHome.findByPrimaryKey( isbn );
         
         // get ProductModel
         ProductModel productModel = product.getProductModel();
         
         // create OrderProductModel for ProductModel and set
         // its quantity
         OrderProductModel orderProductModel = 
            new OrderProductModel();
         
         orderProductModel.setProductModel( productModel );
         orderProductModel.setQuantity( 1 );
         
         // add OrderProductModel to ShoppingCart
         orderProductModels.add( orderProductModel );
         
      } // end try
      
      // handle exception when finding Product record
      catch ( FinderException finderException ) { 
         finderException.printStackTrace(); 
         
         throw new ProductNotFoundException( "The Product " +
            "with ISBN " + isbn + " was not found." );
      }    
      
      // handle exception when invoking Product EJB methods
      catch ( Exception exception ) { 
         throw new EJBException( exception ); 
      }
      
   } // end method addProduct

   // remove Product with given ISBN from ShoppingCart
   public void removeProduct( String isbn ) 
      throws ProductNotFoundException 
   {
      Iterator iterator = orderProductModels.iterator();
      
      while ( iterator.hasNext() ) {
         
         // get next OrderProduct in ShoppingCart
         OrderProductModel orderProductModel = 
            ( OrderProductModel ) iterator.next();
         
         ProductModel productModel = 
            orderProductModel.getProductModel();
         
         // remove Product with given ISBN from ShoppingCart
         if ( productModel.getISBN().equals( isbn ) ) {
            orderProductModels.remove( orderProductModel );
            
            return;
         }
         
      } // end while

      // throw exception if Product not found in ShoppingCart
      throw new ProductNotFoundException( "The Product " +
         "with ISBN " + isbn + " was not found in your " +
         "ShoppingCart." );
      
   } // end method removeProduct

   // set quantity of Product in ShoppingCart 
   public void setProductQuantity( String isbn, 
      int productQuantity ) throws ProductNotFoundException 
   {
      // throw IllegalArgumentException if uantity not valid
      if ( productQuantity < 0 )
         throw new IllegalArgumentException(
            "Quantity cannot be less than zero." );
      
      // remove Product if productQuantity less than 1
      if ( productQuantity == 0 ) {
         removeProduct( isbn );
         return;
      }
      
      Iterator iterator = orderProductModels.iterator();

      while ( iterator.hasNext() ) {
         
         // get next OrderProduct in ShoppingCart
         OrderProductModel orderProductModel = 
            ( OrderProductModel ) iterator.next();
         
         ProductModel productModel = 
            orderProductModel.getProductModel();
         
         // set quantity for Product with given ISBN
         if ( productModel.getISBN().equals( isbn ) ) {
            orderProductModel.setQuantity( productQuantity );
            return;
         }
         
      } // end while
      
      // throw exception if Product not found in ShoppingCart
      throw new ProductNotFoundException( "The Product " +
         "with ISBN " + isbn + " was not found in your " +
         "ShoppingCart." );
      
   } // end method setProductQuantity

   // checkout of store (i.e., create new Order)
   public Order checkout( String userID ) 
      throws ProductNotFoundException, EJBException
   {      
      // throw exception if ShoppingCart is empty
      if ( orderProductModels.isEmpty() )
         throw new ProductNotFoundException( "There were " +
            "no Products found in your ShoppingCart." );
      
      // create OrderModel for Order details
      OrderModel orderModel = new OrderModel();
      
      // set OrderModel's date to today's Date
      orderModel.setOrderDate( new Date() );
      
      // set list of OrderProduct in OrderModel
      orderModel.setOrderProductModels( orderProductModels );
      
      // set OrderModel's shipped flag to false
      orderModel.setShipped( false );
      
      // use OrderHome interface to create new Order
      try {
         InitialContext context = new InitialContext();
         
         // look up Order EJB
         Object object = context.lookup( 
            "java:comp/env/ejb/Order" );
         
         OrderHome orderHome = ( OrderHome )
            PortableRemoteObject.narrow( object, 
               OrderHome.class );
         
         // create new Order using OrderModel and 
         // Customer's userID
         Order order = orderHome.create( orderModel, userID );
         
         // empty ShoppingCart for further shopping
         orderProductModels = new ArrayList();
         
         // return Order EJB that was created
         return order;
         
      } // end try
      
      // handle exception when looking up Order EJB
      catch ( Exception exception ) { 
         throw new EJBException( exception ); 
      }    
      
   } // end method checkout

   // get total cost for Products in ShoppingCart
   public double getTotal() 
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
      
   } // end method getTotal
   
   // set SessionContext
   public void setSessionContext( SessionContext context ) 
   { 
      sessionContext = context; 
   }   

   // activate ShoppingCart EJB instance  
   public void ejbActivate() {}
   
   // passivate ShoppingCart EJB instance
   public void ejbPassivate() {}   
   
   // remove ShoppingCart EJB instance
   public void ejbRemove() {}
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
