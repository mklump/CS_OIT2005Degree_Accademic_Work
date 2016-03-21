'Imports statment used for forms-based authentication
Imports System.Web.Security

Public Class signout
    Inherits System.Web.UI.Page
    Protected WithEvents cmdSignout As System.Web.UI.WebControls.Button

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

    End Sub

    Private Sub cmdSignout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSignout.Click
        'TODO Lab 16: Implement the signout
    End Sub
End Class
