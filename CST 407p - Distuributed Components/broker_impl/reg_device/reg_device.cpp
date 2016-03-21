#include <windows.h>
#include	<iostream.h>

int main(int argc, char *argv[])
{
	HMODULE	hDll;

	typedef	int	(*pfnRegisterEntryPoint)();
	pfnRegisterEntryPoint	pfnRegdll;
	if ( argc == 1 )
	{
		cout << argv[0] << " dll to register" << endl;
		return -1;
	}

	cout << "loading dll = " << argv[1] << endl;

	hDll = LoadLibrary(argv[1]);
	if ( NULL == hDll )
	{
		cout << "loading dll = " << argv[1] << " failed" << endl;
		return -2;
	}

	pfnRegdll = 
		(pfnRegisterEntryPoint)GetProcAddress(hDll, "RegisterClassId");

	if ( NULL == pfnRegdll )
	{
		cout << "dll loaded but cannot get entry point" << endl;
		return	-3;
	}

	cout << "return value from registration = " << pfnRegdll() << endl;

	FreeLibrary(hDll);

	return 0;
}