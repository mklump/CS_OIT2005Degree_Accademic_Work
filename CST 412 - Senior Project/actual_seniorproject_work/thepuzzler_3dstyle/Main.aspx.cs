//
//-------------------------------------------------------------------------------
// Module: Solution
// SubModule: Main.aspx.cs Code Behind File for the Main.aspx ASP.NET
//			  web application logic tier.
// Date:   February 25, 2005
// Purpose: Pleased to provide the C# Code Behind that must run for the
//			Puzzler - 3D Style Main Interaction Screen.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//

#region "VS.NET" inserted using statments.
using System;
using System.IO;
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

using ManageDB;
using Puzzle_Solution;
using ns_DictionaryCreator;
using Puzzle_Creation;
using ns_RedBlack;
using PuzzleConfig;
using ns_ManageStats;

namespace thepuzzler_3dstyle  
{
	/// <summary>
	/// Summary description for MainWebForm.
	/// </summary>
	public class MainWebForm : System.Web.UI.Page
	{
		#region Web user interface control variable declarations.
		/// <summary>
		/// System.Web.UI.WebControls.Label
		/// </summary>
		protected System.Web.UI.WebControls.Label WordsFound_VS_DictionarySize;
		/// <summary>
		/// System.Web.UI.WebControls.Label
		/// </summary>
		protected System.Web.UI.WebControls.Label PuzzleSize;
		/// <summary>
		/// System.Web.UI.WebControls.Label
		/// </summary>
		protected System.Web.UI.WebControls.Label Label2;
		/// <summary>
		/// System.Web.UI.WebControls.Label
		/// </summary>
		protected System.Web.UI.WebControls.Label Label3;
		/// <summary>
		/// System.Web.UI.WebControls.Label
		/// </summary>
		protected System.Web.UI.WebControls.Label Label4;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button Get_Lists;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button Get_Puzzle;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button SolvePuzzle;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button SingleThreadSolution;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button GetStats;
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
		protected System.Web.UI.WebControls.Label Label5;
		/// <summary>
		/// System.Web.UI.WebControls.Label
		/// </summary>
		protected System.Web.UI.WebControls.Label Label6;
		/// <summary>
		/// System.Web.UI.WebControls.Label
		/// </summary>
		protected System.Web.UI.WebControls.Label Label1;
		/// <summary>
		/// System.Web.UI.WebControls.DropDownList
		/// </summary>
		protected System.Web.UI.WebControls.DropDownList DictionaryViewControl;
		/// <summary>
		/// System.Web.UI.WebControls.DropDownList
		/// </summary>
		protected System.Web.UI.WebControls.DropDownList WordsMatchedViewControl;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlTable
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlTable StatisticsView;
		/// <summary>
		/// System.Web.UI.HtmlControls.HtmlTable
		/// </summary>
		protected System.Web.UI.HtmlControls.HtmlTable PuzzleView;
		/// <summary>
		/// System.Web.UI.WebControls.AdRotator
		/// </summary>
		protected System.Web.UI.WebControls.AdRotator CubeImageRotator;
		/// <summary>
		/// System.Web.UI.WebControls.ListBox
		/// </summary>
		protected System.Web.UI.WebControls.ListBox DictionaryListBox;
		/// <summary>
		/// System.Web.UI.WebControls.ListBox
		/// </summary>
		protected System.Web.UI.WebControls.ListBox WordsFound;
		/// <summary>
		/// protected System.Web.UI.WebControls.DropDownList
		/// </summary>
		protected System.Web.UI.WebControls.DropDownList DirectionDropDownList;
		/// <summary>
		/// protected System.Web.UI.WebControls.DropDownList
		/// </summary>
		protected System.Web.UI.WebControls.DropDownList Cross_sectionDropDownList;
		/// <summary>
		/// System.Web.UI.WebControls.Button
		/// </summary>
		protected System.Web.UI.WebControls.Button HELP;
		#endregion

