
// Generated on "Sun Aug 06 09:21:42 EDT 2000"

// package identification
package com.deitel.advjhtp1.jiro.DynamicService.service;

// imported classes
import com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagement;
import com.sun.fma.client.BaseProxy;
import java.lang.reflect.InvocationTargetException;
import java.rmi.RemoteException;
import java.rmi.ServerError;
import java.rmi.UnexpectedException;
import javax.fma.common.StationAddress;
import net.jini.core.event.RemoteEvent;
import net.jini.core.event.RemoteEventListener;
import net.jini.core.event.UnknownEventException;

/**
 * Generated Proxy class for com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl.
 * @see javax.fma.common.Proxy
 * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl
 */
public final class PrinterManagementImplProxy extends BaseProxy
    implements PrinterManagement, RemoteEventListener
{
    
    // -------------------- Constructor methods
    /**
     * Wraps the specified PrinterManagementImpl object in a Proxy.
     *  
     * @param referent Object to be wrapped in a Proxy.  Must be an instance of com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl or ClassCastException will be thrown. 
     * @throws java.lang.ClassCastException
     * @throws java.rmi.RemoteException
     */
    public PrinterManagementImplProxy( Object referent )
        throws ClassCastException, RemoteException
    {
        // Avoid NullPointerException while calling super().
        // If referent is null, exportReferent will throw an IllegalArgumentException.
        super( referent == null ? "" : referent.getClass().getName() );
        exportReferent( referent, "com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl" );
    }
    /**
     * Constructs a new PrinterManagementImpl on specified Station.
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#PrinterManagementImpl 
     * @param station Station to construct object on. 
     * @throws java.rmi.RemoteException
     */
    public PrinterManagementImplProxy( StationAddress station )
        throws RemoteException
    {
        super( "com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl" );
        try
        {
            // make remote call
            remoteConstruct(
                station,
                "com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl",
                "<init>()Lcom.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl;",
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
        return "com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl";
    }
    
    // -------------------- Instance methods
    /**
     * Calls notify() on PrinterManagementImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#notify
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#notify 
     * @param theRemoteEvent0  
     * @throws java.rmi.RemoteException
     * @throws net.jini.core.event.UnknownEventException
     */
    public void notify( RemoteEvent theRemoteEvent0 )
        throws RemoteException, UnknownEventException
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
            // rethrow Errors as ServerError
            if ( t instanceof Error )
                throw new ServerError( "Error thrown from referent method", (Error) t );
            // rethrow other exceptions as UnexpectedException
            throw new UnexpectedException(
                "Proxy does not match referent class.  Unexpected declared exception thrown from referent method", (Exception) t );
        }
    }
    /**
     * Calls terminateScheduledTasks() on PrinterManagementImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#terminateScheduledTasks
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#terminateScheduledTasks 
     * @throws java.rmi.RemoteException
     */
    public void terminateScheduledTasks( )
        throws RemoteException
    {
        try
        {
            // make remote call
            remoteInstanceMethodCall(
                "terminateScheduledTasks()V",
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
     * Calls addPaper() on PrinterManagementImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#addPaper
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#addPaper 
     * @param theInt0  
     * @throws java.rmi.RemoteException
     */
    public void addPaper( int theInt0 )
        throws RemoteException
    {
        try
        {
            // make remote call
            remoteInstanceMethodCall(
                "addPaper(I)V",
                new Object[] { new Integer( theInt0 ) }
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
     * Calls isPrinting() on PrinterManagementImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#isPrinting
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#isPrinting 
     * @throws java.rmi.RemoteException
     */
    public boolean isPrinting( )
        throws RemoteException
    {
        try
        {
            // make remote call
            return ((Boolean) remoteInstanceMethodCall(
                "isPrinting()Z",
                new Object[] {  }
            ) ).booleanValue();
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
     * Calls isPaperJam() on PrinterManagementImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#isPaperJam
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#isPaperJam 
     * @throws java.rmi.RemoteException
     */
    public boolean isPaperJam( )
        throws RemoteException
    {
        try
        {
            // make remote call
            return ((Boolean) remoteInstanceMethodCall(
                "isPaperJam()Z",
                new Object[] {  }
            ) ).booleanValue();
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
     * Calls getPaperInTray() on PrinterManagementImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#getPaperInTray
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#getPaperInTray 
     * @throws java.rmi.RemoteException
     */
    public int getPaperInTray( )
        throws RemoteException
    {
        try
        {
            // make remote call
            return ((Integer) remoteInstanceMethodCall(
                "getPaperInTray()I",
                new Object[] {  }
            ) ).intValue();
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
     * Calls getPendingPrintJobs() on PrinterManagementImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#getPendingPrintJobs
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#getPendingPrintJobs 
     * @throws java.rmi.RemoteException
     */
    public String[] getPendingPrintJobs( )
        throws RemoteException
    {
        try
        {
            // make remote call
            return (String[])remoteInstanceMethodCall(
                "getPendingPrintJobs()[Ljava.lang.String;",
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
     * Calls isOnline() on PrinterManagementImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#isOnline
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#isOnline 
     * @throws java.rmi.RemoteException
     */
    public boolean isOnline( )
        throws RemoteException
    {
        try
        {
            // make remote call
            return ((Boolean) remoteInstanceMethodCall(
                "isOnline()Z",
                new Object[] {  }
            ) ).booleanValue();
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
     * Calls cancelPendingPrintJobs() on PrinterManagementImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#cancelPendingPrintJobs
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#cancelPendingPrintJobs 
     * @throws java.rmi.RemoteException
     */
    public void cancelPendingPrintJobs( )
        throws RemoteException
    {
        try
        {
            // make remote call
            remoteInstanceMethodCall(
                "cancelPendingPrintJobs()V",
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
     * Calls addToner() on PrinterManagementImpl object pointed to by this Proxy.
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#addToner
     * @see com.deitel.advjhtp1.jiro.DynamicService.service.PrinterManagementImpl#addToner 
     * @throws java.rmi.RemoteException
     */
    public void addToner( )
        throws RemoteException
    {
        try
        {
            // make remote call
            remoteInstanceMethodCall(
                "addToner()V",
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
    public static final String _codeGenerationVersion = "Sun Aug 06 09:21:42 EDT 2000";
    
} // end of PrinterManagementImplProxy

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
