// Fig. 23.25 ImageProcessingClient.java
// The application asks for user-specified image file, image 
// filter type and image partition number, filters the image
// and displays the processed image.
package com.deitel.advjhtp1.javaspace.ImageProcessor;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.util.*;
import java.io.*;

// Java extension packages
import javax.swing.*;

// Jini core packages
import net.jini.core.lease.Lease;
import net.jini.core.entry.*;
import net.jini.core.transaction.*;
import net.jini.core.transaction.server.TransactionManager;

// Jini extension packages
import net.jini.space.JavaSpace;

// Deitel packages
import com.deitel.advjhtp1.javaspace.common.*;

public class ImageProcessingClient extends JFrame {

   private String[] operations = { "BLUR", "COLOR",
      "INVERT", "SHARP" };
   private JButton okButton;
   private JComboBox operationComboBox;
   private JTextField imageText;
   private JTextField numberText;
 
   private static String hostname = "";
   private String imageName;
   private String operation = "BLUR";
   private int partitionNumber = 0;

   public ImageProcessingClient( String host )
   {
      super ( "ImageProcessInput" );

      hostname = host;
      Container container = getContentPane();

      // define the center panel
      JPanel centerPanel = new JPanel();
      centerPanel.setLayout( new GridLayout( 3, 2, 0, 5 ) );

      // add image label
      JLabel imageLabel = new JLabel( "Image File:", 
         SwingConstants.CENTER );
      centerPanel.add( imageLabel );

      JButton openFile = new JButton( 
         "Choose file to process" );
      openFile.addActionListener( 

         new ActionListener() {

            public void actionPerformed( ActionEvent event )
            {
               JFileChooser fileChooser = new JFileChooser();
               
               fileChooser.setFileSelectionMode( 
                  JFileChooser.FILES_ONLY );
               int result = fileChooser.showOpenDialog( null );
               File file;

               // user clicked Cancel button on dialog
               if ( result == JFileChooser.CANCEL_OPTION )
                  file = null;
               else {
                  file = fileChooser.getSelectedFile();
                  imageName = file.getPath();
               }

            } // end method actionPerformed

         } // end ActionListener constructor

      ); // end addActionListener

      centerPanel.add( openFile );

      // add number label
      JLabel numberLabel = new JLabel( "Partition Number:", 
         SwingConstants.CENTER );
      centerPanel.add( numberLabel );

      // add number text field
      numberText = new JTextField( 10 );
      centerPanel.add( numberText );

      // install a listener to the number text field
      numberText.addActionListener( 

         new ActionListener() {

            // get the text when the user feeds a return 
            // character in the text field
            public void actionPerformed( ActionEvent event ) 
            {
               partitionNumber = Integer.parseInt(
                  event.getActionCommand() );
            }
         }
      );

      // add operation label
      JLabel operationLabel = new JLabel( "Operation Type:", 
         SwingConstants.CENTER );
      centerPanel.add( operationLabel );

      // add a combo box
      operationComboBox = new JComboBox( operations );
      operationComboBox.setSelectedIndex( 0 );
      centerPanel.add( operationComboBox );

      // install a listener to the combo box
      operationComboBox.addItemListener( 

         new ItemListener() {

            // an operation other than BLUR is selected
            public void itemStateChanged( ItemEvent itemEvent )
            {
               operation = 
                  ( String ) operationComboBox.getSelectedItem();
            }
         }
      );

      // define the button panel    
      JPanel buttonPanel = new JPanel();
      buttonPanel.setLayout( new GridLayout( 1, 1, 0, 5 ) );

      // add the OK button
      okButton = new JButton( "OK" );
      buttonPanel.add( okButton );

      // add a listener to the OK button
      okButton.addActionListener(

         new ActionListener() {

            // partition image file into number of pieces user 
            // specified
            public void actionPerformed( ActionEvent event ) 
            {
               // get user inputs
               partitionNumber = Integer.parseInt( 
                  numberText.getText() );

               // check whether the user 
               // fills in both text fields
               if ( ( partitionNumber == 0 ) 
                  || ( imageName == null ) ) {
                     JOptionPane.showMessageDialog( null, 
                      "Either image name or partition number " 
                      + "is not specified!", "Error", 
                      JOptionPane.ERROR_MESSAGE);
               }

               else {
                  setVisible( false );

                  // partition the image into smaller pieces 
                  // and store the sub images into a JavaSpace
                  ImageSeparator imageSeparator = 
                     new ImageSeparator( 
                        imageName, operation, partitionNumber );
                  imageSeparator.partitionImage();
                  imageSeparator.storeImage( hostname );
                  imageSeparator.displayImage();
                  collect();
               }

            } // end method actionPerformed

         } // end ActionListener constructor

      ); // end addActionListener

      // put everything together
      container.add( centerPanel, BorderLayout.CENTER );
      container.add( buttonPanel, BorderLayout.SOUTH );

   } // end ImageProcessingClient constructor

