using System;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace XmlDeserialization_Practise
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Practise
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			XmlSerializer serializer = new XmlSerializer( typeof(order) );
			XmlReader reader = new XmlTextReader("order.xml");

			order myOrders = (order) serializer.Deserialize( reader );
			Console.Write("Order Number: {0}\nSend To Address:\n\tStreet: " +
				"{1}\n\t City: {2}\n\t State: {3}\nItems:\n\t Item #{4}\n\t\tItem Name: {5}" +
				"\n\t\tItem Unit Price: {6}\n\t Item #{7}\n\t\tItem Name: " +
				"{8}\n\t\tItem Unit Price: {9}\n", myOrders.orderNum,
				myOrders.SendToAddress[0].street, myOrders.SendToAddress[0].city,
				myOrders.SendToAddress[0].state, myOrders.items[0].number,
				myOrders.items[0].name, myOrders.items[0].unit_price,
				myOrders.items[1].number, myOrders.items[1].name,
				myOrders.items[1].unit_price);

			reader.Close();
		}
	}
}
