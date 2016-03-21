#region Using Statements
using System;
using System.Xml;
using System.IO;
#endregion

namespace dotNetXmlReader
{
	class XmlReader
	{
		/// <summary>
		/// Main entry point for console applcation
		/// </summary>
		/// <param name="args"></param>
		[STAThread]
		static void Main(string[] args)
		{
			StreamReader streamreader = null;
			try
			{
				streamreader = File.OpenText( args[0] );
				string book_id = null, Name = null;
				XmlTextReader xmltextreader = new XmlTextReader( streamreader );
				xmltextreader.WhitespaceHandling = WhitespaceHandling.None;
				while( xmltextreader.Read() )
				{
					Name = xmltextreader.Name;
					if( Name == "book" )
					{
						book_id = xmltextreader.GetAttribute("id");
						Console.Write( "{0}", book_id );
					}
					else if( Name != "xml" && Name != "catalog" )
					{
						Console.Write(" {0}{1}", xmltextreader.Value.Trim(),
							string.Compare( Name, "description" ) == 0 ? "\n" : "" );
					}
				}
			}
			finally
			{
				if( streamreader != null )
				{
					streamreader.Close();
				}
			}
		}
	}
}