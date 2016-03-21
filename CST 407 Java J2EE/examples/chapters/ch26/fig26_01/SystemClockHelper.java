package com.deitel.advjhtp1.idl.clock;


/**
* com/deitel/advjhtp1/idl/clock/SystemClockHelper.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from systemclock.idl
* Sunday, July 1, 2001 10:36:53 PM PDT
*/


// The definition of the CORBA-enabled service
abstract public class SystemClockHelper
{
  private static String  _id = "IDL:clock/SystemClock:1.0";

  public static void insert (org.omg.CORBA.Any a, com.deitel.advjhtp1.idl.clock.SystemClock that)
  {
    org.omg.CORBA.portable.OutputStream out = a.create_output_stream ();
    a.type (type ());
    write (out, that);
    a.read_value (out.create_input_stream (), type ());
  }

  public static com.deitel.advjhtp1.idl.clock.SystemClock extract (org.omg.CORBA.Any a)
  {
    return read (a.create_input_stream ());
  }

  private static org.omg.CORBA.TypeCode __typeCode = null;
  synchronized public static org.omg.CORBA.TypeCode type ()
  {
    if (__typeCode == null)
    {
      __typeCode = org.omg.CORBA.ORB.init ().create_interface_tc (com.deitel.advjhtp1.idl.clock.SystemClockHelper.id (), "SystemClock");
    }
    return __typeCode;
  }

  public static String id ()
  {
    return _id;
  }

  public static com.deitel.advjhtp1.idl.clock.SystemClock read (org.omg.CORBA.portable.InputStream istream)
  {
    return narrow (istream.read_Object (_SystemClockStub.class));
  }

  public static void write (org.omg.CORBA.portable.OutputStream ostream, com.deitel.advjhtp1.idl.clock.SystemClock value)
  {
    ostream.write_Object ((org.omg.CORBA.Object) value);
  }

  public static com.deitel.advjhtp1.idl.clock.SystemClock narrow (org.omg.CORBA.Object obj)
  {
    if (obj == null)
      return null;
    else if (obj instanceof com.deitel.advjhtp1.idl.clock.SystemClock)
      return (com.deitel.advjhtp1.idl.clock.SystemClock)obj;
    else if (!obj._is_a (id ()))
      throw new org.omg.CORBA.BAD_PARAM ();
    else
    {
      org.omg.CORBA.portable.Delegate delegate = ((org.omg.CORBA.portable.ObjectImpl)obj)._get_delegate ();
      return new com.deitel.advjhtp1.idl.clock._SystemClockStub (delegate);
    }
  }

}
