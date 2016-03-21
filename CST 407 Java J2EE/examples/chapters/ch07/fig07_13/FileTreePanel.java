// FileTreePanel.java
// JPanel for displaying file system contents in a JTree
// using a custom TreeModel.
package com.deitel.advjhtp1.security.signatures;

// Java core packages
import java.io.*;
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;
import javax.swing.tree.*;
import javax.swing.event.*;

// Deitel packages
import com.deitel.advjhtp1.mvc.tree.filesystem.FileSystemModel;

public class FileTreePanel extends JPanel {

   // JTree for displaying file system
   private JTree fileTree;
   
   // FileSystemModel TreeModel implementation
   private FileSystemModel fileSystemModel;
   
   // JTextArea for displaying selected file's details
   private JTextArea fileDetailsTextArea; 

   // FileTreePanel constructor
   public FileTreePanel( String directory ) 
   {            
      // create JTextArea for displaying File information
      fileDetailsTextArea = new JTextArea();
      fileDetailsTextArea.setEditable( false );
      
      // create FileSystemModel for given directory
      fileSystemModel = new FileSystemModel( 
         new File( directory ) );
      
      // create JTree for FileSystemModel
      fileTree = new JTree( fileSystemModel );
      
      // make JTree editable for renaming Files
      fileTree.setEditable( true );
      
      // add a TreeSelectionListener
      fileTree.addTreeSelectionListener( 
         new TreeSelectionListener() {
            
            // display details of newly selected File when
            // selection changes
            public void valueChanged( 
               TreeSelectionEvent event ) 
            {  
               File file = ( File ) 
                  fileTree.getLastSelectedPathComponent();
               
               fileDetailsTextArea.setText( 
                  getFileDetails( file ) );
            }
         }
      ); // end addTreeSelectionListener
            
      // put fileTree and fileDetailsTextArea in a JSplitPane
      JSplitPane splitPane = new JSplitPane(
         JSplitPane.HORIZONTAL_SPLIT, true, 
         new JScrollPane( fileTree ), 
         new JScrollPane( fileDetailsTextArea ) );

      setLayout( new BorderLayout() );
      add( splitPane );
     
   } // end FileTreePanel constructor
   
   // get FileTreePanel preferred size
   public Dimension getPreferredSize()
   {
      return new Dimension( 400, 200 );
   } 
   
   // build a String to display file details
   private String getFileDetails( File file )
   {
      // do not return details for null Files
      if ( file == null )
         return "";
      
      // put File information in a StringBuffer
      StringBuffer buffer = new StringBuffer();
      buffer.append( "Name: " + file.getName() + "\n" );
      buffer.append( "Path: " + file.getPath()  + "\n" );
      buffer.append( "Size: " + file.length() + "\n" );
      
      return buffer.toString();
   }
   
   // execute application
   public static void main( String args[] )
   {
      // ensure that user provided directory name
      if ( args.length != 1 )
         System.err.println( 
            "Usage: java FileTreeFrame <path>" );
      
      // start application using provided directory name
      else {
         
         // create JFrame and add FileTreePanel
         JFrame frame = new JFrame( "JTree FileSystem Viewer" );
         FileTreePanel treePanel = new FileTreePanel( args[ 0 ] );
         frame.getContentPane().add( treePanel );
         
         // configure and display JFrame
         frame.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );
         frame.pack();
         frame.setVisible( true );
      }

   } // end method main
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