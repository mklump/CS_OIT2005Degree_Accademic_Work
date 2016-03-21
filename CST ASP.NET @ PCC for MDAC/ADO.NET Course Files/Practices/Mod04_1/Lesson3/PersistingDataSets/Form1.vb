Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents dsNorthwind As System.Data.DataSet
    Friend WithEvents dtProducts As System.Data.DataTable
    Friend WithEvents dcProductID As System.Data.DataColumn
    Friend WithEvents dcProductName As System.Data.DataColumn
    Friend WithEvents dcUnitPrice As System.Data.DataColumn
    Friend WithEvents dcUnitsInStock As System.Data.DataColumn
    Friend WithEvents dcStockValue As System.Data.DataColumn
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.dsNorthwind = New System.Data.DataSet()
        Me.dtProducts = New System.Data.DataTable()
        Me.dcProductID = New System.Data.DataColumn()
        Me.dcProductName = New System.Data.DataColumn()
        Me.dcUnitPrice = New System.Data.DataColumn()
        Me.dcUnitsInStock = New System.Data.DataColumn()
        Me.dcStockValue = New System.Data.DataColumn()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.dsNorthwind, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dsNorthwind, "Products.UnitsInStock"))
        Me.TextBox4.Location = New System.Drawing.Point(8, 80)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(160, 20)
        Me.TextBox4.TabIndex = 0
        Me.TextBox4.Text = "TextBox4"
        '
        'dsNorthwind
        '
        Me.dsNorthwind.DataSetName = "Northwind"
        Me.dsNorthwind.Locale = New System.Globalization.CultureInfo("en-US")
        Me.dsNorthwind.Tables.AddRange(New System.Data.DataTable() {Me.dtProducts})
        '
        'dtProducts
        '
        Me.dtProducts.Columns.AddRange(New System.Data.DataColumn() {Me.dcProductID, Me.dcProductName, Me.dcUnitPrice, Me.dcUnitsInStock, Me.dcStockValue})
        Me.dtProducts.TableName = "Products"
        '
        'dcProductID
        '
        Me.dcProductID.ColumnName = "ProductID"
        Me.dcProductID.DataType = GetType(System.Int32)
        '
        'dcProductName
        '
        Me.dcProductName.ColumnName = "ProductName"
        '
        'dcUnitPrice
        '
        Me.dcUnitPrice.ColumnName = "UnitPrice"
        Me.dcUnitPrice.DataType = GetType(System.Decimal)
        '
        'dcUnitsInStock
        '
        Me.dcUnitsInStock.ColumnName = "UnitsInStock"
        Me.dcUnitsInStock.DataType = GetType(System.Int32)
        '
        'dcStockValue
        '
        Me.dcStockValue.ColumnName = "StockValue"
        Me.dcStockValue.Expression = "UnitPrice*UnitsInStock"
        Me.dcStockValue.ReadOnly = True
        '
        'TextBox5
        '
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dsNorthwind, "Products.StockValue"))
        Me.TextBox5.Location = New System.Drawing.Point(8, 104)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(160, 20)
        Me.TextBox5.TabIndex = 0
        Me.TextBox5.Text = "TextBox5"
        '
        'DataGrid1
        '
        Me.DataGrid1.DataMember = "Products"
        Me.DataGrid1.DataSource = Me.dsNorthwind
        Me.DataGrid1.Location = New System.Drawing.Point(8, 136)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(440, 128)
        Me.DataGrid1.TabIndex = 1
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dsNorthwind, "Products.UnitPrice"))
        Me.TextBox3.Location = New System.Drawing.Point(8, 56)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(160, 20)
        Me.TextBox3.TabIndex = 0
        Me.TextBox3.Text = "TextBox3"
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dsNorthwind, "Products.ProductName"))
        Me.TextBox2.Location = New System.Drawing.Point(8, 32)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(160, 20)
        Me.TextBox2.TabIndex = 0
        Me.TextBox2.Text = "TextBox2"
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.dsNorthwind, "Products.ProductID"))
        Me.TextBox1.Location = New System.Drawing.Point(8, 8)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(160, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "TextBox1"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(472, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox5, Me.TextBox4, Me.TextBox3, Me.TextBox2, Me.DataGrid1, Me.TextBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dsNorthwind, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dtProducts.Constraints.Add( _
            New UniqueConstraint("UC_ProductName", Me.dcProductName))

        Try
            Me.dsNorthwind.ReadXml("Northwind.ds")
        Catch
        End Try

    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Me.dsNorthwind.WriteXml("Northwind.ds")

    End Sub
End Class
