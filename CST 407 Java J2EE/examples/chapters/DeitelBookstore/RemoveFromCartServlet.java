// RemoveFromCartServlet.java
// RemoveFromCartServlet removes a Product from the Customer's 
// ShoppingCart.
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

public class RemoveFromCartServlet extends XMLServlet {
   
   // respond to HTTP post requests
   public void doPost( HttpServletRequest request,
                      HttpServletResponse response )
      throws ServletException, IOException
   {
      Document document = getDocumentBuilder().newDocument();
      
      // remove Product from ShoppingCart
      try {

         // get ISBN of Product to be removed
         String isbn = request.getParameter( "ISBN" );  
         
         // get Customer's ShoppingCart from session
         HttpSession session = request.getSession();
         
         ShoppingCart shoppingCart = 
            ( ShoppingCart ) session.getAttribute( "cart" );
         
         // if ShoppingCart is not null, remove Product
         if ( shoppingCart != null )
            shoppingCart.removeProduct( isbn );
         
         // redirect Customer to ViewCartServlet to view
         // the contents of ShoppingCart
         response.sendRedirect( "ViewCart" );      
         
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
