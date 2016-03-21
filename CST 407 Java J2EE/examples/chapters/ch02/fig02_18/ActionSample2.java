// ActionSample2.java
// ActionSample2 demonstrates the Accessibility features of
// Swing components.
package com.deitel.advjhtp1.gui.actions;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.accessibility.*;
import javax.swing.*;

public class ActionSample2 extends JFrame {   
   
   // Swing Actions
   private Action sampleAction;
   private Action exitAction;

   // ActionSample2 constructor
   public ActionSample2() 
   {
      super( "Using Actions" );
      
      // create AbstractAction subclass for sampleAction
      sampleAction = new AbstractAction() {
         
         public void actionPerformed( ActionEvent event ) 
         { 
            // display message indicating sampleAction invoked
            JOptionPane action = new JOptionPane( 
               "The sampleAction was invoked." );
            
            // get AccessibleContext for action and set name 
            // and description
            AccessibleContext actionContext = 
               action.getAccessibleContext();
            actionContext.setAccessibleName( "sampleAction" );
            actionContext.setAccessibleDescription( 
               "SampleAction opens a dialog box to demonstrate" 
               + " the Action class." );
            
            // create and display dialog box
            action.createDialog( ActionSample2.this, 
               "sampleAction" ).setVisible( true );
            
            // enable exitAction and associated GUI components
            exitAction.setEnabled( true );
         }
      };
      
      // set Action name
      sampleAction.putValue( Action.NAME, "Sample Action" );
      
      // set Action Icon
      sampleAction.putValue( Action.SMALL_ICON, new ImageIcon(
         getClass().getResource( "images/Help24.gif" ) ) );
      
      // set Action short description (tooltip text)
      sampleAction.putValue( Action.SHORT_DESCRIPTION, 
         "A Sample Action" );
      
      // set Action mnemonic key
      sampleAction.putValue( Action.MNEMONIC_KEY, 
         new Integer( 'S' ) );
      
      // create AbstractAction subclass for exitAction      
      exitAction = new AbstractAction() {
         
         public void actionPerformed( ActionEvent event ) 
         { 
            // display message indicating sampleAction invoked
            JOptionPane exit = new JOptionPane( 
               "The exitAction was invoked." );
            
            // get AccessibleContext for exit and set name and 
            // description
            AccessibleContext exitContext = 
               exit.getAccessibleContext();
            exitContext.setAccessibleName( "exitAction" );
            exitContext.setAccessibleDescription( "ExitAction" 
               + " opens a dialog box to demonstrate the" 
               + " Action class and then exits the program." );
            
            // create and display dialog box
            exit.createDialog( ActionSample2.this, 
               "exitAction" ).setVisible( true );

            // exit program
            System.exit( 0 );
         }
      };
      
      // set Action name
      exitAction.putValue( Action.NAME, "Exit" );
      
      // set Action icon
      exitAction.putValue( Action.SMALL_ICON, new ImageIcon(
         getClass().getResource( "images/EXIT.gif" ) ) );
      
      // set Action short description (tooltip text)
      exitAction.putValue( Action.SHORT_DESCRIPTION, 
         "Exit Application" );
      
      // set Action mnemonic key
      exitAction.putValue( Action.MNEMONIC_KEY, 
         new Integer( 'x' ) );
      
      // disable exitAction and associated GUI components
      exitAction.setEnabled( false );
      
      // create File menu
      JMenu fileMenu = new JMenu( "File" );
      
      // add sampleAction and exitAction to File menu to 
      // create a JMenuItem for each Action
      fileMenu.add( sampleAction );
      fileMenu.add( exitAction );
      
      fileMenu.setMnemonic( 'F' );
      
      // create JMenuBar and add File menu
      JMenuBar menuBar = new JMenuBar();
      menuBar.add( fileMenu );
      setJMenuBar( menuBar );   
      
      // create JToolBar
      JToolBar toolBar = new JToolBar();
      
      // add sampleAction and exitAction to JToolBar to create
      // JButtons for each Action
      toolBar.add( sampleAction );
      toolBar.add( exitAction );
      
      // get AccessibleContext for toolBar and set name and 
      // description
      AccessibleContext toolContext = 
         toolBar.getAccessibleContext();
      toolContext.setAccessibleName( "ToolBar" );
      toolContext.setAccessibleDescription( "ToolBar contains"
         + " sampleAction button and exitAction button." );
      
      // create JButton and set its Action to sampleAction
      JButton sampleButton = new JButton();
      sampleButton.setAction( sampleAction );
      
      // get AccessibleContext for sampleButton and set name  
      // and description
      AccessibleContext sampleContext = 
         sampleButton.getAccessibleContext();
      sampleContext.setAccessibleName( "SampleButton" );
      sampleContext.setAccessibleDescription( "SampleButton" 
         + " produces a sampleAction event." );
      
      // create JButton and set its Action to exitAction
      JButton exitButton = new JButton( exitAction );
      
      // get AccessibleContext for exitButton and set name and
      // description
      AccessibleContext exitContext = 
         exitButton.getAccessibleContext();
      exitContext.setAccessibleName( "ExitButton" );
      exitContext.setAccessibleDescription( "ExitButton"
         + " produces an exitAction event." );
      
      // lay out JButtons in JPanel
      JPanel buttonPanel = new JPanel();
      buttonPanel.add( sampleButton );
      buttonPanel.add( exitButton );
      
      // add toolBar and buttonPanel to JFrame's content pane
      Container container = getContentPane();
      container.add( toolBar, BorderLayout.NORTH );
      container.add( buttonPanel, BorderLayout.CENTER );
      
   }
   
   // execute application
   public static void main( String args[] ) 
   { 
      ActionSample2 sample = new ActionSample2(); 
      sample.setDefaultCloseOperation( EXIT_ON_CLOSE );
      sample.pack();
      sample.setVisible( true );   
   }
}