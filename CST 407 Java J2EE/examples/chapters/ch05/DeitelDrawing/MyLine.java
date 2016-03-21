// MyLine.java
// MyLine is a MyShape subclass that represents a line.
package com.deitel.advjhtp1.drawing.model.shapes;

// Java core packages
import java.awt.*;
import java.awt.geom.*;

// third-party packages
import org.w3c.dom.*;

public class MyLine extends MyShape {

   // draw MyLine object on given Graphics2D context
   public void draw( Graphics2D g2D )
   {
      // configure Graphics2D (gradient, color, etc.)
      configureGraphicsContext( g2D );
      
      // create new Line2D.Float
      Shape line = new Line2D.Float( getX1(), getY1(), getX2(), 
         getY2() );
      
      // draw shape
      g2D.draw( line );
   }

   // determine if MyLine contains given Point2D
   public boolean contains( Point2D point ) 
   {       
      // get Point1 and Point2 coordinates
      float x1 = getX1();
      float x2 = getX2();
      float y1 = getY1();
      float y2 = getY2();
      
      // determines slope of line
      float slope = ( y2 - y1 ) / ( x2 - x1 );
      
      // determines slope from point argument and Point1
      float realSlope = ( float ) 
         ( ( point.getY() - y1 ) / ( point.getX() - x1 ) );
      
      // return true if slope and realSlope are close in value
      return Math.abs( realSlope - slope ) < 0.1;
   }

   // get MyLine XML representation
   public Element getXML( Document document )
   {
      Element shapeElement = super.getXML( document );      
      shapeElement.setAttribute( "type", "MyLine" );  
      
      return shapeElement;
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
