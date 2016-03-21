// DrawingInternalFrame.java
// DrawingInternalFrame is a JInternalFrame subclass for 
// DeitelDrawing drawings.
package com.deitel.advjhtp1.drawing;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.awt.dnd.*;
import java.io.*;
import java.util.*;
import java.util.List;

// Java extension packages
import javax.swing.*;
import javax.swing.event.*;
import javax.swing.border.*;

// Deitel packages
import com.deitel.advjhtp1.drawing.model.*;
import com.deitel.advjhtp1.drawing.model.shapes.*;
import com.deitel.advjhtp1.drawing.view.*;
import com.deitel.advjhtp1.drawing.controller.*;

public class DrawingInternalFrame extends JInternalFrame 
   implements Observer {
   
   // offsets to stagger new windows
   private static final int xOffset = 30;
   private static final int yOffset = 30;
   private static int openFrameCount = 0;

   // MVC components
   private DrawingModel drawingModel;
   private DrawingView drawingView;
   private MyShapeController myShapeController;
   private DragAndDropController dragAndDropController;
   private MyShapeControllerFactory shapeControllerFactory;
   
   // file management properties
   private JFileChooser fileChooser;
   private String fileName;
   private String absoluteFilePath;
   private boolean saved = true;
   
   private DrawingToolBar toolBar;
   private ZoomDialog zoomDialog;   
   
   // Actions for save, zoom, move, etc.
   private Action saveAction, saveAsAction, zoomAction, 
      moveAction, fillAction, gradientAction;

   // DrawingInternalFrame constructor
   public DrawingInternalFrame( String title ) 
   {
      super( title + " - " + ( ++openFrameCount ), true, true, 
         false, true );

      setDefaultCloseOperation( 
         WindowConstants.DO_NOTHING_ON_CLOSE );

      // create new DrawingModel
      drawingModel = new DrawingModel();
      
      // create new DrawingView for DrawingModel
      drawingView = new DrawingView( drawingModel );
      
      // register DrawingInternalFrame as a DrawingModel Observer
      drawingModel.addObserver( this );   
      
      // MyShapeControllerFactory for creating MyShapeControllers
      shapeControllerFactory = 
         MyShapeControllerFactory.getInstance();

      // create DragAndDropController for drag and drop operations
      dragAndDropController = 
         new DragAndDropController( drawingModel );
      
      // get default DragSource for current platform
      DragSource dragSource = DragSource.getDefaultDragSource();
      
      // create DragGestureRecognizer to register 
      // DragAndDropController as DragGestureListener
      dragSource.createDefaultDragGestureRecognizer( drawingView,
         DnDConstants.ACTION_COPY_OR_MOVE,
         dragAndDropController );
      
      // enable drawingView to accept drop operations, using
      // dragAndDropController as DropTargetListener
      drawingView.setDropTarget( new DropTarget( drawingView, 
         DnDConstants.ACTION_COPY_OR_MOVE, 
         dragAndDropController ) );

      // add drawingView to viewPanel, put viewPanel in
      // JScrollPane and add JScrollPane to DrawingInternalFrame
      JPanel viewPanel = new JPanel();
      viewPanel.add( drawingView );
      getContentPane().add( new JScrollPane( viewPanel ), 
         BorderLayout.CENTER );
          
      // create fileChooser and set its FileFilter
      fileChooser = new JFileChooser();
      fileChooser.setFileFilter( new DrawingFileFilter() );
      
      // show/hide ZoomDialog when frame activated/deactivated
      addInternalFrameListener( 
         new InternalFrameAdapter() {
         
            // when DrawingInternalFrame activated, make
            // associated zoomDialog visible
            public void internalFrameActivated( 
               InternalFrameEvent event ) 
            {
               if ( zoomDialog != null )  
                  zoomDialog.setVisible( true );
            }

            // when DrawingInternalFrame is deactivated, make
            // associated zoomDialog invisible
            public void internalFrameDeactivated( 
               InternalFrameEvent event ) 
            {
               if ( zoomDialog != null ) 
                  zoomDialog.setVisible( false );
            }
         }
         
      ); // end call to addInternalFrameListener
      
      // stagger each DrawingInternalFrame to prevent it from 
      // obscuring other InternalFrames
      setLocation( xOffset * openFrameCount,
         yOffset * openFrameCount ); 

      // add new DrawingToolBar to NORTH area
      toolBar = new DrawingToolBar();
      getContentPane().add( toolBar, BorderLayout.NORTH );
      
      // get name of first MyShape that shapeControllerFactory
      // supports and create MyShapeController
      String shapeName = 
         shapeControllerFactory.getSupportedShapes()[ 0 ];
      
      setMyShapeController( 
         shapeControllerFactory.newMyShapeController(
            drawingModel, shapeName ) );               
        
      // set DrawingInternalFrame size
      setSize( 500, 320 );   
      
   } // end DrawingInternalFrame constructor
   
   // get DrawingInternalFrame Save Action
   public Action getSaveAction() 
   { 
      return saveAction; 
   }
   
   // get DrawingInternalFrame Save As Action
   public Action getSaveAsAction() 
   { 
      return saveAsAction; 
   }
   
   // set Saved flag for current drawing and update frame
   // title to indicate saved state to user
   public void setSaved( boolean drawingSaved ) 
   {
      // set Saved property
      saved = drawingSaved;
      
      // get current DrawingInternalFrame title
      String title = getTitle();
      
      // if drawing is not saved and title does not end with
      // an asterisk, add asterisk to title
      if ( !title.endsWith( " *" ) && !isSaved() ) 
         setTitle( title + " *" );
      
      // if title ends with * and drawing has been saved, 
      // remove * from title
      else 
         
         if ( title.endsWith( " *" ) && isSaved() ) 
            setTitle( title.substring( 0, 
               title.length() - 2 ) );
      
      // enable save actions if drawing not saved
      getSaveAction().setEnabled( !isSaved() );
   }
   
   // return value of saved property
   public boolean isSaved() 
   { 
      return saved; 
   }
   
   // handle updates from DrawingModel
   public void update( Observable observable, Object object ) 
   { 
      // set saved property to false to indicate that
      // DrawingModel has changed
      setSaved( false ); 
   }
   
   // set fileName for current drawing
   public void setFileName( String file ) 
   {
      fileName = file;
      
      // update DrawingInternalFrame title
      setTitle( fileName );
   }
   
   // get fileName for current drawing
   public String getFileName() 
   { 
      return fileName; 
   }
   
   // get full path (absoluteFilePath) for current drawing
   public String getAbsoluteFilePath() 
   { 
      return absoluteFilePath; 
   }
   
   // set full path (absoluteFilePath) for current drawing
   public void setAbsoluteFilePath( String path ) 
   { 
      absoluteFilePath = path; 
   }
   
   // get DrawingModel for current drawing
   public DrawingModel getModel() 
   { 
      return drawingModel; 
   }
   
   // set JInternalFrame and ZoomDialog titles
   public void setTitle( String title )
   {
      super.setTitle( title );
      
      if ( zoomDialog != null )
         zoomDialog.setTitle( title );
   }
   
   // set MyShapeController for handling user input
   public void setMyShapeController( 
      MyShapeController controller )
   {
      // remove old MyShapeController
      if ( myShapeController != null ) {
         
         // remove mouse listeners
         drawingView.removeMouseListener( 
            myShapeController.getMouseListener() );
         
         drawingView.removeMouseMotionListener( 
            myShapeController.getMouseMotionListener() );
      }
      
      // set MyShapeController property
      myShapeController = controller;
      
      // register MyShapeController to handle mouse events
      drawingView.addMouseListener( 
         myShapeController.getMouseListener() );
      
      drawingView.addMouseMotionListener( 
         myShapeController.getMouseMotionListener() ); 
      
      // update new MyShapeController with currently selected
      // drawing properties (stroke size, color, fill, etc.)
      myShapeController.setStrokeSize( toolBar.getStrokeSize() );
      
      myShapeController.setPrimaryColor( 
         toolBar.getPrimaryColor() );
      
      myShapeController.setSecondaryColor( 
         toolBar.getSecondaryColor() );
      
      myShapeController.setDragMode( toolBar.getDragMode() );
      
      myShapeController.setShapeFilled( 
         toolBar.getShapeFilled() );
      
      myShapeController.setUseGradient( 
         toolBar.getUseGradient() );
      
   } // end method setMyShapeController

   // close DrawingInternalFrame; return false if drawing
   // was not saved and user canceled the close operation
   public boolean close() 
   {
      // if drawing not saved, prompt user to save
      if ( !isSaved() ) {
         
         // display JOptionPane confirmation dialog to allow
         // user to save drawing
         int response = JOptionPane.showInternalConfirmDialog( 
            this, "The drawing in this window has been " +
            "modified.  Would you like to save changes?",
            "Save Changes", JOptionPane.YES_NO_CANCEL_OPTION,
            JOptionPane.QUESTION_MESSAGE );
         
         // if user selects Yes, save drawing and close 
         if ( response == JOptionPane.YES_OPTION ) {        
            saveDrawing();
            dispose();
            
            // return true to indicate frame closed
            return true;
         }
         
         // if user selects No, close frame without saving
         else if ( response == JOptionPane.NO_OPTION ) {            
            dispose();
            return true;
         }
         
         // if user selects Cancel, do not save or close
         else            
            return false; // indicate frame was not closed
      }
      
      // if drawing has been saved, close frame
      else {         
         dispose();
         return true;
      }
      
   } // end method close 
  
   // open existing drawing from file
   public boolean openDrawing() 
   {
      // open JFileChooser Open dialog
      int response = fileChooser.showOpenDialog( this );
      
      // if user selected valid file, open an InputStream
      // and retrieve the saved shapes
      if ( response == fileChooser.APPROVE_OPTION ) {
         
         // get selecte file name
         String fileName = 
            fileChooser.getSelectedFile().getAbsolutePath();
         
         // get shapes List from file
         Collection shapes = 
            DrawingFileReaderWriter.readFile( fileName );
         
         // set shapes in DrawingModel
         drawingModel.setShapes( shapes );
         
         // set fileName property
         setFileName( fileChooser.getSelectedFile().getName() );
         
         // set absoluteFilePath property
         setAbsoluteFilePath( fileName );
         
         // set saved property
         setSaved( true );
         
         // return true to indicate successful file open
         return true;
      }
      
      // return false to indicate file open failed
      else 
         return false;
      
   } // end method openDrawing
   
   // save current drawing to file 
   public void saveDrawing() 
   { 
      // get absolute path to which file should be saved
      String fileName = getAbsoluteFilePath();
      
      // if fileName is null or empty, call saveDrawingAs
      if ( fileName == null || fileName.equals( "" ) )
         saveDrawingAs();
      
      // write drawing to given fileName
      else {
         DrawingFileReaderWriter.writeFile( drawingModel,
            fileName );
         
         // update saved property
         setSaved( true );
      }
      
   } // end method saveDrawing
   
   // prompt user for file name and save drawing
   public void saveDrawingAs() 
   {
      // display JFileChooser Save dialog
      int response = fileChooser.showSaveDialog( this );
      
      // if user selected a file, save drawing
      if ( response == fileChooser.APPROVE_OPTION ) 
      {
         // set absoluteFilePath property
         setAbsoluteFilePath(
            fileChooser.getSelectedFile().getAbsolutePath() );
         
         // set fileName property
         setFileName( fileChooser.getSelectedFile().getName() );
         
         // write drawing to file
         DrawingFileReaderWriter.writeFile( drawingModel,
            getAbsoluteFilePath() );
         
         // update saved property
         setSaved( true );
      }
      
   } // end method saveDrawingAs
   
   // display zoomDialog
   public void showZoomDialog() 
   {
      // if zoomDialog is null, create one
      if (zoomDialog == null)         
         zoomDialog = new ZoomDialog( getModel(), getTitle() );
      
      // make extant zoomDialog visible
      else
         zoomDialog.setVisible( true );
   }   
   
   // dispose DrawingInternalFrame
   public void dispose() 
   {
      // dispose associated zoomDialog
      if ( zoomDialog != null ) 
         zoomDialog.dispose();
      
      super.dispose();
   }   
   
   // JToolBar subclass for DrawingInternalFrame
   private class DrawingToolBar extends JToolBar {
      
      // user interface components
      private GradientIcon gradientIcon;
      private JPanel primaryColorPanel, secondaryColorPanel;
      private JButton primaryColorButton; 
      private JButton secondaryColorButton;
      private JComboBox shapeChoice, strokeSizeChoice;
      private JToggleButton gradientButton, fillButton; 
      private JToggleButton moveButton;         

      // DrawingToolBar constructor
      public DrawingToolBar()
      {
         // create JComboBox for choosing current shape type
         shapeChoice = new JComboBox( 
            shapeControllerFactory.getSupportedShapes() );
         shapeChoice.setToolTipText( "Choose Shape" );

         // when shapeChoice changes, get new MyShapeController 
         // from MyShapeControllerFactory
         shapeChoice.addActionListener( 
            new ActionListener() {

               public void actionPerformed( ActionEvent event ) 
               {
                  // get selected shape type
                  String className = 
                     shapeChoice.getSelectedItem().toString();
                  
                  setMyShapeController( 
                     shapeControllerFactory.newMyShapeController( 
                        drawingModel, className ) );
               }
            }
            
         ); // end call to addActionListener

         // create JComboBox for selecting stroke size
         strokeSizeChoice = new JComboBox( 
            new String[] { "1.0", "2.0", "3.0", "4.0", "5.0", 
               "6.0", "7.0", "8.0", "9.0", "10.0" } );
               
         strokeSizeChoice.setToolTipText( "Choose Line Width" );

         // set stroke size property to selected value
         strokeSizeChoice.addActionListener( 
            new ActionListener() {

               public void actionPerformed( ActionEvent event ) 
               {              
                  myShapeController.setStrokeSize(
                     getStrokeSize() );
               }
            }
         );      

         // create JToggleButton for filling shapes
         fillButton = new JToggleButton( "Fill" );

         fillAction = new AbstractDrawingAction( "Fill", null,
            "Fill Shape", new Integer( 'L' ) ) {

            public void actionPerformed( ActionEvent event ) 
            {
               myShapeController.setShapeFilled( 
                  getShapeFilled() );
            }
         };   

         fillButton.setAction( fillAction );

         // create GradientIcon to display gradient settings
         gradientIcon = new GradientIcon( Color.black, 
            Color.white );

         // create JToggleButton to enable/disable gradients
         gradientButton = new JToggleButton( gradientIcon );   

         gradientAction = new AbstractDrawingAction( "", 
            gradientIcon, "Use Gradient", new Integer( 'G' ) ) {

            public void actionPerformed( ActionEvent event ) 
            {
               myShapeController.setUseGradient(
                  getUseGradient() );
            }
         };         

         gradientButton.setAction( gradientAction );

         // create JPanel to display primary drawing color
         primaryColorPanel = new JPanel();
         primaryColorPanel.setPreferredSize(
            new Dimension( 16, 16 ) );
         primaryColorPanel.setOpaque( true );
         primaryColorPanel.setBackground( Color.black );

         // create JButton for changing color1
         primaryColorButton = new JButton();
         primaryColorButton.add( primaryColorPanel );

         // display JColorChooser for selecting startColor value
         primaryColorButton.addActionListener( 
            new ActionListener() {

               public void actionPerformed( ActionEvent event )
               {
                  Color color = JColorChooser.showDialog( 
                     DrawingInternalFrame.this, "Select Color", 
                     primaryColorPanel.getBackground() );

                  if ( color != null ) {
                     primaryColorPanel.setBackground( color );
                     gradientIcon.setStartColor( color );
                     myShapeController.setPrimaryColor( color );
                  }
               }
               
            } // end ActionListener inner class
            
         ); // end call to addActionListener

         // create JPanel to display secondary drawing color
         secondaryColorPanel = new JPanel();
         secondaryColorPanel.setPreferredSize( 
            new Dimension( 16, 16 ) );
         secondaryColorPanel.setOpaque( true );
         secondaryColorPanel.setBackground( Color.white );               

         // create JButton for changing secondary color
         secondaryColorButton = new JButton();
         secondaryColorButton.add( secondaryColorPanel );

         // display JColorChooser for selecting endColor value
         secondaryColorButton.addActionListener( 
            new ActionListener() {

               public void actionPerformed( ActionEvent event )
               {
                  Color color = JColorChooser.showDialog( 
                     DrawingInternalFrame.this, "Select Color", 
                     secondaryColorPanel.getBackground() );

                  if ( color != null ) {
                     secondaryColorPanel.setBackground( color );
                     gradientIcon.setEndColor( color );
                     myShapeController.setSecondaryColor( 
                        color );
                  }
               }
               
            } // end ActionListener inner class
         
         ); // end call to addActionListener

         // create Action for saving drawings
         Icon saveIcon = new ImageIcon( 
            DrawingInternalFrame.class.getResource( 
               "images/save.gif" ) );

         saveAction = new AbstractDrawingAction( "Save", saveIcon,
            "Save Drawing", new Integer( 'S' ) ) {

            public void actionPerformed( ActionEvent event ) 
            { 
               saveDrawing(); 
            }
         };

         // create action for saving drawings as given file name
         Icon saveAsIcon = new ImageIcon(
            DrawingInternalFrame.class.getResource( 
               "images/saveAs.gif" ) );

         saveAsAction = new AbstractDrawingAction( "Save As",
            saveAsIcon, "Save Drawing As", new Integer( 'A' ) ) {

            public void actionPerformed( ActionEvent event ) 
            { 
               saveDrawingAs(); 
            }
         };

         // create action for displaying zoomDialog
         Icon zoomIcon = new ImageIcon(
            DrawingInternalFrame.class.getResource( 
            "images/zoom.gif" ) );

         zoomAction = new AbstractDrawingAction( "Zoom", zoomIcon,
            "Show Zoom Window", new Integer( 'Z' ) ) {

            public void actionPerformed( ActionEvent event ) 
            { 
               showZoomDialog(); 
            }
         };

         // create JToggleButton for setting drag and drop mode
         moveButton = new JToggleButton();

         Icon moveIcon = new ImageIcon(
            DrawingInternalFrame.class.getResource( 
               "images/move.gif" ) );

         moveAction = new AbstractDrawingAction( "Move", null,
            "Move Shape", new Integer( 'M' ) ) {

            public void actionPerformed( ActionEvent event ) 
            {
               myShapeController.setDragMode(
                  getDragMode() );

               dragAndDropController.setDragMode(
                  getDragMode() );
            }
         };

         moveButton.setAction( moveAction );

         // add Actions, buttons, etc. to JToolBar
         add( saveAction );
         add( saveAsAction );
         addSeparator();
         add( zoomAction );         
         addSeparator();         
         add( shapeChoice );
         add( strokeSizeChoice );
         addSeparator();
         add( primaryColorButton );
         add( secondaryColorButton );
         addSeparator();
         add( gradientButton );
         add( fillButton );         
         addSeparator();
         add( moveButton );         
         
         // disable floating
         setFloatable( false );
         
      } // end DrawingToolBar constructor
      
      // get currently selected stroke size
      public float getStrokeSize()
      {
         Object selectedItem = strokeSizeChoice.getSelectedItem();

         return Float.parseFloat( selectedItem.toString() );
      }

      // get current shape filled value
      public boolean getShapeFilled()
      {
         return fillButton.isSelected();
      }

      // get current use gradient property
      public boolean getUseGradient()
      {
         return gradientButton.isSelected();
      }   

      // get primary drawing Color
      public Color getPrimaryColor()
      {
         return primaryColorPanel.getBackground();
      }

      // get secondary drawing Color
      public Color getSecondaryColor()
      {
         return secondaryColorPanel.getBackground();
      }

      // get current drag mode
      public boolean getDragMode()
      {
         return moveButton.isSelected();
      }      
      
   } // end DrawingToolBar inner class
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
