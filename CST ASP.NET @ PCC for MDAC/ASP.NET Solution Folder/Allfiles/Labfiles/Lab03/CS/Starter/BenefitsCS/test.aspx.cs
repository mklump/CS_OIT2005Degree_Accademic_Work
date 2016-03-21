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
	/// Summary description for test.
	/// </summary>
	public class test : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			BenefitsListCS.Benefits clBenefits = new BenefitsListCS.Benefits();

			Response.Write("<table border=1><tr><td>Benefit Name</td><td>Web Page</td></tr>");

			foreach(BenefitsListCS.Benefits.BenefitInfo bi in clBenefits.GetBenefitsList())
				Response.Write("<tr><td>" + bi.strName + "</td><td>" + bi.strPage + "</td></tr>");
					    
			Response.Write("</table>");
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
