// CandidateEJB.java
// CandidateEJB is an entity EJB that uses container-managed
// persistence to persist its Candidate and its vote tally.
package com.deitel.advjhtp1.jms.mdb;

// Java core libraries
import java.rmi.RemoteException;

// Java standard extensions
import javax.ejb.*;

public class CandidateEJB implements EntityBean {
   
   private EntityContext entityContext;

   // container-managed fields
   public Integer voteCount;
   public String name;   
   
   // place vote for this Candidate
   public void incrementVoteCount()
   {
      int newVoteCount = voteCount.intValue() + 1;
      voteCount = new Integer( newVoteCount );
   }
   
   // get total vote count for this Candidate
   public Integer getVoteCount()
   {
      return voteCount;
   }
   
   // get Candidate's name
   public String getCandidateName()
   {
      return name;
   }  
   
   // create new Candidate
   public String ejbCreate( String candidateName ) 
      throws CreateException
   {    
      name = candidateName;
      voteCount = new Integer( 0 );
      
      return null;
   }
   
   // do post-creation tasks when creating new Candidate
   public void ejbPostCreate( String candidateName ) {}
   
   // set EntityContext
   public void setEntityContext( EntityContext context )
   {
      entityContext = context;
   }
   
   // unset EntityContext
   public void unsetEntityContext() 
   {
      entityContext = null;
   }
   
   // activate Candidate instance
   public void ejbActivate() 
   {
      name = ( String ) entityContext.getPrimaryKey();
   }
   
   // passivate Candidate instance
   public void ejbPassivate() 
   {
      name = null;
   }
   
   // load Candidate from database
   public void ejbLoad() {}
   
   // store Candidate in database
   public void ejbStore() {}
   
   // remove Candidate from database
   public void ejbRemove() {}  
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
