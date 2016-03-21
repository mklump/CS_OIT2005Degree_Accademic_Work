// SnapshotUsage.java
// This application removes entries from the JavaSpace using
// method snapshot.
package com.deitel.advjhtp1.javaspace.snapshot;

// Jini core packages
import net.jini.core.transaction.TransactionException;
import net.jini.core.entry.UnusableEntryException;
import net.jini.core.entry.Entry;

// Jini extension package
import net.jini.space.JavaSpace;

// Java core packages
import java.rmi.RemoteException;

// Java extension package
import javax.swing.*;

// Deitel packages
import com.deitel.advjhtp1.javaspace.common.*;

public class SnapshotUsage {

   private JavaSpace space;
   private static final String[] days = { "Monday", "Tuesday",
      "Wednesday", "Thursday", "Friday" };
   private String output = "\n";

   // constructor gets the JavaSpace
   public SnapshotUsage( String hostname )
   {
      // get JavaSpace
      String jiniURL = "jini://" +  hostname;
      JavaSpaceFinder findtool = new JavaSpaceFinder( jiniURL );
      space = findtool.getJavaSpace();
   }

   // create a snapshot entry object, pass this object as the
   // Entry parameter to the take method
   public void snapshotEntry( String day )
   {
      // specify a matching template, snapshot the template
      // and remove matching entries from the JavaSpace using 
      // the snapshot entry
      try {     
         AttendeeCounter counter = new AttendeeCounter( day );
         Entry snapshotentry = space.snapshot( counter );
         AttendeeCounter resultCounter = ( AttendeeCounter ) 
            space.take( snapshotentry, null, JavaSpace.NO_WAIT );

         // keep removing entries until no more entry exists
         // in the space
         while ( resultCounter != null ) {
            output += "Removing an entry ... \n";
            resultCounter = (AttendeeCounter) space.take( 
               snapshotentry, null, JavaSpace.NO_WAIT );
         }
         
         output += "No more entry to remove!\n";
      }

      // if a network failure occurs
      catch ( RemoteException remoteException ) {
         remoteException.printStackTrace();
      }

      // if take operates under an invalid transaction
      catch ( TransactionException transactionException ) {
         transactionException.printStackTrace();
      }

      // if the returned Entry cannot be deserialized
      catch ( UnusableEntryException unusableEntryException ) {
         unusableEntryException.printStackTrace();
      } 

      // if an interrupt occurs
      catch ( InterruptedException interruptedException ) {
         interruptedException.printStackTrace();
      }

   } // end method snapshotEntry

   // show output
   public void showOutput()
   {
      JTextArea outputArea = new JTextArea();
      outputArea.setText( output );
      JOptionPane.showMessageDialog( null, outputArea, 
         "SnapshotUsage Output", 
         JOptionPane.INFORMATION_MESSAGE );

      // terminate the program
      System.exit( 0 );
   }

   // method main
   public static void main( String args[] )
   {
      // get the hostname
      if ( args.length != 1 ) {
         System.out.println( 
            "Usage: SnapshotUsage hostname" );
         System.exit( 1 );
      }
      
      // get the user input day
	  String day = ( String ) JOptionPane.showInputDialog( 
         null, "Select Day", "Day Selection", 
         JOptionPane.QUESTION_MESSAGE, null, days, days[ 0 ] );

      // snapshot an Entry
      SnapshotUsage snapshot = new SnapshotUsage( args[ 0 ] );
      snapshot.snapshotEntry( day );

      snapshot.showOutput();

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