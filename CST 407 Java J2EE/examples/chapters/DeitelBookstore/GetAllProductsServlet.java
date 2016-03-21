// GetAllProductsServlet.java
// GetAllProductsServlet retrieves a list of all Products 
// available in the store and presents the list to the client.
package com.deitel.advjhtp1.bookstore.servlets;

// Java core packages  
import java.io.*;
import java.util.*;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;
import javax.rmi.*;
import javax.naming.*;
import javax.ejb.*;

// third-party packages
import org.w3c.dom.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.ejb.*;

public class GetAllProductsServlet extends XMLServlet {
   
   // respond to HTTP get requests
   public void doGet( HttpServletRequest request,
                      HttpServletResponse response )
      throws ServletException, IOException
   {
      Document document = getDocumentBuilder().newDocument();
 
      // generate Product catalog
      try {         
         InitialContext context = new InitialContext();

         // look up Product EJB
         Object object = 
            context.lookup( "java:comp/env/ejb/Product" );
         
         // get ProductHome interface to find all Products
         ProductHome productHome = ( ProductHome ) 
            PortableRemoteObject.narrow( object, 
               ProductHome.class );
         
         // get Iterator for Product list
         Iterator products = 
            productHome.findAllProducts().iterator();
         
         // create root of XML document
         Element rootElement = 
            document.createElement( "catalog" );
         
         // append catalog Element to XML document
         document.appendChild( rootElement );

         // add each Product to the XML document
         while ( products.hasNext() ) {
            Product product = ( Product )
               PortableRemoteObject.narrow( products.next(),
                  Product.class );
            
            // get ProductModel for current Product
            ProductModel productModel = 
               product.getProductModel();
            
            // add an XML element to document for Product
            rootElement.appendChild( 
               productModel.getXML( document ) ); 
         }
         
      } // end try
      
      // handle exception when looking up Product EJB
      catch ( NamingException namingException ) { 
         namingException.printStackTrace(); 
         
         String error = "The Product EJB was not found in " +
            "the JNDI directory.";
         
         // append error message to XML document
         document.appendChild( buildErrorMessage(
               document, error ) );
      }
      
      // handle exception when a Product cannot be found
      catch ( FinderException finderException ) { 
         finderException.printStackTrace(); 
         
         String error = "No Products found in the store.";
         
         // append error message to XML document
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
