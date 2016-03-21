//
//-------------------------------------------------------------------------------
// Module: Solution
// SubModule: Help.aspx.cs Code Behind File for the Help.aspx ASP.NET
//			  web application logic tier.
// Date:   April 8, 2005
// Purpose: Pleased to provide the C# Code Behind that must run for the
//			Puzzler - 3D Style Help Screen.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//
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
using System.Diagnostics;

namespace thepuzzler_3dstyle
{
	/// <summary>
	/// Summary description for Help.
	/// </summary>
	public class Help : System.Web.UI.Page
	{
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button ResetServer;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button BACK1;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button BACK2;
		/// <summary>
		/// System.Web.UI.WebControls.Label
		/// </summary>
		protected System.Web.UI.WebControls.Label Label1;

		/// <summary>
		/// Specifies where this page was navigated to from.
		/// </summary>
		public static string from;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
		}

		#region Web Form Designer generated code
		/// <summary>
		/// OnInit is responsible for handling the Initialization
		/// of the web application
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
			this.BACK2.Click += new System.EventHandler(this.BACK2_Click);
			this.ResetServer.Click += new System.EventHandler(this.ResetServer_Click);
			this.BACK1.Click += new System.EventHandler(this.BACK1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		/// <summary>
		/// Back button 1 click event handler
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">event arguements</param>
		private void BACK1_Click(object sender, System.EventArgs e)
		{
			string back = from;
			from = "Help.aspx";
			Response.Redirect( back, false );
		}
		/// <summary>
		/// Back button click event handler
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">event arguements</param>
		private void BACK2_Click(object sender, System.EventArgs e)
		{
			BACK1_Click( sender, e );
		}
		/// <summary>
		/// Reset web server click event handler
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">event arguements</param>
		private void ResetServer_Click(object sender, System.EventArgs e)
		{
			Process process = new Process();
			process.EnableRaisingEvents = false;
			process.StartInfo.FileName = "iisreset.exe";
			process.StartInfo.Arguments = "/restart";
			process.Start();
			process.WaitForExit();
		}
	}
}
