/***** Class :- cst407
*	Winter 2003.
*	Implementation of the cst407 Broker interface.
*	This interface allows for a peaceful negotiation
*	between clients and devices. 
*
*	This is a DCOM compliant interface.
*
*	See http://capital.ous.edu/~rksaripa/cst407dcom.
*	for more information.
*
*/


#ifndef	_cst407brokerimpl_h
#define	_cst407brokerimpl_h

#include "cst407_broker.h"
#include	<vector>
using	namespace std;
/*
*
* CLSID_CST407BrokerComponent.
*	Class id for the broker component.
*
*/
const	CLSID	CLSID_CST407BrokerComponent =
{
	0x2b36cecb, 0x4280, 0x4b4e, {0xb9, 0xb, 0x9e, 0xb6, 0xeb, 0x13, 0xfc, 0xde} 
};

/**** class CCST407Broker.
*	Implementation in C++ of the ICST407BrokerIntf
*	interface.
*
*/
class	CCST407Broker : public ICST407BrokerIntf
{
private:
	/* m_cRef is the reference count */
	LONG	m_cRef;

	vector<GUID*>	m_device_guid_list;
public:

	CCST407Broker();
	~CCST407Broker();

	/* implementation of the IUnknown interface
	*
	*/

	ULONG	__stdcall	AddRef();
	ULONG	__stdcall	Release();
	HRESULT	__stdcall	QueryInterface(
					REFIID	riid,
					void	**ppv
					);

	/* implementation of the ICST407BrokerIntf
	*	interface.
	*
	*/

    HRESULT STDMETHODCALLTYPE RegisterDeviceComponent( 
        /* [in] */ int guid_array[ 4 ]) ;
    
    HRESULT STDMETHODCALLTYPE UnregisterDeviceComponent( 
        /* [in] */ int guid_array[ 4 ]) ;
    
    HRESULT STDMETHODCALLTYPE GetDeviceComponentList( 
        /* [in] */ int maxGuids,
        /* [out] */ int *pActualGuids,
        /* [size_is][length_is][out] */ int guid_array[  ]) ;
};

class	CCST407ClassFactory : public IClassFactory
{
private:
	LONG	m_cRef;

public:
	CCST407ClassFactory();
	~CCST407ClassFactory();

	/* implementation of the IUnknown interface
	*
	*/

	ULONG	__stdcall	AddRef();
	ULONG	__stdcall	Release();
	HRESULT	__stdcall	QueryInterface(
					REFIID	riid,
					void	**ppv
					);

	/* implementation of the IClassFactory interface.
	*
	*/

	HRESULT	__stdcall	CreateInstance(
					IUnknown *pUnkOuter,
					REFIID	riid,
					void	**ppv
					);

	HRESULT	__stdcall	LockServer(
		BOOL	bLock);
};

#endif