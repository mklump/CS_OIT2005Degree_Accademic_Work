// Java3DExample.java
// Java3DExample is an application that demonstrates Java 3D 
// and provides an interface for a user to control the 
// transformation, lighting color, and texture of a 3D scene. 
package com.deitel.advjhtp1.java3dgame;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;
import javax.swing.event.*;

public class Java3DExample extends JFrame {
   
   private Java3DWorld1 java3DWorld;  // 3D scene panel 
   private JPanel controlPanel;  // 3D scene control panel   
   
   // initialize Java3DWorld and ControlPanel
   public Java3DExample()
   {
      super( "Java 3D Graphics Demo" );

      java3DWorld = new Java3DWorld1( "images/ajhtp.png" );
      controlPanel = new ControlPanel1( java3DWorld );
      
      // add Components to JFrame
      getContentPane().add( java3DWorld, BorderLayout.CENTER );
      getContentPane().add( controlPanel, BorderLayout.EAST );       
      
   } // end Java3DExample constructor
       
   // start program
   public static void main( String args[] )
   {
      Java3DExample application = new Java3DExample();
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



