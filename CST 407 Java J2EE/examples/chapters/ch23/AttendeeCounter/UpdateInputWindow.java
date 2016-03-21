// Fig. 23.15: UpdateInputWindow.java
// This application is an user interface used
// to get the input data.
package com.deitel.advjhtp1.javaspace.update;

// Java extension package
import javax.swing.*;

// Java core packages
import java.awt.*;
import java.awt.event.*;

public class UpdateInputWindow extends JFrame {

   private String[] dates = { "Monday", "Tuesday",
      "Wednesday", "Thursday", "Friday" };
   private JButton okButton;
   private JComboBox dateComboBox;
   private JLabel firstLabel;
   private JTextField numberText;
   private String date = "Monday";
   private int count = 0;
   private String hostname;

   public UpdateInputWindow( String name )
   {
      super( "UpdateInputWindow" );
      Container container = getContentPane();

      hostname = name;

      // define center panel
      JPanel centerPanel = new JPanel();
      centerPanel.setLayout( new GridLayout( 2, 2, 0, 5 ) );

      // add label
      firstLabel = new JLabel( "Please choose a date:", 
         SwingConstants.CENTER );
      centerPanel.add( firstLabel );

      // add combo box
      dateComboBox = new JComboBox( dates );
      dateComboBox.setSelectedIndex( 0 );
      centerPanel.add( dateComboBox );

      // install listener to combo box
      dateComboBox.addItemListener( 

         new ItemListener() {

            public void itemStateChanged( ItemEvent itemEvent )
            {
               date = ( String ) dateComboBox.getSelectedItem();
            }
         }
      );

      // add label
      JLabel numberLabel = new JLabel( 
         "Please specify a number:", SwingConstants.CENTER );
      centerPanel.add( numberLabel );

      // add text field
      numberText = new JTextField( 10 );
      centerPanel.add( numberText );

      // install listener to text field
      numberText.addActionListener( 

         new ActionListener() {

            public void actionPerformed( ActionEvent event ) 
            {
               count = Integer.parseInt( 
                  event.getActionCommand() );
            }
         }
      );

      // define button panel    
      JPanel buttonPanel = new JPanel();
      buttonPanel.setLayout( new GridLayout( 1, 1, 0, 5 ) );

      // add OK button
      okButton = new JButton( "OK" );
      buttonPanel.add( okButton );

      // add listener to OK button
      okButton.addActionListener(

         new ActionListener() {

            public void actionPerformed( ActionEvent event ) 
            {
               // get user input
               count = Integer.parseInt( numberText.getText() );

               if ( count == 0) {
                  System.out.println(
                     "Please Specify a Number" );
               }
               
               else {                  
                  UpdateOperation update = new UpdateOperation();
                  String jiniURL = "jini://" +  hostname;
                  update.getServices( jiniURL );
                  update.updateEntry( date, count );
                  
                  setVisible( false );
                  update.showOutput();
               }
            }
         }
      );

      // put everything together
      container.add( centerPanel, BorderLayout.CENTER );
      container.add( buttonPanel, BorderLayout.SOUTH );

      // set window size and display it
      setSize( 320, 130 );
      setVisible( true );

   } // end updateInputWindow constructor
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