package javabook;

import java.awt.*;
import java.awt.event.*;
import java.net.*;
import javax.swing.*;
import javax.swing.event.*;

/**
 * A simpleton web browser to illustrate the power of Swing classes.
 *
 * @author Dr Caffeine
 */
public class MiniBrowser extends JFrame implements HyperlinkListener {

    /** Default Width of this window */
    private final static int DEFAULT_WIDTH = 700;

    /** Default Height of this window */
    private final static int DEFAULT_HEIGHT = 500;

    /** Default home page to display */
    private final static String DEFAULT_HOME = "http://www.drcaffeine.com";

    /** Pane for showing URL contents */
    private JEditorPane browserPane;

    /** Text field for showing/entering URL */
    private JTextField  urlTextField;

    /** Current URL this browser is displaying */
    private String      currentURL;

    /**
     * Default constructor
     */
    public MiniBrowser( ) {

        this(DEFAULT_HOME);
    }

    /**
     * Constructs this object with urlString as
     * the starting page.
     *
     * @param urlString url to display
     */
    public MiniBrowser(String urlString) {

        super("Mini Browser");

        currentURL = urlString;

        createComponents( );
        createListeners( );

        setSize(DEFAULT_WIDTH, DEFAULT_HEIGHT);

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }

    /**
     * Sample main method
     *
     * @param args argument list
     */
    public static void main(String[] args) {

        MiniBrowser myBrowser = new MiniBrowser();
        myBrowser.setVisible(true);
    }

    /**
     * Handles the hyperlink event
     *
     * @param e hyperlink event
     */
    public void hyperlinkUpdate(HyperlinkEvent e) {

        if (e.getEventType() == HyperlinkEvent.EventType.ACTIVATED) {
            displayPage(e.getURL().toString());
        }
    }

    /**
     * Overrides the ancestor setVisible by adding the display
     * of url page.
     *
     * @param state true if visible
     */
    public void setVisible(boolean state) {

        super.setVisible(state);

        displayPage(currentURL);
    }

    /**
     * Create the UI components
     */
    private void createComponents( ) {

        Container contentPane = getContentPane();
        contentPane.setLayout(new BorderLayout());

        JPanel urlPanel = new JPanel();
        urlPanel.add(new JLabel("Currently Showing: "));
        urlTextField = new JTextField(currentURL, 50);
        urlPanel.add(urlTextField);
        contentPane.add(urlPanel, BorderLayout.NORTH);

        browserPane = new JEditorPane();
        browserPane.setEditable(false);
        contentPane.add(new JScrollPane(browserPane), BorderLayout.CENTER);
    }

    /**
     * Creates and associate the three event listeners.
     */
    private void createListeners( ) {

        //handle the 'enter' key press in the urlTextField
        urlTextField.addActionListener(new ActionListener() {

            public void actionPerformed(ActionEvent e) {
                displayPage(e.getActionCommand());
            }
        });

        //handle the window closing event
        this.addWindowListener(new WindowAdapter() {

            public void WindowClosing(WindowEvent e) {
                System.exit(0);
            }
        });

        //handle the mouse click on the hyperlink
        browserPane.addHyperlinkListener(this);
    }

    /**
     * Displays the given url page
     *
     * @param urlString string representing the url
     */
    private void displayPage(String urlString) {

        try {
            URL url = new URL(urlString);
            browserPane.setPage(url);
            urlTextField.setText(urlString);
            currentURL = urlString;
        }
        catch (Exception e) {
            JOptionPane.showMessageDialog(this, "Can't open " + urlString);
        }
    }
}
