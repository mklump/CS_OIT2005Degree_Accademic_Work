// PhilosophersJList.java
// MVC architecture using JList with a DefaultListModel
package com.deitel.advjhtp1.mvc.list;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;

public class PhilosophersJList extends JFrame {
   
   private DefaultListModel philosophers;
   private JList list;

   // PhilosophersJList constructor
   public PhilosophersJList() 
   {
      super( "Favorite Philosophers" );

      // create a DefaultListModel to store philosophers
      philosophers = new DefaultListModel();
      philosophers.addElement( "Socrates" );
      philosophers.addElement( "Plato" );
      philosophers.addElement( "Aristotle" );
      philosophers.addElement( "St. Thomas Aquinas" );
      philosophers.addElement( "Soren Kierkegaard" );
      philosophers.addElement( "Immanuel Kant" );
      philosophers.addElement( "Friedrich Nietzsche" ); 
      philosophers.addElement( "Hannah Arendt" );

      // create a JList for philosophers DefaultListModel
      list = new JList( philosophers );  
      
      // allow user to select only one philosopher at a time
      list.setSelectionMode( 
         ListSelectionModel.SINGLE_SELECTION );
      
      // create JButton for adding philosophers
      JButton addButton = new JButton( "Add Philosopher" );
      addButton.addActionListener(
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event ) 
            {
               // prompt user for new philosopher's name
               String name = JOptionPane.showInputDialog(
                  PhilosophersJList.this, "Enter Name" );
               
               // add new philosopher to model
               philosophers.addElement( name );
            }
         }
      );
      
      // create JButton for removing selected philosopher
      JButton removeButton = 
         new JButton( "Remove Selected Philosopher" );
      
      removeButton.addActionListener(
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event ) 
            {
               // remove selected philosopher from model
               philosophers.removeElement( 
                  list.getSelectedValue() );
            }
         }
      );
      
      // lay out GUI components
      JPanel inputPanel = new JPanel();
      inputPanel.add( addButton );
      inputPanel.add( removeButton );
      
      Container container = getContentPane();       
      container.add( list, BorderLayout.CENTER );      
      container.add( inputPanel, BorderLayout.NORTH );
      
      setDefaultCloseOperation( EXIT_ON_CLOSE );      
      setSize( 400, 300 );
      setVisible( true );
      
   } // end PhilosophersJList constructor

   // execute application
   public static void main( String args[] ) 
   {
      new PhilosophersJList();
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