#region Using Statements
using System;
using System.Xml;
using System.IO;
using System.Text;
#endregion

namespace Invoice_XMLParser
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class RealXml
	{
		private static int num = 0;

		public static void Main( string [] args )
		{
			FileStream inStream = null;
			XmlTextReader inXml = null;
			try
			{
				inStream = File.Open( args[0], FileMode.Open );

				inXml = new XmlTextReader( inStream );

				while( inXml.Read() )
				{
					if( string.Compare(inXml.Name, "order") == 0 )
					{
						Console.WriteLine( "For order #{0} the details are:",
							inXml.GetAttribute("PO_NUMBER")
							);
						while( inXml.Read() )
						{
							if( inXml.Name != "" && inXml.Name != "order" )
								Console.WriteLine( "\nFor order detail \"{0}\"", inXml.Name );
							while( inXml.MoveToNextAttribute() )
								Console.WriteLine( "{0}: {1}", inXml.Name, inXml.Value );
						}
					}
				}
			}
			catch( FileNotFoundException e )
			{
				Console.WriteLine( "The specified file was not found, error detail:\n{0}", e.Message );
			}
			finally
			{
				inStream.Close();
			}
		}
	}
}
