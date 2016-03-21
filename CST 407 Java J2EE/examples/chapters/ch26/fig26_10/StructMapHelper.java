package maptest;


/**
* maptest/StructMapHelper.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from maptest.idl
* Monday, May 14, 2001 4:18:09 PM PDT
*/


// This comment appears in the generated files for StructMap
abstract public class StructMapHelper
{
  private static String  _id = "IDL:maptest/StructMap:1.0";

  public static void insert (org.omg.CORBA.Any a, maptest.StructMap that)
  {
    org.omg.CORBA.portable.OutputStream out = a.create_output_stream ();
    a.type (type ());
    write (out, that);
    a.read_value (out.create_input_stream (), type ());
  }

  public static maptest.StructMap extract (org.omg.CORBA.Any a)
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
          org.omg.CORBA.StructMember[] _members0 = new org.omg.CORBA.StructMember [14];
          org.omg.CORBA.TypeCode _tcOf_members0 = null;
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_boolean);
          _members0[0] = new org.omg.CORBA.StructMember (
            "boolValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_char);
          _members0[1] = new org.omg.CORBA.StructMember (
            "charValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_wchar);
          _members0[2] = new org.omg.CORBA.StructMember (
            "wCharValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_octet);
          _members0[3] = new org.omg.CORBA.StructMember (
            "octetValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().create_string_tc (0);
          _members0[4] = new org.omg.CORBA.StructMember (
            "stringValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().create_string_tc (0);
          _members0[5] = new org.omg.CORBA.StructMember (
            "wStringValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_short);
          _members0[6] = new org.omg.CORBA.StructMember (
            "shortValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_ushort);
          _members0[7] = new org.omg.CORBA.StructMember (
            "uShortValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_long);
          _members0[8] = new org.omg.CORBA.StructMember (
            "longValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_ulong);
          _members0[9] = new org.omg.CORBA.StructMember (
            "uLongValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_longlong);
          _members0[10] = new org.omg.CORBA.StructMember (
            "longLongValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_ulonglong);
          _members0[11] = new org.omg.CORBA.StructMember (
            "uLongLongValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_float);
          _members0[12] = new org.omg.CORBA.StructMember (
            "floatValue",
            _tcOf_members0,
            null);
          _tcOf_members0 = org.omg.CORBA.ORB.init ().get_primitive_tc (org.omg.CORBA.TCKind.tk_double);
          _members0[13] = new org.omg.CORBA.StructMember (
            "doubleValue",
            _tcOf_members0,
            null);
          __typeCode = org.omg.CORBA.ORB.init ().create_struct_tc (maptest.StructMapHelper.id (), "StructMap", _members0);
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

  public static maptest.StructMap read (org.omg.CORBA.portable.InputStream istream)
  {
    maptest.StructMap value = new maptest.StructMap ();
    value.boolValue = istream.read_boolean ();
    value.charValue = istream.read_char ();
    value.wCharValue = istream.read_wchar ();
    value.octetValue = istream.read_octet ();
    value.stringValue = istream.read_string ();
    value.wStringValue = istream.read_wstring ();
    value.shortValue = istream.read_short ();
    value.uShortValue = istream.read_ushort ();
    value.longValue = istream.read_long ();
    value.uLongValue = istream.read_ulong ();
    value.longLongValue = istream.read_longlong ();
    value.uLongLongValue = istream.read_ulonglong ();
    value.floatValue = istream.read_float ();
    value.doubleValue = istream.read_double ();
    return value;
  }

  public static void write (org.omg.CORBA.portable.OutputStream ostream, maptest.StructMap value)
  {
    ostream.write_boolean (value.boolValue);
    ostream.write_char (value.charValue);
    ostream.write_wchar (value.wCharValue);
    ostream.write_octet (value.octetValue);
    ostream.write_string (value.stringValue);
    ostream.write_wstring (value.wStringValue);
    ostream.write_short (value.shortValue);
    ostream.write_ushort (value.uShortValue);
    ostream.write_long (value.longValue);
    ostream.write_ulong (value.uLongValue);
    ostream.write_longlong (value.longLongValue);
    ostream.write_ulonglong (value.uLongLongValue);
    ostream.write_float (value.floatValue);
    ostream.write_double (value.doubleValue);
  }

}