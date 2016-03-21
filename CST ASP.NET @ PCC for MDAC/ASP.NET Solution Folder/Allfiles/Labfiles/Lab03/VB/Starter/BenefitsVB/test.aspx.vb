Public Class test
    Inherits System.Web.UI.Page

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
        Dim clBenefits As New BenefitsListVB.Benefits()
        Dim bi As BenefitsListVB.Benefits.BenefitInfo

        Response.Write("<table border=1><tr><td>Benefit Name</td><td>Web Page</td></tr>")
        For Each bi In clBenefits.GetBenefitsList()
            Response.Write("<tr><td>" & bi.strName & "</td><td>" & bi.strPage & "</td></tr>")
        Next
        Response.Write("</table>")
    End Sub

End Class
