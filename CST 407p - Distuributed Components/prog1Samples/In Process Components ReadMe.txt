---------------------------------
In Process Components
---------------------------------
See Chapter 2 "IUnknown and IClassFactory"
for information on In Process Components



Minimum System Requirements
===========================
Windows 95 with DCOM installed or Windows NT 4.0
Visual C++ 5.0 Professional



In Process sample
  Self-Registering Component
  Client that uses CoCreateInstance
  Client that uses CoGetClassObject
  Client that uses TypeSaferQI
===================================
1.  Open "In Process.dsw" in Visual C++
2.  Build Client.exe
    (this also builds "Component with Registration.dll")
3.  Register "Component with Registration.dll"
4.  Run Client.exe to test use of CoCreateInstance
5.  Build "CoGetClassObject Client.exe"
6.  Run "CoGetClassObject Client.exe" to test use of
    CoGetClassObject
7.  Build TypeSaferQIClient.exe
8.  Run TypeSaferQIClient.exe to test use of TypeSaferQI


In Process sample
  Component that cannot Self-Register
  Client that uses CoCreateInstance
  Client that uses CoGetClassObject
  Client that uses TypeSaferQI
======================================
1.  Open "In Process.dsw" in Visual C++
2.  Build Component.dll
3.  Open Component.reg in a text editor such as Notepad and edit
    the InprocServer32 path to the location of Component.dll.
    Be sure to use double back slashes between "\\" directories.
4.  Once Component.reg is saved, in Windows Explorer double-click
    the Component.reg icon to regiser Component.dll.
    Note: If any of the directory names contain spaces and you are
    using Windows 95, you may receive an error about being unable
    to import file.  In this case, you can move Component.dll to a
    directory containing a path without spaces and reregister for
    this new path, or you can manually add the appropriate entries
    in the registry using the Registry Editor (regedit.exe).
5.  Use Registry Editor to ensure proper entries were made in the
    registry
6.  Build Client.exe
7.  Run Client.exe to test use of CoCreateInstance
8.  Build "CoGetClassObject Client.exe"
9.  Run "CoGetClassObject Client.exe" to test use of
    CoGetClassObject
10. Build TypeSaferQIClient.exe
11. Run TypeSaferQIClient.exe to test use of TypeSaferQI


TypeSaferQI macro
=================
See the "Another Good One to Tell Your Friends About" sidebar in
Chapter 2 "IUnknown and IClassFactory" pages 48-49 for more
information on the TypeSaferQI macro.



<end>