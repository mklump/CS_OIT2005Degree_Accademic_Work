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
	/// Summary description for results.
	/// </summary>
	public class results : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblWelcome;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtHits;
		protected System.Web.UI.WebControls.Label lblTime;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Application.Lock();
				Application["NumberofVisitors"] = 
					(int)Application["NumberofVisitors"] + 1;
				Application.UnLock();
			}

			HttpCookie objCookie = Request.Cookies["nameCookie"];
			string strName = objCookie.Values["name"];
			string strColor = (string)Session["Color"];

			lblWelcome.Text = "Welcome " + strName + "!"
						+ "  Your favorite color is: " + strColor;

			lblTime.Text = lblTime.Text + objCookie.Values["Time"];

			txtHits.Text = Application["NumberofVisitors"].ToString();
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
