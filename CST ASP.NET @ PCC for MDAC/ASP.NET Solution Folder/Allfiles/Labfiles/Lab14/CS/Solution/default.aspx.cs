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
	/// Summary description for _default.
	/// </summary>
	public class _default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.CheckBoxList chkListBenefits;
		protected System.Web.UI.WebControls.Button cmdSubmit;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtLife;
		protected System.Web.UI.WebControls.TextBox txtDoctor;
		protected System.Web.UI.WebControls.Label lblSelections;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{ 
				//read benefits list from component and fill in checkbox list
				BenefitsListCS.Benefits clBenefits = new BenefitsListCS.Benefits();

				foreach (BenefitsListCS.Benefits.BenefitInfo bi in clBenefits.GetBenefitsList())
					chkListBenefits.Items.Add("<a href=" + bi.strPage + ">" + bi.strName + "</a>");
			}

			HttpCookie objGetCookie = Request.Cookies["Benefits"];
			string strDoc;
			string strLife;

			if (objGetCookie != null)
			{
				strDoc = objGetCookie.Values["doctor"];
				strLife = objGetCookie.Values["life"];
				txtDoctor.Text = strDoc;
				txtLife.Text = strLife;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdSubmit_Click(object sender, System.EventArgs e)
		{
			//output in a label the items that were selected
	        foreach (ListItem li in chkListBenefits.Items)
			{
				if (li.Selected)
					lblSelections.Text += (", " + li.Value);
			}
		}
	}
}