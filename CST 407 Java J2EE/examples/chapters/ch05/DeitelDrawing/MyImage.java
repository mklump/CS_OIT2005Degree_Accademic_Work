// MyImage.java
// MyImage is a MyShape subclass that contains a JPEG image.
package com.deitel.advjhtp1.drawing.model.shapes;

// Java core packages
import java.io.*;
import java.awt.*;
import java.awt.image.*;
import java.awt.geom.*;

// third-party packages
import org.w3c.dom.*;
import com.sun.image.codec.jpeg.*;

public class MyImage extends MyShape {
   
   private BufferedImage image;
   private String fileName;

   // draw image on given Graphics2D context
   public void draw( Graphics2D g2D ) 
   {
      // draw image on Graphics2D context
      g2D.drawImage( getImage(), getX1(), getY1(), null );
   }

   // return true if Point falls within MyImage
   public boolean contains( Point2D point ) 
   {
      Rectangle2D.Float rectangle = new Rectangle2D.Float( 
         getX1(), getY1(), getWidth(), getHeight() );

      return rectangle.contains( point );
   }

   // get MyImage image
   public BufferedImage getImage() 
   { 
      return image; 
   }

   // set filename for loading image
   public void setFileName( String name ) 
   { 
      // load image from file
      try {
         File file = new File( name );

         FileInputStream inputStream = 
            new FileInputStream( file );

         // decode JPEG image
         JPEGImageDecoder decoder = 
            JPEGCodec.createJPEGDecoder( inputStream );
         
         image = decoder.decodeAsBufferedImage();  
      
         setPoint2( getX1() + image.getWidth(), 
            getY1() + image.getHeight() );
      }

      // handle exception reading image from file
      catch ( IOException ioException ) {
         ioException.printStackTrace();
      }
      
      // set fileName if try is successful
      fileName = name;
   }

   // get image filename
   public String getFileName() 
   { 
      return fileName; 
   }
   
   // get MyImage XML Element
   public Element getXML( Document document ) 
   {
      Element shapeElement = super.getXML( document );
      shapeElement.setAttribute( "type", "MyImage" );
      
      // create filename Element
      Element temp = document.createElement( "fileName" );
      temp.appendChild( document.createTextNode( 
         getFileName() ) );
      shapeElement.appendChild( temp );
      
      return shapeElement;
  
   } // end method getXML
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