		/// <summary>
		/// Saved state variable, boundary marker, or list control variable.
		/// </summary>
		protected static int pre_cross_section, pre_direction,
			xbound, ybound, zbound, list_counter;
		private static string wordsFoundResult;
		/// <summary>
		/// This ArrayList collection will keep track of the statistical
		/// results posted to the StatisticsView HtmlTable display.
		/// </summary>
		protected static ArrayList statistics;
		/// <summary>
		/// HtmlTextWriter used to output each HtmlTable's content.
		/// </summary>
		protected static HtmlTextWriter writer;
		/// <summary>
		/// HtmlTableRow for the StatisticsView and PuzzleView HTML table construction.
		/// </summary>
		protected static HtmlTableRow row;
		/// <summary>
		/// HtmlTableCell for the StatisticsView and PuzzleView HTML table construction.
		/// </summary>
		protected static HtmlTableCell cell;
		/// <summary>
		/// This is responsible for handling the execution and timing statistics for the
		/// various C# logic components to this project.
		/// </summary>
		public static ManageStats managestats;
		/// <summary>
		/// Data base connection for database.
		/// </summary>
		public static ManageDataBase manageDB;
	
		/// <summary>
		/// Main load page event handler
		/// </summary>
		/// <param name="sender">sender idenitifier</param>
		/// <param name="e">Event arguements</param>
		public void Page_Load(object sender, System.EventArgs e)
		{
			list_counter = 0;
			writer = CreateHtmlTextWriter( Response.Output );
			if( !Page.IsPostBack )
			{
				if( Help.from != "Help.aspx" && Help.from != "Main.aspx" )
				{
					manageDB = new ManageDataBase();
					managestats = new ManageStats();
					statistics = new ArrayList(0);
					LoadStatistics();
				}

				WordsFound_VS_DictionarySize.Text = wordsFoundResult;
				DictionaryListBox.Items.Clear();
				InitializeDictionaryListBox( managestats.solution.Dictionary, ' ' );
				Init_DirectionDropDownList();
				xbound = managestats.puzzleCreator.GetBoundaries()[0];
				ybound = managestats.puzzleCreator.GetBoundaries()[1];
				zbound = managestats.puzzleCreator.GetBoundaries()[2];
				WordsFound_VS_DictionarySize.Text = "The dictionary size is " +
					managestats.dictionaryCreator.DictionarySize.ToString() +
					" words.";
				PuzzleSize.Text = "The puzzle is " + xbound + " x " +
					ybound + " x " + zbound + " dimentional lengths.";
				Cross_sectionDropDownList.Items.Add( new ListItem(
					"Please select cross section parallel to direction." ));
				Select_Layer( 0, -1 ); // Start the default layer selection view
				Help.from = "Main.aspx";
				DataBind();
			}
			// Refresh the statistics view
			ReDrawStatisticsView();
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
			this.Cross_sectionDropDownList.SelectedIndexChanged += new System.EventHandler(this.Cross_sectionDropDownList_SelectedIndexChanged);
			this.SingleThreadSolution.Click += new System.EventHandler(this.SingleThreadSolution_Click);
			this.DictionaryListBox.SelectedIndexChanged += new System.EventHandler(this.DictionaryListBox_SelectedIndexChanged);
			this.DictionaryViewControl.SelectedIndexChanged += new System.EventHandler(this.DictionaryViewControl_SelectedIndexChanged);
			this.WordsMatchedViewControl.SelectedIndexChanged += new System.EventHandler(this.WordsMatchedViewControl_SelectedIndexChanged);
			this.Exit.Click += new System.EventHandler(this.Exit_Click);
			this.StartOver.Click += new System.EventHandler(this.StartOver_Click);
			this.HELP.Click += new System.EventHandler(this.HELP_Click);
			this.GetStats.Click += new System.EventHandler(this.GetStats_Click);
			this.WordsFound.SelectedIndexChanged += new System.EventHandler(this.WordsFound_SelectedIndexChanged);
			this.DirectionDropDownList.SelectedIndexChanged += new System.EventHandler(this.DirectionDropDownList_SelectedIndexChanged);
			this.SolvePuzzle.Click += new System.EventHandler(this.SolvePuzzle_Click);
			this.Get_Puzzle.Click += new System.EventHandler(this.Get_Puzzle_Click);
			this.Get_Lists.Click += new System.EventHandler(this.Get_Lists_Click);
			this.CubeImageRotator.AdCreated += new System.Web.UI.WebControls.AdCreatedEventHandler(this.CubeImageRotator_AdCreated);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SolvePuzzle_Click(object sender, System.EventArgs e)
		{
			if( managestats.solution.WordsFound.Key == null )
			{
				Solution.IsMultiThreaded =
					( ((Button)sender).Text == "Single Threaded Solution")
					? false : true;
				list_counter = managestats.GetSolutionTime( ref StatisticsView, ref statistics );
				wordsFoundResult = string.Format("The Solver has found {0} " + 
					"out of {1} words.", list_counter,
					managestats.dictionaryCreator.DictionarySize );
				WordsFound_VS_DictionarySize.Text = wordsFoundResult;
			}

			ReDrawStatisticsView();
			RedrawPuzzle();
			list_counter = 0;
			InitializeWordsFoundListBox( managestats.solution.WordsFound, ' ' );

			// Store the resulting objects to the database
			manageDB.Call_StorePuzzlerRun( ref managestats.solution, ref managestats );

			DirectionDropDownList.Enabled = true;
			Cross_sectionDropDownList.Enabled = true;
			GetStats.Enabled = true;
			StartOver.Enabled = true;
			SolvePuzzle.Enabled = false;
			SingleThreadSolution.Enabled = false;
		}
		private void SingleThreadSolution_Click(object sender, System.EventArgs e)
		{
			SolvePuzzle_Click( sender, e );
		}
		/// <summary>
		/// This Method Will run the Dictionary Creator, the Puzzle Generator,
		/// the Puzzle Solver, and render the HtmlTable StatisticsView.
		/// </summary>
		public void LoadStatistics()
		{
			// Create Dictionary and the Puzzle and display
			// their time taken to execute in the StatisticsView
			// HtmlTable Control.
			managestats.GetDictionaryTime(
				ref StatisticsView,
				PuzzleConfiguration.dictionarySpecs[0], 
				PuzzleConfiguration.dictionarySpecs[1],
				PuzzleConfiguration.dictionarySpecs[2],
				statistics ); // <-- Set Dictionary here!

			managestats.GetPuzzleTime( ref StatisticsView, ref statistics );
			// Write out the Html.
			StatisticsView.RenderControl( writer );
			// Disable the other controls.
			DirectionDropDownList.Enabled = true;
			Cross_sectionDropDownList.Enabled = true;
			GetStats.Enabled = false;
			StartOver.Enabled = false;
		}
		/// <summary>
		/// This helper operation will redraw the StatisticsView HTML Table
		/// control.
		/// </summary>
		private void ReDrawStatisticsView()
		{
			StatisticsView.Controls.Clear();
			foreach( string str in statistics )
			{
				row = new HtmlTableRow();
				cell = new HtmlTableCell();
				cell.Controls.Add( new LiteralControl( str ) );
				row.Controls.Add( cell );
				StatisticsView.Controls.Add( row );
			}
			StatisticsView.RenderControl( writer );
		}
		/// <summary>
		/// This method's responsibility is to print the appropriate crossectional
		/// view of the inside of the puzzle.
		/// </summary>
		/// <param name="direction">Specifies which of thirteen views to look at. The default
		/// is zero.</param>
		/// <param name="cross_section">Specifies which crossectional "cut" to display
		/// in the puzzle display area. The default is zero.</param>
		public void Select_Layer( int direction, int cross_section )
		{
			int x = 0, y = 0, z = 0, select = 0; 
			pre_cross_section = cross_section;
			pre_direction = direction;
			direction = ( DirectionDropDownList.SelectedIndex <= 1 ) ?
				managestats.puzzleCreator.Direction :
				DirectionDropDownList.SelectedIndex;
			switch( direction )
			{
				case 1:
				case 2:
				case 10: /* North to South and South to North, Corner to Corner
							* and Edge to Edge directions
							*/
					for( y = ybound - 1; y > -1; y-- )
					{
						x = z = 0;
						row = new HtmlTableRow();
						if( xbound > zbound )
						{
							select = xbound - zbound; // default cross_section selection
							cross_section = ( cross_section > (xbound - zbound) ) ||
								( cross_section < 0 ) ? select : cross_section;
							x = cross_section;
						}
						else if( zbound > xbound )
						{
							select = zbound - xbound; // default cross_section selection
							cross_section = ( cross_section > (zbound - xbound) ) ||
								( cross_section < 0 ) ? select : cross_section;
							z = cross_section;
						}
						else
							select = xbound;
						while( x < xbound && z < zbound )
						{
							cell = new HtmlTableCell();
							cell.Controls.Add( new LiteralControl(
								managestats.solution.Puzzle[x, y, z].ToString() ) );
							row.Cells.Add( cell );
							x = x + 1;
							z = z + 1;
						}
						PuzzleView.Rows.Add( row );
					}
					if( !Page.IsPostBack )
					{
						for( x = 0; x < select; x++ )
							Cross_sectionDropDownList.Items.Add( new ListItem( x.ToString() ));
						Cross_sectionDropDownList.SelectedIndex = cross_section;
					}
					break;
				case 3:
				case 4:
				case 9: /* West to East and East to West, Corner to Corner
							* and Edge to edge directions
							*/
					for( y = ybound - 1; y > -1; y-- )
					{
						x = 0;
						z = zbound - 1;
						row = new HtmlTableRow();
						if( xbound > zbound )
						{
							select = xbound - zbound; // default cross_section selection
							cross_section = ( cross_section > (xbound - zbound) ) ||
								( cross_section < 0 ) ? select : cross_section;
							x = cross_section;
						}
						else if( zbound > xbound )
						{
							select = z - (zbound - xbound); // default cross_section selection
							cross_section = ( cross_section > (zbound - xbound) ) ||
								( cross_section < 0 ) ? select : cross_section;
							z = cross_section;
						}
						else
							select = xbound;
						while( x < xbound && z > -1 )
						{
							cell = new HtmlTableCell();
							cell.Controls.Add( new LiteralControl(
								managestats.solution.Puzzle[x , y, z].ToString() ) );
							row.Cells.Add( cell );
							x = x + 1;
							z = z - 1;
						}
						PuzzleView.Rows.Add( row );
					}
					if( !Page.IsPostBack )
					{
						for( x = 0; x < select; x++ )
							Cross_sectionDropDownList.Items.Add( new ListItem( x.ToString() ));
						Cross_sectionDropDownList.SelectedIndex = cross_section;
					}
					break;
				case 5:
				case 7:
				case 13: /* North East to South West and South West to North
							* East, Edge to Edge and Side to Side directions.
							*/
					for( y = ybound - 1; y > -1; y-- )
					{
						row = new HtmlTableRow();
						select = 0; // default cross_section selection
						cross_section = ( cross_section > xbound ) ||
							( cross_section < 0 ) ? select : cross_section;
						for( x = cross_section, z = (zbound - 1)/ 2; x < xbound; x++ )
						{
							cell = new HtmlTableCell();
							cell.Controls.Add( new LiteralControl(
								managestats.solution.Puzzle[x, y, z].ToString() ) );
							row.Cells.Add( cell );
						}
						PuzzleView.Rows.Add( row );
					}
					if( !Page.IsPostBack )
					{
						for( x = 0; x < xbound; x++ )
							Cross_sectionDropDownList.Items.Add( new ListItem( x.ToString() ));
						Cross_sectionDropDownList.SelectedIndex = cross_section;
					}
					break;
				case 6:
				case 8:
				case 11:
				case 12: /* North West to South East and South East to North
							* West, Edge to Edge and Side to Side directions.
							* For better appearance, Top to Bottom was added here.
							*/
					for( y = ybound - 1; y > -1; y-- )
					{
						row = new HtmlTableRow();
						select = 0; // default cross_section selection
						cross_section = ( cross_section > zbound ) ||
							( cross_section < 0 ) ? select : cross_section;
						for( x = (xbound - 1) / 2, z = cross_section; z < zbound; z++ )
						{
							cell = new HtmlTableCell();
							cell.Controls.Add( new LiteralControl(
								managestats.solution.Puzzle[x, y, z].ToString() ) );
							row.Cells.Add( cell );
						}
						PuzzleView.Rows.Add( row );
					}
					if( !Page.IsPostBack )
					{
						for( z = 0; z < zbound; z++ )
							Cross_sectionDropDownList.Items.Add( new ListItem( z.ToString() ));
						Cross_sectionDropDownList.SelectedIndex = cross_section;
					}
					break;
				default:
					break;
			} // End of switch( direction )
			PuzzleView.RenderControl( writer );
		} // End of protected void Select_DefaultLayer()

		/// <summary>
		/// Initializes the DirectionDropDownList Control
		/// </summary>
		public void Init_DirectionDropDownList()
		{
			DirectionDropDownList.Items.Add( new ListItem( "Please select a puzzle direction to looks at:" ));
			DirectionDropDownList.Items.Add( new ListItem( "Top East Corner to Lower West Corner" ));
			DirectionDropDownList.Items.Add( new ListItem( "Top North Corner to Lower South Corner" ));
			DirectionDropDownList.Items.Add( new ListItem( "Top South Corner to Lower North Corner" ));
			DirectionDropDownList.Items.Add( new ListItem( "Top West Corner to Lower East Corner" ));
			DirectionDropDownList.Items.Add( new ListItem( "North East Side to South West Side" ));
			DirectionDropDownList.Items.Add( new ListItem( "North West Side to South East Side" ));
			DirectionDropDownList.Items.Add( new ListItem( "North East Top Edge to South West Lower Edge" ));
			DirectionDropDownList.Items.Add( new ListItem( "South East Top Edge to North West Lower Edge" ));
			DirectionDropDownList.Items.Add( new ListItem( "North West Top Edge to South East Lower Edge" ));
			DirectionDropDownList.Items.Add( new ListItem( "South East Top Edge to North West Lower Edge" ));
			DirectionDropDownList.Items.Add( new ListItem( "North Vertical Edge to South Vertical Edge" ));
			DirectionDropDownList.Items.Add( new ListItem( "West Vertical Edge to East Vertical Edge" ));
			DirectionDropDownList.Items.Add( new ListItem( "Top Side to Bottom Side" ));
			DirectionDropDownList.SelectedIndex = managestats.puzzleCreator.Direction + 1;
		}
		/// <summary>
		/// The method will initialize the DictionaryListBox on the first load of the
		/// Main.aspx page.		
		/// </summary>
		/// <param name="next">This is the root RedBlack Tree Solution.dictionary node.</param>
		/// <param name="sortChar">Beginning letter of dictionary word to add to list.</param>
		public void InitializeDictionaryListBox( RedBlack next, char sortChar )
		{
			if( !Page.IsPostBack && next == managestats.solution.Dictionary )
			{
				list_counter = 0;
				DictionaryViewControl.Items.Add( new ListItem( "Select All Words" ) );
				for( int x = 'a'; x <= (int)'z'; x++ )
					DictionaryViewControl.Items.Add( new ListItem( ((char)x).ToString() ));
			}
			if( next != Sentinel.Node )
			{
				InitializeDictionaryListBox( next.Left, sortChar );
				if( list_counter >= 2000 )
					return;
				else if( ((char[])next.Key)[0] == sortChar || sortChar == ' ' )
				{
					list_counter = list_counter + 1;
					string str = new string((char[])next.Key);
					DictionaryListBox.Items.Add( new ListItem( str ) );
				}
				InitializeDictionaryListBox( next.Right, sortChar );
			}
		}
		/// <summary>
		/// This method will populate the WordsFound ListBox control.
		/// </summary>
		/// <param name="next">This is the Solution.wordsFound RedBlack Tree root node.</param>
		/// <param name="sortChar">Beginning letter of dictionary word to add to list.</param>
		public void InitializeWordsFoundListBox( RedBlack next, char sortChar )
		{
			if( WordsMatchedViewControl.Items.Count == 0 &&
					next == managestats.solution.WordsFound )
			{
				list_counter = 0;
				WordsMatchedViewControl.Items.Add( new ListItem( "Select All Words" ) );
				for( int x = 'a'; x <= (int)'z'; x++ )
					WordsMatchedViewControl.Items.Add( new ListItem( ((char)x).ToString() ));
			}
			if( next != Sentinel.Node )
			{
				InitializeWordsFoundListBox( next.Left, sortChar );
				if( list_counter >= 2000 )
					return;
				else if( ((char[])next.Key)[0] == sortChar || sortChar == ' ' )
				{
					list_counter = list_counter + 1;
					string str = new string( (char[]) next.Key );
					WordsFound.Items.Add( new ListItem( str ) );
				}
				InitializeWordsFoundListBox( next.Right, sortChar );
			}
		}

		private void DirectionDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			pre_direction = (DirectionDropDownList.SelectedIndex <= 1) ?
				0 : DirectionDropDownList.SelectedIndex - 1;
			pre_cross_section = (Cross_sectionDropDownList.SelectedIndex <= 1) ?
				-1 : Cross_sectionDropDownList.SelectedIndex - 1;
		}

