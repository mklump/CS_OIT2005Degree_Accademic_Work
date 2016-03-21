// ViewCartServlet.java
// ViewCartServlet presents the contents of the Customer's 
// ShoppingCart.
package com.deitel.advjhtp1.bookstore.servlets;

// Java core packages 
import java.io.*;
import java.util.*;
import java.text.*;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;
import javax.rmi.*;

// third-party packages
import org.w3c.dom.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.ejb.*;

public class ViewCartServlet extends XMLServlet {
   
   // respond to HTTP get requests
   public void doGet( HttpServletRequest request,
                      HttpServletResponse response )
      throws ServletException, IOException
   {
      Document document = getDocumentBuilder().newDocument();
      HttpSession session = request.getSession();

      // get Customer's ShoppingCart from session
      ShoppingCart shoppingCart = 
         ( ShoppingCart ) session.getAttribute( "cart" );      

      // build XML document with contents of ShoppingCart 
      if ( shoppingCart != null ) {

         // create cart element in XML document
         Element root = ( Element ) document.appendChild( 
            document.createElement( "cart" ) );

         // get total cost of Products in ShoppingCart
         double total = shoppingCart.getTotal();

         // create NumberFormat for local currency
         NumberFormat priceFormatter =
            NumberFormat.getCurrencyInstance();

         // format total price for ShoppingCart and add it 
         // as an attribute of element cart
         root.setAttribute( "total", 
            priceFormatter.format( total ) );
         
         // get contents of ShoppingCart
         Iterator orderProducts = 
            shoppingCart.getContents().iterator();

         // add an element for each Product in ShoppingCart
         // to XML document
         while ( orderProducts.hasNext() ) {
            OrderProductModel orderProductModel = 
               ( OrderProductModel ) orderProducts.next();
            
            root.appendChild( 
               orderProductModel.getXML( document ) );
         }
         
      } // end if
      
      else {         
         String error = "Your ShoppingCart is empty.";
         
         // append error message to XML document
         document.appendChild( buildErrorMessage( 
               document, error ) );         
      }
      
      // write content to client
      writeXML( request, response, document ); 
      
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
