// InvertFilter.java
// InvertFilter is an ImageFilter that inverts a 
// BufferedImage's RGB color values.
package com.deitel.advjhtp1.java2d;

// Java core packages
import java.awt.image.*;

public class InvertFilter implements Java2DImageFilter {
   
   // apply color inversion filter to BufferedImage
   public BufferedImage processImage( BufferedImage image ) 
   {
      // create 256 color array and invert colors
      byte[] invertArray = new byte[ 256 ];
      
      for ( int counter = 0; counter < 256; counter++ )
         invertArray[ counter ] = ( byte )( 255 - counter );   
      
      // create filter to invert colors
      BufferedImageOp invertFilter = new LookupOp(
         new ByteLookupTable( 0, invertArray ), null );
      
      // apply filter to displayImage
      return invertFilter.filter( image, null );
      
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
