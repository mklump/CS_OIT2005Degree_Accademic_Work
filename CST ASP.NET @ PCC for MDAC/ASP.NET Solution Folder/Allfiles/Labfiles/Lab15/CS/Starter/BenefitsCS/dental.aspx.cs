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

namespace BenefitsCS
{
	/// <summary>
	/// Summary description for dental.
	/// </summary>
	public class dental : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button cmdGetAllDentists;
		protected System.Web.UI.WebControls.Button cmdSubmit;
		protected System.Web.UI.WebControls.TextBox txtPostalCode;
		protected System.Web.UI.WebControls.DataGrid dgDentists;
	
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
			this.cmdGetAllDentists.Click += new System.EventHandler(this.cmdGetAllDentists_Click);
			this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
			this.txtPostalCode.TextChanged += new System.EventHandler(this.txtPostalCode_TextChanged);
			this.dgDentists.SelectedIndexChanged += new System.EventHandler(this.dgDentists_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdSubmit_Click(object sender, System.EventArgs e)
		{
			//TODO Lab 13: call the XML Web service method
			//GetDentistsByPostalCode
			BenefitsCS.DentalWebRef.DentalService1 ProxyGetDentistsByPostalCode = new BenefitsCS.DentalWebRef.DentalService1();
			DataSet dsDentistsByPostalCode = new DataSet();
			dsDentistsByPostalCode = ProxyGetDentistsByPostalCode.GetDentistsByPostalCode(txtPostalCode.Text);
			dgDentists.DataSource = dsDentistsByPostalCode.Tables[0];
			dgDentists.DataBind();
		}

		private void cmdGetAllDentists_Click(object sender, System.EventArgs e)
		{
			//TODO Lab 13: call the XML Web service method
			//GetAllDentists
			BenefitsCS.DentalWebRef.DentalService1 ProxyGetAllDentists = new BenefitsCS.DentalWebRef.DentalService1();
			DataSet dsAllDentists = new DataSet();
			dsAllDentists = ProxyGetAllDentists.GetAllDentists();
			dgDentists.DataSource = dsAllDentists.Tables[0];
			dgDentists.DataBind();
		}

		private void txtPostalCode_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgDentists_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}