// Fig. 6.50 ColorSliderPanel.java
// ColorSliderPanel contains 3 SliderFieldPanels connected to
// indexed property redGreenBlue that adjusts the red, green
// and blue colors of an object.
package com.deitel.advjhtp1.beans;

// Java core packages
import java.io.*;
import java.awt.*;
import java.awt.event.*;
import java.beans.*;
import java.util.*;

// Java extension packages
import javax.swing.*;
import javax.swing.event.*;

public class ColorSliderPanel extends JPanel 
   implements Serializable {

   private JLabel redLabel, greenLabel, blueLabel;
   private SliderFieldPanel redSlider, greenSlider, blueSlider;
   private JPanel labelPanel, sliderPanel;
   private int[] redGreenBlue;
   public int RED_INDEX = 0;
   public int GREEN_INDEX = 1;
   public int BLUE_INDEX = 2;
   private Set listeners = new HashSet();

   // constructor for ColorSliderPanel
   public ColorSliderPanel()
   {
      // initialize redGreenBlue property
      redGreenBlue = new int[] { 0, 0, 0 };
      
      // initialize gui components for red slider
      redLabel = new JLabel( "Red:" ); 
      redSlider = new SliderFieldPanel();
      redSlider.setMinimumValue( 0 );
      redSlider.setMaximumValue( 255 );

      // initialize gui components for green slider
      greenLabel = new JLabel( "Green: " );
      greenSlider = new SliderFieldPanel();
      greenSlider.setMinimumValue( 0 );
      greenSlider.setMaximumValue( 255 );

      // initialize gui components for blue slider
      blueLabel = new JLabel( "Blue:" );
      blueSlider = new SliderFieldPanel();
      blueSlider.setMinimumValue( 0 );
      blueSlider.setMaximumValue( 255 );
      
      // set layout and add components
      setLayout( new BorderLayout() );
      
      labelPanel = new JPanel( new GridLayout( 3, 1 ) );
      labelPanel.add( redLabel );
      labelPanel.add( greenLabel );
      labelPanel.add( blueLabel );
      
      sliderPanel = new JPanel( new GridLayout( 3, 1 ) );
      sliderPanel.add( redSlider );
      sliderPanel.add( greenSlider );
      sliderPanel.add( blueSlider );
      
      add( labelPanel, BorderLayout.WEST );
      add( sliderPanel, BorderLayout.CENTER );
      
      // add PropertyChangeListener for redSlider
      redSlider.addPropertyChangeListener( 
      
         new PropertyChangeListener() {
            
            // handle propertyChange for redSlider
            public void propertyChange( PropertyChangeEvent 
               propertyChangeEvent )
            {
               setRedGreenBlue( RED_INDEX, 
                  redSlider.getCurrentValue() );
            }
         
         } // end anonymous inner class
         
      ); // end call to addPropertyChangeListener

      // add PropertyChangeListener for greenSlider
      greenSlider.addPropertyChangeListener(
      
         new PropertyChangeListener() {
            
            // handle propertyChange for greenSlider
            public void propertyChange( PropertyChangeEvent 
               propertyChangeEvent )
            {
               setRedGreenBlue( GREEN_INDEX, 
                  greenSlider.getCurrentValue() );
            }
            
         } // end anonymous inner class
         
      ); // end call to addPropertyChangeListener     

      // add PropertyChangeListener for blueSlider
      blueSlider.addPropertyChangeListener( 
      
         new PropertyChangeListener() {
            
            // handle propertyChange for blueSlider
            public void propertyChange( PropertyChangeEvent 
               propertyChangeEvent )
            {
               setRedGreenBlue( BLUE_INDEX, 
                  blueSlider.getCurrentValue() );
            }
            
         } // end anonymous inner class
         
      ); // end call to addPropertyChangeListener

   } // end ColorSliderPanel constructor
   
   // add ColorListener
   public void addColorListener( 
      ColorListener colorListener ) 
   {
      // listeners must be accessed atomically
      synchronized ( listeners ) {
         listeners.add( colorListener );
      }
   }
   
   // remove ColorListener
   public void removeColorListener( 
      ColorListener colorListener ) 
   {
      // listeners must be accessed by one thread only
      synchronized ( listeners ) {
         listeners.remove( colorListener );
      }
   }
   
   // fire ColorEvent
   public void fireColorChanged()
   {
      Iterator iterator;
      
      // listeners must be accessed atomically
      synchronized ( listeners ) {
         iterator = new HashSet( listeners ).iterator();
      }
      
      // create new Color with values of redGreenBlue
      // create new ColorEvent with color variable
      Color color = new Color( redGreenBlue[ RED_INDEX ], 
         redGreenBlue[ GREEN_INDEX ],
            redGreenBlue[ BLUE_INDEX ] );
      ColorEvent colorEvent = new ColorEvent( this, color );
      
      // notify all registered ColorListeners of ColorChange
      while ( iterator.hasNext() ) {
         ColorListener colorListener = ( ColorListener ) 
            iterator.next();
         colorListener.colorChanged( colorEvent );
      }
   }
   
   // get redGreenBlue property
   public int[] getRedGreenBlue()
   {
      return redGreenBlue;
   }

   // get redGreenBlue indexed property
   public int getRedGreenBlue( int index )
   {
      return redGreenBlue[ index ];
   }

   // set redGreenBlue property
   public void setRedGreenBlue( int[] array ) 
   {
      redGreenBlue = array;
   }
   
   // set redGreenBlue indexed property
   public void setRedGreenBlue( int index, int value ) 
   {
      redGreenBlue[ index ] = value;
      fireColorChanged();
   }

}  // end class ColorSliderPanel

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
