#include <iostream.h>
#include "icalc.h"

static const GUID CLSID_ICalc = 
{ 0xd58cf70d, 0x7363, 0x49c9, { 0xaa, 0x6e, 0x7f, 0x30, 0xb6, 0x69, 0x1f, 0x5b } };

void main()
{
	IUnknown *pUnk;
	ICalc *pCalc;

	HRESULT hr = CoInitialize(NULL);

	if ( FAILED(hr) )
	{
		return ;
	}

	hr = CoCreateInstance(CLSID_ICalc, NULL, CLSCTX_INPROC_SERVER, IID_IUnknown, (void **)&pUnk);
	if ( FAILED(hr) )
	{
		return;
	}

	hr = pUnk->QueryInterface(IID_ICalc, (void **)&pCalc);
	if ( FAILED(hr) )
	{
		pUnk->Release();
		return;
	}

	pUnk->Release();

	int sum;

	hr = pCalc->Sum(2,3,&sum);

	pCalc->Release();

	CoUninitialize();
}