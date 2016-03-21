// UpdateOperation.java
// This application removes an Entry from the JavaSpace,
// changes the variable's value in the returned Entry and
// deposits the updated Entry into the JavaSpace. All these
// operations are occurred within a transaction.
package com.deitel.advjhtp1.javaspace.update;

// Jini core package
import net.jini.core.lease.Lease;
import net.jini.core.transaction.*;
import net.jini.core.entry.UnusableEntryException;
import net.jini.core.transaction.server.TransactionManager;

// Jini extension package
import net.jini.space.JavaSpace;
import net.jini.lease.*;

// Java core packages
import java.rmi.RemoteException;

// Java extension packages
import javax.swing.*;

// Deitel packages
import com.deitel.advjhtp1.javaspace.common.*;

public class UpdateOperation {

   private JavaSpace space;
   private TransactionManager transactionManager;
   private static String hostname = "";
   private static String day = "";
   private static int inputCount = 0;
   private static String output = "\n";

   // default constructor
   public UpdateOperation() {}

   // constructor gets JavaSpace and TransactionManager
   public void getServices( String jiniURL )
   {
      // get JavaSpace and TransactionManager
      JavaSpaceFinder findtool = 
         new JavaSpaceFinder( jiniURL );
      space = findtool.getJavaSpace();
      TransactionManagerFinder findTransaction = 
         new TransactionManagerFinder( jiniURL );
      transactionManager = 
         findTransaction.getTransactionManager();
   }

   // update Entry
   public void updateEntry( String inputDay, int countNumber )
   {
      day = inputDay;
      inputCount = countNumber;

      AttendeeCounter resultCounter = null;
      Transaction.Created transactionCreated = null;
      LeaseRenewalManager manager = new LeaseRenewalManager();

      int oldCount = 0;
      int newCount = 0;

      // create transaction and renew transaction's lease
      try {
         transactionCreated = TransactionFactory.create(
            transactionManager, Lease.FOREVER );
         manager.renewUntil( 
            transactionCreated.lease, Lease.FOREVER, null );
      }

      // handle exception creating transaction and renewing lease
      catch ( Exception exception ) {
         exception.printStackTrace();
      }

      // specify matching template, remove template 
      // from JavaSpace in transaction, change 
      // variable's value and write updated template back 
      // to JavaSpace within a transaction
      try {

         // take Entry away from JavaSpace
         AttendeeCounter count = new AttendeeCounter( day );
         resultCounter = ( AttendeeCounter ) space.take( count,
            transactionCreated.transaction, JavaSpace.NO_WAIT );

         // if no matching entry
         if ( resultCounter == null ) {

            // set output message
            output += " No matching Entry is available!\n";
         }
         else { // if find a matching entry
         
            // update value
            oldCount = resultCounter.counter.intValue();
            newCount = oldCount + inputCount;

            // put updated Entry back to JavaSpace
            resultCounter.counter = new Integer( newCount );
            space.write( resultCounter, 
               transactionCreated.transaction, Lease.FOREVER );

            // output result if transaction completes
            output += "Count Information:\n";
            output += "   Day: ";
            output += resultCounter.day + "\n";
            output += "   Old Count: " + oldCount + "\n";
            output += "   New Count: " + newCount + "\n";
         }

         // commit transaction and release lease
         transactionCreated.transaction.commit();
         manager.remove( transactionCreated.lease );

      } // end try

      // handle exception updating Entry
      catch ( Exception exception ) {
         exception.printStackTrace();
            
         // revert change and release lease
         try {
            transactionCreated.transaction.abort();
            manager.remove( transactionCreated.lease );
         }

         // handle exception reverting change
         catch ( Exception abortException ) {
            abortException.printStackTrace();
         }
      }

   } // end method updateEntry

   // show output
   public void showOutput()
   {
      JTextArea outputArea = new JTextArea();
      outputArea.setText( output );
      JOptionPane.showMessageDialog( null, outputArea, 
         "UpdateOperation Output", 
         JOptionPane.INFORMATION_MESSAGE );

      // terminate program
      System.exit( 0 );
   }

   public static void main( String args[])
   {
      // get hostname
      if ( args.length != 1 ) {
         System.out.println( 
            "Usage: UpdateOperation hostname" );
         System.exit( 1 );
      }
      else 
         hostname = args[ 0 ];

      // get user input day
      UpdateInputWindow input = new UpdateInputWindow( hostname );

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