// ReadOperation.java
// This application reads an Entry from the JavaSpace and
// displays the Entry information.
package com.deitel.advjhtp1.javaspace.read;

// Jini core packages
import net.jini.core.transaction.TransactionException;
import net.jini.core.entry.UnusableEntryException;

// Jini extension package
import net.jini.space.JavaSpace;

// Java core packages
import java.rmi.RemoteException;
import java.lang.InterruptedException;

// Java extension package
import javax.swing.*;

// Deitel package
import com.deitel.advjhtp1.javaspace.common.*;

public class ReadOperation {

   private JavaSpace space;
   private static final String[] days = { "Monday", "Tuesday",
      "Wednesday", "Thursday", "Friday" };
   private String output = "\n";

   // constructor gets JavaSpace
   public ReadOperation( String hostname )
   {
      // get JavaSpace
      String jiniURL = "jini://" +  hostname;
      JavaSpaceFinder findtool = new JavaSpaceFinder( jiniURL );
      space = findtool.getJavaSpace();
   }

   // read Entry from JavaSpace
   public void readEntry( String day )
   {
      // specify matching template, read template
      // from JavaSpace and output Entry information
      try {

         // read Entry from JavaSpace
         AttendeeCounter counter = new AttendeeCounter( day );
         AttendeeCounter resultCounter = ( AttendeeCounter ) 
            space.read( counter, null, JavaSpace.NO_WAIT );

         if (resultCounter == null) {
            output += "Sorry, cannot find an Entry for "
               + day + "!\n";
         }
         else {

            // get Entry information
            output += "Count Information:\n";
            output += "   Day: " + resultCounter.day;
            output += "\n";
            output += "   Count: " 
               + resultCounter.counter.intValue() + "\n";
         }
      }

      // handle exception network failure		
      catch ( RemoteException exception ) {
         exception.printStackTrace();
      }

      // handle exception invalid transaction
      catch ( TransactionException exception ) {
         exception.printStackTrace();
      }

      // handle exception unusable Entry 
      catch ( UnusableEntryException exception ) {
         exception.printStackTrace();
      }

      // handle exception interrupting
      catch ( InterruptedException exception ) {
         exception.printStackTrace();
      }

   } // end method readEntry

   // show output
   public void showOutput()
   {
      JTextArea outputArea = new JTextArea();
      outputArea.setText( output );
      JOptionPane.showMessageDialog( null, outputArea, 
         "ReadOperation Output", 
         JOptionPane.INFORMATION_MESSAGE );

      // terminate program
      System.exit( 0 );
   }

   // method main
   public static void main( String args[] )
   {
      // get hostname
      if ( args.length != 1 ) {
         System.out.println( 
            "Usage: ReadOperation hostname" );
         System.exit( 1 );
      }

      // get user input day
      String day = ( String ) JOptionPane.showInputDialog( 
         null, "Select Day", "Day Selection", 
         JOptionPane.QUESTION_MESSAGE, null, days, days[ 0 ] );

      // read an Entry
      ReadOperation read = new ReadOperation( args[ 0 ] );
      read.readEntry( day );

      read.showOutput();

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