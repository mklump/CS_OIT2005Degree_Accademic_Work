// TabbedPaneWebBrowser.java
// TabbedPaneWebBrowser is an application that uses a 
// JTabbedPane to display multiple Web browsers.
package com.deitel.advjhtp1.gui.tabbedpane;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;

// Deitel packages
import com.deitel.advjhtp1.gui.webbrowser.*;

public class TabbedPaneWebBrowser extends JFrame {
   
   // JTabbedPane for displaying multiple browser tabs
   private JTabbedPane tabbedPane = new JTabbedPane();

   // TabbedPaneWebBrowser constructor
   public TabbedPaneWebBrowser() 
   {     
      super( "JTabbedPane Web Browser" );
      
      // create first browser tab
      createNewTab();
      
      // add JTabbedPane to contentPane
      getContentPane().add( tabbedPane );      
      
      // create File JMenu for creating new browser tabs and
      // exiting application
      JMenu fileMenu = new JMenu( "File" );
      fileMenu.add( new NewTabAction() );
      fileMenu.addSeparator();
      fileMenu.add( new ExitAction() );
      fileMenu.setMnemonic( 'F' );
      
      JMenuBar menuBar = new JMenuBar();
      menuBar.add( fileMenu );
      setJMenuBar( menuBar );

   } // end TabbedPaneWebBrowser constructor
   
   // create new browser tab
   private void createNewTab()
   {
      // create JPanel to contain WebBrowserPane and WebToolBar
      JPanel panel = new JPanel( new BorderLayout() );
      
      // create WebBrowserPane and WebToolBar
      WebBrowserPane browserPane = new WebBrowserPane();
      WebToolBar toolBar = new WebToolBar( browserPane );
      
      // add WebBrowserPane and WebToolBar to JPanel
      panel.add( toolBar, BorderLayout.NORTH );
      panel.add( new JScrollPane( browserPane ), 
         BorderLayout.CENTER );
      
      // add JPanel to JTabbedPane
      tabbedPane.addTab( "Browser " + tabbedPane.getTabCount(),
         panel );
   }
   
   // Action for creating new browser tabs
   private class NewTabAction extends AbstractAction {
      
      // NewTabAction constructor
      public NewTabAction()
      {
         // set name, description and mnemonic key
         putValue( Action.NAME, "New Browser Tab" );
         putValue( Action.SHORT_DESCRIPTION, 
            "Create New Web Browser Tab" );
         putValue( Action.MNEMONIC_KEY, new Integer( 'N' ) );
      }
      
      // when Action invoked, create new browser tab
      public void actionPerformed( ActionEvent event ) 
      {
         createNewTab();
      }      
   }
   
   // Action for exiting application
   private class ExitAction extends AbstractAction {
      
      // ExitAction constructor
      public ExitAction()
      {
         // set name, description and mnemonic key
         putValue( Action.NAME, "Exit" );
         putValue( Action.SHORT_DESCRIPTION, "Exit Application" );
         putValue( Action.MNEMONIC_KEY, new Integer( 'x' ) );
      }
      
      // when Action invoked, exit application
      public void actionPerformed( ActionEvent event ) 
      {
         System.exit( 0 );
      }
   }  
   
   // execute application
   public static void main( String args[] )
   {
      TabbedPaneWebBrowser browser = new TabbedPaneWebBrowser();
      browser.setDefaultCloseOperation( EXIT_ON_CLOSE );
      browser.setSize( 640, 480 );
      browser.setVisible( true );     
   }      
}