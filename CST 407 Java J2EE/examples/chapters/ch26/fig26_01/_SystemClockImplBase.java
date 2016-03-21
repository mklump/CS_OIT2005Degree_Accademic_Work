package com.deitel.advjhtp1.idl.clock;


/**
* com/deitel/advjhtp1/idl/clock/_SystemClockImplBase.java
* Generated by the IDL-to-Java compiler (portable), version "3.0"
* from systemclock.idl
* Sunday, July 1, 2001 10:36:53 PM PDT
*/


// The definition of the CORBA-enabled service
public abstract class _SystemClockImplBase extends org.omg.CORBA.portable.ObjectImpl
                implements com.deitel.advjhtp1.idl.clock.SystemClock, org.omg.CORBA.portable.InvokeHandler
{

  // Constructors
  public _SystemClockImplBase ()
  {
  }

  private static java.util.Hashtable _methods = new java.util.Hashtable ();
  static
  {
    _methods.put ("currentTimeMillis", new java.lang.Integer (0));
  }

  public org.omg.CORBA.portable.OutputStream _invoke (String method,
                                org.omg.CORBA.portable.InputStream in,
                                org.omg.CORBA.portable.ResponseHandler rh)
  {
    org.omg.CORBA.portable.OutputStream out = null;
    java.lang.Integer __method = (java.lang.Integer)_methods.get (method);
    if (__method == null)
      throw new org.omg.CORBA.BAD_OPERATION (0, org.omg.CORBA.CompletionStatus.COMPLETED_MAYBE);

    switch (__method.intValue ())
    {
       case 0:  // clock/SystemClock/currentTimeMillis
       {
         long __result = (long)0;
         __result = this.currentTimeMillis ();
         out = rh.createReply();
         out.write_longlong (__result);
         break;
       }

       default:
         throw new org.omg.CORBA.BAD_OPERATION (0, org.omg.CORBA.CompletionStatus.COMPLETED_MAYBE);
    }

    return out;
  } // _invoke

  // Type-specific CORBA::Object operations
  private static String[] __ids = {
    "IDL:clock/SystemClock:1.0"};

  public String[] _ids ()
  {
    return __ids;
  }


} // class _SystemClockImplBase
