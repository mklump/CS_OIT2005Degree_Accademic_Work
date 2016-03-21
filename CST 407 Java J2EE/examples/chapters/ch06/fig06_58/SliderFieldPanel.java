// Fig. 6.41: SliderFieldPanel.java
// SliderFieldPanel provides a slider to adjust the animation 
// speed of LogoAnimator2.
package com.deitel.advjhtp1.beans;

// Java core packages
import java.io.*;
import java.awt.*;
import java.awt.event.*;
import java.beans.*;

// Java extension packages
import javax.swing.*;
import javax.swing.event.*;

public class SliderFieldPanel extends JPanel 
   implements Serializable {

   private JSlider slider;
   private JTextField field;
   private Box boxContainer;
   private int currentValue;
   
   // object to support bound property changes
   private PropertyChangeSupport changeSupport;

   // SliderFieldPanel constructor
   public SliderFieldPanel()
   {
      // create PropertyChangeSupport for bound properties
      changeSupport = new PropertyChangeSupport( this );

      // initialize slider and text field
      slider = new JSlider( 
         SwingConstants.HORIZONTAL, 1, 100, 1 );
      field = new JTextField( 
         String.valueOf( slider.getValue() ), 5 );

      // set box layout and add slider and text field
      boxContainer = new Box( BoxLayout.X_AXIS );
      boxContainer.add( slider );
      boxContainer.add( Box.createHorizontalStrut( 5 ) );
      boxContainer.add( field );

      setLayout( new BorderLayout() );
      add( boxContainer );

      // add ChangeListener for JSlider
      slider.addChangeListener(
      
         new ChangeListener() {
            
            // handle state change for JSlider
            public void stateChanged( ChangeEvent changeEvent )
            {
               setCurrentValue( slider.getValue() );
            }
            
         } // end anonymous inner class
         
      ); // end call to addChangeListener     

      // add ActionListener for JTextField
      field.addActionListener(
      
         new ActionListener() {
            
            // handle action for JTextField
            public void actionPerformed( ActionEvent 
               actionEvent )
            {
               setCurrentValue(
                  Integer.parseInt( field.getText() ) );
            }
            
         } // end anonymous inner class
         
      ); // end call to addActionListener
      
   } // end SliderFieldPanel constructor

   // add PropertyChangeListener
   public void addPropertyChangeListener( 
      PropertyChangeListener listener ) 
   {
      changeSupport.addPropertyChangeListener( listener );
   }

   //  remove PropertyChangeListener
   public void removePropertyChangeListener( 
      PropertyChangeListener listener ) 
   {
      changeSupport.removePropertyChangeListener( listener );
   }

   // set minimumValue property
   public void setMinimumValue( int minimum ) 
   { 
      slider.setMinimum( minimum ); 
      
      if ( slider.getValue() < slider.getMinimum() ) {         
         slider.setValue( slider.getMinimum() );
         field.setText( String.valueOf( slider.getValue() ) );
      }
   }

   // get minimumValue property
   public int getMinimumValue() 
   { 
      return slider.getMinimum(); 
   }

   // set maximumValue property
   public void setMaximumValue( int maximum )
   {
      slider.setMaximum( maximum ); 
      
      if ( slider.getValue() > slider.getMaximum() ) {
         slider.setValue( slider.getMaximum() );
         field.setText( String.valueOf( slider.getValue() ) );
      }
   }

   // get maximumValue property
   public int getMaximumValue() 
   { 
      return slider.getMaximum(); 
   }

   // set currentValue property
   public void setCurrentValue( int current )
      throws IllegalArgumentException
   { 
      if ( current < 0 ) 
         throw new IllegalArgumentException();

      int oldValue = currentValue;
      
      // set currentValue property
      currentValue = current;
      
      // change slider and textfield values
      slider.setValue( currentValue );
      field.setText( String.valueOf( currentValue ) );
      
      // fire PropertyChange
      changeSupport.firePropertyChange( 
         "currentValue", new Integer( oldValue ), 
         new Integer( currentValue ) );
   }   

   // get currentValue property
   public int getCurrentValue() 
   {
      return slider.getValue(); 
   }

   // set fieldWidth property
   public void setFieldWidth( int columns ) 
   { 
      field.setColumns( columns );
      boxContainer.validate();
   }

   // get fieldWidth property
   public int getFieldWidth() 
   { 
      return field.getColumns(); 
   }

   // get minimum panel size
   public Dimension getMinimumSize()
   {
      return boxContainer.getMinimumSize();
   }

   // get preferred panel size
   public Dimension getPreferredSize()
   {
      return boxContainer.getPreferredSize();
   }

}  // end class SliderFieldPanel

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