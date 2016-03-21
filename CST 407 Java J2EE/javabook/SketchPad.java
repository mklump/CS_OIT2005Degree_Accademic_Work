package javabook;

import java.awt.*;
import java.awt.event.*;

/**
 * This window supports a freehand drawing. You draw pictures by dragging the while
 * holding the left button down (the only button for a single-button mouse). 
 * You erase the drawing by clicking the right button (ctrl-click on a single-button
 * mouse). This window does not have a "memory" so if you minimize and restore this 
 * window, for example, the drawing will be gone.
 *
 *<p> 
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit 
 * warranty is given.
 * 
 *<p>
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 */
public class SketchPad extends MainWindow
{
    
//----------------------------------
//    Data Members:
//----------------------------------
    
    /**
     * Default title of this dialog
     */
    private static final String DEFAULT_TITLE = "SketchPad For Your Doodle Art";
      
    /**
     * Default width of this dialog
     */
    private static final int    DEFAULT_WIDTH  = 500;
    
    /**
     * Default height of this dialog
     */
    private static final int    DEFAULT_HEIGHT = 400;

    /**
     * The X coordinate of the last position of the mouse
     */
    private int last_x;
    
    /**
     * The Y coordinate of the last position of the mouse
     */
    private int last_y;

    
//-----------------------------------------
//
//    Constructors:
//
//-----------------------------------------

    /**
     * Default Constructor. The default title is 
     * "SketchPad For Your Doodle Art"
     *
     */
    public SketchPad()
    {
        this( DEFAULT_TITLE );
    }
    
    
    /**
     * Constructs a SketchPad object with the parameter title
     *
     * @param title the title of this window
     */
    public SketchPad(String title)
    {
      //  super( title, false );
        super(title);
        initialize( );
    }


//-----------------------------------------------
//    Private Methods:
//        
//        void         initialize       (       )
//
//-----------------------------------------------
    
   /**
    * Initializes the components in this dialog. 
    * Anonymous inner classes are used for 
    * mouse listener and mouse motion listener.
    */
    private void initialize()
    {
        last_x = 0;
        last_y = 0;
      
        setSize( DEFAULT_WIDTH, DEFAULT_HEIGHT );
        moveToCenter( );
        
        addMouseMotionListener(
           new MouseMotionAdapter() 
           {
              public void mouseDragged(MouseEvent e) 
              {
                 if (!e.isMetaDown()) { 
                     //don't process right button drag
  
                      int x = e.getX();
                      int y = e.getY();
    
                      Graphics g = getGraphics();
                      g.drawLine(last_x, last_y, x, y);
                      last_x = x;
                      last_y = y;
                      
                      g.dispose( );
                 }
              }
           }   
        );
      
        addMouseListener(
           new MouseAdapter() 
           {
               public void mousePressed(MouseEvent e) {
                   if (e.isMetaDown()) {
                      //erase the content if it is a rightbutton
                      repaint();
                   }
                   else {
                      //reset for a new mouse drag
                      last_x = e.getX();
                      last_y = e.getY();
                   }
              }
           }
        );
    }
}