// BoundedShapeController.java
// BoundedShapeController is a MyShapeController subclass for 
// rectangle-bounded shapes, such as MyOvals and MyRectangles.
package com.deitel.advjhtp1.drawing.controller;

// Deitel packages
import com.deitel.advjhtp1.drawing.model.*;
import com.deitel.advjhtp1.drawing.model.shapes.*;

public class BoundedShapeController extends MyShapeController {
 
   private MyShape currentShape;
   
   // BoundedShapeController constructor
   public BoundedShapeController( 
      DrawingModel model, Class shapeClass )
   { 
      super( model, shapeClass );
   }
   
   // start drawing shape
   public void startShape( int x, int y )
   {
      // get new shape
      currentShape = createNewShape();

      if( currentShape != null ) {
         
         // set location of shape in drawing
         currentShape.setPoint1( x, y );
         currentShape.setPoint2( x, y );
         currentShape.setStartPoint( x, y );
         
         // add newly created shape to DrawingModel
         addShapeToModel( currentShape );
      }
   }
   
   // modify shape currently being drawn
   public void modifyShape( int x, int y )
   {
      // remove shape from DrawingModel
      removeShapeFromModel( currentShape );      
      currentShape.setEndPoint( x, y );
      
      int startX = currentShape.getStartX();
      int startY = currentShape.getStartY();
      
      // set Point1 to upper-left coordinates of shape
      currentShape.setPoint1( 
         Math.min( x, startX ), Math.min( y, startY ) );
      
      // set Point2 to lower right coordinates of shape
      currentShape.setPoint2( 
         Math.max( x, startX ), Math.max( y, startY ) );
      
      // add shape back into model
      addShapeToModel( currentShape );      
   }
   
   // finish drawing shape
   public void endShape( int x, int y )
   {
      modifyShape( x, y );
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
