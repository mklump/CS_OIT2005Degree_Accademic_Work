// InterestCalculatorClient.java
// InterestCalculatorClient is a GUI for interacting with the 
// InterestCalculator EJB.
package com.deitel.advjhtp1.ejb.session.stateful.client;

// Java core libraries
import java.awt.*;
import java.awt.event.*;
import java.rmi.*;
import java.text.*;
import java.util.*;

// Java standard extensions
import javax.swing.*;
import javax.rmi.*;
import javax.naming.*;
import javax.ejb.*;

// Deitel libraries
import com.deitel.advjhtp1.ejb.session.stateful.ejb.*;

public class InterestCalculatorClient extends JFrame {
   
   // InterestCalculator remote reference
   private InterestCalculator calculator;
   
   private JTextField principalTextField;
   private JTextField rateTextField;
   private JTextField termTextField;
   private JTextField balanceTextField;
   private JTextField interestEarnedTextField;
      
   // InterestCalculatorClient constructor
   public InterestCalculatorClient()
   {     
      super( "Stateful Session EJB Example" );    
      
      // create InterestCalculator for calculating interest
      createInterestCalculator();
      
      // create JTextField for entering principal amount
      createPrincipalTextField();
      
      // create JTextField for entering interest rate
      createRateTextField();

      // create JTextField for entering loan term
      createTermTextField();
      
      // create uneditable JTextFields for displaying balance 
      // and interest earned
      balanceTextField = new JTextField( 10 );
      balanceTextField.setEditable( false );      
      
      interestEarnedTextField = new JTextField( 10 );
      interestEarnedTextField.setEditable( false );
      
      // layout components for GUI
      layoutGUI();
      
      // add WindowListener to remove EJB instances when user
      // closes window
      addWindowListener( getWindowListener() );
      
      setSize( 425, 200 );
      setVisible( true );
      
   } // end InterestCalculatorClient constructor
   
   // create InterestCalculator EJB instance
   public void createInterestCalculator()
   {
      // lookup InterestCalculatorHome and create 
      // InterestCalculator EJB
      try {
         
         InitialContext initialContext = new InitialContext();
         
         // lookup InterestCalculator EJB
         Object homeObject = 
            initialContext.lookup( "InterestCalculator" );
         
         // get InterestCalculatorHome interface
         InterestCalculatorHome calculatorHome = 
            ( InterestCalculatorHome )
               PortableRemoteObject.narrow( homeObject, 
                  InterestCalculatorHome.class );         
         
         // create InterestCalculator EJB instance
         calculator = calculatorHome.create();
         
      } // end try
      
      // handle exception if InterestCalculator EJB not found
      catch ( NamingException namingException ) {
         namingException.printStackTrace();
      }
      
      // handle exception when creating InterestCalculator EJB
      catch ( RemoteException remoteException ) {
         remoteException.printStackTrace();
      }
      
      // handle exception when creating InterestCalculator EJB
      catch ( CreateException createException ) {
         createException.printStackTrace();
      }            
   } // end method createInterestCalculator
   
