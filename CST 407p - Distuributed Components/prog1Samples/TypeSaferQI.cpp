// client.cpp

#define TypeSaferQI(ppObject) QueryInterface(__uuidof(*ppObject), (void**)ppObject)

#define _WIN32_DCOM
#include <iostream.h>
#include <stdio.h>
#include "Component with Registration\component.h"

// {10000002-0000-0000-0000-000000000001}
const CLSID CLSID_InsideDCOM = {0x10000002,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01}};

void main()
{
	cout << "Client: Calling CoInitialize()" << endl;
	CoInitialize(NULL);
		
	IUnknown* pUnknown;
	ISum* pSum;

	cout << "Client: Calling CoCreateInstance() " << endl;
	CoCreateInstance(CLSID_InsideDCOM, NULL, CLSCTX_INPROC_SERVER, IID_IUnknown, (void**)&pUnknown);

	cout << "Client: Calling QueryInterface() for ISum on " << pUnknown << endl;
//	HRESULT hr = pUnknown->QueryInterface(IID_ISum, (void**)&pSum);
	HRESULT hr = pUnknown->TypeSaferQI(&pSum);

	if(FAILED(hr))
		cout << "QueryInterface FAILED" << endl;

	cout << "Client: Calling Release() for pUnknown" << endl;
	hr = pUnknown->Release();

	cout << "Client: pSum = " << pSum << endl;

	int sum;
	hr = pSum->Sum(123, 43, &sum);
	if(SUCCEEDED(hr))
		cout << "Client: Calling Sum() return value is " << sum << endl;

	cout << "Client: Calling Release() for pSum" << endl;
	hr = pSum->Release();

	cout << "Client: Calling CoUninitialize()" << endl;
	CoUninitialize();
}