// WeatherServiceClient.java 
// WeatherServiceClient uses the WeatherService remote object
// to retrieve weather information.
package com.deitel.advjhtp1.rmi.weather;

// Java core packages
import java.rmi.*;   
import java.util.*;

// Java extension packages
import javax.swing.*;

public class WeatherServiceClient extends JFrame
{   
   // WeatherServiceClient constructor
   public WeatherServiceClient( String server ) 
   {
      super( "RMI WeatherService Client" ); 
      
      // connect to server and get weather information
      try {
                 
         // name of remote server object bound to rmi registry
         String remoteName = "rmi://" + server + "/WeatherService";

         // lookup WeatherServiceImpl remote object
         WeatherService weatherService = 
            ( WeatherService ) Naming.lookup( remoteName );

         // get weather information from server
         List weatherInformation = new ArrayList( 
            weatherService.getWeatherInformation() );   

         // create WeatherListModel for weather information
         ListModel weatherListModel = 
            new WeatherListModel( weatherInformation );

         // create JList, set ListCellRenderer and add to layout
         JList weatherJList = new JList( weatherListModel );
         weatherJList.setCellRenderer( new WeatherCellRenderer() );
         getContentPane().add( new JScrollPane( weatherJList ) );

      } // end try
      
      // handle exception connecting to remote server
      catch ( ConnectException connectionException ) {
         System.err.println( "Connection to server failed. " +
            "Server may be temporarily unavailable." );
         
         connectionException.printStackTrace();
      }
      
      // handle exceptions communicating with remote object
      catch ( Exception exception ) {
         exception.printStackTrace();
      }
      
   } // end WeatherServiceClient constructor
   
   public static Thread getWeather( String server )
   {
       WeatherServiceClient client = null;

       // if no sever IP address or host name specified,
       // use "localhost"; otherwise use specified host
       if ( server.length() == 0 )
           client = new WeatherServiceClient( "localhost" );
       else
           client = new WeatherServiceClient( server );

       // configure and display application window
       client.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );
       client.pack();
       client.setResizable( false );
       client.setVisible( true );
       
       return Thread.currentThread();
   }

   // execute WeatherServiceClient
   public static void main( String args[] )
   {
       try
       {
           while( true )
           {
               Thread mainThread = Thread.currentThread();
               String args_ = null;
               if( args.length == 0 )
                   args_ = new String( "localhost" );
               
               // Execute this portion of the thread main() now and every six hours
               Thread thisThread = getWeather( args_ );
               thisThread.join();
               
               mainThread.sleep( 21600000 ); // Make this thread wait every 6 hours

               mainThread = new Thread();
               mainThread.start();
           }
       }
       catch( InterruptedException e )
       {
           System.out.println( e.getMessage() );
           e.printStackTrace();
       }
   }
}
