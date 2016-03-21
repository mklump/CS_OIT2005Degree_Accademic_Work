// Fig. C.11 : BuildXml.java
// Creates element node, attribute node, comment node,
// processing instruction and a CDATA section.

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
         
public class BuildXml {
   private Document document;   

   public BuildXml()
   {

      DocumentBuilderFactory factory =
            DocumentBuilderFactory.newInstance();
      
      // create new DOM tree
      try {

         // get DocumentBuilder
         DocumentBuilder builder = 
            factory.newDocumentBuilder();

         // create root node       
         document = builder.newDocument();
      } 
      
      // handle exception thrown by DocumentBuilder
      catch ( ParserConfigurationException parserException ) {
         parserException.printStackTrace();
      }

      Element root = document.createElement( "root" );
      document.appendChild( root );

      // add comment to XML document
      Comment simpleComment = document.createComment( 
         "This is a simple contact list" );
      root.appendChild( simpleComment );

      // add child element
      Node contactNode = createContactNode( document );
      root.appendChild( contactNode );

      // add processing instruction
      ProcessingInstruction pi = 
         document.createProcessingInstruction(
             "myInstruction", "action silent" );
      root.appendChild( pi );

      // add CDATA section
      CDATASection cdata = document.createCDATASection(
         "I can add <, >, and ?" );     
      root.appendChild( cdata ); 

      // write the XML document to disk
      try {      

         // create DOMSource for source XML document
         Source xmlSource = new DOMSource( document );
         
         // create StreamResult for transformation result
         Result result = new StreamResult( 
            new FileOutputStream( "myDocument.xml" ) );

         // create TransformerFactory
         TransformerFactory transformerFactory =
            TransformerFactory.newInstance();

         // create Transformer for transformation
         Transformer transformer = 
            transformerFactory.newTransformer();
         
         transformer.setOutputProperty( "indent", "yes" );

         // transform and deliver content to client
         transformer.transform( xmlSource, result ); 
      } 
      
      // handle exception creating TransformerFactory
      catch ( 
         TransformerFactoryConfigurationError factoryError ) {
         System.err.println( "Error creating " +
            "TransformerFactory" );
         factoryError.printStackTrace();
      }
      
      // handle exception transforming document
      catch ( TransformerException transformerError ) {
         System.err.println( "Error transforming document" );
         transformerError.printStackTrace();
      }
      
      // handle exception writing data to file
      catch ( IOException ioException ) {
         ioException.printStackTrace();
      }
   }

   public Node createContactNode( Document document )
   {

      // create FirstName and LastName elements
      Element firstName = document.createElement( "FirstName" );
      Element lastName = document.createElement( "LastName" );

      firstName.appendChild( document.createTextNode( "Sue" ) );
      lastName.appendChild( document.createTextNode( "Green" ) );
      
      // create contact element
      Element contact = document.createElement( "contact" );

      // create attribute
      Attr genderAttribute = document.createAttribute( "gender" ); 
      genderAttribute.setValue( "F" );

      // append attribute to contact element
      contact.setAttributeNode( genderAttribute );
      contact.appendChild( firstName );
      contact.appendChild( lastName );
      
      return contact;
   }    
   
   public static void main( String args[] )
   {
     BuildXml buildXml = new BuildXml();    
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