   // create JTextField for entering principal amount
   public void createPrincipalTextField()
   {
      principalTextField = new JTextField( 10 );
      
      principalTextField.addActionListener( 
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event )
            {
               // set principal amount in InterestCalculator
               try {
                  double principal = Double.parseDouble( 
                     principalTextField.getText() );

                  calculator.setPrincipal( principal );
               }

               // handle exception setting principal amount
               catch ( RemoteException remoteException ) {
                  remoteException.printStackTrace();
               }
               
               // handle wrong number format
               catch ( NumberFormatException 
                  numberFormatException ) {
                  numberFormatException.printStackTrace();
               }
            }
         }
      ); // end addActionListener      
   } // end method createPrincipalTextField   
   
   // create JTextField for entering interest rate
   public void createRateTextField()
   {
      rateTextField = new JTextField( 10 );
      
      rateTextField.addActionListener( 
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event )
            {
               // set interest rate in InterestCalculator
               try {
                  double rate = Double.parseDouble( 
                     rateTextField.getText() );

                  // convert from percentage
                  calculator.setInterestRate( rate / 100.0 );
               }

               // handle exception when setting interest rate
               catch ( RemoteException remoteException ) {
                  remoteException.printStackTrace();
               }            
            }
         }
      ); // end addActionListener            
   } // end method createRateTextField   
   
   // create JTextField for entering loan term
   public void createTermTextField()
   {
      termTextField = new JTextField( 10 );
      
      termTextField.addActionListener( 
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event )
            {
               // set loan term in InterestCalculator
               try {
                  int term = Integer.parseInt( 
                     termTextField.getText() );

                  calculator.setTerm( term );
               }

               // handle exception when setting loan term
               catch ( RemoteException remoteException ) {
                  remoteException.printStackTrace();
               }            
            }
         }
      ); // end addActionListener      
   } // end method getTermTextField   
   
   // get JButton for starting calculation
   public JButton getCalculateButton()
   {
      JButton calculateButton = new JButton( "Calculate" );
      
      calculateButton.addActionListener( 
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event )
            {
               // use InterestCalculator to calculate interest
               try {

                  // get balance and interest earned
                  double balance = calculator.getBalance();
                  double interest = 
                     calculator.getInterestEarned();

                  NumberFormat dollarFormatter =
                     NumberFormat.getCurrencyInstance( 
                        Locale.US );

                  balanceTextField.setText( 
                     dollarFormatter.format( balance ) );

                  interestEarnedTextField.setText( 
                     dollarFormatter.format( interest ) );
               }

               // handle exception when calculating interest
               catch ( RemoteException remoteException ) {
                  remoteException.printStackTrace();
               }
            } // end method actionPerformed
         }
      ); // end addActionListener
      
      return calculateButton;
      
   } // end method getCalculateButton
   
   // lay out GUI components in JFrame
   public void layoutGUI()
   {
      Container contentPane = getContentPane();
      
      // layout user interface components
      JPanel inputPanel = new JPanel( new GridLayout( 5, 2 ) );
      
      inputPanel.add( new JLabel( "Principal" ) );
      inputPanel.add( principalTextField );
      
      inputPanel.add( new JLabel( "Interest Rate (%)" ) );
      inputPanel.add( rateTextField );
      
      inputPanel.add( new JLabel( "Term (years)" ) );
      inputPanel.add( termTextField );
      
      inputPanel.add( new JLabel( "Balance" ) );
      inputPanel.add( balanceTextField );
      
      inputPanel.add( new JLabel( "Interest Earned" ) );
      inputPanel.add( interestEarnedTextField );      
      
      // add inputPanel to contentPane
      contentPane.add( inputPanel, BorderLayout.CENTER );
      
      // create JPanel for calculateButton
      JPanel controlPanel = new JPanel( new FlowLayout() );
      controlPanel.add( getCalculateButton() );
      contentPane.add( controlPanel, BorderLayout.SOUTH );
   }
   
   // get WindowListener for exiting application
   public WindowListener getWindowListener()
   {
      return new WindowAdapter() {
            
         public void windowClosing( WindowEvent event )
         {
            // check to see if calculator is null
            if ( calculator.equals( null ) ) {
               System.exit( -1 );
            }
            
            else {
               // remove InterestCalculator instance
               try {
                  calculator.remove();
               }

               // handle exception removing InterestCalculator
               catch ( RemoveException removeException ) {
                  removeException.printStackTrace();
                  System.exit( -1 );
               }

               // handle exception removing InterestCalculator
               catch ( RemoteException remoteException ) {
                  remoteException.printStackTrace();
                  System.exit( -1 );
               }
            
               System.exit( 0 );
            }
         }
      };
   } // end method getWindowListener
   
   // execute the application
   public static void main( String[] args )
   {
      new InterestCalculatorClient();
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