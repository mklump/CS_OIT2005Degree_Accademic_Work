//
//-------------------------------------------------------------------------------
// Module: Solution
// SubModule: ReviewConfiguration.aspx.cs Code Behind File for the
//			  ReviewConfiguration.aspx ASP.NET web application logic tier.
// Date:   April 7, 2005
// Purpose: Pleased to provide the C# Code Behind that must run for the
//			Puzzler - 3D Style ReviewConfiguration Screen.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//
#region Auto generated "using statements"
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

using PuzzleConfig;

namespace thepuzzler_3dstyle
{
	/// <summary>
	/// Summary description for ReviewConfiguration.
	/// </summary>
	[Serializable]
	public class ReviewConfiguration : System.Web.UI.Page
	{
		#region Web user interface control variable declarations.
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl DIV1;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlGenericControl
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl DIV5;
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
		protected System.Web.UI.HtmlControls.HtmlGenericControl DIV6;
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
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button HELP;
		#endregion

		/// <summary>
		/// Base dictionary input text box
		/// </summary>
		protected System.Web.UI.WebControls.TextBox BASEDICTIONARY;
		/// <summary>
		/// Dictionary size input text box
		/// </summary>
		protected System.Web.UI.WebControls.TextBox DICTIONARYSIZE;
		/// <summary>
		/// Minimum dictionary word size input text box
		/// </summary>
		protected System.Web.UI.WebControls.TextBox MINIMUMDICTIONARYWORDSIZE;
		/// <summary>
		/// Puzzle input box control group label
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl Puzzle_Label;
		/// <summary>
		/// Configuration question label
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl Config_Question;
		/// <summary>
		/// Dictionary input box control group label
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl Dictionary_Label;
		/// <summary>
		/// X variable puzzle length
		/// </summary>
		protected System.Web.UI.WebControls.TextBox PUZZLE_X_LENGTH;
		/// <summary>
		/// Y variable puzzle length
		/// </summary>
		protected System.Web.UI.WebControls.TextBox PUZZLE_Y_LENGTH;
		/// <summary>
		/// Z variable puzzle length
		/// </summary>
		protected System.Web.UI.WebControls.TextBox PUZZLE_Z_LENGTH;
		/// <summary>
		/// Button indicating YES
		/// </summary>
		protected System.Web.UI.WebControls.Button buttonYESRESPONSE;
		/// <summary>
		/// Button indicating NO
		/// </summary>
		protected System.Web.UI.WebControls.Button buttonNORESPONSE;
		/// <summary>
		/// Configuration status indicator
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlGenericControl StatusPanel;
		/// <summary>
		/// Represents the dictionary specifications for passing to Main.aspx Page
		/// </summary>
		private static int [] dictionarySpecs;
		/// <summary>
		/// Represents the three puzzle dimentions for verification
		/// </summary>
		private static int [] puzzleSizes;
		/// <summary>
		/// This pages HtmlTextWriter
		/// </summary>
		private HtmlTextWriter writer;
		/// <summary>
		/// Error indicator
		/// </summary>
		private static char errorNum;
		/// <summary>
		/// Helper string buffers for use with postback state retention.
		/// </summary>
		private static string status, question;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			writer = new HtmlTextWriter( Response.Output );
			if( !IsPostBack )
			{
				errorNum = ' ';
				question = status = null;
				PuzzleConfiguration.dictionarySpecs = dictionarySpecs = new int[3];
				PuzzleConfiguration.puzzleSizes = puzzleSizes = new int[3];
				BASEDICTIONARY.Text = Welcome.baseDictionary;
				DICTIONARYSIZE.Text = Welcome.dictionarySize;
				MINIMUMDICTIONARYWORDSIZE.Text = Welcome.minimumSizeWord;
				
				PUZZLE_X_LENGTH.Text = Welcome.puzzleX;
				PUZZLE_Y_LENGTH.Text = Welcome.puzzleY;
				PUZZLE_Z_LENGTH.Text = Welcome.puzzleZ;
				Help.from = "./ReviewConfiguration.aspx";
			}
			else if( errorNum == '0' )
			{
				PuzzleConfiguration.dictionarySpecs = dictionarySpecs;
				dictionarySpecs[0] = int.Parse( BASEDICTIONARY.Text );
				dictionarySpecs[1] = int.Parse( DICTIONARYSIZE.Text );
				dictionarySpecs[2] = int.Parse( MINIMUMDICTIONARYWORDSIZE.Text );
				PuzzleConfiguration.puzzleSizes = puzzleSizes;
				puzzleSizes[0] = int.Parse( PUZZLE_X_LENGTH.Text );
				puzzleSizes[1] = int.Parse( PUZZLE_Y_LENGTH.Text );
				puzzleSizes[2] = int.Parse( PUZZLE_Z_LENGTH.Text );
				Response.Redirect( "./GeneratingPuzzle.aspx", false );
			}
			if( status != null && question != null )
			{
				StatusPanel.InnerHtml = status;
				Config_Question.Style.Remove( "FONT-SIZE" );
				Config_Question.Style.Add( "FONT-SIZE", "32pt" );
				Config_Question.InnerHtml = question;
			}
		}

