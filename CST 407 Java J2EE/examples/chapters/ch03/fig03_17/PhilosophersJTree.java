// PhilosophersJTree.java
// MVC architecture using JTree with a DefaultTreeModel
package com.deitel.advjhtp1.mvc.tree;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.util.*;

// Java extension packages
import javax.swing.*;
import javax.swing.tree.*;

public class PhilosophersJTree extends JFrame {
   
   private JTree tree;
   private DefaultTreeModel philosophers;
   private DefaultMutableTreeNode rootNode;
   
   // PhilosophersJTree constructor
   public PhilosophersJTree() 
   {
      super( "Favorite Philosophers" );
      
      // get tree of philosopher DefaultMutableTreeNodes
      DefaultMutableTreeNode philosophersNode =
         getPhilosopherTree();
      
      // create philosophers DefaultTreeModel 
      philosophers = new DefaultTreeModel( philosophersNode );
      
      // create JTree for philosophers DefaultTreeModel
      tree = new JTree( philosophers );
      
      // create JButton for adding philosophers
      JButton addButton = new JButton( "Add Philosopher" ); 
      addButton.addActionListener(
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event ) 
            {
               addPhilosopher();
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
               removeSelectedPhilosopher();
            }
         }
      );      
      
      // lay out GUI components
      JPanel inputPanel = new JPanel();
      inputPanel.add( addButton );
      inputPanel.add( removeButton );
      
      Container container = getContentPane();   
      
      container.add( new JScrollPane( tree ), 
         BorderLayout.CENTER );
      
      container.add( inputPanel, BorderLayout.NORTH );
      
      setDefaultCloseOperation( EXIT_ON_CLOSE );
      setSize( 400, 300 );
      setVisible( true );
      
   } // end PhilosophersJTree constructor
   
   // add new philosopher to selected era
   private void addPhilosopher()
   {
      // get selected era
      DefaultMutableTreeNode parent = getSelectedNode();

      // ensure user selected era first
      if ( parent == null ) {
         JOptionPane.showMessageDialog( 
            PhilosophersJTree.this, "Select an era.", 
            "Error", JOptionPane.ERROR_MESSAGE );

         return;
      }
      
      // prompt user for philosopher's name
      String name = JOptionPane.showInputDialog(
         PhilosophersJTree.this, "Enter Name:" );

      // add new philosopher to selected era
      philosophers.insertNodeInto( 
         new DefaultMutableTreeNode( name ), 
         parent, parent.getChildCount() );
       
   } // end method addPhilosopher
   
   // remove currently selected philosopher
   private void removeSelectedPhilosopher()
   {
      // get selected node
      DefaultMutableTreeNode selectedNode = getSelectedNode();
      
      // remove selectedNode from model
      if ( selectedNode != null )      
         philosophers.removeNodeFromParent( selectedNode );
   }
   
   // get currently selected node
   private DefaultMutableTreeNode getSelectedNode()
   {
      // get selected DefaultMutableTreeNode
      return ( DefaultMutableTreeNode ) 
         tree.getLastSelectedPathComponent();      
   }
   
   // get tree of philosopher DefaultMutableTreeNodes
   private DefaultMutableTreeNode getPhilosopherTree()
   {
      // create rootNode
      DefaultMutableTreeNode rootNode = 
         new DefaultMutableTreeNode( "Philosophers" );  
      
      // Ancient philosophers
      DefaultMutableTreeNode ancient = 
         new DefaultMutableTreeNode( "Ancient" );
      rootNode.add( ancient );
          
      ancient.add( new DefaultMutableTreeNode( "Socrates" ) );
      ancient.add( new DefaultMutableTreeNode( "Plato" ) );
      ancient.add( new DefaultMutableTreeNode( "Aristotle" ) );
      
      // Medieval philosophers
      DefaultMutableTreeNode medieval = 
         new DefaultMutableTreeNode( "Medieval" );
      rootNode.add( medieval );

      medieval.add( new DefaultMutableTreeNode( 
         "St. Thomas Aquinas" ) );
      
      // Renaissance philosophers
      DefaultMutableTreeNode renaissance = 
         new DefaultMutableTreeNode( "Renaissance" );
      rootNode.add( renaissance );
      
      renaissance.add( new DefaultMutableTreeNode( 
         "Thomas More" ) );

      // Early Modern philosophers
      DefaultMutableTreeNode earlyModern = 
         new DefaultMutableTreeNode( "Early Modern" );
      rootNode.add( earlyModern );

      earlyModern.add( new DefaultMutableTreeNode( 
         "John Locke" ) );

      // Enlightenment Philosophers
      DefaultMutableTreeNode enlightenment = 
         new DefaultMutableTreeNode( "Enlightenment" );
      rootNode.add( enlightenment );      

      enlightenment.add( new DefaultMutableTreeNode( 
         "Immanuel Kant" ) );
      
      // 19th Century Philosophers
      DefaultMutableTreeNode nineteenth = 
         new DefaultMutableTreeNode( "19th Century" );
      rootNode.add( nineteenth );            

      nineteenth.add( new DefaultMutableTreeNode( 
         "Soren Kierkegaard" ) );      

      nineteenth.add( new DefaultMutableTreeNode( 
         "Friedrich Nietzsche" ) );

      // 20th Century Philosophers
      DefaultMutableTreeNode twentieth = 
         new DefaultMutableTreeNode( "20th Century" );
      rootNode.add( twentieth );                  

      twentieth.add( new DefaultMutableTreeNode( 
         "Hannah Arendt" ) );   
      
      return rootNode;
      
   } // end method getPhilosopherTree
   
   // execute application
   public static void main( String args[] ) 
   {
      new PhilosophersJTree();
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