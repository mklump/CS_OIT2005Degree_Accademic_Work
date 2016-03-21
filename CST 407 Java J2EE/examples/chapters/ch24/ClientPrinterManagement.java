// Fig. 24.12: ClientPrinterManagement.java
// This application establishes a connection to the MBeanServer
// and creates an MBean for PrinterSimulator.

// deitel package
package com.deitel.advjhtp1.jmx.Client;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// JMX core packages
import javax.management.*;

// JDMX core packages
import com.sun.jdmk.comm.RmiConnectorClient;
import com.sun.jdmk.comm.RmiConnectorAddress;

public class ClientPrinterManagement {

   private RmiConnectorClient rmiClient;

   // instantiate client connection
   public ClientPrinterManagement() 
   {
      // create connector client instance
      rmiClient = new RmiConnectorClient();
      
      // create address instance
      RmiConnectorAddress rmiAddress = 
         new RmiConnectorAddress();
      
      // specify port
      rmiAddress.setPort( 5555 );
      
      // establish connection
      rmiClient.connect( rmiAddress );

   } // end ClinetPrinterManagement constructor
   
   // return RmiConnectorClient referrence
   public RmiConnectorClient getClient() 
   {
      return rmiClient;
   }

   public static void main( String[] args ) 
   {
      // instantiate client connection
      ClientPrinterManagement clientManager = 
         new ClientPrinterManagement();
      
      // get RMIConnectorClient handle
      RmiConnectorClient client = clientManager.getClient();
      
      // start GUI
      PrinterManagementGUI printerManagementGUI = 
         new PrinterManagementGUI( client ); 
 
      // display the output
      printerManagementGUI.setSize(
         new Dimension( 500, 500 ) );
      printerManagementGUI.setVisible( true );

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