		#region Web Form Designer generated code
		/// <summary>
		/// On initialization event handler
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
			this.buttonYESRESPONSE.Click += new System.EventHandler(this.buttonYESRESPONSE_Click);
			this.buttonNORESPONSE.Click += new System.EventHandler(this.buttonNORESPONSE_Click);
			this.HELP.Click += new System.EventHandler(this.HELP_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void buttonNORESPONSE_Click(object sender, System.EventArgs e)
		{
			Welcome.NO_Response = true;
			Response.Redirect( "./Welcome.aspx", true );
		}

		private void buttonYESRESPONSE_Click(object sender, System.EventArgs e)
		{
			string errorCondition = "0";
			while( true )
			{
				errorCondition = PuzzleConfiguration.CheckIntegerInput(
					BASEDICTIONARY.Text,
					DICTIONARYSIZE.Text,
					MINIMUMDICTIONARYWORDSIZE.Text,
					PUZZLE_X_LENGTH.Text,
					PUZZLE_Y_LENGTH.Text,
					PUZZLE_Z_LENGTH.Text
					);
				if( errorCondition != "0" )
					break;
				errorCondition = PuzzleConfiguration.CheckDictionaryParameters(
					int.Parse(BASEDICTIONARY.Text),
					int.Parse(DICTIONARYSIZE.Text),
					int.Parse(MINIMUMDICTIONARYWORDSIZE.Text),
					puzzleSizes = ( puzzleSizes[0] == 0 ) ? new int[] {
						int.Parse(PUZZLE_X_LENGTH.Text),
						int.Parse(PUZZLE_Y_LENGTH.Text),
						int.Parse(PUZZLE_Z_LENGTH.Text)
						} :
						puzzleSizes
					);
				if( errorCondition != "0" )
					break;
				errorCondition = PuzzleConfiguration.CheckPuzzleParameters( puzzleSizes );
				errorNum = errorCondition[0];
				break;
			}
			if( errorNum != '0' )
			{
				errorNum = errorCondition[errorCondition.Length - 1];
				switch( errorNum )
				{
					case '1':
						BASEDICTIONARY.BackColor = Color.Red;
						DIV2.Style.Remove("BACKGROUND-COLOR");
						DIV2.Style.Add( "BACKGROUND-COLOR", "red" );
						DICTIONARYSIZE.BackColor = Color.White;
						DIV3.Style.Remove("BACKGROUND-COLOR");
						DIV3.Style.Add( "BACKGROUND-COLOR", "white" );
						MINIMUMDICTIONARYWORDSIZE.BackColor = Color.White;
						DIV4.Style.Remove("BACKGROUND-COLOR");
						DIV4.Style.Add( "BACKGROUND-COLOR", "white" );
						PUZZLE_X_LENGTH.BackColor = Color.White;
						Div17.Style.Remove("BACKGROUND-COLOR");
						Div17.Style.Add("BACKGROUND-COLOR","white");
						PUZZLE_Y_LENGTH.BackColor = Color.White;
						Div18.Style.Remove("BACKGROUND-COLOR");
						Div18.Style.Add("BACKGROUND-COLOR","white");
						PUZZLE_Z_LENGTH.BackColor = Color.White;
						Div19.Style.Remove("BACKGROUND-COLOR");
						Div19.Style.Add("BACKGROUND-COLOR","white");
						break;
					case '2':
						BASEDICTIONARY.BackColor = Color.White;
						DIV2.Style.Remove("BACKGROUND-COLOR");
						DIV2.Style.Add( "BACKGROUND-COLOR", "white" );
						DICTIONARYSIZE.BackColor = Color.Red;
						DIV3.Style.Remove("BACKGROUND-COLOR");
						DIV3.Style.Add( "BACKGROUND-COLOR", "red" );
						MINIMUMDICTIONARYWORDSIZE.BackColor = Color.White;
						DIV4.Style.Remove("BACKGROUND-COLOR");
						DIV4.Style.Add( "BACKGROUND-COLOR", "white" );
						PUZZLE_X_LENGTH.BackColor = Color.White;
						Div17.Style.Remove("BACKGROUND-COLOR");
						Div17.Style.Add("BACKGROUND-COLOR","white");
						PUZZLE_Y_LENGTH.BackColor = Color.White;
						Div18.Style.Remove("BACKGROUND-COLOR");
						Div18.Style.Add("BACKGROUND-COLOR","white");
						PUZZLE_Z_LENGTH.BackColor = Color.White;
						Div19.Style.Remove("BACKGROUND-COLOR");
						Div19.Style.Add("BACKGROUND-COLOR","white");
						break;
					case '3':
						BASEDICTIONARY.BackColor = Color.White;
						DIV2.Style.Remove("BACKGROUND-COLOR");
						DIV2.Style.Add( "BACKGROUND-COLOR", "white" );
						DICTIONARYSIZE.BackColor = Color.White;
						DIV3.Style.Remove("BACKGROUND-COLOR");
						DIV3.Style.Add( "BACKGROUND-COLOR", "white" );
						MINIMUMDICTIONARYWORDSIZE.BackColor = Color.Red;
						DIV4.Style.Remove("BACKGROUND-COLOR");
						DIV4.Style.Add( "BACKGROUND-COLOR", "red" );
						PUZZLE_X_LENGTH.BackColor = Color.White;
						Div17.Style.Remove("BACKGROUND-COLOR");
						Div17.Style.Add("BACKGROUND-COLOR","white");
						PUZZLE_Y_LENGTH.BackColor = Color.White;
						Div18.Style.Remove("BACKGROUND-COLOR");
						Div18.Style.Add("BACKGROUND-COLOR","white");
						PUZZLE_Z_LENGTH.BackColor = Color.White;
						Div19.Style.Remove("BACKGROUND-COLOR");
						Div19.Style.Add("BACKGROUND-COLOR","white");
						break;
//					default:
//						BASEDICTIONARY.BackColor = Color.White;
//						DIV2.Style.Remove("BACKGROUND-COLOR");
//						DIV2.Style.Add( "BACKGROUND-COLOR", "white" );
//						DICTIONARYSIZE.BackColor = Color.White;
//						DIV3.Style.Remove("BACKGROUND-COLOR");
//						DIV3.Style.Add( "BACKGROUND-COLOR", "white" );
//						MINIMUMDICTIONARYWORDSIZE.BackColor = Color.White;
//						DIV4.Style.Remove("BACKGROUND-COLOR");
//						DIV4.Style.Add( "BACKGROUND-COLOR", "white" );
//						break;
					case '4':
						BASEDICTIONARY.BackColor = Color.White;
						DIV2.Style.Remove("BACKGROUND-COLOR");
						DIV2.Style.Add( "BACKGROUND-COLOR", "white" );
						DICTIONARYSIZE.BackColor = Color.White;
						DIV3.Style.Remove("BACKGROUND-COLOR");
						DIV3.Style.Add( "BACKGROUND-COLOR", "white" );
						MINIMUMDICTIONARYWORDSIZE.BackColor = Color.White;
						DIV4.Style.Remove("BACKGROUND-COLOR");
						DIV4.Style.Add( "BACKGROUND-COLOR", "white" );
						PUZZLE_X_LENGTH.BackColor = Color.Red;
						Div17.Style.Remove("BACKGROUND-COLOR");
						Div17.Style.Add("BACKGROUND-COLOR","red");
						PUZZLE_Y_LENGTH.BackColor = Color.White;
						Div18.Style.Remove("BACKGROUND-COLOR");
						Div18.Style.Add("BACKGROUND-COLOR","white");
						PUZZLE_Z_LENGTH.BackColor = Color.White;
						Div19.Style.Remove("BACKGROUND-COLOR");
						Div19.Style.Add("BACKGROUND-COLOR","white");
						break;
					case '5':
						BASEDICTIONARY.BackColor = Color.White;
						DIV2.Style.Remove("BACKGROUND-COLOR");
						DIV2.Style.Add( "BACKGROUND-COLOR", "white" );
						DICTIONARYSIZE.BackColor = Color.White;
						DIV3.Style.Remove("BACKGROUND-COLOR");
						DIV3.Style.Add( "BACKGROUND-COLOR", "white" );
						MINIMUMDICTIONARYWORDSIZE.BackColor = Color.White;
						DIV4.Style.Remove("BACKGROUND-COLOR");
						DIV4.Style.Add( "BACKGROUND-COLOR", "white" );
						PUZZLE_X_LENGTH.BackColor = Color.White;
						Div17.Style.Remove("BACKGROUND-COLOR");
						Div17.Style.Add("BACKGROUND-COLOR","white");
						PUZZLE_Y_LENGTH.BackColor = Color.Red;
						Div18.Style.Remove("BACKGROUND-COLOR");
						Div18.Style.Add("BACKGROUND-COLOR","red");
						PUZZLE_Z_LENGTH.BackColor = Color.White;
						Div19.Style.Remove("BACKGROUND-COLOR");
						Div19.Style.Add("BACKGROUND-COLOR","white");
						break;
					case '6':
						BASEDICTIONARY.BackColor = Color.White;
						DIV2.Style.Remove("BACKGROUND-COLOR");
						DIV2.Style.Add( "BACKGROUND-COLOR", "white" );
						DICTIONARYSIZE.BackColor = Color.White;
						DIV3.Style.Remove("BACKGROUND-COLOR");
						DIV3.Style.Add( "BACKGROUND-COLOR", "white" );
						MINIMUMDICTIONARYWORDSIZE.BackColor = Color.White;
						DIV4.Style.Remove("BACKGROUND-COLOR");
						DIV4.Style.Add( "BACKGROUND-COLOR", "white" );
						PUZZLE_X_LENGTH.BackColor = Color.White;
						Div17.Style.Remove("BACKGROUND-COLOR");
						Div17.Style.Add("BACKGROUND-COLOR","white");
						PUZZLE_Y_LENGTH.BackColor = Color.White;
						Div18.Style.Remove("BACKGROUND-COLOR");
						Div18.Style.Add("BACKGROUND-COLOR","white");
						PUZZLE_Z_LENGTH.BackColor = Color.Red;
						Div19.Style.Remove("BACKGROUND-COLOR");
						Div19.Style.Add("BACKGROUND-COLOR","red");
						break;
					default:
						BASEDICTIONARY.BackColor = Color.White;
						DIV2.Style.Remove("BACKGROUND-COLOR");
						DIV2.Style.Add( "BACKGROUND-COLOR", "white" );
						DICTIONARYSIZE.BackColor = Color.White;
						DIV3.Style.Remove("BACKGROUND-COLOR");
						DIV3.Style.Add( "BACKGROUND-COLOR", "white" );
						MINIMUMDICTIONARYWORDSIZE.BackColor = Color.White;
						DIV4.Style.Remove("BACKGROUND-COLOR");
						DIV4.Style.Add( "BACKGROUND-COLOR", "white" );
						PUZZLE_X_LENGTH.BackColor = Color.White;
						Div17.Style.Remove("BACKGROUND-COLOR");
						Div17.Style.Add("BACKGROUND-COLOR","white");
						PUZZLE_Y_LENGTH.BackColor = Color.White;
						Div18.Style.Remove("BACKGROUND-COLOR");
						Div18.Style.Add("BACKGROUND-COLOR","white");
						PUZZLE_Z_LENGTH.BackColor = Color.White;
						Div19.Style.Remove("BACKGROUND-COLOR");
						Div19.Style.Add("BACKGROUND-COLOR","white");
						break;
				}
				StatusPanel.InnerHtml = "<p><p>" + errorCondition.TrimEnd(
					new char[] {' ','1','2','3','4','5','6'} ) + "<br>Please click the \"NO\" button" +
						" to go back and re-enter the required specification." + "</p></p>";
				StatusPanel.RenderControl( writer );
			}
			else
			{
				StatusPanel.InnerHtml = "\r\n\t\t\t\t<FONT style=\"FONT-SIZE: 20px\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\r\n\t\t\t\t\t<STRONG>Configuration Okay!</STRONG></FONT>\r\n\t\t\t\t<UL>\r\n\t\t\t\t\t<LI>\r\n\t\t\t\t\t\t<FONT style=\"FONT-SIZE: 16px\">Please review the dictionary and puzzle \r\n\t\t\t\t\t\t\tspecifications. To proceed&nbsp;click \"Yes\" to check the&nbsp;specifications or \r\n\t\t\t\t\t\t\tclick \"No\" to go back and re-enter the specifications.</FONT>\r\n\t\t\t\t\t<LI>\r\n\t\t\t\t\t\t<FONT style=\"FONT-SIZE: 16px\">Extremely large values will cause the application to \r\n\t\t\t\t\t\t\tstop responding.</FONT>\r\n\t\t\t\t\t<LI>\r\n\t\t\t\t\t\t<FONT style=\"FONT-SIZE: 16px\">Tips for the Dictionary: </FONT><font style=\"FONT-SIZE: 14px\">\r\n\t\t\t\t\t\t\t<UL>\r\n\t\t\t\t\t\t\t\t<LI>\r\n\t\t\t\t\t\t\t\tOnly specify the base dictionaries 1 through 4.\r\n\t\t\t\t\t\t\t\t"
					+ "<LI>\r\n\t\t\t\t\t\t\t\tThe size should be at least 1000 words and idealy less than 25000 words.\r\n\t\t\t\t\t\t\t\t<LI>\r\n\t\t\t\t\t\t\t\tOn base dictionary #1, the size should not be more than 38,622 words.\r\n\t\t\t\t\t\t\t\t<LI>\r\n\t\t\t\t\t\t\t\tOn base dictionary #2, the size should not be more than 106,249 words.\r\n\t\t\t\t\t\t\t\t<LI>\r\n\t\t\t\t\t\t\t\tOn base dictionary #3, the size should not be more than 213,558 words.\r\n\t\t\t\t\t\t\t\t<LI>\r\n\t\t\t\t\t\t\t\tOn base dictionary #4, the size should not be more than 869,230 words.\r\n\t\t\t\t\t\t\t\t<LI>\r\n\t\t\t\t\t\t\t\t\tThe Minimum Word Length should be at least 3 characters and not more than any \r\n\t\t\t\t\t\t\t\t\tlength of the puzzle.</LI></UL>\r\n\t\t\t\t\t\t</font>\r\n\t\t\t\t\t<LI>\r\n\t\t\t\t\t\t<FONT style=\"FONT-SIZE: 16px\">Tips for the Puzzle: </FONT><font style=\"FONT-SIZE: 14px\">\r\n\t\t\t\t\t\t\t<UL>\r\n\t\t\t\t\t\t\t\t<LI>\r\n\t\t\t\t\t\t\t\tThe puzzle lengths/measurements can be anything, however,\r\n\t\t\t\t\t\t\t\t<LI>\r\n\t\t\t\t\t\t\t\t\tthe puzzle lengths/measurements longer than 100 tend to take exponentially \r\n\t\t\t\t\t\t\t\t\tlonger to create and to solve.</LI></UL>\r\n\t\t\t\t\t\t</font>\r\n\t\t\t\t\t</LI>\r\n\t\t\t\t</UL>\r\n\t\t\t";
				Config_Question.Style.Remove( "FONT-SIZE" );
				Config_Question.Style.Add( "FONT-SIZE", "32pt" );
				question = Config_Question.InnerHtml = "Proceed?";
				Config_Question.RenderControl( writer );
				status = StatusPanel.InnerHtml;
				StatusPanel.RenderControl( writer );
			}
		} // End Of private void buttonYESRESPONSE_Click(object sender, System.EventArgs e)

		private void HELP_Click(object sender, System.EventArgs e)
		{
			Response.Redirect( "./Help.aspx", false );
		}
	}
}
