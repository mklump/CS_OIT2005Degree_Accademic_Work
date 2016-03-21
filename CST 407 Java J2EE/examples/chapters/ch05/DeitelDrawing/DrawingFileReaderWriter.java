// DrawingFileReaderWriter.java
// DrawingFileReaderWriter defines static methods for reading
// and writing DeitelDrawing files on disk.
package com.deitel.advjhtp1.drawing;

// Java core packages
import java.io.*;
import java.util.*;
import java.awt.Color;

// Java extension packages
import javax.xml.parsers.*;
import javax.xml.transform.*;
import javax.xml.transform.dom.*;
import javax.xml.transform.stream.*;

// third-party packages
import org.w3c.dom.*;
import org.xml.sax.*;

// Deitel packages
import com.deitel.advjhtp1.drawing.model.*;
import com.deitel.advjhtp1.drawing.model.shapes.*;

public class DrawingFileReaderWriter {
   
   // write drawing to file with given fileName
   public static void writeFile( DrawingModel drawingModel, 
      String fileName ) 
   {
      // open file for writing and save drawing data
      try {
         
         DocumentBuilderFactory builderFactory =
            DocumentBuilderFactory.newInstance();
         
         DocumentBuilder builder = 
            builderFactory.newDocumentBuilder();
         
         Document document = builder.newDocument();
         
         // create shapes element to contain all MyShapes
         Element shapesElement = 
            document.createElement( "shapes" );
         document.appendChild( shapesElement );
         
         Iterator iterator = drawingModel.getShapes().iterator();
         
         // populate shapes element with shape element for each
         // MyShape in DrawingModel
         while ( iterator.hasNext() ) {
            MyShape shape = ( MyShape ) iterator.next();
            
            shapesElement.appendChild( shape.getXML( document ) );            
         }
         
         // use Transformer to write shapes XML document to a file
         TransformerFactory transformerFactory = 
            TransformerFactory.newInstance();
         
         Transformer transformer = 
            transformerFactory.newTransformer();
         
         // specify the shapes.dtd Document Type Definition
         transformer.setOutputProperty(
            OutputKeys.DOCTYPE_SYSTEM, "shapes.dtd" );
         
         transformer.transform( new DOMSource( document ), 
            new StreamResult( new FileOutputStream( 
               fileName ) ) );        
         
      } // end try
      
      // handle exception building XML Document
      catch ( ParserConfigurationException parserException ) {
         parserException.printStackTrace();
      }
      
      // handle exception transforming XML Document
      catch ( TransformerException transformerException ) {
         transformerException.printStackTrace();
      }
      
      // handle exception opening FileOutputStream
      catch( FileNotFoundException fileException ) { 
         fileException.printStackTrace(); 
      } 
      
   } // end method writeFile
   
   // open existing drawing from file
   public static Collection readFile( String fileName ) 
   {         
      // load shapes from file
      try {
         
         // Collection of MyShapes read from XML Document
         Collection shapes = new ArrayList();
         
         DocumentBuilderFactory builderFactory =
            DocumentBuilderFactory.newInstance();
         
         builderFactory.setValidating( true );
         
         DocumentBuilder builder = 
            builderFactory.newDocumentBuilder();
         
         Document document = builder.parse( 
            new File( fileName ) );
         
         // get all shape elements in XML Document
         NodeList list = document.getElementsByTagName( "shape" );
         
         // get MyShape from each shape element in XML Document
         for ( int i = 0; i < list.getLength(); i++ ) {            
            Element element = ( Element ) list.item( i );            
            MyShape shape = getShapeFromElement( element );            
            shapes.add( shape );            
         }
         
         return shapes;
         
      } // end try
      
      // handle exception parsing XML Document
      catch ( ParserConfigurationException parserException ) {
         parserException.printStackTrace();
      }     
      
      // handle exception parsing Document
      catch ( SAXException saxException ) {
         saxException.printStackTrace();
      }
      
      // handle exception reading Document from file
      catch ( IOException ioException ) {
         ioException.printStackTrace();
      }
         
      return null;
   
   } // end method readFile
   
