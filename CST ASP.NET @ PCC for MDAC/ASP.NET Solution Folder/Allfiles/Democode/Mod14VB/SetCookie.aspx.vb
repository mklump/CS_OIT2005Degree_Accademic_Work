Public Class SetCookie
    Inherits System.Web.UI.Page
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink

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

        ' Create a new cookie object 
        Dim objCookie As New HttpCookie("Course2310")

        ' Get the current time
        Dim now As DateTime = DateTime.Now

        ' Set some pairs key/values
        objCookie.Values.Add("Time", now.ToString())
        objCookie.Values.Add("ForeColor", "White")
        objCookie.Values.Add("BackColor", "Blue")

        ' Set the expiration of the cookie
        ' objCookie.Expires = now.AddHours(1)

        Response.Cookies.Add(objCookie)

    End Sub

End Class
