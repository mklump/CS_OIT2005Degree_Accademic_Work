// Fig. 26.4: SystemClockClient.java
// Client application for the SystemClock example.

package com.deitel.advjhtp1.idl.clock;

// Java core packages
import java.text.DateFormat;
import java.util.*;

// Java extension packages
import javax.swing.JOptionPane;

// OMG CORBA packages
import org.omg.CORBA.ORB;
import org.omg.CosNaming.*;
import org.omg.CosNaming.NamingContextPackage.*;

public class SystemClockClient implements Runnable {
   private SystemClock timeServer;

   // initialize client
   public SystemClockClient( String [] params ) throws Exception
   {
      connectToTimeServer( params );
      startTimer();
   }

   // use NameService to connect to time server
   private void connectToTimeServer( String [] params )
      throws org.omg.CORBA.ORBPackage.InvalidName,
         org.omg.CosNaming.NamingContextPackage.InvalidName,
         NotFound, CannotProceed
   {
      // Connect to SystemClock server
      ORB orb = ORB.init( params, null );

      org.omg.CORBA.Object corbaObject =
         orb.resolve_initial_references("NameService");
      NamingContext naming =
         NamingContextHelper.narrow( corbaObject );

      // Resolve object reference in naming
      NameComponent nameComponent = 
         new NameComponent( "TimeServer", "" );
      NameComponent path[] = { nameComponent };
      corbaObject = naming.resolve( path );
      timeServer = SystemClockHelper.narrow( corbaObject );
   }

   // start timer thread
   private void startTimer()
   {
      Thread thread = new Thread( this );
      thread.start();
   }

   // Talk to server on regular basis and display results
   public void run()
   {
      long time = 0;
      Date date = null;
      DateFormat format = 
         DateFormat.getTimeInstance( DateFormat.LONG );
      String timeString = null;
      int response = 0;

      while( true ) {
         time = timeServer.currentTimeMillis();
         date = new Date( time );
         timeString = format.format( date );

         response = JOptionPane.showConfirmDialog( null, timeString,
            "SystemClock Example", JOptionPane.OK_CANCEL_OPTION );

         if ( response == JOptionPane.CANCEL_OPTION )
            break;  // Get us out of here
      }

      System.exit( 0 );
   }

   // Main method to execute client application
   public static void main (String args[])
   {
      // create client
      try {
         new SystemClockClient( args );
      }

      // process exceptions that occur while client executes
      catch ( Exception exception ) {
         System.out.println( 
            "Exception thrown by SystemClockClient:" );
         exception.printStackTrace();
      }
   }

}   // end of class SystemClockClient

/**************************************************************************
 * (C) Copyright 2001 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
