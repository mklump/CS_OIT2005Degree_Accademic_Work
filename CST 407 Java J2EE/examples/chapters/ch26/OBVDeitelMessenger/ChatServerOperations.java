package com.deitel.messenger.obvcorba.server;


/**
* com/deitel/messenger/obvcorba/server/ChatServerOperations.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from chat.idl
* Tuesday, August 21, 2001 10:20:46 PM EDT
*/

public interface ChatServerOperations 
{

  // register new ChatClient with ChatServer
  void registerClient (com.deitel.messenger.obvcorba.client.ChatClient client);

  // unregister ChatClient with ChatServer
  void unregisterClient (com.deitel.messenger.obvcorba.client.ChatClient client);

  // post new message to ChatServer
  void postMessage (com.deitel.messenger.obvcorba.ChatMessage message);
} // interface ChatServerOperations
