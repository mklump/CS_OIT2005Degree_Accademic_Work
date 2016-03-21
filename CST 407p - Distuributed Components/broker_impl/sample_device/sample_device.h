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

#include "cst407_modem.h"
#include	<vector>
using	namespace std;

/*
*
* CLSID_CST407BrokerComponent.
*	Class id for the broker component.
*
*/
const	CLSID	CLSID_CST407SampleModem = 
{
	0x17fbe9ed, 0xf340, 0x4719, {0x98, 0xd9, 0xf5, 0x1e, 0x21, 0x42, 0x8d, 0xce}
};

/**** class CCST407Sample.
*	Implementation in C++ of the ICST407BrokerIntf
*	interface.
*
*/
class	CCST407Sample : public ICST407ModemIntf
{
private:
	/* m_cRef is the reference count */
	LONG	m_cRef;

	vector<GUID*>	m_device_guid_list;
public:

	CCST407Sample();
	~CCST407Sample();

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

    virtual HRESULT STDMETHODCALLTYPE Connect( void);
    
    virtual HRESULT STDMETHODCALLTYPE Disconnect( void);
    
    virtual HRESULT STDMETHODCALLTYPE SendData( 
        /* [out][in] */ int *pNumDatums,
        /* [size_is][in] */ int data[  ]);
    
    virtual HRESULT STDMETHODCALLTYPE RecvData( 
        /* [out][in] */ int *pNumDatums,
        /* [length_is][size_is][out] */ int data[  ]);

};

class	CSampleDeviceClassFactory : public IClassFactory
{
private:
	LONG	m_cRef;

public:
	CSampleDeviceClassFactory();
	~CSampleDeviceClassFactory();

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