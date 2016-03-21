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
	/// Summary description for _Default.
	/// </summary>
	public class _Default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.DropDownList lstColor;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
	
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
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			//Response.Write(Application("NumberofVisitors"))
			Session["Color"] = lstColor.SelectedItem.Text;
			//Response.Write(Session("Color"))

			HttpCookie objCookie = new HttpCookie("nameCookie");
			DateTime time  = DateTime.Now;
			objCookie.Values.Add("Name", txtName.Text);
			objCookie.Values.Add("Time", time.ToString());
			objCookie.Expires = time.AddDays(5);

			Response.Cookies.Add(objCookie);
			Response.Redirect("results.aspx");
		}
	}
}
