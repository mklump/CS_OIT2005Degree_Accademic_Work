#include <windows.h>
#include "icalc.h"
#include <stdio.h>

long g_ServerLocks = 0;
long g_Components = 0;

static const GUID CLSID_ICalc = 
{ 0xd58cf70d, 0x7363, 0x49c9, { 0xaa, 0x6e, 0x7f, 0x30, 0xb6, 0x69, 0x1f, 0x5b } };

class CCalc: public ICalc
{
public:
	ULONG __stdcall AddRef();
	ULONG __stdcall Release();
	HRESULT __stdcall QueryInterface( REFIID iid, void **ppv );

	HRESULT STDMETHODCALLTYPE Sum(int x, int y, int *retval);
	HRESULT STDMETHODCALLTYPE Mult(int x, int y, int *retval);

	CCalc();
	~CCalc() { g_Components--; }

private:
	LONG m_cRef;
};

CCalc::CCalc()
{
	m_cRef = 0;
	AddRef();
	g_Components++;
}

ULONG CCalc::AddRef()
{
	InterlockedIncrement(&m_cRef);

	return m_cRef;
}

ULONG CCalc::Release()
{
	ULONG temp;

	temp = InterlockedDecrement(&m_cRef);

	if ( 0 == temp )
	{
		printf("deleting the object[0x%x]\n", this);
		delete this;
	}

	return temp;
}

HRESULT CCalc::Sum(int x, int y, int *retval)
{
	*retval = x + y;
	return S_OK;
}

HRESULT CCalc::Mult(int x, int y, int *retval)
{
	*retval = x * y;
	return S_OK;
}

HRESULT CCalc::QueryInterface(REFIID riid, void **ppv)
{
	if ( riid == IID_IUnknown )
		*ppv = (IUnknown *) this;
	else if ( riid == IID_ICalc )
		*ppv = (ICalc *) this;
	else
	{
		*ppv = NULL;
		return E_NOINTERFACE;
	}

	AddRef();

	return S_OK;
}

class CCalcFactory : public IClassFactory
{
private:
	LONG m_cRef;
public:
	ULONG __stdcall AddRef() { InterlockedIncrement(&m_cRef); return m_cRef; }
	ULONG __stdcall Release() { 
		ULONG temp; 
		temp = InterlockedDecrement(&m_cRef); 
		if ( 0 == temp ) delete this; 
		return temp; 
	}

	HRESULT __stdcall QueryInterface(REFIID riid, void **ppv);

	HRESULT __stdcall CreateInstance(IUnknown *pOuter, REFIID riid, void **ppv);

	HRESULT __stdcall LockServer(BOOL bLock);

	CCalcFactory() : m_cRef(1) { }
	~CCalcFactory() { }
};

HRESULT CCalcFactory::QueryInterface(REFIID riid , void **ppv)
{
	if ( riid == IID_IUnknown || riid == IID_IClassFactory )
		*ppv = (IClassFactory *) this;
	else
	{
		*ppv = NULL;
		return E_NOINTERFACE;
	}

	AddRef();
	return S_OK;
}

HRESULT CCalcFactory::CreateInstance(IUnknown *p, REFIID riid, void **ppv)
{
	if ( p )
		return CLASS_E_NOAGGREGATION;

	CCalc *myCalc = new CCalc;
	if ( NULL == myCalc )
		return E_OUTOFMEMORY;

	HRESULT hr = myCalc->QueryInterface(riid, ppv);

	myCalc->Release();
	return hr;
}

HRESULT CCalcFactory::LockServer(BOOL bLock)
{
	if ( bLock )
		g_ServerLocks++;
	else
		g_ServerLocks--;

	return S_OK;
}

extern "C" 
HRESULT
__stdcall
DllCanUnloadNow(void)
{
	if ( g_ServerLocks == 0 && g_Components == 0 )
		return S_OK;
	else
		return S_FALSE;
}


STDAPI
DllGetClassObject(REFCLSID clsid, REFIID riid, void **ppv)
{
	printf("[ dllgetclassobject\n");

	if ( clsid != CLSID_ICalc)
		return CLASS_E_CLASSNOTAVAILABLE;

	CCalcFactory *pFactory = new CCalcFactory;

	if ( NULL == pFactory )
		return E_OUTOFMEMORY;

	HRESULT hr = pFactory->QueryInterface(riid, ppv);
	pFactory->Release();
	return hr;
}