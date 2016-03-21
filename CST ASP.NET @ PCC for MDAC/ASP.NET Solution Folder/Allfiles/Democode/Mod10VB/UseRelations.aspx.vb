Imports System.Data.SqlClient

Public Class UseRelations
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents dgChild As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgParent As System.Web.UI.WebControls.DataGrid

#End Region
    Private ds As DataSet

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        CreateDataSet()
        MakeDataRelation()
        BindToDataGrid()
    End Sub

    Private Sub CreateDataSet()
        Dim conn As SqlConnection
        Dim daCustomers As SqlDataAdapter
        Dim daOrders As SqlDataAdapter

        'create a connection to the Pubs database    
        conn = New SqlConnection _
            ("data source=localhost;integrated security=true;initial catalog=northwind")

        'create first datatable
        daCustomers = New SqlDataAdapter _
            ("select CustomerID, CompanyName from Customers", conn)
        ds = New DataSet()
        daCustomers.Fill(ds, "Customers")

        'create the second DataTable
        daOrders = New SqlDataAdapter _
            ("select CustomerID, OrderID, OrderDate, ShippedDate from Orders", conn)
        daOrders.Fill(ds, "Orders")
    End Sub

    Private Sub MakeDataRelation()
        ' DataRelation requires two DataColumn (parent and child) and a name.
        Dim dr As DataRelation
        Dim parentCol As DataColumn
        Dim childCol As DataColumn
        'relationship: each Customer has many orders
        parentCol = ds.Tables("Customers").Columns("customerid")
        childCol = ds.Tables("Orders").Columns("customerid")
        dr = New DataRelation("CustOrders", parentCol, childCol)
        ds.Relations.Add(dr)
    End Sub

    Private Sub BindToDataGrid()
        ' Instruct the DataGrid to bind to the DataSet, with the 
        ' Publishers table as the topmost DataTable.
        dgParent.DataSource = ds
        dgParent.DataMember = "Customers"
        dgParent.DataBind()
    End Sub


    Private Sub dgParent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgParent.SelectedIndexChanged
        'when you select a customer, display the order numbers
        'get the row and call GetParentRows
        Label1.Text = "Order Numbers: "

        'use relationship programmatically
        Dim currentParentRow As DataRow
        Dim r As DataRow
        Dim iCurrentRowIndex As Integer
        iCurrentRowIndex = dgParent.SelectedIndex + (dgParent.CurrentPageIndex * dgParent.PageSize)
        currentParentRow = ds.Tables("Customers").Rows(iCurrentRowIndex)
        For Each r In currentParentRow.GetChildRows("CustOrders")
            Label1.Text &= r("OrderID") & ", "
        Next

        'use relationship visually
        Dim parentTableView As New DataView(ds.Tables("Customers"))
        Dim currentRowView As DataRowView = parentTableView(iCurrentRowIndex)
        dgChild.DataSource = currentRowView.CreateChildView("CustOrders")
        dgChild.DataBind()

    End Sub

    Private Sub dgParent_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgParent.PageIndexChanged
        dgParent.CurrentPageIndex = e.NewPageIndex
        CreateDataSet()
        MakeDataRelation()
        BindToDataGrid()
    End Sub
End Class
