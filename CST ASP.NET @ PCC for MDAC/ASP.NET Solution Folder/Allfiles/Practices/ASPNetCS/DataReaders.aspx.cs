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
using ado = System.Data.SqlClient;


namespace ASPNetCS
{
	/// <summary>
	/// Summary description for DataReaders.
	/// </summary>
	public class DataReaders : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlCustomers;
		protected System.Web.UI.WebControls.DataGrid dgOrders;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			

			if (!Page.IsPostBack)
			{
				ado.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(Application["connectionString"].ToString());
				ado.SqlCommand cmdSQL = new System.Data.SqlClient.SqlCommand("Select * from Customers",conSQL);
				conSQL.Open();
			
				ado.SqlDataReader rdrSQL = cmdSQL.ExecuteReader();

				this.ddlCustomers.DataSource = rdrSQL;
				this.ddlCustomers.DataTextField = "ContactName";
				this.ddlCustomers.DataValueField = "CustomerID";
				this.ddlCustomers.DataBind();

				rdrSQL.Close();
				conSQL.Close();
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
			this.ddlCustomers.SelectedIndexChanged += new System.EventHandler(this.ddlCustomers_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddlCustomers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ado.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(Application["connectionString"].ToString());

			ado.SqlCommand cmdSQL = new System.Data.SqlClient.SqlCommand("Select * from Orders where CustomerID = @CustomerID" ,conSQL);
			cmdSQL.Parameters.Add("@CustomerID" ,System.Data.SqlDbType.NChar,5).Value = this.ddlCustomers.SelectedValue;
			conSQL.Open();
			
			ado.SqlDataReader rdrSQL = cmdSQL.ExecuteReader();

			this.dgOrders.DataSource = rdrSQL;
			this.dgOrders.DataBind();

			rdrSQL.Close();
			conSQL.Close();
		}
	}
}
