// HelloCliDlg.h : header file
//

#if !defined(AFX_HELLOCLIDLG_H__8495B5DE_67FF_11D4_A358_00104B732442__INCLUDED_)
#define AFX_HELLOCLIDLG_H__8495B5DE_67FF_11D4_A358_00104B732442__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CHelloCliDlg dialog

#define START		IDC_START_SERVER	// the Start Server button should be active
#define ADVISE		IDC_ADVISE_SERVER	// the Advise Server button should be active
#define CALL		IDC_CALL_METHOD	// the Call Method button should be active
#define UNADVISE	IDC_UNADVISE_SERVER	// the Unadvise Server button should be active
#define STOP		IDC_STOP_SERVER	// the Stop Server button should be active

#include "HelloWorldEvents.h"

class CHelloCliDlg : public CDialog
{
// Construction
public:
	CHelloCliDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CHelloCliDlg)
	enum { IDD = IDD_HELLOCLI_DIALOG };
	CButton	m_btnStop;
	CButton	m_btnUnadvise;
	CButton	m_btnCall;
	CButton	m_btnAdvise;
	CButton	m_btnStart;
	CString	m_strStatus;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CHelloCliDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	virtual void PostNcDestroy();
	//}}AFX_VIRTUAL

// Implementation
protected:
	BOOL UnadviseEventSink();
	BOOL AdviseEventSink();
	void DisableAll();
	void EnableControl(UINT nIDC, BOOL bEnable);
	void ActivateCurrentButton();
	void DoDialogInit();
	
	HICON	m_hIcon;
	int		m_nCurBtn;

	DWORD	m_dwCookie;	// Cookie for connection point
	BOOL	m_bSinkAdvised;	// Is the sink advised?

	IHelloWorldPtr*		m_pHelloWorld;
	IUnknown*			m_pHelloWorldEventsUnk;
	
	CHelloWorldEvents	m_events;

	// Generated message map functions
	//{{AFX_MSG(CHelloCliDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnStartServer();
	afx_msg void OnAdviseServer();
	afx_msg void OnCallMethod();
	afx_msg void OnUnadviseServer();
	afx_msg void OnStopServer();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_HELLOCLIDLG_H__8495B5DE_67FF_11D4_A358_00104B732442__INCLUDED_)
