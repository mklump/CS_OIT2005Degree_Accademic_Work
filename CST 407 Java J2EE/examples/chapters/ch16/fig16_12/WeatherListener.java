// WeatherListener.java
// WeatherListener is the MessageListener for a subscription
// to the Weather topic. It implements the specified onMessage
// method to update the GUI with the corresponding city's
// weather.
package com.deitel.advjhtp1.jms.weather;

// Java extension packages
import javax.jms.*;
import javax.swing.*;

// Deitel packages
import com.deitel.advjhtp1.rmi.weather.WeatherBean;

public class WeatherListener implements MessageListener {

   private WeatherDisplay weatherDisplay;

   // WeatherListener constructor
   public WeatherListener( WeatherDisplay display )
   {
      weatherDisplay = display;
   }

   // receive new message
   public void onMessage( Message message )
   {
      // retrieve and process message
      try {

         // ensure Message is an ObjectMessage
         if ( message instanceof ObjectMessage ) {
            
            // get WeatherBean from ObjectMessage
            ObjectMessage objectMessage = 
               ( ObjectMessage ) message;
            WeatherBean weatherBean =
               ( WeatherBean ) objectMessage.getObject();
            
            // add WeatherBean to display
            weatherDisplay.addItem( weatherBean );
            
         } // end if

         else {
            System.out.println( "Expected ObjectMessage," +
               " but received " + message.getClass().getName() );
         }
         
      } // end try

      // process JMS exception from message
      catch ( JMSException jmsException ) {
         jmsException.printStackTrace();
      }
      
   } // end method onMessage
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
