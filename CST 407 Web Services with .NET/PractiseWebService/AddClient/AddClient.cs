using System;
using System.IO;

namespace AddClient
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//
			// TODO: Add code to start application here
			//
			localhost.Service1 s = new AddClient.localhost.Service1();

			localhost.Add a = new AddClient.localhost.Add();
			a.one = 1;
			a.two = 2;
			Console.WriteLine(s.Add( a ).result);
			Console.Read();
		}
	}
}
