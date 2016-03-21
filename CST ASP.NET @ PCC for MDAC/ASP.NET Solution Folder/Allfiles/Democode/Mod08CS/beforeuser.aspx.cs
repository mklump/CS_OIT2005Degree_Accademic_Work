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

namespace Mod08CS
{
	/// <summary>
	/// Summary description for beforeuser.
	/// </summary>
	public class beforeuser : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtNum1;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtNumValidator1;
		protected System.Web.UI.WebControls.RangeValidator txtNumRngValidator1;
		protected System.Web.UI.WebControls.TextBox txtNum2;
		protected System.Web.UI.WebControls.RequiredFieldValidator txtNumValidator2;
		protected System.Web.UI.WebControls.RangeValidator txtNumRngValidator2;
		protected System.Web.UI.WebControls.Label lblSum;
		protected System.Web.UI.WebControls.Button Button1;
	
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			//check Page.IsValid
			if (Page.IsValid)
				lblSum.Text = Convert.ToString(Convert.ToInt32(txtNum1.Text) + Convert.ToInt32(txtNum2.Text));
		}
	}
}
