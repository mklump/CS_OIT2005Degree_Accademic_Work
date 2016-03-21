// ControlPanel1.java
// ControlPanel1 is a JPanel that contains Swing controls 
// for manipulating a Java3DWorld1.
package com.deitel.advjhtp1.java3dgame;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;
import javax.swing.border.*;
import javax.swing.event.*;

public class ControlPanel1 extends JPanel {
   
   private static final int CONTAINER_WIDTH = 250;
   private static final int CONTAINER_HEIGHT = 150;
   
   private static final int NUMBER_OF_SHAPES = 20;
   
   // JSliders control lighting color 
   private JSlider numberSlider;
   private Java3DWorld1 java3DWorld1;
   
   // ControlPanel constructor
   public ControlPanel1( Java3DWorld1 tempJ3DWorld )
   {
      java3DWorld1 = tempJ3DWorld;
       
      // assemble lighting color control panel 
      JPanel colorPanel = new JPanel(  
         new FlowLayout( FlowLayout.LEFT, 15, 15 ) );
            
      TitledBorder colorBorder = 
         new TitledBorder( "How Many Shapes?" );
      
      colorBorder.setTitleJustification( TitledBorder.CENTER );
      colorPanel.setBorder( colorBorder ); 
 
      JLabel numberLabel = new JLabel( "Number of Shapes" );
     
      // create JSlider for adjusting number of flying shapes
      numberSlider = new JSlider( 
         SwingConstants.HORIZONTAL, 0, NUMBER_OF_SHAPES, 1 );
      
      numberSlider.setMajorTickSpacing( 5 );
      numberSlider.setPaintTicks( true );
      numberSlider.setPaintTrack( true );
      numberSlider.setPaintLabels( true );
      
      // create ChangeListener for JSliders
      ChangeListener slideListener = new ChangeListener() {
         
         // invoked when slider has been accessed
         public void stateChanged( ChangeEvent event )
         {
           java3DWorld1.switchScene( numberSlider.getValue(), 
              NUMBER_OF_SHAPES );
         }
         
      }; // end anonymous inner class
      
      // add listener to sliders
      numberSlider.addChangeListener( slideListener );

      // add lighting color control components to colorPanel
      colorPanel.add( numberLabel );
      colorPanel.add( numberSlider );
      add( colorPanel );

      // set GridLayout
      setLayout( new GridLayout( 2, 1, 0, 20 ) );
       
              
   } // end ControlPanel1 constructor method
       
    // return preferred dimensions of container
    public Dimension getPreferredSize()
    {
       return new Dimension( CONTAINER_WIDTH, CONTAINER_HEIGHT );
    } 
    
    // return minimum size of container
    public Dimension getMinimumSize()
    {
       return getPreferredSize();
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


