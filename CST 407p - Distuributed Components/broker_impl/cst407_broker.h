
#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0342 */
/* at Fri Mar 07 21:05:45 2003
 */
/* Compiler settings for .\cst407_broker.idl:
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

#ifndef __cst407_broker_h__
#define __cst407_broker_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __ICST407BrokerIntf_FWD_DEFINED__
#define __ICST407BrokerIntf_FWD_DEFINED__
typedef interface ICST407BrokerIntf ICST407BrokerIntf;
#endif 	/* __ICST407BrokerIntf_FWD_DEFINED__ */


/* header files for imported files */
#include "unknwn.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __ICST407BrokerIntf_INTERFACE_DEFINED__
#define __ICST407BrokerIntf_INTERFACE_DEFINED__

/* interface ICST407BrokerIntf */
/* [uuid][object] */ 


EXTERN_C const IID IID_ICST407BrokerIntf;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("88C5CFAC-7F0A-418c-AED1-57C6774C6749")
    ICST407BrokerIntf : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE RegisterDeviceComponent( 
            /* [in] */ int guid_array[ 4 ]) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE UnregisterDeviceComponent( 
            /* [in] */ int guid_array[ 4 ]) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE GetDeviceComponentList( 
            /* [in] */ int maxGuids,
            /* [out] */ int *pActualGuids,
            /* [size_is][length_is][out] */ int guid_array[  ]) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ICST407BrokerIntfVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICST407BrokerIntf * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICST407BrokerIntf * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICST407BrokerIntf * This);
        
        HRESULT ( STDMETHODCALLTYPE *RegisterDeviceComponent )( 
            ICST407BrokerIntf * This,
            /* [in] */ int guid_array[ 4 ]);
        
        HRESULT ( STDMETHODCALLTYPE *UnregisterDeviceComponent )( 
            ICST407BrokerIntf * This,
            /* [in] */ int guid_array[ 4 ]);
        
        HRESULT ( STDMETHODCALLTYPE *GetDeviceComponentList )( 
            ICST407BrokerIntf * This,
            /* [in] */ int maxGuids,
            /* [out] */ int *pActualGuids,
            /* [size_is][length_is][out] */ int guid_array[  ]);
        
        END_INTERFACE
    } ICST407BrokerIntfVtbl;

    interface ICST407BrokerIntf
    {
        CONST_VTBL struct ICST407BrokerIntfVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICST407BrokerIntf_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ICST407BrokerIntf_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ICST407BrokerIntf_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ICST407BrokerIntf_RegisterDeviceComponent(This,guid_array)	\
    (This)->lpVtbl -> RegisterDeviceComponent(This,guid_array)

#define ICST407BrokerIntf_UnregisterDeviceComponent(This,guid_array)	\
    (This)->lpVtbl -> UnregisterDeviceComponent(This,guid_array)

#define ICST407BrokerIntf_GetDeviceComponentList(This,maxGuids,pActualGuids,guid_array)	\
    (This)->lpVtbl -> GetDeviceComponentList(This,maxGuids,pActualGuids,guid_array)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE ICST407BrokerIntf_RegisterDeviceComponent_Proxy( 
    ICST407BrokerIntf * This,
    /* [in] */ int guid_array[ 4 ]);


void __RPC_STUB ICST407BrokerIntf_RegisterDeviceComponent_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE ICST407BrokerIntf_UnregisterDeviceComponent_Proxy( 
    ICST407BrokerIntf * This,
    /* [in] */ int guid_array[ 4 ]);


void __RPC_STUB ICST407BrokerIntf_UnregisterDeviceComponent_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE ICST407BrokerIntf_GetDeviceComponentList_Proxy( 
    ICST407BrokerIntf * This,
    /* [in] */ int maxGuids,
    /* [out] */ int *pActualGuids,
    /* [size_is][length_is][out] */ int guid_array[  ]);


void __RPC_STUB ICST407BrokerIntf_GetDeviceComponentList_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ICST407BrokerIntf_INTERFACE_DEFINED__ */


/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


