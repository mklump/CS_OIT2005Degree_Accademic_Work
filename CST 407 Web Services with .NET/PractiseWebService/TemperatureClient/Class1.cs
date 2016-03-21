using System;

namespace TemperatureClient
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
			if(args.Length < 1)
			{
				Console.WriteLine("Usage: TemperaturClient.exe zipcode");
				return;
			}

			string zip = args[0];

			net.xmethods.www.TemperatureService temp = new TemperatureClient.net.xmethods.www.TemperatureService();

			Console.WriteLine("Temperature in {0}: {1}",zip,temp.getTemp(zip));

			Console.WriteLine("Press Enter to quit...");
			Console.ReadLine();
		}
	}
}
