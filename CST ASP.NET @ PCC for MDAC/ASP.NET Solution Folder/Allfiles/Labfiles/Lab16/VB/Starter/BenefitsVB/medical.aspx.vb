Public Class medical
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtDoctor As System.Web.UI.WebControls.TextBox
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents cmdSave As System.Web.UI.WebControls.Button
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected Namedate1 As BenefitsVB.namedate

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
        If Not Page.IsPostBack Then
            'if doctor has been selected already, display here
            If Request.QueryString("pcp") <> "" Then
                txtDoctor.Text = Request.QueryString("pcp")
            End If
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Label2.Text = Namedate1.strName & ", born on " & Namedate1.dtDate.ToString()

        Dim objCookie As HttpCookie = Request.Cookies("Benefits")
        Dim strDoc As String
        Dim strLife As String

        If Not objCookie Is Nothing Then
            strDoc = objCookie.Values("doctor")
            strLife = objCookie.Values("life")
        End If

        strDoc = txtDoctor.Text
        Dim objNewCookie As New HttpCookie("Benefits")
        objNewCookie.Expires = DateTime.Now.AddDays(30)
        objNewCookie.Values.Add("doctor", strDoc)
        objNewCookie.Values.Add("life", strLife)
        Response.Cookies.Add(objNewCookie)
        Response.Redirect("default.aspx")
    End Sub
End Class
