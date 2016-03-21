//--------------------------------------------------------------
//	File:		Catalog.cs
//	Project:	Assignment1 (as well as the executable's name)
//	Author:		Matthew Klump
//	Date:		October 15, 2004
//
//	Purpose:	This C# console application will provide an
//				adequate solution for Applied Web Services
//				Assignment #1.
//
//	Overview:	This program will accept an XML document with
//				the ".xml" extension only as input.
//
//	Output:		This program will deserialize the XML document
//				and insert all of its data into a Catalog class
//				data object I have defined. If the user wants,
//				you have the option to print the contents of the
//				Catalog object to a file for inspection.
//				After that, the program will then serialize the
//				Catalog object back into an XML document and print
//				the results to a file called:
//				CatalogAssignment1Output.xml
//-------------------------------------------------------------- 
using System.Xml.Serialization;

namespace Catalog_NameSpace
{
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Assignment1/Catalog")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://Assignment1/Catalog", IsNullable=false)]
	public class catalog 
	{
		[System.Xml.Serialization.XmlElementAttribute("book")]
		public catalogBook[] Items;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Assignment1/Catalog")]
	public class catalogBook 
	{
		public string author;
		public string title;
		public string genre;
		public double price;
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime publish_date;
		public string description;
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string id;
	}
}