// DrawingModel.java
// DrawingModel is the model for a DeitelDrawing painting. It 
// provides methods for adding and removing shapes from a 
// drawing.
package com.deitel.advjhtp1.drawing.model;

// Java core packages
import java.util.*;

// Deitel packages
import com.deitel.advjhtp1.drawing.model.shapes.*;

public class DrawingModel extends Observable {
   
   // shapes contained in model
   private Collection shapes;

   // no-argument constructor
   public DrawingModel() 
   { 
      shapes = new ArrayList(); 
   }

   // add shape to model
   public void addShape( MyShape shape ) 
   {
      // add new shape to list of shapes
      shapes.add( shape );
      
      // send model changed notification
      fireModelChanged();
   }
   
   // remove shape from model
   public void removeShape( MyShape shape ) 
   {
      // remove shape from list
      shapes.remove( shape );
      
      // send model changed notification
      fireModelChanged();
   }
   
   // get Collection of shapes in model
   public Collection getShapes()
   { 
      return Collections.unmodifiableCollection( shapes ); 
   }
     
   // set Collection of shapes in model
   public void setShapes( Collection newShapes ) 
   { 
      // copy Collection into new ArrayList
      shapes = new ArrayList( newShapes ); 
      
      // send model changed notification
      fireModelChanged();
   }

   // empty the current ArrayList of shapes
   public void clear() 
   {
      shapes = new ArrayList();
      
      // send model changed notification
      fireModelChanged();
   }
   
   // send model changed notification
   private void fireModelChanged()
   {
      // set model changed flag
      setChanged();
      
      // notify Observers that model changed
      notifyObservers();
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
