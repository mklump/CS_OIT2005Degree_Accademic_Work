// WeatherItem.java
// WeatherItem displays a city's weather information in a JPanel.
package com.deitel.advjhtp1.rmi.weather;

// Java core packages
import java.awt.*;
import java.net.*;
import java.util.*;

// Java extension packages
import javax.swing.*;

public class WeatherItem extends JPanel { 
   
   private WeatherBean weatherBean;  // weather information

   // background ImageIcon
   private static ImageIcon backgroundImage;
   
   // static initializer block loads background image when class
   // WeatherItem is loaded into memory
   static {
      
      // get URL for background image
      URL url = WeatherItem.class.getResource( "images/back.jpg" );

      // background image for each city's weather info
      backgroundImage = new ImageIcon( url );
   }
  
   // initialize a WeatherItem
   public WeatherItem( WeatherBean bean )
   {
      weatherBean = bean;
   }

   // display information for city's weather
   public void paintComponent( Graphics g )
   {
      super.paintComponent( g );
      
      // draw background
      backgroundImage.paintIcon( this, g, 0, 0 );
      
      // set font and drawing color,
      // then display city name and temperature
      Font font = new Font( "SansSerif", Font.BOLD, 12 );
      g.setFont( font );
      g.setColor( Color.white );
      g.drawString( weatherBean.getCityName(), 10, 19 );
      g.drawString( weatherBean.getTemperature(), 130, 19 );

      // display weather image
      weatherBean.getImage().paintIcon( this, g, 253, 1 );

   } // end method paintComponent

   // make WeatherItem's preferred size the width and height of
   // the background image
   public Dimension getPreferredSize()
   {
      return new Dimension( backgroundImage.getIconWidth(),
         backgroundImage.getIconHeight() );
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
