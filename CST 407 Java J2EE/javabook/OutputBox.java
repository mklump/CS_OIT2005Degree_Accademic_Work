package javabook;

import java.awt.*;
import java.awt.event.*;
import java.io.*;
import javax.swing.*;

/**
 * This dialog is for displaying the program output. You can save the output to
 * a designated file with using either appendToFile or saveToFile.
 *
 *<p>
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit
 * warranty is given.
 *
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 */
public class OutputBox extends JDialog
{

//----------------------------------
//    Data Members:
//----------------------------------

    /**
     * Default title of this dialog
     */
    private static final String DEFAULT_TITLE = "Program Output";

    /**
     * Default width of this dialog
     */
    private static final int    DEFAULT_WIDTH = 550;

    /**
     * Default height of this dialog
     */
    private static final int    DEFAULT_HEIGHT = 380;

    /**
     * Maximum number for skipping lines
     */
    private static final int    MAX_SKIPLINE  = 21;

    /**
     * The default font used for the text
     */
    private static Font        font;

    /**
     * The system-dependent line separator for new line
     */
    private static String      newLine;

    /**
     * The constant to represent the state of action pending
     */
    private JTextArea    outputArea;


//------------- Static initializer ----------------//
    static {
        newLine = System.getProperty("line.separator");
        font    = new Font("Courier",Font.PLAIN, 12);
    }

//-----------------------------------------
//
//    Constructors:
//
//-----------------------------------------

    /**
     * Constructs a OutputBox whose dimension is set the parameters
     * width and height, window title is set to the parameter
     * title, and the owning frame to the parameter owner.
     *
     * @param owner  the owning Frame object
     * @param width  the width of this dialog
     * @param height the height of this dialog
     * @param title  the window title of this dialog
     */
    public OutputBox(Frame owner, int width, int height, String title)
    {
        super(owner, false);

        initialize(width, height, title);
    }

    /**
     * Constructs a OutputBox whose dimension is the parameters
     * width and height and the owning frame is the parameter owner.
     *
     * @param owner  the owning Frame object
     * @param width  the width of this dialog
     * @param height the height of this dialog
     */
    public OutputBox(Frame owner, int width, int height)
    {
       this(owner, width, height, DEFAULT_TITLE);
    }

    /**
     * Constructs a OutputBox whose window title is the parameter
     * title, and the owning frame is the parameter owner.
     *
     * @param owner  the owning Frame object
     * @param title  the window title of this dialog
     */
    public OutputBox(Frame owner, String title)
    {
       this(owner, DEFAULT_WIDTH, DEFAULT_HEIGHT, title);
    }

    /**
     * Constructs a OutputBox whose dimension owning frame is
     * the parameter owner.
     *
     * @param owner  the owning Frame object
     */
    public OutputBox(Frame owner)
    {
       this(owner, DEFAULT_TITLE);
    }


//-----------------------------------------------
//    Public Methods:
//
//            void    appendToFile    ( String  )
//            void    clear           (         )
//
//            void    print           ( boolean )
//            void    print           ( char    )
//            void    print           ( double  )
//            void    print           ( long    )
//            void    print           ( String  )
//            void    print           ( StringBuffer  )
//
//            void    printLine       ( boolean )
//            void    printLine       ( char    )
//            void    printLine       ( double  )
//            void    printLine       ( long    )
//            void    printLine       ( String  )
//            void    printLine       ( StringBuffer  )
//
//            void    println         ( boolean )
//            void    println         ( char    )
//            void    println         ( double  )
//            void    println         ( long    )
//            void    println         ( String  )
//            void    println         ( StringBuffer  )
//
//            void    setFont         ( Font    )
//            void    skipLine        ( int     )
//            void    saveToFile      ( String  )
//
//            void    waitUntilClose  (         )
//
//----------------------------------------------

    /**
     * Appends the content of this dialog to filename.
     *
     * @param fileName the name of the file to save the content of this dialog
     */
    public void appendToFile( String fileName )
    {
        writeToFile(fileName, true);
    }


    /**
     * Implements the required method of the ActionListener. Do not call this
     * method. The Java virtual machine handles the action event processing.
     * This method sets this dialog's state depending on whether the OK or
     * CANCEL button is pressed.
     *
     * @param e the ActionEvent object.
     *
     */
    public void clear()
    {
        //clears the whole content
        outputArea.setText("");
    }


    /**
     * Prints out boolean b.
     *
     * @param b boolean data to output
     */
    public void print(boolean b)
    {
        print("" + b);
    }

    /**
     * Prints out char ch.
     *
     * @param ch char data to output
     */
    public void print(char ch)
    {
        print("" + ch);
    }

    /**
     * Prints out a real number.
     *
     * @param number real number value to output
     */
    public void print(double number)
    {
        print("" + number);
    }

    /**
     * Prints out an integer number.
     *
     * @param number integer value to output
     */
    public void print(long number)
    {
        print("" + number);
    }

    /**
     * Prints out text.
     *
     * @param text String object to output
     */
    public void print(String text)
    {
        outputArea.append(text);
    }

    /**
     * Prints out strBuf.
     *
     * @param strBuf StringBuffer object to output
     */
    public void print(StringBuffer strBuf)
    {
        print(strBuf.toString());
    }

