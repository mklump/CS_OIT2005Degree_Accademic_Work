// ZoomDialog.java
// ZoomDialog is a JDialog subclass that shows a zoomed view
// of a DrawingModel.
package com.deitel.advjhtp1.drawing;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;

// Deitel packages
import com.deitel.advjhtp1.drawing.model.*;
import com.deitel.advjhtp1.drawing.view.*;

public class ZoomDialog extends JDialog {
   
   private ZoomDrawingView drawingView;
   private double zoomFactor = 0.5;

   // ZoomDialog constructor
   public ZoomDialog( DrawingModel model, String title ) 
   {
      // set ZoomDialog title
      setTitle( title );

      // create ZoomDrawingView for using default zoomFactor
      drawingView = new ZoomDrawingView( model, zoomFactor );
      
      // add ZoomDrawingView to ContentPane
      getContentPane().add( drawingView );      

      // size ZoomDialog to fit ZoomDrawingView's preferred size
      pack();
      
      // make ZoomDialog visible
      setVisible( true );        
   }   
   
   // set JDialog title
   public void setTitle( String title )
   {
      super.setTitle( title + " [Zoom]" );
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
