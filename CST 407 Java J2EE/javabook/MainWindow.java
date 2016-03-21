package javabook;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

/**
 * This class is used as the top-level main window of an application. The MainWindow
 * window will be almost as big as the screen and positioned at the center
 * of the screen. When the user closes this window, the program is terminated.
 *
 *<p>
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit
 * warranty is given.
 *
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 */
public class MainWindow extends JFrame
{

//-----------------------------------------
//
//    Data Members:
//
//-----------------------------------------

    /**
     * Default title for this dialog
     */
    private static final String  DEFAULT_TITLE = "Sample Java Application";

    /**
     * The left and right margins between the screen and
     * this window's left and right boundaries
     */
    private static final int HORIZONTAL_MARGIN = 40;

    /**
     * The top and bottom margins between the screen and
     * this window's top and bottom boundaries
     */
    private static final int VERTICAL_MARGIN   = 80;

    /**
     * The size of the screen
     */
    private Dimension screenSize;


//-----------------------------------------
//
//    Constructors:
//
//-----------------------------------------

    /**
     * Default constructor. The title is fixed to "Sample Java Application".
     */
    public MainWindow()
    {
        this( DEFAULT_TITLE );
    }

    /**
     * Creates a new MainWindow object with the designated title.
     *
     * @param title the title of the window
     */
    public MainWindow(String title)
    {
        super(title);
        initialize( true );
    }

//----------------------------------------------
//    Protected Methods:
//
//       void moveToCenter (   )
//
//----------------------------------------------

    /**
     * Moves this dialog to the center of the screen.
     */
    protected void moveToCenter()
    {
         Dimension selfBounds = getSize();
         setLocation((screenSize.width - selfBounds.width) / 2,
                     (screenSize.height - selfBounds.height) / 2);
    }

//----------------------------------------------
//    Private Methods:
//
//           void initialize   (   )
//
//----------------------------------------------

    /**
     * Initializes this window by setting its size and position.
     * The size is set to be almost as big as the screen and the
     * position is set to the center of the screen. This window
     * will display the image at the center of this window.
     * If the specified file
     * is not located in the directory, then no image will be displayed
     * and no error will be generated.
     *
     * @param loadImage load the center image if true
     */
    private void initialize( boolean loadImage )
    {
        Toolkit toolkit = Toolkit.getDefaultToolkit();
        screenSize      = toolkit.getScreenSize();

        setSize(screenSize.width-HORIZONTAL_MARGIN,screenSize.height-VERTICAL_MARGIN);

        Container contentPane = getContentPane();
        contentPane.setBackground( Color.white );

        moveToCenter();

        setDefaultCloseOperation(EXIT_ON_CLOSE);
    }

}