# Microsoft Developer Studio Project File - Name="demo1" - Package Owner=<4>
# Microsoft Developer Studio Generated Build File, Format Version 6.00
# ** DO NOT EDIT **

# TARGTYPE "Win32 (x86) Console Application" 0x0103

CFG=demo1 - Win32 Debug
!MESSAGE This is not a valid makefile. To build this project using NMAKE,
!MESSAGE use the Export Makefile command and run
!MESSAGE 
!MESSAGE NMAKE /f "demo1.mak".
!MESSAGE 
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "demo1.mak" CFG="demo1 - Win32 Debug"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "demo1 - Win32 Release" (based on "Win32 (x86) Console Application")
!MESSAGE "demo1 - Win32 Debug" (based on "Win32 (x86) Console Application")
!MESSAGE 

# Begin Project
# PROP AllowPerConfigDependencies 0
# PROP Scc_ProjName ""
# PROP Scc_LocalPath ""
CPP=cl.exe
RSC=rc.exe

!IF  "$(CFG)" == "demo1 - Win32 Release"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 0
# PROP BASE Output_Dir "Release"
# PROP BASE Intermediate_Dir "Release"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 0
# PROP Output_Dir "Release"
# PROP Intermediate_Dir "Release"
# PROP Target_Dir ""
# ADD BASE CPP /nologo /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_CONSOLE" /D "_MBCS" /YX /FD /c
# ADD CPP /nologo /W3 /GX /O2 /D "WIN32" /D "NDEBUG" /D "_CONSOLE" /D "_MBCS" /YX /FD /c
# ADD BASE RSC /l 0x409 /d "NDEBUG"
# ADD RSC /l 0x409 /d "NDEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib  kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:console /machine:I386
# ADD LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib  kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:console /machine:I386

!ELSEIF  "$(CFG)" == "demo1 - Win32 Debug"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 1
# PROP BASE Output_Dir "Debug"
# PROP BASE Intermediate_Dir "Debug"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 1
# PROP Output_Dir "Debug"
# PROP Intermediate_Dir "Debug"
# PROP Target_Dir ""
# ADD BASE CPP /nologo /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_CONSOLE" /D "_MBCS" /YX /FD /GZ  /c
# ADD CPP /nologo /W3 /Gm /GX /ZI /Od /D "WIN32" /D "_DEBUG" /D "_CONSOLE" /D "_MBCS" /YX /FD /GZ  /c
# ADD BASE RSC /l 0x409 /d "_DEBUG"
# ADD RSC /l 0x409 /d "_DEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib  kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:console /debug /machine:I386 /pdbtype:sept
# ADD LINK32 kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib  kernel32.lib user32.lib gdi32.lib winspool.lib comdlg32.lib advapi32.lib shell32.lib ole32.lib oleaut32.lib uuid.lib odbc32.lib odbccp32.lib /nologo /subsystem:console /debug /machine:I386 /pdbtype:sept

!ENDIF 

# Begin Target

# Name "demo1 - Win32 Release"
# Name "demo1 - Win32 Debug"
# Begin Group "Source Files"

# PROP Default_Filter "cpp;c;cxx;rc;def;r;odl;idl;hpj;bat"
# Begin Source File

SOURCE=..\..\Week6\Examples\Stl1\stdafx.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\Stl2\stdafx.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\Stl3\stdafx.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL4DequePontoon\stdafx.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL5PhoneBook\stdafx.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL6Stack\stdafx.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL7Queue\stdafx.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL8PriorityQueue\stdafx.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\Stl1\STL1.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\Stl2\STL2.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\Stl3\STL3.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL4DequePontoon\STL4DequePontoon.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL5PhoneBook\STL5.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL6Stack\STL6.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL7Queue\STL7.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL8PriorityQueue\STL8PriorityQueue.cpp
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL4DequePontoon\STLDequeBlackjack.cpp
# End Source File
# End Group
# Begin Group "Header Files"

# PROP Default_Filter "h;hpp;hxx;hm;inl"
# Begin Source File

SOURCE=..\..\Week6\Examples\Stl1\stdafx.h
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\Stl2\stdafx.h
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\Stl3\stdafx.h
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL4DequePontoon\stdafx.h
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL5PhoneBook\stdafx.h
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL6Stack\stdafx.h
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL7Queue\stdafx.h
# End Source File
# Begin Source File

SOURCE=..\..\Week6\Examples\STL8PriorityQueue\stdafx.h
# End Source File
# End Group
# Begin Group "Resource Files"

# PROP Default_Filter "ico;cur;bmp;dlg;rc2;rct;bin;rgs;gif;jpg;jpeg;jpe"
# End Group
# End Target
# End Project
