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
	public partial class dental : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
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

		}
		#endregion

		protected void cmdSubmit_Click(object sender, System.EventArgs e)
		{
			//TODO Lab 13: call the XML Web service method
			DentalWebRef.DentalService1 ProxyGetDentistsByPostalCode =
				new BenefitsCS.DentalWebRef.DentalService1();
			DataSet dsDentistsByPostalCode = new DataSet();
			dsDentistsByPostalCode =
				ProxyGetDentistsByPostalCode.GetDentistsByPostalCode( txtPostalCode.Text );
			dgDentists.DataSource = dsDentistsByPostalCode;
			dgDentists.DataBind();
		}

		protected void cmdGetAllDentists_Click(object sender, System.EventArgs e)
		{
			//TODO Lab 13: call the XML Web service method
            DentalWebRef.DentalService1 ProxyGetAllDentists = new BenefitsCS.DentalWebRef.DentalService1();
			DataSet dsAllDentists = new DataSet();
			dsAllDentists = ProxyGetAllDentists.GetAllDentists();
			dgDentists.DataSource = dsAllDentists;
			dgDentists.DataBind();
		}

		protected void txtPostalCode_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void dgDentists_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}