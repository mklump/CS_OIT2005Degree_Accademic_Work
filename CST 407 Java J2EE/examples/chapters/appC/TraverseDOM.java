// Fig. C.13 : TraverseDOM.java
// Traverses DOM and prints various nodes.

// Java core packages
import java.io.*;

// Java extension packages
import javax.xml.parsers.*;

// third-party libraries
import org.w3c.dom.*;
import org.xml.sax.*;

public class TraverseDOM {
   private Document document;   
   
   public TraverseDOM( String file )
   {
      // parse XML, create DOM tree, call method processNode
      try {

         // obtain default parser
         DocumentBuilderFactory factory =
            DocumentBuilderFactory.newInstance();
         factory.setValidating( true );
         DocumentBuilder builder = factory.newDocumentBuilder();

         // set error handler for validation errors
         builder.setErrorHandler( new MyErrorHandler() );

         // obtain document object from XML document
         document = builder.parse( new File( file ) );
         processNode( document );
      } 
      
      // handle exception thrown by DocumentBuilder
      catch ( ParserConfigurationException parserException ) {
         parserException.printStackTrace();
      }
      
      // handle exception thrown by Parser
      catch ( SAXException saxException ) {
         saxException.printStackTrace();         
      }
      
      // handle exception thrown when reading data from file
      catch ( IOException ioException ) {
         ioException.printStackTrace();
         System.exit( 1 );
      }
   }

   public void processNode( Node currentNode )
   {
      switch ( currentNode.getNodeType() ) {

         // process Document root
         case Node.DOCUMENT_NODE:
            Document doc = ( Document ) currentNode;

            System.out.println( 
                 "Document node: " + doc.getNodeName() +
                 "\nRoot element: " +
                 doc.getDocumentElement().getNodeName() );
            processChildNodes( doc.getChildNodes() );
            break;

         // process Element node
         case Node.ELEMENT_NODE:   
            System.out.println( "\nElement node: " + 
                                currentNode.getNodeName() );
            NamedNodeMap attributeNodes =
               currentNode.getAttributes();

            for ( int i = 0; i < attributeNodes.getLength(); i++) {
               Attr attribute = ( Attr ) attributeNodes.item( i );

               System.out.println( "\tAttribute: " + 
                  attribute.getNodeName() + " ; Value = " +
                  attribute.getNodeValue() );
            }

            processChildNodes( currentNode.getChildNodes() );
            break;

         // process text node and CDATA section
         case Node.CDATA_SECTION_NODE:
         case Node.TEXT_NODE: 
            Text text = ( Text ) currentNode;

            if ( !text.getNodeValue().trim().equals( "" ) )
               System.out.println( "\tText: " +
                  text.getNodeValue() );
            break;
      }
   }

   public void processChildNodes( NodeList children )
   {
      if ( children.getLength() != 0 ) 

         for ( int i = 0; i < children.getLength(); i++ )
            processNode( children.item( i ) );
   }

   public static void main( String args[] )
   {
      if ( args.length < 1 ) {
         System.err.println( 
            "Usage: java TraverseDOM <filename>" );
         System.exit( 1 );
      }

      TraverseDOM traverseDOM = new TraverseDOM( args[ 0 ] );    
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
