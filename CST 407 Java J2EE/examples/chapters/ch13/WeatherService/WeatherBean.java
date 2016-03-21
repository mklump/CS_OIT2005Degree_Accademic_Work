// WeatherBean.java
// WeatherBean maintains weather information for one city.
package com.deitel.advjhtp1.rmi.weather;

// Java core packages
import java.awt.*;
import java.io.*;
import java.net.*;
import java.util.*;

// Java extension packages
import javax.swing.*;

public class WeatherBean implements Serializable {
   
   private String cityName;         // name of city
   private String temperature;      // city's temperature
   private String description;      // weather description
   private ImageIcon image;         // weather image

   private static Properties imageNames; 
   
   // initialize imageNames when class WeatherInfo 
   // is loaded into memory
   static {
      imageNames = new Properties(); // create properties table
      
      // load weather descriptions and image names from 
      // properties file
      try {
         
         // obtain URL for properties file
         URL url = WeatherBean.class.getResource( 
            "imagenames.properties" );
         
         // load properties file contents
         imageNames.load( new FileInputStream( url.getFile() ) );
      }
      
      // process exceptions from opening file
      catch ( IOException ioException ) {     
         ioException.printStackTrace();
      }

   } // end static block
   
   // WeatherBean constructor
   public WeatherBean( String city, String weatherDescription, 
      String cityTemperature )
   {
      cityName = city;
      temperature = cityTemperature;
      description = weatherDescription.trim();
      
      URL url = WeatherBean.class.getResource( "images/" + 
         imageNames.getProperty( description, "noinfo.jpg" ) );      

      // get weather image name or noinfo.jpg if weather 
      // description not found
      image = new ImageIcon( url );
   }

   // get city name
   public String getCityName() 
   { 
      return cityName; 
   }

   // get temperature
   public String getTemperature() 
   {
      return temperature; 
   }

   // get weather description
   public String getDescription() 
   {
      return description; 
   }

   // get weather image
   public ImageIcon getImage() 
   {      
      return image; 
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
