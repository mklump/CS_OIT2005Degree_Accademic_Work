// AccountTextView.java
// AccountTextView is an AbstractAccountView subclass
// that displays an Account balance in a JTextField.
package com.deitel.advjhtp1.mvc.account;

// Java core packages
import java.util.*;
import java.text.NumberFormat;

// Java extension packages
import javax.swing.*;

public class AccountTextView extends AbstractAccountView {  

   // JTextField for displaying Account balance
   private JTextField balanceTextField = new JTextField( 10 );
   
   // NumberFormat for US dollars
   private NumberFormat moneyFormat = 
      NumberFormat.getCurrencyInstance( Locale.US );
      
   // AccountTextView constructor
   public AccountTextView( Account account )
   {
      super( account );
      
      // make balanceTextField readonly
      balanceTextField.setEditable( false );
      
      // lay out components
      add( new JLabel( "Balance: " ) );
      add( balanceTextField );
      
      updateDisplay();
   }
   
   // update display with Account balance
   public void updateDisplay()
   {      
      // set text in balanceTextField to formatted balance
      balanceTextField.setText( moneyFormat.format( 
         getAccount().getBalance() ) );
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