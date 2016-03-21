// Fig. 29.4 : GetMessage.java
// Program that makes a SOAP RPC

// import Java packages
import java.io.*;
import java.net.*;
import java.util.*;

// import third-party packages
import org.apache.soap.*;
import org.apache.soap.rpc.*;

public class GetMessage {

   // main method
   public static void main( String args[] ) {
      String encodingStyleURI = Constants.NS_URI_SOAP_ENC;
      String message;

      if ( args.length != 0 )
        message = args[ 0 ];
      else
        message = "Thanks!";
 
      // attempt SOAP remote procedure call
      try {      
         URL url = new URL( 
            "http://localhost:8080/soap/servlet/rpcrouter" );

         // build call
         Call remoteMethod = new Call();
         remoteMethod.setTargetObjectURI( 
            "urn:xml-simple-message" );

         // set name of remote method to be invoked
         remoteMethod.setMethodName( "getWelcome" );
         remoteMethod.setEncodingStyleURI( encodingStyleURI );

         // set parameters for remote method
         Vector parameters = new Vector();

         parameters.addElement( new Parameter( "message", 
            String.class, message, null ) );
         remoteMethod.setParams( parameters );
         Response response;

         // invoke remote method
         response = remoteMethod.invoke( url, "" );

         // get response
         if ( response.generatedFault() ) {
            Fault fault = response.getFault();

            System.err.println( "CALL FAILED:\nFault Code = "
               + fault.getFaultCode()+ "\nFault String = " 
               + fault.getFaultString() );
         }

         else {
            Parameter result = response.getReturnValue();

            // display result of call
            System.out.println( result.getValue() );
         }
      }

      // catch malformed URL exception
      catch ( MalformedURLException malformedURLException ) {
         malformedURLException.printStackTrace();
         System.exit( 1 );
      }

      // catch SOAPException
      catch ( SOAPException soapException ) {
         System.err.println( "Error message: " +
            soapException.getMessage() );
         System.exit( 1 );
      }
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