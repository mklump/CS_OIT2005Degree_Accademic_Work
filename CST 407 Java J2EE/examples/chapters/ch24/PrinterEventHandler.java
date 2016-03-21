// Fig. 24.11: PrinterEventHandler.java
// The class adds a listener to the broadcaster MBean and
// defines the event handlers when event occurs.

// deitel package
package com.deitel.advjhtp1.jmx.Client;

// JMX core packages
import javax.management.*;

// JDMK core packages
import com.sun.jdmk.comm.RmiConnectorClient;
import com.sun.jdmk.comm.ClientNotificationHandler;

// Deitel packages
import com.deitel.advjhtp1.jmx.Printer.*;

public class PrinterEventHandler {

   private RmiConnectorClient rmiClient;
   private PrinterEventListener eventTarget;

   // notification listener annonymous inner class
   private NotificationListener notificationListener =   
      new NotificationListener() {
         public void handleNotification(
            Notification notification, Object handback ) 
         {
            // retrieve notification type
            String notificationType = notification.getType();

            // handle different notifications  
            if ( notificationType.equals( 
               "PrinterEvent.OUT_OF_PAPER" ) ) { 
                  handleOutOfPaperEvent(); 
                  return;
            }
            
            if ( notificationType.equals( 
               "PrinterEvent.LOW_TONER" ) ) { 
                  handleLowTonerEvent(); 
                  return; 
            }

            if ( notificationType.equals( 
               "PrinterEvent.PAPER_JAM" ) ) {
                  handlePaperJamEvent();
                  return;   
            }

         } // end method handleNotification

      }; // end annonymous inner class

   // default constructor
   public PrinterEventHandler(
      RmiConnectorClient inputRmiClient,
      PrinterEventListener inputEventTarget ) 
   {
      rmiClient = inputRmiClient;
      eventTarget = inputEventTarget;
      
      // set notification push mode
        rmiClient.setMode( ClientNotificationHandler.PUSH_MODE );      
      
      // register listener
      try {
         ObjectName objectName = new ObjectName( 
            rmiClient.getDefaultDomain() 
            + ":type=" + "PrinterEventBroadcaster" );

         rmiClient.addNotificationListener( objectName,
            notificationListener, null, null );
      } 

      // if MBean does not exist in the MBean server
      catch ( InstanceNotFoundException exception) {
         exception.printStackTrace();
      }

      // if the format of the object name is wrong
      catch ( MalformedObjectNameException exception ) {
         exception.printStackTrace();
      }

   } // end PrinterEventHandler constructor
   
   // delegate out of paper event
   private void handleOutOfPaperEvent()
   {
      eventTarget.outOfPaper();
   }
   
   // delegate low toner event
   private void handleLowTonerEvent()
   {
      eventTarget.lowToner();
   }
   
   // delegate paper jam event
   private void handlePaperJamEvent()
   {
      eventTarget.paperJam();
   }
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
