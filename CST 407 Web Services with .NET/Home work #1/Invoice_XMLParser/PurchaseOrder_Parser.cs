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
	class Class1
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			StreamReader fileReader = null;
			XmlTextWriter xmlWriter = null;
			string tempbuff = "", purchase_data = "purchase order.xml";
			try
			{
				fileReader = File.OpenText( args[0] );
				xmlWriter = new XmlTextWriter( purchase_data, null );
				xmlWriter.Formatting = Formatting.Indented;
				xmlWriter.WriteStartDocument( true );
				while( fileReader.Peek() != -1 )
					tempbuff += fileReader.Read();

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
				xmlWriter.Close();
				tempbuff.Remove( 0, tempbuff.Length );
			}
		}
	}
}
