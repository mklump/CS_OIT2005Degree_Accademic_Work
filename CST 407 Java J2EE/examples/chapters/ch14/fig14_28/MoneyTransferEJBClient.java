// MoneyTransferEJBClient.java
// MoneyTransferEJBClient is a client for interacting with
// the MoneyTransfer EJB.
package com.deitel.advjhtp1.ejb.transactions.client;

// Java core libraries
import java.awt.*;
import java.awt.event.*;
import java.rmi.*;

// Java standard extensions
import javax.swing.*;
import javax.ejb.*;
import javax.rmi.*;
import javax.naming.*;

// Deitel libraries
import com.deitel.advjhtp1.ejb.transactions.*;

public class MoneyTransferEJBClient extends JFrame {
   
   private MoneyTransfer moneyTransfer;
   
   private JTextField bankABCBalanceTextField;
   private JTextField bankXYZBalanceTextField;
   private JTextField transferAmountTextField;
   
   // MoneyTransferEJBClient constructor
   public MoneyTransferEJBClient( String JNDIName )
   {
      super( "MoneyTransferEJBClient" );
      
      // create MoneyTransfer EJB for transferring money
      createMoneyTransfer( JNDIName );
      
      // create and lay out GUI components
      createGUI();
      
      // display current balances at BankABC and BankXYZ
      displayBalances();

      setSize( 400, 300 );
      setVisible( true );
   }
   
   // create MoneyTransferEJB for transferring money
   private void createMoneyTransfer( String JNDIName )
   {
      // look up MoneyTransfer EJB using given JNDIName
      try {
         InitialContext context = new InitialContext();
         
         // lookup MoneyTransfer EJB
         Object homeObject = context.lookup( JNDIName );
         
         // get MoneyTransfer interface
         MoneyTransferHome moneyTransferHome = 
            ( MoneyTransferHome ) PortableRemoteObject.narrow( 
               homeObject, MoneyTransferHome.class );         
         
         // create MathTool EJB instance
         moneyTransfer = moneyTransferHome.create();
         
      } // end try
      
      // handle exception when looking up MoneyTransfer EJB
      catch ( NamingException namingException ) {
         namingException.printStackTrace();
      }         

      // handle exception when looking up MoneyTransfer EJB
      catch ( CreateException createException ) {
         createException.printStackTrace();
      }    
      
      // handle exception when looking up MoneyTransfer EJB
      catch ( RemoteException remoteException ) {
         remoteException.printStackTrace();
      }               
   } // end method createMoneyTransfer
   
   // display balance in account at BankABC
   private void displayBalances()
   {
      try {
         
         // get and display BankABC Account balance
         double balance = moneyTransfer.getBankABCBalance();
         
         bankABCBalanceTextField.setText( 
            String.valueOf( balance ) );         
         
         // get and display BankXYZ Account balance
         balance = moneyTransfer.getBankXYZBalance();
         
         bankXYZBalanceTextField.setText( 
            String.valueOf( balance ) );                  
      }
      
      // handle exception when invoke MoneyTransfer EJB methods
      catch ( RemoteException remoteException ) {
         JOptionPane.showMessageDialog( this, 
            remoteException.getMessage() );
      }
   } // end method displayBalances
   
   // create button to transfer funds between accounts
   private JButton getTransferButton()
   {
      JButton transferButton = new JButton( "Transfer" );  
      
      transferButton.addActionListener( 
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event )
            {
               try {

                  // get transfer amount from JTextField
                  double amount = Double.parseDouble(
                     transferAmountTextField.getText() );

                  // transfer money
                  moneyTransfer.transfer( amount );

                  // display new balances
                  displayBalances();
               }

               // handle exception when transferring money
               catch ( RemoteException remoteException ) {
                  JOptionPane.showMessageDialog( 
                     MoneyTransferEJBClient.this, 
                     remoteException.getMessage() );
               }
            } // end method actionPerformed
         }
      ); // end addActionListener    
      
      return transferButton;
      
   } // end method getTransferButton
   
   // create and lay out GUI components
   private void createGUI()
   {
      // create JTextFields for user input and display
      bankABCBalanceTextField = new JTextField( 10 );
      bankABCBalanceTextField.setEditable( false );

      bankXYZBalanceTextField = new JTextField( 10 );
      bankXYZBalanceTextField.setEditable( false );

      transferAmountTextField = new JTextField( 10 );
      
      // create button to transfer between accounts
      JButton transferButton = getTransferButton();
 
      // layout user interface
      Container contentPane = getContentPane();
      contentPane.setLayout( new GridLayout( 3, 2 ) );

      contentPane.add( transferButton );
      contentPane.add( transferAmountTextField );
      
      contentPane.add( new JLabel( "Bank ABC Balance: " ) );
      contentPane.add( bankABCBalanceTextField );
      
      contentPane.add( new JLabel( "Bank XYZ Balance: " ) );
      contentPane.add( bankXYZBalanceTextField );      
      
   } // end method createGUI
   
   // get WindowListener for exiting application
   private WindowListener getWindowListener()
   {
      // remove MoneyTransfer EJB when user exits application
      return new WindowAdapter() {
         
         public void windowClosing( WindowEvent event ) {
            
            // remove MoneyTransfer EJB
            try {
               moneyTransfer.remove();
            }
            
            // handle exception removing MoneyTransfer EJB
            catch ( RemoveException removeException ) {
               removeException.printStackTrace();
               System.exit( 1 );
            }
            
            // handle exception removing MoneyTransfer EJB
            catch ( RemoteException remoteException ) {
               remoteException.printStackTrace();
               System.exit( 1 );
            }          
       
            System.exit( 0 );
            
         } // end method windowClosing
      };     
   } // end method getWindowListener
   
   // execute application
   public static void main( String[] args ) 
   {
      // ensure user provided JNDI name for MoneyTransfer EJB
      if ( args.length != 1 )
         System.err.println( 
            "Usage: java MoneyTransferEJBClient <JNDI Name>" );
      
      // start application using provided JNDI name
      else
         new MoneyTransferEJBClient( args[ 0 ] );
   }
}

/***************************************************************
 * (C) Copyright 2002 by Deitel & Associates, Inc. and         *
 * Prentice Hall. All Rights Reserved.                         *
 *                                                             *
 * DISCLAIMER: The authors and publisher of this book have     *
 * used their best efforts in preparing the book. These        *
 * efforts include the development, research, and testing of   *
 * the theories and programs to determine their effectiveness. *
 * The authors and publisher make no warranty of any kind,     *
 * expressed or implied, with regard to these programs or to   *
 * the documentation contained in these books. The authors     *
 * and publisher shall not be liable in any event for          *
 * incidental or consequential damages in connection with, or  *
 * arising out of, the furnishing, performance, or use of      *
 * these programs.                                             *
 ***************************************************************/