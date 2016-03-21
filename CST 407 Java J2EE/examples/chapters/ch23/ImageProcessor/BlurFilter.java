// BlurFilter.java
// Blurfilter is an Java2DImageFilter that blurs a BufferedImage.
package com.deitel.advjhtp1.java2d;

// Java core packages
import java.awt.image.*;

public class BlurFilter implements Java2DImageFilter {
   
   // apply blurring filter to BufferedImage
   public BufferedImage processImage( BufferedImage image ) 
   {
      // array used to blur BufferedImage
      float[] blurMatrix = {
         1.0f / 9.0f, 1.0f / 9.0f, 1.0f / 9.0f,
         1.0f / 9.0f, 1.0f / 9.0f, 1.0f / 9.0f,
         1.0f / 9.0f, 1.0f / 9.0f, 1.0f / 9.0f };
  
     // create ConvolveOp for blurring BufferedImage
     BufferedImageOp blurFilter = new ConvolveOp( 
        new Kernel( 3, 3, blurMatrix ), ConvolveOp.EDGE_NO_OP, null );
     
     // apply blurFilter to BufferedImage
     return blurFilter.filter( image, null );
     
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