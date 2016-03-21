// TallyDisplay.java
// TallyDisplay displays the votes from database.
package com.deitel.advjhtp1.jms.mdb;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.rmi.*;
import java.util.*;
import java.util.List;

// Java extension packages
import javax.swing.*;
import javax.ejb.*;
import javax.rmi.*;
import javax.naming.*;
public class TallyDisplay extends JFrame {

   // TallyDisplay constructor
   public TallyDisplay()
   {
      super( "Vote Tallies" );
      
      Container container = getContentPane();

      // displayPanel displays tally results
      JPanel displayPanel = new JPanel();
      displayPanel.setLayout( new GridLayout( 0, 1 ) );
      container.add( new JScrollPane( displayPanel ) );

      // find Candidates and display tallies
      try {
         
         // look up Candidate EJB
         Context initialContext = new InitialContext();

         Object object = initialContext.lookup( 
            "Candidate" );
         CandidateHome candidateHome = 
            ( CandidateHome ) PortableRemoteObject.narrow( 
                  object, CandidateHome.class );

         // find all Candidates
         Collection candidates = 
            candidateHome.findAllCandidates();

         // add TallyPanel with candidate name and
         // vote count for each candidate
         Iterator iterator = candidates.iterator();
         while ( iterator.hasNext() ) {
            Candidate candidate = ( Candidate ) iterator.next();

            // create TallyPanel for Candidate
            TallyPanel tallyPanel =
               new TallyPanel( candidate.getCandidateName(),
                  candidate.getVoteCount().intValue() );
            displayPanel.add( tallyPanel );
         }
         
      } // end try
      
      // handle exception finding Candidates
      catch ( FinderException finderException ) { 
         finderException.printStackTrace();
      }       
      // handle exception looking up Candidate EJB
      catch ( NamingException namingException ) { 
         namingException.printStackTrace(); 
      }      
      
      // handle exception communicating with Candidate
      catch ( RemoteException remoteException ) { 
         remoteException.printStackTrace(); 
      }

   } // end TallyDisplay constructor

   // launch TallyDisplay application
   public static void main( String args[] )
   {
      TallyDisplay tallyDisplay = new TallyDisplay();
      tallyDisplay.setDefaultCloseOperation( EXIT_ON_CLOSE );
      tallyDisplay.pack();
      tallyDisplay.setVisible( true );
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
