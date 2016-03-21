// HelloCli.h : main header file for the HELLOCLI application
//

#if !defined(AFX_HELLOCLI_H__8495B5DC_67FF_11D4_A358_00104B732442__INCLUDED_)
#define AFX_HELLOCLI_H__8495B5DC_67FF_11D4_A358_00104B732442__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CHelloCliApp:
// See HelloCli.cpp for the implementation of this class
//

class CHelloCliApp : public CWinApp
{
public:
	CHelloCliApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CHelloCliApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CHelloCliApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_HELLOCLI_H__8495B5DC_67FF_11D4_A358_00104B732442__INCLUDED_)
