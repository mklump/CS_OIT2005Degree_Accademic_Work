// AssetPieChartView.java
// AssetPieChartView is an AbstractAccountView subclass that
// displays multiple asset Account balances as a pie chart.
package com.deitel.advjhtp1.mvc.account;

// Java core packages
import java.awt.*;
import java.util.*;
import java.util.List;

// Java extension packages
import javax.swing.*;
import javax.swing.border.*;

public class AssetPieChartView extends JPanel 
   implements Observer {
   
   // Set of observed Accounts
   private List accounts = new ArrayList();
   
   // Map of Colors for drawing pie chart wedges
   private Map colors = new HashMap();
   
   // add Account to pie chart view
   public void addAccount( Account account )
   {   
      // do not add null Accounts
      if ( account == null )
         throw new NullPointerException();
      
      // add Account to accounts Vector
      accounts.add( account );
      
      // add Color to Hashtable for drawing Account's wedge
      colors.put( account, getRandomColor() );     
      
      // register as Observer to receive Account updates
      account.addObserver( this );
      
      // update display with new Account information
      repaint();
   }
   
   // remove Account from pie chart view
   public void removeAccount( Account account )
   {
      // stop receiving updates from given Account
      account.deleteObserver( this );
      
      // remove Account from accounts Vector
      accounts.remove( account );
      
      // remove Account's Color from Hashtable
      colors.remove( account );
      
      // update display to remove Account information
      repaint();      
   }
   
   // draw Account balances in a pie chart
   public void paintComponent( Graphics g )
   {
      // ensure proper painting sequence
      super.paintComponent( g );
      
      // draw pie chart
      drawPieChart( g );
      
      // draw legend to describe pie chart wedges
      drawLegend( g );
   }
   
   // draw pie chart on given Graphics context
   private void drawPieChart( Graphics g )
   {      
      // get combined Account balance
      double totalBalance = getTotalBalance();
      
      // create temporary variables for pie chart calculations
      double percentage = 0.0;
      int startAngle = 0;
      int arcAngle = 0;
      
      Iterator accountIterator = accounts.iterator();
      Account account = null;
      
      // draw pie wedge for each Account
      while ( accountIterator.hasNext() ) {
         
         // get next Account from Iterator
         account = ( Account ) accountIterator.next(); 
         
         // draw wedges only for included Accounts
         if ( !includeAccountInChart( account ) )
            continue;         
         
         // get percentage of total balance held in Account
         percentage = account.getBalance() / totalBalance;
         
         // calculate arc angle for percentage
         arcAngle = ( int ) Math.round( percentage * 360 ); 
         
         // set drawing Color for Account pie wedge
         g.setColor( ( Color ) colors.get( account ) );
     
         // draw Account pie wedge
         g.fillArc( 5, 5, 100, 100, startAngle, arcAngle );
         
         // calculate startAngle for next pie wedge
         startAngle += arcAngle;
      }       
   } // end method drawPieChart
   
   // draw pie chart legend on given Graphics context
   private void drawLegend( Graphics g )
   {
      Iterator accountIterator = accounts.iterator();
      Account account = null;
      
      // create Font for Account name
      Font font = new Font( "SansSerif", Font.BOLD, 12 );
      g.setFont( font );
      
      // get FontMetrics for calculating offsets and
      // positioning descriptions
      FontMetrics metrics = getFontMetrics( font );
      int ascent = metrics.getMaxAscent();
      int offsetY = ascent + 2;      
      
      // draw description for each Account
      for ( int i = 1; accountIterator.hasNext(); i++ ) {
         
         // get next Account from Iterator
         account = ( Account ) accountIterator.next();
         
         // draw Account color swatch at next offset
         g.setColor( ( Color ) colors.get( account ) );
         g.fillRect( 125, offsetY * i, ascent, ascent );
         
         // draw Account name next to color swatch
         g.setColor( Color.black );
         g.drawString( account.getName(), 140, 
            offsetY * i + ascent );
      }      
   } // end method drawLegend
   
   // get combined balance of all observed Accounts
   private double getTotalBalance()
   {
      double sum = 0.0;
      
      Iterator accountIterator = accounts.iterator();
      Account account = null;
      
      // calculate total balance
      while ( accountIterator.hasNext() ) {
         account = ( Account ) accountIterator.next();
         
         // add only included Accounts to sum
         if ( includeAccountInChart( account ) )
            sum += account.getBalance();
      }
      
      return sum;      
   }
   
   // return true if given Account should be included in
   // pie chart
   protected boolean includeAccountInChart( Account account )
   {
      // include only Asset accounts (Accounts with positive
      // balances)
      return account.getBalance() > 0.0;
   }
   
   // get a random Color for drawing pie wedges
   private Color getRandomColor()
   {
      // calculate random red, green and blue values
      int red = ( int ) ( Math.random() * 256 );
      int green = ( int ) ( Math.random() * 256 );
      int blue = ( int ) ( Math.random() * 256 );
      
      // return newly created Color
      return new Color( red, green, blue );
   }
   
   // receive updates from Observable Account
   public void update( Observable observable, Object object )
   {
       repaint();
   }   

   // get AccountBarGraphView's preferred size
   public Dimension getPreferredSize()
   {
      return new Dimension( 210, 110 );
   }
   
   // get AccountBarGraphView's preferred size
   public Dimension getMinimumSize()
   {
      return getPreferredSize();
   }
   
   // get AccountBarGraphView's preferred size
   public Dimension getMaximumSize()
   {
      return getPreferredSize();
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