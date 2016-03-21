// WebBrowser.java
// WebBrowser is an application for browsing Web sites using
// a WebToolBar and WebBrowserPane.
package com.deitel.advjhtp1.gui.i18n;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.net.*;
import java.util.*;

// Java extension packages
import javax.swing.*;
import javax.swing.event.*;

// Deitel packages
import com.deitel.advjhtp1.gui.webbrowser.WebBrowserPane;

public class WebBrowser extends JFrame {
   
   private ResourceBundle resources;
   private WebToolBar toolBar;
   private WebBrowserPane browserPane;
   
   // WebBrowser constructor
   public WebBrowser( Locale locale )
   {     
      resources = ResourceBundle.getBundle( 
         "StringsAndLabels", locale );
      
      setTitle( resources.getString( "applicationTitle" ) );
      
      // create WebBrowserPane and WebToolBar for navigation
      browserPane = new WebBrowserPane();      
      toolBar = new WebToolBar( browserPane, locale );
      
      // lay out WebBrowser components
      Container contentPane = getContentPane();
      contentPane.add( toolBar, BorderLayout.NORTH );  
      contentPane.add( new JScrollPane( browserPane ), 
         BorderLayout.CENTER );
   }
}