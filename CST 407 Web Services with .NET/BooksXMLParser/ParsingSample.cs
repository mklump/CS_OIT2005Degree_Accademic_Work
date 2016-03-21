using System;
using System.Xml;
using System.IO;

namespace XmlParsing
{
	public class ParsingClass
	{
		/// <summary>
		/// Main execution portion of the program
		/// </summary>
		[STAThread]
		public static void Main()
		{
			XmlDocument document = new XmlDocument();
			document.Load(@"C:\Documents and Settings\Nostro\My Documents\Visual Studio Projects\Accademic_Work\CST 407 Web Services with .NET\books.xml");
			XmlNode root = document.DocumentElement;
			Console.WriteLine("Count: {0}",  root.ChildNodes.Count);
			foreach(XmlNode element in root.ChildNodes)
			{
				Console.WriteLine("Title: {0}", element.ChildNodes[1].FirstChild.Value);
				if(element.Name == "book")
				{
					foreach(XmlNode sub in element.ChildNodes)
					{
						XmlNodeList list = sub.ChildNodes;
						if(sub.Name == "title")
						{
							Console.WriteLine(sub.FirstChild.Value);
						}
					}
				}
			}
		}
	}
}

