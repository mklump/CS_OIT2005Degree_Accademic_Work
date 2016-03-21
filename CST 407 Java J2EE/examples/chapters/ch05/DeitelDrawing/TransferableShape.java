// TransferableShape.java
// TransferableShape is a Transferable object that contains a 
// MyShape and the point from which the user dragged that MyShape.
package com.deitel.advjhtp1.drawing.controller;

// Java core packages
import java.util.*;
import java.io.*;
import java.awt.Point;
import java.awt.dnd.*;
import java.awt.datatransfer.*;

// Deitel packages
import com.deitel.advjhtp1.drawing.model.*;
import com.deitel.advjhtp1.drawing.model.shapes.*;

public class TransferableShape implements Transferable {
   
   // the MyShape to transfer from Point origin
   private MyShape shape;   
   private Point origin;
      
   // MIME type that identifies dragged MyShapes
   public static final String MIME_TYPE =
      "application/x-deitel-shape";
      
   // DataFlavors that MyShape supports for drag and drop
   private static final DataFlavor[] flavors = new DataFlavor[] { 
      new DataFlavor( MIME_TYPE, "Shape" ) };
      
   // TransferableShape constructor
   public TransferableShape( MyShape myShape, Point originPoint ) 
   {
      shape = myShape;      
      origin = originPoint;
      
   } // end TransferableShape constructor  
   
   // get Point from which user dragged MyShape
   public Point getOrigin()
   {
      return origin;
   }
   
   // get MyShape
   public MyShape getShape()
   {
      return shape;
   }
   
   // get data flavors MyShape supports
   public DataFlavor[] getTransferDataFlavors() 
   { 
      return flavors; 
   }

   // determine if MyShape supports given data flavor
   public boolean isDataFlavorSupported( DataFlavor flavor )
   {
      // search for given DataFlavor in flavors array
      for ( int i = 0; i < flavors.length; i++)
         
         if ( flavor.equals( flavors[ i ] ) )
            return true;

      return false;
   }

   // get data to be transferred for given DataFlavor
   public Object getTransferData( DataFlavor flavor ) 
      throws UnsupportedFlavorException, IOException
   {
      if ( !isDataFlavorSupported( flavor ) )
         throw new UnsupportedFlavorException( flavor );

      // return TransferableShape object for transfer
      return this;
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
