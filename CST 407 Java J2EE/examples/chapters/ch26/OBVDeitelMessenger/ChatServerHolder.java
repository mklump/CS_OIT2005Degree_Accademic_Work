package com.deitel.messenger.obvcorba.server;

/**
* com/deitel/messenger/obvcorba/server/ChatServerHolder.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from chat.idl
* Tuesday, August 21, 2001 10:20:46 PM EDT
*/

public final class ChatServerHolder implements org.omg.CORBA.portable.Streamable
{
  public com.deitel.messenger.obvcorba.server.ChatServer value = null;

  public ChatServerHolder ()
  {
  }

  public ChatServerHolder (com.deitel.messenger.obvcorba.server.ChatServer initialValue)
  {
    value = initialValue;
  }

  public void _read (org.omg.CORBA.portable.InputStream i)
  {
    value = com.deitel.messenger.obvcorba.server.ChatServerHelper.read (i);
  }

  public void _write (org.omg.CORBA.portable.OutputStream o)
  {
    com.deitel.messenger.obvcorba.server.ChatServerHelper.write (o, value);
  }

  public org.omg.CORBA.TypeCode _type ()
  {
    return com.deitel.messenger.obvcorba.server.ChatServerHelper.type ();
  }

}
