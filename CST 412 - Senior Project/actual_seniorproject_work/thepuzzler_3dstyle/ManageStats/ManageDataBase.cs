//
//-------------------------------------------------------------------------------
// Module: ManageDB Module
// Date:   April 29, 2005
// Purpose: Please see the Unit Test Plan for this completely defined.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//
using System;
using System.IO;
using System.Net;
using System.Collections;
using ns_RedBlack;
using Puzzle_Solution;
using ns_ManageStats;
using NUnit.Framework;

using System.Data.OleDb;
using System.Xml;
using System.Xml.Serialization;

using ManageDB.localhost;

namespace ManageDB
{
	/// <summary>
	/// Responsible for managing the connection to the Data Base through a
	/// provided web service for each application execution to keep record.
	/// </summary>
	public class ManageDataBase
	{
		/// <summary>
		/// This string variable represents the serialized Equivalent of the
		/// corresponding RedBlack Dictionary, char[,,] puzzle, and the
		/// RedBlack wordsFound data objcets produced by this web appliaction
		/// for transport through the web service, and ultimately stored in
		/// local or remote MS SQL Server 2000 data base.
		/// </summary>
		private string dictionaryXML, puzzleXML, wordsFoundXML;
		/// <summary>
		/// 64 bit long integers for easier serialization and calculations.
		/// </summary>
		private long dictionaryTime, puzzleTime, solutionTime;
		/// <summary>
		/// XmlTextWriter for writing out the XML document serialized equivalent
		/// of each of the processed data objects.
		/// </summary>
		private StreamWriter writer;
		/// <summary>
		/// StreamReader for reading the XML data documents back into a string
		/// for transport through the web service to the database.
		/// </summary>
		private StreamReader reader;
		/// <summary>
		/// Class level scope index variable.
		/// </summary>
		private static int index;
		/// <summary>
		/// Web service to Data Base Interface object reference.
		/// </summary>
		private DataBaseInterface dbinterface;
		/// <summary>
		/// XML Serializer for serializing my data objects into XML documents
		/// for easier, more simplified transport through the web service
		/// and ultimately to the database where they will be stored as simple
		/// text.
		/// </summary>
		private static XmlSerializer serializer;
		/// <summary>
		/// Property Serializer (XmlSerializer) Set or Get
		/// </summary>
		public XmlSerializer Serializer
		{
			get { return serializer; }
			set { serializer = value; }
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ManageDataBase()
		{
			index = 0;
			writer = null;
			reader = null;
			wordsFoundXML = puzzleXML = dictionaryXML = "";
			dbinterface = new DataBaseInterface();
			dictionaryTime = puzzleTime = solutionTime = 0;
		}
		/// <summary>
		/// The operation will (on the client side) call the StorePuzzlerRun()
		/// web service to store all of the current execution statics.
		/// </summary>
		/// <param name="solution">The Solution reference containing the dictionary,
		/// puzzle, and words found data to store in the data base.</param>
		/// <param name="statistics">The ManageStats reference containing the
		/// dictionary, puzzle, and solution execution times.</param>
		/// <returns>The success or failure message of the server side db insert operation.</returns>
		public string Call_StorePuzzlerRun( ref Solution solution, ref ManageStats statistics )
		{
			SetDataForStorage( solution.Dictionary, solution.Puzzle,
				solution.WordsFound, ref solution );

			dictionaryTime = statistics.DictionaryTime.Ticks;
			puzzleTime = statistics.PuzzleTime.Ticks;
			solutionTime = statistics.SolutionTime.Ticks;

			return dbinterface.StorePuzzlerRun(
				dictionaryXML,
				puzzleXML,
				wordsFoundXML,
				dictionaryTime,
				puzzleTime,
				solutionTime
				);
		}
		/// <summary>
		/// This operation will (on the client side) call the GetExecutionStatistics()
		/// web service to retrieve the average execution times for the DictionaryCreation,
		/// the Puzzle Creation, and the Solution Execution
		/// </summary>
		/// <returns>The average execution times for the dictionary, puzzle, and
		/// solution for display on the front end UI (from the client side).</returns>
		public long[] Call_GetExecutionStatistics()
		{
			return dbinterface.GetExecutionStatistics();
		}
		/// <summary>
		/// This operation will ready the RedBlack dictionary to an array of strings, and the
		/// RedBlack wordsFound to an array of strings. This done so the serialization of the data
		/// objects become extremely easy for section 5 array encoding, and even easier for each data
		/// object's ultimate destination to the server side database.
		/// </summary>
		/// <param name="RedBlack_Dictionary">The RedBlack dictionary to convert.</param>
		/// <param name="puzzle">The char [,,] to convert.</param>
		/// <param name="RedBlack_wordsFound">The RedBlack wordsFound to convert.</param>
		/// <param name="solution">The solution object class reference.</param>
		private void SetDataForStorage( 
										RedBlack RedBlack_Dictionary,
										char[,,] puzzle,
										RedBlack RedBlack_wordsFound,
										ref Solution solution
										)
		{
			try
			{
				// Serialize the dictinary
				string path = @"\\" + System.Net.Dns.GetHostName() +
					@"\thepuzzler_3dstyle\ManageDB\dictionary.xml";
				writer = new StreamWriter( path );

				serializer = new XmlSerializer( typeof(string[]), "http://ns_DictionaryCreator" );
				RedBlack_Dictionary.GetActualSize( RedBlack_Dictionary, ref index );
				string [] dictionary = new string[index];
				index = 0;
				VisitRedBlackTree( RedBlack_Dictionary, ref dictionary );
				serializer.Serialize( writer.BaseStream, dictionary );

				writer.Close();
				reader = new StreamReader( path );
				dictionaryXML = reader.ReadToEnd();
				reader.Close();

				// Serialize the puzzle
				path = @"\\" + System.Net.Dns.GetHostName() +
					@"\thepuzzler_3dstyle\ManageDB\puzzle.xml";
				writer = new StreamWriter( path );

				serializer = new XmlSerializer( typeof(char[][][]), "http://Puzzle_Creation" );
				char[][][] jaggedPuzzle = ConvertTo3DJaggedArray( puzzle );
				serializer.Serialize( writer.BaseStream, jaggedPuzzle );

				writer.Close();
				reader = new StreamReader( path );
				puzzleXML = reader.ReadToEnd();
				reader.Close();

				// Serialize the wordsFound
				path = @"\\" + System.Net.Dns.GetHostName() +
					@"\thepuzzler_3dstyle\ManageDB\wordsFound.xml";
				writer = new StreamWriter( path );

				serializer = new XmlSerializer( typeof(string[]), "http://Puzzle_Solution" );
				index = 0;
				RedBlack_wordsFound.GetActualSize(RedBlack_wordsFound, ref index);
				string [] wordsFound = new string[index];
				index = 0;
				VisitRedBlackTree( RedBlack_wordsFound, ref wordsFound );
				serializer.Serialize( writer.BaseStream, wordsFound );

				writer.Close();
				reader = new StreamReader( path );
				wordsFoundXML = reader.ReadToEnd();
				reader.Close();
			}
			catch( Exception ex )
			{
				new ManageDB_TestClass().HandleException( ref ex );
			}
			finally
			{
				writer.Close();
				reader.Close();
			}
		}
		/// <summary>
		/// This helper method will take a three dimentional array and convert it to
		/// the equivalent three dimentional Jagged Array.
		/// </summary>
		/// <param name="sourceArray">The source three dimentional char[,,], passed
		/// pass value to convert from.</param>
		/// <returns>The output char[][][] Destination Array converted to.</returns>
		public char[][][] ConvertTo3DJaggedArray( char[,,] sourceArray )
		{
			char[][][] destArray = new char[sourceArray.GetUpperBound(0)+1][][];
			for( int y = 0; y < sourceArray.GetUpperBound( 0 ) + 1; ++y )
			{
				destArray[y] = new char[sourceArray.GetUpperBound(1)+1][];
			}
			for( int x = 0; x < sourceArray.GetUpperBound( 0 ) + 1; ++x )
				for( int y = 0; y < sourceArray.GetUpperBound( 1 ) + 1; ++y )
				{
					destArray[x][y] = new char[sourceArray.GetUpperBound(2)+1];
				}

			for( int z = 0; z < sourceArray.GetUpperBound( 2 ) + 1; ++z )
				for( int y = 0; y < sourceArray.GetUpperBound( 1 ) + 1; ++y )
					for( int x = 0; x < sourceArray.GetUpperBound( 0 ) + 1; ++x )
						destArray[x][y][z] = sourceArray[x,y,z];

			return destArray;
		}

		/// <summary>
		/// This helper method is used to help with the conversion process from a RedBlack
		/// Binary Search Tree to a string[] for easier serialization.
		/// </summary>
		/// <param name="node">The root/next RedBlack Binary Search Tree node in the list
		/// to visit.</param>
		/// <param name="convertToItem">The string [] reference to convert the RedBlack Binary
		/// Search Tree to.</param>
		private void VisitRedBlackTree( RedBlack node, ref string [] convertToItem )
		{
			if( node != Sentinel.Node )
			{
				VisitRedBlackTree( node.Left, ref convertToItem );
				convertToItem[ index++ ] = new string( (char[])node.Key );
				VisitRedBlackTree( node.Right, ref convertToItem );
			}
		}
		/// <summary>
		/// (Depricated) This operation will serialize the char [,,] Puzzle (three dimentional
		/// character array) into a soap message for transport to the DataBase.
		/// </summary>
		/// <param name="puzzle">The three dimentional char [,,] puzzle to serialize.</param>
		/// <returns>True if the serialization succeeded, false if an exception ocurred.</returns>
		public bool SoapSerializePuzzle( char [,,] puzzle )
		{
			bool retval = false;
			try 
			{
				//soapFormatter.Serialize( /*need new Stream destination */, Solution.puzzle );
				retval = true;
			}
			catch (System.Runtime.Serialization.SerializationException e) 
			{
				StreamWriter error = new StreamWriter( "\\\\" + Dns.GetHostName() +
					"\\thepuzzler_3dstyle\\PuzzleCreator\\SerializationError.txt", false );
				error.Write("Failed to serialize. Reason: \n\n" + e.Message);
				retval = false;
				throw;
			}
			return retval;
		}
		/// <summary>
		/// (Deprecated) This operation will serialize the RedBlack Binary Search Tree
		/// Dictionary object into a soap message for transport to the DataBase.
		/// </summary>
		/// <param name="dictionaryRoot">The dictionary root RedBlack node.</param>
		/// <returns>True if the serialization succeeded, false if an exception ocurred.</returns>
		public bool SoapSerializeDictionary( RedBlack dictionaryRoot )
		{
			bool retval = false;
			try 
			{
				//soapFormatter.Serialize( /* Need new Stream destination */, Solution.dictionary );
				retval = true;
			}
			catch (System.Runtime.Serialization.SerializationException e) 
			{
				StreamWriter error = new StreamWriter( "\\\\" + Dns.GetHostName() +
					"\\thepuzzler_3dstyle\\DictionaryCreator\\SerializationError.txt", false );
				error.Write("Failed to serialize. Reason: \n\n" + e.Message);
				retval = false;
				throw;
			}
			return retval;
		}
	} // End of public class ManageDataBase

