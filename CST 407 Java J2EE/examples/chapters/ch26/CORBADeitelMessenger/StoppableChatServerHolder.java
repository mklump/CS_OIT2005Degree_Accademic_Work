package com.deitel.messenger.corba.server;

/**
* com/deitel/messenger/corba/server/StoppableChatServerHolder.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from chat.idl
* Tuesday, August 21, 2001 6:24:10 PM EDT
*/

public final class StoppableChatServerHolder implements org.omg.CORBA.portable.Streamable
{
  public com.deitel.messenger.corba.server.StoppableChatServer value = null;

  public StoppableChatServerHolder ()
  {
  }

  public StoppableChatServerHolder (com.deitel.messenger.corba.server.StoppableChatServer initialValue)
  {
    value = initialValue;
  }

  public void _read (org.omg.CORBA.portable.InputStream i)
  {
    value = com.deitel.messenger.corba.server.StoppableChatServerHelper.read (i);
  }

  public void _write (org.omg.CORBA.portable.OutputStream o)
  {
    com.deitel.messenger.corba.server.StoppableChatServerHelper.write (o, value);
  }

  public org.omg.CORBA.TypeCode _type ()
  {
    return com.deitel.messenger.corba.server.StoppableChatServerHelper.type ();
  }

}
