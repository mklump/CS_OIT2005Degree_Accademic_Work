; CLW file contains information for the MFC ClassWizard

[General Info]
Version=1
LastClass=CHelloWorldEvents
LastTemplate=CCmdTarget
NewFileInclude1=#include "stdafx.h"
NewFileInclude2=#include "hellocli.h"
LastPage=0

ClassCount=3
Class1=CHelloCliApp
Class2=CHelloCliDlg

ResourceCount=1
Class3=CHelloWorldEvents
Resource1=IDD_HELLOCLI_DIALOG

[CLS:CHelloCliApp]
Type=0
BaseClass=CWinApp
HeaderFile=HelloCli.h
ImplementationFile=HelloCli.cpp
LastObject=CHelloCliApp

[CLS:CHelloCliDlg]
Type=0
BaseClass=CDialog
HeaderFile=HelloCliDlg.h
ImplementationFile=HelloCliDlg.cpp

[DLG:IDD_HELLOCLI_DIALOG]
Type=1
Class=CHelloCliDlg
ControlCount=13
Control1=IDC_STATIC,static,1342308353
Control2=IDC_START_SERVER,button,1342242880
Control3=IDC_STATIC,static,1342308353
Control4=IDC_ADVISE_SERVER,button,1342242880
Control5=IDC_STATIC,static,1342308353
Control6=IDC_CALL_METHOD,button,1342242880
Control7=IDC_STATIC,static,1342308353
Control8=IDC_UNADVISE_SERVER,button,1342242880
Control9=IDC_STATIC,static,1342308353
Control10=IDC_STOP_SERVER,button,1342242880
Control11=IDC_STATIC,static,1342308352
Control12=IDC_STATUS,edit,1353779268
Control13=IDOK,button,1342242817

[CLS:CHelloWorldEvents]
Type=0
HeaderFile=HelloWorldEvents.h
ImplementationFile=HelloWorldEvents.cpp
BaseClass=CCmdTarget
Filter=N
LastObject=CHelloWorldEvents
VirtualFilter=C

