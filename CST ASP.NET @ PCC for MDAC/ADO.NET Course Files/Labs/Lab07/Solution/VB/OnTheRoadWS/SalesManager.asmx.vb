Imports System.Web.Services

Public Class SalesManager
    Inherits System.Web.Services.WebService

    Friend WithEvents daEmployees As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents cmSelectEmployees As System.Data.SqlClient.SqlCommand
    Friend WithEvents cnNorthwind As System.Data.SqlClient.SqlConnection
    Friend WithEvents daProducts As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents cmSelectProducts As System.Data.SqlClient.SqlCommand
    Friend WithEvents daCustomers As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents cmSelectCustomers As System.Data.SqlClient.SqlCommand
    Friend WithEvents cmInsertCustomers As System.Data.SqlClient.SqlCommand
    Friend WithEvents cmUpdateCustomers As System.Data.SqlClient.SqlCommand
    Friend WithEvents cmDeleteCustomers As System.Data.SqlClient.SqlCommand
    Friend WithEvents daOrders As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents cmSelectOrders As System.Data.SqlClient.SqlCommand
    Friend WithEvents cmInsertOrders As System.Data.SqlClient.SqlCommand
    Friend WithEvents cmUpdateOrders As System.Data.SqlClient.SqlCommand
    Friend WithEvents cmDeleteOrders As System.Data.SqlClient.SqlCommand
    Friend WithEvents daOrderDetails As System.Data.SqlClient.SqlDataAdapter
    Friend WithEvents cmSelectOrderDetails As System.Data.SqlClient.SqlCommand
    Friend WithEvents cmInsertOrderDetails As System.Data.SqlClient.SqlCommand
    Friend WithEvents cmUpdateOrderDetails As System.Data.SqlClient.SqlCommand
    Friend WithEvents cnNorthwindInstructor As System.Data.SqlClient.SqlConnection
    Friend WithEvents cmDeleteOrderDetails As System.Data.SqlClient.SqlCommand

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmSelectEmployees = New System.Data.SqlClient.SqlCommand
        Me.cnNorthwindInstructor = New System.Data.SqlClient.SqlConnection
        Me.daCustomers = New System.Data.SqlClient.SqlDataAdapter
        Me.cmDeleteCustomers = New System.Data.SqlClient.SqlCommand
        Me.cnNorthwind = New System.Data.SqlClient.SqlConnection
        Me.cmInsertCustomers = New System.Data.SqlClient.SqlCommand
        Me.cmSelectCustomers = New System.Data.SqlClient.SqlCommand
        Me.cmUpdateCustomers = New System.Data.SqlClient.SqlCommand
        Me.daEmployees = New System.Data.SqlClient.SqlDataAdapter
        Me.cmUpdateOrderDetails = New System.Data.SqlClient.SqlCommand
        Me.daOrders = New System.Data.SqlClient.SqlDataAdapter
        Me.cmDeleteOrders = New System.Data.SqlClient.SqlCommand
        Me.cmInsertOrders = New System.Data.SqlClient.SqlCommand
        Me.cmSelectOrders = New System.Data.SqlClient.SqlCommand
        Me.cmUpdateOrders = New System.Data.SqlClient.SqlCommand
        Me.cmInsertOrderDetails = New System.Data.SqlClient.SqlCommand
        Me.cmSelectProducts = New System.Data.SqlClient.SqlCommand
        Me.cmSelectOrderDetails = New System.Data.SqlClient.SqlCommand
        Me.daOrderDetails = New System.Data.SqlClient.SqlDataAdapter
        Me.cmDeleteOrderDetails = New System.Data.SqlClient.SqlCommand
        Me.daProducts = New System.Data.SqlClient.SqlDataAdapter
        '
        'cmSelectEmployees
        '
        Me.cmSelectEmployees.CommandText = "SELECT EmployeeID, LastName + ', ' + FirstName AS FullName FROM EmployeesLatest O" & _
        "RDER BY LastName, FirstName"
        Me.cmSelectEmployees.Connection = Me.cnNorthwindInstructor
        '
        'cnNorthwindInstructor
        '
        Me.cnNorthwindInstructor.ConnectionString = "data source=localhost;initial catalog=Northwind;user id=MaryJane;password=secret;" & _
        "persist security info=False;"
        '
        'daCustomers
        '
        Me.daCustomers.DeleteCommand = Me.cmDeleteCustomers
        Me.daCustomers.InsertCommand = Me.cmInsertCustomers
        Me.daCustomers.SelectCommand = Me.cmSelectCustomers
        Me.daCustomers.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Customers", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"), New System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"), New System.Data.Common.DataColumnMapping("ContactName", "ContactName"), New System.Data.Common.DataColumnMapping("City", "City"), New System.Data.Common.DataColumnMapping("Phone", "Phone")})})
        Me.daCustomers.UpdateCommand = Me.cmUpdateCustomers
        '
        'cmDeleteCustomers
        '
        Me.cmDeleteCustomers.CommandText = "[DeleteCustomers]"
        Me.cmDeleteCustomers.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmDeleteCustomers.Connection = Me.cnNorthwind
        Me.cmDeleteCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
        Me.cmDeleteCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
        Me.cmDeleteCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Original, Nothing))
        Me.cmDeleteCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
        Me.cmDeleteCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Phone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing))
        '
        'cnNorthwind
        '
        Me.cnNorthwind.ConnectionString = "data source=(local);initial catalog=Northwind;integrated security=SSPI;persist se" & _
        "curity info=False;"
        '
        'cmInsertCustomers
        '
        Me.cmInsertCustomers.CommandText = "[InsertCustomers]"
        Me.cmInsertCustomers.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmInsertCustomers.Connection = Me.cnNorthwind
        Me.cmInsertCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmInsertCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"))
        Me.cmInsertCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"))
        Me.cmInsertCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, "ContactName"))
        Me.cmInsertCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"))
        Me.cmInsertCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 24, "Phone"))
        '
        'cmSelectCustomers
        '
        Me.cmSelectCustomers.CommandText = "[SelectCustomers]"
        Me.cmSelectCustomers.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmSelectCustomers.Connection = Me.cnNorthwind
        Me.cmSelectCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmSelectCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"))
        '
        'cmUpdateCustomers
        '
        Me.cmUpdateCustomers.CommandText = "[UpdateCustomers]"
        Me.cmUpdateCustomers.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmUpdateCustomers.Connection = Me.cnNorthwind
        Me.cmUpdateCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"))
        Me.cmUpdateCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"))
        Me.cmUpdateCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, "ContactName"))
        Me.cmUpdateCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"))
        Me.cmUpdateCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 24, "Phone"))
        Me.cmUpdateCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
        Me.cmUpdateCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
        Me.cmUpdateCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Original, Nothing))
        Me.cmUpdateCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
        Me.cmUpdateCustomers.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Phone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing))
        '
        'daEmployees
        '
        Me.daEmployees.SelectCommand = Me.cmSelectEmployees
        Me.daEmployees.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Employees", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"), New System.Data.Common.DataColumnMapping("FullName", "FullName")})})
        '
        'cmUpdateOrderDetails
        '
        Me.cmUpdateOrderDetails.CommandText = "[UpdateOrderDetails]"
        Me.cmUpdateOrderDetails.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmUpdateOrderDetails.Connection = Me.cnNorthwind
        Me.cmUpdateOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, "OrderID"))
        Me.cmUpdateOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductID", System.Data.SqlDbType.Int, 4, "ProductID"))
        Me.cmUpdateOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, "UnitPrice"))
        Me.cmUpdateOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Quantity", System.Data.SqlDbType.SmallInt, 2, "Quantity"))
        Me.cmUpdateOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderID", System.Data.DataRowVersion.Original, Nothing))
        Me.cmUpdateOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProductID", System.Data.DataRowVersion.Original, Nothing))
        Me.cmUpdateOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Quantity", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Quantity", System.Data.DataRowVersion.Original, Nothing))
        Me.cmUpdateOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "UnitPrice", System.Data.DataRowVersion.Original, Nothing))
        '
        'daOrders
        '
        Me.daOrders.DeleteCommand = Me.cmDeleteOrders
        Me.daOrders.InsertCommand = Me.cmInsertOrders
        Me.daOrders.SelectCommand = Me.cmSelectOrders
        Me.daOrders.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Orders", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("OrderID", "OrderID"), New System.Data.Common.DataColumnMapping("OrderDate", "OrderDate"), New System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"), New System.Data.Common.DataColumnMapping("CustomerID", "CustomerID")})})
        Me.daOrders.UpdateCommand = Me.cmUpdateOrders
        '
        'cmDeleteOrders
        '
        Me.cmDeleteOrders.CommandText = "[DeleteOrders]"
        Me.cmDeleteOrders.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmDeleteOrders.Connection = Me.cnNorthwind
        Me.cmDeleteOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderID", System.Data.DataRowVersion.Original, Nothing))
        Me.cmDeleteOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
        Me.cmDeleteOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
        Me.cmDeleteOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing))
        '
        'cmInsertOrders
        '
        Me.cmInsertOrders.CommandText = "[InsertOrders]"
        Me.cmInsertOrders.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmInsertOrders.Connection = Me.cnNorthwind
        Me.cmInsertOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmInsertOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderDate", System.Data.SqlDbType.DateTime, 8, "OrderDate"))
        Me.cmInsertOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"))
        Me.cmInsertOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"))
        '
        'cmSelectOrders
        '
        Me.cmSelectOrders.CommandText = "[SelectOrders]"
        Me.cmSelectOrders.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmSelectOrders.Connection = Me.cnNorthwind
        Me.cmSelectOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmSelectOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"))
        '
        'cmUpdateOrders
        '
        Me.cmUpdateOrders.CommandText = "[UpdateOrders]"
        Me.cmUpdateOrders.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmUpdateOrders.Connection = Me.cnNorthwind
        Me.cmUpdateOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmUpdateOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderDate", System.Data.SqlDbType.DateTime, 8, "OrderDate"))
        Me.cmUpdateOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Param1", System.Data.SqlDbType.Int, 4, "EmployeeID"))
        Me.cmUpdateOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"))
        Me.cmUpdateOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderID", System.Data.DataRowVersion.Original, Nothing))
        Me.cmUpdateOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
        Me.cmUpdateOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
        Me.cmUpdateOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing))
        Me.cmUpdateOrders.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, "OrderID"))
        '
        'cmInsertOrderDetails
        '
        Me.cmInsertOrderDetails.CommandText = "[InsertOrderDetails]"
        Me.cmInsertOrderDetails.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmInsertOrderDetails.Connection = Me.cnNorthwind
        Me.cmInsertOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmInsertOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, "OrderID"))
        Me.cmInsertOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProductID", System.Data.SqlDbType.Int, 4, "ProductID"))
        Me.cmInsertOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, "UnitPrice"))
        Me.cmInsertOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Quantity", System.Data.SqlDbType.SmallInt, 2, "Quantity"))
        '
        'cmSelectProducts
        '
        Me.cmSelectProducts.CommandText = "SELECT ProductID, ProductName, UnitPrice FROM Products"
        Me.cmSelectProducts.Connection = Me.cnNorthwind
        '
        'cmSelectOrderDetails
        '
        Me.cmSelectOrderDetails.CommandText = "[SelectOrderDetails]"
        Me.cmSelectOrderDetails.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmSelectOrderDetails.Connection = Me.cnNorthwind
        Me.cmSelectOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmSelectOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"))
        '
        'daOrderDetails
        '
        Me.daOrderDetails.DeleteCommand = Me.cmDeleteOrderDetails
        Me.daOrderDetails.InsertCommand = Me.cmInsertOrderDetails
        Me.daOrderDetails.SelectCommand = Me.cmSelectOrderDetails
        Me.daOrderDetails.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "OrderDetails", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("OrderID", "OrderID"), New System.Data.Common.DataColumnMapping("ProductID", "ProductID"), New System.Data.Common.DataColumnMapping("UnitPrice", "UnitPrice"), New System.Data.Common.DataColumnMapping("Quantity", "Quantity")})})
        Me.daOrderDetails.UpdateCommand = Me.cmUpdateOrderDetails
        '
        'cmDeleteOrderDetails
        '
        Me.cmDeleteOrderDetails.CommandText = "[DeleteOrderDetails]"
        Me.cmDeleteOrderDetails.CommandType = System.Data.CommandType.StoredProcedure
        Me.cmDeleteOrderDetails.Connection = Me.cnNorthwind
        Me.cmDeleteOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, False, CType(0, Byte), CType(0, Byte), "", System.Data.DataRowVersion.Current, Nothing))
        Me.cmDeleteOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderID", System.Data.DataRowVersion.Original, Nothing))
        Me.cmDeleteOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ProductID", System.Data.DataRowVersion.Original, Nothing))
        Me.cmDeleteOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Quantity", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Quantity", System.Data.DataRowVersion.Original, Nothing))
        Me.cmDeleteOrderDetails.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "UnitPrice", System.Data.DataRowVersion.Original, Nothing))
        '
        'daProducts
        '
        Me.daProducts.SelectCommand = Me.cmSelectProducts
        Me.daProducts.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Products", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ProductID", "ProductID"), New System.Data.Common.DataColumnMapping("ProductName", "ProductName"), New System.Data.Common.DataColumnMapping("UnitPrice", "UnitPrice")})})

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
    End Sub

