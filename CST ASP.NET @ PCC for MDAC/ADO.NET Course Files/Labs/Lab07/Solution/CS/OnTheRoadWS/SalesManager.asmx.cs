using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace OnTheRoadWS
{
	/// <summary>
	/// Summary description for SalesManager.
	/// </summary>
	public class SalesManager : System.Web.Services.WebService
	{
		internal System.Data.SqlClient.SqlConnection cnNorthwind;
		internal System.Data.SqlClient.SqlDataAdapter daEmployees;
		internal System.Data.SqlClient.SqlCommand cmSelectEmployees;
		internal System.Data.SqlClient.SqlDataAdapter daProducts;
		internal System.Data.SqlClient.SqlDataAdapter daCustomers;
		internal System.Data.SqlClient.SqlCommand cmSelectCustomers;
		internal System.Data.SqlClient.SqlCommand cmInsertCustomers;
		internal System.Data.SqlClient.SqlCommand cmUpdateCustomers;
		internal System.Data.SqlClient.SqlCommand cmDeleteCustomers;
		internal System.Data.SqlClient.SqlCommand cmSelectProducts;
		internal System.Data.SqlClient.SqlDataAdapter daOrders;
		internal System.Data.SqlClient.SqlCommand cmSelectOrders;
		internal System.Data.SqlClient.SqlCommand cmInsertOrders;
		internal System.Data.SqlClient.SqlCommand cmUpdateOrders;
		internal System.Data.SqlClient.SqlCommand cmDeleteOrders;
		internal System.Data.SqlClient.SqlDataAdapter daOrderDetails;
		internal System.Data.SqlClient.SqlCommand cmSelectOrderDetails;
		internal System.Data.SqlClient.SqlCommand cmInsertOrderDetails;
		internal System.Data.SqlClient.SqlCommand cmUpdateOrderDetails;
		internal System.Data.SqlClient.SqlConnection cnNorthwindInstructor;
		internal System.Data.SqlClient.SqlCommand cmDeleteOrderDetails;
	

		public SalesManager()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		internal void InitializeComponent()
		{
			this.daOrders = new System.Data.SqlClient.SqlDataAdapter();
			this.cmDeleteOrders = new System.Data.SqlClient.SqlCommand();
			this.cnNorthwind = new System.Data.SqlClient.SqlConnection();
			this.cmInsertOrders = new System.Data.SqlClient.SqlCommand();
			this.cmSelectOrders = new System.Data.SqlClient.SqlCommand();
			this.cmUpdateOrders = new System.Data.SqlClient.SqlCommand();
			this.daProducts = new System.Data.SqlClient.SqlDataAdapter();
			this.cmSelectProducts = new System.Data.SqlClient.SqlCommand();
			this.cmInsertOrderDetails = new System.Data.SqlClient.SqlCommand();
			this.cmInsertCustomers = new System.Data.SqlClient.SqlCommand();
			this.daCustomers = new System.Data.SqlClient.SqlDataAdapter();
			this.cmDeleteCustomers = new System.Data.SqlClient.SqlCommand();
			this.cmSelectCustomers = new System.Data.SqlClient.SqlCommand();
			this.cmUpdateCustomers = new System.Data.SqlClient.SqlCommand();
			this.cmDeleteOrderDetails = new System.Data.SqlClient.SqlCommand();
			this.cmSelectEmployees = new System.Data.SqlClient.SqlCommand();
			this.cnNorthwindInstructor = new System.Data.SqlClient.SqlConnection();
			this.daEmployees = new System.Data.SqlClient.SqlDataAdapter();
			this.cmUpdateOrderDetails = new System.Data.SqlClient.SqlCommand();
			this.cmSelectOrderDetails = new System.Data.SqlClient.SqlCommand();
			this.daOrderDetails = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// daOrders
			// 
			this.daOrders.DeleteCommand = this.cmDeleteOrders;
			this.daOrders.InsertCommand = this.cmInsertOrders;
			this.daOrders.SelectCommand = this.cmSelectOrders;
			this.daOrders.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "Orders", new System.Data.Common.DataColumnMapping[] {
																																																		 new System.Data.Common.DataColumnMapping("OrderID", "OrderID"),
																																																		 new System.Data.Common.DataColumnMapping("OrderDate", "OrderDate"),
																																																		 new System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"),
																																																		 new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID")})});
			this.daOrders.UpdateCommand = this.cmUpdateOrders;
			// 
			// cmDeleteOrders
			// 
			this.cmDeleteOrders.CommandText = "[DeleteOrders]";
			this.cmDeleteOrders.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmDeleteOrders.Connection = this.cnNorthwind;
			this.cmDeleteOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmDeleteOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrderID", System.Data.DataRowVersion.Original, null));
			this.cmDeleteOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null));
			this.cmDeleteOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EmployeeID", System.Data.DataRowVersion.Original, null));
			this.cmDeleteOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrderDate", System.Data.DataRowVersion.Original, null));
			// 
			// cnNorthwind
			// 
			this.cnNorthwind.ConnectionString = "data source=(local);initial catalog=Northwind;integrated security=SSPI;persist se" +
				"curity info=False;packet size=4096";
			// 
			// cmInsertOrders
			// 
			this.cmInsertOrders.CommandText = "[InsertOrders]";
			this.cmInsertOrders.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmInsertOrders.Connection = this.cnNorthwind;
			this.cmInsertOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmInsertOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderDate", System.Data.SqlDbType.DateTime, 8, "OrderDate"));
			this.cmInsertOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"));
			this.cmInsertOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"));
			// 
			// cmSelectOrders
			// 
			this.cmSelectOrders.CommandText = "[SelectOrders]";
			this.cmSelectOrders.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmSelectOrders.Connection = this.cnNorthwind;
			this.cmSelectOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmSelectOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"));
			// 
			// cmUpdateOrders
			// 
			this.cmUpdateOrders.CommandText = "[UpdateOrders]";
			this.cmUpdateOrders.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmUpdateOrders.Connection = this.cnNorthwind;
			this.cmUpdateOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmUpdateOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderDate", System.Data.SqlDbType.DateTime, 8, "OrderDate"));
			this.cmUpdateOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Param1", System.Data.SqlDbType.Int, 4, "EmployeeID"));
			this.cmUpdateOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"));
			this.cmUpdateOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrderID", System.Data.DataRowVersion.Original, null));
			this.cmUpdateOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null));
			this.cmUpdateOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EmployeeID", System.Data.DataRowVersion.Original, null));
			this.cmUpdateOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrderDate", System.Data.DataRowVersion.Original, null));
			this.cmUpdateOrders.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, "OrderID"));
			// 
			// daProducts
			// 
			this.daProducts.SelectCommand = this.cmSelectProducts;
			this.daProducts.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								 new System.Data.Common.DataTableMapping("Table", "Products", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("ProductID", "ProductID"),
																																																			 new System.Data.Common.DataColumnMapping("ProductName", "ProductName"),
																																																			 new System.Data.Common.DataColumnMapping("UnitPrice", "UnitPrice")})});
			// 
			// cmSelectProducts
			// 
			this.cmSelectProducts.CommandText = "SELECT ProductID, ProductName, UnitPrice FROM Products";
			this.cmSelectProducts.Connection = this.cnNorthwind;
			// 
			// cmInsertOrderDetails
			// 
			this.cmInsertOrderDetails.CommandText = "[InsertOrderDetails]";
			this.cmInsertOrderDetails.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmInsertOrderDetails.Connection = this.cnNorthwind;
			this.cmInsertOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmInsertOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, "OrderID"));
			this.cmInsertOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProductID", System.Data.SqlDbType.Int, 4, "ProductID"));
			this.cmInsertOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, "UnitPrice"));
			this.cmInsertOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Quantity", System.Data.SqlDbType.SmallInt, 2, "Quantity"));
			// 
			// cmInsertCustomers
			// 
			this.cmInsertCustomers.CommandText = "[InsertCustomers]";
			this.cmInsertCustomers.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmInsertCustomers.Connection = this.cnNorthwind;
			this.cmInsertCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmInsertCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"));
			this.cmInsertCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"));
			this.cmInsertCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, "ContactName"));
			this.cmInsertCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"));
			this.cmInsertCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 24, "Phone"));
			// 
			// daCustomers
			// 
			this.daCustomers.DeleteCommand = this.cmDeleteCustomers;
			this.daCustomers.InsertCommand = this.cmInsertCustomers;
			this.daCustomers.SelectCommand = this.cmSelectCustomers;
			this.daCustomers.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "Customers", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
																																																			   new System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"),
																																																			   new System.Data.Common.DataColumnMapping("ContactName", "ContactName"),
																																																			   new System.Data.Common.DataColumnMapping("City", "City"),
																																																			   new System.Data.Common.DataColumnMapping("Phone", "Phone")})});
			this.daCustomers.UpdateCommand = this.cmUpdateCustomers;
			// 
			// cmDeleteCustomers
			// 
			this.cmDeleteCustomers.CommandText = "[DeleteCustomers]";
			this.cmDeleteCustomers.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmDeleteCustomers.Connection = this.cnNorthwind;
			this.cmDeleteCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmDeleteCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null));
			this.cmDeleteCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "City", System.Data.DataRowVersion.Original, null));
			this.cmDeleteCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompanyName", System.Data.DataRowVersion.Original, null));
			this.cmDeleteCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactName", System.Data.DataRowVersion.Original, null));
			this.cmDeleteCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Phone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Phone", System.Data.DataRowVersion.Original, null));
			// 
			// cmSelectCustomers
			// 
			this.cmSelectCustomers.CommandText = "[SelectCustomers]";
			this.cmSelectCustomers.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmSelectCustomers.Connection = this.cnNorthwind;
			this.cmSelectCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmSelectCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"));
			// 
			// cmUpdateCustomers
			// 
			this.cmUpdateCustomers.CommandText = "[UpdateCustomers]";
			this.cmUpdateCustomers.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmUpdateCustomers.Connection = this.cnNorthwind;
			this.cmUpdateCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmUpdateCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"));
			this.cmUpdateCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"));
			this.cmUpdateCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, "ContactName"));
			this.cmUpdateCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"));
			this.cmUpdateCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 24, "Phone"));
			this.cmUpdateCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CustomerID", System.Data.DataRowVersion.Original, null));
			this.cmUpdateCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "City", System.Data.DataRowVersion.Original, null));
			this.cmUpdateCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "CompanyName", System.Data.DataRowVersion.Original, null));
			this.cmUpdateCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ContactName", System.Data.DataRowVersion.Original, null));
			this.cmUpdateCustomers.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Phone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Phone", System.Data.DataRowVersion.Original, null));
			// 
			// cmDeleteOrderDetails
			// 
			this.cmDeleteOrderDetails.CommandText = "[DeleteOrderDetails]";
			this.cmDeleteOrderDetails.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmDeleteOrderDetails.Connection = this.cnNorthwind;
			this.cmDeleteOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmDeleteOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrderID", System.Data.DataRowVersion.Original, null));
			this.cmDeleteOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProductID", System.Data.DataRowVersion.Original, null));
			this.cmDeleteOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Quantity", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Quantity", System.Data.DataRowVersion.Original, null));
			this.cmDeleteOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UnitPrice", System.Data.DataRowVersion.Original, null));
			// 
			// cmSelectEmployees
			// 
			this.cmSelectEmployees.CommandText = "SELECT EmployeeID, LastName + \', \' + FirstName AS FullName FROM EmployeesLatest O" +
				"RDER BY LastName, FirstName";
			this.cmSelectEmployees.Connection = this.cnNorthwindInstructor;
			// 
			// cnNorthwindInstructor
			// 
			this.cnNorthwindInstructor.ConnectionString = "data source=localhost;initial catalog=Northwind;user id=MaryJane;password=secret;" +
				"persist security info=False;packet size=4096";
			// 
			// daEmployees
			// 
			this.daEmployees.SelectCommand = this.cmSelectEmployees;
			this.daEmployees.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "Employees", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"),
																																																			   new System.Data.Common.DataColumnMapping("FullName", "FullName")})});
			// 
			// cmUpdateOrderDetails
			// 
			this.cmUpdateOrderDetails.CommandText = "[UpdateOrderDetails]";
			this.cmUpdateOrderDetails.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmUpdateOrderDetails.Connection = this.cnNorthwind;
			this.cmUpdateOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmUpdateOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, "OrderID"));
			this.cmUpdateOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProductID", System.Data.SqlDbType.Int, 4, "ProductID"));
			this.cmUpdateOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, "UnitPrice"));
			this.cmUpdateOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Quantity", System.Data.SqlDbType.SmallInt, 2, "Quantity"));
			this.cmUpdateOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrderID", System.Data.DataRowVersion.Original, null));
			this.cmUpdateOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProductID", System.Data.DataRowVersion.Original, null));
			this.cmUpdateOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Quantity", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Quantity", System.Data.DataRowVersion.Original, null));
			this.cmUpdateOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UnitPrice", System.Data.DataRowVersion.Original, null));
			// 
			// cmSelectOrderDetails
			// 
			this.cmSelectOrderDetails.CommandText = "[SelectOrderDetails]";
			this.cmSelectOrderDetails.CommandType = System.Data.CommandType.StoredProcedure;
			this.cmSelectOrderDetails.Connection = this.cnNorthwind;
			this.cmSelectOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.cmSelectOrderDetails.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"));
			// 
			// daOrderDetails
			// 
			this.daOrderDetails.DeleteCommand = this.cmDeleteOrderDetails;
			this.daOrderDetails.InsertCommand = this.cmInsertOrderDetails;
			this.daOrderDetails.SelectCommand = this.cmSelectOrderDetails;
			this.daOrderDetails.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									 new System.Data.Common.DataTableMapping("Table", "OrderDetails", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("OrderID", "OrderID"),
																																																					 new System.Data.Common.DataColumnMapping("ProductID", "ProductID"),
																																																					 new System.Data.Common.DataColumnMapping("UnitPrice", "UnitPrice"),
																																																					 new System.Data.Common.DataColumnMapping("Quantity", "Quantity")})});
			this.daOrderDetails.UpdateCommand = this.cmUpdateOrderDetails;

		}
		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
		}

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

		[WebMethod]
		public OnTheRoadWS.NWDataSet GetDataSet(System.Int32 iEmployeeID, System.String sServerName)
		{
			// TODO: instantiate the data set

			OnTheRoadWS.NWDataSet tempNW = new OnTheRoadWS.NWDataSet();

			// TODO: set connection string using new server name

			this.cnNorthwind.ConnectionString = 
			"data source=" + sServerName + ";" +
			"initial catalog=Northwind;" +
			"integrated security=SSPI;" +
			"persist security info=False;";

			// TODO: connect to SQL Server

			this.cnNorthwind.Open();

			// fill the Employees DataTable
			this.daEmployees.Fill(tempNW.Employees);

			// fill the Products DataTable
			this.daProducts.Fill(tempNW.Products);

			// fill the Customers DataTable
			this.daCustomers.SelectCommand.Parameters["@EmployeeID"].Value = iEmployeeID;
			this.daCustomers.Fill(tempNW.Customers);

			// fill the Orders DataTable
			this.daOrders.SelectCommand.Parameters["@EmployeeID"].Value = iEmployeeID;
			this.daOrders.Fill(tempNW.Orders);

			// fill the Order Details DataTable
			this.daOrderDetails.SelectCommand.Parameters["@EmployeeID"].Value = iEmployeeID;
			this.daOrderDetails.Fill(tempNW.OrderDetails);

			this.cnNorthwind.Close();

			return tempNW;
		}

		[WebMethod]
		public void UpdateDatabase(OnTheRoadWS.NWDataSet dsNorthwind)
		{
			// TODO: set connection string using new server name

			this.cnNorthwind.ConnectionString = 
				"data source=" + dsNorthwind.AppSettings.Rows[0]["ServerName"] + ";" +
				"initial catalog=Northwind;" +
				"integrated security=SSPI;" +
				"persist security info=False;";

			// update the central database

			// we need to create a complete DataSet for inserts so that when a new
			// order is inserted, and a new OrderID assigned by SQL Server, that value
			// is propagated through to related OrderDetail rows
			DataSet dsInserts = dsNorthwind.GetChanges(DataRowState.Added);

			// these variables are only used to check if new rows have been added
			DataTable dtInsertCustomers = dsNorthwind.Tables["Customers"].GetChanges(DataRowState.Added);
			DataTable dtInsertOrders = dsNorthwind.Tables["Orders"].GetChanges(DataRowState.Added);
			DataTable dtInsertOrderDetails = dsNorthwind.Tables["OrderDetails"].GetChanges(DataRowState.Added);

			DataTable dtUpdateCustomers = dsNorthwind.Tables["Customers"].GetChanges(DataRowState.Modified);
			DataTable dtUpdateOrders = dsNorthwind.Tables["Orders"].GetChanges(DataRowState.Modified);
			DataTable dtUpdateOrderDetails = dsNorthwind.Tables["OrderDetails"].GetChanges(DataRowState.Modified);

			DataTable dtDeleteCustomers = dsNorthwind.Tables["Customers"].GetChanges(DataRowState.Deleted);
			DataTable dtDeleteOrders = dsNorthwind.Tables["Orders"].GetChanges(DataRowState.Deleted);
			DataTable dtDeleteOrderDetails = dsNorthwind.Tables["OrderDetails"].GetChanges(DataRowState.Deleted);

			this.cnNorthwind.Open();

			// INSERT statements must be ordered parent -> child

			if (dtInsertCustomers != null) 
			{
				this.daCustomers.Update(dsInserts.Tables["Customers"]);
			}

			if (dtInsertOrders != null) 
			{
				this.daOrders.Update(dsInserts.Tables["Orders"]);
			}

			if (dtInsertOrderDetails != null) 
			{
				this.daOrderDetails.Update(dsInserts.Tables["OrderDetails"]);
			}

			// UPDATE statements must be ordered parent -> child

			if (dtUpdateCustomers != null)
			{
				this.daCustomers.Update(dtUpdateCustomers);
			}

			if (dtUpdateOrders != null)
			{
				this.daOrders.Update(dtUpdateOrders);
			}

			if (dtUpdateOrderDetails != null)
			{
				this.daOrderDetails.Update(dtUpdateOrderDetails);
			}

			// DELETE statements must be ordered child -> parent

			if (dtDeleteOrderDetails != null)
			{
				this.daOrderDetails.Update(dtDeleteOrderDetails);
			}

			if (dtDeleteOrders != null)
			{
				this.daOrders.Update(dtDeleteOrders);
			}

			if (dtDeleteCustomers != null)
			{
				this.daCustomers.Update(dtDeleteCustomers);
			}

			this.cnNorthwind.Close();

		}
	}
}
