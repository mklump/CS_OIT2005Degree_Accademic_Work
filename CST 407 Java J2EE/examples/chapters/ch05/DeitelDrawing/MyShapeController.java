// MyShapeController.java
// MyShapeController is an abstract base class that represents
// a controller for painting shapes.
package com.deitel.advjhtp1.drawing.controller;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Deitel packages
import com.deitel.advjhtp1.drawing.model.*;
import com.deitel.advjhtp1.drawing.model.shapes.*;

public abstract class MyShapeController {
      
   private DrawingModel drawingModel;
   
   // primary and secondary Colors for drawing and gradients
   private Color primaryColor = Color.black;
   private Color secondaryColor = Color.white;
   
   // Class object for creating new MyShape-subclass instances
   private Class shapeClass;
   
   // common MyShape properties
   private boolean fillShape = false;
   private boolean useGradient = false;
   private float strokeSize = 1.0f;
   
   // indicates whether the user has specified drag mode; if
   // true, MyShapeController should ignore mouse events
   private boolean dragMode = false;   
   
   private MouseListener mouseListener;
   private MouseMotionListener mouseMotionListener;
   
   // MyShapeController constructor
   public MyShapeController( DrawingModel model, Class
      myShapeClass )
   { 
      // set DrawingModel to control
      drawingModel = model; 
      
      // set MyShape subclass
      shapeClass = myShapeClass;
      
      // listen for mouse events
      mouseListener = new MouseAdapter() {
         
         // when mouse button pressed, create new shape
         public void mousePressed( MouseEvent event ) 
         {
            // if not in dragMode, start new shape at 
            // given coordinates
            if ( !dragMode )
               startShape( event.getX(), event.getY() );
         }  

         // when mouse button released, set shape's final 
         // coordinates
         public void mouseReleased( MouseEvent event ) 
         {
            // if not in dragMode, finish drawing current shape
            if ( !dragMode )
               endShape( event.getX(), event.getY() );
         }               
      };
      
      // listen for mouse motion events
      mouseMotionListener = new MouseMotionAdapter() {
         
         // when mouse is dragged, set coordinates for current
         // shape's Point2
         public void mouseDragged( MouseEvent event ) 
         {
            // if not in dragMode, modify current shape
            if ( !dragMode ) 
               modifyShape( event.getX(), event.getY() );
         }                  
      };
   
   } // end MyShapeController constructor

   // set primary color (start color for gradient)
   public void setPrimaryColor( Color color ) 
   { 
      primaryColor = color; 
   }
   
   // get primary color
   public Color getPrimaryColor()
   {
      return primaryColor;
   }
      
   // set secondary color (end color for gradients)
   public void setSecondaryColor( Color color )
   { 
      secondaryColor = color; 
   }
   
   // get secondary color
   public Color getSecondaryColor()
   {
      return secondaryColor;
   }
   
   // fill shape
   public void setShapeFilled( boolean fill ) 
   { 
      fillShape = fill; 
   }
   
   // get shape filled
   public boolean getShapeFilled()
   {
      return fillShape;
   }   
      
   // use gradient when painting shape
   public void setUseGradient( boolean gradient )
   { 
      useGradient = gradient; 
   }
   
   // get use gradient
   public boolean getUseGradient()
   {
      return useGradient;
   }
   
   // set dragMode
   public void setDragMode( boolean drag ) 
   { 
      dragMode = drag; 
   }
   
   // set stroke size for lines
   public void setStrokeSize( float stroke )
   {
      strokeSize = stroke;
   }
   
   // get stroke size
   public float getStrokeSize()
   {
      return strokeSize;
   }

   // create new instance of current MyShape subclass
   protected MyShape createNewShape() 
   {
      // create new instance of current MyShape subclass
      try {
         MyShape shape = ( MyShape ) shapeClass.newInstance();
         
         // set MyShape properties
         shape.setFilled( fillShape );
         shape.setUseGradient( useGradient );
         shape.setStrokeSize( getStrokeSize() );
         shape.setStartColor( getPrimaryColor() );
         shape.setEndColor( getSecondaryColor() );

         // return reference to newly created shape
         return shape;
      }
      
      // handle exception instantiating shape
      catch ( InstantiationException instanceException ) { 
         instanceException.printStackTrace(); 
         return null;
      }  
      
      // handle access exception instantiating shape
      catch ( IllegalAccessException accessException ) { 
         accessException.printStackTrace(); 
         return null;
      } 
      
   } // end method createNewShape
   
   // get MyShapeController's MouseListener
   public MouseListener getMouseListener()
   {
      return mouseListener;
   }
   
   // get MyShapeController's MouseMotionListener
   public MouseMotionListener getMouseMotionListener()
   {
      return mouseMotionListener;
   }
   
   // add given shape to DrawingModel
   protected void addShapeToModel( MyShape shape )
   {
      drawingModel.addShape( shape );
   }
   
   // remove given shape from DrawingModel
   protected void removeShapeFromModel( MyShape shape )
   {
      drawingModel.removeShape( shape );
   }   
   
   // start new shape
   public abstract void startShape( int x, int y );
 
   // modify current shape
   public abstract void modifyShape( int x, int y );

   // finish shape
   public abstract void endShape( int x, int y );
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
