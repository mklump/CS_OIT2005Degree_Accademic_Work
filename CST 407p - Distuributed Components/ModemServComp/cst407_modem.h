/* this ALWAYS GENERATED file contains the definitions for the interfaces */


/* File created by MIDL compiler version 5.01.0164 */
/* at Thu Mar 20 13:32:21 2003
 */
/* Compiler settings for D:\Accademic_Work\CST 407p - Distuributed Components\ModemServComp\cst407_modem.idl:
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

#ifndef __cst407_modem_h__
#define __cst407_modem_h__

#ifdef __cplusplus
extern "C"{
#endif 

/* Forward Declarations */ 

#ifndef __ICST407ModemIntf_FWD_DEFINED__
#define __ICST407ModemIntf_FWD_DEFINED__
typedef interface ICST407ModemIntf ICST407ModemIntf;
#endif 	/* __ICST407ModemIntf_FWD_DEFINED__ */


/* header files for imported files */
#include "unknwn.h"

void __RPC_FAR * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void __RPC_FAR * ); 

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
            /* [out][in] */ int __RPC_FAR *pNumDatums,
            /* [size_is][in] */ int __RPC_FAR data[  ]) = 0;
        
        virtual HRESULT STDMETHODCALLTYPE RecvData( 
            /* [out][in] */ int __RPC_FAR *pNumDatums,
            /* [length_is][size_is][out] */ int __RPC_FAR data[  ]) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct ICST407ModemIntfVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            ICST407ModemIntf __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            ICST407ModemIntf __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            ICST407ModemIntf __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Connect )( 
            ICST407ModemIntf __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Disconnect )( 
            ICST407ModemIntf __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SendData )( 
            ICST407ModemIntf __RPC_FAR * This,
            /* [out][in] */ int __RPC_FAR *pNumDatums,
            /* [size_is][in] */ int __RPC_FAR data[  ]);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *RecvData )( 
            ICST407ModemIntf __RPC_FAR * This,
            /* [out][in] */ int __RPC_FAR *pNumDatums,
            /* [length_is][size_is][out] */ int __RPC_FAR data[  ]);
        
        END_INTERFACE
    } ICST407ModemIntfVtbl;

    interface ICST407ModemIntf
    {
        CONST_VTBL struct ICST407ModemIntfVtbl __RPC_FAR *lpVtbl;
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
    ICST407ModemIntf __RPC_FAR * This);


void __RPC_STUB ICST407ModemIntf_Connect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE ICST407ModemIntf_Disconnect_Proxy( 
    ICST407ModemIntf __RPC_FAR * This);


void __RPC_STUB ICST407ModemIntf_Disconnect_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE ICST407ModemIntf_SendData_Proxy( 
    ICST407ModemIntf __RPC_FAR * This,
    /* [out][in] */ int __RPC_FAR *pNumDatums,
    /* [size_is][in] */ int __RPC_FAR data[  ]);


void __RPC_STUB ICST407ModemIntf_SendData_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


HRESULT STDMETHODCALLTYPE ICST407ModemIntf_RecvData_Proxy( 
    ICST407ModemIntf __RPC_FAR * This,
    /* [out][in] */ int __RPC_FAR *pNumDatums,
    /* [length_is][size_is][out] */ int __RPC_FAR data[  ]);


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
