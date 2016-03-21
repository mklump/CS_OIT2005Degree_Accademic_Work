// Fig: NotifyOperation.java
// This application receives a notification when a matching entry
// is written to the JavaSpace.
package com.deitel.advjhtp1.javaspace.notify;

// Jini core packages
import net.jini.core.transaction.TransactionException;
import net.jini.core.lease.Lease;
import net.jini.core.event.*;

// Jini extension package
import net.jini.space.JavaSpace;

// Java core packages
import java.rmi.*;

// Java standard extensions
import javax.swing.*;

// Deitel packages
import com.deitel.advjhtp1.javaspace.common.*;

public class NotifyOperation implements RemoteEventListener
{
   private JavaSpace space;
   private static final String[] days = { "Monday", "Tuesday",
      "Wednesday", "Thursday", "Friday" };

   // constructor gets the JavaSpace
   public NotifyOperation( String hostname ) 
   {
	  // get JavaSpace
      String jiniURL = "jini://" +  hostname;
      JavaSpaceFinder findtool = new JavaSpaceFinder( jiniURL );
      space = findtool.getJavaSpace();
   }

   // call notify method of the JavaSpace
   public void notifyEntry( String day )
   {
      // get Entry listener
      EntryListener listener = new EntryListener( this );

      // specify a matching template, asks the JavaSpace to
      // send a notification when a matching entry is written
      // to the JavaSpace
      try {      
         AttendeeCounter counter = new AttendeeCounter( day );

         MarshalledObject handback = new MarshalledObject( 
            "JavaSpace Notification" );
         space.notify( 
            counter, null, listener, 10 * 60 * 1000, handback );
      }

      // handle exception notifying space
      catch ( Exception exception ) {
         exception.printStackTrace();
      }

   } // end method notifyEntry

   // show output
   public void showOutput( String output )
   {
      JTextArea outputArea = new JTextArea();
      outputArea.setText( output );
      JOptionPane.showMessageDialog( null, outputArea, 
         "NotifyOperation Output", 
         JOptionPane.INFORMATION_MESSAGE );
   }

   // receive notifications
   public void notify( RemoteEvent remoteEvent )
   {
      String output = "\n";

      // prepare output
      try {
         output += "id: " + remoteEvent.getID() + "\n";
         output += "sequence number: " 
            + remoteEvent.getSequenceNumber() + "\n";
         String handback = ( String ) 
            remoteEvent.getRegistrationObject().get();
         output += "handback: " + handback + "\n";

		 // display output
		 showOutput( output );
	  }

	  // handle exception getting handback
	  catch ( Exception exception ) {
         exception.printStackTrace();
      }
   }

   // method main
   public static void main( String args[] )
   {
      // get the hostname
      if ( args.length != 1 ) {
         System.out.println( 
            "Usage: NotifyOperation hostname" );
         System.exit( 1 );
      }
      
      // get the user input day
	  String day = ( String ) JOptionPane.showInputDialog( 
         null, "Select Day", "Day Selection", 
         JOptionPane.QUESTION_MESSAGE, null, days, days[ 0 ] );

      // notify an Entry
      NotifyOperation notifyOperation = 
         new NotifyOperation( args[ 0 ] );

      notifyOperation.notifyEntry( day );

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