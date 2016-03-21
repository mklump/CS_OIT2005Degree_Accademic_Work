// CustomerEJB.java
// Entity EJB Customer represents a Customer, including
// the Customer's user name, password, billing 
// address, shipping address and credit card information.
package com.deitel.advjhtp1.bookstore.ejb;

// Java core packages
import java.util.*;
import java.rmi.RemoteException;

// Java extension packages
import javax.ejb.*;
import javax.naming.*;
import javax.rmi.PortableRemoteObject;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.exceptions.*;

public class CustomerEJB implements EntityBean {
   private EntityContext entityContext;
   private InitialContext initialContext;

   // container-managed fields
   public Integer customerID;
   public String userID;
   public String password;
   public String passwordHint;
   public String firstName;
   public String lastName;
   public Integer billingAddressID;
   public Integer shippingAddressID;

   public String creditCardName;
   public String creditCardNumber;
   public String creditCardExpirationDate;   

   // get CustomerModel
   public CustomerModel getCustomerModel() throws EJBException
   {
      // construct new CustomerModel
      CustomerModel customer = new CustomerModel();
      
      // populate CustomerModel with data for this Customer  
      customer.setCustomerID( customerID );
      customer.setUserID( userID );
      customer.setPassword( password );
      customer.setPasswordHint( passwordHint );
      customer.setFirstName( firstName );
      customer.setLastName( lastName );
      
      // use Address EJB to get Customer billing and shipping
      // Address instances
      try {         
         initialContext = new InitialContext();         
         
         Object object = initialContext.lookup( 
            "java:comp/env/ejb/Address" );

         AddressHome addressHome = ( AddressHome ) 
            PortableRemoteObject.narrow( object, 
               AddressHome.class );    
         
         // get remote reference to billing Address
         Address billingAddress = 
            addressHome.findByPrimaryKey( billingAddressID );
         
         // add billing AddressModel to CustomerModel
         customer.setBillingAddress( 
            billingAddress.getAddressModel() );
         
         // get remote reference to shipping Address
         Address shippingAddress = 
            addressHome.findByPrimaryKey( shippingAddressID);
         
         // add shipping AddressModel to CustomerModel
         customer.setShippingAddress(
            shippingAddress.getAddressModel() );
         
      } // end try
      
      // handle exception using Address EJB
      catch ( Exception exception ) {
         throw new EJBException( exception );
      }

      // set credit card information in CustomerModel
      customer.setCreditCardName( creditCardName );
      customer.setCreditCardNumber( creditCardNumber );
      customer.setCreditCardExpirationDate( 
         creditCardExpirationDate );
      
      return customer;
      
   } // end method getCustomerModel

   // get Order history for Customer
   public Collection getOrderHistory() 
      throws NoOrderHistoryException, EJBException
   {
      Collection history = new ArrayList();
      
      // use Order EJB to obtain list of Orders for Customer      
      try {         
         initialContext = new InitialContext();         
         
         Object object = initialContext.lookup( 
            "java:comp/env/ejb/Order" );

         OrderHome orderHome = ( OrderHome ) 
            PortableRemoteObject.narrow( object, 
               OrderHome.class );
         
         // find Orders for this Customer 
         Collection orders = 
            orderHome.findByCustomerID( customerID );
         
         Iterator iterator = orders.iterator();
         
         // use list of Orders to build Order history
         while ( iterator.hasNext() ) {
            Order order = ( Order ) PortableRemoteObject.narrow( 
               iterator.next(), Order.class );
            
            // retrieve OrderModel for the Order
            OrderModel orderModel = order.getOrderModel();
            
            // add each OrderModel to Order history
            history.add( orderModel );
         }
         
      } // end try
      
      // handle exception when finding Order records
      catch ( FinderException finderException ) {
         throw new NoOrderHistoryException( "No order " +
            "history found for the customer with userID " +
            userID );
      }
      
      // handle exception when invoking Order EJB methods
      catch ( Exception exception ) {
         exception.printStackTrace(); 
         throw new EJBException( exception ); 
      }
         
      return history;
      
   } // end method getOrderHistory

   // get password hint for Customer
   public String getPasswordHint() 
   { 
      return passwordHint; 
   }
   
   // set Customer data using CustomerModel
   private void setCustomerModel( CustomerModel customer )
   {
      // set Customer data members to CustomerModel values
      userID = customer.getUserID();
      password = customer.getPassword();
      passwordHint = customer.getPasswordHint();
      firstName = customer.getFirstName();
      lastName = customer.getLastName();
      
      billingAddressID = 
         customer.getBillingAddress().getAddressID();
      
      shippingAddressID = 
         customer.getShippingAddress().getAddressID();
       
      creditCardName = customer.getCreditCardName();
      creditCardNumber = customer.getCreditCardNumber();
      
      creditCardExpirationDate = 
         customer.getCreditCardExpirationDate();
      
   } // end method setCustomerModel   

   // create Customer EJB using given CustomerModel
   public Integer ejbCreate( CustomerModel customerModel ) 
      throws CreateException
   {
      // retrieve unique value for primary key using 
      // SequenceFactory EJB
      try {
         initialContext = new InitialContext();
         
         // look up SequenceFactory EJB
         Object object = initialContext.lookup( 
            "java:comp/env/ejb/SequenceFactory" );
         
         SequenceFactoryHome sequenceFactoryHome =
            ( SequenceFactoryHome ) PortableRemoteObject.narrow(
               object, SequenceFactoryHome.class );
         
         // find sequence for Customer EJB
         SequenceFactory sequenceFactory = 
            sequenceFactoryHome.findByPrimaryKey( "Customer" );
         
         // retrieve next available customerID
         customerID = sequenceFactory.getNextID();
         
         // create Address EJBs for billing and shipping 
         // Addresses         
         object = initialContext.lookup( 
            "java:comp/env/ejb/Address" );

         AddressHome addressHome = ( AddressHome ) 
            PortableRemoteObject.narrow( object, 
               AddressHome.class );
         
         // get Customer's billing address
         AddressModel billingAddressModel = 
            customerModel.getBillingAddress();
         
         // create Address EJB for billing Address
         Address billingAddress = 
            addressHome.create( billingAddressModel );
         
         // set addressID in billing AddressModel
         billingAddressModel.setAddressID( ( Integer ) 
            billingAddress.getPrimaryKey() );
         
         // get Customer's shipping address
         AddressModel shippingAddressModel = 
            customerModel.getShippingAddress();
         
         // create Address EJB for shipping Address
         Address shippingAddress = 
            addressHome.create( shippingAddressModel );
         
         // set addressID in shipping AddressModel
         shippingAddressModel.setAddressID( ( Integer )
            shippingAddress.getPrimaryKey() ); 
         
         // use CustomerModel to set data for new Customer
         setCustomerModel( customerModel );               
         
      } // end try
      
      // handle exception when looking up, finding and using EJBs
      catch ( Exception exception ) { 
         throw new CreateException( exception.getMessage() );
      }         

      // EJB container will return a remote reference
      return null;
      
   } // end method ejbCreate
   
   // perform any necessary post-creation tasks
   public void ejbPostCreate( CustomerModel customer ) {}   

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

   // activate Customer EJB instance
   public void ejbActivate() 
   {
      customerID = ( Integer ) entityContext.getPrimaryKey();
   }
   
   // passivate Customer EJB instance
   public void ejbPassivate() 
   {
      customerID = null;
   }
   
   // remove Customer EJB instance
   public void ejbRemove() {}
   
   // store Customer EJB data in database
   public void ejbStore() {}   
   
   // load Customer EJB data from database
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
