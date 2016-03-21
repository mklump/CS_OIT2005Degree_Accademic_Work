// ZoomDrawingView.java
// ZoomDrawingView is a subclass of DrawingView that scales
// the view of the drawing using the given scale factor.
package com.deitel.advjhtp1.drawing.view;

// Java core packages
import java.awt.*;
import java.awt.geom.*;
import java.awt.event.*;

// Deitel packages
import com.deitel.advjhtp1.drawing.model.*;

public class ZoomDrawingView extends DrawingView {
   
   // factor for scaling view
   private double scaleFactorX;
   private double scaleFactorY;
   
   // transform for scaling view
   private AffineTransform scaleTransform;
   
   // construct ZoomDrawingView with given model and default
   // scale factor
   public ZoomDrawingView( DrawingModel model ) 
   { 
      this( model, 1.0 ); 
   }
      
   // construct ZoomDrawingView with given model and scale factor
   public ZoomDrawingView( DrawingModel model, double scale )
   {
      this( model, scale, scale );
   }
   
   // construct ZoomDrawingView with given model and separate
   // x and y scale factors
   public ZoomDrawingView( DrawingModel model, double scaleX, 
      double scaleY )
   {
      // call DrawingView constructor
      super( model );
      
      // set scale factor for this view
      setScaleFactors( scaleX, scaleY );
      
      // listen for component resize events to adjust scale
      addComponentListener( 
         new ComponentAdapter() { 
            
            // when view is resized, update scale factors
            public void componentResized( ComponentEvent event ) 
            {        
               double width = ( double ) getSize().width;
               double height = ( double ) getSize().height;
               
               // calculate new scale factors
               double factorX = width / 320.0;
               
               double factorY = height / 240.0;
               
               setScaleFactors( factorX, factorY );
            }
         }
      );      
      
   } // end ZoomDrawingView constructor 
   
   // draw shapes using scaled Graphics2D object
   public void drawShapes( Graphics2D g2D )
   {
      // set Graphics2D object transform
      g2D.setTransform( scaleTransform );
      
      // draw shapes on scaled Graphics2D object
      super.drawShapes( g2D );
   }
   
   // set scale factors for view
   public void setScaleFactors( double scaleX, double scaleY ) 
   {
      // set scale factors
      scaleFactorX = scaleX;
      scaleFactorY = scaleY;
      
      // create AffineTransform with given scale factors
      scaleTransform = AffineTransform.getScaleInstance( 
         scaleFactorX, scaleFactorY );
   }
   
   // get preferred size for this component
   public Dimension getPreferredSize()
   { 
      // default size is 320 x 240; scale using scaleFactors
      return new Dimension( ( int ) ( 320 * scaleFactorX ), 
         ( int ) ( 240 * scaleFactorY ) ); 
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
