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
	/// Summary description for SPUseParameters.
	/// </summary>
	public class SPUseParameters : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtStartDate;
		protected System.Web.UI.WebControls.TextBox txtEndDate;
		protected System.Web.UI.WebControls.Button cmdSales;
		protected System.Web.UI.WebControls.DataGrid dgSales;
	
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
			this.cmdSales.Click += new System.EventHandler(this.cmdSales_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdSales_Click(object sender, System.EventArgs e)
		{
			SqlConnection conn = new SqlConnection("server=localhost;integrated security=true;initial catalog=northwind");
			SqlDataAdapter da;
			DataSet ds;
			SqlParameter workParam;

			//call the Sales by year stored procedure
			da = new SqlDataAdapter("Sales By Year", conn);
	        da.SelectCommand.CommandType = CommandType.StoredProcedure;

	        //add the start date input parameter 
			workParam = new SqlParameter("@Beginning_Date", System.Data.SqlDbType.DateTime);
			workParam.Direction = ParameterDirection.Input;
			workParam.Value = Convert.ToDateTime(txtStartDate.Text);
			da.SelectCommand.Parameters.Add(workParam);

			//add the end date input parameter 
			workParam = new SqlParameter("@Ending_Date", System.Data.SqlDbType.DateTime);
			workParam.Direction = ParameterDirection.Input;
			workParam.Value = Convert.ToDateTime(txtEndDate.Text);
			da.SelectCommand.Parameters.Add(workParam);

			//run the stored procedure and fill a dataset with the results
			ds = new DataSet();
			da.Fill(ds, "Sales");

			//bind the dataset to a datagrid
			dgSales.DataSource = ds;
			dgSales.DataBind();
		}
	}
}
