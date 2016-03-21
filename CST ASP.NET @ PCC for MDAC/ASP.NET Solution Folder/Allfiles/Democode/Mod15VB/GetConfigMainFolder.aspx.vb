Public Class GetConfigMainFolder
    Inherits System.Web.UI.Page
    Protected WithEvents label1 As System.Web.UI.WebControls.Label
    Protected WithEvents cmdNext As System.Web.UI.WebControls.Button

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
        Dim strValue As String

        strValue = ConfigurationSettings.AppSettings("mySetting")
        label1.Text = strValue

    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        Response.Redirect(".\SubFolder\GetConfigSubFolder.aspx")

    End Sub
End Class
