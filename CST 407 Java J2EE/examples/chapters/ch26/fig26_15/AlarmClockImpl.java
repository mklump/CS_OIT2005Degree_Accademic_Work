// Fig. 23.15: AlarmClockImpl.java
// Implementation of AlarmClock server.

package com.deitel.advjhtp1.idl.alarm;

// Java core packages
import java.util.*;

// Java extension packages
import org.omg.CORBA.ORB;
import org.omg.CosNaming.*;
import org.omg.CosNaming.NamingContextPackage.*;

public class AlarmClockImpl extends _AlarmClockImplBase {

   // This list contains name/alarm pairs of 
   // registered objects waiting for an alarm.
   private Hashtable alarmList = new Hashtable();

   // register AlarmClockImpl object with Naming Service
   public void register( String corbaName, String [] params )
      throws org.omg.CORBA.ORBPackage.InvalidName,
         org.omg.CosNaming.NamingContextPackage.InvalidName,
         CannotProceed, NotFound
   {
      if ( ( corbaName == null ) || 
           ( corbaName.trim().length() == 0 ) )
         throw new IllegalArgumentException(
            "Registration name can not be null or blank");

      // create and initialize ORB
      ORB orb = ORB.init( params, null );

      // register this object with ORB
      orb.connect( this );

      // retrieve reference to Naming Service
      org.omg.CORBA.Object corbaObject =
         orb.resolve_initial_references( "NameService" );
      NamingContext naming = 
         NamingContextHelper.narrow( corbaObject );

      // create NameComponent array with path information to
      // find this object
      NameComponent namingComponent = 
         new NameComponent( corbaName, "" );
      NameComponent path[] = { namingComponent };

      // bind AlarmClockImpl object with ORB
      naming.rebind( path, this );
      System.out.println( "Rebind complete" ); 
   }

   // method used by clients wanting to register
   // as callback/listener objects
   public void addAlarmListener( String listenerName,
      AlarmListener listener )
         throws DuplicateNameException
   {
      if ( listenerName == null || 
           listenerName.trim().length() == 0 )
         throw new IllegalArgumentException(
            "Name cannot be null or blank");
      else
          
         if ( alarmList.get(listenerName) != null )
            throw new DuplicateNameException(
               "Name is already registered, please choose another" );
         else
             
            if ( listener == null )
               throw new IllegalArgumentException(
                  "Listener cannot be null" );        

      // create new Timer and save it under listener name
      alarmList.put( listenerName, new AlarmTimer(listener) );
   }

   // Set an alarm for a client.  If client not registered
   // throw a runtime exception.
   public void setAlarm( String name, long seconds )
   {
      // get alarm for particular client
      AlarmTimer timer = (AlarmTimer) alarmList.get( name );

      if ( timer == null )
         throw new IllegalArgumentException(
            "No timer found for the incoming name" );
      else
         timer.schedule( new TaskWrapper(timer.getListener(),
            seconds), seconds * 1000 );
   }

   // main method to execute AlarmClock server
   public static void main (String args[]) throws Exception
   {
      AlarmClockImpl alarm = new AlarmClockImpl();
      alarm.register( AlarmClock.NAME, args );

      java.lang.Object sync = new java.lang.Object();

      // keep server alive
      synchronized( sync ) {
         sync.wait();
      }
   }

   // Every listener get an AlarmTimer assigned to them.
   private class AlarmTimer extends Timer {
       
       // The listener this Timer is assigned to.
       private AlarmListener listener;
       
       public AlarmTimer( AlarmListener l )
       {
           listener = l;
       }

       // Accessor method so we can get to the listener
       // object reference.
       public AlarmListener getListener()
       {
           return listener;
       }
   }   // end of private inner class TaskWrapper
   
   // TaskWrapper takes care of calling our clients
   // when their alarm expires.
   private class TaskWrapper extends TimerTask {

      // The reference to our listener
      private AlarmListener listener;
      private long seconds;

      // TaskWrapper needs to know who to call and
      // how long was the alarm set (in seconds).
      public TaskWrapper( AlarmListener l, long s )
      {
         listener = l;
         seconds = s;
      }
      
      public void run()
      {
         // Go wake them up!
         listener.updateTime(seconds);
         
         // Discard this TaskWrapper.  When the client
         // wants a new alarm we create a new TaskWrapper.
         this.cancel();
      }
   }   // end of private inner class TaskWrapper   
}  // end class AlarmClockImpl

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
