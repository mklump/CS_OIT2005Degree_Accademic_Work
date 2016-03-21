// AccountManager.java
// AccountManager is an application that uses the MVC design
// pattern to manage bank Account information.
package com.deitel.advjhtp1.mvc.account;

// Java core packages
import java.awt.*;
import java.awt.event.*;

// Java extension packages
import javax.swing.*;
import javax.swing.border.*;

public class AccountManager extends JFrame {
   
   // AccountManager no-argument constructor
   public AccountManager() 
   {
      super( "Account Manager" );
      
      // create account1 with initial balance
      Account account1 = new Account( "Account 1", 1000.00 );
      
      // create GUI for account1
      JPanel account1Panel = createAccountPanel( account1 );
 
      // create account2 with initial balance
      Account account2 = new Account( "Account 2", 3000.00 );
      
      // create GUI for account2
      JPanel account2Panel = createAccountPanel( account2 );
      
      // create AccountPieChartView to show Account pie chart
      AssetPieChartView pieChartView = 
         new AssetPieChartView();
      
      // add both Accounts to AccountPieChartView
      pieChartView.addAccount( account1 );
      pieChartView.addAccount( account2 );
      
      // create JPanel for AccountPieChartView
      JPanel pieChartPanel = new JPanel();
      
      pieChartPanel.setBorder( 
         new TitledBorder( "Assets" ) );
      
      pieChartPanel.add( pieChartView );
      
      // lay out account1, account2 and pie chart components
      Container contentPane = getContentPane();
      contentPane.setLayout( new GridLayout( 3, 1 ) );
      contentPane.add( account1Panel );
      contentPane.add( account2Panel ); 
      contentPane.add( pieChartPanel );
      
      setSize( 425, 450 );
      
   } // end AccountManager constructor
   
   // create GUI components for given Account
   private JPanel createAccountPanel( Account account )
   {
      // create JPanel for Account GUI
      JPanel accountPanel = new JPanel();
      
      // set JPanel's border to show Account name
      accountPanel.setBorder( 
         new TitledBorder( account.getName() ) );
      
      // create AccountTextView for Account
      AccountTextView accountTextView = 
         new AccountTextView( account );
      
      // create AccountBarGraphView for Account
      AccountBarGraphView accountBarGraphView =
         new AccountBarGraphView( account );
      
      // create AccountController for Account
      AccountController accountController = 
         new AccountController( account );      
      
      // lay out Account's components
      accountPanel.add( accountController );      
      accountPanel.add( accountTextView );  
      accountPanel.add( accountBarGraphView );      
      
      return accountPanel;   
      
   } // end method getAccountPanel   
   
   // execute application
   public static void main( String args[] )
   {
      AccountManager manager = new AccountManager();
      manager.setDefaultCloseOperation( EXIT_ON_CLOSE );
      manager.setVisible( true );
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
