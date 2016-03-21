// WeatherServiceImpl.java
// WeatherServiceImpl implements the WeatherService remote
// interface to provide a WeatherService remote object.
package com.deitel.advjhtp1.rmi.weather;

// Java core packages
import java.io.*;
import java.net.URL;
import java.rmi.*;
import java.rmi.server.*;
import java.util.*;

public class WeatherServiceImpl extends UnicastRemoteObject
   implements WeatherService {
                                   
   private List weatherInformation;  // WeatherBean objects

   // initialize server
   public WeatherServiceImpl() throws RemoteException
   {
      super();
      updateWeatherConditions();
   }

   // get weather information from NWS
   private void updateWeatherConditions()
   {
      try {
         System.err.println( "Update weather information..." );

         // National Weather Service Travelers Forecast page
         URL url = new URL(
            "http://iwin.nws.noaa.gov/iwin/us/traveler.html" );

         // set up text input stream to read Web page contents
         BufferedReader in = new BufferedReader(
            new InputStreamReader( url.openStream() ) );

         // helps determine starting point of data on Web page
         String separator = "TAV12";  

         // locate separator string in Web page
         while ( !in.readLine().startsWith( separator ) )
            ;    // do nothing

         // strings representing headers on Travelers Forecast
         // Web page for daytime and nighttime weather
         String dayHeader =
            "CITY            WEA     HI/LO   WEA     HI/LO";
         String nightHeader =
            "CITY            WEA     LO/HI   WEA     LO/HI";
         
         String inputLine = "";

         // locate header that begins weather information
         do {
            inputLine = in.readLine();
         } while ( !inputLine.equals( dayHeader ) &&
                   !inputLine.equals( nightHeader ) );

         weatherInformation = new ArrayList(); // create List
         
         // create WeatherBeans containing weather data and 
         // store in weatherInformation Vector
         inputLine = in.readLine();  // get first city's info
 
         // The portion of inputLine containing relevant data is
         // 28 characters long. If the line length is not at 
         // least 28 characters long, done processing data.
         while ( inputLine.length() > 28 ) {

            // Create WeatherBean object for city. First 16 
            // characters are city name. Next, six characters
            // are weather description. Next six characters
            // are HI/LO or LO/HI temperature.
            WeatherBean weather = new WeatherBean(
               inputLine.substring( 0, 16 ),   
               inputLine.substring( 16, 22 ),   
               inputLine.substring( 23, 29 ) );

            // add WeatherBean to List
            weatherInformation.add( weather ); 
            
            inputLine = in.readLine();  // get next city's info
         }

         in.close();  // close connection to NWS Web server  
         
         System.err.println( "Weather information updated." );
      }
      
      // process failure to connect to National Weather Service
      catch( java.net.ConnectException connectException ) {
         connectException.printStackTrace();
         System.exit( 1 );
      }
      
      // process other exceptions
      catch( Exception exception ) {
         exception.printStackTrace();
         System.exit( 1 );
      }
   }

   // implementation for WeatherService interface method
   public List getWeatherInformation() throws RemoteException 
   {
      return weatherInformation;
   }

   // launch WeatherService remote object
   public static void main( String args[] ) throws Exception
   {     
      System.err.println( "Initializing WeatherService..." );

      // create remote object
      WeatherService service = new WeatherServiceImpl();

      // specify remote object name
      String serverObjectName = "rmi://localhost/WeatherService";
      
      // bind WeatherService remote object in rmiregistry
      Naming.rebind( serverObjectName, service );
      
      System.err.println( "WeatherService running." );
   }
}


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
