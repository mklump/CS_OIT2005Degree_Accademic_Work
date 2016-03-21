// ActionSample.java
// Demonstrating the Command design pattern with Swing Actions.
package com.deitel.advjhtp1.gui.actions;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;

public class ActionSample extends JFrame {   
   
   // Swing Actions
   private Action sampleAction;
   private Action exitAction;

   // ActionSample constructor
   public ActionSample() 
   {
      super( "Using Actions" );
      
      // create AbstractAction subclass for sampleAction
      sampleAction = new AbstractAction() {
         
         public void actionPerformed( ActionEvent event ) 
         { 
            // display message indicating sampleAction invoked
            JOptionPane.showMessageDialog( ActionSample.this, 
               "The sampleAction was invoked" );
            
            // enable exitAction and associated GUI components
            exitAction.setEnabled( true );
         }
      };
      
      // set Action name
      sampleAction.putValue( Action.NAME, "Sample Action");
      
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
            // display message indicating exitAction invoked
            JOptionPane.showMessageDialog( ActionSample.this, 
               "The exitAction was invoked" );
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
      
      // create JButton and set its Action to sampleAction
      JButton sampleButton = new JButton();
      sampleButton.setAction( sampleAction );
      
      // create JButton and set its Action to exitAction
      JButton exitButton = new JButton( exitAction );      
      
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
      ActionSample sample = new ActionSample(); 
      sample.setDefaultCloseOperation( EXIT_ON_CLOSE );
      sample.pack();
      sample.setVisible( true );   
   }
}