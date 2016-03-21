// AbstractDrawingAction.java
// AbstractDrawingAction is an Action implementation that
// provides set and get methods for common Action properties.
package com.deitel.advjhtp1.drawing;

// Java core packages
import java.awt.event.*;

// Java extension packages
import javax.swing.*;

public abstract class AbstractDrawingAction 
   extends AbstractAction {
   
   // construct AbstractDrawingAction with given name, icon
   // description and mnemonic key
   public AbstractDrawingAction( String name, Icon icon, 
      String description, Integer mnemonic)
   {
      setName( name );
      setSmallIcon( icon );
      setShortDescription( description );
      setMnemonic( mnemonic );
   }
   
   // set Action name
   public void setName( String name )
   {
      putValue( Action.NAME, name );
   }
   
   // set Action Icon
   public void setSmallIcon( Icon icon )
   {
      putValue( Action.SMALL_ICON, icon );
   }
   
   // set Action short description
   public void setShortDescription( String description )
   {
      putValue( Action.SHORT_DESCRIPTION, description );
   }
   
   // set Action mnemonic key
   public void setMnemonic( Integer mnemonic ) 
   {
      putValue( Action.MNEMONIC_KEY, mnemonic );
   }
   
   // abstract actionPerformed method to be implemented
   // by concrete subclasses
   public abstract void actionPerformed( ActionEvent event );
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
