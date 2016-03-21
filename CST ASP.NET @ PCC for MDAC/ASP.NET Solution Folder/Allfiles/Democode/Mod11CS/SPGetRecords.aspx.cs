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
	/// Summary description for SPGetRecords.
	/// </summary>
	public class SPGetRecords : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgProducts;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				//create connection
				SqlConnection conn = new SqlConnection("data source=localhost;integrated security=true;initial catalog=northwind");

				//create dataadapter to call stored procedure
				SqlDataAdapter da = new SqlDataAdapter();
				da.SelectCommand = new SqlCommand();
				da.SelectCommand.Connection = conn;
				da.SelectCommand.CommandText = "Ten Most Expensive Products";
				da.SelectCommand.CommandType = CommandType.StoredProcedure;

				//fill dataset with results of stored procedure
				DataSet ds = new DataSet();
				da.Fill(ds, "Products");

				//bind dataset to datagrid
				dgProducts.DataSource = ds;
				dgProducts.DataBind();
			}
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
