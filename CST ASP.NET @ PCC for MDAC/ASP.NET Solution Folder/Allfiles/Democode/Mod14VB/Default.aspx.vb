Public Class default1
    Inherits System.Web.UI.Page
    Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents lstColor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
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

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        'Response.Write(Application("NumberofVisitors"))
        Session("Color") = lstColor.SelectedItem.Text
        'Response.Write(Session("Color"))

        Dim objCookie As New HttpCookie("nameCookie")
        Dim time As DateTime = DateTime.Now
        objCookie.Values.Add("Name", txtName.Text)
        objCookie.Values.Add("Time", time.ToString())
        objCookie.Expires = time.AddDays(5)

        Response.Cookies.Add(objCookie)
        Response.Redirect("results.aspx")

    End Sub
End Class
