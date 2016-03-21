using System;
//using ConsoleClientAssignment4.net.cauldwell;

namespace NorthWind_DataNameSpace
{

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
			order.orderingCustomer = customerX;
			order.orders = new OrderDetail[1];
			order.orders[0].OrderID = 1;
			order.orders[0].product.category.CategoryName = "General";
			order.orders[0].product.category.CategoryID = 2;
			order.orders[0].product.Discontinued = false;
			order.orders[0].product.ProductID = 10;
			order.orders[0].product.ProductName = "Marmelaid";
			order.orders[0].product.supply.supplier[0].CompanyName = "Supplier Inc.";
			order.orders[0].product.supply.supplier[0].SupplierID = 121;
			order.orders[0].Quantity = 10;
			order.orders[0].UnitPrice = 9.99;

			Console.WriteLine("The new order placement status is: {0}.", customerX.PlaceOrder(order) );
			Console.WriteLine("The number of Orders that were placed for customerX is: {0}.", order.orders.Length);
		}
	}

	/// <summary>
	/// Class Order
	/// </summary>
	public class Order
	{
		public OrderDetail [] orders;
		// IE the EmployeeID
		public Employee processingEmployee;
		// IE the CustomerID
		public Customer orderingCustomer;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Order()
		{
			// TODO: insert constructor code here
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

		/// <summary>
		/// Default constructor
		/// </summary>
		public OrderDetail()
		{
			OrderID = 0;
			Quantity = 0;
			UnitPrice = 0.0;
			Discount = 0.0;
			product.Discontinued = false;
			product.ProductName = "";
			product.ProductID = 0;
			product.supply.supplier[0].SupplierID = 0;
			product.supply.supplier[0].CompanyName = "";
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
		public Order [] orderHandle;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Employee()
		{
			// TODO: insert constructor code here
		}

		public Employee[] GetAllEmployees()
		{
			int x = 0;
			Employee [] empList = null;
			foreach( Order thisOrder in orderHandle )
			{
				empList[x] = new Employee();
				empList[x++] = thisOrder.processingEmployee;
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
		public string CompanyName;
		public Order custOrders;

		/// <summary>
		/// Default constructor
		/// </summary>
		public Customer()
		{
			CustomerID = 0;
			CompanyName = "";
			custOrders = null;
		}

		public Customer( int customerid, string companyname)
		{
			CustomerID = customerid;
			CompanyName = companyname;
			custOrders = null;
		}

		public Customer[] GetAllCustomers()
		{
			Customer [] custList = null;
			
			for( int x = 0; x < custOrders.orders.Length; ++x )
			{
				custList[x] = new Customer();
				custList[x++] = custOrders.orderingCustomer;
			}
			return custList;
		}

		/// <summary>
		/// The parameter "neworders" requires that all the data fields for
		/// this "Order" must be filled in.
		/// The return values indicates whether your order was placed or not.
		/// </summary>
		/// <param name="neworder"></param>
		/// <returns></returns>
		public bool PlaceOrder( Order neworders )
		{
			for( int x = 0; x < neworders.orders.Length; ++x )
			{
				if( neworders.orders[x].OrderID == 0 ||
					neworders.orders[x].Quantity == 0 ||
					neworders.orders[x].UnitPrice == 0.0 ||
					neworders.orders[x].Discount == 0.0 ||
					neworders.orders[x].product.ProductName == "" ||
					neworders.orders[x].product.Discontinued == true ||
					neworders.orders[x].product.category.CategoryName == "" ||
					neworders.orders[x].product.supply.supplier[0].SupplierID == 0 ||
					neworders.orders[x].product.supply.supplier[0].CompanyName == "" )
				{
					return false;
				}
			}
			// Order placement succeeded
			custOrders = neworders;
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
			// TODO: insert constructor code here
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
			// TODO: insert constructor code here
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
			// TODO: insert constructor code here
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
			// TODO: insert constructor code here
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
			// TODO: insert constructor code here
		}
	}
	
}
