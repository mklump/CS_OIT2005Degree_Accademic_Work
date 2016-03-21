// Fig C.2 : XMLInfo.java
// Outputs node information

// Java core libraries
import java.io.*;

// Java standard extensions
import javax.xml.parsers.*;

// third-party libraries
import org.w3c.dom.*;   
import org.xml.sax.*;

public class XMLInfo {
   
   public static void main( String args[] ) 
   {

      if ( args.length != 1 ) {
         System.err.println( "Usage: java XMLInfo input.xml" );
         System.exit( 1 );
      }      
      
      try {
         
         // create DocumentBuilderFactory
         DocumentBuilderFactory factory = 
            DocumentBuilderFactory.newInstance();

         // create DocumentBuilder
         DocumentBuilder builder = factory.newDocumentBuilder();

         // obtain document object from XML document
         Document document = builder.parse( 
            new File( args[ 0 ] ) );

         // get root node
         Node root = document.getDocumentElement();

         System.out.print( "Here is the document's root node:" );
         System.out.println( " " + root.getNodeName() );

         System.out.println( "Here are its child elements: " );
         NodeList childNodes = root.getChildNodes();
         Node currentNode;  

         for ( int i = 0; i < childNodes.getLength(); i++ ) {
         
            currentNode = childNodes.item( i );

            // print node name of each child element
            System.out.println( currentNode.getNodeName() );
         }

         // get first child of root element
         currentNode = root.getFirstChild();

         System.out.print( "The first child of root node is: " );
         System.out.println( currentNode.getNodeName() );

         // get next sibling of first child
         System.out.print( "whose next sibling is: " );
         currentNode = currentNode.getNextSibling();
         System.out.println( currentNode.getNodeName() );

         // print value of next sibling of first child
         System.out.println( "value of " + 
            currentNode.getNodeName() + " element is: " + 
            currentNode.getFirstChild().getNodeValue() );

         // print name of parent of next sibling of first child
         System.out.print( "Parent node of " + 
            currentNode.getNodeName() + " is: " +
            currentNode.getParentNode().getNodeName() );
      }

      // handle exception creating DocumentBuilder
      catch ( ParserConfigurationException parserError ) {
         System.err.println( "Parser Configuration Error" );
         parserError.printStackTrace();
      }

      // handle exception reading data from file
      catch ( IOException fileException ) {
         System.err.println( "File IO Error" );
         fileException.printStackTrace();
      }

      // handle exception parsing XML document
      catch ( SAXException parseException ) {
         System.err.println( "Error Parsing Document" );
         parseException.printStackTrace();
      }
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
