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
using System.Data.SqlClient;

namespace Mod11CS
{
	/// <summary>
	/// Summary description for SPPractice.
	/// </summary>
	public class SPPractice : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Data.SqlClient.SqlConnection SqlConnection1;
		protected System.Data.SqlClient.SqlCommand SqlCommand1;
		protected System.Data.SqlClient.SqlCommand SqlCommand2;
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
	        //create DataReader to read from SqlCommand1
			SqlDataReader dr;

			SqlConnection1.Open();
			dr = SqlCommand1.ExecuteReader();
			DataGrid1.DataSource = dr;
			DataGrid1.DataBind();
			dr.Close();
			SqlConnection1.Close();
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
			this.SqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.SqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.SqlCommand2 = new System.Data.SqlClient.SqlCommand();
			// 
			// SqlConnection1
			// 
			this.SqlConnection1.ConnectionString = "data source=localhost;initial catalog=Northwind;integrated security=SSPI;persist " +
				"security info=True";
			// 
			// SqlCommand1
			// 
			this.SqlCommand1.CommandText = "dbo.[Ten Most Expensive Products]";
			this.SqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.SqlCommand1.Connection = this.SqlConnection1;
			this.SqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// SqlCommand2
			// 
			this.SqlCommand2.CommandText = "dbo.CustOrderHist";
			this.SqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.SqlCommand2.Connection = this.SqlConnection1;
			this.SqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.SqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NChar, 5, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
