package maptest;


/**
* maptest/BoundStructMapSeqHolder.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from maptest.idl
* Monday, May 14, 2001 4:18:09 PM PDT
*/

public final class BoundStructMapSeqHolder implements org.omg.CORBA.portable.Streamable
{
  public maptest.StructMap value[] = null;

  public BoundStructMapSeqHolder ()
  {
  }

  public BoundStructMapSeqHolder (maptest.StructMap[] initialValue)
  {
    value = initialValue;
  }

  public void _read (org.omg.CORBA.portable.InputStream i)
  {
    value = maptest.BoundStructMapSeqHelper.read (i);
  }

  public void _write (org.omg.CORBA.portable.OutputStream o)
  {
    maptest.BoundStructMapSeqHelper.write (o, value);
  }

  public org.omg.CORBA.TypeCode _type ()
  {
    return maptest.BoundStructMapSeqHelper.type ();
  }

}
