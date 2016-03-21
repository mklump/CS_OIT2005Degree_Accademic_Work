// HelloWorldEvents.cpp : implementation file
//

#include "stdafx.h"
#include "HelloCli.h"
#include "HelloCliDlg.h"

#include "HelloWorldEvents.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CHelloWorldEvents

IMPLEMENT_DYNCREATE(CHelloWorldEvents, CCmdTarget)

CHelloWorldEvents::CHelloWorldEvents()
{
	EnableAutomation();
}

CHelloWorldEvents::~CHelloWorldEvents()
{
}


void CHelloWorldEvents::OnFinalRelease()
{
	// When the last reference for an automation object is released
	// OnFinalRelease is called.  The base class will automatically
	// deletes the object.  Add additional cleanup required for your
	// object before calling the base class.

	CCmdTarget::OnFinalRelease();
}


BEGIN_MESSAGE_MAP(CHelloWorldEvents, CCmdTarget)
	//{{AFX_MSG_MAP(CHelloWorldEvents)
		// NOTE - the ClassWizard will add and remove mapping macros here.
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

BEGIN_DISPATCH_MAP(CHelloWorldEvents, CCmdTarget)
	//{{AFX_DISPATCH_MAP(CHelloWorldEvents)
	DISP_FUNCTION(CHelloWorldEvents, "OnSayHello", OnSayHello, VT_EMPTY, VTS_BSTR)
	//}}AFX_DISPATCH_MAP
END_DISPATCH_MAP()

BEGIN_INTERFACE_MAP(CHelloWorldEvents, CCmdTarget)
	INTERFACE_PART(CHelloWorldEvents, DIID_DHelloWorldEvents, Dispatch)
END_INTERFACE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CHelloWorldEvents message handlers

void CHelloWorldEvents::OnSayHello(LPCTSTR lpszHost) 
{
	CHelloCliDlg* pDlg = (CHelloCliDlg*)AfxGetMainWnd();
	if (pDlg != NULL)
	{
		pDlg->m_strStatus += "The OnSayHello() connection point method has been called\r\n";
		pDlg->UpdateData(FALSE);
	}

	// Show a message box saying 'Hello, world, from host ' + lpszHost:
	CString strMessage = "Hello, world, from ";
	strMessage += lpszHost;

	AfxMessageBox(strMessage, MB_ICONINFORMATION);
}
