// WebBrowser.java
// WebBrowser is an application for browsing Web sites using
// a WebToolBar and WebBrowserPane.
package com.deitel.advjhtp1.gui.webbrowser;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.net.*;

// Java extension packages
import javax.swing.*;
import javax.swing.event.*;

public class WebBrowser extends JFrame {
   
   private WebToolBar toolBar;
   private WebBrowserPane browserPane;
   
   // WebBrowser constructor
   public WebBrowser()
   {     
      super( "Deitel Web Browser" );
      
      // create WebBrowserPane and WebToolBar for navigation
      browserPane = new WebBrowserPane();      
      toolBar = new WebToolBar( browserPane );
      
      // lay out WebBrowser components
      Container contentPane = getContentPane();
      contentPane.add( toolBar, BorderLayout.NORTH );  
      contentPane.add( new JScrollPane( browserPane ), 
         BorderLayout.CENTER );
   }
   
   // execute application
   public static void main( String args[] )
   {
      WebBrowser browser = new WebBrowser();
      browser.setDefaultCloseOperation( EXIT_ON_CLOSE );
      browser.setSize( 640, 480 );
      browser.setVisible( true );
   }
}