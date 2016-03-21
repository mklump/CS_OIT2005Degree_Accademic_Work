
#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0342 */
/* at Fri Feb 21 15:32:54 2003
 */
/* Compiler settings for ..\component.idl:
    Os, W1, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
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

#ifndef __component_h__
#define __component_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __ISum_FWD_DEFINED__
#define __ISum_FWD_DEFINED__
typedef interface ISum ISum;
#endif 	/* __ISum_FWD_DEFINED__ */


#ifndef __ISum2_FWD_DEFINED__
#define __ISum2_FWD_DEFINED__
typedef interface ISum2 ISum2;
#endif 	/* __ISum2_FWD_DEFINED__ */


/* header files for imported files */
#include "unknwn.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __ISum_INTERFACE_DEFINED__
#define __ISum_INTERFACE_DEFINED__

/* interface ISum */
/* [uuid][object] */ 


EXTERN_C const IID IID_ISum;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("10000001-0000-0000-0000-000000000001")
    ISum : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Sum( 
            /* [in] */ int x,
            /* [in] */ int y,
            /* [retval][out] */ int *retval) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISumVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISum * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISum * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISum * This);
        
        HRESULT ( STDMETHODCALLTYPE *Sum )( 
            ISum * This,
            /* [in] */ int x,
            /* [in] */ int y,
            /* [retval][out] */ int *retval);
        
        END_INTERFACE
    } ISumVtbl;

    interface ISum
    {
        CONST_VTBL struct ISumVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISum_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISum_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISum_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISum_Sum(This,x,y,retval)	\
    (This)->lpVtbl -> Sum(This,x,y,retval)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE ISum_Sum_Proxy( 
    ISum * This,
    /* [in] */ int x,
    /* [in] */ int y,
    /* [retval][out] */ int *retval);


void __RPC_STUB ISum_Sum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISum_INTERFACE_DEFINED__ */


#ifndef __ISum2_INTERFACE_DEFINED__
#define __ISum2_INTERFACE_DEFINED__

/* interface ISum2 */
/* [uuid][object] */ 


EXTERN_C const IID IID_ISum2;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("DD625AA7-E568-4db6-8874-E735F8D29B0A")
    ISum2 : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE MySum( 
            /* [in] */ int length,
            /* [out] */ int *retval,
            /* [size_is][in] */ int intArray[  ]) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ISum2Vtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ISum2 * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ISum2 * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ISum2 * This);
        
        HRESULT ( STDMETHODCALLTYPE *MySum )( 
            ISum2 * This,
            /* [in] */ int length,
            /* [out] */ int *retval,
            /* [size_is][in] */ int intArray[  ]);
        
        END_INTERFACE
    } ISum2Vtbl;

    interface ISum2
    {
        CONST_VTBL struct ISum2Vtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ISum2_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ISum2_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ISum2_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ISum2_MySum(This,length,retval,intArray)	\
    (This)->lpVtbl -> MySum(This,length,retval,intArray)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE ISum2_MySum_Proxy( 
    ISum2 * This,
    /* [in] */ int length,
    /* [out] */ int *retval,
    /* [size_is][in] */ int intArray[  ]);


void __RPC_STUB ISum2_MySum_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ISum2_INTERFACE_DEFINED__ */


/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


