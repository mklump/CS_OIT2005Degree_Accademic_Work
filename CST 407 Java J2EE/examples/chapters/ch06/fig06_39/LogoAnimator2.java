// Fig. 6.39: LogoAnimator2.java
// LogoAnimator2 extends LogoAnimator to include 
// animationDelay property and implements ColorListener
package com.deitel.advjhtp1.beans;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;

public class LogoAnimator2 extends LogoAnimator {

   // set animationDelay property
   public void setAnimationDelay( int delay )
   {
      animationTimer.setDelay( delay );
   }

   // get animationDelay property
   public int getAnimationDelay()
   {
      return animationTimer.getDelay();
   }
   
   // launch LogoAnimator in JFrame for testing
   public static void main( String args[] )
   {
      // create new LogoAnimator2
      LogoAnimator2 animation = new LogoAnimator2();

      // create new JFrame and add LogoAnimator2 to it
      JFrame application = new JFrame( "Animator test" );
      application.getContentPane().add( animation, 
         BorderLayout.CENTER );

      application.setDefaultCloseOperation( 
         JFrame.EXIT_ON_CLOSE );
      application.pack();
      application.setVisible( true );
   }

}  // end class LogoAnimator2

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
