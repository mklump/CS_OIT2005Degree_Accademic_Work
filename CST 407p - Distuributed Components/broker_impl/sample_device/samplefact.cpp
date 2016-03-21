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

#include	<windows.h>
#include	"registry.h"

#include	"cst407_broker.h"

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

static CCST407Broker	g_BrokerIntfObj;

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

	if ( riid != IID_ICST407ModemIntf )
	{
		return	E_NOINTERFACE;
	}

	HRESULT	hr	=	g_BrokerIntfObj.QueryInterface(riid,ppv);
	//g_BrokerIntfObj.Release();

	return	hr;
}

HRESULT __stdcall DllRegisterServer()
{
	return RegisterServer("broker_impl.dll.dll", 
											CLSID_CST407BrokerComponent, 
											"CST407 Broker Interface Implementation", 
											"Component.CST407 Broker Interface", 
											"Component.CST407 Broker Interface.1", 
											NULL
											);
}

HRESULT __stdcall DllUnregisterServer()
{
	return UnregisterServer(
					CLSID_CST407BrokerComponent, 
					"Component.CST407 Broker Interface", 
					"Component.CST407 Broker Interface.1"
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

	if ( clsid != CLSID_CST407BrokerComponent )
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
		cout << argv[0] << " failed to initialize COM" << endl;
		return;
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
		cout << argv[0] << " failed to get broker interface" << endl;

		CoUninitialize();

		return;
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

}