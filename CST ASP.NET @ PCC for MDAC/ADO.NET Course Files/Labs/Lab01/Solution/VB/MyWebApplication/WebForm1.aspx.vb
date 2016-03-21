Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Protected WithEvents btnQuery As System.Web.UI.WebControls.Button
    Protected WithEvents dgResult As System.Web.UI.WebControls.DataGrid
    Protected WithEvents SqlCommand1 As System.Data.SqlClient.SqlCommand
        
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SqlCommand1 = New System.Data.SqlClient.SqlCommand()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        '
        'SqlCommand1
        '
        Me.SqlCommand1.CommandText = "SELECT ProductName, UnitPrice FROM Products"
        Me.SqlCommand1.Connection = Me.SqlConnection1
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "data source=(local);initial catalog=Northwind;integrated security=SSPI;persist se" & _
        "curity info=False;packet size=4096"

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

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        ' Open a connection to the Northwind database
        SqlConnection1.Open()

        ' Execute the query, and create a SqlDataReader to read the results
        Dim Reader As System.Data.SqlClient.SqlDataReader
        Reader = SqlCommand1.ExecuteReader()

        ' Bind the datagrid to the SqlDataReader. This will cause the SqlDataReader to
        ' iterate through the data, and populate the datagrid with that data. 
        ' The datagrid will display the data on the screen.
        dgResult.DataSource = Reader
        dgResult.DataBind()

        ' Close the SqlDataReader and the SqlConnection
        Reader.Close()
        SqlConnection1.Close()
    End Sub
End Class
