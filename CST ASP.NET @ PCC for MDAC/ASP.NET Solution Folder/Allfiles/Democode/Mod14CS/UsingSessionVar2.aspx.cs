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

namespace Mod14CS
{
	/// <summary>
	/// Summary description for UsingSessionVar2.
	/// </summary>
	public class UsingSessionVar2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSessionVar;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Session["intNumber"] = Convert.ToInt16(Session["intNumber"]) + 4;
			lblSessionVar.Text = Session["intNumber"].ToString();
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