    /**
     * Prints out boolean b and moves the cursor to the next line.
     *
     * @param b boolean data to output
     */
    public void printLine(boolean b)
    {
        printLine("" + b);
    }

    /**
     * Prints out char ch and moves the cursor to the next line.
     *
     * @param ch char data to output
     */
    public void printLine(char ch)
    {
        printLine("" + ch);
    }

    /**
     * Prints out a real number and moves the cursor to the next line.
     *
     * @param number real number value to output
     */
    public void printLine(double number)
    {
        printLine("" + number);
    }

    /**
     * Prints out an integer number and moves the cursor to the next line.
     *
     * @param number integer value to output
     */
    public void printLine(long number)
    {
        printLine("" + number);
    }

    /**
     * Prints out text and moves the cursor to the next line.
     *
     * @param text String object to output
     */
    public void printLine(String text)
    {
        print(text);
        newLine();
    }

    /**
     * Prints out strBuf and moves the cursor to the next line.
     *
     * @param strBuf StringBuffer object to output
     */

    public void printLine(StringBuffer strBuf)
    {
        printLine(strBuf.toString());
    }

    /**
     * Prints out boolean b and moves the cursor to the next line.
     *
     * @param b boolean data to output
     */
    public void println(boolean b)
    {
        printLine("" + b);
    }

    /**
     * Prints out char ch and moves the cursor to the next line.
     *
     * @param ch char data to output
     */
    public void println(char ch)
    {
        printLine("" + ch);
    }

    /**
     * Prints out a real number and moves the cursor to the next line.
     *
     * @param number real number value to output
     */
    public void println(double number)
    {
        printLine("" + number);
    }

    /**
     * Prints out an integer number and moves the cursor to the next line.
     *
     * @param number integer value to output
     */
    public void println(long number)
    {
        printLine("" + number);
    }

    /**
     * Prints out text and moves the cursor to the next line.
     *
     * @param text String object to output
     */
    public void println(String text)
    {
        print(text);
        newLine();
    }

    /**
     * Prints out strBuf and moves the cursor to the next line.
     *
     * @param strBuf StringBuffer object to output
     */

    public void println(StringBuffer strBuf)
    {
        printLine(strBuf.toString());
    }


    /**
     * Saves the content of this dialog to fileName. If the
     * designated file already contains data, they will be
     * erased.
     *
     * @param fileName the name of file to save the content of this dialog.
     */
    public void saveToFile( String fileName )
    {
        writeToFile(fileName, false);
    }

    /**
     * Sets the font of this dialog to the parameter font.
     *
     * @param font the new font to use for subsequent output
     */
    public void setFont(Font font)
    {
        if (outputArea != null) {
            outputArea.setFont(font);
        }

        this.font = font;
    }

    /**
     * Skips the numberOfLines lines.
     *
     * @param numberOfLines the number of lines to skip
     */
    public void skipLine(int numberOfLines)
    {
        if (numberOfLines > 0 && numberOfLines < MAX_SKIPLINE) {
            for (int i = 0; i < numberOfLines; i++) {
                newLine();
            }
        }
    }

    /**
     * Changes this dialog to modal and thereby causes the
     * program execution to pause until this dialog is closed.
     */
    public void waitUntilClose( )
    {
        setVisible(false);
        setModal(true);
        setVisible(true);
    }


//-----------------------------------------------
//    Private Methods:
//
//        void    initialize   ( int, int, String  )
//        void    newLine      (                   )
//        void    writeToFile  ( String, boolean   )
//
//-----------------------------------------------

   /**
    * Initializes the components in this dialog.
    *
    * @param width  the width of this dialog
    * @param height the height of this dialog
    * @param title  the title of this dialog
    */
    private void initialize(int width, int height, String title)
    {
        setResizable(true);
        setTitle(title);

        outputArea = new JTextArea( );
        setContentPane(new JScrollPane(outputArea)); //make it scrollable
        setFont(font);

        setSize(width, height);

        moveToCenter();

        addWindowListener(
            new WindowAdapter( )
            {
                public void windowClosing(WindowEvent e)
                {
                    dispose();
                    setModal(false);
                }
            }
        );
    }

    /**
     * Moves this dialog to the center of the screen.
     */
    private void moveToCenter( )
    {
         Toolkit toolkit = Toolkit.getDefaultToolkit();

         Dimension screenSize  = toolkit.getScreenSize();
         Dimension selfBounds  = getSize();

         setLocation((screenSize.width - selfBounds.width) / 2,
                     (screenSize.height - selfBounds.height) / 2);
    }

    /**
     * Skips a line. Output continues from the next line.
     *
     */
    private void newLine()
    {
        outputArea.append( newLine );
    }

    /**
     * Saves the content of this dialog to the filename.
     * If the parameter append is true, the content is append
     * at the end of the file if it is not empty.
     *
     * @param filename the name of the file to save the content of this dialog
     * @param append   true will append the content to the existing file;
     *                 false will overwrite any existing file content.
     */
    private void writeToFile( String fileName, boolean append)
    {
        try
        {
            FileWriter outputFile = new FileWriter(fileName, append);
            outputFile.write(outputArea.getText());
            outputFile.close();
        }
        catch (IOException e)
        {
        }
    }


}

