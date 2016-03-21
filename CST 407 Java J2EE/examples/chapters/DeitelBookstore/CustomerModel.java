// CustomerModel.java
// CustomerModel represents a Deitel Bookstore Customer, 
// including billing, shipping and credit card information.
package com.deitel.advjhtp1.bookstore.model;

// Java core packages
import java.io.*;
import java.util.*;

// third-party packages
import org.w3c.dom.*;

public class CustomerModel implements Serializable, 
   XMLGenerator {
      
   // CustomerModel properties
   private Integer customerID;
   private String userID;
   private String password;
   private String passwordHint;
   private String firstName;
   private String lastName;
   
   private AddressModel billingAddress;
   private AddressModel shippingAddress;
   
   private String creditCardName;
   private String creditCardNumber;
   private String creditCardExpirationDate;
   
   // set customer ID
   public void setCustomerID( Integer id ) 
   { 
      customerID = id; 
   }
   
   // get customer ID
   public Integer getCustomerID() 
   { 
      return customerID; 
   }

   // set user ID
   public void setUserID( String id ) 
   { 
      userID = id; 
   }
   
   // get user ID
   public String getUserID() 
   { 
      return userID; 
   }

   // set password
   public void setPassword( String customerPassword ) 
   { 
      password = customerPassword; 
   }
   
   // get password
   public String getPassword() 
   { 
      return password; 
   }

   // set password hint
   public void setPasswordHint( String hint )
   { 
      passwordHint = hint; 
   }
      
   // get password hint
   public String getPasswordHint() 
   { 
      return passwordHint; 
   }

   // set first name
   public void setFirstName( String name ) 
   { 
      firstName = name; 
   }
   
   // get first name
   public String getFirstName() 
   { 
      return firstName; 
   }

   // set last name
   public void setLastName( String name ) 
   { 
      lastName = name; 
   }
   
   // get last name
   public String getLastName() 
   {  
      return lastName; 
   }

   // set billing address
   public void setBillingAddress( AddressModel address )
   {
      billingAddress = address;
   }
   
   // get billing address
   public AddressModel getBillingAddress()
   {
      return billingAddress;
   }
   
   // set shipping address
   public void setShippingAddress( AddressModel address )
   {
      shippingAddress = address;
   }
   
   // get shipping address
   public AddressModel getShippingAddress()
   {
      return shippingAddress;
   }
   
   // set name of credit card
   public void setCreditCardName( String name ) 
   { 
      creditCardName = name; 
   }
      
   // get name of credit card
   public String getCreditCardName() 
   { 
      return creditCardName; 
   }

   // set credit card number
   public void setCreditCardNumber( String number ) 
   { 
      creditCardNumber = number; 
   }
      
   // get credit card number
   public String getCreditCardNumber() 
   { 
      return creditCardNumber; 
   }

   // set expiration date of credit card
   public void setCreditCardExpirationDate( String date ) 
   { 
      creditCardExpirationDate = date; 
   }
     
   // get expiration date of credit card
   public String getCreditCardExpirationDate() 
   { 
         return creditCardExpirationDate; 
   }
      
   // build an XML representation of this Customer including
   // all public properties as nodes
   public Element getXML( Document document )
   {
      // create customer Element
      Element customer = 
         document.createElement( "customer" );
      
      // create customerID Element
      Element temp = document.createElement( "customerID" );      
      temp.appendChild( document.createTextNode( 
         String.valueOf( getCustomerID() ) ) );
      customer.appendChild( temp );
      
      // create userID Element
      temp = document.createElement( "userID" );
      temp.appendChild( 
         document.createTextNode( getUserID() ) );
      customer.appendChild( temp );
      
      // create firstName Element
      temp = document.createElement( "firstName" );
      temp.appendChild( document.createTextNode( 
         getFirstName() ) );
      customer.appendChild( temp );
      
      // create lastName Element
      temp = document.createElement( "lastName" );
      temp.appendChild( document.createTextNode( 
         getLastName() ) );
      customer.appendChild( temp );
      
      // create billingAddress Element
      temp = document.createElement( "billingAddress" );
      temp.appendChild( billingAddress.getXML( document ) );
      
      // create shippingAddressElement
      temp = document.createElement( "shippingAddress" );
      temp.appendChild( shippingAddress.getXML( document ) );
      
      // create creditCardName Element
      temp = document.createElement( "creditCardName" );
      temp.appendChild( document.createTextNode( 
         getCreditCardName() ) );
      customer.appendChild( temp );
      
      // create creditCardNumber Element
      temp = document.createElement( "creditCardNumber" );
      temp.appendChild( document.createTextNode( 
         getCreditCardNumber() ) );
      customer.appendChild( temp );
      
      // create creditCardExpirationDate Element
      temp = document.createElement( 
         "creditCardExpirationDate" );
      temp.appendChild( document.createTextNode( 
         getCreditCardExpirationDate() ) );
      customer.appendChild( temp );
      
      // create passwordHint Element
      temp = document.createElement( "passwordHint" );
      temp.appendChild( document.createTextNode( 
         getPasswordHint() ) );
      customer.appendChild( temp );
      
      return customer;
      
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
