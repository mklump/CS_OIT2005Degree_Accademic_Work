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

#include	<iostream>
#include	<windows.h>
#include	"cst407brokerimpl.h"
#include	"cst407_helper.h"
#include	"registry.h"

long	g_cComponents = 0;
long	g_cServerLocks = 0;
HANDLE	g_hEvent;

CCST407ClassFactory::CCST407ClassFactory()
{
	cout << "CCST407ClassFactory::CCST407ClassFactory"
		<< endl;

	m_cRef = 1;
}

CCST407ClassFactory::~CCST407ClassFactory()
{
	cout << "CCST407ClassFactory::~CCST407ClassFactory()"
		<< endl;
}

ULONG
CCST407ClassFactory::AddRef()
{
	InterlockedIncrement(&m_cRef);

	return	m_cRef;
}

ULONG
CCST407ClassFactory::Release()
{
	ULONG	temp	=	m_cRef;

	InterlockedDecrement(&m_cRef);

	if ( 0 == m_cRef )
	{
	}

	return	temp;
}

HRESULT
CCST407ClassFactory::QueryInterface(
							  REFIID	riid,
							  void	**ppv
							  )
{
	if ( IID_IUnknown == riid )
	{
		cout << "CCST407ClassFactory::QueryInterface" 
			<< "query for IUnknown interface"
			<< endl;
		
		*ppv = static_cast<IUnknown *>(this);
	}
	else if ( IID_IClassFactory == riid )
	{
		cout << "CCST407ClassFactory::QueryInterface" 
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
CCST407ClassFactory::LockServer(BOOL	bLock)
{
	if ( bLock )
		g_cServerLocks++;
	else
		g_cServerLocks--;

	return	S_OK;
}

static CCST407Broker	g_BrokerIntfObj;

HRESULT
CCST407ClassFactory::CreateInstance(
								IUnknown	*pUnkOuter,
								REFIID			riid,
								void			**ppv
								)
{
	if ( pUnkOuter != NULL )
	{
		return	CLASS_E_NOAGGREGATION;
	}

	HRESULT	hr	=	g_BrokerIntfObj.QueryInterface(riid,ppv);
	//g_BrokerIntfObj.Release();

	return	hr;
}

HRESULT __stdcall DllRegisterServer()
{
	return RegisterServer("broker_impl.dll", 
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

CCST407ClassFactory	g_ClassFactory;

HRESULT
__stdcall
DllGetClassObject(
				  REFCLSID	clsid,
				  REFIID		riid,
				  void			**ppv
				  )
{
	cout << "DllGetClassObject" << endl;

	_display_guid(cout, clsid) << "Class id " << endl;

	_display_guid(cout, riid) << "interface id" << endl;

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