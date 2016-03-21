// CandidateHome.java
// CandidateHome is the home interface for the Candidate EJB.
package com.deitel.advjhtp1.jms.mdb;

// Java core libraries
import java.rmi.*;
import java.util.*;

// Java standard extensions
import javax.ejb.*;

public interface CandidateHome extends EJBHome {
   
   // find Candidate with given name
   public Candidate findByPrimaryKey( String candidateName )
      throws RemoteException, FinderException;
   
   // find all Candidates
   public Collection findAllCandidates()
      throws RemoteException, FinderException;

   // create new Candidate EJB
   public Candidate create( String candidateName ) 
      throws RemoteException, CreateException;
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