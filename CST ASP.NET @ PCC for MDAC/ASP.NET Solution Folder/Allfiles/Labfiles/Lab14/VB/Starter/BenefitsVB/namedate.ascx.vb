Public MustInherit Class namedate
    Inherits System.Web.UI.UserControl
    Protected WithEvents vldBirthType As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents vldBirth As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtBirth As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents vldName As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label

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
    End Sub

    Public Property strName() As String
        Get
            Return txtName.Text
        End Get
        Set(ByVal Value As String)
            txtName.Text = Value
        End Set
    End Property

    Public Property dtDate() As Date
        Get
            Return CDate(txtBirth.Text)
        End Get
        Set(ByVal Value As Date)
            txtBirth.Text = Value.ToString()
        End Set
    End Property
End Class
