#region Using Statements
using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;
#endregion

namespace Invoice_XMLParser
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Order_Generator
	{
		private static double order_total;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args)
		{
			StreamReader fileReader = null;
			XmlTextWriter xmlWriter = null;
			string tempbuff = "",
				   purchase_data = "purchase order.xml";

			try
			{
				fileReader = File.OpenText( args[0] );
				xmlWriter = new XmlTextWriter( purchase_data, null );
				xmlWriter.Formatting = Formatting.Indented;

				// Writing the special XML declaration node.
				xmlWriter.WriteStartDocument( true );
				tempbuff += fileReader.ReadToEnd();

				StreamWriter fout = new StreamWriter( "tempbuff.txt", false, Encoding.Default, tempbuff.Length);
				fout.Write( "{0}\n", tempbuff );
				fout.Flush();
				fout.Close();

				// Writing the document type node.
				xmlWriter.WriteDocType( "invoice", null, null, "<!ENTITY h \"purchase order\">" );

				// xmlWriter.WriteAttributeString("xmlns", "po", null, "urn:orders");

				// Comment xml document description.
				xmlWriter.WriteComment( "XML representation of the \"purchase order.doc\" invoice." );

				// Root element:
				xmlWriter.WriteStartElement( "order" );

				// Get purchase order number:
				tempbuff = tempbuff.Trim();
				string po_number = tempbuff.Substring
					(
					tempbuff.IndexOf( "P.O. NUMBER: ", 0, tempbuff.Length ) + 13,
					4
					);
				xmlWriter.WriteAttributeString( "PO_NUMBER", po_number );

				// Get vendor info:
				string vendname_logo = tempbuff.Substring
					(
					tempbuff.IndexOf( "WidgetsRUs", 0, tempbuff.Length ),
					32
					),
					vendAddress = tempbuff.Substring
					(
					tempbuff.IndexOf( "1234", 0, tempbuff.Length ),
					35
					);
				vendAddress = vendAddress.Replace( "\r", ", " );
				Write_PersonInfo( "Vendor", vendname_logo.Substring( 0, 10 ),
								  vendname_logo.Remove( 0 , 11 ),
								  vendAddress,
								  "509.555.0190",
								  "509.555.0191",
								  xmlWriter
								);

				// Write the "To:" node:
				Write_PersonInfo( "To", "Phil Phillipson", 
								  "Widget Supplier, Inc.",
								  "678 9th St., Springfield, AK  98382",
								  "293.555.1212",
								  null,
								  xmlWriter
								);

				// Write the "From:" node:
				Write_PersonInfo( "From", "Heady Lamar",
								  "Radio Widgets, LLC",
								  "345 6th Place., Springfield, MA 09876",
								  "383.555.1212",
								  null,
								  xmlWriter
								);

				// Write item #1 detail:
				Write_OrderItem( 1, 1, 987, "Widget X", .99, .99, xmlWriter );

				// Write item #2 detail:
				Write_OrderItem( 2, 4, 324, "Widget Y", 1.88, 7.52, xmlWriter );

				// Write item #3 detail:
				Write_OrderItem( 3, 8, 2378, "Widget Z", 3.98, 31.84, xmlWriter );

				// Write the purchase total:
				xmlWriter.WriteStartElement( "total" );
				xmlWriter.WriteAttributeString( "value", order_total.ToString() );
				xmlWriter.WriteEndElement();

				// Write end root element:
				xmlWriter.WriteEndElement();

				// Write end document:
				xmlWriter.WriteEndDocument();
			}
			catch( FileNotFoundException e )
			{
				Console.WriteLine( "The specified file was not found.\n" + 
					"The extended message is: \n{0}\n", e.Message );
			}
			catch( IOException e )
			{
				Console.WriteLine( "An IO exception has occured.\n" + 
					"The extended message is: \n{0}\n", e.Message );
			}
			catch( XmlException e )
			{
				Console.WriteLine( "An XmlEception has occured.\n" +
					"The extender message is: \n{0}\n", e.Message );
			}
			finally
			{
				fileReader.Close();
				xmlWriter.Flush();
				xmlWriter.Close();
				tempbuff.Remove( 0, tempbuff.Length );

				//Load the file into an XmlDocument to ensure well formed XML.
				XmlDocument doc = new XmlDocument();
				//Preserve white space for readability.
				doc.PreserveWhitespace = true;
				//Load the file.
				doc.Load(purchase_data);  
    
				//Display the XML content to the console.
				Console.Write(doc.InnerXml);
			}
		}
		public static void Write_PersonInfo(
			string direction,
			string name,
			string company,
			string address,
			string phone,
			string fax,
			XmlTextWriter writer
			)
		{
			writer.WriteStartElement( direction );
			writer.WriteAttributeString( "Name", name );
			writer.WriteAttributeString( "Company", company );
			writer.WriteAttributeString( "Address", address );
			writer.WriteAttributeString( "Phone", phone );
			if( fax != null )
				writer.WriteAttributeString( "Fax", fax );
			writer.WriteEndElement();
		}

		public static void Write_OrderItem(
			int item_number,
			int quantity,
			int unit,
			string description,
			double unit_price,
			double item_total,
			XmlTextWriter writer
			)
		{
			writer.WriteStartElement( string.Format("item_{0}", item_number.ToString()) );
			writer.WriteAttributeString( "Quantity", quantity.ToString() );
			writer.WriteAttributeString( "Unit", unit.ToString() );
			writer.WriteAttributeString( "Description", description );
			writer.WriteAttributeString( "Unit_Price", unit_price.ToString() );
			writer.WriteAttributeString( "Item_Total", item_total.ToString() );
			writer.WriteEndElement();

			order_total += item_total;
		}
	}
}
