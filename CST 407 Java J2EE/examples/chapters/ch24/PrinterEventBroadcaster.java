// Fig. 24.10: PrinterEventBroadcaster.java
// This class defines an MBean that 
// provides events information.

// deitel package
package com.deitel.advjhtp1.jmx.PrinterManagement;

// JMX core packages
import javax.management.MBeanNotificationInfo;
import javax.management.NotificationBroadcasterSupport;

// extends NotificationBroadcasterSupport to adopt its 
// functionality.
public class PrinterEventBroadcaster 
   extends NotificationBroadcasterSupport
   implements PrinterEventBroadcasterMBean {

   private static final String OUT_OF_PAPER = 
      "PrinterEvent.OUT_OF_PAPER";
   private static final String LOW_TONER = 
      "PrinterEvent.LOW_TONER";
   private static final String PAPER_JAM = 
      "PrinterEvent.PAPER_JAM";

   // provide information about deliverable events
   public MBeanNotificationInfo[] getNotificationInfo() 
   {
      // array containing descriptor objects
      MBeanNotificationInfo[] descriptorArray = 
         new MBeanNotificationInfo[ 1 ];
                
      // different event types
      String[] notificationTypes = new String[ 3 ];
      notificationTypes[ 0 ] = 
         PrinterEventBroadcaster.OUT_OF_PAPER;
      notificationTypes[ 1 ] = 
         PrinterEventBroadcaster.LOW_TONER;
      notificationTypes[ 2 ] =
         PrinterEventBroadcaster.PAPER_JAM;
      
      // notification class type
      String classType = "javax.management.Notification";
      
      // description of MBeanNotificationInfo
      String description =
         "Notification types for PrinterEventBroadcaster";
      
      // populate descriptor array
      descriptorArray[ 0 ] = new MBeanNotificationInfo( 
         notificationTypes, classType, description );
          
      return descriptorArray;   

   } // end method getNotificationInfo
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
