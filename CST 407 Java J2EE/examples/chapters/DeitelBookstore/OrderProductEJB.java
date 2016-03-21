// OrderProductEJB.java
// Entity EJB OrderProductEJB represents the mapping between
// a Product and an Order, including the quantity of the 
// Product in the Order.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.rmi.RemoteException;

// Java extension packages
import javax.ejb.*;
import javax.naming.*;
import javax.rmi.PortableRemoteObject;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;

public class OrderProductEJB implements EntityBean {
   private EntityContext entityContext;

   // container-managed fields
   public String ISBN;
   public Integer orderID;
   public int quantity;
   
   // get OrderProduct details as OrderProductModel
   public OrderProductModel getOrderProductModel()
      throws EJBException
   {
      OrderProductModel model = new OrderProductModel();
      
      // get ProductModel for Product in this OrderProduct
      try {
         Context initialContext = new InitialContext();
         
         // look up Product EJB
         Object object = initialContext.lookup( 
            "java:comp/env/ejb/Product" );
         
         // get ProductHome interface
         ProductHome productHome = ( ProductHome ) 
            PortableRemoteObject.narrow( object, 
               ProductHome.class );
         
         // find Product using its ISBN
         Product product = 
            productHome.findByPrimaryKey( ISBN );
               
         // get ProductModel
         ProductModel productModel = 
            product.getProductModel();
         
         // set ProductModel in OrderProductModel
         model.setProductModel( productModel );
         
      } // end try
      
      // handle exception when looking up Product EJB
      catch ( Exception exception ) { 
         throw new EJBException( exception ); 
      }
      
      // set orderID and quantity in OrderProductModel
      model.setOrderID( orderID );
      model.setQuantity( quantity );
      
      return model;
      
   } // end method getOrderProductModel
   
   // set OrderProduct details using OrderProductModel
   private void setOrderProductModel( OrderProductModel model )
   {      
      ISBN = model.getProductModel().getISBN();
      orderID = model.getOrderID();
      quantity = model.getQuantity();
   }      
  
   // create OrderProduct for given OrderProductModel
   public OrderProductPK ejbCreate( OrderProductModel model )
   {
      setOrderProductModel( model );
      return null;
   }
   
   // perform any necessary post-creation tasks
   public void ejbPostCreate( OrderProductModel model ) {}

   // set EntityContext
   public void setEntityContext( EntityContext context ) 
   { 
      entityContext = context; 
   }

   // unset EntityContext
   public void unsetEntityContext() 
   { 
      entityContext = null; 
   }

   // activate OrderProduct EJB instance
   public void ejbActivate() 
   {
      OrderProductPK primaryKey = 
         ( OrderProductPK ) entityContext.getPrimaryKey();
      
      ISBN = primaryKey.getISBN();
      orderID = primaryKey.getOrderID();
   }

   // passivate OrderProduct EJB instance
   public void ejbPassivate() 
   {
      ISBN = null;
      orderID = null;
   }

   // remove OrderProduct EJB instance
   public void ejbRemove() {}

   // store OrderProduct EJB data in database
   public void ejbStore() {}

   // load OrderProduct EJB data from database
   public void ejbLoad() {}
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
