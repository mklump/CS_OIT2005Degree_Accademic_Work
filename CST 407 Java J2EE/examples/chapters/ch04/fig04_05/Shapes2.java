// Shapes2.java
// Shapes2 demonstrates a general path.

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.awt.geom.*;

// Java extension packages
import javax.swing.*;

public class Shapes2 extends JFrame {

   // set window's title bar String and background color

   public Shapes2()
   {
      super( "Drawing 2D Shapes" );

      getContentPane().setBackground( Color.gray );
   } 

   // draw general paths
   public void paint( Graphics g )
   {
      // call superclass' paint method
      super.paint( g );

      int xPoints[] = 
         { 55, 67, 109, 73, 83, 55, 27, 37, 1, 43 };
      int yPoints[] = 
         { 0, 36, 36, 54, 96, 72, 96, 54, 36, 36 };

      Graphics2D graphics2D = ( Graphics2D ) g;

      // create a star from a series of points
      GeneralPath star = new GeneralPath();

      // set the initial coordinate of the General Path
      star.moveTo( xPoints[ 0 ], yPoints[ 0 ] );

      // create the star--this does not draw the star
      for ( int count = 1; count < xPoints.length; count++ )
         star.lineTo( xPoints[ count ], yPoints[ count ] );

      // close the shape
      star.closePath();

      // translate the origin to (200, 200)
      graphics2D.translate( 200, 200 );

      // rotate around origin and draw stars in random colors
      for ( int count = 1; count <= 20; count++ ) {

         // rotate coordinate system
         graphics2D.rotate( Math.PI / 10.0 );

         // set random drawing color
         graphics2D.setColor( new Color( 
            ( int ) ( Math.random() * 256 ),
            ( int ) ( Math.random() * 256 ),
            ( int ) ( Math.random() * 256 ) ) );

         // draw filled star
         graphics2D.fill( star );   
      }

   }  // end method paint
 
   // execute application
   public static void main( String args[] )
   {
      Shapes2 application = new Shapes2();
      application.setDefaultCloseOperation(
         JFrame.EXIT_ON_CLOSE );
      application.setSize( 400, 400 );
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

