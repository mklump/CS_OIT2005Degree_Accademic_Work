package javabook;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

/**
 * This dialog is for displaying a single line of text. This dialog is intended
 * for displaying a short warning or error message. The width of this dialog
 * is adjusted to fit the displayed message and the dialog is placed at the center 
 * of the screen, unless you change it by using calling the setLocation method.
 *
 *<p> 
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit 
 * warranty is given.
 * 
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 */
public class MessageBox extends JavaBookDialog
{
  
//-----------------------------------------
//
//    Data Members:
//
//-----------------------------------------
    
	  /**
     * The default title for this dialog
     */
    private static final String DEFAULT_TITLE = "Message Box";   

//-----------------------------------------
//
//    Constructors:
//
//-----------------------------------------

    /**
     * Default constructor.
     *
     * @param owner a Frame object owner of this dialog
     */
    public MessageBox(Frame owner)
    {
      	this(owner, true);
    }

	  /**
     * Constructs this dialog with 'owner' as its owner and display
     * this dialog as modal if the parameter is true. Otherwise, display
     * this dialog as modeless.
     * 
     * @param owner a Frame object owner of this dialog
     * @param modal true for modal dialog; false for modeless dialog
     */
    public MessageBox(Frame owner, boolean modal)
    {
        super( owner, modal );
        setTitle( DEFAULT_TITLE );
        setIcon( INFO_ICON );
    }


//-----------------------------------------------
//    Public Methods:
//
//
//            void    show        ( long                      )
//            void    show        ( double                    )
//            void    show        ( String                    )
//            void    show        ( StringBuffer              )
//
//            void    show        ( long         , int        )
//            void    show        ( double       , int        )
//            void    show        ( String       , int        )
//            void    show        ( StringBuffer , int        )
//
//            void    show        ( long         , int, int   )
//            void    show        ( double       , int, int   )
//            void    show        ( String       , int, int   )
//            void    show        ( StringBuffer , int, int   )
//
//            void    show        ( long         , int, int , int    )
//            void    show        ( double       , int, int , int    )
//            void    show        ( String       , int, int , int    )
//            void    show        ( StringBuffer , int, int , int    )
//
//-----------------------------------------------

    /**
     * Displays the integer value after converting it to a string. 
     *
     * @param number the integer value to display
     *
     */
    public void show (long number)
    {
        show(" " + number + " ");
    }

    /**
     * Displays the real number after converting it to a string. 
     *
     * @param number the real value to display
     *
     */
    public void show (double number)
    {
        show(" " + number + " ");
    }
    
    /**
     * Displays the String value. 
     *
     * @param text the String value to display
     *
     */    
    public void show (String text)
    {
        setMessage( text );
        createDialog( );
        super.show( );
    }
 
    /**
     * Displays the StringBuffer value after conveting it to a string. 
     *
     * @param text the StringBuffer value to display
     *
     */
    public void show (StringBuffer text)
    {
        show( text.toString() );
    }
    
    
    /**
     * Displays the integer value after converting it to a string.
     * Uses the designated icon in this dialog. Designated icon
     * is used only once here in this display. If you want all
     * subsequent shows to display the same icon, then use 
     * the setIcon method.
     *
     * @param number the integer value to display
     * @param icon   the icon to display
     *
     */
    public void show (long number, int icon )
    {
        show( " " + number + " ", icon );
    }

    /**
     * Displays the real number after converting it to a string. 
     * Uses the designated icon in this dialog. Designated icon
     * is used only once here in this display. If you want all
     * subsequent shows to display the same icon, then use 
     * the setIcon method.
     *
     * @param number the real value to display
     * @param icon   the icon to display
     *
     */
    public void show (double number, int icon )
    {
        show( " " + number + " ", icon );
    }
    
