// Transform.java
// Performs XSL Transformation

// Java core libraries
import java.io.*;
import java.util.*;

// Java standard extensions
import javax.xml.parsers.*;
import javax.xml.transform.*;
import javax.xml.transform.dom.*;
import javax.xml.transform.stream.*;

// third-party libraries
import org.w3c.dom.*;
import org.xml.sax.SAXException;      

public class Transform {
   
   // execute application
   public static void main( String args[] ) throws Exception
   {            
      if ( args.length != 3 ) {
         System.err.println( "Usage: java Transform input.xml"
            + "input.xsl output.xml" );
         System.exit( 1 );
      }

      // factory for creating DocumentBuilders
      DocumentBuilderFactory builderFactory = 
         DocumentBuilderFactory.newInstance();

      // factory for creating Transformers
      TransformerFactory transformerFactory = 
         TransformerFactory.newInstance();     

      DocumentBuilder builder = 
         builderFactory.newDocumentBuilder();

      Document document = builder.parse( new File( args[ 0 ] ) );

      // create DOMSource for source XML document
      Source xmlSource = new DOMSource( document );

      // create StreamSource for XSLT document
      Source xslSource = new StreamSource( new File( args[ 1 ] ) );

      // create StreamResult for transformation result
      Result result = new StreamResult( new File( args[ 2 ] ) );

      // create Transformer for XSL transformation
      Transformer transformer = 
         transformerFactory.newTransformer( xslSource );

      // transform and deliver content to client
      transformer.transform( xmlSource, result );
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
