// CheckOutServlet.java
// CheckOutServlet allows a Customer to checkout of the online
// store to purchase the Products in the ShoppingCart.
package com.deitel.advjhtp1.bookstore.servlets;

// Java core packages
import java.io.*;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;

// third-party packages
import org.w3c.dom.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.ejb.*;
import com.deitel.advjhtp1.bookstore.exceptions.*;

public class CheckoutServlet extends XMLServlet {
   
   // respond to HTTP post requests
   public void doPost( HttpServletRequest request,
                      HttpServletResponse response )
      throws ServletException, IOException
   {
      Document document = getDocumentBuilder().newDocument();
      HttpSession session = request.getSession();   
      
      // get Customer's userID from session
      String userID = ( String ) 
         session.getAttribute( "userID" );
      
      // get ShoppingCart and check out
      try {
         
         // get Customer's ShoppingCart from session
         ShoppingCart shoppingCart = ( ShoppingCart )
            session.getAttribute( "cart" );
         
         // ensure Customer has a ShoppingCart
         if ( shoppingCart == null )
            throw new ProductNotFoundException( "Your " +
               "ShoppingCart is empty." );
         
         // ensure userID is neither null nor empty
         if ( !( userID == null || userID.equals( "" ) ) ) {

            // invoke checkout method to place Order
            Order order = shoppingCart.checkout( userID );
            
            // get orderID for Customer's Order
            Integer orderID = ( Integer ) order.getPrimaryKey();
            
            // go to ViewOrder to show completed order
            response.sendRedirect( "ViewOrder?orderID=" + 
               orderID );
         }
         else {
            // userID was null, indicating Customer is 
            // not logged in
            String error = "You are not logged in.";
            
            // append error message to XML document
            document.appendChild( buildErrorMessage( document,
                  error ) );            
            
            writeXML( request, response, document );
         }
         
      } // end try
      
      // handle exception if Product not found in ShoppingCart
      catch ( ProductNotFoundException productException ) {
         productException.printStackTrace();
         
         // append error message to XML document
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
