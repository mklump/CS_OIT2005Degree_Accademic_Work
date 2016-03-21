// MathToolClient.java
// MathToolClient is a GUI for calculating factorials and
// Fibonacci series using the MathTool EJB.
package com.deitel.advjhtp1.ejb.session.stateless.client;

// Java core libraries
import java.awt.*;
import java.awt.event.*;
import java.rmi.*;

// Java standard extensions
import javax.swing.*;
import javax.rmi.*;
import javax.naming.*;
import javax.ejb.*;

// Deitel libraries
import com.deitel.advjhtp1.ejb.session.stateless.ejb.*;

public class MathToolClient extends JFrame {
   
   private MathToolHome mathToolHome;
   private MathTool mathTool;
   
   private JTextArea resultsTextArea;
   private JTextField numberTextField;
      
   // MathToolClient constructor
   public MathToolClient()
   {     
      super( "Stateless Session EJB Example" );      
      
      // create MathTool for calculating factorials
      // and Fibonacci series
      createMathTool();
      
      // create and lay out GUI components
      createGUI();
      
      addWindowListener( getWindowListener() );
      
      setSize( 425, 200 );
      setVisible( true );
      
   } // end MathToolClient constructor
   
   // create MathTool EJB instance
   private void createMathTool()
   {
      // lookup MathToolHome and create MathTool EJB
      try {
         
         InitialContext initialContext = new InitialContext();
         
         // lookup MathTool EJB
         Object homeObject = 
            initialContext.lookup( "MathTool" );
         
         // get MathToolHome interface
         mathToolHome = ( MathToolHome )
            PortableRemoteObject.narrow( homeObject, 
               MathToolHome.class );         
         
         // create MathTool EJB instance
         mathTool = mathToolHome.create();
         
      } // end try
      
      // handle exception if MathTool EJB is not found
      catch ( NamingException namingException ) {
         namingException.printStackTrace();
      }
      
      // handle exception when creating MathTool EJB
      catch ( RemoteException remoteException ) {
         remoteException.printStackTrace( System.err );
      }
      
      // handle exception when creating MathTool EJB
      catch ( CreateException createException ) {
         createException.printStackTrace( System.err );
      }      
   } // end method createMathTool
   
   // create JButton for calculating factorial
   private JButton getFactorialButton()
   {
      JButton factorialButton = 
         new JButton( "Calculate Factorial" );
      
      // add ActionListener for factorial button
      factorialButton.addActionListener( 
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event )
            {
               // use MathTool EJB to calculate factorial
               try {
                  
                  int number = Integer.parseInt( 
                     numberTextField.getText() );

                  // get Factorial of number input by user
                  int result = mathTool.getFactorial( number );

                  // display results in resultsTextArea
                  resultsTextArea.setText( number + "! = " + 
                     result );

               } // end try

               // handle exception calculating factorial
               catch ( RemoteException remoteException ) {
                  remoteException.printStackTrace();
               }
            } // end method actionPerformed
         }
      ); // end addActionListener    
      
      return factorialButton;
      
   } // end method getFactorialButton
   
   // create JButton for generating Fibonacci series
   private JButton getFibonacciButton()
   {
      JButton fibonacciButton =
         new JButton( "Fibonacci Series" );
      
      // add ActionListener for generating Fibonacci series
      fibonacciButton.addActionListener( 
         new ActionListener() {
            
            public void actionPerformed( ActionEvent event )
            {
               // generate Fibonacci series using MathTool EJB
               try {

                  // get number entered by user
                  int number = Integer.parseInt( 
                     numberTextField.getText() );

                  // get Fibonacci series
                  int[] series = mathTool.getFibonacciSeries( 
                     number );

                  // create StringBuffer to store series
                  StringBuffer buffer = 
                     new StringBuffer( "The first " );

                  buffer.append( number );

                  buffer.append( " Fibonacci number(s): \n" );

                  // append each number in series to buffer
                  for ( int i = 0; i < series.length; i++ ) {

                     // do not add comma before first number
                     if ( i != 0 )
                        buffer.append( ", " );

                     // append next number in series to buffer
                     buffer.append( String.valueOf( 
                        series[i] ) );
                  }

                  // display series in resultsTextArea
                  resultsTextArea.setText( buffer.toString() );

               } // end try

               // handle exception calculating series
               catch ( RemoteException remoteException ) {
                  remoteException.printStackTrace();
               }            
            } // end method actionPerformed
         }
      ); // end addActionListener        
      
      return fibonacciButton;
      
   } // end method getFibonacciButton
   
   // create lay out GUI components
   public void createGUI()
   {
      // create JTextArea to show results
      resultsTextArea = new JTextArea();
      resultsTextArea.setLineWrap( true );
      resultsTextArea.setWrapStyleWord( true );
      resultsTextArea.setEditable( false );

      // create JTextField for user input
      numberTextField = new JTextField( 10 );

      // create JButton for calculating factorial
      JButton factorialButton = getFactorialButton();
      
      // create JButton for generating Fibonacci series
      JButton fibonacciButton = getFibonacciButton();
      
      Container contentPane = getContentPane();
      
      // put resultsTextArea in a JScrollPane
      JScrollPane resultsScrollPane = 
         new JScrollPane( resultsTextArea );
      
      contentPane.add( resultsScrollPane, 
         BorderLayout.CENTER );
      
      // add input components to new JPanel
      JPanel inputPanel = new JPanel( new FlowLayout() );
      inputPanel.add( new JLabel( "Enter an integer: " ) );
      inputPanel.add( numberTextField );
      
      // add JButton components to new JPanel
      JPanel buttonPanel = new JPanel( new FlowLayout() );
      buttonPanel.add( factorialButton );
      buttonPanel.add( fibonacciButton );  
      
      // add inputPanel and buttonPanel to new JPanel
      JPanel controlPanel = 
         new JPanel( new GridLayout( 2, 2 ) );
      
      controlPanel.add( inputPanel );
      controlPanel.add( buttonPanel );
      
      contentPane.add( controlPanel, BorderLayout.NORTH );
      
   } // end method createGUI
   
   // get WindowListener for exiting application
   private WindowListener getWindowListener()
   {
      return new WindowAdapter() {
         
         public void windowClosing( WindowEvent event )
         {
            // remove MathTool instance
            try {
               mathTool.remove();
            }
            
            // handle exception when removing MathTool EJB
            catch ( RemoveException removeException ) {
               removeException.printStackTrace();
               System.exit( -1 );
            }
            
            // handle exception when removing MathTool EJB
            catch ( RemoteException remoteException ) {
               remoteException.printStackTrace();
               System.exit( -1 );
            }     
            
            System.exit( 0 );
         } // end method windowClosing
      }; 
   } // end method getWindowListener
   
   // execute application
   public static void main( String[] args )
   {
      MathToolClient client = new MathToolClient();
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