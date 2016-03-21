// AddToCartServlet.java
// AddToCartServlet adds a Product to the Customer's 
// ShoppingCart.
package com.deitel.advjhtp1.bookstore.servlets;

// Java core packages
import java.io.*;

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

public class AddToCartServlet extends XMLServlet {
   
   // respond to HTTP post requests
   public void doPost( HttpServletRequest request,
                      HttpServletResponse response )
      throws ServletException, IOException
   {
      Document document = getDocumentBuilder().newDocument();
      
      // get HttpSession Object for this user
      HttpSession session = request.getSession();

      // get Customer's ShoppingCart
      ShoppingCart shoppingCart = 
         ( ShoppingCart ) session.getAttribute( "cart" );
      
      // get ISBN parameter from request Object
      String isbn = request.getParameter( "ISBN" );
      
      // get ShoppingCart and add Product to be purchased
      try {         
         InitialContext context = new InitialContext();
         
         // create ShoppingCart if Customer does not have one
         if ( shoppingCart == null ) {
            Object object = context.lookup( 
               "java:comp/env/ejb/ShoppingCart" );
            
            // cast Object reference to ShoppingCartHome
            ShoppingCartHome shoppingCartHome =  
               ( ShoppingCartHome ) 
                  PortableRemoteObject.narrow(
                     object, ShoppingCartHome.class );
            
            // create ShoppingCart using ShoppingCartHome
            shoppingCart = shoppingCartHome.create();
            
            // store ShoppingCart in session
            session.setAttribute( "cart", shoppingCart );
         }

         // add Product to Customer's ShoppingCart
         shoppingCart.addProduct( isbn );
         
         // redirect Customer to ViewCartServlet to view
         // contents of ShoppingCart
         response.sendRedirect( "ViewCart" );
         
      } // end try
      
      // handle exception when looking up ShoppingCart EJB
      catch ( NamingException namingException ) { 
         namingException.printStackTrace(); 
 
         String error = "The ShoppingCart EJB was not " +
            "found in the JNDI directory.";
         
         // append error message to XML document
         document.appendChild( buildErrorMessage( 
            document, error ) );
         
         writeXML( request, response, document );
      }
      
      // handle exception when creating ShoppingCart EJB
      catch ( CreateException createException ) { 
         createException.printStackTrace(); 

         String error = "ShoppingCart could not be created";
         
         // append error message to XML document
         document.appendChild( buildErrorMessage( 
               document, error ) );
         
         writeXML( request, response, document );
      }
      
      // handle exception when Product is not found
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
