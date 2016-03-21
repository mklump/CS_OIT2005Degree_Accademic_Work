// WriteOperation.java
// This application initializes an new Entry object, 
// and deposits this Entry to the JavaSpace.
package com.deitel.advjhtp1.javaspace.write;

// Jini core packages
import net.jini.core.lease.Lease;
import net.jini.core.transaction.TransactionException;

// Jini extension package
import net.jini.space.JavaSpace;

// Java core package
import java.rmi.RemoteException;

// Java extension package
import javax.swing.*;

// Deitel package
import com.deitel.advjhtp1.javaspace.common.*;

public class WriteOperation {

   private JavaSpace space;
   private static final String[] days = { "Monday", "Tuesday",
      "Wednesday", "Thursday", "Friday" };
   private String output = "\n";

   // WriteOperation constructor
   public WriteOperation( String hostname )
   {
      // get the JavaSpace
      String jiniURL = "jini://" +  hostname;
      JavaSpaceFinder findtool = new JavaSpaceFinder( jiniURL );
      space = findtool.getJavaSpace();
   }

   // deposit a new Entry to the JavaSpace
   public void writeEntry( String day )
   {
      // initialize a AttendeeCounter Entry and deposit 
      // Entry object to the JavaSpace
      try {
         AttendeeCounter counter = new AttendeeCounter( day );
         space.write( counter, null, Lease.FOREVER );

         output += "Initialize the Entry: \n";
         output += "   Day: " + day + "\n";
         output += "   Count: 0\n";
      }

      // handle exception network failure 
      catch ( RemoteException exception ) {
         exception.printStackTrace();
      }

      // handle exception invalid transaction
      catch ( TransactionException exception ) {
         exception.printStackTrace();
      }
   }

   // show output
   public void showOutput()
   {
      JTextArea outputArea = new JTextArea();
      outputArea.setText( output );
      JOptionPane.showMessageDialog( null, outputArea, 
         "WriteOperation Output", 
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
            "Usage: WriteOperation hostname" );
         System.exit( 1 );
      }
      
      // get the user input day
	  String day = ( String ) JOptionPane.showInputDialog( 
         null, "Select Day", "Day Selection", 
         JOptionPane.QUESTION_MESSAGE, null, days, days[ 0 ] );

      // write an Entry
      WriteOperation write = new WriteOperation( args[ 0 ] );
      write.writeEntry( day );

      write.showOutput();
     
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