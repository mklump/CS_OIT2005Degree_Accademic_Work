package com.deitel.messenger.corba.server;


/**
* com/deitel/messenger/corba/server/_ChatServerStub.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from chat.idl
* Tuesday, August 21, 2001 6:24:10 PM EDT
*/

public class _ChatServerStub extends org.omg.CORBA.portable.ObjectImpl implements com.deitel.messenger.corba.server.ChatServer
{
  // Constructors
  // NOTE:  If the default constructor is used, the
  //        object is useless until _set_delegate (...)
  //        is called.
  public _ChatServerStub ()
  {
    super ();
  }

  public _ChatServerStub (org.omg.CORBA.portable.Delegate delegate)
  {
    super ();
    _set_delegate (delegate);
  }


  // register new ChatClient with ChatServer
  public void registerClient (com.deitel.messenger.corba.client.ChatClient client)
  {
    org.omg.CORBA.portable.InputStream _in = null;
    try {
       org.omg.CORBA.portable.OutputStream _out = _request ("registerClient", true);
       com.deitel.messenger.corba.client.ChatClientHelper.write (_out, client);
       _in = _invoke (_out);
    } catch (org.omg.CORBA.portable.ApplicationException _ex) {
       _in = _ex.getInputStream ();
       String _id = _ex.getId ();
       throw new org.omg.CORBA.MARSHAL (_id);
    } catch (org.omg.CORBA.portable.RemarshalException _rm) {
       registerClient (client);
    } finally {
        _releaseReply (_in);
    }
  } // registerClient


  // unregister ChatClient with ChatServer
  public void unregisterClient (com.deitel.messenger.corba.client.ChatClient client)
  {
    org.omg.CORBA.portable.InputStream _in = null;
    try {
       org.omg.CORBA.portable.OutputStream _out = _request ("unregisterClient", true);
       com.deitel.messenger.corba.client.ChatClientHelper.write (_out, client);
       _in = _invoke (_out);
    } catch (org.omg.CORBA.portable.ApplicationException _ex) {
       _in = _ex.getInputStream ();
       String _id = _ex.getId ();
       throw new org.omg.CORBA.MARSHAL (_id);
    } catch (org.omg.CORBA.portable.RemarshalException _rm) {
       unregisterClient (client);
    } finally {
        _releaseReply (_in);
    }
  } // unregisterClient


  // post new message to ChatServer
  public void postMessage (com.deitel.messenger.corba.ChatMessage message)
  {
    org.omg.CORBA.portable.InputStream _in = null;
    try {
       org.omg.CORBA.portable.OutputStream _out = _request ("postMessage", true);
       com.deitel.messenger.corba.ChatMessageHelper.write (_out, message);
       _in = _invoke (_out);
    } catch (org.omg.CORBA.portable.ApplicationException _ex) {
       _in = _ex.getInputStream ();
       String _id = _ex.getId ();
       throw new org.omg.CORBA.MARSHAL (_id);
    } catch (org.omg.CORBA.portable.RemarshalException _rm) {
       postMessage (message);
    } finally {
        _releaseReply (_in);
    }
  } // postMessage

  // Type-specific CORBA::Object operations
  private static String[] __ids = {
    "IDL:corba/server/ChatServer:1.0"};

  public String[] _ids ()
  {
    return (String[])__ids.clone ();
  }

  private void readObject (java.io.ObjectInputStream s)
  {
     try 
     {
       String str = s.readUTF ();
       org.omg.CORBA.Object obj = org.omg.CORBA.ORB.init ().string_to_object (str);
       org.omg.CORBA.portable.Delegate delegate = ((org.omg.CORBA.portable.ObjectImpl) obj)._get_delegate ();
       _set_delegate (delegate);
     } catch (java.io.IOException e) {}
  }

  private void writeObject (java.io.ObjectOutputStream s)
  {
     try 
     {
       String str = org.omg.CORBA.ORB.init ().object_to_string (this);
       s.writeUTF (str);
     } catch (java.io.IOException e) {}
  }
} // class _ChatServerStub
