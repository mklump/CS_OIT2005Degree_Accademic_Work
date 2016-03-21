// WeatherSubscriber.java
// WeatherSubscriber presents a GUI for the client to request
// weather conditions for various cities. The WeatherSubscriber
// retrieves the weather conditions from the Weather topic;
// each message body contains a WeatherBean object. The message
// header contains a String property "City," which allows
// the client to select the desired cities.
package com.deitel.advjhtp1.jms.weather;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;
import javax.naming.*;
import javax.jms.*;

public class WeatherSubscriber extends JFrame {

   // GUI variables
   private WeatherDisplay weatherDisplay;
   private JList citiesList;

   // cities contains cities for which weather
   // updates are available on "Weather" topic
   private String cities[] = { "ALBANY NY", "ANCHORAGE", 
      "ATLANTA", "ATLANTIC CITY", "BOSTON", "BUFFALO", 
      "BURLINGTON VT", "CHARLESTON WV", "CHARLOTTE", "CHICAGO", 
      "CLEVELAND", "DALLAS FT WORTH", "DENVER", "DETROIT", 
      "GREAT FALLS", "HARTFORD SPGFLD", "HONOLULU", 
      "HOUSTON INTCNTL", "KANSAS CITY", "LAS VEGAS", 
      "LOS ANGELES", "MIAMI BEACH", "MPLS ST PAUL", "NEW ORLEANS", 
      "NEW YORK CITY", "NORFOLK VA", "OKLAHOMA CITY", "ORLANDO", 
      "PHILADELPHIA", "PHOENIX", "PITTSBURGH", "PORTLAND ME", 
      "PORTLAND OR", "RENO" };

   // JMS variables
   private TopicConnection topicConnection;
   private TopicSession topicSession;
   private Topic topic;
   private TopicSubscriber topicSubscriber;
   private WeatherListener topicListener;

   // WeatherSubscriber constructor
   public WeatherSubscriber()
   {
      super( "JMS WeatherSubscriber..." );
      weatherDisplay = new WeatherDisplay();

      // set up JNDI context and JMS connections
      try {

         // create JNDI context
         Context jndiContext = new InitialContext();
  
         // retrieve topic connection factory 
         // from JNDI context
         TopicConnectionFactory topicConnectionFactory =
            ( TopicConnectionFactory ) jndiContext.lookup( 
               "WEATHER_FACTORY" );

         // retrieve topic from JNDI context
         String topicName = "Weather";
         topic = ( Topic ) jndiContext.lookup( topicName );

         // create topic connection
         topicConnection = 
            topicConnectionFactory.createTopicConnection();

         // create topic session
         topicSession = topicConnection.createTopicSession( false,
            Session.AUTO_ACKNOWLEDGE );

         // initialize listener 
         topicListener = new WeatherListener( weatherDisplay );
      }
      
      // process Naming exception from JNDI context
      catch ( NamingException namingException ) {
         namingException.printStackTrace();
      }
      
      // process JMS exceptions from topic connection or session
      catch ( JMSException jmsException ) {
         jmsException.printStackTrace();
      }
      
      // lay out user interface
      Container container = getContentPane();
      container.setLayout( new BorderLayout() );

      JPanel selectionPanel = new JPanel();
      selectionPanel.setLayout( new BorderLayout() );
      
      JLabel selectionLabel = new JLabel( "Select Cities" );
      selectionPanel.add( selectionLabel, BorderLayout.NORTH );

      // create list of cities for which users
      // can request weather updates
      citiesList = new JList( cities );
      selectionPanel.add( new JScrollPane( citiesList ),
         BorderLayout.CENTER );

      JButton getWeatherButton = new JButton( "Get Weather..." );
      selectionPanel.add( getWeatherButton, BorderLayout.SOUTH );

      // invoke method getWeather when getWeatherButton clicked
      getWeatherButton.addActionListener (
 
         new ActionListener() {
     
            public void actionPerformed ( ActionEvent event ) 
            {
               getWeather();
            }
         }
         
      ); // end call to addActionListener

      container.add( selectionPanel, BorderLayout.WEST );
      container.add( weatherDisplay, BorderLayout.CENTER );

      // invoke method quit when window closed
      addWindowListener(

         new WindowAdapter() {

            public void windowClosing( WindowEvent event ) 
            {
               quit();
            }
         }
         
      ); // end call to addWindowListener

   } // end WeatherSubscriber constructor

   // get weather information for selected cities
   public void getWeather()
   {
      // retrieve selected indices
      int selectedIndices[] = citiesList.getSelectedIndices();
      
      if ( selectedIndices.length > 0 ) {

         // if topic subscriber exists, method has
         // been called before
         if ( topicSubscriber != null ) {
    
            // close previous topic subscriber
            try {
               topicSubscriber.close(); 
            }

            // process JMS exception
            catch ( JMSException jmsException ) {
               jmsException.printStackTrace();
            }

            // clear previous cities from display
            weatherDisplay.clearCities();
         }
   
         // create message selector to retrieve specified cities
         StringBuffer messageSelector = new StringBuffer();
         messageSelector.append( 
            "City = '" + cities[ selectedIndices[ 0 ] ] + "'" );

         for ( int i = 1; i < selectedIndices.length; i++ ) {
            messageSelector.append( " OR City = '" +
               cities[ selectedIndices[ i ] ] + "'" );
         }

         // create topic subscriber and subscription
         try {
            topicSubscriber = topicSession.createSubscriber( 
               topic, messageSelector.toString(), false );
            topicSubscriber.setMessageListener( topicListener );
            topicConnection.start();
 
            JOptionPane.showMessageDialog( this,
               "A weather update should be arriving soon..." );
         }

         // process JMS exception
         catch ( JMSException jmsException ) {
            jmsException.printStackTrace();
         }
         
      } // end if

   } // end method getWeather

   // quit WeatherSubscriber application
   public void quit()
   {
      // close connection and subscription to topic
      try {

         // close topic subscriber
         if ( topicSubscriber != null ) {
            topicSubscriber.close(); 
         }

         // close topic connection 
         topicConnection.close();
      }

      // process JMS exception
      catch ( JMSException jmsException ) {
         jmsException.printStackTrace();
         System.exit( 1 );
      }

      System.exit( 0 );
      
   } // end method quit

   // launch WeatherSubscriber application
   public static void main( String args [] )
   {
      WeatherSubscriber subscriber = new WeatherSubscriber();
      subscriber.pack();
      subscriber.setVisible( true );
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
