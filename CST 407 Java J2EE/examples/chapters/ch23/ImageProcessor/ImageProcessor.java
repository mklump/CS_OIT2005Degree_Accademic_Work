// Fig: ImageProcessor.java
// This application notifies the listener when an ImageEntry
// that needs to be processed is written into the JavaSpace.
package com.deitel.advjhtp1.javaspace.ImageProcessor;

// Java standard extensions
import javax.swing.*;

// Jini core packages
import net.jini.core.lease.Lease;
import net.jini.core.transaction.*;
import net.jini.core.transaction.server.TransactionManager;
import net.jini.core.entry.*;
import net.jini.core.transaction.*;
import net.jini.lease.*;

// Jini extension package
import net.jini.space.JavaSpace;

// Deitel packages
import com.deitel.advjhtp1.javaspace.common.*;

public class ImageProcessor {

   private JavaSpace space;
   private TransactionManager manager;

   // ImageProcessor constructor
   public ImageProcessor ( String hostname )
   {
      // get the JavaSpace
      String jiniURL = "jini://" +  hostname;
      JavaSpaceFinder finder = 
         new JavaSpaceFinder( jiniURL );
      space = finder.getJavaSpace();

      // get the TransactionManager
      TransactionManagerFinder findTransaction = 
         new TransactionManagerFinder( jiniURL );
      manager = 
         findTransaction.getTransactionManager();
   }

   // wait for unprocessed image
   public void waitForImage()
   {
      LeaseRenewalManager leaseManager = 
         new LeaseRenewalManager();

      while ( true ) {

         // get unprocessed image and process it 
         try {
            Transaction.Created transactionCreated = 
               TransactionFactory.create( 
                  manager, Lease.FOREVER );

            // renew transaction's lease
            leaseManager.renewUntil( 
               transactionCreated.lease, Lease.FOREVER, null );

            ImageEntry template = new ImageEntry( null, false );
            ImageEntry entry = ( ImageEntry ) space.take( 
               template, transactionCreated.transaction, 
               Lease.FOREVER );

            if ( entry != null ) {

               // get image icon
               ImageIcon imageIcon = entry.imageIcon;

               Filters filters = new Filters( imageIcon );

               if ( entry.filter.equals( "BLUR" ) )
                  filters.blurImage();

               else if ( entry.filter.equals( "COLOR" ) )
                  filters.colorFilter();
            
               else if ( entry.filter.equals( "INVERT" ) )
                  filters.invertImage();
            
               else if ( entry.filter.equals( "SHARP" ) )
                  filters.sharpenImage();

               // update the fields of result entry
               entry.imageIcon = filters.getImageIcon();
               entry.processed = new Boolean( true );

               // put the updated Entry back to JavaSpace
               Lease writeLease = space.write( entry, 
                  transactionCreated.transaction, 
                  Lease.FOREVER );
               leaseManager.renewUntil( 
                  writeLease, Lease.FOREVER, null );

            } // end if

		    // commit the transaction and release the lease
            transactionCreated.transaction.commit();
            leaseManager.remove( transactionCreated.lease );
         
         } // end try

         // handle exception
         catch ( Exception exception ) {
            exception.printStackTrace();
         }

      } // end while
      
   } // end method wait for images

   public static void main( String[] args )
   {
      // get the hostname
      if ( args.length != 1 ) {
         System.out.println( 
            "Usage: ImageProcessor hostname" );
         System.exit( 1 );
      }
      
      ImageProcessor processor = 
         new ImageProcessor( args[ 0 ] );

      // wait for image
      processor.waitForImage();

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