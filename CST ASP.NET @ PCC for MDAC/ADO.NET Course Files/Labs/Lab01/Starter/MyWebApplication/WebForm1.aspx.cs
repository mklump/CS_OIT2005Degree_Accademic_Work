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
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DataGrid dgResult;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "workstation id=NOTEBOOK;packet size=4096;integrated security=SSPI;data source=\"(l" +
				"ocal)\";persist security info=False;initial catalog=Northwind";
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "SELECT ProductName, UnitPrice FROM Products";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlDataReader reader = null;
			try
			{
				sqlConnection1.Open();
				reader = sqlCommand1.ExecuteReader( CommandBehavior.CloseConnection );
				dgResult.DataSource = reader;
				dgResult.DataBind();
			}
			catch( System.Data.SqlClient.SqlException error )
			{
				Response.Write( "SQL Exception! Error is:\n" + error.ToString() );
			}
			finally
			{
				reader.Close();
			}
		}
	}
}
