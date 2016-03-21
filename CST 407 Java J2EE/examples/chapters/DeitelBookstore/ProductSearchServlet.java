// ProductSearchServlet.java
// ProductSearchServlet allows a Customer to search through 
// the store for a particular Product.
package com.deitel.advjhtp1.bookstore.servlets;

// Java core packages
import java.io.*;
import java.util.*;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;
import javax.naming.*;
import javax.ejb.*;
import javax.rmi.PortableRemoteObject;

// third-party packages
import org.w3c.dom.*;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;
import com.deitel.advjhtp1.bookstore.ejb.*;

public class ProductSearchServlet extends XMLServlet {
   
   // respond to HTTP get requests
   public void doGet( HttpServletRequest request, 
                      HttpServletResponse response )
      throws ServletException, IOException
   {      
      Document document = getDocumentBuilder().newDocument();
      
      // get the searchString from the request object
      String searchString = "%" + 
         request.getParameter( "searchString" ) + "%";
      
      // find Product using Product EJB
      try {
         InitialContext context = new InitialContext();
         
         // look up Product EJB
         Object object = 
            context.lookup( "java:comp/env/ejb/Product" );
         
         ProductHome productHome = ( ProductHome ) 
            PortableRemoteObject.narrow( 
               object, ProductHome.class );
         
         // find Products that match searchString
         Iterator products = productHome.findByTitle( 
            searchString ).iterator();
         
         // create catalog document element
         Node rootNode = document.appendChild( 
            document.createElement( "catalog" ) );
         
         // generate list of matching products
         while ( products.hasNext() ) {
            Product product = ( Product )
               PortableRemoteObject.narrow( products.next(),
                  Product.class );
            
            ProductModel productModel = product.getProductModel();
            
            // append XML element to the document for the 
            // current Product
            rootNode.appendChild( 
               productModel.getXML( document ) );
         }
         
      } // end try
      
      // handle exception when looking up Product EJB
      catch ( NamingException namingException ) { 
         namingException.printStackTrace(); 
         
         String error = "The Product EJB was not found in " +
            "the JNDI directory.";
         
         document.appendChild( buildErrorMessage(
               document, error ) );
      }
      
      // handle exception when Product is not found
      catch ( FinderException finderException ) { 
         finderException.printStackTrace(); 
         
         String error = "No Products match your search.";
         
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
