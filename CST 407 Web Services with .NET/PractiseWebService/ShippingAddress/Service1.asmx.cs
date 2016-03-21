using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace ShippingAddress
{
	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	public class Service1 : System.Web.Services.WebService
	{
		public Service1()
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

		// WEB SERVICE EXAMPLE
		// The HelloWorld() example service returns the string Hello World
		// To build, uncomment the following lines then save and build the project
		// To test this web service, press F5

		/// <summary>
		/// Returns the caculated shipping cost based on the Original Zipcode,
		/// the Destination Zipcode, and the Shipping Weight.
		/// </summary>
		/// <param name="OrigZipCode"></param>
		/// <param name="DestZipCode"></param>
		/// <param name="ShippingWeight"></param>
		/// <returns>Returns the cost as a double.</returns>
		[WebMethod]
		public double
			CalculateShippingCost( string OrigZipCode, 
								   string DestZipCode,
								   double ShippingWeight )
		{
			// returns shipping cost
			Random myNum = new Random();
			return Convert.ToDouble(myNum.NextDouble().ToString("C"));
		}
		/// <summary>
		/// Gets the tracking number for a given address destination.
		/// </summary>
		/// <param name="Destination"></param>
		/// <returns>Returns the tracking number as a string.</returns>
		[WebMethod]
		public string GetTrackingNumber( Address Destination )
		{
			Random myNum = new Random();
			return Convert.ToString(myNum.Next(9999999));
		}
	}

	public class Address
	{
		public string StreetAddress;
		public string City;
		public string State;
		public string Zip;
	}
}
