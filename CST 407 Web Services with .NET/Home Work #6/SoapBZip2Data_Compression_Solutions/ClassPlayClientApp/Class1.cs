using System;
using Service1;
using ClientApp.ExtHelloWorld;

namespace ClientApp {
	class Class1 {
		[STAThread]
		static void Main(string[] args) {
			ExtHelloWorld.Service1 service = new ClientApp.ExtHelloWorld.Service1();
			string answer = service.HelloWorld();
			Console.WriteLine( answer );
			Console.ReadLine();
		}
	}
}
