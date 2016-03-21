// VoteListener.java
// VoteListener is the message listener for the
// receiver of the "Votes" queue. It implements 
// the specified onMessage method to update the 
// GUI with the received vote.
package com.deitel.advjhtp1.jms.voter;

// Java extension packages
import javax.jms.*;

public class VoteListener implements MessageListener {

   private VoteCollector voteCollector;

   // VoteListener constructor
   public VoteListener( VoteCollector collector )
   {
      voteCollector = collector;
   }

   // receive new message
   public void onMessage( Message message )
   {
      TextMessage voteMessage;

      // retrieve and process message
      try {

         if ( message instanceof TextMessage ) {
            voteMessage = ( TextMessage ) message;
            String vote = voteMessage.getText();
            voteCollector.addVote( vote );

            System.out.println( "Received vote: " + vote );
         }

         else {
            System.out.println( "Expecting " +
               "TextMessage object, received " +
               message.getClass().getName() );
         }
      }

      // process JMS exception from message
      catch ( JMSException jmsException ) {
         jmsException.printStackTrace();
      }

   } // end method onMessage
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
