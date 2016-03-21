Public Class results
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtHits As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblTime As System.Web.UI.WebControls.Label
    Protected WithEvents lblWelcome As System.Web.UI.WebControls.Label

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not (Page.IsPostBack) Then
            Application.Lock()
            Application("NumberofVisitors") = _
                Application("NumberofVisitors") + 1
            Application.UnLock()
        End If

        Dim objCookie As HttpCookie = Request.Cookies("nameCookie")
        Dim strName As String = objCookie.Values("name")
        Dim strColor As String = (Session("Color"))

        lblWelcome.Text = "Welcome " + strName + "!" & _
            "  Your favorite color is: " + strColor

        lblTime.Text = lblTime.Text + (objCookie.Values("Time"))

        txtHits.Text = (Application("NumberofVisitors"))

    End Sub

End Class
