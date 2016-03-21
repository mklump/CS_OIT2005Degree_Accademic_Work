// XMLServlet.java
// XMLServlet is a base class for servlets that generate 
// XML documents and perform XSL transformations.
package com.deitel.advjhtp1.bookstore.servlets;

// Java core packages
import java.io.*;
import java.util.*;
import java.net.URL;

// Java extension packages
import javax.servlet.*;
import javax.servlet.http.*;
import javax.xml.parsers.*;
import javax.xml.transform.*;
import javax.xml.transform.dom.*;
import javax.xml.transform.stream.*;

// third-party packages
import org.w3c.dom.*;
import org.xml.sax.SAXException;

// Deitel packages
import com.deitel.advjhtp1.bookstore.model.*;

public class XMLServlet extends HttpServlet {

   // factory for creating DocumentBuilders
   private DocumentBuilderFactory builderFactory;
   
   // factory for creating Transformers
   private TransformerFactory transformerFactory;
   
   // XSL file that presents servlet's content
   private String XSLFileName;
   
   // ClientModel List for determining client type
   private List clientList;
   
   // initialize servlet
   public void init( ServletConfig config ) 
      throws ServletException
   {     
      // call superclass's init method for initialization
      super.init( config );

      // use InitParameter to set XSL file for transforming 
      // generated content
      setXSLFileName( config.getInitParameter( "XSL_FILE" ) );
      
      // create new DocumentBuilderFactory
      builderFactory = DocumentBuilderFactory.newInstance(); 
      
      // create new TransformerFactory
      transformerFactory = TransformerFactory.newInstance();
      
      // set URIResolver for resolving relative paths in XSLT
      transformerFactory.setURIResolver( 
      
         new URIResolver() {

            // resolve href as relative to ServletContext
            public Source resolve( String href, String base )
            {
               try {                  
                  ServletContext context = getServletContext();
                  URL url = context.getResource( href );

                  // create StreamSource to read document from URL
                  return new StreamSource( url.openStream() ); 
               } 
               
               // handle exceptions obtaining referenced document
               catch ( Exception exception ) { 
                  exception.printStackTrace(); 

                  return null;
               }
            }
         }
      ); // end call to setURIResolver     
      
      // create ClientModel ArrayList
      clientList = buildClientList();
   }
   
   // get DocumentBuilder instance for building XML documents
   public DocumentBuilder getDocumentBuilder( boolean validating ) 
   { 
      // create new DocumentBuilder
      try {
         
         // set validation mode
         builderFactory.setValidating( validating );
         
         // return new DocumentBuilder to the caller
         return builderFactory.newDocumentBuilder();      
      }
      
      // handle exception when creating DocumentBuilder
      catch ( ParserConfigurationException parserException ) { 
         parserException.printStackTrace(); 
         
         return null;
      }
      
   }  // end method getDocumentBuilder
   
   // get non-validating parser
   public DocumentBuilder getDocumentBuilder()
   {
      return getDocumentBuilder( false );
   }
   
   // set XSL file name for transforming servlet's content
   public void setXSLFileName( String fileName )
   {
      XSLFileName = fileName;
   }
   
   // get XSL file name for transforming servlet's content
   public String getXSLFileName() 
   { 
      return XSLFileName;
   }   

   // write XML document to client using provided response 
   // Object after transforming XML document with 
   // client-specific XSLT document
   public void writeXML( HttpServletRequest request,
      HttpServletResponse response, Document document ) 
      throws IOException 
   {
      // get current session, create if not extant
      HttpSession session = request.getSession( true );
      
      // get ClientModel from session Object
      ClientModel client = ( ClientModel ) 
         session.getAttribute( "clientModel" );
      
      // if client is null, get new ClientModel for this
      // User-Agent and store in session
      if ( client == null ) {
         String userAgent = request.getHeader( "User-Agent" );               
         client = getClientModel( userAgent );
         session.setAttribute( "clientModel", client );         
      }
    
      // set appropriate Content-Type for client
      response.setContentType( client.getContentType() );
      
      // get PrintWriter for writing data to client
      PrintWriter output = response.getWriter();
            
      // build file name for XSLT document
      String xslFile = client.getXSLPath() + getXSLFileName();
      
      // open InputStream for XSL document 
      InputStream xslStream = 
         getServletContext().getResourceAsStream( xslFile );

      // transform XML document using XSLT
      transform( document, xslStream, output );

      // flush and close PrintWriter
      output.close();
      
   } // end method writeXML
   
