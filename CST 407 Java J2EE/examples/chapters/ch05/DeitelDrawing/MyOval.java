// MyOval.java
// MyOval is a MyShape subclass that represents an oval.
package com.deitel.advjhtp1.drawing.model.shapes;

// Java core packages
import java.awt.*;
import java.awt.geom.*;

// third-party packages
import org.w3c.dom.*;

public class MyOval extends MyShape {

   // draw MyOval on given Graphics2D context
   public void draw( Graphics2D g2D )
   {
      // configure Graphics2D (gradient, color, etc.)
      configureGraphicsContext( g2D );
      
      // create Ellipse2D for drawing oval
      Shape shape = new Ellipse2D.Float( getLeftX(),
         getLeftY(), getWidth(), getHeight() );
      
      // if shape is filled, draw filled shape
      if ( isFilled() )
         g2D.fill( shape );
      
      // draw shape
      else
         g2D.draw( shape );         
   }

   // return true if point falls inside MyOval
   public boolean contains( Point2D point ) 
   {
      Ellipse2D.Float ellipse = new Ellipse2D.Float( 
         getLeftX(), getLeftY(), getWidth(), getHeight() );
      
      return ellipse.contains( point );
   }
   
   // get MyOval XML representation
   public Element getXML( Document document )
   {
      Element shapeElement = super.getXML( document );
      shapeElement.setAttribute( "type", "MyOval" );
      
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
