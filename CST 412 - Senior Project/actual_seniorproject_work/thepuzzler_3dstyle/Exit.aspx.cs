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

namespace thepuzzler_3dstyle
{
	/// <summary>
	/// Summary description for Exit.
	/// </summary>
	public class Exit : System.Web.UI.Page
	{
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl DIV1;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl P1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		/// <summary>
		/// OnInit event handler
		/// </summary>
		/// <param name="e">Event Arguements</param>
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
