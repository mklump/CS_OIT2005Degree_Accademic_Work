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
        Friend WithEvents cmSelectProducts As System.Data.SqlClient.SqlCommand
    Friend WithEvents cmInsertProducts As System.Data.SqlClient.SqlCommand
    Friend WithEvents cmUpdateProducts As System.Data.SqlClient.SqlCommand
    Friend WithEvents cmDeleteProducts As System.Data.SqlClient.SqlCommand
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents daProducts As System.Data.SqlClient.SqlDataAdapter

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.daProducts = New System.Data.SqlClient.SqlDataAdapter()
        Me.cmDeleteProducts = New System.Data.SqlClient.SqlCommand()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.cmInsertProducts = New System.Data.SqlClient.SqlCommand()
        Me.cmSelectProducts = New System.Data.SqlClient.SqlCommand()
        Me.cmUpdateProducts = New System.Data.SqlClient.SqlCommand()
        '
        'daProducts
        '
        Me.daProducts.DeleteCommand = Me.cmDeleteProducts
        Me.daProducts.InsertCommand = Me.cmInsertProducts
        Me.daProducts.SelectCommand = Me.cmSelectProducts
        Me.daProducts.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Products", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ProductID", "ProductID"), New System.Data.Common.DataColumnMapping("ProductName", "ProductName"), New System.Data.Common.DataColumnMapping("SupplierID", "SupplierID"), New System.Data.Common.DataColumnMapping("CategoryID", "CategoryID"), New System.Data.Common.DataColumnMapping("QuantityPerUnit", "QuantityPerUnit"), New System.Data.Common.DataColumnMapping("UnitPrice", "UnitPrice"), New System.Data.Common.DataColumnMapping("UnitsInStock", "UnitsInStock"), New System.Data.Common.DataColumnMapping("UnitsOnOrder", "UnitsOnOrder"), New System.Data.Common.DataColumnMapping("ReorderLevel", "ReorderLevel"), New System.Data.Common.DataColumnMapping("Discontinued", "Discontinued")})})
        Me.daProducts.UpdateCommand = Me.cmUpdateProducts
        '
        'cmDeleteProducts
        '
        Me.cmDeleteProducts.CommandText = "DeleteProducts"
        Me.cmDeleteProducts.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmDeleteProducts.Connection = Me.SqlConnection1
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CategoryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CategoryID1", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Discontinued", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductName", System.Data.SqlDbType.NChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@QuantityPerUnit", System.Data.SqlDbType.NChar, 20, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@QuantityPerUnit1", System.Data.SqlDbType.NChar, 20, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ReorderLevel", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ReorderLevel1", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SupplierID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SupplierID1", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(19, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitPrice1", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(19, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitsInStock", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitsInStock1", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitsOnOrder", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitsOnOrder1", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "data source=(local);initial catalog=Northwind;integrated security=SSPI;persist se" & _
        "curity info=False;packet size=4096"
        '
        'cmInsertProducts
        '
        Me.cmInsertProducts.CommandText = "InsertProducts"
        Me.cmInsertProducts.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmInsertProducts.Connection = Me.SqlConnection1
        Me.cmInsertProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmInsertProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductName", System.Data.SqlDbType.NChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmInsertProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SupplierID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmInsertProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CategoryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmInsertProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@QuantityPerUnit", System.Data.SqlDbType.NChar, 20, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmInsertProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(19, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmInsertProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitsInStock", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmInsertProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitsOnOrder", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmInsertProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ReorderLevel", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmInsertProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Discontinued", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '
        'cmSelectProducts
        '
        Me.cmSelectProducts.CommandText = "SelectProducts"
        Me.cmSelectProducts.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmSelectProducts.Connection = Me.SqlConnection1
        Me.cmSelectProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '
        'cmUpdateProducts
        '
        Me.cmUpdateProducts.CommandText = "UpdateProducts"
        Me.cmUpdateProducts.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmUpdateProducts.Connection = Me.SqlConnection1
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductName", System.Data.SqlDbType.NChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SupplierID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CategoryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@QuantityPerUnit", System.Data.SqlDbType.NChar, 20, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(19, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitsInStock", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitsOnOrder", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ReorderLevel", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Discontinued", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CategoryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CategoryID1", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Discontinued", System.Data.SqlDbType.Bit, 1, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProductName", System.Data.SqlDbType.NChar, 40, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_QuantityPerUnit", System.Data.SqlDbType.NChar, 20, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_QuantityPerUnit1", System.Data.SqlDbType.NChar, 20, System.Data.ParameterDirection.Input, True, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ReorderLevel", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ReorderLevel1", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_SupplierID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_SupplierID1", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(19, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitPrice1", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, True, CType(19, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitsInStock", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitsInStock1", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitsOnOrder", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitsOnOrder1", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, True, CType(5, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateProducts.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Select_ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, True, CType(10, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(360, 273)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region


End Class
