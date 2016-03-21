// Java2DExample.java
// Java2DExample is an application that applies filters to an 
// image using Java 2D.
package com.deitel.advjhtp1.java2d;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.awt.image.*;
import java.lang.*;
import java.net.*;

// Java extension packages
import javax.swing.*;
import javax.swing.event.*;

public class Java2DExample extends JFrame {
   
   private JMenu filterMenu; 
   private ImagePanel imagePanel; 
    
   // image filters
   private Java2DImageFilter invertFilter;
   private Java2DImageFilter sharpenFilter;
   private Java2DImageFilter blurFilter;
   private Java2DImageFilter colorFilter;
   
   // initialize JMenuItems
   public Java2DExample()
   {
      super( "Java 2D Image Processing Demo" );
      
      // create Java2DImageFilter
      blurFilter = new BlurFilter();
      sharpenFilter = new SharpenFilter();
      invertFilter = new InvertFilter();
      colorFilter = new ColorFilter();
      
      // initialize ImagePanel
      imagePanel = new ImagePanel( 
         Java2DExample.class.getResource( "images/ajhtp.png" ) );
      
      // create JMenuBar 
      JMenuBar menuBar = new JMenuBar();   
      setJMenuBar( menuBar );   
          
      // create JMenu
      filterMenu = new JMenu( "Image Filters" );
      filterMenu.setMnemonic( 'I' );
    
      // create JMenuItem for displaying orginal Image
      JMenuItem originalMenuItem = 
         new JMenuItem( "Display Original" );
      originalMenuItem.setMnemonic( 'O' );
      
      originalMenuItem.addActionListener(
         new ActionListener() {
            
            // show original Image
            public void actionPerformed( ActionEvent action )
            {
               imagePanel.displayOriginalImage();
            }
            
         } // end anonymous inner class
      );
      
      // create JMenuItems for Java2DImageFilter
      JMenuItem invertMenuItem = createMenuItem( 
         "Invert", 'I', invertFilter );
      JMenuItem sharpenMenuItem = createMenuItem( 
         "Sharpen", 'S', sharpenFilter );
      JMenuItem blurMenuItem = createMenuItem( 
         "Blur", 'B', blurFilter );
      JMenuItem changeColorsMenuItem = createMenuItem( 
         "Change Colors", 'C', colorFilter );
      
      // add JMenuItems to JMenu
      filterMenu.add( originalMenuItem );
      filterMenu.add( invertMenuItem );
      filterMenu.add( sharpenMenuItem );
      filterMenu.add( blurMenuItem );
      filterMenu.add( changeColorsMenuItem );
      
      // add JMenu to JMenuBar
      menuBar.add( filterMenu );
              
      getContentPane().add( imagePanel, BorderLayout.CENTER );
     
   } // end Java2DExample constructor
   
   // create JMenuItem and ActionListener for given filter
   public JMenuItem createMenuItem( String menuItemName, 
      char mnemonic, final Java2DImageFilter filter )
   {
      // create JMenuItem
      JMenuItem menuItem = new JMenuItem( menuItemName );
      
      // set Mnemonic 
      menuItem.setMnemonic( mnemonic );

      menuItem.addActionListener(
         new ActionListener() {

            // apply Java2DImageFilter when MenuItem accessed
            public void actionPerformed( ActionEvent action )
            {
               imagePanel.applyFilter( filter );
            }
            
         } // end anonymous inner class
      );
      
      return menuItem;
      
   } // end method createMenuItem
  
   // start program
   public static void main( String args[] )
   {
      Java2DExample application = new Java2DExample();
      application.setDefaultCloseOperation( EXIT_ON_CLOSE );
      application.pack();
      application.setVisible( true );
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
