Public Class retirement
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtVisits As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgRetirement As System.Web.UI.WebControls.DataGrid

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
        If Not Page.IsPostBack Then
            'TODO Lab 12: Create a dataset, fill it out with the
            'XML file, and display it
            Dim dsRetirement As New DataSet()
            dsRetirement.ReadXml( _
                Server.MapPath("mutual_funds.xml"))
            dgRetirement.DataSource = dsRetirement
            dgRetirement.DataBind()

            Application.Lock()
            Application("Visits") = CInt(Application("Visits")) + 1
            Application.UnLock()
        End If

        txtVisits.Text = CStr(Application("Visits"))

    End Sub

End Class
