// Message.java
// Message represents an object that can be sent to an IMPeer;
// contains the sender and content of the message.
package com.deitel.advjhtp1.jini.IM;

// Java core package
import java.io.Serializable;

public class Message implements Serializable
{
   private static final long SerialVersionUID = 20010808L;
   private String from;
   private String content;
   
   // Message constructor
   public Message( String messageSenderName, 
      String messageContent )
   {
      from = messageSenderName;
      content = messageContent;
   } 
   
   // get String representation
   public String toString()
   {
      return from + ": " + content + "\n";
   }
   
   // get Message sender's name
   public String getSenderName()
   {
      return from;
   }
   
   // get Message content
   public String getContent()
   {
      return content;
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
