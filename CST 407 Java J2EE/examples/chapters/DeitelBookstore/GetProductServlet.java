// GetProductServlet.java
// GetProductServlet retrieves the details of a Product and 
// presents them to the customer.
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

public class GetProductServlet extends XMLServlet {
   
   public void doGet( HttpServletRequest request,
                      HttpServletResponse response )
      throws ServletException, IOException
   {
      Document document = getDocumentBuilder().newDocument();

      // get ISBN from request object
      String isbn = request.getParameter( "ISBN" );
      
      // generate XML document with Product details
      try {
         InitialContext context = new InitialContext();
         
         // look up Product EJB
         Object object = 
            context.lookup( "java:comp/env/ejb/Product" );

         // get ProductHome interface to find Product
         ProductHome productHome = ( ProductHome ) 
            PortableRemoteObject.narrow( 
               object, ProductHome.class );

         // find Product with given ISBN
         Product product = 
            productHome.findByPrimaryKey( isbn );

         // create XML document root Element
         Node rootNode = 
            document.createElement( "bookstore" );
         
         // append root Element to XML document
         document.appendChild( rootNode );

         // get Product details as a ProductModel
         ProductModel productModel = 
            product.getProductModel();

         // build an XML document with Product details
         rootNode.appendChild( 
            productModel.getXML( document ) );
         
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
         
         String error = "The Product with ISBN " + isbn +
            " was not found in our store.";
         
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
