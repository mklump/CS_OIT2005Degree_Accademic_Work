package javabook;

import java.awt.*;
import javax.swing.*;
import java.util.Vector;

/**
 * This dialog is for listing a list of items from which the user can select. 
 * You can get the index or the string value of the item the user selects.
 * If the user closes the dialog without clicking any
 * button or clicks the Cancel button, then the result 
 * is CANCEL (getSelectedIndex) or NO_ITEM (getSelectedItem). If the user
 * clicks the OK button without selecting an item, 
 * then the result is CANCEL or NO_ITEM. If the user selects
 * an item and clicks the OK button, then the index or the string value
 * of the selected item is returned.
 *
 *<p> 
 * This class is provided as freeware. You are free to use as provided or modify to
 * your heart's content. But you use it at your own risk. No implied or explicit 
 * warranty is given.
 * 
 * @author C. Thomas Wu a.k.a Dr. Caffeine
 */
public class ListBox extends JavaBookDialog
{

//-----------------------------------------
//
//    Data Members:
//
//-----------------------------------------

    /**
     * Constant to represent a user action where
     * the Ok button is clicked, but no item is
     * selected from the list.
     */
    public static final int     NO_SELECTION = -1;
    
    /**
     * Constant to represent a user action where
     * the Cancel button is clicked or the dialog
     * is closed.
     */
    public static final int     CANCEL       = -2;
    
    /**
     * Constant to represent no selection for
     * the getSelectedItem method.
     */
    public static final String  NO_ITEM      = null;
    
    /**
     * Default title for this dialog
     */
    private static final String  DEFAULT_TITLE = "List Box: Select One";

    /**
     * A vector to keep track of list items
     */
    private Vector items;
    
    /**
     * A JPanel for the content(message) portion of this dialog
     */
    private JPanel listPanel;
    
    /**
     * A JList for listing the items
     */
    private JList  list;
    

//-----------------------------------------
//
//    Constructors:
//
//-----------------------------------------
    
    /**
     * Constructs the standard modal ListBox dialog
     * with 'owner' as its owner.
     *
     * @param owner a Frame object owner of this dialog
     */
    public ListBox( Frame owner )
    {
        this( owner, DEFAULT_TITLE, true );
    }
    
    /**
     * Constructs a modal ListBox dialog with 'owner' as its 
     * owner and 'title' as its title.
     * 
     * @param owner   a Frame object owner of this dialog
     * @param title    the title of this title
     */
    public ListBox( Frame owner, String title )
    {
        this( owner, title, true );
    }

    /**
     * Constructs a ListBox dialog with 'owner' as its 
     * owner and default title. This dialog is modal 
     * if 'modal' is true; otherwise, it is modeless.
     * 
     * @param owner   a Frame object owner of this dialog
     * @param modal   true for modal; false for modeless
     */
    public ListBox( Frame owner, boolean modal )
    {
        this( owner, DEFAULT_TITLE, modal );
    }

    /**
     * Constructs a ListBox dialog with 'owner' as its 
     * owner and 'title' as its title. This dialog is modal 
     * if 'modal' is true; otherwise, it is modeless.
     * 
     * @param owner   a Frame object owner of this dialog
     * @param title   the title of this title
     * @param modal   true for modal; false for modeless
     */
    public ListBox( Frame owner, String title, boolean modal )
    {
        super( owner, modal );
        setTitle( title );
        setIcon( QUESTION_ICON );
        
        items = new Vector( );
    }


//-----------------------------------------------
//    Public Methods:
//
//          void    addItem             ( String            )
//          void    deleteItem          ( int               )
//          void    deleteItem          ( String            )
//
//          int     getSelectedIndex    (                   )
//          String  getItemFromIndex    ( int               )
//
//-----------------------------------------------

    /**
     * Adds an item to the list.
     *
     * @param item a String value to add to the list
     *
     */
    public void addItem(String item)
    {
        items.add( item );
    }

