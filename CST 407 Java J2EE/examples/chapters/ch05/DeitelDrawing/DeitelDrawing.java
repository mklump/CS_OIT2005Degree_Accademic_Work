// DeitelDrawing.java
// DeitelDrawing is a drawing program that uses, MVC, a
// multiple-document interface and Java2D.
package com.deitel.advjhtp1.drawing;

// Java core packages
import java.io.*;
import java.util.*;
import java.awt.*;
import java.awt.event.*;
import java.beans.*;

// Java extension packages
import javax.swing.*;
import javax.swing.event.*;
import javax.swing.border.*;

public class DeitelDrawing extends JFrame {
   
   private JMenuBar menuBar;
   private JMenu fileMenu, helpMenu;

   private Action newAction, openAction, 
      exitAction, aboutAction;

   private JMenuItem saveMenuItem, saveAsMenuItem;
   
   private JToolBar toolBar;
   private JPanel toolBarPanel, frameToolBarPanel;
   private JDesktopPane desktopPane;
   
   private SplashScreen splashScreen;

   // DeitelDrawing constructor
   public DeitelDrawing() 
   {
      super( "DeitelDrawing" );
      
      // set icon for JFrame's upper-left-hand corner
      ImageIcon icon = new ImageIcon( 
         DeitelDrawing.class.getResource( "images/icon.png" ) );      
      setIconImage( icon.getImage() );
      
      showSplashScreen();      
      
      // do not hide window when close button clicked
      setDefaultCloseOperation( 
         WindowConstants.DO_NOTHING_ON_CLOSE );

      // create JDesktopPane for MDI
      desktopPane = new JDesktopPane();
      
      // show contents when dragging JInternalFrames
      desktopPane.setDragMode( JDesktopPane.LIVE_DRAG_MODE );

      // create Action for creating new drawings
      Icon newIcon = new ImageIcon( 
         DeitelDrawing.class.getResource( "images/new.gif" ) );   
      
      newAction = new AbstractDrawingAction( "New", newIcon,
         "Create New Drawing", new Integer( 'N' ) ) {

         public void actionPerformed( ActionEvent event )
         {
            createNewWindow();
         }
      };
      
      // create Action for opening existing drawings
      Icon openIcon = new ImageIcon( 
         DeitelDrawing.class.getResource( "images/open.gif" ) );
      
      openAction = new AbstractDrawingAction( "Open", openIcon,
         "Open Existing Drawing", new Integer( 'O' ) ) {
         
         public void actionPerformed( ActionEvent event ) 
         { 
            DrawingInternalFrame frame = createNewWindow();
            
            if ( !frame.openDrawing() ) 
               frame.close();
         }
      };

      // create Action for exiting application
      Icon exitIcon = new ImageIcon( 
         DeitelDrawing.class.getResource( "images/exit.gif" ) );
      
      exitAction = new AbstractDrawingAction( "Exit", exitIcon,
         "Exit Application", new Integer( 'X' ) ) {
         
         public void actionPerformed( ActionEvent event ) 
         { 
            exitApplication(); 
         }
      };

      // create Action for opening About dialog
      Icon aboutIcon = new ImageIcon(
         DeitelDrawing.class.getResource( "images/about.gif" ) );
      
      aboutAction = new AbstractDrawingAction( "About", 
         aboutIcon, "About Application", new Integer( 'b' ) ) {
            
         public void actionPerformed( ActionEvent event ) 
         {
            JOptionPane.showMessageDialog( DeitelDrawing.this, 
               "DeitelDrawing v1.0.\n Copyright " +
               "2002. Deitel & Associates, Inc." ); 
         }
      };

      // create File menu and set its mnemonic
      fileMenu = new JMenu( "File" );
      fileMenu.setMnemonic( 'F' );
      
      // create Help menu and set its mnemonic
      helpMenu = new JMenu( "Help" );
      helpMenu.setMnemonic( 'H' );
      
      menuBar = new JMenuBar();

      // add New Drawing and Open Drawing actions to 
      // File menu and remove their icons
      fileMenu.add( newAction ).setIcon( null );
      fileMenu.add( openAction ).setIcon( null );
      
      // create JMenuItems for saving drawings; these 
      // JMenuItems will invoke the save Actions for the 
      // current DrawingInternalFrame
      saveMenuItem = new JMenuItem( "Save" );
      saveAsMenuItem = new JMenuItem( "Save As" );
      
      // add Save, Save As and Close JMenuItems to File menu
      fileMenu.add( saveMenuItem );
      fileMenu.add( saveAsMenuItem );
      
      fileMenu.addSeparator();
      
      // add Exit action to File menu and remove its icon
      fileMenu.add( exitAction ).setIcon( null );
      
      // add About action to Help menu and remove its icon
      helpMenu.add ( aboutAction ).setIcon( null );

      // add File and Help menus to JMenuBar
      menuBar.add( fileMenu );
      menuBar.add( helpMenu );

      // set Frame's JMenuBar
      setJMenuBar( menuBar );

      // create application JToolBar
      toolBar = new JToolBar();
      
      // disable JToolBar floating
      toolBar.setFloatable( false );
      
      // add New Drawing and Open Drawing actions to JToolBar
      toolBar.add( newAction );
      toolBar.add( openAction );
      
      toolBar.addSeparator();
      
      // add Exit action to JToolBar
      toolBar.add( exitAction );
      
      toolBar.addSeparator();
      
      // add About action to JToolBar
      toolBar.add( aboutAction );
      
      // add toolBar and desktopPane to ContentPane
      getContentPane().add( toolBar, BorderLayout.NORTH );
      getContentPane().add( desktopPane, BorderLayout.CENTER );

      // add WindowListener for windowClosing event
      addWindowListener( 
         new WindowAdapter() {
         
            public void windowClosing( WindowEvent event ) 
            { 
               exitApplication(); 
            }
         }
      );
      
      // wait for SplashScreen to go away
      while ( splashScreen.isVisible() ) {
         
         try {
            Thread.sleep( 10 );
         }
         
         // handle exception 
         catch ( InterruptedException interruptedException ) {
            interruptedException.printStackTrace();
         }
      }

      // set initial JFrame size
      setSize( 640, 480 );
      
      // position application window
      centerWindowOnScreen();
      
      // make application visible
      setVisible( true );
      
      // create new, empty drawing window
      createNewWindow();   
      
   } // end DeitelDrawing constructor

