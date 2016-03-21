// Fig. 24.8: PrinterManagementAgent.java
// This application creates an MBeanServer and starts an RMI
// connector MBean service.

// deitel package
package com.deitel.advjhtp1.jmx.PrinterManagement;

// JMX core packages
import javax.management.*;

public class PrinterManagementAgent {

   public static void main( String[] args ) 
   {
      ObjectInstance rmiConnectorServer = null;
      ObjectInstance printer = null;
      ObjectInstance broadcaster = null;
      ObjectName objectName = null;

      // create an MBeanServer
      MBeanServer server = 
         MBeanServerFactory.createMBeanServer();

      // create an RMI connector service, a printer simulator
      // MBean and a broadcaster MBean
      try {

         // create an RMI connector server
         rmiConnectorServer = server.createMBean (
            "com.sun.jdmk.comm.RmiConnectorServer", null );

         // create a broadcaster MBean
         String name = server.getDefaultDomain() 
            + ":type=" + "PrinterEventBroadcaster";
         String className = "com.deitel.advjhtp1.jmx."
            + "PrinterManagement.PrinterEventBroadcaster";

         objectName = new ObjectName( name );
         printer = server.createMBean( 
            className, objectName );   

         // create a printer simulator MBean
         name = server.getDefaultDomain()
            + ":type=" + "Printer";
         className =  "com.deitel.advjhtp1.jmx." 
            + "PrinterManagement.Printer";
   
         objectName = new ObjectName( name );
         broadcaster = server.createMBean(
            className, objectName );

      } // end try

      // handle class not JMX-compliant MBean exception
      catch ( NotCompliantMBeanException exception ) {
         exception.printStackTrace();
      }

      // handle MBean constructor exception
      catch ( MBeanException exception ) {
         exception.printStackTrace();
      }

      // handle MBean already exists exception
      catch ( InstanceAlreadyExistsException exception ) {
         exception.printStackTrace();
      }

      // handle MBean constructor exception
      catch ( ReflectionException exception ) {
         exception.printStackTrace();
      }

      // handle invalid object name exception
      catch ( MalformedObjectNameException exception) {
         exception.printStackTrace();
      }
                
      // set port number
      Object[] parameter = new Object[ 1 ];
      parameter[ 0 ] = new Integer( 5555  );
      String[] signature = new String[ 1 ];
      signature[ 0 ] = "int";

      // invoke method setPort on RmiConnectorServer MBean
      // start the RMI connector service
      try {
         server.invoke( 
            rmiConnectorServer.getObjectName(), "setPort",
            parameter, signature );
         server.invoke( 
            rmiConnectorServer.getObjectName(), "start" ,
            new Object[ 0 ], new String[ 0 ] );
      } 

      // handle exception when executing method
      catch ( ReflectionException exception ) {
         exception.printStackTrace();
      }

      // handle exception communicating with MBean
      catch ( MBeanException exception ) {
         exception.printStackTrace();
      }

      // handle exception if MBean not found
      catch ( InstanceNotFoundException exception ) {
         exception.printStackTrace();
      } 

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
