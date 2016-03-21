Public MustInherit Class header
    Inherits System.Web.UI.UserControl
    Protected WithEvents A2 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents A3 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents A4 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents lblTime As System.Web.UI.WebControls.Label
    Protected WithEvents A5 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents A1 As System.Web.UI.HtmlControls.HtmlAnchor

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
        Dim clBenefits As New BenefitsListVB.Benefits()
        Dim arBenefits As BenefitsListVB.Benefits.BenefitInfo()

        arBenefits = clBenefits.GetBenefitsList()
        A1.HRef = arBenefits(0).strPage
        A1.InnerText = arBenefits(0).strName
        A2.HRef = arBenefits(1).strPage
        A2.InnerText = arBenefits(1).strName
        A3.HRef = arBenefits(2).strPage
        A3.InnerText = arBenefits(2).strName
        A4.HRef = arBenefits(3).strPage
        A4.InnerText = arBenefits(3).strName
        
        lblTime.Text = DateTime.Now.TimeOfDay.ToString()

    End Sub

End Class