   // create new DrawingInternalFrame
   private DrawingInternalFrame createNewWindow() 
   {  
      // create new DrawingInternalFrame
      DrawingInternalFrame frame = 
         new DrawingInternalFrame( "Untitled Drawing" );
   
      // add listener for InternalFrame events
      frame.addInternalFrameListener( 
         new DrawingInternalFrameListener() );
      
      // make DrawingInternalFrame opaque
      frame.setOpaque( true );
      
      // add DrawingInternalFrame to desktopPane
      desktopPane.add( frame );
      
      // make DrawingInternalFrame visible
      frame.setVisible( true );
      
      // select new DrawingInternalFrame
      try { 
         frame.setSelected( true ); 
      } 
      
      // handle exception selecting DrawingInternalFrame 
      catch ( PropertyVetoException vetoException ) { 
         vetoException.printStackTrace(); 
      }
      
      // return reference to newly created DrawingInternalFrame
      return frame;
   }
   
   // InternalFrameAdapter to listen for InternalFrame events
   private class DrawingInternalFrameListener 
      extends InternalFrameAdapter {

      // when DrawingInternalFrame is closing disable 
      // appropriate Actions
      public void internalFrameClosing( 
         InternalFrameEvent event ) 
      { 
         DrawingInternalFrame frame = 
            ( DrawingInternalFrame ) event.getSource();
         
         // frame closes successfully, disable Save menu items
         if ( frame.close() ) {           
            saveMenuItem.setAction( null );
            saveAsMenuItem.setAction( null );
         }
      }

      // when DrawingInternalFrame is activated, make its JToolBar
      // visible and set JMenuItems to DrawingInternalFrame Actions
      public void internalFrameActivated( 
         InternalFrameEvent event ) 
      {
         DrawingInternalFrame frame = 
            ( DrawingInternalFrame ) event.getSource();
         
         // set saveMenuItem to DrawingInternalFrame's saveAction
         saveMenuItem.setAction( frame.getSaveAction() );
         saveMenuItem.setIcon( null );
         
         // set saveAsMenuItem to DrawingInternalFrame's 
         // saveAsAction
         saveAsMenuItem.setAction( frame.getSaveAsAction() );
         saveAsMenuItem.setIcon( null );
      }
   }    
   
   // close each DrawingInternalFrame to let user save drawings 
   // then exit application
   private void exitApplication() 
   {
      // get array of JInternalFrames from desktopPane
      JInternalFrame frames[] = desktopPane.getAllFrames();
      
      // keep track of DrawingInternalFrames that do not close
      boolean allFramesClosed = true;
      
      // select and close each DrawingInternalFrame
      for ( int i = 0; i < frames.length; i++ ) {
         DrawingInternalFrame nextFrame = 
            ( DrawingInternalFrame ) frames[ i ];
         
         // select current DrawingInternalFrame
         try { 
            nextFrame.setSelected( true ); 
         } 
         
         // handle exception when selecting DrawingInternalFrame 
         catch ( PropertyVetoException vetoException ) { 
            vetoException.printStackTrace(); 
         }
      
         // close DrawingInternalFrame and update allFramesClosed
         allFramesClosed = allFramesClosed && nextFrame.close();
      }
      
      // exit application only if all frames were closed
      if ( allFramesClosed ) 
         System.exit( 0 );
   
   } // end method exitApplication
   
   // display application's splash screen
   public void showSplashScreen()
   {
      // create ImageIcon for logo
      Icon logoIcon = new ImageIcon( 
         getClass().getResource( "images/deitellogo.png" ) );
      
      // create new JLabel for logo
      JLabel logoLabel = new JLabel( logoIcon );
      
      // set JLabel background color
      logoLabel.setBackground( Color.white );
      
      // set splash screen border
      logoLabel.setBorder( 
         new MatteBorder( 5, 5, 5, 5, Color.black ) );
      
      // make logoLabel opaque
      logoLabel.setOpaque( true );
      
      // create SplashScreen for logo
      splashScreen = new SplashScreen( logoLabel ); 
      
      // show SplashScreen for 3 seconds
      splashScreen.showSplash( 3000 );     
   
   } // end method showSplashScreen
   
   // center application window on user's screen
   private void centerWindowOnScreen()
   {
      // get Dimension of user's screen
      Dimension screenDimension = 
         Toolkit.getDefaultToolkit().getScreenSize();
      
      // use screen width and height and application width
      // and height to center application on user's screen
      int width = getSize().width;
      int height = getSize().height;
      int x = ( screenDimension.width - width ) / 2 ;
      int y = ( screenDimension.height - height ) / 2 ;
      
      // place application window at screen's center
      setBounds( x, y, width, height );
   }

   // execute application
   public static void main( String args[] ) 
   {      
      new DeitelDrawing();
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
