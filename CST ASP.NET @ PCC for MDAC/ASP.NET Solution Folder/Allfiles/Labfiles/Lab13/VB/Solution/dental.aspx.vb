Public Class dental
    Inherits System.Web.UI.Page
    Protected WithEvents txtPostalCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents cmdSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents dgDentists As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdGetAllDentists As System.Web.UI.WebControls.Button
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

    Private Sub cmdGetAllDentists_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetAllDentists.Click
        'TODO Lab 13: call the XML Web service method
        'GetAllDentists
        Dim ProxyGetAllDentists As New _
            BenefitsVB.DentalWebRef.DentalService1()
        Dim dsAllDentists As New DataSet()
        dsAllDentists = _
            ProxyGetAllDentists.GetAllDentists()
        dgDentists.DataSource = dsAllDentists.Tables(0)
        dgDentists.DataBind()
    End Sub

    Private Sub cmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        'TODO Lab 13: call the XML Web service method
        'GetDentistsByPostalCode
        Dim ProxyGetDentistsByPostalCode As New _
            BenefitsVB.DentalWebRef.DentalService1()
        Dim dsDentistsByPostalCode As New DataSet()
        dsDentistsByPostalCode = _
         ProxyGetDentistsByPostalCode. _
          GetDentistsByPostalCode(txtPostalCode.Text)
        dgDentists.DataSource = dsDentistsByPostalCode.Tables(0)
        dgDentists.DataBind()
    End Sub

End Class
