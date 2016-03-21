// ChatMessage.java
// ChatMessage is a Serializable object for messages in the RMI
// ChatClient and ChatServer.
package com.deitel.messenger.rmi;

// Java core packages
import java.io.*;

public class ChatMessage implements Serializable {

   private String sender;   // person sending message
   private String message;  // message being sent
   
   // construct empty ChatMessage
   public ChatMessage() 
   { 
      this( "", "" ); 
   }
   
   // construct ChatMessage with sender and message values
   public ChatMessage( String sender, String message )
   {
      setSender( sender );
      setMessage( message );
   }
   
   // set name of person sending message
   public void setSender( String name ) 
   { 
      sender = name; 
   }
   
   // get name of person sending message 
   public String getSender() 
   { 
      return sender; 
   }
   
   // set message being sent
   public void setMessage( String messageBody ) 
   { 
      message = messageBody; 
   }
     
   // get message being sent
   public String getMessage() 
   { 
      return message; 
   }   
   
   // String representation of ChatMessage
   public String toString() 
   {
      return getSender() + "> " + getMessage();
   }
}

/**************************************************************************
 * (C) Copyright 2001 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/


/**************************************************************************
 * (C) Copyright 2001 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