    /**
     * Deletes an item at position index from
     * the list.
     *
     * @param index the position of an item to remove
     */
    public void deleteItem(int index)
    {
        items.remove( index );
    }

    /**
     * Deletes an item from the list.
     *
     * @param item the item to remove
     */
    public void deleteItem(String item)
    {
        items.remove( item );
    }

    /**
     * Prompts the user to select an item. If the 
     * user closes the dialog without clicking any
     * button or clicks the Cancel button, then the result 
     * is CANCEL. If the user
     * clicks the OK button without selecting an item, 
     * then the result is CANCEL. If the user selects
     * an item and clicks the OK button, then the index
     * of the selected item is returned.
     * 
     * @return the index of the selected item in the list
     *         or the value CANCEL
     */
    public int getSelectedIndex()
    {
        createListPanel( );
        
        int value = showDialog( );
        
        return getSelectedIndex( value );
      
    }

    /**
     * Returns the string value of an iten given
     * index. If an invalid index is provided,
     * then the value returned is NO_ITEM.
     *
     * @param index the index of an item to return
     * 
     * @return the string value of an item at the 
     *         index position. NO_ITEM is returned
     *         for an invalid index.
     */
    public String getItemFromIndex(int index) 
    {
        String result = NO_ITEM;
        
        if ( index >= 0 && index < items.size( ) ) {
            result = (String) items.elementAt(index);
        }
        
        return result;
        
    }

    /**
     * Prompts the user to select an item. If the 
     * user closes the dialog without clicking any
     * button or clicks the Cancel button, then the result 
     * is NO_ITEM. If the user
     * clicks the OK button without selecting an item, 
     * then the result is NO_ITEM. If the user selects
     * an item and clicks the OK button, then the string
     * value of the selected item is returned.
     * 
     * @return the string value of the selected item in the list
     *         or the value NO_ITEM
     */
    public String getSelectedItem()
    {
        int value = showDialog( );
        
        int index = getSelectedIndex( value ); 
        
        return getItemFromIndex( index );
        
    }

//-----------------------------------------------
//    Private Methods:
//
//
//           void    createListPanel   (         )
//           int     getSelectedIndex  (         )
//           int     showDialog        (         )
//
//-----------------------------------------------

    /**
     * Creates a JPanel that contains a JList. This panel
     * becomes the content portion of this dialog.
     */
    private void createListPanel( )
    {
        //create the list of items
        list = new JList( items );
        JScrollPane sp = new JScrollPane( list );

        sp.setPreferredSize( new Dimension( 200, 100 ) );
        
        listPanel = new JPanel( );
        listPanel.add( sp );      //You can actually add JScrollPane
                                  //as the content portion of JOptionPane
                                  //but using JPanel is general because
                                  //you can add other components to the
                                  //JPanel.
      
    }
    
    /**
     * Returns the result of user selection. If the 
     * user closes the dialog without clicking any
     * button or clicks the Cancel button, then the result 
     * is CANCEL. If the user
     * clicks the OK button without selecting an item, 
     * then the result is CANCEL. If the user selects
     * an item and clicks the OK button, then the index
     * of the selected item is returned.
     *
     * @param button value returned from showOptionDialog
     * 
     * @return the index of the selected item in the list
     *         or the value CANCEL
     */
    private int getSelectedIndex( int button )
    {
        int result = 0;
        
        switch ( button ) {
            case JOptionPane.CLOSED_OPTION:
            case JOptionPane.NO_OPTION:
                                            //CANCEL_OPTION never matches with two buttons
                                            //The second button is NO_OPTION
                          result = CANCEL;
                          break;
                          
            case JOptionPane.OK_OPTION:
        
                          result = list.getSelectedIndex();
                          break;
                          
            default:      result = CANCEL;  //just in case; this case should
                          break;            //never happen     
        }
        
        return result;
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
                                              listPanel,
                                              getTitle( ),
                                              JOptionPane.DEFAULT_OPTION,
                                              getIcon( ),
                                              null,
                                              new Object[]{"OK", "Cancel"},
                                              null );
    }
    

}