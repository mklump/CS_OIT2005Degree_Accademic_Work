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
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		/// <summary>
		/// System.Web.UI.WebControls.ListBox
		/// </summary>
		protected System.Web.UI.WebControls.ListBox ListBox1;
		/// <summary>
		/// System.Web.UI.WebControls.ListBox
		/// </summary>
		protected System.Web.UI.WebControls.ListBox ListBox2;
		/// <summary>
		/// System.Web.UI.WebControls.Label
		/// </summary>
		protected System.Web.UI.WebControls.Label Label2;
		/// <summary>
		/// System.Web.UI.WebControls.DropDownList
		/// </summary>
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		/// <summary>
		/// System.Web.UI.WebControls.Label
		/// </summary>
		protected System.Web.UI.WebControls.Label Label3;
		/// <summary>
		/// System.Web.UI.WebControls.Label
		/// </summary>
		protected System.Web.UI.WebControls.Label Label4;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlTable
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlTable Table1;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button SolvePuzzle;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button GetStats;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button Help;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button StartOver;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button Exit;
		/// <summary>
		/// System.Web.UI.WebControls.Label
		/// </summary>
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		/// <summary>
		/// OnInit is responsible for handling the On-Initialization of the web application.
		/// </summary>
		/// <param name="e">EventArgs</param>
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
