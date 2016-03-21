// ColorFilter.java
// ColorFilter is an Java2DImageFilter that alters the 
// RGB color bands in a BufferedImage.
package com.deitel.advjhtp1.java2d;

// Java core packages
import java.awt.image.*;

public class ColorFilter implements Java2DImageFilter {
   
   // apply color-change filter to BufferedImage
   public BufferedImage processImage( BufferedImage image ) 
   {
      // create array used to change RGB color bands
      float[][] colorMatrix = {
         { 1f, 0f, 0f },
         { 0.5f, 1.0f, 0.5f },
         { 0.2f, 0.4f, 0.6f } };
     
     // create filter to change colors
     BandCombineOp changeColors = 
        new BandCombineOp( colorMatrix, null );
     
     // create source and display Rasters
     Raster sourceRaster = image.getRaster();  
     
     WritableRaster displayRaster = 
        sourceRaster.createCompatibleWritableRaster();
     
     // filter Rasters with changeColors filter
     changeColors.filter( sourceRaster, displayRaster );
     
     // create new BufferedImage from display Raster
     return new BufferedImage( image.getColorModel(), 
        displayRaster, true, null );
  
   } // end method processImage
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