	/// <summary>
	/// This class is responsible for testing the database connectivity
	/// and querying ability.
	/// </summary>
	[TestFixture]
	public class ManageDB_TestClass
	{
		private static OleDbConnection conn;
		private static int queryResult;
		private OleDbCommand cmd;
		private OleDbDataAdapter adapter;

		/// <summary>
		/// Default Constuctor for the ManageDB_TestClass test class of
		/// which is further responsible for testing the database connectivity
		/// as well as the ability to execute any such needed queries.
		/// </summary>
		public ManageDB_TestClass()
		{
			StreamReader connString = new StreamReader( @"\\" +
				Dns.GetHostName() + @"\thepuzzler_3dstyle\dbconn.txt" );
			conn = new OleDbConnection( connString.ReadLine() );
		}
		/// <summary>
		/// Seting up the tests will call the class constructor just like
		/// calling new My_TestClass()
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			new ManageDB_TestClass();
		}
		/// <summary>
		/// This method will test the connectivity to the MS SQL Data Base Server 2000.
		/// </summary>
		/// <returns>True if succeeded, and false if not.</returns>
		[Test]
		public void TestConnectivity()
		{
			try
			{
				conn.Open();
				conn.Close();
				Assert.IsTrue( true );
			}
			catch( Exception ex )
			{
				HandleException( ref ex );
				Assert.IsTrue( false );
			}
		}
		/// <summary>
		/// This method will test whether creating the neccessary database table
		/// is successfull or not.
		/// </summary>
		[Test]
		public void TestCreateDataBase()
		{
			try
			{
				conn.Open();
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT * FROM puzzleRUN";
				if( 0 == cmd.ExecuteNonQuery() ) // Check existance of the puzzleRUN table
				{	// No rows found, drop and recreate database table
					cmd = conn.CreateCommand();
					cmd.CommandText = "DROP TABLE puzzleRUN";
					queryResult = cmd.ExecuteNonQuery();
					cmd = conn.CreateCommand();
					cmd.CommandText =
						"CREATE TABLE puzzleRUN(" +
						"ExecutionID timestamp UNIQUE NOT NULL," + 
						"Dictionary text NOT NULL," +
						"Puzzle text NOT NULL," +
						"WordsFound text NOT NULL," +
						"DictionaryTime bigint NOT NULL," +
						"PuzzleTime bigint NOT NULL," +
						"SolutionTime bigint NOT NULL," +
						"PRIMARY KEY(ExecutionID) );";
					queryResult = cmd.ExecuteNonQuery();
				}
				Assert.IsTrue( true );
			}
			catch( Exception ex )
			{
				HandleException( ref ex );
				Assert.IsTrue( false );
			}
			finally
			{
				conn.Close();
			}
		}
		/// <summary>
		/// This method will test the ability to successfully query a the MS SQL Server
		/// 2000 data base for a Result Set for the ADO.NET interface.
		/// </summary>
		/// <returns>True if the query succeeded, and false if the query failed.</returns>
		[Test]
		public void TestQueryingTheDataBase()
		{
			try
			{
				conn.Open();
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT * FROM puzzleRUN";
				adapter = new OleDbDataAdapter( cmd );
				System.Data.DataSet dataSet = new System.Data.DataSet( "Test_DataSet" );

				int numRowsAffected = cmd.ExecuteNonQuery();
				adapter.Fill( dataSet );
				dataSet.WriteXmlSchema( @"\\" + System.Net.Dns.GetHostName() +
					@"\thepuzzler_3dstyle\ManageStatsWebService\puzzleRUN_DataSet.xsd" );
				Assert.IsTrue( true );
			}
			catch( Exception ex )
			{
				HandleException( ref ex );
				Assert.IsTrue( false );
			}
			finally
			{
				conn.Close();
			}
		}
		/// <summary>
		/// Error Handling for this ManageDB_TestClass
		/// </summary>
		/// <param name="ex">The Current System.Exception that was thrown.</param>
		public void HandleException( ref Exception ex )
		{
			string error = ex.Message + "\n";
			StreamWriter errorOut = new StreamWriter( @"\\" +
				System.Net.Dns.GetHostName() +
				@"\thepuzzler_3dstyle\error.txt", false );
			errorOut.Write( "Application Error Occured of Type: " +
				ex.GetType().FullName + "\n\n" +
				ex.ToString() );
			errorOut.Close();
		}
		/// <summary>
		/// In case this library is compiled into an individual executable.
		/// </summary>
		/// <param name="args">Main method parameter list.</param>
		public static void Main( string [] args )
		{
			ManageDB_TestClass testing = new ManageDB_TestClass();
			// testing.SetUp();
			testing.TestConnectivity();
			testing.TestCreateDataBase();
			testing.TestQueryingTheDataBase();
		}
	}
} // End of namespace ManageDB
