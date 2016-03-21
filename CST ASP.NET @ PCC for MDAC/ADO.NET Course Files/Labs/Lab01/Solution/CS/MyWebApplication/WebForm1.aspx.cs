using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace MyWebApplication
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.DataGrid dgResult;
	
		public WebForm1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=NOTEBOOK;packet size=4096;integrated security=SSPI;data source=loc" +
				"alhost;persist security info=False;initial catalog=Northwind";
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "SELECT ProductName, UnitPrice FROM Products";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			// Open a connection to the Northwind database
			sqlConnection1.Open();

			// Execute the query, and create a SqlDataReader to read the results
			System.Data.SqlClient.SqlDataReader Reader;
			Reader = sqlCommand1.ExecuteReader();

			// Bind the datagrid to the SqlDataReader. This will cause the SqlDataReader to
			// iterate through the data, and populate the datagrid with that data. 
			// The datagrid will display the data on the screen.
			dgResult.DataSource = Reader;
			dgResult.DataBind();

			// Close the SqlDataReader and the SqlConnection
			Reader.Close();
			sqlConnection1.Close();
		}
	}
}
