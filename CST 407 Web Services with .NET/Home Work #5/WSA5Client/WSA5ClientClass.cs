using System;
using WSA5NameSpace.com.klump_pdx.matthew;
//using WSA5NameSpace.localhost;

namespace WSA5NameSpace
{
	/// <summary>
	/// Summary description for WSA5ClientClass.
	/// </summary>
	public class WSA5ClientClass
	{
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public WSA5ClientClass()
		{
		}
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			WSA5 assignment5WebService = new WSA5();
			if( false == assignment5WebService.PlaceOrder(new Customer(), new Order(), 0.0) )
				assignment5WebService.Login( 0, 0, "", 123456 );

			Customer customerX = new Customer();
			customerX.CustomerID = 99;
			customerX.CompanyName = "Corillian";
			customerX.custOrder = new Order();
			customerX.custOrder.orders = new OrderDetail[1];
			customerX.custOrder.orders[0].orderingCustomer = new Customer();
			customerX.custOrder.orders[0].orderingCustomer = customerX;
			customerX.custOrder.orders[0] = new OrderDetail();
			customerX.custOrder.orders[0].OrderID = 1;
			customerX.custOrder.orders[0].product = new Product();
			customerX.custOrder.orders[0].product.category = new Category();
			customerX.custOrder.orders[0].product.category.CategoryName = "General";
			customerX.custOrder.orders[0].product.category.CategoryID = 2;
			customerX.custOrder.orders[0].product.Discontinued = false;
			customerX.custOrder.orders[0].product.ProductID = 10;
			customerX.custOrder.orders[0].product.ProductName = "Marmelaid";
			customerX.custOrder.orders[0].product.supply = new Supply();
			customerX.custOrder.orders[0].product.supply.supplier = new Supplier[1];
			customerX.custOrder.orders[0].product.supply.supplier[0] = new Supplier();
			customerX.custOrder.orders[0].product.supply.supplier[0].CompanyName = "Supplier Inc.";
			customerX.custOrder.orders[0].product.supply.supplier[0].SupplierID = 121;
			customerX.custOrder.orders[0].Quantity = 10;
			customerX.custOrder.orders[0].UnitPrice = 9.99;

			Console.WriteLine("The new order placement status is: {0}.",
				assignment5WebService.PlaceOrder( customerX, customerX.custOrder, 9.99 ) );
			Console.WriteLine("The number of Orders that were placed for customerX is: {0}.",
				customerX.custOrder.orders.Length);
		}
	}
}
