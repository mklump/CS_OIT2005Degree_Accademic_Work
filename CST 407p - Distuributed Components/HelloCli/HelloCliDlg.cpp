// HelloCliDlg.cpp : implementation file
//

#include "stdafx.h"

#include "HelloCli.h"
#include "HelloCliDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CHelloCliDlg dialog

CHelloCliDlg::CHelloCliDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CHelloCliDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CHelloCliDlg)
	m_strStatus = _T("");
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

	m_dwCookie = 0;
	m_pHelloWorldEventsUnk = m_events.GetIDispatch(FALSE);
	m_bSinkAdvised = FALSE;
}

void CHelloCliDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CHelloCliDlg)
	DDX_Control(pDX, IDC_STOP_SERVER, m_btnStop);
	DDX_Control(pDX, IDC_UNADVISE_SERVER, m_btnUnadvise);
	DDX_Control(pDX, IDC_CALL_METHOD, m_btnCall);
	DDX_Control(pDX, IDC_ADVISE_SERVER, m_btnAdvise);
	DDX_Control(pDX, IDC_START_SERVER, m_btnStart);
	DDX_Text(pDX, IDC_STATUS, m_strStatus);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CHelloCliDlg, CDialog)
	//{{AFX_MSG_MAP(CHelloCliDlg)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_START_SERVER, OnStartServer)
	ON_BN_CLICKED(IDC_ADVISE_SERVER, OnAdviseServer)
	ON_BN_CLICKED(IDC_CALL_METHOD, OnCallMethod)
	ON_BN_CLICKED(IDC_UNADVISE_SERVER, OnUnadviseServer)
	ON_BN_CLICKED(IDC_STOP_SERVER, OnStopServer)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CHelloCliDlg message handlers

BOOL CHelloCliDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	DoDialogInit();

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CHelloCliDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CHelloCliDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CHelloCliDlg::DoDialogInit()
{
	// Set icons for the buttons and enable the Start Server button
	m_btnStart.SetIcon(AfxGetApp()->LoadIcon(IDR_MAINFRAME1));
	m_btnAdvise.SetIcon(AfxGetApp()->LoadIcon(IDR_MAINFRAME2));
	m_btnCall.SetIcon(AfxGetApp()->LoadIcon(IDR_MAINFRAME));
	m_btnUnadvise.SetIcon(AfxGetApp()->LoadIcon(IDR_MAINFRAME2));
	m_btnStop.SetIcon(AfxGetApp()->LoadIcon(IDR_MAINFRAME1));
	
	m_nCurBtn = START;

	ActivateCurrentButton();

	// Initialize COM and security settings
	CoInitialize(NULL);

	CoInitializeSecurity(NULL, -1, NULL, NULL, RPC_C_AUTHN_LEVEL_NONE,
		RPC_C_IMP_LEVEL_IMPERSONATE, NULL, EOAC_NONE, NULL);
}

void CHelloCliDlg::DisableAll()
{
	EnableControl(IDC_START_SERVER, FALSE);
	EnableControl(IDC_ADVISE_SERVER, FALSE);
	EnableControl(IDC_CALL_METHOD, FALSE);
	EnableControl(IDC_UNADVISE_SERVER, FALSE);
	EnableControl(IDC_STOP_SERVER, FALSE);
}

void CHelloCliDlg::EnableControl(UINT nIDC, BOOL bEnable)
{
	// Enable or disable the button with the specified ID
	CButton* pBtn = (CButton*)GetDlgItem(nIDC);
	if (pBtn == NULL)
		return;

	pBtn->EnableWindow(bEnable);
}

void CHelloCliDlg::ActivateCurrentButton()
{
	if (m_nCurBtn != START)
		EnableControl(START, FALSE);
	else
		EnableControl(m_nCurBtn, TRUE);

	if (m_nCurBtn != ADVISE)
		EnableControl(ADVISE, FALSE);
	else
		EnableControl(m_nCurBtn, TRUE);

	if (m_nCurBtn != CALL)
		EnableControl(CALL, FALSE);
	else
		EnableControl(m_nCurBtn, TRUE);

	if (m_nCurBtn != UNADVISE)
		EnableControl(UNADVISE, FALSE);
	else
		EnableControl(m_nCurBtn, TRUE);

	if (m_nCurBtn != STOP)
		EnableControl(STOP, FALSE);
	else
		EnableControl(m_nCurBtn, TRUE);
}

