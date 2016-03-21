// Fig. 6.48 ColorEvent.java
// ColorEvent is an EventObject subclass that indicates a 
// change in color.
package com.deitel.advjhtp1.beans;

// Java core packages
import java.util.*;
import java.awt.Color;

public class ColorEvent extends EventObject {

   private Color color;

   // constructor sets color property
   public ColorEvent( Object source, Color color )
   {
      super( source );
      setColor( color );
   }
   
   // set method for color property
   public void setColor( Color newColor )
   {
      color = newColor;
   }
   
   // get method for color property
   public Color getColor()
   {
      return color;
   }

}  // end class ColorEvent

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
