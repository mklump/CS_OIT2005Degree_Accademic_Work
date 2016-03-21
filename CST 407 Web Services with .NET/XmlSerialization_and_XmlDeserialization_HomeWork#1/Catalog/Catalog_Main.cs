//--------------------------------------------------------------
//	File:		Catalog_Main.cs
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
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Catalog_NameSpace
{
	/// <summary>
	/// Summary description for Class_Main.
	/// </summary>
	class Class_Main
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			string usage = "Usage: Catalog.exe <XML Document>";
			if( args.Length == 0 || !args[0].EndsWith( ".xml" ) )
			{
				Console.WriteLine( usage );
				return;
			}
			catalog theCatalog = DeserializeCatalog( args[0] );
			SerializeCatalog( "CatalogAssignment1Output.xml", theCatalog );
		}
		/// <summary>
		/// DeserializeCatalog accepts a file name containing the
		/// XML that is the data for a Catalog.
		/// </summary>
		/// <param name="filename"></param>
		/// <returns>This returns a catalog data object for further
		/// processing.</returns>
		public static catalog
			DeserializeCatalog( string filename )
		{
			XmlReader reader =
				new XmlTextReader( filename == string.Empty ? "Catalog.xml" : filename );
			XmlSerializer serializer = new XmlSerializer( typeof(catalog) );
			catalog myCatalog = (catalog) serializer.Deserialize( reader );

			Console.Write("Do you want to write the contents of the catalog\n" +
						  "data class object to the file catalog.txt : Y/N ? ");
			char ans = (char) Console.Read();
			if( ans == 'Y' || ans == 'y' )
			{
				catalog nextbook = myCatalog;
				using( StreamWriter ostream = new StreamWriter("catalog.txt") )
				{
					ostream.Write( "Your Catalog Sir...\n" );
					for( int x = 0; x < nextbook.Items.Length; ++x )
					{
						ostream.Write(nextbook.Items[x].id + "\n" + nextbook.Items[x].title + "\n" +
									  nextbook.Items[x].publish_date + "\n" + nextbook.Items[x].price + "\n" +
									  nextbook.Items[x].genre + "\n" + nextbook.Items[x].description + "\n\n");
					}
				}
			}
			reader.Close();
			return myCatalog;
		}
		/// <summary>
		/// SerializeCatalog accepts a file name and a catalog of books
		/// to serialize back into an XML document that is the data for
		/// a catalog of books. This will also write the XML to a file
		/// specified by filename.
		/// </summary>
		/// <param name="filename"></param>
		public static void
			SerializeCatalog( string filename, catalog catalogOfBooks )
		{
			XmlSerializer serializer = new XmlSerializer( typeof(catalog) );
			FileStream ostream = new FileStream( filename, FileMode.OpenOrCreate );
			serializer.Serialize( ostream, catalogOfBooks );				
		}
	}
}
