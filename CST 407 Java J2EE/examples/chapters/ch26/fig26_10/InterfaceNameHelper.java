package maptest;


/**
* maptest/InterfaceNameHelper.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from maptest.idl
* Monday, May 14, 2001 4:18:09 PM PDT
*/


// the interface declaration for InterfaceName
abstract public class InterfaceNameHelper
{
  private static String  _id = "IDL:maptest/InterfaceName:1.0";

  public static void insert (org.omg.CORBA.Any a, maptest.InterfaceName that)
  {
    org.omg.CORBA.portable.OutputStream out = a.create_output_stream ();
    a.type (type ());
    write (out, that);
    a.read_value (out.create_input_stream (), type ());
  }

  public static maptest.InterfaceName extract (org.omg.CORBA.Any a)
  {
    return read (a.create_input_stream ());
  }

  private static org.omg.CORBA.TypeCode __typeCode = null;
  synchronized public static org.omg.CORBA.TypeCode type ()
  {
    if (__typeCode == null)
    {
      __typeCode = org.omg.CORBA.ORB.init ().create_interface_tc (maptest.InterfaceNameHelper.id (), "InterfaceName");
    }
    return __typeCode;
  }

  public static String id ()
  {
    return _id;
  }

  public static maptest.InterfaceName read (org.omg.CORBA.portable.InputStream istream)
  {
    return narrow (istream.read_Object (_InterfaceNameStub.class));
  }

  public static void write (org.omg.CORBA.portable.OutputStream ostream, maptest.InterfaceName value)
  {
    ostream.write_Object ((org.omg.CORBA.Object) value);
  }

  public static maptest.InterfaceName narrow (org.omg.CORBA.Object obj)
  {
    if (obj == null)
      return null;
    else if (obj instanceof maptest.InterfaceName)
      return (maptest.InterfaceName)obj;
    else if (!obj._is_a (id ()))
      throw new org.omg.CORBA.BAD_PARAM ();
    else
    {
      org.omg.CORBA.portable.Delegate delegate = ((org.omg.CORBA.portable.ObjectImpl)obj)._get_delegate ();
      return new maptest._InterfaceNameStub (delegate);
    }
  }

}
