// HelloWorld.cpp : Implementation of CHelloWorld
#include "stdafx.h"
#include "HelloServ.h"
#include "HelloWorld.h"

/////////////////////////////////////////////////////////////////////////////
// CHelloWorld

STDMETHODIMP CHelloWorld::SayHello()
{
    USES_CONVERSION;

    // Get the network name of this computer
    TCHAR szComputerName[MAX_COMPUTERNAME_LENGTH + 1];
    DWORD dwSize = MAX_COMPUTERNAME_LENGTH + 1;

    if (!GetComputerName(szComputerName, &dwSize))
        return E_FAIL;    // failed to get the name of this computer

    // Say Hello to the client
    Fire_OnSayHello(T2OLE(szComputerName));

    return S_OK;
}