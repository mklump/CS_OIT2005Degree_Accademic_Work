// Registry.h
// This function will register a component.
HRESULT RegisterServer(const char* szModuleName, REFCLSID clsid, const char* szFriendlyName, const char* szVerIndProgID, const char* szProgID, const char* szThreadingModel);

// This function will unregister a component.
HRESULT UnregisterServer(REFCLSID clsid, const char* szVerIndProgID, const char* szProgID);