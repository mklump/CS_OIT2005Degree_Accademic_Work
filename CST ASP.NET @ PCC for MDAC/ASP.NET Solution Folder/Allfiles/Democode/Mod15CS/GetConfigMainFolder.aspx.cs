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
using System.Configuration;

namespace Mod15CS
{
	/// <summary>
	/// Summary description for GetConfigMainFolder.
	/// </summary>
	public class GetConfigMainFolder : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button cmdNext;
		protected System.Web.UI.WebControls.Label label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			AppSettingsReader App = new AppSettingsReader();
			String strValue =  (String)App.GetValue("mySetting", typeof(string));
			label1.Text = strValue;
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
			this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdNext_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(".\\SubFolder\\GetConfigSubFolder.aspx");
		}
	}
}
