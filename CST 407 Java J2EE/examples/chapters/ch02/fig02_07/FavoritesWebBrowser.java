// FavoritesWebBrowser.java
// FavoritesWebBrowser is an application for browsing Web sites 
// using a WebToolBar and WebBrowserPane and displaying an HTML
// page containing links to favorite Web sites.
package com.deitel.advjhtp1.gui.splitpane;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.net.*;

// Java extension packages
import javax.swing.*;
import javax.swing.event.*;

// Deitel packages
import com.deitel.advjhtp1.gui.webbrowser.*;

public class FavoritesWebBrowser extends JFrame {
   
   private WebToolBar toolBar;
   private WebBrowserPane browserPane;
   private WebBrowserPane favoritesBrowserPane;
   
   // WebBrowser constructor
   public FavoritesWebBrowser()
   {     
      super( "Deitel Web Browser" );
      
      // create WebBrowserPane and WebToolBar for navigation
      browserPane = new WebBrowserPane();      
      toolBar = new WebToolBar( browserPane );
      
      // create WebBrowserPane for displaying favorite sites
      favoritesBrowserPane = new WebBrowserPane();
      
      // add WebToolBar as listener for HyperlinkEvents
      // in favoritesBrowserPane
      favoritesBrowserPane.addHyperlinkListener( toolBar );  
      
      // display favorites.html in favoritesBrowserPane
      favoritesBrowserPane.goToURL( 
         getClass().getResource( "favorites.html" ) );
      
      // create JSplitPane with horizontal split (side-by-side)
      // and add WebBrowserPanes with JScrollPanes
      JSplitPane splitPane = new JSplitPane( 
         JSplitPane.HORIZONTAL_SPLIT,
         new JScrollPane( favoritesBrowserPane ), 
         new JScrollPane( browserPane ) );  
      
      // position divider between WebBrowserPanes
      splitPane.setDividerLocation( 210 );
      
      // add buttons for expanding/contracting divider
      splitPane.setOneTouchExpandable( true );
      
      // lay out WebBrowser components
      Container contentPane = getContentPane();
      contentPane.add( toolBar, BorderLayout.NORTH );  
      contentPane.add( splitPane, BorderLayout.CENTER );
   }
   
   // execute application
   public static void main( String args[] )
   {
      FavoritesWebBrowser browser = new FavoritesWebBrowser();
      browser.setDefaultCloseOperation( EXIT_ON_CLOSE );
      browser.setSize( 640, 480 );
      browser.setVisible( true );
   }
}