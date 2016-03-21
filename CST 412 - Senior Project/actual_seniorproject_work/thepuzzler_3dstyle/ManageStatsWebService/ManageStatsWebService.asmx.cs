//
//-------------------------------------------------------------------------------
// Module: ManageStats Module
// Date:   May 1, 2005
// Purpose: Please see the Unit Test Plan for this completely defined.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//
using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace ManageStatsWebService
{
	/// <summary>
	/// Summary description for ManageStats.
	/// </summary>
	[WebService(Namespace="http://matthew.klump-pdx.com/thepuzzler_3dstyle/")]
	public class DataBaseInterface : System.Web.Services.WebService
	{
		/// <summary>
		/// OleDbConnection to the data base named thepuzzler_3dstyle on the DB server localhost.
		/// </summary>
		private OleDbConnection conn;
		/// <summary>
		/// OleDbCommand commander object for handling query commands into the data base.
		/// </summary>
		private OleDbCommand cmd;
		/// <summary>
		/// OleDbDataAdapter for directly working with the puzzleRUN table/dataSet in
		/// thepuzzler_3dstyle database.
		/// </summary>
		private OleDbDataAdapter dataAdapter;
		/// <summary>
		/// Stream reader that reads the first line connection string from the text file dbconn.txt
		/// </summary>
		private StreamReader connString;

		/// <summary>
		/// Web Service Constructor
		/// </summary>
		public DataBaseInterface()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
			cmd = null;
			conn = null;
			connString = null;
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		/// <summary>
		/// This web service will accept a complete six-item data row containing the
		/// next Puzzler - 3D Style Execution Run to keep track of.
		/// </summary>
		/// <param name="dictionary">The dictionary for the current execution run.</param>
		/// <param name="puzzle">The puzzle for the current execution run.</param>
		/// <param name="wordsFound">The words that were found by the solution for the
		/// current execution run.</param>
		/// <param name="dictionaryTime">The time span taken to create the dictionary.</param>
		/// <param name="puzzleTime">The time span taken to create the puzzle.</param>
		/// <param name="solutionTime">The time span taken to execute the solution for
		/// the current run of everything.</param>
		/// <returns>"Succeeded" if the the operation succeeded, and the error message
		/// if the operation failed.</returns>
		[WebMethod(Description="Use this web service to save an execution set.",
			 EnableSession=true)]
		public string StorePuzzlerRun(
										string dictionary,
										string puzzle,
										string wordsFound,
										long dictionaryTime,
										long puzzleTime,
										long solutionTime
										)
		{
			string retval = "";
			int queryResult = 0;
			try
			{
				SetUpDataBase( ref queryResult );

				// Previously used to generate the Guid to be used for ExecutionID.
//				byte [] recordID = new byte[16];
//				string strrecID = null;
//				new Random(new Random().Next()).NextBytes( recordID );
//				foreach( byte thisByte in recordID )
//					strrecID += thisByte.ToString();

				cmd = conn.CreateCommand();
				cmd.CommandText = string.Format(
					"INSERT INTO puzzleRUN( Dictionary, Puzzle, WordsFound," +
					"DictionaryTime, PuzzleTime, SolutionTime ) " +
					"VALUES( '{0}', '{1}', '{2}', '{3}', '{4}', '{5}' );",
					dictionary, puzzle, wordsFound,
					dictionaryTime, puzzleTime, solutionTime
					);
				queryResult = cmd.ExecuteNonQuery();
				retval = "Succeeded";
			}
			catch( System.Exception ex )
			{
				HandleException( ref ex );
			}
			finally
			{
				connString.Close();
				conn.Close();
			}
			return retval;
		} // End of public string StorePuzzlerRun()
		/// <summary>
		/// This web service queries the data base for all of the calculated average execution
		/// times.
		/// </summary>
		/// <returns>The resulting queries and calcuation as a string[] set for display
		/// at the ASP.NET user interface front end.</returns>
		[WebMethod(Description="Use this web service to retrieve the average execution times," +
			 "the expected execution times, and the difference between these two.",
			 EnableSession=true)]
		public long[] GetExecutionStatistics()
		{
			long [] results = new long[3];
			try
			{
				// Open the database
				connString = new StreamReader( @"\\" +
					System.Net.Dns.GetHostName() + @"\thepuzzler_3dstyle\dbconn.txt" );
				conn = new OleDbConnection( connString.ReadLine() );
				conn.Open();

				// Get the timing averages
				cmd = conn.CreateCommand();
				cmd.CommandText =
					"SELECT (SUM(DictionaryTime) / COUNT(DictionaryTime)) FROM puzzleRUN";
				OleDbDataReader reader = cmd.ExecuteReader();
				reader.Read();
				results[0] = reader.GetInt64( 0 );
				reader.Close();
				cmd = conn.CreateCommand();
				cmd.CommandText =
					"SELECT (SUM(PuzzleTime) / COUNT(PuzzleTime)) FROM puzzleRUN";
				reader = cmd.ExecuteReader();
				reader.Read();
				results[1] = reader.GetInt64( 0 );
				reader.Close();
				cmd = conn.CreateCommand();
				cmd.CommandText =
					"SELECT (SUM(SolutionTime) / COUNT(SolutionTime)) FROM puzzleRUN";
				reader = cmd.ExecuteReader();
				reader.Read();
				results[2] = reader.GetInt64( 0 );
				reader.Close();
			}
			catch( Exception ex )
			{
				HandleException( ref ex );
			}
			finally
			{
				conn.Close();
				conn.Dispose();
			}
			return results;
		}

		/// <summary>
		/// This helper operation sets up the database for The Puzzler - 3D Style
		/// web application.
		/// </summary>
		private void SetUpDataBase( ref int queryResult )
		{
			connString = new StreamReader( @"\\" +
				System.Net.Dns.GetHostName() + @"\thepuzzler_3dstyle\dbconn.txt" );

			conn = new OleDbConnection( connString.ReadLine() );
			connString.Close();
			conn.Open();
			OleDbCommand cmd = conn.CreateCommand();
			cmd.CommandText = "SELECT COUNT(*) FROM puzzleRUN";
			try
			{
				queryResult = (int)cmd.ExecuteScalar();
			}
			catch( OleDbException ex )
			{
				if( ex.Message == "Invalid object name 'puzzleRUN'." )
					queryResult = 0;
				else
					queryResult = 1;
			}
			if( 0 == queryResult )
			{
				try
				{
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
					dataAdapter = new OleDbDataAdapter( "SELECT * FROM puzzleRUN", conn );
					DataSet dataSet = new DataSet( "thepuzzler_3dstyleSchema" );
					dataAdapter.Fill( dataSet );
					dataSet.WriteXmlSchema( @"\\" + System.Net.Dns.GetHostName() +
						@"\thepuzzler_3dstyle\ManageStatsWebService\puzzleRUN_DataSet.xsd" );
				}
				catch( Exception ex )
				{
					HandleException( ref ex );

//					// Create a dataSet Progmatically that will later result in the schema for
//					// thepuzzler_3dstyle database
//					DataSet dataSet = new DataSet( "puzzleRUN_DataSet" );
//					DataTable dataTable = dataSet.Tables.Add( "puzzleRUN" );
//					dataTable.Columns.Add( new DataColumn( "ExecutionID", typeof( int ) ));
//					dataTable.Columns.Add( new DataColumn( "Dictionary", typeof( object[] ) ));
//					dataTable.Columns["Dictionary"].AllowDBNull = false;
//					dataTable.Columns.Add( new DataColumn( "Puzzle", typeof( char[][][] ) ));
//					dataTable.Columns["Puzzle"].AllowDBNull = false;
//					dataTable.Columns.Add( new DataColumn( "WordsFound", typeof( object[] ) ));
//					dataTable.Columns["WordsFound"].AllowDBNull = false;
//					dataTable.Columns.Add( new DataColumn( "DictionaryTime", typeof( System.DateTime ) ));
//					dataTable.Columns["DictionaryTime"].AllowDBNull = false;
//					dataTable.Columns.Add( new DataColumn( "PuzzleTime", typeof( System.DateTime ) ));
//					dataTable.Columns["PuzzleTime"].AllowDBNull = false;
//					dataTable.Columns.Add( new DataColumn( "SolutionTime", typeof( System.DateTime ) ));
//					dataTable.Columns["SolutionTime"].AllowDBNull = false;
//					dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ExecutionID"] };
//					dataTable.Columns["ExecutionID"].AutoIncrement = true;
//				
//					// Write out the Xml Schema for the data store structure="dataSet"
//					dataSet.WriteXmlSchema( @"\\" + System.Net.Dns.GetHostName() +
//						@"\thepuzzler_3dstyle\ManageStatsWebService\puzzleRUN_DataSet.xsd" );
//
//					// Create an OleDbDataAdapter to link with the database and insert
//					// the first dummy value.
//					dataAdapter = new OleDbDataAdapter( string.Format(
//						"INSERT INTO puzzleRUN(Dictionary, Puzzle, WordsFound, " +
//						"DictionaryTime, PuzzleTime, SolutionTime) " +
//						"VALUES({0}, {1}, {2}, {3}, {4}, {5});", string.Empty,
//						string.Empty, string.Empty, DateTime.MinValue,
//						DateTime.MinValue, DateTime.MinValue ),
//						conn );
//					dataAdapter.Fill( dataSet, "puzzleRUN" );
				} // End of catch( System.Data.OleDb.OleDbException ex )
			} // End of if( 0 == queryResult )
		} // End of public void StorePuzzlerRun()
		/// <summary>
		/// Error Handling for this DataBaseInterface WebService class
		/// </summary>
		/// <param name="ex">The Current System.Exception that was thrown.</param>
		private void HandleException( ref Exception ex )
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
	} // End of public class DataBaseInterface : System.Web.Services.WebService
} // End of namespace ManageStatsWebService