    /**
     * Displays the String value. 
     * Uses the designated icon in this dialog. Designated icon
     * is used only once here in this display. If you want all
     * subsequent shows to display the same icon, then use 
     * the setIcon method.
     *
     * @param text the String value to display
     * @param icon   the icon to display
     *
     */    
    public void show (String text, int icon )
    {
        int currentIcon = getIcon( );
        setIcon( icon ); //temporarily change the icon
        
        setMessage( text );
        createDialog( );
        super.show( );
        
        setIcon( currentIcon ); //restore the previous icon
    }
 
    /**
     * Displays the StringBuffer value after conveting it to a string. 
     * Uses the designated icon in this dialog. Designated icon
     * is used only once here in this display. If you want all
     * subsequent shows to display the same icon, then use 
     * the setIcon method.
     *
     * @param text the StringBuffer value to display
     * @param icon   the icon to display
     *
     */
    public void show (StringBuffer text, int icon )
    {
        show( text.toString(), icon );
    }


    /**
     * Displays the integer value after converting it to a string. 
     * Position this dialog at (x, y).
     *
     * @param number the integer value to display
     * @param x      the x-coordinate of this dialog's origin
     * @param y      the y-coordiante of this dialog's origin
     *
     */
    public void show (long number, int x, int y)
    {
        show(" " + number + " ", x, y);
    }

    /**
     * Displays the real number after converting it to a string. 
     * Position this dialog at (x, y).
     *
     * @param number the real value to display
     * @param x      the x-coordinate of this dialog's origin
     * @param y      the y-coordiante of this dialog's origin
     *
     */
    public void show (double number, int x, int y)
    {
        show(" " + number + " ",  x, y);
    }

    /**
     * Displays the String value. 
     * Position this dialog at (x, y).
     *
     * @param text the String value to display
     * @param x      the x-coordinate of this dialog's origin
     * @param y      the y-coordiante of this dialog's origin
     *
     */
    public void show (String text, int x, int y)
    {      
        setMessage( text );
        createDialog( );
        setLocation( x, y );
        super.show( );
    }

    /**
     * Displays the StringBuffer value after conveting it to a string. 
     * Position this dialog at (x, y).
     *
     * @param text the StringBuffer value to display
     * @param x      the x-coordinate of this dialog's origin
     * @param y      the y-coordiante of this dialog's origin
     *
     */
    public void show (StringBuffer text, int x, int y)
    {
        show(text.toString(), x, y);
    }
    
    
    /**
     * Displays the integer value after converting it to a string. 
     * Position this dialog at (x, y).
     *
     * @param number the integer value to display
     * @param x      the x-coordinate of this dialog's origin
     * @param y      the y-coordiante of this dialog's origin
     * @param icon   the icon to display
     *
     */
    public void show ( long number, int x, int y, int icon )
    {
        show(" " + number + " ", x, y, icon );
    }

    /**
     * Displays the real number after converting it to a string. 
     * Position this dialog at (x, y).
     *
     * @param number the real value to display
     * @param x      the x-coordinate of this dialog's origin
     * @param y      the y-coordiante of this dialog's origin
     * @param icon   the icon to display
     *
     */
    public void show (double number, int x, int y, int icon )
    {
        show(" " + number + " ",  x, y, icon );
    }

    /**
     * Displays the String value. 
     * Position this dialog at (x, y).
     *
     * @param text the String value to display
     * @param x      the x-coordinate of this dialog's origin
     * @param y      the y-coordiante of this dialog's origin
     * @param icon   the icon to display
     *
     */
    public void show (String text, int x, int y, int icon )
    {  
        int currentIcon = getIcon( );
        setIcon( icon );  //temporarily set the designated icon
        
        setMessage( text );
        createDialog( );
        setLocation( x, y );
        super.show( );
        
        setIcon( currentIcon ); //restore the previous icon
    }

    /**
     * Displays the StringBuffer value after conveting it to a string. 
     * Position this dialog at (x, y).
     *
     * @param text the StringBuffer value to display
     * @param x      the x-coordinate of this dialog's origin
     * @param y      the y-coordiante of this dialog's origin
     * @param icon   the icon to display
     *
     */
    public void show (StringBuffer text, int x, int y, int icon )
    {
        show( text.toString(), x, y, icon );
    }
}