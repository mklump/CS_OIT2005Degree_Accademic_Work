package javabook;

import java.awt.*;
import javax.swing.*;


/**
 * This dialog is for accepting multiple input values. Input values are returned
 * as an array of String objects. You have to convert the String values to appropriate
 * data type in your code.
 *
 *<p> 
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit 
 * warranty is given.
 * 
 *<p>
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 */
public class MultiInputBox extends JavaBookDialog
{


//-----------------------------------------
//
//    Data Members:
//
//-----------------------------------------
    /**
     * Constant to represent no selection for
     * the getSelectedItem method.
     */
    public static final String[]  NO_ITEM      = null;

    /**
     * Default title for this dialog
     */
    private static final String  DEFAULT_TITLE = "MultiInput Box";

    /**
     * The constant to represent the state which the CANCEL button is clicked
     */    
    private final static int CANCEL  = -2;
    
    /**
     * The constant to represent this dialog is not canceled
     */    
    private final static int OK      = 0;  
    
    /**
     * The state of this dialog
     */
    private int status;

    /**
     * The array of TextField objects for accepting user input
     */
    private JTextField   inputLine[];
    
    /**
     * The array of labels for input lines
     */
    private JLabel       prompt[];
    
    /**
     * A JPanel for the content(message) portion of this dialog
     */
    private JPanel       contentPanel;
    
    /**
     * The number of input lines in this dialog
     */
    private int          numOfRows;
    
    /**
     * The flag to indicate whether to clear the input lines
     * or not after the getInputs method is called.
     */
    private boolean      resetInputLine;


//-----------------------------------------
//
//    Constructors:
//
//-----------------------------------------

    /**
     * Constructs a MultiInputBox with the owner frame and
     * size input lines.
     *
     * @param owner the owning Frame object
     * @param size  the number of input lines
     */
    public MultiInputBox(Frame owner, int size)
    {
        super( owner,true );
        setTitle( DEFAULT_TITLE );
        setIcon( QUESTION_ICON );
        
        numOfRows = size;
        
        prompt    = new JLabel[numOfRows];
        inputLine = new JTextField[numOfRows];
        
        for (int i = 0; i < numOfRows; i++) {
            prompt[i]    = new JLabel("");
            inputLine[i] = new JTextField( 15 );
        }
        
        setDialogState( OK );
        setResetOption( false );
        
    }

    /**
     * Constructs a MultiInputBox with the owner frame and
     * labels for input lines.
     *
     * @param owner  the owning Frame object
     * @param labels the array of String for input line labels
     */
    public MultiInputBox(Frame owner, String[] labels)
    {
        this(owner, labels.length);
        setLabels(labels);
    }


//-----------------------------------------------
//    Public Methods:
//
//
//            String[] getInputs       (                      )
//            boolean  isCanceled      (                      )
//
//            void     setLabels       ( String[]             )
//            void     setResetOption  ( boolean              )
//            void     setValue        ( int,   String        )
//
//----------------------------------------------

    /**
     * Returns the input values entered by the user. If the user
     * clicks the close box or the Cancel button, NO_ITEM is
     * returned. In this case, a subsequent call to isCanceled
     * will return true. If the user clicks the Ok button, an
     * array of Sring is returned. For those input lines that
     * contain no input value, the corresponding element in
     * the array is an empty string.
     *
     * @return an array of String values entered by the user
     */
    public String[] getInputs()
    {
        if (contentPanel == null) { //need to create contentPanel
            createContentPanel( );  //only once
        }
                
        int value = showDialog( );
                
        String result[] = getInputLines( value );
        
        if ( resetInputLine ) clearInputLines();
        
        return result;
    }

    /**
     * Returns true if the state of this dialog is CANCEL.
     *
     * @return the state of this dialog; true if CANCEL; false otherwise
     */
    public boolean isCanceled()
    {
        if (status == CANCEL) {
            return true;
        }
        else {
            return false;
        }
    }

    
    /**
     * Assigns the input line labels to the passed array
     *
     * @param label an array of String for input line labels
     */
    public void setLabels(String[] label)
    {
        for (int i = 0; i < label.length; i++) {
            prompt[i].setText(label[i]);
        }
    }
    
