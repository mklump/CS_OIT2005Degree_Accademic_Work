// Fig. 29.6: WeatherServiceClient.java
// WeatherServiceClient accesses the WeatherService remote
// object via SOAP to retrieve weather information.
package com.deitel.advjhtp1.soap.weather;

// Java core packages
import java.util.*;
import java.net.*;

// Java extension packages
import javax.swing.*;

// third-party packages
import org.apache.soap.*;
import org.apache.soap.rpc.*;

// Deitel packages
import com.deitel.advjhtp1.rmi.weather.*;

public class WeatherServiceClient extends JFrame {

   // WeatherServiceClient constructor
   public WeatherServiceClient( String server ) 
   {
      super( "SOAP WeatherService Client" ); 
      
      // connect to server and get weather information
      try {

         // URL of remote SOAP object
         URL url = new URL( "http://" + server + ":8080/soap/"
            + "servlet/rpcrouter" );

         // build SOAP RPC call
         Call remoteMethod = new Call();
         remoteMethod.setTargetObjectURI( 
            "urn:xml-weather-service" );

         // set name of remote method to be invoked
         remoteMethod.setMethodName( 
            "getWeatherInformation" );
         remoteMethod.setEncodingStyleURI( 
            Constants.NS_URI_SOAP_ENC );

         // invoke remote method
         Response response = remoteMethod.invoke( url, "" );

         // get response
         if ( response.generatedFault() ) {
            Fault fault = response.getFault();

            System.err.println( "CALL FAILED:\nFault Code = "
               + fault.getFaultCode() + "\nFault String = "
               + fault.getFaultString() );
         }

         else {
            Parameter result = response.getReturnValue();

            Vector weatherStrings = ( Vector ) 
               result.getValue();

            // get weather information from result object
            List weatherInformation = createBeans( 
               weatherStrings );

            // create WeatherListModel for weather information
            ListModel weatherListModel = 
               new WeatherListModel( weatherInformation );

            // create JList, set its CellRenderer and add to 
            // layout
            JList weatherJList = new JList( weatherListModel );
            weatherJList.setCellRenderer( new 
               WeatherCellRenderer() );
            getContentPane().add( new 
               JScrollPane( weatherJList ) );
         }

      } // end try
      
      // handle bad URL
      catch ( MalformedURLException malformedURLException ) {
         malformedURLException.printStackTrace();
      }
      
      // handle SOAP exception
      catch ( SOAPException soapException ) {
         soapException.printStackTrace();
      }
      
   } // end WeatherServiceClient constructor

   // create List of WeatherBeans from Vector of Strings
   public List createBeans( Vector weatherStrings )
   {
      List list = new ArrayList();
      for ( int i = 0; ( weatherStrings.size() - 1 ) > i; 
         i += 3 ) {
         list.add( new WeatherBean( 
            ( String ) weatherStrings.elementAt( i ), 
            ( String ) weatherStrings.elementAt( i + 1 ), 
            ( String ) weatherStrings.elementAt( i + 2 ) ) );
      }

      return list;
   }

   // execute WeatherServiceClient
   public static void main( String args[] )
   {
      WeatherServiceClient client = null;

      // if no server IP address or host name specified,
      // use "localhost"; otherwise use specified host
      if ( args.length == 0 )
         client = new WeatherServiceClient( "localhost" );
      else
         client = new WeatherServiceClient( args[ 0 ] );

      // configure and display application window
      client.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );
      client.pack();
      client.setResizable( false ); 
      client.setVisible( true );  
   }
}