#End Region

    <WebMethod()> Public Function GetDataSet(ByVal iEmployeeID As System.Int32, ByVal sServerName As System.String) As OnTheRoadWS.NWDataSet

        ' TODO: instantiate the data set

        Dim tempNW As New OnTheRoadWS.NWDataSet()

        ' TODO: set connection string using new server name

        Me.cnNorthwind.ConnectionString = _
         "data source=" & sServerName & ";" & _
         "initial catalog=Northwind;" & _
         "integrated security=SSPI;" & _
         "persist security info=False;"

        ' TODO: connect to SQL Server

        Me.cnNorthwind.Open()

        ' fill the Employees DataTable
        Me.daEmployees.Fill(tempNW.Employees)

        ' fill the Products DataTable
        Me.daProducts.Fill(tempNW.Products)

        ' fill the Customers DataTable
        Me.daCustomers.SelectCommand.Parameters("@EmployeeID").Value = iEmployeeID
        Me.daCustomers.Fill(tempNW.Customers)

        ' fill the Orders DataTable
        Me.daOrders.SelectCommand.Parameters("@EmployeeID").Value = iEmployeeID
        Me.daOrders.Fill(tempNW.Orders)

        ' fill the Order Details DataTable
        Me.daOrderDetails.SelectCommand.Parameters("@EmployeeID").Value = iEmployeeID
        Me.daOrderDetails.Fill(tempNW.OrderDetails)

        Me.cnNorthwind.Close()

        GetDataSet = tempNW

    End Function

    <WebMethod()> Public Sub UpdateDatabase(ByVal dsNorthwind As OnTheRoadWS.NWDataSet)

        ' TODO: set connection string using new server name

        Me.cnNorthwind.ConnectionString = _
         "data source=" & dsNorthwind.AppSettings.Rows(0)("ServerName") & ";" & _
         "initial catalog=Northwind;" & _
         "integrated security=SSPI;" & _
         "persist security info=False;"

        ' update the central database

        ' we need to create a complete DataSet for inserts so that when a new
        ' order is inserted, and a new OrderID assigned by SQL Server, that value
        ' is propagated through to related OrderDetail rows
        Dim dsInserts As DataSet = dsNorthwind.GetChanges(DataRowState.Added)

        ' these variables are only used to check if new rows have been added
        Dim dtInsertCustomers As DataTable = dsNorthwind.Tables("Customers").GetChanges(DataRowState.Added)
        Dim dtInsertOrders As DataTable = dsNorthwind.Tables("Orders").GetChanges(DataRowState.Added)
        Dim dtInsertOrderDetails As DataTable = dsNorthwind.Tables("OrderDetails").GetChanges(DataRowState.Added)

        Dim dtUpdateCustomers As DataTable = dsNorthwind.Tables("Customers").GetChanges(DataRowState.Modified)
        Dim dtUpdateOrders As DataTable = dsNorthwind.Tables("Orders").GetChanges(DataRowState.Modified)
        Dim dtUpdateOrderDetails As DataTable = dsNorthwind.Tables("OrderDetails").GetChanges(DataRowState.Modified)

        Dim dtDeleteCustomers As DataTable = dsNorthwind.Tables("Customers").GetChanges(DataRowState.Deleted)
        Dim dtDeleteOrders As DataTable = dsNorthwind.Tables("Orders").GetChanges(DataRowState.Deleted)
        Dim dtDeleteOrderDetails As DataTable = dsNorthwind.Tables("OrderDetails").GetChanges(DataRowState.Deleted)

        Me.cnNorthwind.Open()

        ' INSERT statements must be ordered parent -> child

        If Not dtInsertCustomers Is Nothing Then
            Me.daCustomers.Update(dsInserts.Tables("Customers"))
        End If

        If Not dtInsertOrders Is Nothing Then
            Me.daOrders.Update(dsInserts.Tables("Orders"))
        End If

        If Not dtInsertOrderDetails Is Nothing Then
            Me.daOrderDetails.Update(dsInserts.Tables("OrderDetails"))
        End If

        ' UPDATE statements must be ordered parent -> child

        If Not dtUpdateCustomers Is Nothing Then
            Me.daCustomers.Update(dtUpdateCustomers)
        End If

        If Not dtUpdateOrders Is Nothing Then
            Me.daOrders.Update(dtUpdateOrders)
        End If

        If Not dtUpdateOrderDetails Is Nothing Then
            Me.daOrderDetails.Update(dtUpdateOrderDetails)
        End If

        ' DELETE statements must be ordered child -> parent

        If Not dtDeleteOrderDetails Is Nothing Then
            Me.daOrderDetails.Update(dtDeleteOrderDetails)
        End If

        If Not dtDeleteOrders Is Nothing Then
            Me.daOrders.Update(dtDeleteOrders)
        End If

        If Not dtDeleteCustomers Is Nothing Then
            Me.daCustomers.Update(dtDeleteCustomers)
        End If

        Me.cnNorthwind.Close()

    End Sub

End Class
