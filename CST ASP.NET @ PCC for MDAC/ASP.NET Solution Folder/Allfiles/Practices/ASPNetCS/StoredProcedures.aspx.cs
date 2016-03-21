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
	/// Summary description for StoredProcedures.
	/// </summary>
	public class StoredProcedures : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgOrders;
		protected System.Web.UI.WebControls.TextBox txtCompanyName;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.DropDownList ddlCustomers;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				ado.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(Application["connectionString"].ToString());
				ado.SqlCommand cmdSQL = new System.Data.SqlClient.SqlCommand("usp_GetCustomers",conSQL);
				cmdSQL.CommandType = System.Data.CommandType.StoredProcedure;
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
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddlCustomers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ado.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(Application["connectionString"].ToString());

			ado.SqlCommand cmdSQL = new System.Data.SqlClient.SqlCommand("usp_GetCustomerOrders" ,conSQL);
			cmdSQL.CommandType = System.Data.CommandType.StoredProcedure;
			cmdSQL.Parameters.Add("@CustomerID" ,System.Data.SqlDbType.NChar,5).Value = this.ddlCustomers.SelectedValue;
			cmdSQL.Parameters.Add("@CompanyName",System.Data.SqlDbType.NChar,40).Direction = System.Data.ParameterDirection.Output;
			cmdSQL.Parameters.Add("@Phone",System.Data.SqlDbType.NChar,24).Direction = System.Data.ParameterDirection.Output;

			conSQL.Open();
			
			ado.SqlDataReader rdrSQL = cmdSQL.ExecuteReader();

			this.dgOrders.DataSource = rdrSQL;
			this.dgOrders.DataBind();

			rdrSQL.Close();
			
			this.txtCompanyName.Text = cmdSQL.Parameters["@CompanyName"].Value.ToString();
			this.txtPhone.Text = cmdSQL.Parameters["@Phone"].Value.ToString();
			
			
			conSQL.Close();
			cmdSQL.Dispose();
		}

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			ado.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(Application["connectionString"].ToString());

			ado.SqlCommand cmdSQL = new System.Data.SqlClient.SqlCommand("usp_UpdateCustomer" ,conSQL);
			cmdSQL.CommandType = System.Data.CommandType.StoredProcedure;
			cmdSQL.Parameters.Add("@CustomerID" ,System.Data.SqlDbType.NChar,5).Value = this.ddlCustomers.SelectedValue;
			cmdSQL.Parameters.Add("@CompanyName",System.Data.SqlDbType.NChar,40).Value = this.txtCompanyName.Text;
			cmdSQL.Parameters.Add("@Phone",System.Data.SqlDbType.NChar,24).Value = this.txtPhone.TabIndex;
			cmdSQL.Parameters.Add("@ReturnValue",System.Data.SqlDbType.NChar,24).Direction = System.Data.ParameterDirection.ReturnValue;

			conSQL.Open();
			
			cmdSQL.ExecuteNonQuery();

			if (int.Parse(cmdSQL.Parameters["@ReturnValue"].Value.ToString()) == 0)
			{
				Response.Write("<Script language=javascript>{alert('Update was Successful')}</Script>");
			}
			else
			{
				Response.Write("<Script language=javascript>{alert('Update Failed')}</Script>");
			}
			
			
			conSQL.Close();
			cmdSQL.Dispose();
		}
	}
}
