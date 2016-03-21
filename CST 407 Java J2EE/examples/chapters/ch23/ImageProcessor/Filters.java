// Filters.java
// Applies blurring, sharpening, converting, modifying on images.
package com.deitel.advjhtp1.javaspace.ImageProcessor;

// Java core packages
import java.awt.*;
import java.awt.image.*;

// Java standard extensions
import javax.swing.*;

// Deitel packages
import com.deitel.advjhtp1.java2d.*;

public class Filters {
   
   Java2DImageFilter blurFilter;
   Java2DImageFilter sharpenFilter;
   Java2DImageFilter invertFilter;
   Java2DImageFilter colorFilter;
   
   BufferedImage bufferedImage;
   
   // constructor method initializes ImageFilters and pulls
   // BufferedImage out of the ImageIcon
   public Filters( ImageIcon icon ) 
   {
      blurFilter = new BlurFilter();
      sharpenFilter = new SharpenFilter();
      invertFilter = new InvertFilter();
      colorFilter = new ColorFilter();
      
      Image image = icon.getImage();
      bufferedImage = new BufferedImage( 
         image.getWidth( null ), image.getHeight( null ), 
         BufferedImage.TYPE_INT_RGB );
      
      Graphics2D gg = bufferedImage.createGraphics();
      gg.drawImage( image, null, null );
   }
   
   // apply BlurFilter to bufferedImage
   public void blurImage() 
   {
      bufferedImage = blurFilter.processImage( bufferedImage );
   }
   
   // apply SharpenFilter to bufferedImage
   public void sharpenImage()
   {
      bufferedImage = sharpenFilter.processImage( 
         bufferedImage );
   }
   
   // apply InvertFilter to bufferedImage
   public void invertImage() 
   {
      bufferedImage = invertFilter.processImage( 
         bufferedImage );
   }
   
   // apply ColorFilter to bufferedImage
   public void colorFilter()
   {
      bufferedImage = colorFilter.processImage( 
         bufferedImage );
   }
   
   // constructs and returns an ImageIcon from bufferedImage
   public ImageIcon getImageIcon()
   {
      return ( new ImageIcon( bufferedImage ));
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