   // create MyShape using properties specified in given Element
   private static MyShape getShapeFromElement( Element element )
   {
      MyShape shape = null;
      
      // get MyShape type (e.g., MyLine, MyRectangle, etc.)
      String type = element.getAttribute( "type" );
      
      // create appropriate MyShape subclass instance
      if ( type.equals( "MyLine" ) ) {
         shape = new MyLine();
      }
      
      else if ( type.equals( "MyRectangle" ) ) {
         shape = new MyRectangle();
      }
            
      else if ( type.equals( "MyOval" ) ) {
         shape = new MyOval();
      }
            
      else if ( type.equals( "MyText" ) ) {
         shape = new MyText();
         
         // create MyText reference for setting MyText-specific
         // properties, including fontSize, text, etc.
         MyText textShape  = ( MyText ) shape;
         
         // set text property
         String text = 
            getStringValueFromChildElement( element, "text" );
         
         textShape.setText( text );
         
         // set fontSize property
         int fontSize =
            getIntValueFromChildElement( element, "fontSize" );
         
         textShape.setFontSize( fontSize );
         
         // set fontName property
         String fontName =
            getStringValueFromChildElement( element, "fontName" );
         
         textShape.setFontName( fontName );
         
         // set underlined property
         boolean underlined = getBooleanValueFromChildElement( 
            element, "underlined" );
         
         textShape.setUnderlineSelected( underlined );
         
         // set bold property
         boolean bold =
            getBooleanValueFromChildElement( element, "bold" );
         
         textShape.setBoldSelected( bold );
         
         // set italic property
         boolean italic =
            getBooleanValueFromChildElement( element, "italic" );
         
         textShape.setItalicSelected( italic );  
      }
            
      else if ( type.equals( "MyImage" ) ) {
         shape = new MyImage();
         
         // create MyImage reference for setting MyImage-specific
         // fileName property
         MyImage imageShape = ( MyImage ) shape;
         
         String fileName = getStringValueFromChildElement(
            element, "fileName" );
         
         imageShape.setFileName( fileName );
      }
      
      // set properties common to all MyShapes, including x1, y1,
      // x2, y2, startColor, endColor, etc.
      
      // set x1 and y1 properties
      int x1 = getIntValueFromChildElement( element, "x1" );
      int y1 = getIntValueFromChildElement( element, "y1" );
      
      shape.setPoint1( x1, y1 );
      
      // set x2 and y2 properties
      int x2 = getIntValueFromChildElement( element, "x2" );
      int y2 = getIntValueFromChildElement( element, "y2" );
      
      shape.setPoint2( x2, y2 );
      
      // set startX and startY properties
      int startX = 
         getIntValueFromChildElement( element, "startX" );
      int startY = 
         getIntValueFromChildElement( element, "startY" );
      
      shape.setStartPoint( startX, startY );
      
      // set endX and endY properties
      int endX = getIntValueFromChildElement( element, "endX" );
      int endY = getIntValueFromChildElement( element, "endY" );
      
      shape.setEndPoint( endX, endY );
      
      // set startColor and endColor properties
      Color startColor = 
         getColorValueFromChildElement( element, "startColor" );
      
      shape.setStartColor( startColor );

      Color endColor = 
         getColorValueFromChildElement( element, "endColor" );   
      
      shape.setEndColor( endColor );
      
      // set useGradient property
      boolean useGradient = getBooleanValueFromChildElement( 
         element, "useGradient" );
      
      shape.setUseGradient( useGradient );
      
      // set strokeSize property
      float strokeSize = getFloatValueFromChildElement(
         element, "strokeSize" );
      
      shape.setStrokeSize( strokeSize );
      
      // set filled property
      boolean fill = 
         getBooleanValueFromChildElement( element, "fill" );
      
      shape.setFilled( fill );
      
      return shape;
      
   } // end method getShapeFromElement
   
   // get int value from child element with given name
   private static int getIntValueFromChildElement( Element parent,
      String childElementName )
   {
      // get NodeList for Elements of given childElementName
      NodeList childNodes = parent.getElementsByTagName(
         childElementName );
      
      // get Text Node from zeroth child Element
      Node childTextNode = childNodes.item( 0 ).getFirstChild();
      
      // parse int value from Text Node
      return Integer.parseInt( childTextNode.getNodeValue() ); 
      
   } // end method getIntValueFromChildElement
   
   // get float value from child element with given name
   private static float getFloatValueFromChildElement(
      Element parent, String childElementName )
   {
      // get NodeList for Elements of given childElementName
      NodeList childNodes = parent.getElementsByTagName(
         childElementName );
      
      // get Text Node from zeroth child Element
      Node childTextNode = childNodes.item( 0 ).getFirstChild();
      
      // parse float value from Text Node
      return Float.parseFloat( childTextNode.getNodeValue() );  
      
   } // end method getFloatValueFromChildElement
   
   // get boolean value from child element with given name
   private static boolean getBooleanValueFromChildElement(
      Element parent, String childElementName )
   {
      // get NodeList for Elements of given childElementName
      NodeList childNodes = parent.getElementsByTagName(
         childElementName );
      
      Node childTextNode = childNodes.item( 0 ).getFirstChild();
      
      // parse boolean value from Text Node
      return Boolean.valueOf( 
         childTextNode.getNodeValue() ).booleanValue();   
      
   } // end method getBooleanValueFromChildElement
   
   // get String value from child element with given name
   private static String getStringValueFromChildElement(
      Element parent, String childElementName )
   {
      // get NodeList for Elements of given childElementName
      NodeList childNodes = parent.getElementsByTagName(
         childElementName );
      
      // get Text Node from zeroth child Element
      Node childTextNode = childNodes.item( 0 ).getFirstChild();
      
      // return String value of Text Node
      return childTextNode.getNodeValue();  
      
   }  // end method getStringValueFromChildElement 
   
   // get Color value from child element with given name
   private static Color getColorValueFromChildElement(
      Element parent, String childElementName )
   {
      // get NodeList for Elements of given childElementName
      NodeList childNodes = parent.getElementsByTagName(
         childElementName );
      
      // get zeroth child Element
      Element childElement = ( Element ) childNodes.item( 0 );
      
      // get red, green and blue attribute values
      int red = Integer.parseInt( 
         childElement.getAttribute( "red" ) );
      
      int green = Integer.parseInt( 
         childElement.getAttribute( "green" ) );
      
      int blue = Integer.parseInt( 
         childElement.getAttribute( "blue" ) );      
      
      // return Color for given red, green and blue values
      return new Color( red, green, blue );           
      
   } // end method getColorValueFromChildElement
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
