#ifndef _server_h
#define _server_h

#ifdef __cplusplus
extern "C"
{
#endif

#ifdef DLLSERVER
_declspec(dllexport)
#else
_declspec(dllimport)
#endif

int add(int a, int b);

#ifdef DLLSERVER
_declspec(dllexport)
#else
_declspec(dllimport)
#endif

int sub(int a, int b);

} // __cplusplus
#endif // _server_h