    /**
     * Sets the reset flag. Pass true to clear the input 
     * fields after the getInputs method is called. It
     * is useful to set the flag to false, so the input
     * fields are not reset when you enter a number of
     * similar data. Default is true so the input
     * fields are cleared after each appearance of this
     * dialog.
     *
     * @param option pass 'true' to reset the input fields
     */
    public void setResetOption( boolean option )
    {
        resetInputLine = option;
    }

    /**
     * Sets the value to the input line at the index position. This
     * method is useful to set default input values so the user
     * gets an hint on the type of values expected in the input lines.
     * This method does nothing when the index value is invalid.
     *
     * @param index the position of the input line to set the value
     * @param value the value to assign to the input line
     */
    public void setValue(int index, String value)
    {
        if (index >=0 && index < numOfRows) {
            inputLine[index].setText(value);
        }
        //ignore invalid index.
    }


//-----------------------------------------------
//    Private Methods:
//        
//        void         clearInputLines     (       )
//        void         createContentPanel  (       )
//        String[]     getInputLines       (       )
//
//        void         setDialogState      ( int   )
//        int          showDialog          (       )
//
//-----------------------------------------------

    /**
     * Clears the input lines by assigning empty String
     */
    private void clearInputLines()
    {
        for (int i = 0; i < numOfRows; i++) {
            inputLine[i].setText("");
        }
    }
    
    
    /**
     * Creates the content panel. This panel
     * becomes the content portion of this dialog.
     */
    private void createContentPanel( )
    {
        JPanel promptPanel = new JPanel();
        promptPanel.setLayout( new GridLayout( 0, 1 ) );  
              
        JPanel inputPanel = new JPanel();
        inputPanel.setLayout( new GridLayout( 0, 1 ) );
 
        for (int i = 0; i < numOfRows; i++) {
            promptPanel.add( prompt[i]    );
             inputPanel.add( inputLine[i] );
        }  
        
        contentPanel = new JPanel( );
        contentPanel.setLayout( new BoxLayout( contentPanel, 
                                               BoxLayout.X_AXIS ) );
        contentPanel.add( promptPanel );
        contentPanel.add( inputPanel  );
    }
 

    /**
     * Returns the contents of the input lines
     *
     * return an array of String currently in the input lines
     */

    private String[] getInputLines( int value )
    {
         String[] answer = new String[numOfRows];
         
         switch ( value ) {
           
            case JOptionPane.CLOSED_OPTION:
            case JOptionPane.NO_OPTION:
                                            //CANCEL_OPTION never matches with two buttons
                                            //The second button is NO_OPTION
                          
                          setDialogState( CANCEL );
                          answer = NO_ITEM;
                          break;
                          
            case JOptionPane.OK_OPTION:
        
                          for (int i = 0; i < numOfRows; i++) {
                               answer[i] = inputLine[i].getText( );
                          }
                          
                          setDialogState( OK );
                          break;
                          
            default:      answer = NO_ITEM;         //just in case; this case should
                          setDialogState( CANCEL ); //never happen
                          break;                 
        }        

        return answer;
    }
    
    /**
     * Sets the state of this dialog
     *
     * @param state the new state of this dialog
     */
    private void setDialogState( int state )
    {
        status = state;
    }
    
    /**
     * Displays this dialog using showOptionDialog and
     * returns the user action.
     *
     * return the id value of the user action
     */
    private int showDialog( )
    {
        return  JOptionPane.showOptionDialog( getOwner( ),
                                              contentPanel,
                                              getTitle( ),
                                              JOptionPane.DEFAULT_OPTION,
                                              getIcon( ),
                                              null,
                                              new Object[]{"OK", "Cancel"},
                                              null );
    }




}