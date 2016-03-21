// ControlPanel.java
// ControlPanel is a JPanel that contains Swing controls 
// for manipulating a Java3DWorld.
package com.deitel.advjhtp1.java3d;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;
import javax.swing.border.*;
import javax.swing.event.*;


public class ControlPanel extends JPanel {
   
   // JSliders control lighting color 
   private JSlider redSlider, greenSlider, blueSlider;
   
   // JCheckbox turns on texture mapping
   private JCheckBox textureCheckBox;
   
   // graphics display environment
   private Java3DWorld java3DWorld;
     
   // ControlPanel constructor
   public ControlPanel( Java3DWorld tempJ3DWorld )
   {
      java3DWorld = tempJ3DWorld;
                 
       // assemble instruction panel
      JPanel instructionPanel = new JPanel();
      
      TitledBorder titledBorder = 
         new TitledBorder( "Transformation Instructions" );
      
      titledBorder.setTitleJustification( TitledBorder.CENTER );
      instructionPanel.setBorder( titledBorder ); 
      
      JLabel rotationInstructions = 
         new JLabel( "Rotation - Left Mouse Button", 
         SwingConstants.CENTER );
        
      JLabel translationInstructions = 
         new JLabel( "Translation - Right Mouse Button", 
         SwingConstants.CENTER );       
      
      JLabel scalingInstructions = 
         new JLabel( "Scale - Alt + Left Mouse Button",
         SwingConstants.CENTER );
      
      // add instruction JLabels to JPanel
      instructionPanel.add( rotationInstructions );
      instructionPanel.add( translationInstructions );
      instructionPanel.add( scalingInstructions );
            
      // assemble texture mapping control panel
      JPanel texturePanel = new JPanel();
      
      TitledBorder textureBorder = 
         new TitledBorder( "Texture Controls" );
      
      textureBorder.setTitleJustification( TitledBorder.CENTER );
      texturePanel.setBorder( textureBorder ); 
      
      textureCheckBox = new JCheckBox( 
         "Apply Texture Map to Image" );
      
      texturePanel.add( textureCheckBox );
      
      // create ItemListener for JCheckBox
      textureCheckBox.addItemListener(
         new ItemListener() {
            
            // invoked when checkbox selected/deselected
            public void itemStateChanged( ItemEvent event )
            {
               if( event.getStateChange() == ItemEvent.SELECTED )
                  java3DWorld.updateTexture( true );
               else
                  java3DWorld.updateTexture( false );
            }
         } // end anonymous inner class
         
      ); 
            
      // create JPanel with instructionPanel and texturePanel
      JPanel topPanel = new JPanel( 
         new GridLayout( 2, 1, 0, 20 ) );
      
      topPanel.add( instructionPanel );
      topPanel.add( texturePanel );
      
      // assemble lighting color control panel 
      JPanel colorPanel = new JPanel(  
         new FlowLayout( FlowLayout.LEFT, 15, 15 ) );
            
      TitledBorder colorBorder = 
         new TitledBorder( "Direct Lighting Color Contols" );
      
      colorBorder.setTitleJustification( TitledBorder.CENTER );
      colorPanel.setBorder( colorBorder ); 
 
      JLabel redLabel = new JLabel( "R" );
      JLabel greenLabel = new JLabel( "G" );
      JLabel blueLabel = new JLabel( "B" );
      
      // create JSlider for adjusting red light component
      redSlider = new JSlider( 
         SwingConstants.HORIZONTAL, 0, 255, 25 );
      
      redSlider.setMajorTickSpacing( 25 );
      redSlider.setPaintTicks( true );
      
      // create JSlider for adjusting green light component      
      greenSlider = new JSlider( 
         SwingConstants.HORIZONTAL, 0, 255, 25 );
      
      greenSlider.setMajorTickSpacing( 25 );
      greenSlider.setPaintTicks( true );
      
      // create JSlider for adjusting blue light component
      blueSlider = new JSlider( 
         SwingConstants.HORIZONTAL, 0, 255, 25 );
      
      blueSlider.setMajorTickSpacing( 25 );
      blueSlider.setPaintTicks( true );
      
      // create ChangeListener for JSliders
      ChangeListener slideListener = new ChangeListener() {
         
         // invoked when slider has been accessed
         public void stateChanged( ChangeEvent event )
         {
            Color color = new Color( 
                  redSlider.getValue(), greenSlider.getValue(), 
                  blueSlider.getValue() );
             
            java3DWorld.changeColor( color );
         }
         
      }; // end anonymous inner class
      
      // add listener to sliders
      redSlider.addChangeListener( slideListener );
      greenSlider.addChangeListener( slideListener );
      blueSlider.addChangeListener( slideListener );
      
      // add lighting color control components to colorPanel
      colorPanel.add( redLabel );
      colorPanel.add( redSlider );
      colorPanel.add( greenLabel );
      colorPanel.add( greenSlider );
      colorPanel.add( blueLabel );
      colorPanel.add( blueSlider );
      
      // set Java3DWorld object default RGB slider values
      java3DWorld.changeColor(
         new Color( redSlider.getValue(), 
            greenSlider.getValue(), blueSlider.getValue() ) );
        
      // set GridLayout        
      setLayout( new GridLayout( 2, 1, 0, 20 ) );
       
      // add JPanels to ControlPanel
      add( topPanel );
      add( colorPanel );
              
   } // end ControlPanel constructor method
       
    // return preferred dimensions of container
    public Dimension getPreferredSize()
    {
       return new Dimension( 250, 150 );
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
