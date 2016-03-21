Public Class _default
    Inherits System.Web.UI.Page
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents cmdSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents chkListBenefits As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents lblSelections As System.Web.UI.WebControls.Label

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
        If Not Page.IsPostBack Then
            'read benefits list from component and fill in checkbox list
            Dim clBenefits As New BenefitsListVB.Benefits()
            Dim bi As BenefitsListVB.Benefits.BenefitInfo

            For Each bi In clBenefits.GetBenefitsList()
                chkListBenefits.Items.Add("<a href=" & bi.strPage & ">" & bi.strName & "</a>")
            Next
        End If
    End Sub

    Private Sub cmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        'output in a label the items that were selected
        Dim li As ListItem
        For Each li In chkListBenefits.Items
            If li.Selected Then
                lblSelections.Text &= (", " & li.Value)
            End If
        Next
    End Sub
End Class
