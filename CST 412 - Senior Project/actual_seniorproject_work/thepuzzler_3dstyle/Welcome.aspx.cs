//
//-------------------------------------------------------------------------------
// Module: Solution
// SubModule: Welcome.aspx.cs Code Behind File for the Welcome.aspx ASP.NET
//			  web application logic tier.
// Date:   April 7, 2005
// Purpose: Pleased to provide the C# Code Behind that must run for the
//			Puzzler - 3D Style Welcome Screen.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//
#region Auto generated using statments
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
	/// Summary description for Welcome.
	/// </summary>
	public class Welcome : System.Web.UI.Page
	{
		#region Web user interface control variable declarations.
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl Div1;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl DIV2;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl DIV3;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl DIV4;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl DIV5;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl Div16;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl Div17;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl Div18;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl Div19;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl Div20;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl DIV6;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button HELP;
		#endregion

		/// <summary>
		/// This TextBox specifies which Base Dictionary to Generate the Actual
		/// Dictionary from.
		/// </summary>
		protected System.Web.UI.WebControls.TextBox textboxBASEDICTIONARY;
		/// <summary>
		/// This TextBox specifies the actual size of the Dictionary to create.
		/// </summary>
		protected System.Web.UI.WebControls.TextBox textboxDICTIONARYSIZE;
		/// <summary>
		/// This TextBox specifies the minimum size of any given word in the
		/// Dictionary.
		/// </summary>
		protected System.Web.UI.WebControls.TextBox textboxMINIMUMDICTIONARYWORDSIZE;
		/// <summary>
		/// This TextBox specifies the X variable length of the 3D puzzle.
		/// </summary>
		protected System.Web.UI.WebControls.TextBox textboxPUZZLE_X_LENGTH;
		/// <summary>
		/// This TextBox specifies the Y variable height of the 3D puzzle.
		/// </summary>
		protected System.Web.UI.WebControls.TextBox textboxPUZZLE_Y_LENGTH;
		/// <summary>
		/// This TextBox specifies the Z variable depth of the 3D puzzle;
		/// </summary>
		protected System.Web.UI.WebControls.TextBox textboxPUZZLE_Z_LENGTH;
		/// <summary>
		/// This Button submits the specified configuration for checking,
		/// to the next Review Configuration page.
		/// </summary>
		protected System.Web.UI.WebControls.Button SubmitConfiguration;
		/// <summary>
		/// Static reference to which base dictionary to use.
		/// </summary>
		public static string baseDictionary;
		/// <summary>
		/// Static reference to how big the dictionary should be.
		/// </summary>
		public static string dictionarySize;
		/// <summary>
		/// Static reference what minimum size of a dictionary word to use.
		/// </summary>
		public static string minimumSizeWord;
		/// <summary>
		/// Static reference to the X puzzle length.
		/// </summary>
		public static string puzzleX;
		/// <summary>
		/// Static reference to the Y puzzle height.
		/// </summary>
		public static string puzzleY;
		/// <summary>
		/// Static reference to the Z puzzle depth.
		/// </summary>
		public static string puzzleZ;
		/// <summary>
		/// No response flag to the "Configuration Okay?" question on Review Configuration page
		/// </summary>
		public static bool NO_Response;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if( !IsPostBack && NO_Response != true )
			{
				baseDictionary = "";
				dictionarySize = "";
				minimumSizeWord = "";
				puzzleX = "";
				puzzleY = "";
				puzzleZ = "";
				// LoadDefaultValues();
				Help.from = "./Welcome.aspx";
			}
			else if( NO_Response == true )
			{
				textboxBASEDICTIONARY.Text = baseDictionary;
				textboxDICTIONARYSIZE.Text = dictionarySize;
				textboxMINIMUMDICTIONARYWORDSIZE.Text = minimumSizeWord;
				textboxPUZZLE_X_LENGTH.Text = puzzleX;
				textboxPUZZLE_Y_LENGTH.Text = puzzleY;
				textboxPUZZLE_Z_LENGTH.Text = puzzleZ;
				NO_Response = false;
			}
		}

		#region Web Form Designer generated code
		/// <summary>
		/// On initionalization event handler
		/// </summary>
		/// <param name="e">Event arguement</param>
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
			this.SubmitConfiguration.Click += new System.EventHandler(this.SubmitConfiguration_Click);
			this.HELP.Click += new System.EventHandler(this.HELP_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Loads the default starting values if people don't want to enter anything.
		/// </summary>
		private void LoadDefaultValues()
		{
			textboxBASEDICTIONARY.Text = "1";
			textboxDICTIONARYSIZE.Text = "38621";
			textboxMINIMUMDICTIONARYWORDSIZE.Text = "3";
			textboxPUZZLE_X_LENGTH.Text = "25";
			textboxPUZZLE_Y_LENGTH.Text = "25";
			textboxPUZZLE_Z_LENGTH.Text = "25";
		}

		private void SubmitConfiguration_Click(object sender, System.EventArgs e)
		{
			baseDictionary = textboxBASEDICTIONARY.Text;
			dictionarySize = textboxDICTIONARYSIZE.Text;
			minimumSizeWord = textboxMINIMUMDICTIONARYWORDSIZE.Text;
			puzzleX = textboxPUZZLE_X_LENGTH.Text;
			puzzleY = textboxPUZZLE_Y_LENGTH.Text;
			puzzleZ = textboxPUZZLE_Z_LENGTH.Text;
			Response.Redirect( "./ReviewConfiguration.aspx", false );
		}

		private void HELP_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("./Help.aspx");
		}
	}
}
