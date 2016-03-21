Imports System.Data.SqlClient

Public Class UseGrid
    Inherits System.Web.UI.Page
    Protected WithEvents dgAuthors As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgCAAuthors As System.Web.UI.WebControls.DataGrid
    Protected strSort As String
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
            DisplayData()
        End If
    End Sub

 

    Private Sub DisplayData()
        Dim ds As DataSet
        Dim conn As SqlConnection
        Dim daAuthors As SqlDataAdapter
        Dim dv As DataView

        'create a connection to the Pubs database    
        conn = New SqlConnection _
            ("data source=localhost;integrated security=true;initial catalog=pubs")

        'create a dataset with information from the authors table
        daAuthors = New SqlDataAdapter _
            ("select * from Authors", conn)
        ds = New DataSet()
        daAuthors.Fill(ds, "Authors")

        'bind the first datagrid to the DefaultView of the dataset
        dgAuthors.DataSource = ds
        dgAuthors.DataMember = "Authors"
        dgAuthors.DataBind()

        'create a new DataView that is authors from California
        'and bind the second datagrid to it
        dv = New DataView(ds.Tables("Authors"))
        dv.RowFilter = "state = 'CA'"
        dv.Sort = strSort
        dgCAAuthors.DataSource = dv
        dgCAAuthors.DataBind()
    End Sub

    Private Sub dgCAAuthors_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgCAAuthors.SortCommand
        strSort = e.SortExpression.ToString()
        DisplayData()
    End Sub
End Class
