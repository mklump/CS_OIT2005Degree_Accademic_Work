using System;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using AsyncClient.net.xmethods.services;
using System.IO;

namespace AsyncClient
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	[WebServiceBinding("MyBinding", "http://www.themindelectric.com/wsdl/net.xmethods.services.stockquote.StockQuote/")]
	class AsyncClientClass : SoapHttpClientProtocol
	{
		public static string [] stocknames;

		public AsyncClientClass()
		{
			stocknames = new string[] { "MSFT-Q", "INTC-Q", "MENT-Q", "IBM-N", "SUNW-Q" };
		}
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			new AsyncClientClass();
			netxmethodsservicesstockquoteStockQuoteService myQuotes =
				new netxmethodsservicesstockquoteStockQuoteService();
			IAsyncResult [] asi = new IAsyncResult[stocknames.Length];
			WaitHandle [] wh = new WaitHandle[stocknames.Length];
			for(int x = 0; x < stocknames.Length; ++x)
			{
				asi[x] = myQuotes.BegingetQuote(stocknames[x],
					new AsyncCallback( CallBack ), myQuotes);
				wh[x] = asi[x].AsyncWaitHandle;
			}
			WaitHandle.WaitAny( wh );
		}

		private static void CallBack(IAsyncResult isa)
		{
			netxmethodsservicesstockquoteStockQuoteService s =
				(netxmethodsservicesstockquoteStockQuoteService) isa.AsyncState;
			StreamWriter writer = new StreamWriter( "output.txt", true );
			foreach(string str in stocknames )
				writer.Write( str + " is now: {0}\n" ,s.EndgetQuote( isa ) );
		}
	}
}
