Public MustInherit Class numberbox
    Inherits System.Web.UI.UserControl
    Protected WithEvents txtNum1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNumValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtNumRngValidator1 As System.Web.UI.WebControls.RangeValidator

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
    Public Property pNum() As Integer
        Get
            Return CInt(txtNum1.Text)
        End Get
        Set(ByVal Value As Integer)
            txtNum1.Text = Value.ToString()
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            txtNum1.Text = "0"
        End If

    End Sub

End Class
