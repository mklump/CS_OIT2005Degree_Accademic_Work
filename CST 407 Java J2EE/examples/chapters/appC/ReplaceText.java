// Fig C.8 : ReplaceText.java
// Reads intro.xml and replaces a text node.

// Java core packages
import java.io.*;

// Java extension packages
import javax.xml.parsers.*;
import javax.xml.parsers.*;
import javax.xml.transform.*;
import javax.xml.transform.stream.*;
import javax.xml.transform.dom.*;

// third-party libraries
import org.xml.sax.*;
import org.w3c.dom.*;
         

public class ReplaceText {
   private Document document; 

   public ReplaceText()
   {
      // parse document, find/replace element, output result
      try {

         // obtain default parser
         DocumentBuilderFactory factory =
            DocumentBuilderFactory.newInstance();

         // set parser as validating           
         factory.setValidating( true );
     
         // obtain object that builds Documents
         DocumentBuilder builder = factory.newDocumentBuilder();

         // set error handler for validation errors
         builder.setErrorHandler( new MyErrorHandler() );

         // obtain document object from XML document
         document = builder.parse( new File( "intro.xml" ) );

         // retrieve the root node
         Node root = document.getDocumentElement();

         if ( root.getNodeType() == Node.ELEMENT_NODE ) {
            Element myMessageNode = ( Element ) root;
            NodeList messageNodes = 
               myMessageNode.getElementsByTagName( "message" );

            if ( messageNodes.getLength() != 0 ) {
               Node message = messageNodes.item( 0 );

               // create text node
               Text newText = document.createTextNode(
                  "New Changed Message!!" );

               // get old text node
               Text oldText =
                  ( Text ) message.getChildNodes().item( 0 );  

               // replace text 
               message.replaceChild( newText, oldText );
            }
         }            
        
         // output Document object
        
         // create DOMSource for source XML document
         Source xmlSource = new DOMSource( document );

         // create StreamResult for transformation result
         Result result = new StreamResult( System.out );

         // create TransformerFactory
         TransformerFactory transformerFactory =
            TransformerFactory.newInstance();

         // create Transformer for transformation
         Transformer transformer = 
            transformerFactory.newTransformer();
         
         transformer.setOutputProperty( OutputKeys.INDENT, "yes" );
		 transformer.setOutputProperty( OutputKeys.STANDALONE, "yes" );

         // transform and deliver content to client
         transformer.transform( xmlSource, result ); 
      } 
      
      // handle exception creating DocumentBuilder
      catch ( ParserConfigurationException parserException ) {
         parserException.printStackTrace();
      }
      
      // handle exception parsing Document
      catch ( SAXException saxException ) {
         saxException.printStackTrace();         
      }
      
      // handle exception reading/writing data 
      catch ( IOException ioException ) {
         ioException.printStackTrace();
         System.exit( 1 );
      }
      
      // handle exception creating TransformerFactory
      catch ( 
         TransformerFactoryConfigurationError factoryError ) {
         System.err.println( "Error while creating " +
            "TransformerFactory" );
         factoryError.printStackTrace();
      }
      
      // handle exception transforming document
      catch ( TransformerException transformerError ) {
         System.err.println( "Error transforming document" );
         transformerError.printStackTrace();
      }      
   }
   
   public static void main( String args[] )
   {
      ReplaceText replace = new ReplaceText();    
   }
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
