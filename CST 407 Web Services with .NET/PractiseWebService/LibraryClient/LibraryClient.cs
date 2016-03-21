using System;

namespace LibraryClient
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class cLibraryClient
	{
		private const int librarySize = 11;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			localhost.Service1 service = new LibraryClient.localhost.Service1();

			Console.WriteLine("Creat{1}",service.createLibray( librarySize ));
		}
	}
}
