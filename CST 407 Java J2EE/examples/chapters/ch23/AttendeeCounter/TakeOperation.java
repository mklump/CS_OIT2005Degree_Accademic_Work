// TakeOperation.java
// This application removes an Entry from the JavaSpace.
package com.deitel.advjhtp1.javaspace.take;

// Jini core packages
import net.jini.core.transaction.TransactionException;
import net.jini.core.entry.UnusableEntryException;

// Jini extension package
import net.jini.space.JavaSpace;

// Java core packages
import java.rmi.RemoteException;

// Java extension package
import javax.swing.*;

// Deitel package
import com.deitel.advjhtp1.javaspace.common.*;

public class TakeOperation {

   private JavaSpace space = null;
   private static final String[] days = { "Monday", "Tuesday",
      "Wednesday", "Thursday", "Friday" };
   private String output = "\n";

   // constructor gets the JavaSpace
   public TakeOperation( String hostname )
   {
      // get the JavaSpace
      String jiniURL = "jini://" +  hostname;
      JavaSpaceFinder findtool = new JavaSpaceFinder( jiniURL );
      space = findtool.getJavaSpace();
   }

   // remove an Entry from the JavaSpace
   public void TakeAnEntry( String day )
   {
      AttendeeCounter resultCounter = null;

      // specify a matching template, remove the template
      // from the JavaSpace			
      try {     
         AttendeeCounter count = new AttendeeCounter( day );
         resultCounter = ( AttendeeCounter ) space.take( count,
            null, JavaSpace.NO_WAIT );

         if ( resultCounter == null) {
            output += "No Entry for " + day
               + " is available from the JavaSpace.\n";
         }
         else {
            output += "Entry is taken away from ";
            output += "the JavaSpace successfully.\n";
         }
      }

      // if a network failure occurs
      catch ( RemoteException exception ) {
         exception.printStackTrace();
      }

      // if take operates under an invalid transaction
      catch ( TransactionException exception ) {
         exception.printStackTrace();
      }

      // if the returned Entry cannot be deserialized
      catch ( UnusableEntryException exception ) {
         exception.printStackTrace();
      }

      // if an interrupt occurs
      catch ( InterruptedException exception ) {
         exception.printStackTrace();
      }

   } // end method TakeAnEntry

   // show output
   public void showOutput()
   {
      JTextArea outputArea = new JTextArea();
      outputArea.setText( output );
      JOptionPane.showMessageDialog( null, outputArea, 
         "TakeOperation Output", 
         JOptionPane.INFORMATION_MESSAGE );

      // terminate the program
      System.exit( 0 );
   }

   public static void main( String args[] )
   {
      // get the hostname
      if ( args.length != 1 ) {
         System.out.println( 
            "Usage: WriteOperation hostname!" );
         System.exit( 1 );
      }
     
      // get the user input day
      String day = ( String ) JOptionPane.showInputDialog( 
         null, "Select Day", "Day Selection", 
         JOptionPane.QUESTION_MESSAGE, null, days, days[ 0 ] );

      // take an Entry
      TakeOperation take = new TakeOperation( args[ 0 ] );
      take.TakeAnEntry( day );
      
      take.showOutput();

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