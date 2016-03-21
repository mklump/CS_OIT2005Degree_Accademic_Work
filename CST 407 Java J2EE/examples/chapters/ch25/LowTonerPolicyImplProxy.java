
// Generated on "Sun Aug 06 09:22:13 EDT 2000"

// package identification
package com.deitel.advjhtp1.jiro.DynamicService.policy;

// imported classes
import com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicy;
import com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagement;
import com.sun.fma.client.BaseProxy;
import java.lang.reflect.InvocationTargetException;
import java.rmi.RemoteException;
import java.rmi.ServerError;
import java.rmi.UnexpectedException;
import javax.fma.common.StationAddress;
import javax.fma.services.event.EventNotHandledException;
import net.jini.core.event.RemoteEvent;
import net.jini.core.event.RemoteEventListener;
import net.jini.core.event.UnknownEventException;

/**
 * Generated Proxy class for com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl.
 * @see javax.fma.common.Proxy
 * @see com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl
 */
public final class LowTonerPolicyImplProxy extends BaseProxy
    implements LowTonerPolicy, RemoteEventListener
{
    
    // -------------------- Constructor methods
    /**
     * Wraps the specified LowTonerPolicyImpl object in a Proxy.
     *  
     * @param referent Object to be wrapped in a Proxy.  Must be an instance of com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl or ClassCastException will be thrown. 
     * @throws java.lang.ClassCastException
     * @throws java.rmi.RemoteException
     */
    public LowTonerPolicyImplProxy( Object referent )
        throws ClassCastException, RemoteException
    {
        // Avoid NullPointerException while calling super().
        // If referent is null, exportReferent will throw an IllegalArgumentException.
        super( referent == null ? "" : referent.getClass().getName() );
        exportReferent( referent, "com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl" );
    }
    /**
     * Constructs a new LowTonerPolicyImpl on specified Station.
     * @see com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl#LowTonerPolicyImpl 
     * @param station Station to construct object on. 
     * @throws java.rmi.RemoteException
     */
    public LowTonerPolicyImplProxy( StationAddress station )
        throws RemoteException
    {
        super( "com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl" );
        try
        {
            // make remote call
            remoteConstruct(
                station,
                "com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl",
                "<init>()Lcom.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl;",
                new Object[] {  }
            );
        }
        catch ( InvocationTargetException ite )
        {
            Throwable t = ite.getTargetException();
            // rethrow Errors as ServerError
            if ( t instanceof Error )
                throw new ServerError( "Error thrown from referent method", (Error) t );
            // rethrow other exceptions as UnexpectedException
            throw new UnexpectedException(
                "Proxy does not match referent class.  Unexpected declared exception thrown from referent method", (Exception) t );
        }
    }
    
    // -------------------- Class methods
    /**
     * Returns the name of the referent class for this proxy class.
     */
    public static String getReferentClassClassName( )
    {
        return "com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl";
    }
    
    // -------------------- Instance methods
    /**
     * Calls notify() on LowTonerPolicyImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl#notify
     * @see com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl#notify 
     * @param theRemoteEvent0  
     * @throws java.rmi.RemoteException
     * @throws javax.fma.services.event.EventNotHandledException
     * @throws net.jini.core.event.UnknownEventException
     */
    public void notify( RemoteEvent theRemoteEvent0 )
        throws RemoteException, EventNotHandledException, UnknownEventException
    {
        try
        {
            // make remote call
            remoteInstanceMethodCall(
                "notify(Lnet.jini.core.event.RemoteEvent;)V",
                new Object[] { theRemoteEvent0 }
            );
        }
        catch ( InvocationTargetException ite )
        {
            Throwable t = ite.getTargetException();
            // rethrow declared exceptions
            if ( t instanceof UnknownEventException )
                throw (UnknownEventException) t;
            if ( t instanceof RemoteException )
                throw (RemoteException) t;
            if ( t instanceof EventNotHandledException )
                throw (EventNotHandledException) t;
            // rethrow Errors as ServerError
            if ( t instanceof Error )
                throw new ServerError( "Error thrown from referent method", (Error) t );
            // rethrow other exceptions as UnexpectedException
            throw new UnexpectedException(
                "Proxy does not match referent class.  Unexpected declared exception thrown from referent method", (Exception) t );
        }
    }
    /**
     * Calls stopPolicy() on LowTonerPolicyImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl#stopPolicy
     * @see com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl#stopPolicy 
     * @throws java.rmi.RemoteException
     */
    public void stopPolicy( )
        throws RemoteException
    {
        try
        {
            // make remote call
            remoteInstanceMethodCall(
                "stopPolicy()V",
                new Object[] {  }
            );
        }
        catch ( InvocationTargetException ite )
        {
            Throwable t = ite.getTargetException();
            // rethrow Errors as ServerError
            if ( t instanceof Error )
                throw new ServerError( "Error thrown from referent method", (Error) t );
            // rethrow other exceptions as UnexpectedException
            throw new UnexpectedException(
                "Proxy does not match referent class.  Unexpected declared exception thrown from referent method", (Exception) t );
        }
    }
    /**
     * Calls getPrinterManagementProxy() on LowTonerPolicyImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.policy.LowTonerPolicyImpl#getPrinterManagementProxy 
     * @throws java.rmi.RemoteException
     */
    public PrinterManagement getPrinterManagementProxy( )
        throws RemoteException
    {
        try
        {
            // make remote call
            return (PrinterManagement)remoteInstanceMethodCall(
                "getPrinterManagementProxy()Lcom.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagement;",
                new Object[] {  }
            );
        }
        catch ( InvocationTargetException ite )
        {
            Throwable t = ite.getTargetException();
            // rethrow Errors as ServerError
            if ( t instanceof Error )
                throw new ServerError( "Error thrown from referent method", (Error) t );
            // rethrow other exceptions as UnexpectedException
            throw new UnexpectedException(
                "Proxy does not match referent class.  Unexpected declared exception thrown from referent method", (Exception) t );
        }
    }
    /**
     * @internal
     * Code generation version
     */
    public static final String _codeGenerationVersion = "Sun Aug 06 09:22:13 EDT 2000";
    
} // end of LowTonerPolicyImplProxy

/***************************************************************
 * (C) Copyright 2002 by Deitel & Associates, Inc. and         *
 * Prentice Hall. All Rights Reserved.                         *
 *                                                             *
 * DISCLAIMER: The authors and publisher of this book have     *
 * used their best efforts in preparing the book. These        *
 * efforts include the development, research, and testing of   *
 * the theories and programs to determine their effectiveness. *
 * The authors and publisher make no warranty of any kind,     *
 * expressed or implied, with regard to these programs or to   *
 * the documentation contained in these books. The authors     *
 * and publisher shall not be liable in any event for          *
 * incidental or consequential damages in connection with, or  *
 * arising out of, the furnishing, performance, or use of      *
 * these programs.                                             *
 ***************************************************************/
