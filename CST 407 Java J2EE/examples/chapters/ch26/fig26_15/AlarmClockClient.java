// Fig. 23.17: AlarmClockClient.java
// Client of the AlarmClock service

package com.deitel.advjhtp1.idl.alarm;

// OMG CORBA packages
import org.omg.CORBA.ORB;
import org.omg.CosNaming.*;
import org.omg.CosNaming.NamingContextPackage.*;

public class AlarmClockClient extends _AlarmListenerImplBase {

   // Reference to the GUI to be displayed
   private ClockClientGUI gui;

   // Reference to the alarm clock server we connect to
   private AlarmClock alarmClock;

   // Name of this client used by server to make proper callback
   private String name;

   public AlarmClockClient( String params[] ) throws Exception
   {
      // create displayable name that is unique among VMs
      // running on same computer
      name = new Long( 
         System.currentTimeMillis() % 10000 ).toString();

      // create GUI to display name and
      // number of seconds before alarm expires
      gui = new ClockClientGUI();

      // connect to TimeService
      connectToAlarmServer( name, params );

      // display GUI and wait for user to terminate app.
      gui.show();
   }

   // perform connection to AlarmServer
   private void connectToAlarmServer( 
      String name, String params[] )
      throws org.omg.CORBA.ORBPackage.InvalidName,
         org.omg.CosNaming.NamingContextPackage.InvalidName,
         NotFound, CannotProceed,
         DuplicateNameException
   {
      // connect AlarmClockClient to an ORB
      ORB orb = ORB.init( params, null );

      // connect to Naming Service and find object
      // reference for AlarmClock service
      org.omg.CORBA.Object corbaObject =
         orb.resolve_initial_references( "NameService" );
      NamingContext naming = 
         NamingContextHelper.narrow( corbaObject );

      // resolve object reference in naming
      NameComponent nameComponent =
         new NameComponent( AlarmClock.NAME, "" );
      NameComponent path[] = { nameComponent };
      alarmClock =
         AlarmClockHelper.narrow( naming.resolve( path ) );

      // register this object with AlarmClock service
      alarmClock.addAlarmListener( name, this );
      gui.show();
      updateTime( 0 );
   }

   // The callback method defined in AlarmListener.
   public void updateTime(long seconds)
   {
      // Make up a length of time to use for the alarm setting.
      long newTime = (int)(Math.random() * 10.0) + 1;
      gui.setText("Alarm " + name + " came in at " + seconds
         + " seconds.  Resetting to " + newTime + " seconds" );
      alarmClock.setAlarm( name, newTime );
   }

   // main method to execute client
   public static void main( String args[] ) throws Exception
   {
      // create client
      try {
         AlarmClockClient client = new AlarmClockClient( args );
      }

      // process exceptions that occur while client executes
      catch ( Exception exception ) {
         System.out.println(
            "Exception thrown by AlarmClockClient:" );
         exception.printStackTrace();
      }
   }

}   // end of class AlarmClockClient

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
