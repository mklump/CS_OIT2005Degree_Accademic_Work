// VoteCollector.java
// VoteCollector tallies and displays the votes
// posted as TextMessages to the "Votes" queue.
package com.deitel.advjhtp1.jms.voter;

// Java core packages
import java.awt.*;
import java.awt.event.*;
import java.util.*;

// Java extension packages
import javax.swing.*;
import javax.jms.*;
import javax.naming.*;

public class VoteCollector extends JFrame {

   private JPanel displayPanel;
   private Map tallies = new HashMap();
   
   // JMS variables
   private QueueConnection queueConnection;
   
   // VoteCollector constructor
   public VoteCollector()
   {
      super( "Vote Tallies" );
      
      Container container = getContentPane();

      // displayPanel will display tally results
      displayPanel = new JPanel();
      displayPanel.setLayout( new GridLayout( 0, 1 ) );
      container.add( new JScrollPane( displayPanel ) );

      // invoke method quit when window closed
      addWindowListener(

         new WindowAdapter() {

            public void windowClosing( WindowEvent event ) {
               quit();
            }
         }
      );

      // connect to "Votes" queue
      try {

         // create JNDI context
         Context jndiContext = new InitialContext();

         // retrieve queue connection factory
         // and queue from JNDI context
         QueueConnectionFactory queueConnectionFactory =
            ( QueueConnectionFactory )
            jndiContext.lookup( "VOTE_FACTORY" );
         Queue queue = ( Queue ) jndiContext.lookup( "Votes" );

         // create connection, session and receiver
         queueConnection = 
            queueConnectionFactory.createQueueConnection();
         QueueSession queueSession =
            queueConnection.createQueueSession( false,
               Session.AUTO_ACKNOWLEDGE );
         QueueReceiver queueReceiver =
            queueSession.createReceiver( queue );

         // initialize and set message listener
         queueReceiver.setMessageListener( 
            new VoteListener( this ) );

         // start connection
         queueConnection.start();
      }

      // process Naming exception from JNDI context
      catch ( NamingException namingException ) {
         namingException.printStackTrace();
         System.exit( 1 );
      }

      // process JMS exception from queue connection or session
      catch ( JMSException jmsException ) {
         jmsException.printStackTrace();
         System.exit( 1 );
      }
      
   } // end VoteCollector constructor

   // add vote to corresponding tally
   public void addVote( String vote )
   {
      if ( tallies.containsKey( vote ) ) {

         // if vote already has corresponding tally
         TallyPanel tallyPanel =
            ( TallyPanel ) tallies.get( vote );
         tallyPanel.updateTally();
      }

      // add to GUI and tallies
      else {
         TallyPanel tallyPanel = new TallyPanel( vote, 1 );
         displayPanel.add( tallyPanel );
         tallies.put( vote, tallyPanel );
         validate();
      }
   }

   // quit application
   public void quit()
   {
      if ( queueConnection != null ) {

         // close the queue connection if it exists
         try {
            queueConnection.close();
         }

         // process JMS exception 
         catch ( JMSException jmsException ) {
            jmsException.printStackTrace();
            System.exit( 1 );
         }

      }

      System.exit( 0 );

   } // end method quit

   // launch VoteCollector
   public static void main( String args[] )
   {
      VoteCollector voteCollector = new VoteCollector();
      voteCollector.setSize( 200, 200 );
      voteCollector.setVisible( true );
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
