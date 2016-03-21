Public Class beforeuser
    Inherits System.Web.UI.Page
    Protected WithEvents txtNum1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNumValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtNumRngValidator1 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents txtNum2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNumValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtNumRngValidator2 As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents lblSum As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'check Page.IsValid'
        If Page.IsValid Then
            lblSum.Text = CStr(Convert.ToInt32(txtNum1.Text) + Convert.ToInt32(txtNum2.Text))
        End If

    End Sub
End Class
