package javabook;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

/**
 * This abstract class defines behavior and data members common to javabook 
 * dialogs such as MessageBox, InputBox, and others. You can use this class
 * as the superclass of your own dialog box. In this Swing version of javabook,
 * the JOptionPane class is used extensively. Many functionalities coded inside
 * the original javabook package are now handled automatically by the JOptionPane
 * class.
 *
 *<p> 
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit 
 * warranty is given.
 * 
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 */
public abstract class JavaBookDialog
{

//-----------------------------------------
//
//    Data Members
//
//-----------------------------------------
        
    /**
     * Constant for no icon
     */
    public static final int     NO_ICON       = JOptionPane.PLAIN_MESSAGE;
    
    /**
     * Constant for the information icon
     */
    public static final int     INFO_ICON     = JOptionPane.INFORMATION_MESSAGE;
    
    /**
     * Constant for the error icon
     */
    public static final int     ERROR_ICON    = JOptionPane.ERROR_MESSAGE;
    
    /**
     * Constant for the warning icon
     */
    public static final int     WARNING_ICON  = JOptionPane.WARNING_MESSAGE;
    
    /**
     * Constant for the question icon
     */
    public static final int     QUESTION_ICON = JOptionPane.QUESTION_MESSAGE;
        
    /**
     * Default title of this dialog
     */
    private static final String  DEFAULT_TITLE = "JavaBook Dialog";
    
    /**
     * The owner component of this dialog
     */
    private   Component  owner;
    
    /**
     * The modality of this dialog; true for modal and false for modeless
     */
    private   boolean    modal;
    
    /**
     * The title of this dialog
     */
    private   String     title;
    
    /**
     * The type of icon to be displayed in this dialog
     */
    private   int        icon;
    
    /**
     * The message content of this dialog
     */
    private   Object     message;
    
    /**
     * The JDialog object that actually does the work for this
     * dialog. In other words, this dialog contains a JDialog
     * object to provide dialog services.
     */
    private   JDialog    dialog;
    
    
//-----------------------------------------
//
//    Constructors:
//
//-----------------------------------------

    public JavaBookDialog( Component owner )
    {
        this( owner, true );
    }

    public JavaBookDialog( Component owner, boolean modal )
    {        
        setTitle  ( DEFAULT_TITLE );
        setModal  ( modal         );
        setIcon   ( NO_ICON       );
        setMessage( ""            ); 
        
        dialog = null;
    }

//----------------------------------------------
//    Public Methods:
//
//       void    setIcon      ( int        )       
//       void    setLocation  ( int,  int  )
//       void    setTitle     ( String     )
//
//----------------------------------------------

    /**
     * Sets the icon of this dialog
     *
     * @param icon  an icon to display on this dialog
     */
    public void setIcon( int icon )
    {
        this.icon = icon;
    }
    
    /** 
     * Sets the location of this dialog.
     *
     * @param x the x coordinate of this dialog's origin relative to the screen
     * @param y the y coordinate of this dialog's origin relative to the screen
     *
     */
    public void setLocation( int x, int y )
    {
        dialog.setLocation( x, y );
    }
    
    /**
     * Sets the title of this dialog
     *
     * @param title  a new title for this dialog
     */
    public void setTitle( String title )
    {
        this.title = title;
    }
    
    
    
//----------------------------------------------
//    Protected Methods:
//
//       void       createDialog  (            )
//
//       int        getIcon       (            )
//       Component  getOwner      (            )
//       String     getTitle      (            )
//
//       void       setMessage    (  Object    )
//       void       setModal      (  boolean   )
//
//       void       show          (            )
//
//----------------------------------------------
    
    /**
     * Creates a dialog based on the values set
     * for title, message, and icon.
     */
    protected void createDialog(  )
    {
        JOptionPane pane = new JOptionPane( message, icon );
        
        dialog = pane.createDialog( owner, title );
        dialog.setModal(modal);
    }                                       
    
    /**
     * Returns the currently set icon.
     *
     * @return int the current set icon
     */
    protected int getIcon( )
    {
        return icon;
    }
    
    /**
     * Returns the owner parent of this dialog
     *
     * @return Component the owner parent of this dialog
     */
    protected Component getOwner( )
    {
        return owner;
    }
    
    
    /**
     * Returns the title of this dialog
     *
     * @return String the title of this dialog
     */
    protected String getTitle( )
    {
        return title;
    }
    
    
    /**
     * Sets the message content of this dialog. The message
     * can be String, Component, Icon, or generic
     * Object. String and Component are displayed as is,
     * Icon is wrapped in a JLabel, and for generic 
     * Object, the String 
     * returned from toString is displayed.
     *
     * @param Object the message content of this dialog
     */
    protected void setMessage( Object message )
    {
        this.message = message;
    }
    
    
    /**
     * Sets the modality of this dialog. This method
     * is protected because its use should be restricted
     * to the descendant classes. The client programmer
     * should not be calling this method.
     *
     * @param modality  true for modal; false for modeless
     */
    protected void setModal( boolean modality )
    {
        this.modal = modality;
    }
   
    /**
     * Shows this dialog
     */
    protected void show( )
    {
        if ( dialog != null ) {
          
            dialog.show( );
        
        }
    }
    
}