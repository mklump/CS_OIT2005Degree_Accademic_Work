// MyLineController.java
// MyLineController is a MyShapeController subclass for MyLines.
package com.deitel.advjhtp1.drawing.controller;

// Deitel packages
import com.deitel.advjhtp1.drawing.model.*;
import com.deitel.advjhtp1.drawing.model.shapes.*;

public class MyLineController extends MyShapeController {
 
   private MyShape currentShape;
   
   // MyLineController constructor
   public MyLineController( DrawingModel model, Class shapeClass )
   { 
      super( model, shapeClass );
   }
   
   // start drawing new shape
   public void startShape( int x, int y )
   {
      // create new shape
      currentShape = createNewShape();

      if( currentShape != null ) {
         
         // set location of shape in drawing
         currentShape.setPoint1( x, y );
         currentShape.setPoint2( x, y );
         currentShape.setStartPoint( x, y );
         
         // add newly created shape to DrawingModel
         addShapeToModel( currentShape );
      }
      
   } // end method startShape
   
   // modify shape currently being drawn
   public void modifyShape( int x, int y )
   {
      // remove shape from DrawingModel
      removeShapeFromModel( currentShape );
      currentShape.setEndPoint( x, y );
      
      int startX = currentShape.getStartX();
      int startY = currentShape.getStartY();
         
      // set current ( x, y ) to Point1
      currentShape.setPoint1( x, y );

      // set Point2 to StartPoint
      currentShape.setPoint2( startX, startY );
         
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
