// LoginServlet.java
// LoginServlet that logs an existing Customer into the site.
package com.deitel.advjhtp1.bookstore.servlets;

// Java core packages
import java.io.*;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;
import javax.naming.*;
import javax.ejb.*;
import javax.rmi.*;

// third-party packages
import org.w3c.dom.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.ejb.*;

public class LoginServlet extends XMLServlet {

   // respond to HTTP post requests
   public void doPost( HttpServletRequest request,
                       HttpServletResponse response )
      throws ServletException, IOException
   {
      Document document = getDocumentBuilder().newDocument();
      
      String userID = request.getParameter( "userID" );
      String password = request.getParameter( "password" );
      
      // use Customer EJB to authenticate user
      try {
         InitialContext context = new InitialContext();
         
         // look up Customer EJB
         Object object = 
            context.lookup( "java:comp/env/ejb/Customer" );
         
         CustomerHome customerHome = ( CustomerHome )
            PortableRemoteObject.narrow( object,
               CustomerHome.class );

         // find Customer with given userID and password
         Customer customer = 
            customerHome.findByLogin( userID, password );
         
         // get CustomerModel for Customer
         CustomerModel customerModel = 
            customer.getCustomerModel();
         
         // set userID in Customer's session
         request.getSession().setAttribute( "userID", 
            customerModel.getUserID() );
         
         // create login XML element
         Element login = document.createElement( "login" );
         document.appendChild( login );
         
         // add Customer's first name to XML document
         Element firstName = 
            document.createElement( "firstName" );
         
         firstName.appendChild( document.createTextNode(
            customerModel.getFirstName() ) );
         
         login.appendChild( firstName );
         
      } // end try
      
      // handle exception when looking up Customer EJB
      catch ( NamingException namingException ) { 
         namingException.printStackTrace(); 
         
         String error = "The Customer EJB was not found in " +
            "the JNDI directory.";
         
         document.appendChild( buildErrorMessage(
               document, error ) );
      }
      
      // handle exception when Customer is not found
      catch ( FinderException finderException ) { 
         finderException.printStackTrace(); 
         
         String error = "The userID and password entered " +
            "were not found.";
         
         document.appendChild( buildErrorMessage( 
               document, error ) );
      }
      
      // ensure content is written to client
      finally { 
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
