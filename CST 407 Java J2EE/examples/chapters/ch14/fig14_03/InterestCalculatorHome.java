// InterestCalculatorHome.java
// InterestCalculatorHome is the home interface for the 
// InterestCalculator EJB.
package com.deitel.advjhtp1.ejb.session.stateful.ejb;

// Java core libraries
import java.rmi.RemoteException;

// Java standard extensions
import javax.ejb.*;

public interface InterestCalculatorHome extends EJBHome {
   
   // create InterestCalculator EJB
   public InterestCalculator create() throws RemoteException,
      CreateException;
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