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
	/// Summary description for life.
	/// </summary>
	public class life : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtBirth;
		protected System.Web.UI.WebControls.TextBox txtCoverage;
		protected System.Web.UI.WebControls.CheckBox chkShortTerm;
		protected System.Web.UI.WebControls.CheckBox chkLongTerm;
		protected System.Web.UI.WebControls.Button cmdSave;
		protected System.Web.UI.WebControls.Calendar Calendar1;
		protected System.Web.UI.WebControls.CompareValidator vldBirthType;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldBirth;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldName;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldCoverage;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldCoverageType;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.ValidationSummary vldSummary;
		protected System.Web.UI.WebControls.Label Label7;
	
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
			this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				lblMessage.Text = "Valid!";

				//TODO Lab 14: Set Session Variables

	            		//TODO Lab 14: Build the string
				//if (chkShortTerm.Checked)
				//{
				//	if (chkLongTerm.Checked)
				//	{
				//		strLife = "Short Term and Long Term";
				//	}
				//	else
				//	{
				//		strLife = "Short Term";
				//	}
				//}
				//else
				//{
				//	if (chkLongTerm.Checked)
				//	{
				//		strLife = "Long Term";
				//	}
				//}
				//strLife += ": Coverage = $" + txtCoverage.Text;
			}
		}
	}
}
