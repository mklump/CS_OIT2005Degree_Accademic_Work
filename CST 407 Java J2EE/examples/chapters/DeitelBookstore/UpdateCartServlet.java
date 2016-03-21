// UpdateCartServlet.java
// UpdateCartServlet updates the quantity of a Product in the 
// Customer's ShoppingCart.
package com.deitel.advjhtp1.bookstore.servlets;

// Java core packages
import java.io.*;
import java.util.*;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;

// third-party packages
import org.w3c.dom.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.ejb.*;
import com.deitel.advjhtp1.bookstore.exceptions.*;

public class UpdateCartServlet extends XMLServlet {
   
   // respond to HTTP post requests
   public void doPost( HttpServletRequest request,
                       HttpServletResponse response )
      throws ServletException, IOException
   {
      Document document = getDocumentBuilder().newDocument();
      
      // update quantity of given Product in ShoppingCart
      try {

         // get Customer's ShoppingCart from session 
         HttpSession session = request.getSession( false );
         
         ShoppingCart shoppingCart = ( ShoppingCart )
            session.getAttribute( "cart" );
         
         // get Enumeration of parameter names
         Enumeration parameters = request.getParameterNames();
         
         // update quantity for each ISBN parameter
         while ( parameters.hasMoreElements() ) {

            // get ISBN of Product to be updated
            String ISBN = ( String ) parameters.nextElement();
            
            // get new quantity for Product
            int newQuantity = Integer.parseInt( 
               request.getParameter( ISBN ) );

            // set quantity in ShoppingCart for Product
            // with given ISBN
            shoppingCart.setProductQuantity( ISBN, 
               newQuantity );
         }
         
         // redirect Customer to ViewCartServlet to view
         // contents of ShoppingCart
         response.sendRedirect( "ViewCart" );
         
      } // end try
      
      // handle exception if Product not found in ShoppingCart
      catch ( ProductNotFoundException productException ) {
         productException.printStackTrace();
         
         document.appendChild( buildErrorMessage( 
               document, productException.getMessage() ) );
         
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
