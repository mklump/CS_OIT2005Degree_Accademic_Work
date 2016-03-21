// fig: ImageSeparator.java
// This class partitions the image into smaller pieces evenly
// and stores the smaller images into a JavaSpace.
package com.deitel.advjhtp1.javaspace.ImageProcessor;

// Java core packages
import java.util.*;
import java.rmi.*;

// Java standard extensions
import javax.swing.*;

// Jini core packages
import net.jini.core.lease.Lease;
import net.jini.core.transaction.TransactionException;

// Jini extension packages
import net.jini.space.JavaSpace;
import net.jini.lease.*;

// Deitel packages
import com.deitel.advjhtp1.javaspace.common.*;

public class ImageSeparator {

   private String imageName;
   private String filterType;
   private int partitionNumber;
   private Vector imagePieces;
   private ImageIcon icon;
   
   // ImageSeparator constructor
   public ImageSeparator( 
      String name, String type, int number )
   {
      imageName = name;
      filterType = type;
      partitionNumber = number;
   }

   // partition the image into smaller pieces evenly
   public void partitionImage()
   {
      ImageParser imageParser = new ImageParser();
      icon = new ImageIcon( imageName );

      // partition the image
      imagePieces = imageParser.parseImage( 
         icon, partitionNumber );
   }

   // display the image
   public void displayImage(  )
   {
      ImageDisplayer imageDisplayer = 
         new ImageDisplayer( icon );
      imageDisplayer.setSize( icon.getIconWidth() + 50, 
         icon.getIconHeight() + 50 );
      imageDisplayer.setVisible( true );
   }

   // write image pieces into a JavaSpace
   public void storeImage( String hostname )
   {
      // get the JavaSpace
      String jiniURL = "jini://" +  hostname;
      JavaSpaceFinder findtool = 
         new JavaSpaceFinder( jiniURL );
      JavaSpace space = findtool.getJavaSpace();

      LeaseRenewalManager leaseManager = 
         new LeaseRenewalManager();

      // write sub images to JavaSpace
      try {

         for ( int i = 0; i < imagePieces.size(); i++ ) {
            ImageIcon subImage = 
               ( ImageIcon ) imagePieces.elementAt( i );

            ImageEntry imageEntry = new ImageEntry( 
               imageName, filterType, i, false, subImage );

            Lease writeLease = space.write( 
               imageEntry, null, Lease.FOREVER );
            leaseManager.renewUntil( 
               writeLease, Lease.FOREVER, null );
         }
      }

      // if a network failure occurs		
      catch ( RemoteException remoteException ) {
         remoteException.printStackTrace();
      }

      // if write operates under an invalid transaction
      catch ( TransactionException transactionException ) {
         transactionException.printStackTrace();
      }

   } // end method storeImage
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