using System;
using System.Collections;
using System.Xml.Serialization;
using WSA_Assignment5;
using System.Web.Services.Protocols;

//using ConsoleClientAssignment4.net.cauldwell;

namespace NorthWind_DataNameSpace
{
	#region "Client code for development and testing only."
	/// <summary>
	/// Summary description for NorthWind.
	/// </summary>
	class NorthWindMain
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Customer customerX = new Customer( 99, "Corillian" );
			Order order = new Order();
			order.orders[0] = new OrderDetail();
			
			order.orders = new OrderDetail[1];
			order.orders[0].orderingCustomer = customerX;
			order.orders[0].OrderID = 1;
			order.orders[0].product.category.CategoryName = "General";
			order.orders[0].product.category.CategoryID = 2;
			order.orders[0].product.Discontinued = false;
			order.orders[0].product.ProductID = 10;
			order.orders[0].product.ProductName = "Marmelaid";
			order.orders[0].product.supply.supplier = new Supplier[1];
			order.orders[0].product.supply.supplier[0] = new Supplier();
			order.orders[0].product.supply.supplier[0].CompanyName = "Supplier Inc.";
			order.orders[0].product.supply.supplier[0].SupplierID = 121;
			order.orders[0].Quantity = 10;
			order.orders[0].UnitPrice = 9.99;

