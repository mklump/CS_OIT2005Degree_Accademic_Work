// BrowserLauncher.java
// BrowserLauncher provides a list of Locales and launches a new
// Internationalized WebBrowser for the selected Locale.
package com.deitel.advjhtp1.gui.i18n;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.util.*;

// Java extension packages
import javax.swing.*;

public class BrowserLauncher extends JFrame {
   
   // JComboBox for selecting Locale
   private JComboBox localeComboBox;
   
   // BrowserLauncher constructor
   public BrowserLauncher()
   {   
      super( "Browser Launcher" );
      
      // create JComboBox and add Locales
      localeComboBox = new JComboBox(); 
      
      // United States, English
      localeComboBox.addItem( Locale.US );
      
      // France, French
      localeComboBox.addItem( Locale.FRANCE );
      
      // Russia, Russian
      localeComboBox.addItem( new Locale( "ru", "RU" ) );
      
      // launch new WebBrowser when Locale selection changes
      localeComboBox.addItemListener( 
         new ItemListener() {
            
            public void itemStateChanged( ItemEvent event )
            {
               if ( event.getStateChange() == ItemEvent.SELECTED )
                  launchBrowser( ( Locale ) 
                     localeComboBox.getSelectedItem() );
            }
         }
      );
      
      // lay out components
      Container contentPane = getContentPane();
      contentPane.setLayout( new FlowLayout() );
      contentPane.add( new JLabel( "Select Locale" ) );
      contentPane.add( localeComboBox );  
   }
   
   // launch new WebBrowser for given Locale
   private void launchBrowser( Locale locale )
   {
      WebBrowser browser = new WebBrowser( locale );
      browser.setDefaultCloseOperation( DISPOSE_ON_CLOSE );
      browser.setSize( 640, 480 );
      browser.setVisible( true );
   }
   
   // execute application
   public static void main( String args[] )
   {
      BrowserLauncher launcher = new BrowserLauncher();
      launcher.setDefaultCloseOperation( EXIT_ON_CLOSE );
      launcher.setSize( 200, 125 );
      launcher.setVisible( true );
   }
}