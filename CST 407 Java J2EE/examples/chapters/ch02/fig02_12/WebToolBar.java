// WebToolBar.java
// Internationalized WebToolBar with components for navigating 
// a WebBrowserPane.
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
import com.deitel.advjhtp1.gui.actions.MyAbstractAction;

public class WebToolBar extends JToolBar 
   implements HyperlinkListener {
   
   private WebBrowserPane webBrowserPane;
   private JTextField urlTextField;
   
   // WebToolBar constructor
   public WebToolBar( WebBrowserPane browser, Locale locale ) 
   {
      // get resource bundle for internationalized strings
      ResourceBundle resources = ResourceBundle.getBundle( 
         "StringsAndLabels", locale );
      
      setName( resources.getString( "toolBarTitle" ) );
      
      // register for HyperlinkEvents
      webBrowserPane = browser;
      webBrowserPane.addHyperlinkListener( this );
      
      // create JTextField for entering URLs
      urlTextField = new JTextField( 25 );      
      urlTextField.addActionListener(
         new ActionListener() {
            
            // navigate webBrowser to user-entered URL
            public void actionPerformed( ActionEvent event )
            {
               // attempt to load URL in webBrowserPane
               try {
                  URL url = new URL( urlTextField.getText() );
                  webBrowserPane.goToURL( url );
               }

               // handle invalid URL
               catch ( MalformedURLException urlException ) {
                  urlException.printStackTrace();
               }
            }
         }
      );
      
      // create backAction and configure its properties
      MyAbstractAction backAction = new MyAbstractAction() {
         
         public void actionPerformed( ActionEvent event )
         {
            // navigate to previous URL
            URL url = webBrowserPane.back();

            // display URL in urlTextField
            urlTextField.setText( url.toString() );
         }         
      };
      
      backAction.setSmallIcon( new ImageIcon( 
         getClass().getResource( "images/back.gif" ) ) );
      
      backAction.setShortDescription( 
         resources.getString( "backToolTip" ) );
      
      // create forwardAction and configure its properties      
      MyAbstractAction forwardAction = new MyAbstractAction() {
         
         public void actionPerformed( ActionEvent event )
         {
            // navigate to next URL
            URL url = webBrowserPane.forward();

            // display new URL in urlTextField
            urlTextField.setText( url.toString() );
         }        
      };
      
      forwardAction.setSmallIcon( new ImageIcon(
         getClass().getResource( "images/forward.gif" ) ) );
      
      forwardAction.setShortDescription(
         resources.getString( "forwardToolTip" ) );
      
      // add JButtons and JTextField to WebToolBar
      add( backAction );
      add( forwardAction );
      add( urlTextField );
      
   } // end WebToolBar constructor
   
   // listen for HyperlinkEvents in WebBrowserPane
   public void hyperlinkUpdate( HyperlinkEvent event )
   {
      // if hyperlink was activated, go to hyperlink's URL
      if ( event.getEventType() == 
         HyperlinkEvent.EventType.ACTIVATED ) {
            
         // get URL from HyperlinkEvent
         URL url = event.getURL();
         
         // navigate to URL and display URL in urlTextField
         webBrowserPane.goToURL( event.getURL() );
         urlTextField.setText( url.toString() );
      }
   }   
}