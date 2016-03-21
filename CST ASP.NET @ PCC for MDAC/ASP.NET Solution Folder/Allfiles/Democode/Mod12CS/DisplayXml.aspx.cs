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

namespace Mod12CS
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class DisplayXml : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgBooks;
		protected System.Web.UI.WebControls.Button cmdLoad;
		protected System.Web.UI.WebControls.DropDownList lstFileName;
		protected System.Web.UI.WebControls.Label Label1;
	
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
			this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cmdLoad_Click(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();

			ds.ReadXml(Server.MapPath(lstFileName.SelectedItem.ToString()));
			dgBooks.DataSource = ds;
			dgBooks.DataBind();
		}
	}
}
