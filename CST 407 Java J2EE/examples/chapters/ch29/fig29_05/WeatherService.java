// Fig. 29.5: WeatherService.java
// WeatherService provides a method to retrieve weather
// information from the National Weather Service.
package com.deitel.advjhtp1.soap.weather;

// Java core packages
import java.io.*;
import java.net.URL;
import java.util.*;

public class WeatherService {
                                   
   private Vector weatherInformation;  // WeatherBean objects

   // get weather information from NWS
   private void updateWeatherConditions()
   {
      try {
         System.out.println( "Update weather information..." );

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

         weatherInformation = new Vector(); // create Vector
         
         // create WeatherBeans containing weather data and 
         // store in weatherInformation Vector
         inputLine = in.readLine();  // get first city's data
 
         // The portion of inputLine containing relevant data 
         // is 28 characters long. If the line length is not at 
         // least 28 characters long, then done processing data.
         while ( inputLine.length() > 28 ) {

            // Prepare strings for WeatherBean for each city. 
            // First 16 characters are city name. Next, six 
            // characters are weather description. Next six 
            // characters are HI/LO or LO/HI temperature.
            weatherInformation.add( 
               inputLine.substring( 0, 16 ) );   
            weatherInformation.add( 
               inputLine.substring( 16, 22 ) );   
            weatherInformation.add( 
               inputLine.substring( 23, 29 ) );
            
            inputLine = in.readLine();  // get next city's data
         }

         in.close();  // close connection to NWS Web server  
         
         System.out.println( "Weather information updated." );
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
   public Vector getWeatherInformation() 
   {
      updateWeatherConditions();

      return weatherInformation;
   }
}
