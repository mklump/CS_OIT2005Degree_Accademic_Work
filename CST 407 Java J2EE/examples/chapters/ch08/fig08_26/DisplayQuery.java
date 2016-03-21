///-------------------------------------------------------------------
/// Author:            Matthew Klump CST 407 Java Programming
/// Date Created:      April 15, 2004
/// Last Change Date:  April 15, 2004
/// Package:           Homework.Chapter8.Problem2
/// Filename:          Problem2.java
///
/// Overview:          This file contains the interface and implementation
///                    for the first homework problem due Monday, April 19, 2004.
///
/// Input:             Input is accepted from the database as defined by the file
///                    books.sql database definition file and a JComboBox / InputBox
///                    structure.
///
/// Output:            Each query output is written to a JTextArea for your review.
///-------------------------------------------------------------------

// No package encapsulation is specified for debugging convinience

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.sql.*;
import java.util.*;
// I included this package for the usage of the InputBox in Package javabook
// Much credit is due to C. Thomas Wu a.k.a Dr. Caffeine for providing this
// tool.
// Note: You MUST have the folder javabook with this source code to run
import javabook.*;

// Java extension packages
import javax.swing.*;

public class DisplayQuery extends JFrame {
    
    // JComboBox for selecting the various books database queries
    private JComboBox queryComboBox;
    
    // Database connection object
    private Connection connection;
    
    // Database query container object
    private ResultSet resultSet;
    
    // constructor connects to database
    public DisplayQuery() {
        super( "Query Selector" );
        
        try {
            // Create JComboBox and add the query selections
            queryComboBox = new JComboBox();
            
            // Query all the authors for the AUTHORS table
            queryComboBox.addItem( "Query all authors" );
            
            // Query all publishers from the PUBLISHERS table
            queryComboBox.addItem( "Query all publishers" );
            
            // Query all books (including title, year, and ISBN number) written by a specific author
            queryComboBox.addItem( "Query books by Author" );
            
            // Query all books (including title, year, and ISBN number) published by a specific publisher
            queryComboBox.addItem( "Query books by Publisher" );
            
            // Query all books by Author and Publisher
            queryComboBox.addItem( "Query books by Author and Publisher" );
            
            // Launch a new JTextArea when a query is selected
            queryComboBox.setSelectedIndex( -1 );
            queryComboBox.addItemListener
            (
                new ItemListener()
                {
                    public void itemStateChanged( ItemEvent event )
                    {
                        if( event.getStateChange() == ItemEvent.SELECTED )
                            launchQuery( (String) queryComboBox.getSelectedItem() );
                    }
                }
            );
            // load database driver class
            Class.forName( "COM.cloudscape.core.RmiJdbcDriver" );
            
            // connect to database
            connection = DriverManager.getConnection(
            "jdbc:cloudscape:rmi:books" );
            
            //lay out DisplayQuery components
            Container contentPane = getContentPane();
            contentPane.setLayout( new FlowLayout() );
            contentPane.add( new JLabel( "Select Query:" ) );
            contentPane.add( queryComboBox );
        }  // end try
        
        // detect problems interacting with the database
        catch ( SQLException sqlException ) {
            JOptionPane.showMessageDialog( null,
            sqlException.getMessage(), "Database Error",
            JOptionPane.ERROR_MESSAGE );
            
            System.exit( 1 );
        }
        
        // detect problems loading database driver
        catch ( ClassNotFoundException classNotFound ) {
            JOptionPane.showMessageDialog( null,
            classNotFound.getMessage(), "Driver Not Found",
            JOptionPane.ERROR_MESSAGE );
            
            System.exit( 1 );
        }
    }  // end DisplayAuthors constructor definition
    
    // launchQuery processes each query as it is selected
    private void launchQuery( String query ) {
        String queryStatement;
        try {
            // create Statement to query database
            Statement statement = connection.createStatement();
            InputBox inputbox = new InputBox( this, true );
            
            // query database
            if( query == "Query all authors" ) {
                resultSet =
                statement.executeQuery( "SELECT * FROM authors" );
            }
            else if( query == "Query all publishers" ) {
                resultSet =
                statement.executeQuery( "SELECT * FROM publishers" );
            }
            else if( query == "Query books by Author" ) {
                int authorID = inputbox.getInteger("Please enter an authorID");
                queryStatement = 
                "SELECT lastName, firstName, title, copyright, titles.isbn " +
                "FROM authors, authorISBN, titles " +
                "WHERE " +
                "authors.authorID = authorISBN.authorID AND " +
                "authorISBN.isbn = titles.isbn AND " +
                "authors.authorID = " + authorID + " " +
                "ORDER BY lastname, firstname DESC"
                ;
                resultSet = statement.executeQuery( queryStatement );
            }
            else if( query == "Query books by Publisher" )
            {
                int publisherID = inputbox.getInteger("Please enter a publisherID");
                queryStatement = 
                "SELECT publisherName, title, copyright, isbn " +
                "FROM publishers, titles " +
                "WHERE " +
                "publishers.publisherID = titles.publisherID AND " +
                "publishers.publisherID = " + publisherID + " " + 
                "ORDER BY title DESC"
                ;
                resultSet = statement.executeQuery( queryStatement );
            }
            else if( query == "Query books by Author and Publisher" )
            {
                int authorID = inputbox.getInteger("Please enter an authorID");
                int publisherID = inputbox.getInteger("Please enter a publisherID");
                queryStatement =
                "SELECT lastName, firstName, publisherName, title, copyright, titles.isbn " +
                "FROM authors, publishers, authorISBN, titles " +
                "WHERE " +
                "authors.authorID = authorISBN.authorID AND " +
                "authorISBN.isbn = titles.isbn AND " +
                "authors.authorID = " + authorID + " AND " +
                "publishers.publisherID = " + publisherID + " " +
                "ORDER BY lastname, firstname DESC"
                ;
                resultSet = statement.executeQuery( queryStatement );
            }
            // process query results
            StringBuffer results = new StringBuffer();
            
            ResultSetMetaData metaData = resultSet.getMetaData();
            int numberOfColumns = metaData.getColumnCount();
            
            for ( int i = 1; i <= numberOfColumns; i++ ) {
                results.append( metaData.getColumnName( i )
                + "\t" );
            }
            
            results.append( "\n" );
            
            while ( resultSet.next() ) {
                
                for ( int i = 1; i <= numberOfColumns; i++ ) {
                    results.append( resultSet.getObject( i )
                    + "\t" );
                }
                
                results.append( "\n" );
            }
            
            // set up GUI and display window
            JTextArea textArea = new JTextArea(
            results.toString() );
            Container container = getContentPane();
            
            container.add( new JScrollPane( textArea ) );
            
            setSize( 320, 240 );  // set window size
            setVisible( true );   // display window
            
            // close statement and connection
            statement.close();
            connection.close();
        }
        catch ( SQLException sqlException ) {
            JOptionPane.showMessageDialog( null,
            sqlException.getMessage(), "Database Error",
            JOptionPane.ERROR_MESSAGE );
            
            System.exit( 1 );
        }
    }
    
    // launch the application
    public static void main( String args[] ) {
        DisplayQuery window = new DisplayQuery();
        window.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );
        window.setSize(400,125);
        window.setVisible( true );
    }
}  // end class DisplayAuthors
