#if !defined(AFX_HELLOWORLDEVENTS_H__8495B5E7_67FF_11D4_A358_00104B732442__INCLUDED_)
#define AFX_HELLOWORLDEVENTS_H__8495B5E7_67FF_11D4_A358_00104B732442__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
// HelloWorldEvents.h : header file
//



/////////////////////////////////////////////////////////////////////////////
// CHelloWorldEvents command target

class CHelloWorldEvents : public CCmdTarget
{
	friend class CHelloCliDlg;

	DECLARE_DYNCREATE(CHelloWorldEvents)

	CHelloWorldEvents();           // protected constructor used by dynamic creation

// Attributes
public:

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CHelloWorldEvents)
	public:
	virtual void OnFinalRelease();
	//}}AFX_VIRTUAL

// Implementation
protected:
	virtual ~CHelloWorldEvents();

	// Generated message map functions
	//{{AFX_MSG(CHelloWorldEvents)
		// NOTE - the ClassWizard will add and remove member functions here.
	//}}AFX_MSG

	DECLARE_MESSAGE_MAP()
	// Generated OLE dispatch map functions
	//{{AFX_DISPATCH(CHelloWorldEvents)
	afx_msg void OnSayHello(LPCTSTR lpszHost);
	//}}AFX_DISPATCH
	DECLARE_DISPATCH_MAP()
	DECLARE_INTERFACE_MAP()
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_HELLOWORLDEVENTS_H__8495B5E7_67FF_11D4_A358_00104B732442__INCLUDED_)
