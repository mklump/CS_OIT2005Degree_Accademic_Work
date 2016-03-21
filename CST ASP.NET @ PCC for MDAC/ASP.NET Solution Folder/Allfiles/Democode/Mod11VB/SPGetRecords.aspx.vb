Imports System.Data.SqlClient

Public Class SPGetRecords
    Inherits System.Web.UI.Page
    Protected WithEvents dgProducts As System.Web.UI.WebControls.DataGrid

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
            'create connection
            Dim conn As New SqlConnection _
                ("data source=localhost;integrated security=true;initial catalog=northwind")

            'create dataadapter to call stored procedure
            Dim da As New SqlDataAdapter()
            da.SelectCommand = New SqlCommand()
            With da.SelectCommand
                .Connection = conn
                .CommandText = "Ten Most Expensive Products"
                .CommandType = CommandType.StoredProcedure
            End With

            'fill dataset with results of stored procedure'   
            Dim ds As New DataSet()
            da.Fill(ds, "Products")

            'bind dataset to datagrid'
            dgProducts.DataSource = ds
            dgProducts.DataBind()
        End If
    End Sub

End Class
