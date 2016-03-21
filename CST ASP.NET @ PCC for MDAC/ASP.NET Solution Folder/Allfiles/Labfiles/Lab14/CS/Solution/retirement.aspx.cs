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
	/// Summary description for retirement.
	/// </summary>
	public class retirement : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtVisits;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid dgRetirement;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//TODO Lab 12: Create a dataset, fill it out with the
				//XML file, and display it

				DataSet dsRetirement = new DataSet();
				dsRetirement.ReadXml(Server.MapPath("mutual_funds.xml"));
				dgRetirement.DataSource = dsRetirement;
				dgRetirement.DataBind();

				Application.Lock();
				Application["Visits"] = Convert.ToInt16(Application["Visits"]) + 1;
				Application.UnLock();
			}

			txtVisits.Text = Application["Visits"].ToString();

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
