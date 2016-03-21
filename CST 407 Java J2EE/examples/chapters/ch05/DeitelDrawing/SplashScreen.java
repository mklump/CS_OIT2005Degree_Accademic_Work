// SplashScreen.java
// SplashScreen implements static method showSplash for 
// displaying a splash screen.
package com.deitel.advjhtp1.drawing;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;

public class SplashScreen {
   
   private JWindow window;
   private Timer timer;
   
   // SplashScreen constructor
   public SplashScreen( Component component ) 
   {
      // create new JWindow for splash screen
      window = new JWindow();
      
      // add provided component to JWindow
      window.getContentPane().add( component );
      
      // allow user to dismiss SplashScreen by clicking mouse
      window.addMouseListener( 
      
         new MouseAdapter() {
            
            // when user presses mouse in SplashScreen,
            // hide and dispose JWindow
            public void mousePressed( MouseEvent event ) {
               window.setVisible( false );
               window.dispose();
            }
         }
         
      ); // end call to addMouseListener
      
      // size JWindow for given Component
      window.pack();
      
      // get user's screen size
      Dimension screenDimension = 
         Toolkit.getDefaultToolkit().getScreenSize();
      
      // calculate x and y coordinates to center splash screen 
      int width = window.getSize().width;
      int height = window.getSize().height;
      int x = ( screenDimension.width - width ) / 2 ;
      int y = ( screenDimension.height - height ) / 2 ;
      
      // set the bounds of the window to center it on screen
      window.setBounds( x, y, width, height ); 
      
   } // end SplashScreen constructor   
   
   // show splash screen for given delay
   public void showSplash( int delay ) {
      
      // display the window
      window.setVisible( true );
      
      // crate and start a new Timer to remove SplashScreen
      // after specified delay
      timer = new Timer( delay, 
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event )
            {
               // hide and dispose of window
               window.setVisible( false );
               window.dispose();
               timer.stop();
            }
         } 
      );
      
      timer.start();
      
   } // end method showSplash
   
   // return true if SplashScreen window is visible
   public boolean isVisible()
   {
      return window.isVisible();
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
