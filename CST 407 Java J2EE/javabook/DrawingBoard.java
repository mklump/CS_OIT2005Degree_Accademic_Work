package javabook;

import java.awt.*;

/**
 * This class allows the drawing of lines, circles, and rectangles in the programmer
 * designated color.
 * <p>
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit 
 * warranty is given.
 * 
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 * @see Graphics
 */
public class DrawingBoard extends MainWindow
{

//----------------------------------
//    Data Members:
//----------------------------------

    /**
     * The Graphics object used in the drawing.
     * 
     * @see java.awt.Graphics
     */
    private Graphics g;

    
//-----------------------------------
//    Constructors
//-----------------------------------
    
    /**
     * Default constructor that creates an instance of DrawingBoard with the title
     * "D R A W I N G  B O A R D"
     */
    public DrawingBoard()
    {
       this("D R A W I N G   B O A R D");
    }

    /**
     * Constructor that creates an instance of DrawingBoard with the designated title.
     * 
     * @param title the title of the window
     */
    public DrawingBoard(String title)
    {
        super(title);
        setResizable(false);
        setBackground(Color.white);
    }
    
//-----------------------------------------------
//    Public Methods:
//
//        void    drawCircle     ( int, int, int       )
//        void    drawLine       ( int, int, int, int  )
//        
//        void    drawRectangle  ( int, int, int, int  )
//        void    drawRectangle  ( Rectangle           )
//
//        void    setColor       ( Color               )
//        void    setVisible     ( boolean             )
//        void    show           (                     )
//
//-------------------------------------------------

    /**
     * Draws a circle whose center point is designated by the parameters x and y. The 
     * circle's radius is set by the third parameter.
     * 
     * @param x      x coordinate of the circle's center
     * @param y      y coordinate of the circle's center
     * @param radius this circle's radius
     */
    public void drawCircle(int x, int y, int radius)
    {
        g.drawOval(x-radius,y-radius,2*radius,2*radius);
    }
    
    /**
     * Draws a line between two designated points p1 and p2.
     * 
     * @param x1 x coordinate of the first point p1
     * @param y1 y coordinate of the first point p1
     * @param x2 x coordinate of the second point p2
     * @param y2 y coordinate of the second point p2
     */
    public void drawLine(int x1, int y1, int x2, int y2)
    {
        g.drawLine(x1,y1,x2,y2);
    }

    /**
     * Draws a rectangle with its origin (top, leftmost corner) at (x,y). Its width and 
     * height are determined by the paramaters width and height.
     * 
     * @param x      x coordinate of the origin point
     * @param y      y coordinate of the origin point
     * @param width  the rectangle's width in pixels
     * @param height the rectangle's height in pixels
     */
    public void drawRectangle(int x, int y, int width, int height)
    {
        g.drawRect(x,y,width,height);
    }

    /**
     * Draws a rectangle whose dimension is designated by the parameter rect of type 
     * Rectangle.
     * 
     * @param rect specifies the dimension of the rectangle.
     * @see java.awt.Rectangle
     */
    public void drawRectangle(Rectangle rect)
    {
        g.drawRect(rect.x, rect.y, rect.width, rect.height);
    }
    
 
    /**
     * Sets the drawing color to the argument Color object. All subsequent drawings will be done
     * in the set color.
     * 
     * @param c the color of all subsequent drawings
     */
    public void setColor(Color c)
    {
        g.setColor(c);
    }
    
    /**
     * Makes the window appear on disappear from the screen.
     * 
     * @param view The value 'true' makes the window appear on the screen and 'false' makes it
     * disappear from the screen.
     */
    public void setVisible(boolean view)
    {
        super.setVisible(view);
        if (view) {
           g = getGraphics();
        }
    }

    /**
     * Makes the window appear on the screen.
     * 
     * @deprecated This method is supported for backward compatibility. Use setVisible.
     */
    public void show()
    {
        super.show();
        g = getGraphics();
    }

}
