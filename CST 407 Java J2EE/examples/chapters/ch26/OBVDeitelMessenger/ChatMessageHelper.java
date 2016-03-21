package com.deitel.messenger.obvcorba;


/**
* com/deitel/messenger/obvcorba/ChatMessageHelper.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from chat.idl
* Tuesday, August 21, 2001 10:20:45 PM EDT
*/

abstract public class ChatMessageHelper
{
  private static String  _id = "IDL:obvcorba/ChatMessage:1.0";


  public static void insert (org.omg.CORBA.Any a, com.deitel.messenger.obvcorba.ChatMessage that)
  {
    org.omg.CORBA.portable.OutputStream out = a.create_output_stream ();
    a.type (type ());
    write (out, that);
    a.read_value (out.create_input_stream (), type ());
  }

  public static com.deitel.messenger.obvcorba.ChatMessage extract (org.omg.CORBA.Any a)
  {
    return read (a.create_input_stream ());
  }

  private static org.omg.CORBA.TypeCode __typeCode = null;
  private static boolean __active = false;
  synchronized public static org.omg.CORBA.TypeCode type ()
  {
    if (__typeCode == null)
    {
      synchronized (org.omg.CORBA.TypeCode.class)
      {
        if (__typeCode == null)
        {
          if (__active)
          {
            return org.omg.CORBA.ORB.init().create_recursive_tc ( _id );
          }
          __active = true;
          org.omg.CORBA.ValueMember[] _members0 = new org.omg.CORBA.ValueMember[2];
          org.omg.CORBA.TypeCode _tcOf_members0 = null;
          // ValueMember instance for from
          _tcOf_members0 = org.omg.CORBA.ORB.init ().create_string_tc (0);
          _members0[0] = new org.omg.CORBA.ValueMember ("from", 
              "", 
              _id, 
              "", 
              _tcOf_members0, 
              null, 
              org.omg.CORBA.PRIVATE_MEMBER.value);
          // ValueMember instance for message
          _tcOf_members0 = org.omg.CORBA.ORB.init ().create_string_tc (0);
          _members0[1] = new org.omg.CORBA.ValueMember ("message", 
              "", 
              _id, 
              "", 
              _tcOf_members0, 
              null, 
              org.omg.CORBA.PRIVATE_MEMBER.value);
          __typeCode = org.omg.CORBA.ORB.init ().create_value_tc (_id, "ChatMessage", org.omg.CORBA.VM_NONE.value, null, _members0);
          __active = false;
        }
      }
    }
    return __typeCode;
  }

  public static String id ()
  {
    return _id;
  }

  public static com.deitel.messenger.obvcorba.ChatMessage read (org.omg.CORBA.portable.InputStream istream)
  {
    return (com.deitel.messenger.obvcorba.ChatMessage)((org.omg.CORBA_2_3.portable.InputStream) istream).read_value (id ());
  }

  public static void write (org.omg.CORBA.portable.OutputStream ostream, com.deitel.messenger.obvcorba.ChatMessage value)
  {
    ((org.omg.CORBA_2_3.portable.OutputStream) ostream).write_value (value, id ());
  }


  public static com.deitel.messenger.obvcorba.ChatMessage create (org.omg.CORBA.ORB _orb, String from, String message)
  {
    try {
      com.deitel.messenger.obvcorba.ChatMessageValueFactory _factory = (com.deitel.messenger.obvcorba.ChatMessageValueFactory)
          ((org.omg.CORBA_2_3.ORB) _orb).lookup_value_factory(id());
      return _factory.create (from, message);
    } catch (ClassCastException _ex) {
      throw new org.omg.CORBA.BAD_PARAM ();
    }
  }

}