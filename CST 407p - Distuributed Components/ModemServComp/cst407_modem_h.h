
#pragma warning( disable: 4049 )  /* more than 64k source lines */

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0342 */
/* at Thu Mar 06 08:27:58 2003
 */
/* Compiler settings for cst407_modem.idl:
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

#ifndef __cst407_modem_h_h__
#define __cst407_modem_h_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __ICST407ModemIntf_FWD_DEFINED__
#define __ICST407ModemIntf_FWD_DEFINED__
typedef interface ICST407ModemIntf ICST407ModemIntf;
#endif 	/* __ICST407ModemIntf_FWD_DEFINED__ */


/* header files for imported files */
#include "unknwn.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __ICST407ModemIntf_INTERFACE_DEFINED__
#define __ICST407ModemIntf_INTERFACE_DEFINED__

/* interface ICST407ModemIntf */
/* [uuid][object] */ 


EXTERN_C const IID IID_ICST407ModemIntf;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("7828E364-C822-4b1e-BFB4-7943804848CB")
    ICST407ModemIntf : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Connect( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE Disconnect( void) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE SendData( 
            /* [out][in] */ int *pNumDatums,
            /* [size_is][in] */ int data[  ]) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE RecvData( 
            /* [out][in] */ int *pNumDatums,
            /* [length_is][size_is][out] */ int data[  ]) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ICST407ModemIntfVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            ICST407ModemIntf * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            ICST407ModemIntf * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            ICST407ModemIntf * This);
        
        HRESULT ( STDMETHODCALLTYPE *Connect )( 
            ICST407ModemIntf * This);
        
        HRESULT ( STDMETHODCALLTYPE *Disconnect )( 
            ICST407ModemIntf * This);
        
        HRESULT ( STDMETHODCALLTYPE *SendData )( 
            ICST407ModemIntf * This,
            /* [out][in] */ int *pNumDatums,
            /* [size_is][in] */ int data[  ]);
        
        HRESULT ( STDMETHODCALLTYPE *RecvData )( 
            ICST407ModemIntf * This,
            /* [out][in] */ int *pNumDatums,
            /* [length_is][size_is][out] */ int data[  ]);
        
        END_INTERFACE
    } ICST407ModemIntfVtbl;

    interface ICST407ModemIntf
    {
        CONST_VTBL struct ICST407ModemIntfVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define ICST407ModemIntf_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define ICST407ModemIntf_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define ICST407ModemIntf_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define ICST407ModemIntf_Connect(This)	\
    (This)->lpVtbl -> Connect(This)

#define ICST407ModemIntf_Disconnect(This)	\
    (This)->lpVtbl -> Disconnect(This)

#define ICST407ModemIntf_SendData(This,pNumDatums,data)	\
    (This)->lpVtbl -> SendData(This,pNumDatums,data)

#define ICST407ModemIntf_RecvData(This,pNumDatums,data)	\
    (This)->lpVtbl -> RecvData(This,pNumDatums,data)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE ICST407ModemIntf_Connect_Proxy( 
    ICST407ModemIntf * This);


void __RPC_STUB ICST407ModemIntf_Connect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE ICST407ModemIntf_Disconnect_Proxy( 
    ICST407ModemIntf * This);


void __RPC_STUB ICST407ModemIntf_Disconnect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE ICST407ModemIntf_SendData_Proxy( 
    ICST407ModemIntf * This,
    /* [out][in] */ int *pNumDatums,
    /* [size_is][in] */ int data[  ]);


void __RPC_STUB ICST407ModemIntf_SendData_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE ICST407ModemIntf_RecvData_Proxy( 
    ICST407ModemIntf * This,
    /* [out][in] */ int *pNumDatums,
    /* [length_is][size_is][out] */ int data[  ]);


void __RPC_STUB ICST407ModemIntf_RecvData_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __ICST407ModemIntf_INTERFACE_DEFINED__ */


/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


