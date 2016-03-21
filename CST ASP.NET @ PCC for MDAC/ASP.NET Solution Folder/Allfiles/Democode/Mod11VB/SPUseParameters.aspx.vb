Imports System.Data.SqlClient

Public Class SPUseParameters
    Inherits System.Web.UI.Page
        Protected WithEvents cmdSales As System.Web.UI.WebControls.Button
    Protected WithEvents txtStartDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents dgSales As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtEndDate As System.Web.UI.WebControls.TextBox

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

    Private Sub cmdSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSales.Click
        Dim conn As New SqlConnection _
            ("server=localhost;integrated security=true;initial catalog=northwind")
        Dim da As SqlDataAdapter
        Dim ds As DataSet
        Dim workParam As SQLParameter = Nothing

        'call the Sales by year stored procedure
        da = New SqlDataAdapter("Sales By Year", conn)
        da.SelectCommand.CommandType = CommandType.StoredProcedure

        'add the start date input parameter 
        workParam = New SqlParameter("@Beginning_Date", System.Data.SqlDbType.DateTime)
        workParam.Direction = ParameterDirection.Input
        workParam.Value = CDate(txtStartDate.Text)
        da.SelectCommand.Parameters.Add(workParam)

        'add the end date input parameter 
        workParam = New SqlParameter("@Ending_Date", System.Data.SqlDbType.DateTime)
        workParam.Direction = ParameterDirection.Input
        workParam.Value = CDate(txtEndDate.Text)
        da.SelectCommand.Parameters.Add(workParam)

        'run the stored procedure and fill a dataset with the results
        ds = New DataSet()
        da.Fill(ds, "Sales")

        'bind the dataset to a datagrid
        dgSales.DataSource = ds
        dgSales().DataBind()
    End Sub
End Class
