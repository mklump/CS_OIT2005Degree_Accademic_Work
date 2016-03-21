Public Class _default
    Inherits System.Web.UI.Page
    Protected WithEvents cmdSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents lblSelections As System.Web.UI.WebControls.Label
    Protected WithEvents txtDoctor As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLife As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents chkList As System.Web.UI.WebControls.CheckBoxList

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
        'Trace.Write("default", "Beginning of Page_Load")
        'Put user code to initialize the page here
        'Trace.Warn("default", "IsPostBack=" & Page.IsPostBack)
        If Not Page.IsPostBack Then
            Dim clBenefits As New BenefitsListVB.Benefits()
            Dim bi As BenefitsListVB.Benefits.BenefitInfo
            For Each bi In clBenefits.GetBenefitsList()
                chkList.Items.Add("<a href=" & bi.strPage & ">" & bi.strName & "</a>")
            Next
        End If

        Dim objGetCookie As HttpCookie = Request.Cookies("Benefits")
        Dim strDoc As String
        Dim strLife As String

        If Not objGetCookie Is Nothing Then
            strDoc = objGetCookie.Values("doctor")
            strLife = objGetCookie.Values("life")
            txtDoctor.Text = strDoc
            txtLife.Text = strLife
        End If


    End Sub

    Private Sub cmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        Dim li As ListItem
        For Each li In chkList.Items
            If li.Selected Then
                lblSelections.Text &= (", " & li.Value)
            End If
        Next

    End Sub
End Class
