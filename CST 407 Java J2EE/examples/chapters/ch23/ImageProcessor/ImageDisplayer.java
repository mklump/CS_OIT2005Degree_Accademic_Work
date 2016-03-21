// Fig: ImageDisplayer.java
// This application is an user interface used
// to display an image.
package com.deitel.advjhtp1.javaspace.ImageProcessor;

// Java extension package
import javax.swing.*;

// Java core packages
import java.awt.*;
import java.awt.event.*;

public class ImageDisplayer extends JFrame {

   public ImageDisplayer( ImageIcon icon)
   {
      super( "ImageDisplay" );
      Container container = getContentPane();

      // define the center panel
      JPanel centerPanel = new JPanel();

      // add display label
      JLabel imageLabel = new JLabel( 
         icon, SwingConstants.LEFT );
      centerPanel.add( imageLabel );

      container.add( centerPanel, BorderLayout.CENTER );

   } // end ImageDisplayer constructor
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