void CHelloCliDlg::OnStartServer() 
{
	COSERVERINFO serverInfo;
	ZeroMemory(&serverInfo, sizeof(COSERVERINFO));

	COAUTHINFO athn;
	ZeroMemory(&athn, sizeof(COAUTHINFO));

	// Set up the NULL security information
	athn.dwAuthnLevel = RPC_C_AUTHN_LEVEL_NONE;
	athn.dwAuthnSvc = RPC_C_AUTHN_WINNT;
	athn.dwAuthzSvc = RPC_C_AUTHZ_NONE;
	athn.dwCapabilities = EOAC_NONE;
	athn.dwImpersonationLevel = RPC_C_IMP_LEVEL_IMPERSONATE;
	athn.pAuthIdentityData = NULL;
	athn.pwszServerPrincName = NULL;

	serverInfo.pwszName = L"\\\\MattsNotebook"; // Need to escape both slashes, equivalent to \\MattsNotebook
	serverInfo.pAuthInfo = &athn;
	serverInfo.dwReserved1 = 0;
	serverInfo.dwReserved2 = 0;

	MULTI_QI qi = {&IID_IHelloWorld, NULL, S_OK};

	m_strStatus += "Starting server...\r\n";
	UpdateData(FALSE);

	try
	{
		m_pHelloWorld = new IHelloWorldPtr;
	}
	catch(...)
	{
		AfxMessageBox(AFX_IDP_FAILED_MEMORY_ALLOC, MB_ICONSTOP);

		m_strStatus += "Insufficient memory for a new IHelloWorldPtr\r\n";
		UpdateData(FALSE);

		m_nCurBtn = 0;
		ActivateCurrentButton(); // with m_nCurBtn set to 0, this will disable them all

		return;
	}

	// Create the server locally
	/*HRESULT hResult = m_pHelloWorld->CreateInstance(CLSID_HelloWorld);*/

	HRESULT hResult = CoCreateInstanceEx(CLSID_HelloWorld, NULL,
		CLSCTX_LOCAL_SERVER | CLSCTX_REMOTE_SERVER, &serverInfo, 1, &qi);

	if (FAILED(hResult))
	{
		_com_error err(hResult);
		
		CString strMessage = "Unable to access IHelloWorld because ";
		strMessage += err.ErrorMessage();

		AfxMessageBox(strMessage, MB_ICONSTOP);
		m_strStatus += strMessage + "\r\n";
		UpdateData(FALSE);

		delete m_pHelloWorld;
		m_pHelloWorld = NULL;

		return;
	}

	m_pHelloWorld->Attach((IHelloWorld*)qi.pItf);

	m_strStatus += "Calling QueryInterface() to get IUnknown\r\n";
	UpdateData(FALSE);

	m_nCurBtn = ADVISE;
	ActivateCurrentButton();

	m_btnAdvise.SetFocus();
}

void CHelloCliDlg::OnAdviseServer() 
{
	CWaitCursor wait;

	m_strStatus += "Calling AfxConnectionAdvise() to advise the event sink...\r\n";
	UpdateData(FALSE);

	// Advise the connection point
	BOOL bResult = AdviseEventSink();

	if (!bResult)
	{
		CString strMessage = "Unable to call AfxConnectionAdvise() because an error";
		strMessage += " occurred.";

		AfxMessageBox(strMessage, MB_ICONSTOP);

		m_strStatus += strMessage + "\r\n";
		UpdateData(FALSE);

		delete m_pHelloWorld;
		m_pHelloWorld = NULL;

		m_nCurBtn = 0;
		ActivateCurrentButton();

		return;
	}

	AfxMessageBox("AfxConnectionAdvise has been called successfully.",
		MB_ICONINFORMATION|MB_OK);	

	m_strStatus += "AfxConnectionAdvise has been called successfully.\r\n";
	UpdateData(FALSE);

	m_bSinkAdvised = TRUE;

	m_nCurBtn = CALL;
	ActivateCurrentButton();

	m_btnCall.SetFocus();
}

void CHelloCliDlg::OnCallMethod() 
{
	m_strStatus += "Calling IHelloWorld::SayHello...\r\n";
	UpdateData(FALSE);

	(*m_pHelloWorld)->SayHello();

	m_strStatus += "IHelloWorld::SayHello called.\r\n";
	UpdateData(FALSE);

	m_nCurBtn = UNADVISE;
	ActivateCurrentButton();

	m_btnUnadvise.SetFocus();
}

void CHelloCliDlg::OnUnadviseServer() 
{
	m_strStatus += "Unadvising the server...\r\n";
	UpdateData(FALSE);

	// Unadvise the event sink
	if (!UnadviseEventSink())
	{
		AfxMessageBox("An error occurred unadvising the server.",
			MB_ICONSTOP|MB_OK);

		delete m_pHelloWorld;
		m_pHelloWorld = NULL;

		return;
	}

	AfxMessageBox("Server successfully unadvised.",
		MB_ICONINFORMATION);

	m_strStatus += "Server successfully unadvised.\r\n";
	UpdateData(FALSE);

	m_nCurBtn = STOP;
	ActivateCurrentButton();

	m_btnStop.SetFocus();
}

void CHelloCliDlg::OnStopServer() 
{
	delete m_pHelloWorld;
	m_pHelloWorld = NULL;

	AfxMessageBox("Server released.", MB_ICONINFORMATION);

	m_strStatus += "Server released.\r\n";
	UpdateData(FALSE);
}

void CHelloCliDlg::PostNcDestroy() 
{
	CDialog::PostNcDestroy();
}

BOOL CHelloCliDlg::AdviseEventSink()
{
	if (m_bSinkAdvised)
		return TRUE;

	IUnknown* pUnk = NULL;
	CComPtr<IUnknown> spUnk = (*m_pHelloWorld);
	pUnk = spUnk.p;

	// Advise the connection point
	BOOL bResult = AfxConnectionAdvise(pUnk, DIID_DHelloWorldEvents, 
		m_pHelloWorldEventsUnk, TRUE, &m_dwCookie);

	return bResult;
}

BOOL CHelloCliDlg::UnadviseEventSink()
{
	if (!m_bSinkAdvised)
		return TRUE;

	// Get the IHelloWorld IUnknown pointer using a smart pointer.
	// The smart pointer calls QueryInterface() for us.
	IUnknown* pUnk = NULL;	
	
	CComPtr<IUnknown> spUnk = (*m_pHelloWorld);
	pUnk = spUnk.p;

	if (spUnk.p)
	{
		// Unadvise the connection with the event sink
		return AfxConnectionUnadvise(pUnk, DIID_DHelloWorldEvents,
			m_pHelloWorldEventsUnk, TRUE, m_dwCookie);
	}

	return FALSE;
}
