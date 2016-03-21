#include <iostream.h>
#define DLLSERVER
#include "server.h"


/* export a function call Add and Sub out of the DLL */

extern "C"
_declspec(dllexport)
int
add(int a, int b)
{
	cout << "In add" << endl;
	return a + b;
}

extern "C"
_declspec(dllexport)
int
sub(int a, int b)
{
	cout << "In sub" << endl;
	return a - b;
}