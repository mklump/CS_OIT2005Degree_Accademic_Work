// Fig. I.25 JNIPanel.java
// loads an image, creates a copy and uses JNI to tint the image.

// Java headers
import javax.swing.*;
import java.awt.*;
import java.awt.image.*;
import java.awt.event.*;

public class JNIPanel extends JPanel implements ActionListener {
   BufferedImage loadedImage;
   BufferedImage tintedImage;
   int[] imageRGB;
   int[] tintedRGB;
   JSlider tintRed, tintGreen, tintBlue;
   JButton tintButton;
   JNITintWrapper imageProcess;

   // obtains image, processes it and displays warnings
   public JNIPanel( String file, LayoutManager layout )
   {
      super( layout );
      setPreferredSize( new Dimension( 640, 425 ) );
      
      // create image manipulation components
      tintRed = new JSlider( 0, 255, 0 );
      tintBlue = new JSlider( 0, 255, 0 );
      tintGreen = new JSlider( 0, 255, 0 );
      tintButton = new JButton( "Tint Image" );
      
      JLabel redLabel = new JLabel( "Red");
      JLabel greenLabel = new JLabel( "Green" );
      JLabel blueLabel = new JLabel( "Blue" );
      
      // set properties for red slider
      tintRed.setMajorTickSpacing( 50 );
      tintRed.setMinorTickSpacing( 10 );
      tintRed.setPaintTicks( true );
      tintRed.setPaintLabels( true );
      
      // set properties for green slider
      tintGreen.setMajorTickSpacing( 50 );
      tintGreen.setMinorTickSpacing( 10 );
      tintGreen.setPaintTicks( true );
      tintGreen.setPaintLabels( true );
      
      // set properties for blue slider
      tintBlue.setMajorTickSpacing( 50 );
      tintBlue.setMinorTickSpacing( 10 );
      tintBlue.setPaintTicks( true );
      tintBlue.setPaintLabels( true );
      
      tintButton.setActionCommand( "tint" );
      
      // use this class to process action
      tintButton.addActionListener( this );
      
      // create a new panel for the sliders and button
      JPanel sliderPanel = new JPanel( new FlowLayout( FlowLayout.LEFT ) );
      
      JPanel redPanel =  new JPanel( new FlowLayout() );
      redPanel.setPreferredSize( new Dimension( 200, 250 ) );
      
      JPanel greenPanel =  new JPanel( new FlowLayout() );
      greenPanel.setPreferredSize( new Dimension( 200, 250 ) );
      
      JPanel bluePanel =  new JPanel( new FlowLayout() );
      bluePanel.setPreferredSize( new Dimension( 200, 250 ) );
      
      // add the componenets
      redPanel.add( tintRed );
      redPanel.add( redLabel );
      
      greenPanel.add( tintGreen );
      greenPanel.add( greenLabel );
      
      bluePanel.add( tintBlue );
      bluePanel.add( blueLabel );
      
      sliderPanel.add( redPanel );
      sliderPanel.add( greenPanel );
      sliderPanel.add( bluePanel );
      // set panel size
      sliderPanel.setPreferredSize( new Dimension( 650, 75 ) );
      
      add( sliderPanel );
      
      // add components to JNIPanel
      add( tintButton );
      
      MediaTracker tracker = new MediaTracker( this );

      // load the image
      Image image = Toolkit.getDefaultToolkit().getImage( file );
      
      // add the image to the tracker
      tracker.addImage( image, 0 );
      
      try{
         
         // wait until image is loaded
         tracker.waitForID( 0 );
      } catch ( InterruptedException e ) {
         e.printStackTrace();
      }

      // create a new buffered image
      loadedImage = new BufferedImage(
         image.getWidth( this ), image.getHeight( this ),
         BufferedImage.TYPE_INT_ARGB );
      
      // get the graphics context of the BufferedImage
      Graphics2D graphics = ( Graphics2D )loadedImage.getGraphics();
      
      // draw the Image on the BufferedImage
      graphics.drawImage( image , 0, 0, this );

      // create a new native wrapper
      imageProcess = new JNITintWrapper();
      
      // obtains an array of RGB integer values
      imageRGB = loadedImage.getRGB( 0 , 0 , loadedImage.getWidth(),
         loadedImage.getHeight(), imageRGB,
         0, loadedImage.getWidth() );
    
      // create a new buffered image for the new RGB values
      tintedImage = new BufferedImage(
         loadedImage.getWidth(), loadedImage.getHeight(),
         BufferedImage.TYPE_INT_ARGB );
      
      // proccess the image and print any warnings
      updateTint();
   }
   
   // draw our two BufferedImages
   public void paintComponent( Graphics g )
   {
      super.paintComponent( g );
      Graphics2D graphics = ( Graphics2D )g;
      graphics.drawImage( loadedImage, null,  150 , 150 );
      graphics.drawImage(
         tintedImage, null,  loadedImage.getWidth() + 160 , 150 );
   }
   
   // tints the image and displays warnings
   public void updateTint() {
      
      // get a copy of the original RGB values
      tintedRGB = ( int[] )imageRGB.clone();
      
      // try to tint the image.
      try {
         
         // call to the native code for image processing tint 20 green
         int[] warnings =
            imageProcess.tintImage(
               tintedRGB, tintedRGB.length, tintRed.getValue() ,
                  tintGreen.getValue() , tintBlue.getValue() );

         if ( warnings != null )
            System.out.println(
               "Not all pixels could be fully tinted" );
         
      // if image is too large catch exception and end program
      } catch ( ImageSizeException sizeException ) {
         System.out.println(
            "Image is too large, error was:" );
         sizeException.printStackTrace();
      }
         
      // set the RGB values
      tintedImage.setRGB( 0, 0, tintedImage.getWidth(),
         tintedImage.getHeight(), tintedRGB, 0 ,
         tintedImage.getWidth() );
      
      // repaint the image
      repaint();
   }

   // handles button events
   public void actionPerformed( ActionEvent  e ) {
      
      // if button pressed then update image
      if ( e.getActionCommand().equals( "tint" ) )
         updateTint();
      
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

