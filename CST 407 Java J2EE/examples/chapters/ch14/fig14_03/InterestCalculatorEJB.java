// InterestCalculatorEJB.java
// InterestCalculator is a stateful session EJB for calculating
// simple interest.
package com.deitel.advjhtp1.ejb.session.stateful.ejb;

// Java core libraries
import java.util.*;

// Java standard extensions
import javax.ejb.*;

public class InterestCalculatorEJB implements SessionBean {
   
   private SessionContext sessionContext;
   
   // state variables
   private double principal;
   private double interestRate;
   private int term;   
   
   // set principal amount
   public void setPrincipal( double amount )
   {
      principal = amount;
   }
   
   // set interest rate
   public void setInterestRate( double rate )
   {
      interestRate = rate;
   }
   
   // set loan length in years
   public void setTerm( int years )
   {
      term = years;
   }
   
   // get loan balance
   public double getBalance() 
   {
      // calculate simple interest
      return principal * Math.pow( 1.0 + interestRate, term );
   }
   
   // get amount of interest earned
   public double getInterestEarned()
   {
      return getBalance() - principal;
   }
   
   // set SessionContext
   public void setSessionContext( SessionContext context )
   {
      sessionContext = context;
   }
   
   // create InterestCalculator instance
   public void ejbCreate() {}
   
   // remove InterestCalculator instance
   public void ejbRemove() {}   

   // passivate InterestCalculator instance
   public void ejbPassivate() {}
   
   // activate InterestCalculator instance
   public void ejbActivate() {}
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