			Console.WriteLine("The new order placement status is: {0}.",
				customerX.PlaceOrder(customerX, order, 9.99) );
			Console.WriteLine("The number of Orders that were placed for customerX is: {0}.",
				order.orders.Length);
		}
	}
	#endregion

	/// <summary>
	/// Class Data
	/// </summary>
	public class Data
	{
		public _Session _session;
		public Category category;
		public Customer customer;
		public Employee employee;
		public Order order;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Data()
		{
			_session = new _Session();
			category = new Category();
			customer = new Customer();
			employee = new Employee();
			order = new Order();
		}
	}

	/// <summary>
	/// Class _Session
	/// </summary>
	[XmlRoot(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/WSA5_WebService/Session")]
	public class _Session : SoapHeader
	{
		private string _ID;
		private Initiate _Initiate;
		private Terminate _Terminate;

		/// <summary>
		/// Default constructor
		/// </summary>
		public _Session()
		{
			_ID = "";
			_Initiate = new Initiate();
			_Terminate = new Terminate();
			_Terminate.Terminated = false;
		}
		/// <summary>
		/// Single arguement consrtuctor
		/// </summary>
		/// <param name="ID"></param>
		public _Session( string ID )
		{
			_ID = ID + _Initiate.expires.ToLongTimeString();
			_Initiate = new Initiate();
			_Terminate = new Terminate();
			_Terminate.Terminated = false;
		}
		/// <summary>
		/// Property _ID (string)
		/// </summary>
		public string id
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
			}
		}
		/// <summary>
		/// Property _Initiate (Initiate)
		/// </summary>
		public Initiate initiate
		{
			get
			{
				return _Initiate;
			}
			set
			{
				_Initiate = value;
			}
		}
		/// <summary>
		/// Property _Terminate (Terminate)
		/// </summary>
		public Terminate terminate
		{
			get
			{
				return _Terminate;
			}
			set
			{
				_Terminate = value;
			}
		}
	}	
	
	/// <summary>
	/// Class Initiate
	/// </summary>
	public class Initiate
	{
		private DateTime _Expires;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Initiate()
		{
			_Expires = new DateTime( DateTime.Now.Ticks );
			// The current session will timeout in 30 minutes
			_Expires.AddMinutes( 30 );
		}
		/// <summary>
		/// Property _Expires (DateTime)
		/// </summary>
		public DateTime expires
		{
			get
			{
				return _Expires;
			}
			set
			{
				_Expires = value;
			}
		}
	}

	/// <summary>
	/// Class Terminate
	/// </summary>
	public class Terminate
	{
		private bool terminated;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Terminate()
		{
			terminated = true;
		}
		/// <summary>
		/// Property Terminated (bool)
		/// </summary>
		public bool Terminated
		{
			get
			{
				return terminated;
			}
			set
			{
				terminated = value;
			}
		}
	}
		
	/// <summary>
	/// Class Order
	/// </summary>
	public class Order
	{
		public OrderDetail [] orders;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Order()
		{
			orders = new OrderDetail[1];
		}
	
		/// <summary>
		/// Returns an OrderDetail[] structure representing
		/// all of the Orders.
		/// </summary>
		/// <returns></returns>
		public OrderDetail[] GetAllOrders()
		{
			return orders;
		}
	}

	/// <summary>
	/// Class OrderDetail
	/// </summary>
	public class OrderDetail
	{
		public int OrderID;
		public double UnitPrice;
		public int Quantity;
		public double Discount;
		public Product product;
		public Employee processingEmployee;
		public Customer orderingCustomer;

		/// <summary>
		/// Default constructor
		/// </summary>
		public OrderDetail()
		{
			OrderID = 0;
			Quantity = 0;
			UnitPrice = 0.0;
			Discount = 0.0;
			product = new Product();
			processingEmployee = new Employee();
			orderingCustomer = new Customer();
		}
	}	

	/// <summary>
	/// Class Employee
	/// </summary>
	public class Employee
	{
		public int EmployeeID;
		public string FirstName;
		public string LastName;
		public bool IsManager;
		public Order orderHandle;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Employee()
		{
			EmployeeID = 0;
			FirstName = "";
			LastName = "";
			IsManager = false;
			orderHandle = new Order();
		}

		public Employee[] GetAllEmployees()
		{
			int x = 0;
			WSA5 service = new WSA5();
			IEnumerator enumerator = service.data.order.orders.GetEnumerator();
			Employee [] empList = null;

			while( enumerator.MoveNext() )
			{
				empList[x] = new Employee();
				empList[x++] = (Employee) enumerator.Current;
			}
			return empList;
		}
	}
	
	/// <summary>
	/// Class Customer
	/// </summary>
	public class Customer
	{
		public int CustomerID;
		public double AmountPaid;
		public string CompanyName;
		public Order custOrder;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Customer()
		{
			CustomerID = 0;
			CompanyName = "";
			custOrder = new Order();
		}

		/// <summary>
		/// Two arguement constructor
		/// </summary>
		/// <param name="customerID"></param>
		/// <param name="companyname"></param>
		public Customer( int customerID, string companyname )
		{
			CustomerID = customerID;
			CompanyName = companyname;
		}

		/// <summary>
		/// Three arguement constructor
		/// </summary>
		/// <param name="customerid"></param>
		/// <param name="companyname"></param>
		/// <param name="customerOrder"></param>
		public Customer( int customerID, string companyname, Order customerOrder )
		{
			CustomerID = customerID;
			CompanyName = companyname;
			custOrder = customerOrder;
		}

		public Customer[] GetAllCustomers()
		{
			int x = 0;
			Customer [] custList = null;
			WSA5 service = new WSA5();
			IEnumerator enumerator = service.data.order.orders.GetEnumerator();
			while( enumerator.MoveNext() )
			{
				custList[x] = new Customer();
				custList[x++] = (Customer) enumerator.Current;
			}
			return custList;
		}

		/// <summary>
		/// </summary>
		/// <param name="neworder"></param>
		/// <returns></returns>
		
		/// <summary>
		/// The parameter "neworders" requires that all the data fields for
		/// this "Order" must be filled in.
		/// The return values indicates whether your order was placed or not.
		/// </summary>
		/// <param name="orderingCustomer"></param>
		/// <param name="processingEmployee"></param>
		/// <param name="neworder"></param>
		/// <param name="ammountEnclosed"></param>
		/// <returns>The return values indicates whether your order was placed or not.</returns>
		public bool PlaceOrder( Customer orderingCustomer, Order neworder, double ammountEnclosed )
		{
			for( int x = 0; x < neworder.orders.Length; ++x )
			{
				if( neworder.orders[x].orderingCustomer.CompanyName != "" ||
					neworder.orders[x].orderingCustomer.CustomerID != 0 ||
					neworder.orders[x].processingEmployee.EmployeeID != 0 ||
					neworder.orders[x].processingEmployee.FirstName != "" ||
					neworder.orders[x].processingEmployee.LastName != "" ||
					neworder.orders[x].OrderID == 0 ||
					neworder.orders[x].Quantity == 0 ||
					neworder.orders[x].UnitPrice == 0.0 ||
					neworder.orders[x].Discount == 0.0 ||
					neworder.orders[x].product.ProductName == "" ||
					neworder.orders[x].product.Discontinued == true ||
					neworder.orders[x].product.category.CategoryName == "" ||
					neworder.orders[x].product.supply.supplier[0].SupplierID == 0 ||
					neworder.orders[x].product.supply.supplier[0].CompanyName == "" )
				{
					return false;
				}
			}
			// Order placement succeeded
			Customer [] customers = GetAllCustomers();
			for( int x = 0; x < customers.Length; ++x )
			{
				if( customers[x] == orderingCustomer )
				{
					customers[x].custOrder = neworder;
					customers[x].AmountPaid = ammountEnclosed;
					return true;
				}
			}
			WSA5 service = new WSA5();
			// Customer is not in our records, create a new record.
			for( int x = 0; x < service.data.order.orders.Length; ++x )
			{
				service.data.order.orders[x].orderingCustomer = orderingCustomer;
				service.data.order.orders[x].orderingCustomer.custOrder = neworder;
				service.data.order.orders[x].orderingCustomer.AmountPaid = ammountEnclosed;
			}
			return true;
		}
	}
	
	/// <summary>
	/// Class Shipper
	/// </summary>
	public class Shipper
	{
		public int ShipperID;
		public string CompanyName;
		public Order shippingOrder;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Shipper()
		{
			ShipperID = 0;
			CompanyName = "";
			shippingOrder = new Order();
		}
	}
	
	/// <summary>
	/// Class Product
	/// </summary>
	public class Product
	{
		public int ProductID;
		public string ProductName;
		public bool Discontinued;
		public Category category;
		public Supply supply;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Product()
		{
			ProductID = 0;
			ProductName = "";
			Discontinued = true;
			category = new Category();
			supply = new Supply();
		}
	}
	
	/// <summary>
	/// Class Category
	/// </summary>
	public class Category
	{
		public int CategoryID;
		public string CategoryName;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Category()
		{
			CategoryID = 0;
			CategoryName = "";
		}

		/// <summary>
		/// Parameter "thisOrder" refers to the Order for which you
		/// wish to query all the product categories for.
		/// The return value is the set of all Categories for that Order.
		/// </summary>
		/// <param name="thisOrder"></param>
		/// <returns></returns>
		public Category[] GetAllCategories( Order thisOrder )
		{
			Category [] categories = null;
			for( int x = 0; x < thisOrder.orders.Length; ++x )
			{
				categories[x] = thisOrder.orders[x].product.category;
			}
			return categories;
		}

		/// <summary>
		/// Accepts a category to query all the products by, and the Order Set
		/// to search.
		/// Returns the set of all Products that have that Category.
		/// </summary>
		/// <param name="orderToSearch"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public Product[] GetAllProductsByCategory( Order orderToSearch, Category query )
		{
			int y = 0;
			Product [] categoryMatch = null;
			for( int x = 0; x < orderToSearch.orders.Length; ++x )
			{
				if( orderToSearch.orders[x].product.category.CategoryName == query.CategoryName &&
					orderToSearch.orders[x].product.category.CategoryID == query.CategoryID )
				{
					categoryMatch[y++] = orderToSearch.orders[x].product;
				}
			}
			return categoryMatch;
		}
	}
	
	/// <summary>
	/// Class Ship
	/// </summary>
	public class Supply
	{
		public Product[] product;
		public Supplier[] supplier;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Supply()
		{
			product = new Product[1];
			supplier = new Supplier[1];
		}
	}
	
	/// <summary>
	/// Class Supplier
	/// </summary>
	public class Supplier
	{
		public int SupplierID;
		public string CompanyName;
		public Supply supply;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Supplier()
		{
			SupplierID = 0;
			CompanyName = "";
			supply = new Supply();
		}
	}
	
}
