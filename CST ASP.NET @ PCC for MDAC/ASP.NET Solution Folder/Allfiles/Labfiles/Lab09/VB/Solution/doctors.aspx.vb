Imports System.Data.SqlClient
Imports System.Text

Public Class doctors1
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblSpecialties As System.Web.UI.WebControls.Label
    Protected WithEvents lstSpecialties As System.Web.UI.WebControls.ListBox
    Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
    Protected WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Protected WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
    Protected WithEvents DsDoctors1 As BenefitsVB.DsDoctors
    Protected WithEvents dgDoctors As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdSubmit As System.Web.UI.WebControls.Button

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter()
        Me.DsDoctors1 = New BenefitsVB.DsDoctors()
        CType(Me.DsDoctors1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT dr_id, dr_lname, dr_fname, phone, address, city, state, zip FROM doctors"
        Me.SqlSelectCommand1.Connection = Me.SqlConnection1
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "data source=CM-T23-STEPHENW;initial catalog=doctors;integrated security=SSPI;pers" & _
        "ist security info=True;workstation id=CM-T23-STEPHENW;packet size=4096"
        '
        'SqlDataAdapter1
        '
        Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
        Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "doctors", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("dr_id", "dr_id"), New System.Data.Common.DataColumnMapping("dr_lname", "dr_lname"), New System.Data.Common.DataColumnMapping("dr_fname", "dr_fname"), New System.Data.Common.DataColumnMapping("phone", "phone"), New System.Data.Common.DataColumnMapping("address", "address"), New System.Data.Common.DataColumnMapping("city", "city"), New System.Data.Common.DataColumnMapping("state", "state"), New System.Data.Common.DataColumnMapping("zip", "zip")})})
        '
        'DsDoctors1
        '
        Me.DsDoctors1.DataSetName = "DsDoctors"
        Me.DsDoctors1.Locale = New System.Globalization.CultureInfo("en-GB")
        Me.DsDoctors1.Namespace = "http://www.tempuri.org/DsDoctors.xsd"
        CType(Me.DsDoctors1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            'TODO Lab 9: bind the datagrid to the doctors table
            SqlDataAdapter1.Fill(DsDoctors1)
            dgDoctors.DataBind()


            'TODO Lab10: bind the listbox to city field in the doctors table


            'TODO Lab11: bind the listbox to the getUniqueCities stored procedure


            'TODO Lab10: add the "All" item to the list and select it


            'hide the specialties listbox
            lstSpecialties.Visible = False
            lblSpecialties.Visible = False

        End If
    End Sub

    Private Sub reset()
        'reset page index to 0
        dgDoctors.CurrentPageIndex = 0

        'remove the selection from the datagrid
        dgDoctors.SelectedIndex = -1

        'hide the specialites listbox
        lstSpecialties.Visible = False
        lblSpecialties.Visible = False
    End Sub

    Private Sub dgDoctors_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgDoctors.PageIndexChanged
        dgDoctors.CurrentPageIndex = e.NewPageIndex
        SqlDataAdapter1.Fill(DsDoctors1)
        dgDoctors.DataBind()
    End Sub

    Private Sub cmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        Dim strDrName As String
        strDrName = Trim(dgDoctors.Items _
         (dgDoctors.SelectedIndex).Cells(3).Text) & " " & _
         Trim(dgDoctors.Items _
         (dgDoctors.SelectedIndex).Cells(2).Text)
        Response.Redirect("medical.aspx?pcp=" & strDrName)
    End Sub
End Class
