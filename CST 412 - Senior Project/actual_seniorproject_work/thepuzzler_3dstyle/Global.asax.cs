using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

namespace thepuzzler_3dstyle 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		/// <summary>
		/// Global operation
		/// </summary>
		public Global()
		{
			InitializeComponent();
		}	
		/// <summary>
		/// Application_Start Operation Event Handler
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">event arguement</param>
		protected void Application_Start(Object sender, EventArgs e)
		{
		}
		/// <summary>
		/// Session_Start Operation Event Handler
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">event arguement</param>
		protected void Session_Start(Object sender, EventArgs e)
		{
		}
		/// <summary>
		/// Application_BeginRequest Event Handler
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">event arguement</param>
		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
		}
		/// <summary>
		/// Application_EndRequest Operation Event Handler
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e"></param>
		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}
		/// <summary>
		/// Application_AuthenticateRequest Operation Event Handler
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">event areguement</param>
		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
		}
		/// <summary>
		/// Application_Error Operation Event Handler
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">event areguement</param>
		protected void Application_Error(Object sender, EventArgs e)
		{
		}
		/// <summary>
		/// Session_End Operation Event Handler
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">event areguement</param>
		protected void Session_End(Object sender, EventArgs e)
		{
		}
		/// <summary>
		/// Application_End Operation Event Handler
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">event areguement</param>
		protected void Application_End(Object sender, EventArgs e)
		{
		}
	
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

