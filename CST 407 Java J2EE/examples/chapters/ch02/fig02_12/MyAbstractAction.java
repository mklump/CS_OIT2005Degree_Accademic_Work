// MyAbstractAction.java
// MyAbstractAction is an AbstractAction subclass that provides
// set methods for Action properties (e.g., name, icon, etc.).
package com.deitel.advjhtp1.gui.actions;

// Java core packages
import java.awt.event.*;

// Java extension packages
import javax.swing.*;

public abstract class MyAbstractAction extends AbstractAction {
   
   // no-argument constructor
   public MyAbstractAction() {}
   
   // construct MyAbstractAction with given name, icon
   // description and mnemonic key
   public MyAbstractAction( String name, Icon icon, 
      String description, Integer mnemonic )
   {
      // initialize properties
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