// XML Sample Code:

using System;
using NUnit.Framework;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Collections;

namespace Tests
{
	[TestFixture] 
	public class XmlFun
	{
		[Test]
		public void IAmStupid()
		{
			//Store...query...get working fast...very slow imp...lot of memory
			XmlDocument x = new XmlDocument();
			x.Load("accounts.xml");
			//Way #1
			XmlNodeList list = x.GetElementsByTagName("Account");
			foreach(XmlNode node in list)
			{
				XmlElement numberElement = node["Number"];
				Trace.WriteLine(numberElement.InnerText);
			}
			//Way #2
			list = ((x["AccountList"])["Account"]).ChildNodes;
			foreach(XmlNode node in list)
			{
				Trace.WriteLine(node.InnerText);
			}
			XmlNodeList list_ =
				x.DocumentElement.SelectNodes("//Account[Number = '5635482']");
			foreach(XmlNode node in list_)
			{
				Trace.WriteLine(node.InnerText);
			}
			bool bSeenAvailableBalance = false;
			int i = 0;
			XmlTextReader tr = new XmlTextReader("accounts.xml");
			while (tr.Read())
			{
				i++;
				if (tr.Name == "AvailableBalance")
				{
					bSeenAvailableBalance = true;
				}
				switch (tr.NodeType) 
				{
					case XmlNodeType.Element:
						Trace.WriteLine(String.Format("<{0}>", tr.Name));
						break;
					case XmlNodeType.Text:
						Trace.WriteLine(tr.Value);
						if (bSeenAvailableBalance)
						{
							Trace.WriteLine(String.Format("WOOHOO! {0:C}", decimal.Parse(tr.Value)));
							bSeenAvailableBalance = false;
						}
						break;
					case XmlNodeType.CDATA:
						Trace.WriteLine(String.Format("<![CDATA[{0}]]>", tr.Value));
						break;
					case XmlNodeType.ProcessingInstruction:
						Trace.WriteLine(String.Format("<?{0} {1}?>", tr.Name, tr.Value));
						break;
					case XmlNodeType.Comment:
						Trace.WriteLine(String.Format("<!--{0}-->", tr.Value));
						break;
					case XmlNodeType.XmlDeclaration:
						Trace.WriteLine("<?xml version='1.0'?>");
						break;
					case XmlNodeType.Document:
						break;
					case XmlNodeType.DocumentType:
						Trace.WriteLine(String.Format("<!DOCTYPE {0} [{1}]", tr.Name, tr.Value));
						break;
					case XmlNodeType.EntityReference:
						break;
					case XmlNodeType.EndElement:
						Trace.WriteLine(String.Format("</{0}>", tr.Name));
						break;
				}
				Trace.WriteLine(String.Format("Wow, that happened a lot {0}",i));
			}
		}
		
		//XmlTexttr
		

		//XPathNavigator
		public static void Main()
		{
			XmlFun fun = new XmlFun();
			fun.IAmStupid();
		}
	}
}

 

//Scott Hanselman
//Chief Architect - Corillian Corporation
//Microsoft Regional Director - http://www.microsoft.com/rd 
//scott@corillian.com - 1.503.629.4342
//
//http://www.computerzen.com (Personal Weblog)

