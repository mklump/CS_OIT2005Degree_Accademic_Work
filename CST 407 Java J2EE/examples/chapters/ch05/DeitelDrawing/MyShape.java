// MyShape.java
// MyShape is an abstract base class that represents a shape
// to be drawn in the DeitelDrawing application.
package com.deitel.advjhtp1.drawing.model.shapes;

// Java core packages
import java.awt.*;
import java.awt.geom.Point2D;

// third-party packages
import org.w3c.dom.*;

public abstract class MyShape {
      
   // MyShape properties (coordinates, colors, etc.)
   private int x1, y1, x2, y2;
   private int startX, startY, endX, endY;
   private Color startColor = Color.black;
   private Color endColor = Color.white;
   private boolean filled = false;
   private boolean gradient = false;
   private float strokeSize = 1.0f;
   private Stroke currentStroke;
   
   // get x coordinate of left corner
   public int getLeftX()
   { 
      return x1; 
   }

   // get y coordinate of left corner
   public int getLeftY()
   { 
      return y1; 
   }

   // get x coordinate of right corner
   public int getRightX()
   { 
      return x2; 
   }

   // get y coordinate of right corner
   public int getRightY()
   { 
      return y2; 
   }
   
   // get MyShape width
   public int getWidth()
   { 
      return Math.abs( getX1() - getX2() ); 
   }

   // get MyShape height
   public int getHeight()
   { 
      return Math.abs( getY1() - getY2() ); 
   }

   // set Point1's  x and y coordinates
   public void setPoint1( int x, int y )
   {
      x1 = x;
      y1 = y;
   }

   // set Point2's x and y coordinates
   public final void setPoint2( int x, int y )
   {
      x2 = x;
      y2 = y;
   }
   
   // set start Point's x and y coordinates
   public final void setStartPoint( int x, int y )
   {
      startX = x;
      startY = y;
   }

   // set end Point's x and y coordinates
   public final void setEndPoint( int x, int y )
   {
      endX = x;
      endY = y;
   }
   
   // get x1 coordinate
   public final int getX1() 
   { 
      return x1; 
   }

   // get x2 coordinate
   public final int getX2() 
   { 
      return x2; 
   }

   // get y1 coordinate
   public final int getY1() 
   { 
      return y1; 
   }

   // get y2 coordinate
   public final int getY2() 
   { 
      return y2; 
   }
   
   
   // get startX coordinate
   public final int getStartX() 
   { 
      return startX; 
   }

   // get startY coordinate
   public final int getStartY() 
   { 
      return startY; 
   }

   // get endX coordinate
   public final int getEndX() 
   { 
      return endX; 
   }

   // get endY coordinate
   public final int getEndY() 
   { 
      return endY; 
   }

   // move MyShape by given offset
   public void moveByOffSet( int x, int y )
   {
      setPoint1( getX1() + x, getY1() + y );
      setPoint2( getX2() + x, getY2() + y );
      setStartPoint( getStartX() + x, getStartY() + y );
      setEndPoint( getEndX() + x, getEndY() + y );
   }      
   
   // set default drawing color
   public void setColor( Color color ) 
   {
      setStartColor( color ); 
   }

   // get default drawing color
   public Color getColor() 
   { 
      return getStartColor(); 
   }
   
   // set primary drawing color
   public void setStartColor( Color color ) 
   { 
      startColor = color; 
   }
      
   // get primary drawing color
   public Color getStartColor() 
   { 
      return startColor; 
   }
       
   // set secondary drawing color (for gradients)
   public void setEndColor( Color color )
   { 
      endColor = color; 
   }
      
   // get secondary drawing color
   public Color getEndColor() 
   { 
      return endColor; 
   }
   
   // enable/disable gradient drawing
   public void setUseGradient( boolean useGradient )
   { 
      gradient = useGradient; 
   }
      
   // get gradient enabled/disabled property
   public boolean useGradient() 
   { 
      return gradient; 
   }
   
   // set stroke size
   public void setStrokeSize( float size )
   {
      strokeSize = size;
      currentStroke = new BasicStroke( strokeSize );
   }
   
   // get stroke size
   public float getStrokeSize()
   { 
      return strokeSize;
   }
   
   // set filled property
   public void setFilled ( boolean fill ) 
   { 
      filled = fill; 
   }
   
   // get filled property
   public boolean isFilled() 
   { 
      return filled; 
   }

   // abstract draw method to be implemented by subclasses
   // to draw actual shapes
   public abstract void draw( Graphics2D g2D );

   // return true if the Point2D falls within this shape
   public abstract boolean contains( Point2D point );
   
   // configure Graphics2D context for known drawing properties
   protected void configureGraphicsContext( Graphics2D g2D )
   {
      // set Stroke for drawing shape
      if ( currentStroke == null )
         currentStroke = new BasicStroke( getStrokeSize() );
      
      g2D.setStroke( currentStroke );
      
      // if gradient selected, create new GradientPaint starting
      // at x1, y1 with color1 and ending at x2, y2 with color2
      if ( useGradient() )    
         g2D.setPaint ( new GradientPaint( 
            ( int ) getStartX(), ( int ) getStartY(), 
            getStartColor(), ( int ) getEndX(), ( int ) getEndY(), 
            getEndColor() ) );
      
      // if no gradient selected, use primary color
      else
         g2D.setPaint( getColor() );      
   }   

   // get MyShape XML representation
   public Element getXML( Document document )
   {
      Element shapeElement = document.createElement( "shape" );
      
      // create Elements for x and y coordinates
      Element temp = document.createElement( "x1" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( getX1() ) ) );
      shapeElement.appendChild( temp );
      
      temp = document.createElement( "y1" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( getY1() ) ) );
      shapeElement.appendChild( temp );
      
      temp = document.createElement( "x2" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( getX2() ) ) );
      shapeElement.appendChild( temp );
      
      temp = document.createElement( "y2" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( getY2() ) ) );
      shapeElement.appendChild( temp );
      
      temp = document.createElement( "startX" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( getStartX() ) ) );
      shapeElement.appendChild( temp );
      
      temp = document.createElement( "startY" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( getStartY() ) ) );
      shapeElement.appendChild( temp );
      
      temp = document.createElement( "endX" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( getEndX() ) ) );
      shapeElement.appendChild( temp );      
      
      temp = document.createElement( "endY" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( getEndY() ) ) );
      shapeElement.appendChild( temp );   
      
      // create Element for gradient property
      temp = document.createElement( "useGradient" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( useGradient() ) ) );
      shapeElement.appendChild( temp );
      
      // create XML element for startColor
      Color color = getStartColor();
      temp = document.createElement( "startColor" );
      temp.setAttribute( "red", 
         String.valueOf( color.getRed() ) );
      temp.setAttribute( "green", 
         String.valueOf( color.getGreen() ) );
      temp.setAttribute( "blue", 
         String.valueOf( color.getBlue() ) );
      shapeElement.appendChild( temp );

      // create XML element for endColor
      color = getEndColor();
      temp = document.createElement( "endColor" );
      temp.setAttribute( "red", 
         String.valueOf( color.getRed() ) );
      temp.setAttribute( "green", 
         String.valueOf( color.getGreen() ) );
      temp.setAttribute( "blue", 
         String.valueOf( color.getBlue() ) );
      shapeElement.appendChild( temp );
      
      // add strokeSize element
      temp = document.createElement( "strokeSize" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( getStrokeSize() ) ) );
      shapeElement.appendChild( temp );
      
      // add fill element
      temp = document.createElement( "fill" );
      temp.appendChild( document.createTextNode( 
         String.valueOf( isFilled() ) ) );
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
