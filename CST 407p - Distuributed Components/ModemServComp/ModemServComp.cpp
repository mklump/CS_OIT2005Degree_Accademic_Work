// ModemServComp.cpp : Implementation of DLL Exports.


// Note: Proxy/Stub Information
//      To build a separate proxy/stub DLL, 
//      run nmake -f ModemServCompps.mk in the project directory.

#include "stdafx.h"
#include "resource.h"
#include <initguid.h>
#include <assert.h>
#include "ModemServComp.h"

#include <queue>
#include <iostream>
using namespace std;

#include "ModemServComp_i.c"

CComModule _Module;

BEGIN_OBJECT_MAP(ObjectMap)
END_OBJECT_MAP()

#ifdef __cplusplus
extern "C"
{
#endif 

enum ERROR_CODES
{
    CST407_MODEM_FULL_QUEUE = 7,        // Queue is FULL error
    CST407_MODEM_EMPTY_QUEUE = 8,       // Queue is EMPTY error
    CST407_MODEM_UNKNOWN_ERROR = 9,     // Unknown INTERNAL error
    CST407_MODEM_CONNECT_ERROR = 10     // CONNECTION/INITIALIZATION error
};

// Modem flag
bool bConnected = false,
     bConnectCalled = false,
     bDisconnectCalled = false;

// Modem's data buffer
queue<int> *Queue;

// Modem's maximum data buffer size
#define MAX_SIZE 100

HRESULT
ICST407ModemIntf::Connect()
{
    if( bConnected || bConnectCalled )
    {
        cout << "Modem: Already connected.";
        return S_OK;
    }

    cout << "\nConnecting...";

    Queue = new queue<int>;
    if( !(Queue) )
        return CST407_MODEM_CONNECT_ERROR;
    else
    {
        cout << "\nConnected...";
        bConnected = true;
        bConnectCalled = true;
        bDisconnectCalled = false;
        return S_OK;
    }
}


HRESULT
ICST407ModemIntf::Disconnect()
{
    if( bDisconnectCalled )
    {
        cout << "\nModem: Already disconnected.";
        return S_OK;
    }

    bConnected = false;
    bConnectCalled = false;
    delete Queue;

    bDisconnectCalled = true;
    return S_OK;
}


HRESULT
ICST407ModemIntf::SendData( /*[ in, out ]*/ int *pNumDatums,
                            /*[ in, size_is( *pNumDatums ) ]*/ int data[] )
{
   if( !bConnected )
   {
       cout << "\nModem: Call Connect() first.";
       return E_FAIL;
   }

   // Begin inserting the data items into buffer as received
   for( int index = *pNumDatums - 1; index >= 0; --index )
        Queue->push( data[index] );

   int Size = sizeof( data ) / sizeof( data[0] );

   // Check to see if data sent excedes maximum size
   if( Size > MAX_SIZE )
       return CST407_MODEM_FULL_QUEUE;

   // Check to see if all data items were received
   if( *pNumDatums == Size )
       cout << "\nModem: All " << *pNumDatums << " data items were received.";
   else
       cout << "\nModem: Received all items except " <<  *pNumDatums + 1 << ".";

   cout << "Modem: Size of remaining send queue is " << MAX_SIZE - Queue->size() << " more entries.";
   delete data;
   return S_OK;
}


HRESULT
ICST407ModemIntf::RecvData( /*[ in, out ]*/ int *pNumDatums,
                            /*[ out, size_is( *pNumDatums ), length_is( *pNumDatums ) ]*/ int data[] )
{
    if( !bConnected )
    {
        cout << "\nModem: Call Connect() first.";
        return E_FAIL;
    }

    // Check to see if modem has any data
    if( Queue->empty() )
        return CST407_MODEM_EMPTY_QUEUE;
    else
    {   // Number of data items being returned
        *pNumDatums = Queue->size();
        cout << "\nModem: The Number of data items returned is " << *pNumDatums << ".";
    }
    
    // Begin removing the data for transmition back
    for( int index = *pNumDatums - 1; index >= 0; --index )
    {
        data[index] = Queue->back();
        Queue->pop();
    }

    // Number of remaining data items
    cout << "\nModem: The number of remaining data items waiting to be sent is " << Queue->size() << ".";
    return S_OK;
}

#ifdef __cplusplus
}
#endif

/////////////////////////////////////////////////////////////////////////////
// DLL Entry Point

extern "C"
BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID /*lpReserved*/)
{
    if (dwReason == DLL_PROCESS_ATTACH)
    {
        _Module.Init(ObjectMap, hInstance, &LIBID_MODEMSERVCOMPLib);
        DisableThreadLibraryCalls(hInstance);
    }
    else if (dwReason == DLL_PROCESS_DETACH)
        _Module.Term();
    return TRUE;    // ok
}

/////////////////////////////////////////////////////////////////////////////
// Used to determine whether the DLL can be unloaded by OLE

STDAPI DllCanUnloadNow(void)
{
    return (_Module.GetLockCount()==0) ? S_OK : S_FALSE;
}

/////////////////////////////////////////////////////////////////////////////
// Returns a class factory to create an object of the requested type

STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, LPVOID* ppv)
{
    return _Module.GetClassObject(rclsid, riid, ppv);
}

/////////////////////////////////////////////////////////////////////////////
// DllRegisterServer - Adds entries to the system registry

STDAPI DllRegisterServer(void)
{
    // registers object, typelib and all interfaces in typelib
    return _Module.RegisterServer(TRUE);
}

/////////////////////////////////////////////////////////////////////////////
// DllUnregisterServer - Removes entries from the system registry

STDAPI DllUnregisterServer(void)
{
    return _Module.UnregisterServer(TRUE);
}


