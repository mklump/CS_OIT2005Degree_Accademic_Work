
Public Class CallClassLibraries
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents cmdUseCSharp As System.Web.UI.WebControls.Button
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents cmdUseWS As System.Web.UI.WebControls.Button
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdUseVB As System.Web.UI.WebControls.Button
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label

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
        Dim x As New VBClassLibrary.Class1()
        Button1.Text = x.hello()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim x As New CSharpClassLibrary.Class1()
        Button2.Text = x.hello()
    End Sub

    Private Sub cmdUseVB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUseVB.Click
        Dim x As New VBClassLibrary.Class1()
        Dim sngShipping As Single
        sngShipping = x.ComputeShipping(TextBox1.Text)
        Label1.Text = CStr(sngShipping)
    End Sub

    Private Sub cmdUseCSharp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUseCSharp.Click
        Dim x As New CSharpClassLibrary.Class1()
        Dim sngShipping As Single
        sngShipping = x.ComputeShipping(TextBox1.Text)
        Label1.Text = CStr(sngShipping)
    End Sub

    Private Sub cmdUseWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUseWS.Click
        Dim service As New CallClassVB.shippingWebRef.Service1()
        Dim sngShipping As Single
        sngShipping = service.ComputeShipping(TextBox1.Text)
        Label1.Text = CStr(sngShipping)
    End Sub

End Class
