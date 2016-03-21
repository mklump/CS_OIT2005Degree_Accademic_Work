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
	/// Summary description for securitytest.
	/// </summary>
	public class securitytest : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblAuthUser;
		protected System.Web.UI.WebControls.Label lblAuthType;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			lblAuthUser.Text = User.Identity.Name;
			lblAuthType.Text = User.Identity.AuthenticationType;
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
