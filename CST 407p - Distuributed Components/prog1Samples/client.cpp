// client.cpp
#include <iostream.h>
#include "Component with Registration\component.h" // Generated by MIDL

// {10000002-0000-0000-0000-000000000001}
const CLSID CLSID_CST407_Prog1 = 
{0x10000002,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01}};

void main()
{
	cout << "Client: Calling CoInitialize()" << endl;
	HRESULT hr = CoInitialize(NULL);
	if(FAILED(hr))
		cout << "CoInitialize failed" << endl;
	
	ISum* pSum;
	ISum2 *pSum2;

	cout << "Client: Calling CoCreateInstance()" << endl;
	hr = CoCreateInstance(
		CLSID_CST407_Prog1, 
		NULL, 
		CLSCTX_INPROC_SERVER, 
		IID_ISum, 
		(void**)&pSum
		);

	if(FAILED(hr))
	{
		cout << "CoCreateInstance failed" << endl;
		return ;
	}

	int sum;
	hr = pSum->Sum(2, 3, &sum);
	if(SUCCEEDED(hr))
		cout << "Client: Calling Sum(2, 3) = " << sum << endl;

	hr = pSum->Release();

	hr = CoCreateInstance(
		CLSID_CST407_Prog1, 
		NULL, 
		CLSCTX_INPROC_SERVER, 
		IID_ISum2, 
		(void**)&pSum2
		);

	int array[3] = { 2, 4, 8};

	int length = sizeof(array) / sizeof(int);

	hr = pSum2->MySum(length, &sum, array);

	cout << "from Sum2 : sum = " << sum << endl;

	pSum2->Release();

	CoUninitialize();
}