   // collect processed images
   public void collect()
   {
      // get the JavaSpace
      String jiniURL = "jini://" +  hostname;
      JavaSpaceFinder findtool = 
         new JavaSpaceFinder( jiniURL );
      JavaSpace space = findtool.getJavaSpace();

      Vector unOrderedImages = new Vector();
      Vector orderedImages = null;

      // removes all images in the JavaSpace 
      // that have the specified name
      try {
         double squareRoot = Math.sqrt( partitionNumber );

         if ( Math.floor( squareRoot ) != ( squareRoot ) ) 
            partitionNumber = 4; 

         // specify the matching template
         ImageEntry template = new ImageEntry( imageName, true );

         // snapshot the template
         Entry snapshotEntry = space.snapshot( template );
 
         // collect images
         for ( int i = 0; i < partitionNumber ; i++ ) {
            ImageEntry remove = ( ImageEntry ) space.take(
               snapshotEntry, null, Lease.FOREVER );
            unOrderedImages.add( remove );
         }

         int imageCount = unOrderedImages.size();
         orderedImages = 
            new Vector( imageCount );

         // initialize the Vector
         for ( int i = 0; i < imageCount; i++ )
            orderedImages.add( null );
    
         // order the sub images
         for ( int i = 0; i < imageCount; i++ ) {
            ImageEntry image = 
               ( ImageEntry ) unOrderedImages.elementAt( i );
            orderedImages.setElementAt( 
               image.imageIcon, image.number.intValue() );
         }

      } // end try

      // handle exception collecting images 
      catch ( Exception exception ) {
         exception.printStackTrace();
      }   

      // put images together and display the result image
      if ( orderedImages.size() > 0) {
         ImageParser imageParser = new ImageParser();

         ImageIcon icon = imageParser.putTogether( 
            orderedImages );

         ImageDisplayer imageDisplayer = 
            new ImageDisplayer( icon );

         imageDisplayer.setSize( icon.getIconWidth() + 50, 
            icon.getIconHeight() + 50 );
         imageDisplayer.setVisible( true );
         imageDisplayer.setDefaultCloseOperation( 
            JFrame.EXIT_ON_CLOSE );
      }

      else {
         JOptionPane.showMessageDialog( null, 
            "Invalid image name", "Error", 
            JOptionPane.ERROR_MESSAGE);

         // terminate program
         System.exit( 0 );
      }
      
   } // end method collect

   public static void main( String[] args )
   {
      // get the hostname
      if ( args.length != 1 ) {
         System.out.println( 
            "Usage: ImageProcessingClient hostname" );
         System.exit( 1 );
      }
      
      ImageProcessingClient processor = 
         new ImageProcessingClient( args[ 0 ] );

      // set the window size and display it
      processor.setSize( 350, 150 );
      processor.setVisible( true );
     
   } // end method main
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