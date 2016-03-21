// HelloWorld.h : Declaration of the CHelloWorld

#ifndef __HELLOWORLD_H_
#define __HELLOWORLD_H_

#include "resource.h"       // main symbols
#include "HelloServCP.h"

/////////////////////////////////////////////////////////////////////////////
// CHelloWorld
class ATL_NO_VTABLE CHelloWorld : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CHelloWorld, &CLSID_HelloWorld>,
	public IConnectionPointContainerImpl<CHelloWorld>,
	public IHelloWorld,
	public CProxyDHelloWorldEvents< CHelloWorld >
{
public:
	CHelloWorld()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_HELLOWORLD)
DECLARE_NOT_AGGREGATABLE(CHelloWorld)

DECLARE_PROTECT_FINAL_CONSTRUCT()

BEGIN_COM_MAP(CHelloWorld)
	COM_INTERFACE_ENTRY(IHelloWorld)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
	COM_INTERFACE_ENTRY_IMPL(IConnectionPointContainer)
END_COM_MAP()
BEGIN_CONNECTION_POINT_MAP(CHelloWorld)
CONNECTION_POINT_ENTRY(DIID_DHelloWorldEvents)
END_CONNECTION_POINT_MAP()


// IHelloWorld
public:
	STDMETHOD(SayHello)();
};

#endif //__HELLOWORLD_H_
