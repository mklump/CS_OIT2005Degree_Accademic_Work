// ViewOrderHistoryServlet.java
// ViewOrderHistoryServlet presents a list of previous Orders
// to the Customer.
package com.deitel.advjhtp1.bookstore.servlets;

// Java core packages
import java.io.*;
import java.util.*;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;
import javax.naming.*;
import javax.rmi.*;
import javax.ejb.*;

// third-party packages
import org.w3c.dom.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.ejb.*;
import com.deitel.advjhtp1.bookstore.exceptions.*;

public class ViewOrderHistoryServlet extends XMLServlet {
   
   // respond to HTTP get requests
   public void doGet( HttpServletRequest request,
                      HttpServletResponse response )
      throws ServletException, IOException
   {
      Document document = getDocumentBuilder().newDocument();
      
      HttpSession session = request.getSession();
      String userID = ( String ) 
         session.getAttribute( "userID" );

      // build order history using Customer EJB
      try {
         InitialContext context = new InitialContext();
         
         // look up Customer EJB
         Object object = 
            context.lookup( "java:comp/env/ejb/Customer" );
         
         CustomerHome customerHome = ( CustomerHome )
            PortableRemoteObject.narrow(
               object, CustomerHome.class );
         
         // find Customer with given userID
         Customer customer = 
            customerHome.findByUserID( userID );
         
         // create orderHistory element
         Element rootNode = ( Element ) document.appendChild( 
            document.createElement( "orderHistory" ) );
         
         // get Customer's Order history
         Iterator orderHistory = 
            customer.getOrderHistory().iterator();

         // loop through Order history and add XML elements
         // to XML document for each Order
         while ( orderHistory.hasNext() ) {
            OrderModel orderModel = 
               ( OrderModel ) orderHistory.next();
            
            rootNode.appendChild( 
               orderModel.getXML( document ) );
         }
      } // end try
      
      // handle exception when Customer has no Order history
      catch ( NoOrderHistoryException historyException ) { 
         historyException.printStackTrace(); 
         
         document.appendChild( buildErrorMessage( document, 
            historyException.getMessage() ) );
      }
      
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
         
         String error = "The Customer with userID " + userID +
            " was not found.";
         
         document.appendChild( buildErrorMessage( 
               document, error ) );         
      }  
      
      // ensure content is written to client
      finally { 
         writeXML( request, response, document ); 
      }
      
   } // end method doGet
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
