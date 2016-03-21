// WeatherPublisher.java
// WeatherPublisher retrieves weather conditions from the National
// Weather Service and publishes them to the Weather topic 
// as ObjectMessages containing WeatherBeans. The city name is 
// used in a String property "City" in the message header.
package com.deitel.advjhtp1.jms.weather;

// Java core packages
import java.io.*;
import java.net.*;
import java.util.*;

// Java extension packages
import javax.jms.*;
import javax.naming.*;

// Deitel packages
import com.deitel.advjhtp1.rmi.weather.WeatherBean;

public class WeatherPublisher extends TimerTask {

   private BufferedReader in;
   private TopicConnection topicConnection;
   
   // WeatherPublisher constructor
   public WeatherPublisher()
   {
      // update weather conditions every minute
      Timer timer = new Timer();
      timer.scheduleAtFixedRate( this, 0, 60000 );

      // allow user to quit
      InputStreamReader inputStreamReader =
         new InputStreamReader( System.in );
      char answer = '\0';

      // loop until user enters q or Q
      while ( !( ( answer == 'q' ) || ( answer == 'Q' ) ) ) {

         // read in character
         try {
            answer = ( char ) inputStreamReader.read();
         }

         // process IO exception
         catch ( IOException ioException ) {
            ioException.printStackTrace();
            System.exit( 1 );
         }
         
      } // end while

      // close connections
      try {

         // close topicConnection if it exists
         if ( topicConnection != null ) {
            topicConnection.close();
         }

         in.close();  // close connection to NWS Web server 
         timer.cancel();  // stop timer
      }

      // process JMS exception from closing topic connection
      catch ( JMSException jmsException ) {
         jmsException.printStackTrace();
         System.exit( 1 );
      }

      // process IO exception from closing connection
      // to NWS Web server
      catch ( IOException ioException ) {
         ioException.printStackTrace();
         System.exit( 1 );
      }

      System.exit( 0 );
      
   } // end WeatherPublisher constructor

   // get weather information from NWS
   public void run()
   {
      // connect to topic "Weather"
      try {         
         System.out.println( "Update weather information..." );

         // create JNDI context
         Context jndiContext = new InitialContext();
         String topicName = "Weather";

         // retrieve topic connection factory and topic
         // from JNDI context
         TopicConnectionFactory topicConnectionFactory =
            ( TopicConnectionFactory )
            jndiContext.lookup( "WEATHER_FACTORY" );
         
         Topic topic =
            ( Topic ) jndiContext.lookup( topicName );

         // create connection, session, publisher and message
         topicConnection = 
            topicConnectionFactory.createTopicConnection();
         
         TopicSession topicSession =
            topicConnection.createTopicSession( false,
               Session.AUTO_ACKNOWLEDGE );
         
         TopicPublisher topicPublisher = 
            topicSession.createPublisher( topic );
         
         ObjectMessage message =
            topicSession.createObjectMessage();

         // connect to National Weather Service
         // and publish conditions to topic
 
         // National Weather Service Travelers Forecast page
         URL url = new URL(
            "http://iwin.nws.noaa.gov/iwin/us/traveler.html" );

         // set up text input stream to read Web page contents
         in = new BufferedReader(
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
         }

         while ( !inputLine.equals( dayHeader ) &&
            !inputLine.equals( nightHeader ) );

         // create WeatherBean objects for each city's data
         // publish to Weather topic using city as message's type
         inputLine = in.readLine();  // get first city's info
 
         // the portion of inputLine containing relevant data is
         // 28 characters long. If the line length is not at 
         // least 28 characters long, done processing data.
         while ( inputLine.length() > 28 ) {
 
            // create WeatherBean object for city
            // first 16 characters are city name
            // next six characters are weather description
            // next six characters are HI/LO temperature
            WeatherBean weather = new WeatherBean(
               inputLine.substring( 0, 16 ).trim(),   
               inputLine.substring( 16, 22 ).trim(),   
               inputLine.substring( 23, 29 ).trim() );
  
            // publish WeatherBean object with city name
            // as a message property, 
            // used for selection by clients
            message.setObject( weather );
            message.setStringProperty( "City",
               weather.getCityName() );
            topicPublisher.publish( message );
    
            System.out.println( "published message for city: "
               + weather.getCityName() );
  
            inputLine = in.readLine();  // get next city's info
         }
 
         System.out.println( "Weather information updated." );
         
      } // end try

      // process Naming exception from JNDI context
      catch ( NamingException namingException ) {
         namingException.printStackTrace();
         System.exit( 1 );
      }

      // process JMS exception from connection,
      // session, publisher or message
      catch ( JMSException jmsException ) {
         jmsException.printStackTrace();
         System.exit( 1 );
      }
   
      // process failure to connect to National Weather Service
      catch ( java.net.ConnectException connectException ) {
         connectException.printStackTrace();
         System.exit( 1 );
      }
      
      // process other exceptions
      catch ( Exception exception ) {
         exception.printStackTrace();
         System.exit( 1 );
      }

   } // end method run

   // launch WeatherPublisher
   public static void main( String args[] )
   {     
      System.err.println( "Initializing server...\n" +
         "Enter 'q' or 'Q' to quit" );
      
      WeatherPublisher publisher = new WeatherPublisher();
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
