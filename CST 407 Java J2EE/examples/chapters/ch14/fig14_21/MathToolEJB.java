// MathToolEJB.java
// MathToolEJB is a stateless session EJB with methods for 
// calculating Fibonacci series and factorials.
package com.deitel.advjhtp1.ejb.session.stateless.ejb;

// Java standard extensions
import javax.ejb.*;

public class MathToolEJB implements SessionBean {
   
   private SessionContext sessionContext;

   // get Fibonacci series 
   public int[] getFibonacciSeries( int howMany )
      throws IllegalArgumentException
   {
      // throw IllegalArgumentException if series length
      // is less than zero
      if ( howMany < 2 )
         throw new IllegalArgumentException( 
            "Cannot generate Fibonacci series of " +
            "length less than two." );

      // starting points
      int startPoint1 = 0;
      int startPoint2 = 1;

      // array to contain Fibonacci sequence
      int[] series = new int[ howMany ];
      
      // set base cases
      series[ 0 ] = 0;
      series[ 1 ] = 1;
      
      // generate Fibonacci series
      for ( int i = 2; i < howMany; i++ ) {
         
         // calculate next number in series
         series[ i ] = startPoint1 + startPoint2;

         // set start points for next iteration
         startPoint1 = startPoint2;
         startPoint2 = series[ i ];
      }

      return series;
      
   } // end method getFibonacciSeries

   // get factorial of given integer
   public int getFactorial( int number ) 
      throws IllegalArgumentException
   {
      // throw IllegalArgumentException if number less than zero
      if ( number < 0 )
         throw new IllegalArgumentException( 
            "Cannot calculate factorial of negative numbers." );

      // base case for recursion, return 1
      if ( number == 0 )
         return 1;
      
      // call getFactorial recursively to calculate factorial
      else
         return number * getFactorial( number - 1 );
      
   } // end method getFactorial
   
   // set SessionContext
   public void setSessionContext( SessionContext context ) 
   {
      sessionContext = context;
   }

   // create new MathTool instance
   public void ejbCreate() {}
   
   // remove MathTool instance
   public void ejbRemove() {}
   
   // activate MathTool instance
   public void ejbActivate() {}
   
   // passivate MathTool instance
   public void ejbPassivate() {}
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