// Account.java
// Account is an Observable class that represents a bank
// account in which funds may be deposited or withdrawn.
package com.deitel.advjhtp1.mvc.account;

// Java core packages
import java.util.Observable;

public class Account extends Observable {
   
   // Account balance
   private double balance;  
   
   // readonly Account name
   private String name;
   
   // Account constructor
   public Account( String accountName, double openingDeposit ) 
   {
      name = accountName;
      setBalance( openingDeposit );
   }
   
   // set Account balance and notify observers of change
   private void setBalance( double accountBalance )
   {
      balance = accountBalance;
      
      // must call setChanged before notifyObservers to 
      // indicate model has changed
      setChanged();
      
      // notify Observers that model has changed
      notifyObservers();
   }
   
   // get Account balance
   public double getBalance()
   {
      return balance;
   }
   
   // withdraw funds from Account
   public void withdraw( double amount )
      throws IllegalArgumentException
   {
      if ( amount < 0 )
         throw new IllegalArgumentException( 
            "Cannot withdraw negative amount" );
      
      // update Account balance
      setBalance( getBalance() - amount );
   }
   
   // deposit funds in account
   public void deposit( double amount )
      throws IllegalArgumentException
   {
      if ( amount < 0 )
         throw new IllegalArgumentException( 
            "Cannot deposit negative amount" );
      
      // update Account balance
      setBalance( getBalance() + amount );
   }
   
   // get Account name (readonly)
   public String getName()
   {
      return name;
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