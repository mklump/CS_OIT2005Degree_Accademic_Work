Public Class prospectus
    Inherits System.Web.UI.Page
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents xmlProspectus As System.Web.UI.WebControls.Xml

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
        'TODO Lab 12: Dynamically select the prospectus
        Dim strProspID As String = Request.Params("ProspID")
        xmlProspectus.DocumentSource = strProspID & ".xml"
    End Sub

End Class
