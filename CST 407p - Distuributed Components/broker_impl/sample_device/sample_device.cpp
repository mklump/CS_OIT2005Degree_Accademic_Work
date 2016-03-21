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

#include <iostream>


#include	<windows.h>
#include	<vector>
using	namespace std;

#include "sample_device.h"
#include	"registry.h"

#include	"cst407_broker.h"



CCST407Sample::CCST407Sample()
{
	cout << 
		"<==CCST407Sample::CCST407Sample" 
		<< endl;

	m_cRef = 1;
}

CCST407Sample::~CCST407Sample()
{
	cout << "CCST407Sample::~CCST407Sample. ref count="
		<< m_cRef << " " << endl;
}

ULONG
CCST407Sample::AddRef()
{
	InterlockedIncrement(&m_cRef);

	return	m_cRef;
}

ULONG
CCST407Sample::Release()
{
	ULONG	temp	=	m_cRef;

	InterlockedDecrement(&m_cRef);

	if ( 0 == m_cRef )
	{
	}

	return	temp;
}

HRESULT
CCST407Sample::QueryInterface(
							  REFIID	riid,
							  void	**ppv
							  )
{
	if ( IID_IUnknown == riid )
	{
		cout << "CCST407Sample::QueryInterface" 
			<< "query for IUnknown interface"
			<< endl;
		
		*ppv = static_cast<IUnknown *>(this);
	}
	else if ( IID_ICST407ModemIntf == riid )
	{
		cout << "CCST407Sample::QueryInterface" 
			<< "query for modem interface"
			<< endl;

		*ppv = static_cast<ICST407ModemIntf*>(this);
	}
	else
	{
		*ppv = NULL;
		return	E_NOINTERFACE;
	}

	AddRef();
	return	S_OK;
}

HRESULT STDMETHODCALLTYPE 
CCST407Sample::Connect( void)
{
	cout << "CCST407Sample::Connect" << endl;
	return	S_OK;
}

HRESULT STDMETHODCALLTYPE 
CCST407Sample::Disconnect( void)
{
	cout << "CCST407Sample::DisConnect" << endl;
	return S_OK;
}

HRESULT STDMETHODCALLTYPE 
CCST407Sample::SendData( 
    /* [out][in] */ int *pNumDatums,
    /* [size_is][in] */ int data[  ])
{
	cout << "CCST407Sample::SendData sending = "
		<< *pNumDatums << endl;

	return	S_OK;
}

HRESULT STDMETHODCALLTYPE 
CCST407Sample::RecvData( 
    /* [out][in] */ int *pNumDatums,
    /* [length_is][size_is][out] */ int data[  ])
{
	cout << "CCST407Sample::RecvData" <<
		" receiving = " << endl;

	data[0] = data[1] = 0;

	return	S_OK;
}

long	g_cComponents = 0;
long	g_cServerLocks = 0;
HANDLE	g_hEvent;

CSampleDeviceClassFactory::CSampleDeviceClassFactory()
{
	cout << "CSampleDeviceClassFactory::CSampleDeviceClassFactory"
		<< endl;

	m_cRef = 1;
}

CSampleDeviceClassFactory::~CSampleDeviceClassFactory()
{
	cout << "CSampleDeviceClassFactory::~CSampleDeviceClassFactory()"
		<< endl;
}

ULONG
CSampleDeviceClassFactory::AddRef()
{
	InterlockedIncrement(&m_cRef);

	return	m_cRef;
}

ULONG
CSampleDeviceClassFactory::Release()
{
	ULONG	temp	=	m_cRef;

	InterlockedDecrement(&m_cRef);

	if ( 0 == m_cRef )
	{
	}

	return	temp;
}

HRESULT
CSampleDeviceClassFactory::QueryInterface(
							  REFIID	riid,
							  void	**ppv
							  )
{
	if ( IID_IUnknown == riid )
	{
		cout << "CSampleDeviceClassFactory::QueryInterface" 
			<< "query for IUnknown interface"
			<< endl;
		
		*ppv = static_cast<IUnknown *>(this);
	}
	else if ( IID_IClassFactory == riid )
	{
		cout << "CSampleDeviceClassFactory::QueryInterface" 
			<< "query for class factory interface"
			<< endl;

		*ppv = static_cast<IClassFactory*>(this);
	}
	else
	{
		*ppv = NULL;
		return	E_NOINTERFACE;
	}

	AddRef();
	return	S_OK;
}

HRESULT
CSampleDeviceClassFactory::LockServer(BOOL	bLock)
{
	if ( bLock )
		g_cServerLocks++;
	else
		g_cServerLocks--;

	return	S_OK;
}

static CCST407Sample	g_SampleDevice;

HRESULT
CSampleDeviceClassFactory::CreateInstance(
								IUnknown	*pUnkOuter,
								REFIID			riid,
								void			**ppv
								)
{
	if ( pUnkOuter != NULL )
	{
		return	CLASS_E_NOAGGREGATION;
	}

	HRESULT	hr	=	g_SampleDevice.QueryInterface(riid,ppv);
	//g_BrokerIntfObj.Release();

	return	hr;
}

HRESULT __stdcall DllRegisterServer()
{
	return RegisterServer("sample_device.dll", 
											CLSID_CST407SampleModem, 
											"CST407 Sample modem Implementation", 
											"Component.CST407 RK Modem Interface", 
											"Component.CST407 Modem Interface.1", 
											NULL
											);
}

HRESULT __stdcall DllUnregisterServer()
{
	return UnregisterServer(
					CLSID_CST407SampleModem, 
											"Component.CST407 RK Modem Interface", 
											"Component.CST407 Modem Interface.1"
					);
}

HRESULT
__stdcall
DllCanUnloadNow()
{
	if ( g_cServerLocks == 0 && g_cComponents == 0 )
	{
		return	S_OK;
	}
	else
	{
		return	S_FALSE;
	}
}

CSampleDeviceClassFactory	g_ClassFactory;

HRESULT
__stdcall
DllGetClassObject(
				  REFCLSID	clsid,
				  REFIID		riid,
				  void			**ppv
				  )
{
	cout << "DllGetClassObject" << endl;


	if ( clsid != CLSID_CST407SampleModem )
	{
		return	CLASS_E_CLASSNOTAVAILABLE;
	}

	HRESULT hr = 
		g_ClassFactory.QueryInterface(
			riid, ppv
		);

	g_ClassFactory.Release();

	return	hr;
}

extern "C"
int
RegisterClassId()
{
	const	CLSID	CLSID_CST407BrokerComponent =
	{
		0x2b36cecb, 0x4280, 0x4b4e, {0xb9, 0xb, 0x9e, 0xb6, 0xeb, 0x13, 0xfc, 0xde} 
	};

	ICST407BrokerIntf	*pBroker;

	HRESULT	hr	= CoInitialize(NULL);

	if ( FAILED(hr) )
	{
		cout <<  " failed to initialize COM" << endl;
		return 1;
	}

	hr = 
		CoCreateInstance(
					CLSID_CST407BrokerComponent ,
					NULL,
					CLSCTX_INPROC_SERVER,
					IID_ICST407BrokerIntf,
					(void **)&pBroker
					);

	if ( FAILED(hr) )
	{
		cout << " failed to get broker interface" << endl;

		CoUninitialize();

		return 1;
	}

	int	device_guid[4];

	memcpy(
		device_guid,
		&CLSID_CST407SampleModem,
		sizeof(GUID)
		);

	pBroker->RegisterDeviceComponent(
		device_guid
		);

	pBroker->Release();

	CoUninitialize();

	return 0;
}