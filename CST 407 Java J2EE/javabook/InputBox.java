package javabook;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

/**
 * This dialog is for getting a single input value. You can
 * enter int, float, or double values.
 *<p> 
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit 
 * warranty is given.
 * 
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 */
public class InputBox extends JavaBookDialog
{
  
//-----------------------------------------
//
//    Data Members:
//
//-----------------------------------------
    
    /**
     * The default title for this dialog
     */
    private static final String DEFAULT_TITLE = "Input Box";   

    /**
     * The JTextField for the user to enter value
     */
    private JTextField  inputLine;
    
    /**
     * A JPanel for the content(message) portion of this dialog
     */
    private JPanel      contentPanel;
    
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
    public InputBox(Frame owner)
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
    public InputBox(Frame owner, boolean modal)
    {
        super( owner, modal );
        setTitle( DEFAULT_TITLE );
        setIcon( QUESTION_ICON );
    }


//-----------------------------------------------
//    Public Methods:
//
//      int     getInteger  (                   )
//      int     getInteger  ( String            )
//        
//      double  getDouble   (                   )
//      double  getDouble   ( String            )
//
//      float   getFloat    (                   )
//      float   getFloat    ( String            )
//
//      String  getString   (                   )
//      String  getString   ( String            )
//
//
//-----------------------------------------------

    /**
     * Allows the user to enter an integer value. Error message will
     * be displayed if the value entered cannot be converted to an 
     * int. Default prompt "Enter an integer:" is used.
     *
     * @return the integer value entered by the user
     *
     */
    public int getInteger( )
    {
        return getInteger( "Enter an integer:" );
    }

    /**
     * Allows the user to enter an integer value. Error message will
     * be displayed if the value entered cannot be converted to an 
     * int. The parameter is the prompt for this dialog.
     *
     * @param  text the prompt used in this dialog
     *
     * @return the integer value entered by the user
     *
     */
    public int getInteger( String text )
    {
        boolean done  = false;
        int     value = 0;
        
        createContentPanel( text );

        do {

            String inputValue = showDialog( );
             
            try {
                value = Integer.parseInt(inputValue);
                done = true;
            }

            catch (NumberFormatException e) {
               JOptionPane.showMessageDialog( getOwner(), 
                                              "Not a valid integer. Try again...", 
                                              "Error", 
                                              ERROR_ICON ); 
            }
        } while (!done);

        return value;
        
    }

    /**
     * Allows the user to enter a double value. Error message will
     * be displayed if the value entered cannot be converted to a 
     * double. Default prompt "Enter a double:" is used.
     *
     * @return the double value entered by the user
     *
     */    
    public double getDouble()
    {
        return getFloat("Enter a double:");
    }

    /**
     * Allows the user to enter a double value. Error message will
     * be displayed if the value entered cannot be converted to a 
     * double. The parameter is the prompt for this dialog.
     *
     * @param  text the prompt used in this dialog
     *
     * @return the double value entered by the user
     *
     */
    public double getDouble( String text )
    {
        boolean done  = false;
        double  value = 0;

        createContentPanel( text );
        
        do {
            String inputValue = showDialog( );
            
            try {
                value = Double.parseDouble(inputValue);
                done = true;
            }

            catch (NumberFormatException e) {
               JOptionPane.showMessageDialog( getOwner( ), 
                                              "Not a valid double. Try again...", 
                                              "Error", 
                                               ERROR_ICON ); 
            }
        } while (!done);

        return value;
        
    }
    
    /**
     * Allows the user to enter a double value. Error message will
     * be displayed if the value entered cannot be converted to a 
     * double. Default prompt "Enter a double:" is used.
     *
     * @return the double value entered by the user
     *
     */ 
    public float getFloat()
    {
        return getFloat("Enter a float:");
    }

    
    /**
     * Allows the user to enter a float value. Error message will
     * be displayed if the value entered cannot be converted to a 
     * float. The parameter is the prompt for this dialog.
     *
     * @param  text the prompt used in this dialog
     *
     * @return the float value entered by the user
     *
     */
    public float getFloat(String text)
    {
        boolean done = false;
        float value = 0f;

        createContentPanel( text );
        
        do {
            String inputValue = showDialog( );
            
            try {
                value = Float.parseFloat( inputValue );
                done = true;
            }

            catch (NumberFormatException e) {
               JOptionPane.showMessageDialog( getOwner(), 
                                              "Not a valid float. Try again...", 
                                              "Error", 
                                               ERROR_ICON ); 
            }
        } while (!done);

        return value;
        
    }

    /**
     * Allows the user to enter a String. 
     * Default prompt "Enter a string:" is used.
     *
     * @return the String value entered by the user
     *
     */ 
    public String getString()
    {
        return getString("Enter a string:");
    }

    /**
     * Allows the user to enter a String value. 
     * The parameter is the prompt for this dialog.
     *
     * @param  text the prompt used in this dialog
     *
     * @return the String value entered by the user
     *
     */
    public String getString( String text )
    {
        createContentPanel( text );
        
        return showDialog( );
    }

//-----------------------------------------------
//    Private Methods:
//
//
//           void    createContentPanel   (         )
//           int     showDialog           (         )
//
//-----------------------------------------------

    /**
     * Creates a JPanel that contains a JList. This panel
     * becomes the content portion of this dialog.
     */
    private void createContentPanel( String text )
    {
        JLabel     prompt = new JLabel( text );
       
        inputLine = new JTextField( 15 );
        
        contentPanel = new JPanel( );
        contentPanel.setLayout( new BoxLayout( contentPanel, 
                                               BoxLayout.Y_AXIS ) );
        contentPanel.add( prompt ); 
        contentPanel.add( inputLine );
      
    }

    /**
     * Displays this dialog using showOptionDialog and
     * returns the text entered by the user.
     *
     * return the String value entered by the user
     */
    private String showDialog( )
    {
         JOptionPane.showOptionDialog( getOwner( ),
                                       contentPanel,
                                       getTitle( ),
                                       JOptionPane.DEFAULT_OPTION,
                                       getIcon( ),
                                       null,
                                       new Object[]{"OK"},
                                       null );
                                              
         return inputLine.getText( );
         
         //--------NOTE-------------//
    /*
   Note1: You can't use the standard static method
          
              JOptionPane.showInputDialog
              
          here because the showInputDialog method will always 
          include two buttons: OK and Cancel. 
          For the javabook InputBox we want
          only the OK button.
          
   Note2: The current implementation does not distinguish
          the clicking of the OK button and closing the dialog. 
          If a valid entry is in the inputLine, the user can click
          the OK button or close the dialog. Either way, the input
          is accepted.  
    */
        //-------END NOTE----------//
    }

}