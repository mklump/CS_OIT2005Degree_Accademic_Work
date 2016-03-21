// ImagePanel.java
// ImagePanel contains an image for display.  The image is 
// converted to a BufferedImage for filtering purposes.
package com.deitel.advjhtp1.java2d;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.awt.image.*;
import java.net.*;

 // Java extension packages
import javax.swing.*;
import javax.swing.event.*;

public class ImagePanel extends JPanel {
   
   private BufferedImage displayImage; // filtered image
   private BufferedImage originalImage; // original image copy
   private Image image; // image to load
   
   // ImagePanel constructor
   public ImagePanel( URL imageURL )
   {
      image = 
         Toolkit.getDefaultToolkit().createImage( imageURL );          
      
      // create MediaTracker for image
      MediaTracker mediaTracker = new MediaTracker( this );
      mediaTracker.addImage( image, 0 );
      
      // wait for Image to load
      try {
         mediaTracker.waitForAll();
      } 
      
      // exit program on error
      catch( InterruptedException interruptedException ) {
         interruptedException.printStackTrace();
      }
      
      // create BufferedImage from Image 
      originalImage = new BufferedImage( image.getWidth( null ), 
         image.getHeight( null ), BufferedImage.TYPE_INT_RGB );
      
      //displayImage = new BufferedImage( image.getWidth( null ), 
      //   image.getHeight( null ), BufferedImage.TYPE_INT_RGB );
      
      displayImage = originalImage; 
      
      // draw Image on Graphics2D object
      Graphics2D graphics = displayImage.createGraphics();
      graphics.drawImage( image, null, null );
   
   } // end ImagePanel constructor 
   
   // apply Java2DImageFilter to Image   
   public void applyFilter( Java2DImageFilter filter )
   {
      // process Image using ImageFilter
      displayImage = filter.processImage( displayImage );
      repaint();
   }   
   
   // set Image to originalImage 
   public void displayOriginalImage() 
   {
      displayImage = new BufferedImage( image.getWidth( null ), 
         image.getHeight( null ), BufferedImage.TYPE_INT_RGB );
      
      Graphics2D graphics = displayImage.createGraphics();
      graphics.drawImage( originalImage, null, null );
      repaint();
   }
  
   // draw ImagePanel 
   public void paintComponent( Graphics g )
   {
      super.paintComponent( g );
      Graphics2D graphics = ( Graphics2D ) g;
      graphics.drawImage( displayImage, 0, 0, null );
   }

   // get preferred ImagePanel size
   public Dimension getPreferredSize()
   {
      return new Dimension( displayImage.getWidth(), 
         displayImage.getHeight() );
   }
   
   // get minimum ImagePanel size
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
