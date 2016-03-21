// RegisterServlet.java
// RegisterServlet processes the Customer registration form 
// to register a new Customer.
package com.deitel.advjhtp1.bookstore.servlets;

// Java core packages
import java.io.*;
import java.util.*;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;
import javax.ejb.*;
import javax.naming.*;
import javax.rmi.*;

// third-party packages
import org.w3c.dom.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.ejb.*;

public class RegisterServlet extends XMLServlet {
      
   // respond to HTTP post requests
   public void doPost( HttpServletRequest request,
                       HttpServletResponse response )
      throws ServletException, IOException
   {
      Document document = getDocumentBuilder().newDocument();

      // create CustomerModel to store registration data
      CustomerModel customerModel = new CustomerModel();      

      // set properties of CustomerModel using values
      // passed through request object      
      customerModel.setUserID( request.getParameter( 
         "userID" ) );
      
      customerModel.setPassword( request.getParameter( 
         "password" ) );
      
      customerModel.setPasswordHint( request.getParameter( 
         "passwordHint" ) );
      
      customerModel.setFirstName( request.getParameter( 
         "firstName" ) );
      
      customerModel.setLastName( request.getParameter( 
         "lastName" ) );
      
      // set credit card information
      customerModel.setCreditCardName( request.getParameter( 
         "creditCardName" ) );
      
      customerModel.setCreditCardNumber( request.getParameter( 
         "creditCardNumber" ) );
      
      customerModel.setCreditCardExpirationDate( 
         request.getParameter( "creditCardExpirationDate" ) );
      
      // create AddressModel for billing address
      AddressModel billingAddress = new AddressModel();
      
      billingAddress.setFirstName( request.getParameter( 
         "billingAddressFirstName" ) );
      
      billingAddress.setLastName( request.getParameter( 
         "billingAddressLastName" ) );
      
      billingAddress.setStreetAddressLine1( 
         request.getParameter( "billingAddressStreet1" ) );
      
      billingAddress.setStreetAddressLine2( 
         request.getParameter( "billingAddressStreet2" ) );
      
      billingAddress.setCity( request.getParameter( 
         "billingAddressCity" ) );
      
      billingAddress.setState( request.getParameter( 
         "billingAddressState" ) );
      
      billingAddress.setZipCode( request.getParameter( 
         "billingAddressZipCode" ) );
      
      billingAddress.setCountry( request.getParameter( 
         "billingAddressCountry" ) );
      
      billingAddress.setPhoneNumber( request.getParameter( 
         "billingAddressPhoneNumber" ) );
      
      customerModel.setBillingAddress( billingAddress );
      
      // create AddressModel for shipping address
      AddressModel shippingAddress = new AddressModel();
      
      shippingAddress.setFirstName( request.getParameter( 
         "shippingAddressFirstName" ) );
      
      shippingAddress.setLastName( request.getParameter( 
         "shippingAddressLastName" ) );
      
      shippingAddress.setStreetAddressLine1( 
         request.getParameter( "shippingAddressStreet1" ) );
      
      shippingAddress.setStreetAddressLine2( 
         request.getParameter( "shippingAddressStreet2" ) );
      
      shippingAddress.setCity( request.getParameter( 
         "shippingAddressCity" ) );
      
      shippingAddress.setState( request.getParameter( 
         "shippingAddressState" ) );
      
      shippingAddress.setZipCode( request.getParameter( 
         "shippingAddressZipCode" ) );
      
      shippingAddress.setCountry( request.getParameter( 
         "shippingAddressCountry" ) );
      
      shippingAddress.setPhoneNumber( request.getParameter( 
         "shippingAddressPhoneNumber" ) );
      
      customerModel.setShippingAddress( shippingAddress );      

      // look up Customer EJB and create new Customer
      try {
         InitialContext context = new InitialContext();
         
         // look up Customer EJB
         Object object = 
            context.lookup( "java:comp/env/ejb/Customer" );
         
         CustomerHome customerHome = ( CustomerHome ) 
            PortableRemoteObject.narrow( object, 
               CustomerHome.class );
         
         // create new Customer using the CustomerModel with
         // Customer's registration information
         Customer customer = 
            customerHome.create( customerModel );
         
         customerModel = customer.getCustomerModel();         
         
         // get RequestDispatcher for Login servlet 
         RequestDispatcher dispatcher = 
            getServletContext().getRequestDispatcher( "/Login" );
         
         // set userID and password for Login servlet
         request.setAttribute( "userID", 
            customerModel.getUserID() );
         request.setAttribute( "password", 
            customerModel.getPassword() );

         // forward user to LoginServlet
         dispatcher.forward( request, response );
         
      } // end try
      
      // handle exception when looking up Customer EJB
      catch ( NamingException namingException ) { 
         namingException.printStackTrace();
         
 
         String error = "The Customer EJB was not " +
            "found in the JNDI directory.";
         
         document.appendChild( buildErrorMessage(
               document, error ) );
         
         writeXML( request, response, document );
      }
      
      // handle exception when creating Customer
      catch ( CreateException createException ) { 
         createException.printStackTrace(); 

         String error = "The Customer could not be created";
         
         document.appendChild( buildErrorMessage( 
               document, error ) );
         
         writeXML( request, response, document ); 
      }
      
   } // end method doPost
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
