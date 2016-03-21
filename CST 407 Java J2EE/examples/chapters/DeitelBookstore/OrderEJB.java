// OrderEJB.java
// Entity EJB Order represents an Order, including the 
// orderID, Order date, total cost and whether the Order
// has shipped.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.util.*;
import java.text.DateFormat;
import java.rmi.RemoteException;

// Java extension packages
import javax.ejb.*;
import javax.naming.*;
import javax.rmi.PortableRemoteObject;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;

public class OrderEJB implements EntityBean  {
   private EntityContext entityContext;
   private InitialContext initialContext;
   private DateFormat dateFormat;

   // container-managed fields
   public Integer orderID;
   public Integer customerID;
   public String orderDate;
   public boolean shipped;
   
   // get Order details as OrderModel
   public OrderModel getOrderModel() throws EJBException
   {
      // construct new OrderModel
      OrderModel orderModel = new OrderModel();      

      // look up OrderProduct EJB to retrieve list 
      // of Products contained in the Order         
      try {
         
         // populate OrderModel data members with data from Order
         orderModel.setOrderID( orderID );
         orderModel.setOrderDate( dateFormat.parse( orderDate ) );
         orderModel.setShipped( shipped );         

         initialContext = new InitialContext();
        
         Object object = initialContext.lookup( 
            "java:comp/env/ejb/OrderProduct" );
         
         OrderProductHome orderProductHome =
            ( OrderProductHome ) PortableRemoteObject.narrow( 
               object, OrderProductHome.class );
         
         // get OrderProduct records for Order
         Collection orderProducts = 
            orderProductHome.findByOrderID( orderID );
         
         Iterator iterator = orderProducts.iterator();
         
         // OrderProductModels to place in OrderModel
         Collection orderProductModels = new ArrayList();         
         
         // get OrderProductModel for each Product in Order 
         while ( iterator.hasNext() ) {
            OrderProduct orderProduct = ( OrderProduct ) 
               PortableRemoteObject.narrow( iterator.next(),
                  OrderProduct.class );
            
            // get OrderProductModel for OrderProduct record
            OrderProductModel orderProductModel = 
               orderProduct.getOrderProductModel();
            
            // add OrderProductModel to list of 
            // OrderProductModels in the Order
            orderProductModels.add( orderProductModel );
         }
         
         // add Collection of OrderProductModels to OrderModel
         orderModel.setOrderProductModels( orderProductModels );
         
      } // end try
      
      // handle exception working with OrderProduct EJB
      catch ( Exception exception ) { 
         throw new EJBException( exception ); 
      }
      
      return orderModel;
      
   } // end method getOrderModel

   // set shipped flag
   public void setShipped( boolean flag ) 
   { 
      shipped = flag; 
   }

   // get shipped flag
   public boolean isShipped() 
   { 
      return shipped; 
   }

   // create new Order EJB using given OrderModel and userID
   public Integer ejbCreate( OrderModel order, String userID ) 
      throws CreateException 
   {
      // retrieve unique value for primary key of this
      // Order using SequenceFactory EJB
      try {
         initialContext = new InitialContext();
         
         Object object = initialContext.lookup( 
            "java:comp/env/ejb/SequenceFactory" );
         
         SequenceFactoryHome sequenceFactoryHome =
            ( SequenceFactoryHome ) 
               PortableRemoteObject.narrow( 
                  object, SequenceFactoryHome.class );
         
         // find sequence for CustomerOrder table
         SequenceFactory sequenceFactory = 
            sequenceFactoryHome.findByPrimaryKey( 
               "CustomerOrders" );
         
         // get next unique orderID
         orderID = sequenceFactory.getNextID();

         // get date, cost, shipped flag and list of 
         // OrderProduct from provided OrderModel
         orderDate = dateFormat.format( order.getOrderDate() );
         shipped = order.getShipped();
         
         // get OrderProductModels that comprise OrderModel
         Collection orderProductModels = 
            order.getOrderProductModels();

         // create OrderProduct EJBs for each Product in 
         // Order to keep track of quantity 
         object = initialContext.lookup( 
            "java:comp/env/ejb/OrderProduct" );
         
         OrderProductHome orderProductHome = 
            ( OrderProductHome ) PortableRemoteObject.narrow(
                  object, OrderProductHome.class );
         
         Iterator iterator = orderProductModels.iterator();
         
         // create an OrderProduct EJB with Product's
         // ISBN, quantity and orderID for this Order
         while ( iterator.hasNext() ) {
            
            OrderProductModel orderProductModel = 
               ( OrderProductModel ) iterator.next();
            
            // set orderID for OrderProduct record
            orderProductModel.setOrderID( orderID );

            // create OrderProduct EJB instance
            orderProductHome.create( orderProductModel );
         }

         // get customerID for customer placing Order
         object = initialContext.lookup( 
            "java:comp/env/ejb/Customer" );
         
         CustomerHome customerHome = 
            ( CustomerHome ) PortableRemoteObject.narrow( 
               object, CustomerHome.class );
         
         // use provided userID to find Customer
         Customer customer = 
            customerHome.findByUserID( userID );
         
         customerID = ( Integer ) customer.getPrimaryKey();
         
      } // end try
      
      // handle exception when looking up EJBs
      catch ( Exception exception ) { 
         throw new CreateException( exception.getMessage() ); 
      }
         
      return null;
      
   } // end method ejbCreate
   
   // perform any necessary post-creation tasks
   public void ejbPostCreate( OrderModel order, String id ) {}

   // set EntityContext
   public void setEntityContext( EntityContext context ) 
   { 
      entityContext = context; 
      dateFormat = DateFormat.getDateTimeInstance( 
         DateFormat.FULL, DateFormat.SHORT, Locale.US );
   }

   // unset EntityContext
   public void unsetEntityContext() 
   { 
      entityContext = null;
   }

   // activate Order EJB instance
   public void ejbActivate() 
   {
      orderID = ( Integer ) entityContext.getPrimaryKey();
   }

   // passivate Order EJB instance
   public void ejbPassivate() 
   {
      orderID = null;
   }

   // remove Order EJB instanceCus
   public void ejbRemove() {}

   // store Order EJB data in database
   public void ejbStore() {}

   // load Order EJB data from database
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
