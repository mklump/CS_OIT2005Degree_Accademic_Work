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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dcProductID = New System.Data.DataColumn()
        Me.dcUnitPrice = New System.Data.DataColumn()
        Me.dcProductName = New System.Data.DataColumn()
        Me.dcUnitsInStock = New System.Data.DataColumn()
        Me.dtProducts = New System.Data.DataTable()
        Me.dsNorthwind = New System.Data.DataSet()
        CType(Me.dtProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsNorthwind, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'dcProductID
        '
        Me.dcProductID.ColumnName = "ProductID"
        Me.dcProductID.DataType = GetType(System.Int32)
        '
        'dcUnitPrice
        '
        Me.dcUnitPrice.ColumnName = "UnitPrice"
        Me.dcUnitPrice.DataType = GetType(System.Decimal)
        '
        'dcProductName
        '
        Me.dcProductName.ColumnName = "ProductName"
        '
        'dcUnitsInStock
        '
        Me.dcUnitsInStock.ColumnName = "UnitsInStock"
        Me.dcUnitsInStock.DataType = GetType(System.Int32)
        '
        'dtProducts
        '
        Me.dtProducts.Columns.AddRange(New System.Data.DataColumn() {Me.dcProductID, Me.dcProductName, Me.dcUnitPrice, Me.dcUnitsInStock})
        Me.dtProducts.TableName = "Products"
        '
        'dsNorthwind
        '
        Me.dsNorthwind.DataSetName = "Northwind"
        Me.dsNorthwind.Locale = New System.Globalization.CultureInfo("en-US")
        Me.dsNorthwind.Tables.AddRange(New System.Data.DataTable() {Me.dtProducts})
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dtProducts, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsNorthwind, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtProducts.Constraints.Add( _
            New UniqueConstraint("UC_ProductName", Me.dcProductName))
    End Sub
End Class
