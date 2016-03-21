// ViewOrderServlet.java
// ViewOrderServlet presents the contents of a Customer's 
// Order.
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

public class ViewOrderServlet extends XMLServlet {
   
   // respond to HTTP get requests
   public void doGet( HttpServletRequest request,
                      HttpServletResponse response )
      throws ServletException, IOException
   {
      Document document = getDocumentBuilder().newDocument();
      Integer orderID = null;
      
      // look up Order EJB and get details of Order with 
      // given orderID
      try {
         InitialContext context = new InitialContext();
         
         // look up Order EJB
         Object object = 
            context.lookup( "java:comp/env/ejb/Order" );
         
         OrderHome orderHome = ( OrderHome )
            PortableRemoteObject.narrow(
               object, OrderHome.class );
         
         // get orderID from request object
         orderID = new Integer( 
            request.getParameter( "orderID" ) );
         
         // find Order with given orderID
         Order order = orderHome.findByPrimaryKey( orderID );
         
         // get Order details as an OrderModel         
         OrderModel orderModel = order.getOrderModel();

         // add Order details to XML document
         document.appendChild( 
            orderModel.getXML( document ) );
         
      } // end try
      
      // handle exception when looking up Order EJB
      catch ( NamingException namingException ) { 
         namingException.printStackTrace();
         
         String error = "The Order EJB was not found in " +
            "the JNDI directory.";
         
         document.appendChild( buildErrorMessage(
               document, error ) );
      }
      
      // handle exception when Order is not found
      catch ( FinderException finderException ) { 
         finderException.printStackTrace(); 
         
         String error = "An Order with orderID " + orderID +
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
