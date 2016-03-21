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
	/// Summary description for DataReleation.
	/// </summary>
	public class DataReleation : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlCustomers;
		protected System.Web.UI.WebControls.DataGrid dgOrders;
		private System.Data.DataSet m_dsData ;
		private void Page_Load(object sender, System.EventArgs e)
		{
			m_dsData = new DataSet();
			ado.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(Application["connectionString"].ToString());
			ado.SqlDataAdapter dapSQL = new System.Data.SqlClient.SqlDataAdapter("Select * from Customers",conSQL);
			conSQL.Open();
			dapSQL.Fill(m_dsData,"Customers");
			dapSQL.SelectCommand.CommandText = "Select * from Orders";
			dapSQL.Fill(m_dsData,"Orders");
			conSQL.Close();

			System.Data.DataColumn parentCol = m_dsData.Tables["Customers"].Columns["CustomerID"];
			System.Data.DataColumn childCol = m_dsData.Tables["Orders"].Columns["CustomerID"];
			System.Data.DataRelation dr = new DataRelation("CustOrders",parentCol, childCol);
			m_dsData.Relations.Add(dr);

			if (!Page.IsPostBack)
			{
				this.ddlCustomers.DataSource = m_dsData.Tables["Customers"];
				this.ddlCustomers.DataTextField = "ContactName";
				this.ddlCustomers.DataValueField = "CustomerID";
				this.ddlCustomers.DataBind();
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
			System.Data.DataView pTableView = this.m_dsData.Tables["Customers"].DefaultView;
			System.Data.DataRowView cRowView = pTableView[int.Parse(ddlCustomers.SelectedIndex.ToString())];
			this.dgOrders.DataSource = cRowView.CreateChildView("CustOrders");
			this.dgOrders.DataBind();
		}
	}
}
