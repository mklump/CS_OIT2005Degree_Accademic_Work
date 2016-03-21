#include <iostream.h>
#include <windows.h>
#include "server.h"

void main()
{
	int val;

	typedef int (*pfnAdd_t)(int a, int b);

	pfnAdd_t pfnAdd;

	HMODULE hDll;

	hDll = LoadLibrary("server.dll");

	pfnAdd = (pfnAdd)GetProcAddress(hDll, "add");

	val = (pfnAdd)(5 , 6);

	CloseHandle( hDll );

	cout << "value = " << val << endl;
}