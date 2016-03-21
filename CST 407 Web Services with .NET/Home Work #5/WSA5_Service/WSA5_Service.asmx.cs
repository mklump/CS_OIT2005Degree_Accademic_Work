using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Xml.Serialization;
using System.Web.Services;
using System.IO;
using System.Web.Services.Protocols;
using NorthWind_DataNameSpace;

namespace WSA_Assignment5
{
	/// <summary>
	/// Summary description for WSA5.
	/// </summary>
	[WebService(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/")]
	public class WSA5 : System.Web.Services.WebService
	{
		/// <summary>
		/// The is the Data object these web services will act through.
		/// </summary>
		public Data data;
		public _Session session;

		/// <summary>
		/// WAS5 web service class default constructor
		/// </summary>
		public WSA5()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

		/// <summary>
		/// Saves the current service related.
		/// </summary>
		/// <param name="data"></param>
		private void SaveData( Data data )
		{
			XmlSerializer ser = new XmlSerializer( typeof(Data) );
			FileStream stream = new FileStream(
				"http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/data.xml",
				FileMode.OpenOrCreate );
			ser.Serialize( stream, data );
			stream.Close();
		}

		/// <summary>
		/// Gets the current service related data.
		/// </summary>
		/// <returns></returns>
		private Data GetData()
		{
			XmlSerializer ser = new XmlSerializer( typeof(Data) );
			FileStream stream = new FileStream(
				"http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/data.xml",
				FileMode.Open );
			Data retData = (Data) ser.Deserialize( stream );
			stream.Close();
			return retData;
		}

		/// <summary>
		/// Accepts a customer ID or employee ID for authentication.
		/// Returns the current session token.
		/// </summary>
		/// <param name="text"></param>
		/// <returns>Returns the current session token.</returns>
		private string AddToSession( string text )
		{
			string str = (string) Session["text"];
			str += text;
			Session["text"] = str;
			return str;
		}

		/// <summary>
		/// Checks the current session and logged in status.
		/// Returns true if still authenticated and false if not.
		/// </summary>
		/// <returns>Returns true if still authenticated and false if not.</returns>
		private bool CheckSession()
		{
			if( data._session.terminate.Terminated == true ||
				data._session.initiate.expires.Ticks >= DateTime.Now.Ticks
				)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Accepts employee_ID or customer_ID as your Customer or Employer respectively,
		/// and Name as your Last name if your a customer or Company Name if you are a
		/// corporate customer.
		/// Returns true if you were logged successfully, and false if not.
		/// Note: This method must be called first to interact with any other
		/// services provided, accept if the correct admin password is provided.
		/// </summary>
		/// <param name="employee_ID"></param>
		/// <param name="customer_ID"></param>
		/// <param name="Name"></param>
		/// <param name="admin"></param>
		/// <returns>True if you were logged successfully, and false if not.</returns>
		[WebMethod]
		[SoapHeader("session", Direction=SoapHeaderDirection.InOut)]
		public bool Login( int employee_ID, int customer_ID, string Name, int admin )
		{
			data = new Data();
			session = data._session;
			Employee [] allEmployees = GetAllEmployees();
			IEnumerator iter = allEmployees.GetEnumerator();
			while( iter.MoveNext() )
			{
				Employee emp = (Employee) iter.Current;
				if( emp.EmployeeID == employee_ID && emp.LastName == Name )
				{
					// Build the session token and set terminated flag to false for employee.
					data._session = new _Session( AddToSession(employee_ID.ToString()) );
					SaveData( data );
					return true;
				}
			}
			Customer [] allCustomers = GetAllCustomers();
			iter = allCustomers.GetEnumerator();
			while( iter.MoveNext() )
			{
				Customer cust = (Customer) iter.Current;
				if( cust.CustomerID == customer_ID && cust.CompanyName == Name )
				{
					// Build the session token and set terminated flag to false for customer.
					data._session = new _Session( AddToSession(customer_ID.ToString()) );
					SaveData( data );
					return true;
				}
			}
			if( admin == 123456 )
			{
				// Build the session token and set terminated flag to false for customer.
				data._session = new _Session( "123456" );
				SaveData( data );
				return true;
			}
			return false;
		}

		[WebMethod]
		[SoapHeader("session", Direction=SoapHeaderDirection.InOut)]
		public Category[] GetAllGategories( Order custOrder )
		{
			if( CheckSession() )
			{
				// Get the updated data sets.
				data = GetData();
				return data.category.GetAllCategories( custOrder );
			}
			else
				return null;
		}

		[WebMethod]
		[SoapHeader("session", Direction=SoapHeaderDirection.InOut)]
		public Product[] GetAllProductsByCategory( Order orderSource, Category itemQuery )
		{
			if( CheckSession() )
			{
				// Get the updated data sets.
				data = GetData();
				return data.category.GetAllProductsByCategory( orderSource, itemQuery );
			}
			else
				return null;
		}

		[WebMethod]
		[SoapHeader("session", Direction=SoapHeaderDirection.InOut)]
		public Customer[] GetAllCustomers()
		{
			if( CheckSession() )
			{
				// Get the updated data sets.
				data = GetData();
				return data.customer.GetAllCustomers();
			}
			else
				return null;
		}

		[WebMethod]
		[SoapHeader("session", Direction=SoapHeaderDirection.InOut)]
		public Employee[] GetAllEmployees()
		{
			if( CheckSession() )
			{
				// Get the updated data sets.
				data = GetData();
				return data.employee.GetAllEmployees();
			}
			else
				return null;
		}

		[WebMethod]
		[SoapHeader("session", Direction=SoapHeaderDirection.InOut)]
		public OrderDetail[] GetAllOrders()
		{
			if( CheckSession() )
			{
				// Get the updated data sets.
				data = GetData();
				return data.order.GetAllOrders();
			}
			else
				return null;
		}

		[WebMethod]
		[SoapHeader("session", Direction=SoapHeaderDirection.InOut)]
		public bool PlaceOrder( Customer orderingCustomer, Order neworders, double ammountEnclosed )
		{
			if( CheckSession() )
			{
				// Get the updated data sets.
				data = GetData();
				bool result = data.customer.PlaceOrder( orderingCustomer, neworders, ammountEnclosed );
				SaveData( data );
				return result;
			}
			else
				return false;
		}
	}
}