		private void Cross_sectionDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			pre_direction = (DirectionDropDownList.SelectedIndex <= 1) ?
				0 : DirectionDropDownList.SelectedIndex - 1;
			pre_cross_section = (Cross_sectionDropDownList.SelectedIndex <= 1) ?
				-1 : Cross_sectionDropDownList.SelectedIndex - 1;
		}

		private void RedrawPuzzle()
		{
			PuzzleView.Controls.Clear();
			Select_Layer( pre_direction, pre_cross_section );
		}

		private void Get_Puzzle_Click(object sender, System.EventArgs e)
		{
			RedrawPuzzle();
		}

		private void HELP_Click(object sender, System.EventArgs e)
		{
			Response.Redirect( "./Help.aspx", false );
		}

		private void Exit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect( "./Exit.aspx", true );
		}

		private void DictionaryViewControl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			list_counter = 0;
			DictionaryListBox.Items.Clear();
			InitializeDictionaryListBox(
				managestats.solution.Dictionary, ( DictionaryViewControl.SelectedIndex <= 0 ) ?
				' ' : DictionaryViewControl.SelectedValue.ToCharArray()[0] );
		}

		private void WordsMatchedViewControl_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			list_counter = 0;
			WordsFound.Items.Clear();
			InitializeWordsFoundListBox(
				managestats.solution.WordsFound, ( WordsMatchedViewControl.SelectedIndex <= 0 ) ?
				' ' : WordsMatchedViewControl.SelectedValue.ToCharArray()[0] );
		}

		private void Get_Lists_Click(object sender, System.EventArgs e)
		{
			RedrawPuzzle();
		}

		private void WordsFound_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Nothing Implemented, is handled by WordsMatchedViewControl Drop Down List Box.
		}

		private void DictionaryListBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Nothing Implemented, is handled by DictionaryViewControl Drop Down List Box.
		}

		private void StartOver_Click(object sender, System.EventArgs e)
		{
			Response.Redirect( "./Welcome.aspx", true );
		}

		private void CubeImageRotator_AdCreated(object sender, System.Web.UI.WebControls.AdCreatedEventArgs e)
		{
			// Nothing implemented, all attributes are set in the designer.
		}

		private void GetStats_Click(object sender, System.EventArgs e)
		{
			// Call the web service that retrieves the average execution time from the database.
			long[] averageExecStats = manageDB.Call_GetExecutionStatistics();
			
			// Call the AddTimeStats operation to display the remaining statistics.
			managestats.AddTimeStats( ref StatisticsView, ref statistics, averageExecStats );

			// Refresh the display output
			RedrawPuzzle();
			ReDrawStatisticsView();

			GetStats.Enabled = false;
		}

	} // End of public class MainWebForm : System.Web.UI.Page
} // End of namespace thepuzzler_3dstyle
