package com.deitel.advjhtp1.idl.domain;

/**
* com/deitel/advjhtp1/idl/domain/CustomerHomeHolder.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from domain.idl
* Sunday, July 1, 2001 11:46:27 PM PDT
*/

public final class CustomerHomeHolder implements org.omg.CORBA.portable.Streamable
{
  public com.deitel.advjhtp1.idl.domain.CustomerHome value = null;

  public CustomerHomeHolder ()
  {
  }

  public CustomerHomeHolder (com.deitel.advjhtp1.idl.domain.CustomerHome initialValue)
  {
    value = initialValue;
  }

  public void _read (org.omg.CORBA.portable.InputStream i)
  {
    value = com.deitel.advjhtp1.idl.domain.CustomerHomeHelper.read (i);
  }

  public void _write (org.omg.CORBA.portable.OutputStream o)
  {
    com.deitel.advjhtp1.idl.domain.CustomerHomeHelper.write (o, value);
  }

  public org.omg.CORBA.TypeCode _type ()
  {
    return com.deitel.advjhtp1.idl.domain.CustomerHomeHelper.type ();
  }

}