   // transform XML document using provided XSLT InputStream 
   // and write resulting document to provided PrintWriter
   public void transform( Document document, 
      InputStream xslStream, PrintWriter output )
   {
      // create Transformer and apply XSL transformation
      try {
         
         // create DOMSource for source XML document
         Source xmlSource = new DOMSource( document );

         // create StreamSource for XSLT document
         Source xslSource = 
            new StreamSource( xslStream );
         
         // create StreamResult for transformation result
         Result result = new StreamResult( output );
         
         // create Transformer for XSL transformation
         Transformer transformer = 
            transformerFactory.newTransformer( xslSource );
         
         // transform and deliver content to client
         transformer.transform( xmlSource, result );
         
         transformer.setOutputProperty( OutputKeys.INDENT, "yes" );
         transformer.transform( xmlSource, new StreamResult( System.err ) );
         
      } // end try
      
      // handle exception when transforming XML document
      catch ( TransformerException transformerException ) { 
         transformerException.printStackTrace(); 
      }
      
   } // end method transform
   
   // build error element containing error message
   public Node buildErrorMessage( Document document,
      String message)
   {
      // create error element
      Element error = document.createElement( "error" );
      
      // create message element
      Element errorMessage = 
         document.createElement( "message" );
      
      // create message text and append to message element
      errorMessage.appendChild( 
         document.createTextNode( message ) );
      
      // append message element to error element
      error.appendChild( errorMessage );
      
      return error;
   }   
   
   // build list of ClientModel Objects for delivering
   // appropriate content to each client
   private List buildClientList()
   {
      // get validating DocumentBuilder for client XML document
      DocumentBuilder builder = getDocumentBuilder( true );
      
      // create client ArrayList
      List clientList = new ArrayList();
      
      // get name of XML document containing client 
      // information from ServletContext
      String clientXML = getServletContext().getInitParameter( 
         "CLIENT_LIST" );
      
      // read clients from XML document and build ClientModels
      try { 
         
         // open InputStream to XML document
         InputStream clientXMLStream = 
            getServletContext().getResourceAsStream( 
               clientXML );
         
         // parse XML document
         Document clientsDocument = 
            builder.parse( clientXMLStream );

         // get NodeList of client elements
         NodeList clientElements = 
            clientsDocument.getElementsByTagName( "client" );
  
         // get length of client NodeList
         int listLength = clientElements.getLength();        
         
         // process NodeList of client Elements
         for ( int i = 0; i < listLength; i++ ) {
            
            // get next client Element
            Element client = 
               ( Element ) clientElements.item( i );

            // get agent Element from client Element
            Element agentElement = ( Element ) 
               client.getElementsByTagName( 
                  "userAgent" ).item( 0 );
            
            // get agent Element's child text node
            Text agentText = 
               ( Text ) agentElement.getFirstChild();
            
            // get value of agent Text node
            String agent = agentText.getNodeValue();
            
            // get contentType Element
            Element typeElement = ( Element ) 
               client.getElementsByTagName( 
                  "contentType" ).item( 0 );
            
            // get contentType Element's child text node
            Text typeText = 
               ( Text ) typeElement.getFirstChild();  
            
            // get value of contentType text node
            String type = typeText.getNodeValue();            
            
            // get XSLPath element
            Element pathElement = ( Element ) 
               client.getElementsByTagName( 
                  "XSLPath" ).item( 0 );
            
            // get Text node child of XSLPath
            Text pathText = 
               ( Text ) pathElement.getFirstChild();    
            
            // get value of XSLPath text node
            String path = pathText.getNodeValue();  

            // add new ClientModel with userAgent, contentType
            // and XSLPath for this client Element
            clientList.add( 
               new ClientModel( agent, type, path ) );
         } 
         
      } // end try
      
      // handle SAXException when parsing XML document
      catch ( SAXException saxException ) {
         saxException.printStackTrace();
      }
      
      // catch IO exception when reading XML document
      catch ( IOException ioException ) {
         ioException.printStackTrace();
      }
      
      // return newly creating list of ClientModels
      return clientList;
      
   } // end method buildClientList
   
   // get ClientModel for given User-Agent HTTP header
   private ClientModel getClientModel( String header )
   {
      // get Iterator for clientList
      Iterator iterator = clientList.iterator();
      
      // find ClientModel whose userAgent property is a 
      // substring of given User-Agent HTTP header
      while ( iterator.hasNext() ) {
         ClientModel client = ( ClientModel ) iterator.next();
         
         // if this ClientModel's userAgent property is a
         // substring of the User-Agent HTTP header, return         
         // a reference to the ClientModel
         if ( header.indexOf( client.getUserAgent() ) > -1 )
               return client;
      }
      
      // return default ClientModel if no others match
      return new ClientModel( 
         "DEFAULT CLIENT", "text/html", "/XHTML/" );
      
   } // end method getClientModel
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
