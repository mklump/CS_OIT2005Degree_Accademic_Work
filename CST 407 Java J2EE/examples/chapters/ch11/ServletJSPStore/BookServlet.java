// BookServlet.java
// Servlet to return one book's information to the client.
// The servlet produces XML which is transformed with XSL to
// produce the client XHTML page.
package com.deitel.advjhtp1.store;

// Java core packages
import java.io.*;
import java.util.*;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;
import javax.xml.parsers.*;
import javax.xml.transform.*;
import javax.xml.transform.dom.*;
import javax.xml.transform.stream.*;

// third-party packages
import org.w3c.dom.*;
import org.xml.sax.*;

public class BookServlet extends HttpServlet {
   protected void doGet( HttpServletRequest request,
      HttpServletResponse response )
      throws ServletException, IOException
   {
      HttpSession session = request.getSession( false );

      // RequestDispatcher to forward client to bookstore home
      // page if no session exists or no books are selected
      RequestDispatcher dispatcher = 
         request.getRequestDispatcher( "/index.html" );
      
      // if session does not exist, forward to index.html
      if ( session == null )
         dispatcher.forward( request, response );

      // get books from session object
      List titles = 
         ( List ) session.getAttribute( "titles" );

      // locate BookBean object for selected book
      Iterator iterator = titles.iterator();
      BookBean book = null;
      
      String isbn = request.getParameter( "isbn" );

      while ( iterator.hasNext() ) {
         book = ( BookBean ) iterator.next();

         if ( isbn.equals( book.getISBN() ) ) {
            
            // save the book in a session attribute
            session.setAttribute( "bookToAdd", book );
            break;  // isbn matches current book
         }
      }
      
      // if book is not in list, forward to index.html
      if ( book == null )
         dispatcher.forward( request, response );
      
      // get XML document and transform for browser client
      try {
         // get a DocumentBuilderFactory for creating
         // a DocumentBuilder (i.e., an XML parser)
         DocumentBuilderFactory factory = 
            DocumentBuilderFactory.newInstance();

         // get a DocumentBuilder for building the DOM tree
         DocumentBuilder builder =
            factory.newDocumentBuilder();

         // create a new Document (empty DOM tree)
         Document messageDocument = builder.newDocument();

         // get XML from BookBean and append to Document
         Element bookElement = book.getXML( messageDocument );
         messageDocument.appendChild( bookElement );
         
         // get PrintWriter for writing data to client
         response.setContentType( "text/html" );
         PrintWriter out = response.getWriter();

         // open InputStream for XSL document 
         InputStream xslStream = 
            getServletContext().getResourceAsStream( 
               "/book.xsl" );

         // transform XML document using XSLT
         transform( messageDocument, xslStream, out );

         // flush and close PrintWriter
         out.flush();
         out.close();
      }

      // catch XML parser exceptions
      catch ( ParserConfigurationException pcException ) { 
         pcException.printStackTrace(); 
      }          
   }   
   
   // transform XML document using provided XSLT InputStream 
   // and write resulting document to provided PrintWriter
   private void transform( Document document, 
      InputStream xslStream, PrintWriter output )
   {
      try {
         // create DOMSource for source XML document
         Source xmlSource = new DOMSource( document );

         // create StreamSource for XSLT document
         Source xslSource =
            new StreamSource( xslStream );
         
         // create StreamResult for transformation result
         Result result = new StreamResult( output );
         
         // create TransformerFactory to obtain a Transformer
         TransformerFactory transformerFactory =
            TransformerFactory.newInstance();
         
         // create Transformer for performing XSL transformation
         Transformer transformer = 
            transformerFactory.newTransformer( xslSource );
         
         // perform transformation and deliver content to client
         transformer.transform( xmlSource, result );
      }

      // handle exception when transforming XML document
      catch ( TransformerException transformerException ) { 
         transformerException.printStackTrace( System.err ); 
      }
   }
}

/***************************************************************
 * (C) Copyright 2001 by Deitel & Associates, Inc. and         *
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
