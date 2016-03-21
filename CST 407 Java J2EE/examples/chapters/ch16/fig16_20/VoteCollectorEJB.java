// VoteCollectorEJB.java
// VoteCollectorEJB is a MessageDriven EJB that tallies votes.
package com.deitel.advjhtp1.jms.mdb;

// Java core packages
import java.util.*;
import java.rmi.*;

// Java extension packages
import javax.ejb.*;
import javax.rmi.*;
import javax.jms.*;
import javax.naming.*;

public class VoteCollectorEJB
   implements MessageDrivenBean, MessageListener {

   private MessageDrivenContext messageDrivenContext;
   
   // receive new message
   public void onMessage( Message message )
   {
      TextMessage voteMessage;

      // retrieve and process message
      try {
         
         if ( message instanceof TextMessage ) {
            voteMessage = ( TextMessage ) message;
            String vote = voteMessage.getText();
            countVote( vote );

            System.out.println( "Received vote: " + vote );            
         } // end if

         else {
            System.out.println( "Expecting " +
               "TextMessage object, received " +
               message.getClass().getName() );
         }
         
      } // end try
      
      // process JMS exception from message
      catch ( JMSException jmsException ) {
         jmsException.printStackTrace();
      }
   }

   // add vote to corresponding tally
   private void countVote( String vote )
   {      
      // CandidateHome reference for finding/creating Candidates
      CandidateHome candidateHome = null;
      
      // find Candidate and increment vote count
      try {
         
         // look up Candidate EJB
         Context initialContext = new InitialContext();

         Object object = initialContext.lookup( 
            "java:comp/env/ejb/Candidate" );

         candidateHome = 
            ( CandidateHome ) PortableRemoteObject.narrow( 
                  object, CandidateHome.class );

         // find Candidate for whom the user voted
         Candidate candidate = 
            candidateHome.findByPrimaryKey( vote );   
         
         // increment Candidate's vote count
         candidate.incrementVoteCount();
         
      } // end try
      
      // if Candidate not found, create new Candidate
      catch ( FinderException finderException ) { 
         
         // create new Candidate and increment its vote count
         try {
            Candidate newCandidate = candidateHome.create( vote );
            newCandidate.incrementVoteCount();
         }
         
         // handle exceptions creating new Candidate
         catch ( Exception exception ) {
            throw new EJBException( exception );
         }
         
      } // end FinderException catch
      
      // handle exception when looking up OrderProducts EJB
      catch ( NamingException namingException ) { 
         throw new EJBException( namingException ); 
      }      
      
      // handle exception when invoking OrderProducts methods
      catch ( RemoteException remoteException ) { 
         throw new EJBException( remoteException ); 
      }
            
   } // end method countVote
   
   // set message driven context
   public void setMessageDrivenContext( 
      MessageDrivenContext context )
   {
      messageDrivenContext = context;
   }      
   
   // create bean instance
   public void ejbCreate() {}

   // remove bean instance
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
