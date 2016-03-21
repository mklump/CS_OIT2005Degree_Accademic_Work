// MDIWebBrowser.java
// MDIWebBrowser is an application that uses JDesktopPane
// and JInternalFrames to create a multiple-document-interface
// application for Web browsing.
package com.deitel.advjhtp1.gui.mdi;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;

// Deitel packages
import com.deitel.advjhtp1.gui.webbrowser.*;

public class MDIWebBrowser extends JFrame {
   
   // JDesktopPane for multiple document interface
   JDesktopPane desktopPane = new JDesktopPane();

   // MDIWebBrowser constructor
   public MDIWebBrowser() 
   {     
      super( "MDI Web Browser" );
      
      // create first browser window
      createNewWindow();
      
      // add JDesktopPane to contentPane
      Container contentPane = getContentPane();
      contentPane.add( desktopPane );      
      
      // create File JMenu for creating new windows and
      // exiting application
      JMenu fileMenu = new JMenu( "File" );
      fileMenu.add( new NewWindowAction() );
      fileMenu.addSeparator();
      fileMenu.add( new ExitAction() );
      fileMenu.setMnemonic( 'F' );
      
      JMenuBar menuBar = new JMenuBar();
      menuBar.add( fileMenu );
      setJMenuBar( menuBar );
   }
   
   // create new browser window
   private void createNewWindow()
   {
      // create new JInternalFrame that is resizable, closable,
      // maximizable and iconifiable
      JInternalFrame frame = new JInternalFrame(
         "Browser", // title
         true,      // resizable
         true,      // closable
         true,      // maximizable
         true );    // iconifiable
      
      // create WebBrowserPane and WebToolBar
      WebBrowserPane browserPane = new WebBrowserPane();
      WebToolBar toolBar = new WebToolBar( browserPane );
      
      // add WebBrowserPane and WebToolBar to JInternalFrame
      Container contentPane = frame.getContentPane();
      contentPane.add( toolBar, BorderLayout.NORTH );
      contentPane.add( new JScrollPane( browserPane ), 
         BorderLayout.CENTER );
      
      // make JInternalFrame opaque and set its size
      frame.setSize( 320, 240 );
      
      // move JInternalFrame to prevent it from obscuring others
      int offset = 30 * desktopPane.getAllFrames().length;
      frame.setLocation( offset, offset ); 
      
      // add JInternalFrame to JDesktopPane
      desktopPane.add( frame );
      
      // make JInternalFrame visible
      frame.setVisible( true );      
   }
   
   // Action for creating new browser windows
   private class NewWindowAction extends AbstractAction {
      
      // NewWindowAction constructor
      public NewWindowAction()
      {
         // set name, description and mnemonic key
         putValue( Action.NAME, "New Window" );
         putValue( Action.SHORT_DESCRIPTION, 
            "Create New Web Browser Window" );
         putValue( Action.MNEMONIC_KEY, new Integer( 'N' ) );
      }
      
      // when Action invoked, create new browser window
      public void actionPerformed( ActionEvent event ) 
      {
         createNewWindow();
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
      MDIWebBrowser browser = new MDIWebBrowser();
      browser.setDefaultCloseOperation( EXIT_ON_CLOSE );
      browser.setSize( 640, 480 );
      browser.setVisible( true );     
   }      
}