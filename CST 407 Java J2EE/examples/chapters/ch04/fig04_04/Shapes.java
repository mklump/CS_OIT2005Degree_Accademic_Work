// Shapes.java
// Shapes demonstrates some Java 2D shapes.
 
// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.awt.geom.*;
import java.awt.image.*;

// Java extension packages
import javax.swing.*;

public class Shapes extends JFrame {

   // constructor method
   public Shapes() 
   {
      super( "Drawing 2D shapes" );
   }

   // draw shapes using Java 2D API
   public void paint( Graphics g )
   {
      // call superclass' paint method
      super.paint( g );

      // get Graphics 2D by casting g to Graphics2D
      Graphics2D graphics2D = ( Graphics2D ) g;

      // draw 2D ellipse filled with blue-yellow gradient
      graphics2D.setPaint( new GradientPaint
         ( 5, 30, Color.blue, 35, 100, Color.yellow, true ) );  
      graphics2D.fill( new Ellipse2D.Double( 5, 30, 65, 100 ) );

      // draw 2D rectangle in red
      graphics2D.setPaint( Color.red );                  
      graphics2D.setStroke( new BasicStroke( 10.0f ) ); 
      graphics2D.draw( 
         new Rectangle2D.Double( 80, 30, 65, 100 ) );

      // draw 2D rounded rectangle with BufferedImage background
      BufferedImage bufferedImage = new BufferedImage(
         10, 10, BufferedImage.TYPE_INT_RGB );

      Graphics2D graphics = bufferedImage.createGraphics();   
      graphics.setColor( Color.yellow ); // draw in yellow
      graphics.fillRect( 0, 0, 10, 10 ); // draw filled rectangle
      graphics.setColor( Color.black );  // draw in black
      graphics.drawRect( 1, 1, 6, 6 );   // draw rectangle
      graphics.setColor( Color.blue );   // draw in blue
      graphics.fillRect( 1, 1, 3, 3 );   // draw filled rectangle
      graphics.setColor( Color.red );    // draw in red
      graphics.fillRect( 4, 4, 3, 3 );   // draw filled rectangle

      // paint buffImage into graphics context of JFrame
      graphics2D.setPaint( new TexturePaint(
         bufferedImage, new Rectangle( 10, 10 ) ) );
      graphics2D.fill( new RoundRectangle2D.Double(
         155, 30, 75, 100, 50, 50 ) );

      // draw 2D pie-shaped arc in white
      graphics2D.setPaint( Color.white );
      graphics2D.setStroke( new BasicStroke( 6.0f ) ); 
      graphics2D.draw( new Arc2D.Double(
         240, 30, 75, 100, 0, 270, Arc2D.PIE ) );

      // draw 2D lines in green and yellow
      graphics2D.setPaint( Color.green );
      graphics2D.draw( new Line2D.Double( 395, 30, 320, 150 ) );

      float dashes[] = { 10, 2 };

      graphics2D.setPaint( Color.yellow );    
      graphics2D.setStroke( new BasicStroke( 
         4, BasicStroke.CAP_ROUND, BasicStroke.JOIN_ROUND, 
         10, dashes, 0 ) ); 
      graphics2D.draw( new Line2D.Double( 320, 30, 395, 150 ) );
   
   } // end method paint

   // start application
   public static void main( String args[] )
   {
      Shapes application = new Shapes();
      application.setDefaultCloseOperation( 
         JFrame.EXIT_ON_CLOSE );
      
      application.setSize( 425, 160 );
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
