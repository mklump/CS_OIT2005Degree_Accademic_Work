using System;

namespace SMSClient
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class SMSClientClass
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
			SMSClient.com.dotnetisp.smsserver.ServiceSMS mySMS =
				new SMSClient.com.dotnetisp.smsserver.ServiceSMS();

			Console.WriteLine( "The SendSmsText() message value is: {0}",
				mySMS.SendSmsText( "mklump", "aaaa1111", null, null, "Mateo!", "5039575985") );

			Console.WriteLine("{0}", mySMS.GetStatus("123456") );

			Console.WriteLine("{0}", mySMS.GetCredit( "mklump", "aaaa1111", "SMSClient" ) );
		}
	}
}
