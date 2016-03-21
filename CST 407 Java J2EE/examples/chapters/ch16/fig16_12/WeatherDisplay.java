// WeatherDisplay.java
// WeatherDisplay extends JPanel to display results
// of client's request for weather conditions.
package com.deitel.advjhtp1.jms.weather;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.util.*;

// Java extension packages
import javax.swing.*;

// Deitel packages
import com.deitel.advjhtp1.rmi.weather.*;

public class WeatherDisplay extends JPanel {

   // WeatherListModel and Map for storing WeatherBeans
   private WeatherListModel weatherListModel;
   private Map weatherItems;

   // WeatherDisplay constructor
   public WeatherDisplay()
   {
      setLayout( new BorderLayout() );
      
      ImageIcon headerImage = new ImageIcon( 
         WeatherDisplay.class.getResource( 
            "images/header.jpg" ) );
      add( new JLabel( headerImage ), BorderLayout.NORTH );

      // use JList to display updated weather conditions
      // for requested cities
      weatherListModel = new WeatherListModel();
      JList weatherJList = new JList( weatherListModel );
      weatherJList.setCellRenderer( new WeatherCellRenderer() );

      add( new JScrollPane( weatherJList ), BorderLayout.CENTER );

      // maintain WeatherBean items in HashMap 
      weatherItems = new HashMap();
      
   } // end WeatherDisplay constructor

   // add WeatherBean item to display
   public void addItem( WeatherBean weather )
   {
      String city = weather.getCityName();

      // check whether city is already in display
      if ( weatherItems.containsKey( city ) ) {

         // if city is in Map, and therefore in display
         // remove previous WeatherBean object
         WeatherBean previousWeather = 
            ( WeatherBean ) weatherItems.remove( city );
         weatherListModel.remove( previousWeather ); 
      }
      
      // add WeatherBean to Map and WeatherListModel
      weatherListModel.add( weather );
      weatherItems.put( city, weather );

   } // end method addItem

   // clear all cities from display
   public void clearCities()
   {
      weatherItems.clear();
      weatherListModel.clear();
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
