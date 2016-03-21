//
//-------------------------------------------------------------------------------
// Module: Helper Module
// Date:   May 16, 2005
// Purpose: This page is strictly for administrative purposes, and is used
//			to clear the database table puzzleRUN due to the fact that this
//			can get extremely large.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Data;
using System.Data.OleDb;
using System.IO;

namespace thepuzzler_3dstyle
{
	/// <summary>
	/// Summary description for clearDB.
	/// </summary>
	public class clearDB : System.Web.UI.Page
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

		private void Page_Load(object sender, System.EventArgs e)
		{
			connString = new StreamReader( @"\\" +
				System.Net.Dns.GetHostName() + @"\thepuzzler_3dstyle\dbconn.txt" );
			try
			{
				conn = new OleDbConnection( connString.ReadLine() );
				connString.Close();
				conn.Open();
				cmd = conn.CreateCommand();
				cmd.CommandText = "DROP TABLE puzzleRUN";
				int queryResult = cmd.ExecuteNonQuery();

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
			finally
			{
				connString.Close();
				conn.Close();
			}
		}

		#region Web Form Designer generated code
		/// <summary>
		/// On Intialization Event Handler
		/// </summary>
		/// <param name="e">Event Arguement</param>
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
