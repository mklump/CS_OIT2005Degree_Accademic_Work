Imports System.Data.SqlClient

Public Class UseDataSet
    Inherits System.Web.UI.Page
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cmdRows As System.Web.UI.WebControls.Button
    Protected WithEvents lblRows As System.Web.UI.WebControls.Label
        Protected WithEvents lstItems As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmdGetValues As System.Web.UI.WebControls.Button
        Protected WithEvents lblNames As System.Web.UI.WebControls.Label

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
    Private ds As DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        If Not Page.IsPostBack Then
            'bind the column names to the listbox
            Dim col As DataColumn
            For Each col In ds.Tables(0).Columns
                lstItems.Items.Add(col.ColumnName)
            Next
        End If

    End Sub

    Private Sub cmdRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRows.Click
        lblRows.Text = ds.Tables(0).Rows.Count
    End Sub

    Private Sub cmdGetValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetValues.Click
        Dim r As DataRow

        lblNames.Text = ""
        For Each r In ds.Tables(0).Rows
            'get the column selected in the lstItems listbox
            lblNames.Text &= r(lstItems.SelectedItem.Value) & " "
        Next
    End Sub
End Class
