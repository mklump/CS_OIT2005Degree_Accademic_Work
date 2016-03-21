// Fig. 26.29: ChatMessageImpl.java
package com.deitel.messenger.obvcorba;

public class ChatMessageImpl extends ChatMessage {

   // default constructor for empty ChatMessageImpl object
   public ChatMessageImpl()
   {
       this( "", "" );
   }
    
   // constructor to initialize from and message properties
   public ChatMessageImpl( String sender, String text )
   {
      from = sender;
      message = text;
   }

   // Return the name of who sent the message
   public String getSenderName()
   {
      return from;
   }
    
   // Get the message
   public String getMessage()
   {
      return message;
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

