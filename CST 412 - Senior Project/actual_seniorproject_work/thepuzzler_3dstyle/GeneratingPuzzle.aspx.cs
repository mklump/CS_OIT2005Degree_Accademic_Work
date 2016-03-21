//
//-------------------------------------------------------------------------------
// Module: Solution
// SubModule: GeneratingPuzzle.aspx.cs Code Behind File for the
//			  GeneratingPuzzle.aspx ASP.NET web application logic tier.
// Date:   April 8, 2005
// Purpose: Pleased to provide the C# Code Behind that must run for the
//			Puzzler - 3D Style ReviewConfiguration Screen.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//
#region Auto generated using statements
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
#endregion

namespace thepuzzler_3dstyle
{
	/// <summary>
	/// Summary description for GeneratingPuzzle.
	/// </summary>
	public class GeneratingPuzzle : System.Web.UI.Page
	{
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl DIV1;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlInputButton
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlInputButton continue1;
		/// <summary>
		/// protected System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl P1;
		/// <summary>
		/// protected System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl P2;
		/// <summary>
		/// protected System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl P3;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl GenPuzzleLayout;
		/// <summary>
		/// HtmlTextWriter for the current page request
		/// </summary>
		private HtmlTextWriter writer;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			writer = new HtmlTextWriter( Response.Output );
			if( !IsPostBack )
			{
				continue1.Disabled = false;
				DataBind();
			}
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Web Form Designer generated code: override protected void OnInit(EventArgs e)
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
			this.continue1.ServerClick += new System.EventHandler(this.continue1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Used to Trigger a post back event progmatically
		/// </summary>
		private void GetPostBack()
		{
			this.Page.GetPostBackEventReference(this, "RaisePostBackEvent");
		}
		/// <summary>
		/// Implement the RaisePostBackEvent method from the
		/// IPostBackEventHandler interface.
		/// </summary>
		/// <param name="eventArgument">Event Argument Specification</param>
		public void RaisePostBackEvent(string eventArgument)
		{
			return;
		}
		/// <summary>
		/// Html server button continue1 click event handler
		/// </summary>
		/// <param name="sender">object sender source</param>
		/// <param name="e">Event Arguement(s)</param>
		private void continue1_ServerClick(object sender, System.EventArgs e)
		{
			Response.Redirect( "./Main.aspx", true );
		}
	}
}
