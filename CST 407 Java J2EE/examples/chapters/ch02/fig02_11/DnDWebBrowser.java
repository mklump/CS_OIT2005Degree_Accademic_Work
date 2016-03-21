// DnDWebBrowser.java
// DnDWebBrowser is an application for viewing Web pages using
// drag and drop.
package com.deitel.advjhtp1.gui.dnd;

// Java core packages
import java.awt.*;
import java.awt.dnd.*;
import java.awt.datatransfer.*;
import java.util.*;
import java.io.*;
import java.net.*;

// Java extension packages
import javax.swing.*;
import javax.swing.event.*;

// Deitel packages
import com.deitel.advjhtp1.gui.webbrowser.*;

public class DnDWebBrowser extends JFrame {
   
   private WebToolBar toolBar;
   private WebBrowserPane browserPane;
   
   // DnDWebBrowser constructor
   public DnDWebBrowser()
   {     
      super( "Drag-and-Drop Web Browser" );
      
      // create WebBrowserPane and WebToolBar for navigation
      browserPane = new WebBrowserPane();      
      toolBar = new WebToolBar( browserPane );
      
      // enable WebBrowserPane to accept drop operations, using
      // DropTargetHandler as the DropTargetListener
      browserPane.setDropTarget( new DropTarget( browserPane, 
         DnDConstants.ACTION_COPY, new DropTargetHandler() ) );      
      
      // lay out WebBrowser components
      Container contentPane = getContentPane();
      contentPane.add( toolBar, BorderLayout.NORTH );  
      contentPane.add( new JScrollPane( browserPane ), 
         BorderLayout.CENTER );
   }
   
   // inner class to handle DropTargetEvents
   private class DropTargetHandler implements DropTargetListener {
      
      // handle drop operation
      public void drop( DropTargetDropEvent event ) 
      {         
         // get dropped Transferable object
         Transferable transferable = event.getTransferable();
         
         // if Transferable is a List of Files, accept drop
         if ( transferable.isDataFlavorSupported( 
            DataFlavor.javaFileListFlavor ) ) {      
               
            // accept the drop operation to copy the object   
            event.acceptDrop( DnDConstants.ACTION_COPY );

            // process list of files and display each in browser
            try {
               
               // get List of Files
               java.util.List fileList = 
                  ( java.util.List ) transferable.getTransferData( 
                     DataFlavor.javaFileListFlavor );

               Iterator iterator = fileList.iterator();

               while ( iterator.hasNext() ) {
                  File file = ( File ) iterator.next();

                  // display File in browser and complete drop
                  browserPane.goToURL( file.toURL() );
               }

               // indicate successful drop               
               event.dropComplete( true );
            }

            // handle exception if DataFlavor not supported
            catch ( UnsupportedFlavorException flavorException ) {
               flavorException.printStackTrace();
               event.dropComplete( false );
            }

            // handle exception reading Transferable data
            catch ( IOException ioException ) {
               ioException.printStackTrace();
               event.dropComplete( false );
            }
         }
         
         // if dropped object is not file list, reject drop
         else
            event.rejectDrop();
      }      

      // handle drag operation entering DropTarget
      public void dragEnter( DropTargetDragEvent event ) 
      {
         // if data is javaFileListFlavor, accept drag for copy
         if ( event.isDataFlavorSupported( 
            DataFlavor.javaFileListFlavor ) )
            
            event.acceptDrag( DnDConstants.ACTION_COPY );
         
         // reject all other DataFlavors
         else
            event.rejectDrag();          
      }
      
      // invoked when drag operation exits DropTarget
      public void dragExit( DropTargetEvent event ) {}      

      // invoked when drag operation occurs over DropTarget
      public void dragOver( DropTargetDragEvent event ) {}
      
      // invoked if dropAction changes (e.g., from COPY to LINK)
      public void dropActionChanged( DropTargetDragEvent event )
      {}      

   } // end class DropTargetHandler
   
   // execute application
   public static void main( String args[] )
   {
      DnDWebBrowser browser = new DnDWebBrowser();
      browser.setDefaultCloseOperation( EXIT_ON_CLOSE );
      browser.setSize( 640, 480 );
      browser.setVisible( true );      
   }   
}
