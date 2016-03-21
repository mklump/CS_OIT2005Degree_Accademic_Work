package javabook;

import java.awt.*;
import javax.swing.*;


/**
 * This dialog is for prompting a yes-no response from the user. This dialog
 * allows the programmer to add a single line of prompt with two standard
 * Yes and No buttons. Optionally, the dialog can be adjusted to have one,
 * two, or three buttons with programmer-designated button labels. Buttons
 * are identified by the constants BUTTON1, BUTTON2, and BUTTON3. For the 
 * standard two-button dialog, BUTTON1 and BUTTON2 can also be referred as
 * YES and NO, respectively.
 *
 *<p> 
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit 
 * warranty is given.
 * 
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 */
public class ResponseBox extends JavaBookDialog
{

//-----------------------------------------
//
//    Data Members:
//
//-----------------------------------------
    
    /**
     * The constant for the YES button
     */
    public static final int YES     = JOptionPane.YES_OPTION;
    
    /**
     * The constant for the NO button
     */
    public static final int NO      = JOptionPane.NO_OPTION;
    
    /**
     * The constant for the CANCEL button
     */
    public static final int CANCEL  = JOptionPane.CANCEL_OPTION;
    
    /**
     * The constant for the leftmost button whose value
     * is equal to YES
     */
    public static final int BUTTON1 = YES;
    
    /**
     * The constant for the middle button whose value
     * is equal to NO; this button is rightmost when
     * the dialog has only two buttons
     */
    public static final int BUTTON2 = NO;
    
    /**
     * The constant for the rightmost button whose value
     * is equal to CANCEL
     */
    public static final int BUTTON3 = CANCEL;

    /**
     * Default title of this dialog
     */
    private static String DEFAULT_TITLE = "Response Box";
    
    /**
     * Standard button labels
     */
    private String  labels[] = {"Yes", "No", "Cancel"};

    /**
     * The number of buttons this dialog has
     */
    private int     numberOfButtons;
    
    /**
     * The actual labels used in creating this dialog
     */
    private String  buttons[];

//-----------------------------------------
//
//    Constructors:
//
//-----------------------------------------
    
    /**
     * Constructs the standard ResponseBox dialog with
     * two buttons labeled 'Yes' and 'No'. Use setLabel
     * to change the button label.
     *
     * @param owner a Frame object owner of this dialog
     */
    public ResponseBox( Frame owner )
    {
        this( owner, 2 );
    }

    /**
     * Constructs this dialog with 'owner' as its owner and buttonCount
     * number of buttons. Valid values for buttonCount is 1, 2, or 3.
     * 
     * @param owner       a Frame object owner of this dialog
     * @param buttonCount the number of buttons this dialog has
     */
    public ResponseBox(Frame owner, int buttonCount)
    {
        super( owner, true );
        setTitle( DEFAULT_TITLE );
        setIcon ( QUESTION_ICON );

        if (buttonCount < 1 || buttonCount > 3) {
            numberOfButtons = 1;
        }
        else {
            numberOfButtons = buttonCount;
        }
        
        buttons = new String[numberOfButtons];
        
    }


//-----------------------------------------------
//    Public Methods:
//
//
//           int     prompt      ( String            )
//           void    setLabel    ( int,   String     )
//
//
//-----------------------------------------------

    /**
     * Prompts the user and returns the result
     * of user action.
     *
     * @param text the prompt message to display
     *
     * @return the value that indicates the user action
     */
    public int prompt(String text)
    {
        setButtons( );
        
        int value = JOptionPane.showOptionDialog( getOwner( ),
                                                  text,
                                                  getTitle( ),
                                                  JOptionPane.DEFAULT_OPTION,
                                                  getIcon( ),
                                                  null,
                                                  buttons,
                                                  null );
        return getSelectedButton( value );
    }

    /**
     * Sets the label of the designated button identified
     * by its id value.
     *
     * @param id   the id of the button
     * @param text the new label the button
     *
     */
    public void setLabel(int id, String text)
    { 
        switch ( id ) {
            case BUTTON1:  labels[0] = text;
                           break;
                           
            case BUTTON2:  labels[1] = text;
                           break;
                           
            case BUTTON3:  labels[2] = text;
                           break;
                           
            default:       //do nothing for invalid button#
                           break;
        }
        //--------NOTE-------------//
        /*
          You can write the code like 
          
              if (id < numberOfButtons && id >= 0) {
                  labels[id] = text;
              }
              
          It so happened that BUTTON1 == 0, BUTTON2 == 1, and
          BUTTON3 == 2, we can't be sure JOptionPane.YES_OPTION
          and others remain 0,1, and 2. So the switch statement
          as written is the right way
        */
        //-------END NOTE----------//
    }
 
//-----------------------------------------------
//    Private Methods:
//
//
//           void    getSelectedButton   ( int     )
//           void    setButtons          (         )
//
//-----------------------------------------------
    
    /**
     * Returns the result of user action. The return
     * value is one of YES, NO, and CANCEL. If the 
     * user closes the dialog without clicking any
     * button, then the result is CANCEL.
     *
     * @param button value returned from showOptionDialog
     * 
     * @return the button id value
     */
    private int getSelectedButton( int button )
    {
        int result = 0;
        
        switch ( button ) {
            case JOptionPane.CLOSED_OPTION:
            case CANCEL:
                          result = CANCEL;
                          break;
                          
            case YES:
            case NO:
                          result = button;
                          break;
        }
        
        return result;
    }
    
    
    /**
     * Creates the button array from the labels array. The button
     * array contains the labels for the buttons actually 
     * placed in the dialog.
     *
     */
    private void setButtons( )
    {
        for (int i = 0; i < numberOfButtons; i++) {
           buttons[i] = labels[i];
        }
    }
    


}