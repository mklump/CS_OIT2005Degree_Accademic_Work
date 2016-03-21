// Fig. 6.62 SliderFieldPanelCustomizer.java
// SliderFieldPanelCustomizer is the Customizer class for 
// SliderFieldPanel.
package com.deitel.advjhtp1.beans;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.beans.*;
import java.util.*;

// Java extension packages
import javax.swing.*;

public class SliderFieldPanelCustomizer extends JPanel 
   implements Customizer {

   private JComboBox maximumCombo, minimumCombo;
   private JLabel minimumLabel, maximumLabel;
   protected SliderFieldPanel slider;
   private PropertyChangeSupport changeSupport;
   private static final String[] VALUES = { "50", "100", 
      "150", "200", "250", "300", "350", "400", "450", "500" };
   
   // initialize GUI components
   public SliderFieldPanelCustomizer()
   {
      // create PropertyChangeSupport to handle PropertyChange
      changeSupport = new PropertyChangeSupport( this ); 

      // labels for maximum and minimum properties
      minimumLabel = new JLabel( "Minimum Slider Value:" );
      maximumLabel = new JLabel( "Maximum Slider Value:" );
      
      // combo boxes adjust maximum and minimum properties
      minimumCombo = new JComboBox( VALUES );
      minimumCombo.setSelectedIndex( 0 );
      maximumCombo = new JComboBox( VALUES );
      maximumCombo.setSelectedIndex( 9 );
      
      // add ActionListener to minimumValue combo box
      minimumCombo.addActionListener(
      
         new ActionListener() {
            
            // handle action of minimum combo box
            public void actionPerformed( ActionEvent event ) 
            { 
               setMinimum( minimumCombo.getSelectedIndex() );
            }
            
         } // end anonymous inner class 
      
      ); // end addActionListener
      
      // add ActionListener to maximumValue combo box
      maximumCombo.addActionListener(
      
         new ActionListener() {
            
            // handle action of maximum combo box
            public void actionPerformed( ActionEvent event )
            {
               setMaximum( maximumCombo.getSelectedIndex() );
            }
            
         } // end anonymous inner class
         
      ); // end addActionListener
      
      add( minimumLabel );
      add( minimumCombo );
      add( maximumLabel );
      add( maximumCombo );
   }

   // set the customized object
   public void setObject( Object bean )
   {
      slider = ( SliderFieldPanel ) bean;
   }
   
   // add PropertyChangeListener with PropertyChangeSupport
   public void addPropertyChangeListener( 
      PropertyChangeListener listener )
   {
      changeSupport.addPropertyChangeListener( listener );
   }
   
   // remove PropertyChangeListener with PropertyChangeSupport
   public void removePropertyChangeListener( 
      PropertyChangeListener listener )
   {
      changeSupport.removePropertyChangeListener( listener );
   }
   
   // set minimumValue property
   public void setMinimum( int index )
   {
      int oldValue = slider.getMinimumValue();
      int newValue = Integer.parseInt( VALUES[ index ] );

      slider.setMinimumValue( newValue );
      changeSupport.firePropertyChange( "minimumValue", 
         new Integer( oldValue ), new Integer( newValue ) );
   }
   
   // set maximumValue property
   public void setMaximum( int index )
   {
      int oldValue = slider.getMaximumValue();
      int newValue = Integer.parseInt( VALUES[ index ] );

      slider.setMaximumValue( newValue );
      changeSupport.firePropertyChange( "maximumValue", 
         new Integer( oldValue ), new Integer( newValue ) );
   }

}  // end class SliderFieldPanelCustomizer

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
