/* this ALWAYS GENERATED file contains the definitions for the interfaces */


/* File created by MIDL compiler version 5.01.0164 */
/* at Fri Jan 24 16:57:46 2003
 */
/* Compiler settings for icalc.idl:
    Os (OptLev=s), W1, Zp8, env=Win32, ms_ext, c_ext
    error checks: allocation ref bounds_check enum stub_data 
*/
//@@MIDL_FILE_HEADING(  )


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 440
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __icalc_h__
#define __icalc_h__

#ifdef __cplusplus
extern "C"{
#endif 

/* Forward Declarations */ 

#ifndef __ICalc_FWD_DEFINED__
#define __ICalc_FWD_DEFINED__
typedef interface ICalc ICalc;
#endif 	/* __ICalc_FWD_DEFINED__ */


/* header files for imported files */
#include "unknwn.h"

void __RPC_FAR * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void __RPC_FAR * ); 

#ifndef __ICalc_INTERFACE_DEFINED__
#define __ICalc_INTERFACE_DEFINED__

/* interface ICalc */
/* [uuid][object] */ 


EXTERN_C const IID IID_ICalc;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("EB788015-5336-45ea-BA21-14EA359CDDD0")
    ICalc : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Sum( 
            /* [in] */ int x,
            /* [in] */ int y,
            /* [retval][out] */ int __RPC_FAR *retVal) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE Mult( 
            /* [in] */ int x,
            /* [in] */ int y,
            /* [retval][out] */ int __RPC_FAR *retval) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ICalcVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            ICalc __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            ICalc __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            ICalc __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Sum )( 
            ICalc __RPC_FAR * This,
            /* [in] */ int x,
            /* [in] */ int y,
            /* [retval][out] */ int __RPC_FAR *retVal);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Mult )( 
            ICalc __RPC_FAR * This,
            /* [in] */ int x,
            /* [in] */ int y,
            /* [retval][out] */ int __RPC_FAR *retval);
        
        END_INTERFACE
    } ICalcVtbl;

    interface ICalc
    {
        CONST_VTBL struct ICalcVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICalc_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ICalc_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ICalc_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ICalc_Sum(This,x,y,retVal)	\
    (This)->lpVtbl -> Sum(This,x,y,retVal)

#define ICalc_Mult(This,x,y,retval)	\
    (This)->lpVtbl -> Mult(This,x,y,retval)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE ICalc_Sum_Proxy( 
    ICalc __RPC_FAR * This,
    /* [in] */ int x,
    /* [in] */ int y,
    /* [retval][out] */ int __RPC_FAR *retVal);


void __RPC_STUB ICalc_Sum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE ICalc_Mult_Proxy( 
    ICalc __RPC_FAR * This,
    /* [in] */ int x,
    /* [in] */ int y,
    /* [retval][out] */ int __RPC_FAR *retval);


void __RPC_STUB ICalc_Mult_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ICalc_INTERFACE_DEFINED__ */


/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif
