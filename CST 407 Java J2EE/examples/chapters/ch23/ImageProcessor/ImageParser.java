// Fig. 23.27: ImageParser.java
// This class partitions an image into smaller pieces.
package com.deitel.advjhtp1.javaspace.ImageProcessor;

// Java core packages
import java.awt.image.*;
import java.net.URL;
import java.awt.*;
import java.lang.*;
import java.util.Vector;
import java.awt.geom.*;

// Java standard extensions
import javax.swing.*;

public class ImageParser  {
   
   ImageIcon image;   

   public ImageParser() {}
     
   // pass parseImage an ImageIcon on the number of piece 
   // you want it split into the number of piece must be a 
   // perfect square - this can be extended later
   public Vector parseImage( 
      ImageIcon imageIcon, int numberPieces ) 
   {
      Vector vector = new Vector();
      double squareRoot = Math.sqrt( numberPieces );

      if ( Math.floor( squareRoot ) != ( squareRoot ) ) {
         System.out.println( "This is not a square number,"
            + " setting to default...");
         numberPieces = 4; 
      } 
      
      // get number of rows and columns
      int numberRows = ( int ) Math.sqrt( numberPieces );
      int numberColumns = ( int ) Math.sqrt( numberPieces );
      
      // retrieve Image from BufferedImage
      Image image = imageIcon.getImage();
      BufferedImage bufferedImage = new BufferedImage(
         image.getWidth( null ), image.getHeight( null ), 
         BufferedImage.TYPE_INT_RGB );
      
      Graphics2D g2D = bufferedImage.createGraphics();
      g2D.drawImage( image, null, null );
            
      // get size of each piece
      int width = bufferedImage.getWidth() / numberColumns;
      int height = bufferedImage.getHeight() / numberRows;
      
      // make each of images
      for ( int x = 0; x < numberRows; x++ ) {

         for ( int y = 0; y < numberColumns; y++ ) {
           vector.add( new ImageIcon( 
              bufferedImage.getSubimage(
                 x * width, y * height, width, height ) ) );
         }
      }

      return vector;

   } // end method parseImage

   // takes a vector of image icons (must be a square number)
   // of elements and returns an image icon with the images 
   // put back together again 
   public ImageIcon putTogether( Vector vector )
   {
      double size = vector.size();
      int numberRowColumn = ( int ) Math.sqrt( size );
    
      // step 1, get first Image
      Image tempImage = 
         ( ( ImageIcon ) vector.get( 0 ) ).getImage();
        
      // get total size of one piece
      int width = tempImage.getWidth( null );
      int height = tempImage.getHeight( null );
    
      // create buffered image
      BufferedImage totalPicture = new BufferedImage( 
         width * numberRowColumn, height * numberRowColumn, 
         BufferedImage.TYPE_INT_RGB );
    
      // create Graphics for BufferedImage
      Graphics2D graphics = totalPicture.createGraphics();
    
      // draw images from the vector into buffered image
      for ( int x = 0; x < numberRowColumn; x++ ) {

         for ( int y = 0; y < numberRowColumn; y++ ) {
            Image image = ( ( ImageIcon ) vector.get( 
               y + numberRowColumn * x ) ).getImage();
            graphics.drawImage( image, 
               AffineTransform.getTranslateInstance( 
                  x * width, y * height ), null );
         }
      }
    
      return new ImageIcon( totalPicture );

   } // end method putTogether
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