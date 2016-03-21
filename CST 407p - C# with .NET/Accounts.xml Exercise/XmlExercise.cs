///-------------------------------------------------------------------
/// Author:         Matthew Klump CST 407 Final Project
/// Date Created:	   November 10, 2003
/// Last Change Date:  November 10, 2003
/// Namespace:      Accounts.xml_Exercise
/// Filename:       XmlExercise.cs
///
/// Overview: This file contains the interface for this Xml Parsing
///			  exercise. The goal is to read an "accounts.xml" file
///			  into, perform several lookups, and outpute the results
///			  to a file "searchresults.txt"
///
/// Input:	  Input is accepted from a file "accounts.xml" for
///			  which defines the arbitrary entries for account data.
/// Output:	  Output is written to a text file "searchresults.txt".
///-------------------------------------------------------------------
///</Intro>
#region "using statements"
using System;
using NUnit.Framework;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Collections;
#endregion // "using statements"

namespace Accounts.xml_Exercise
{
	/// <summary>
	/// Summary description for XmlExercise.
	/// </summary>
	[TestFixture]
	public class XmlExercise
	{
		/// <summary>
		/// XmlExercise data field set
		/// </summary>
		private XmlNodeList list;
		private string [] columntags;
		private XmlDocument xml;
		private StreamWriter outFile;
		private TextWriterTraceListener myWriter;

		/// <summary>
		/// Property List (XmlNodeList)
		/// </summary>
		public XmlNodeList List
		{
			get
			{
				return this.list;
			}
		}
		/// <summary>
		/// Property Columntags (string)
		/// </summary>
		public string[] ColumnTags
		{
			get
			{
				return this.columntags;
			}
		}
		/// <summary>
		/// XmlExercise Constructor
		/// </summary>
		public XmlExercise() : this( "accounts.xml" ) {}

		/// <summary>
		/// XmlExercise Constructor that takes an xmlFileName to load.
		/// </summary>
		public XmlExercise( string xmlFileName )
		{
			xml = new XmlDocument();
			xml.Load(xmlFileName);
			columntags = new string[]
			{
				"Number",
				"Description",
				"Type",
				"NickName",
				"CurrentBalance",
				"AvailableBalance"
			};
			InintializeOutput();
		}
		/// <summary>
		/// Setup output for this program XmlExercise program
		/// </summary>
		[Test]
		public void InintializeOutput()
		{
			outFile = new StreamWriter( "searchresults.txt", true );
			myWriter = new TextWriterTraceListener( outFile );
			Trace.Listeners.Add(myWriter);
		}
		/// <summary>
		/// Close routine for the FileStream of the class.
		/// Please exuse the over use of exceptions.
		/// </summary>
		[Test]
		public void CloseOutputFile( ref StreamWriter outFile )
		{
			if( outFile == null )
				throw new Exception( "Take this!",
					new ArgumentException( "And this!",
					new ArgumentException( "And this!",
					new ArgumentNullException( "filename",
					"And that, for passing me a null file pointer!"))));

			outFile.Close();
		}
		/// <summary>
		/// Get the Account Data as they appear in the Xml schema accounts.xml
		/// Writes data found within the xml schema to a file "searchresults.txt"
		/// </summary>
		[Test]
		public void GetAccountData()
		{
			int indexer = 0;
			list = xml.GetElementsByTagName("Account");
			foreach(XmlNode n in list)
			{
				XmlElement element = n[columntags[indexer]];
				indexer++;
			}
			foreach(XmlNode n in list)
				Trace.WriteLine( n.InnerText );
		}
		/// <summary>
		/// Implements a way to search the data subsets for substrings
		/// beginning with S. This done with the XmlDocument
		/// </summary>
		[Test]
		public void FindStringsBeginningWith_S( string xpath )
		{
			XmlNodeList list_ =
				xml.DocumentElement.SelectNodes( xpath );
			foreach(XmlNode node in list_)
			{
				Trace.WriteLine(node.InnerText);
			}
		}
		/// <summary>
		/// Implements a way to search the data subsets for substrings
		/// beginning with S. This done with the XmlTextReader
		/// </summary>
		[Test]
		public void FindStringsBeginningWith_S()
		{
			int i = 0;
			XmlTextReader xreader = new XmlTextReader("accounts.xml");
			while( xreader.Read() )
			{
				i++;
				switch (xreader.NodeType) 
				{
					case XmlNodeType.Element:
						Trace.WriteLine(String.Format("<{0}>", xreader.Name));
						break;
					case XmlNodeType.Text:
						Trace.WriteLine(xreader.Value);
						if (xreader.Value.StartsWith("S"))
						{
							Trace.WriteLine(String.Format("{0}", xreader.Value));
						}
						break;
					default:
						break;
				}
				Trace.WriteLine(String.Format("Ocurred {0}th times", i));
			}
			CloseOutputFile( ref outFile );
		}
		/// <summary>
		/// Program entry point
		/// </summary>
		[Test]
		public static void Main(string[] args)
		{
			XmlExercise xmllexer = new XmlExercise();
			xmllexer.GetAccountData();
			xmllexer.FindStringsBeginningWith_S( args[0] );
			xmllexer.FindStringsBeginningWith_S();
		}
	}
}
