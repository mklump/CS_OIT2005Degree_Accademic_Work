using System;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace XmlParsing
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class PredicateExpressions
	{
		public PredicateExpressions()
		{
		}
		/// <summary>
		/// Main entry point for this application
		/// </summary>
		/// <param name="args"></param>
		[STAThread]
		public static void Main(string[] args)
		{
			StreamWriter fout = new StreamWriter("output.txt",false,System.Text.Encoding.Default);
			using(StreamReader sr = File.OpenText("books.xml") )
			{
				XPathDocument xpdoc = new XPathDocument( sr );
				XPathNavigator nav = xpdoc.CreateNavigator();
				XPathNodeIterator it = nav.Select("//book[number(price) > 5]/title/text()");
				while( it.MoveNext() )
				{
					fout.Write( string.Format("{0}\n",it.Current.Value) );
				}
			}
			fout.Flush();
			fout.Close();
		}
	}
}
