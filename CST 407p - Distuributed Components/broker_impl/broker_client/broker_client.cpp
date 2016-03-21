/***** Class :- cst407
*	Winter 2003.
*	Implementation of the cst407 Broker interface.
*	This client accesses the broker interface to
*	discover all registered devices.
*
*	This is a DCOM compliant interface.
*
*	See http://capital.ous.edu/~rksaripa/cst407dcom.
*	for more information.
*   start /wait nmake -f sample_deviceps.mk
*   regsvr32 Debug\sample_device.dll
*
*/

#include	<iostream.h>
#include	<windows.h>
#include	"cst407_broker.h"

const	CLSID	CLSID_CST407BrokerComponent =
{
	0x2b36cecb, 0x4280, 0x4b4e, {0xb9, 0xb, 0x9e, 0xb6, 0xeb, 0x13, 0xfc, 0xde} 
};

void main(int argc, char *argv[])
{
	ICST407BrokerIntf	*pBroker;

	HRESULT	hr	=CoInitialize(NULL);

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

	const	int	max_guids = 10;
	int	guid_array_length = max_guids;
	int	act_guids = 5;
	int	guid_array[ max_guids*4 ];

	hr	=	pBroker->GetDeviceComponentList(
					guid_array_length,
					&act_guids,
					guid_array
					);

	if ( FAILED(hr) )
	{
		cout << argv[0] << " method to get guid array failed" << endl;
		CoUninitialize();

		return;
	}

	cout << "number of guids requested= " <<
		guid_array_length << " number of guids received = " << 
		act_guids  << endl;

	pBroker->Release();

	CoUninitialize();
}
