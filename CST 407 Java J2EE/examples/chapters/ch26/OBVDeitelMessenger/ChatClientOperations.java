package com.deitel.messenger.obvcorba.client;


/**
* com/deitel/messenger/obvcorba/client/ChatClientOperations.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from chat.idl
* Tuesday, August 21, 2001 10:20:45 PM EDT
*/

public interface ChatClientOperations 
{

  // receive new message
  void deliverMessage (com.deitel.messenger.obvcorba.ChatMessage message);

  // method called when server shuting down
  void serverStopping ();
} // interface ChatClientOperations
