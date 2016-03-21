//
//-------------------------------------------------------------------------------
// Module: ManageStats Module
// Date:   March 4, 2005
// Purpose: Please see the Unit Test Plan for this completely defined.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//
using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Puzzle_Solution;
using ns_DictionaryCreator;
using Puzzle_Creation;
using ns_RedBlack;

namespace ns_ManageStats
{
	/// <summary>
	/// Summary description for ManageStats.
	/// </summary>
	public class ManageStats
	{
		/// <summary>
		/// This System.TimeSpan represents the Dictionary Creation execution time.
		/// </summary>
		private static TimeSpan dictionaryTime;
		/// <summary>
		/// Property DictionaryTime (TimeSpan) Read Only
		/// </summary>
		public TimeSpan DictionaryTime
		{
			get { return dictionaryTime; }
		}
		/// <summary>
		/// This System.TimeSpan represents the Puzzle Creation execution time.
		/// </summary>
		private static TimeSpan puzzleTime;
		/// <summary>
		/// Property PuzzleTime (TimeSpan) Read Only
		/// </summary>
		public TimeSpan PuzzleTime
		{
			get { return puzzleTime; }
		}
		/// <summary>
		/// This System.TimeSpan represents the Puzzle Solution execution time.
		/// </summary>
		private static TimeSpan solutionTime;
		/// <summary>
		/// Property SolutionTime (TimeSpan) Read Only
		/// </summary>
		public TimeSpan SolutionTime
		{
			get { return solutionTime; }
		}

		// C# logic added code behind library files
		/// <summary>
		/// Object responsible for providing the puzzle solution.
		/// </summary>
		public Solution solution;
		/// <summary>
		/// Object responsible for providing the puzzle creation.
		/// </summary>
		public PuzzleCreator puzzleCreator;
		/// <summary>
		/// Object responsible for providing the dictionary creation.
		/// </summary>
		public DictionaryCreator dictionaryCreator;
		/// <summary>
		/// Timer used to get the time of the System clock before an algorithm execution.
		/// </summary>
		private DateTime timer1;
		/// <summary>
		/// Timer used to get the time of the System clock after an algorithm execution.
		/// </summary>
		private TimeSpan timer2;
		/// <summary>
		/// Total number of substring possibilities identified by the solution algorithm.
		/// </summary>
		private static long totalPossibilities;

		/// <summary>
		/// Default constructor for ManageStats.
		/// </summary>
		public ManageStats()
		{
			totalPossibilities = 0;
			solution = new Solution();
			dictionaryCreator = new DictionaryCreator();
			puzzleCreator = new PuzzleCreator();
		}
		/// <summary>
		/// This operation will execute the CreateDictionary() operation and
		/// return the time taken to make it as a System.String
		/// </summary>
		/// <param name="table">The HtmlTable to which will be printed the results.</param>
		/// <param name="dictionNum">Specifies which dictionary to pass to DictionaryCreator().</param>
		/// <param name="listSize">Specifies how large the dictionary should be when passed
		/// to DictionaryCreator() as its second arguement.</param>
		/// <param name="stats">The string array collection keeping track of the
		/// resultant statistics</param>
		/// <param name="minimum">Specifies the minimum size of a word to use.</param>
		public void GetDictionaryTime( ref HtmlTable table, int dictionNum,
			int listSize, int minimum, ArrayList stats )
		{
			timer1 = DateTime.Now;
			dictionaryCreator.CreateDictionary( dictionNum, listSize, minimum );
			timer2 = DateTime.Now - timer1;
			
			HtmlTableRow row = new HtmlTableRow();
			HtmlTableCell cell = new HtmlTableCell();
			cell.Controls.Add(new LiteralControl(
				(string)stats[stats.Add( string.Format(
					"Dictionary Creator took: {0} min. {1} sec. {2} ms.",
				timer2.Minutes, timer2.Seconds, timer2.Milliseconds ) )]
				) );
			row.Controls.Add( cell );
			table.Controls.Add( row );
			dictionaryTime = timer2;
		}
		/// <summary>
		/// This operation will execute the GeneratePuzzle() operaton and
		/// return the time taken to make it as a System.String
		/// </summary>
		/// <param name="table">The HtmlTable to which will be printed the results.</param>
		/// <param name="stats">The string array collection keeping track of the
		/// resultant statistics</param>
		public void GetPuzzleTime( ref HtmlTable table, ref ArrayList stats )
		{
			timer1 = DateTime.Now;
			puzzleCreator.GeneratePuzzle();
			timer2 = DateTime.Now - timer1;
			HtmlTableRow row = new HtmlTableRow(); HtmlTableCell cell = new HtmlTableCell();
			cell.Controls.Add(new LiteralControl(
				(string)stats[stats.Add( string.Format(
				"Puzzle Creator took: {0} min. {1} sec. {2} ms.",
				timer2.Minutes, timer2.Seconds, timer2.Milliseconds ) )]
				) );
			row.Controls.Add( cell );
			table.Controls.Add( row );
			puzzleTime = timer2;
		}
		/// <summary>
		/// This operation will execute the Solve() operation and return
		/// the time taken to solve the puzzle as a System.String
		/// </summary>
		/// <param name="table">The HtmlTable to which will be printed the results.</param>
		/// <param name="stats">The ArrayList keeping track of the
		/// resultant statistics</param>
		/// <returns>The total number of words found in the puzzle that matched the
		/// dictionary.</returns>
		public int GetSolutionTime( ref HtmlTable table, ref ArrayList stats )
		{
			int numWordsFound = solution.Solve();
			timer2 = solution.TotalTime;
			HtmlTableRow row = new HtmlTableRow();
			HtmlTableCell cell = new HtmlTableCell();
			cell.Controls.Add(new LiteralControl(
				(string)stats[stats.Add( string.Format(
				"Puzzle Solver took: {0} min. {1} sec. {2} ms.",
				timer2.Minutes, timer2.Seconds, timer2.Milliseconds ) )]
				) );
			row.Controls.Add( cell );
			table.Controls.Add( row );
			solutionTime = timer2;
			return numWordsFound;
		}
		/// <summary>
		/// This operation will add the average time statistics to the StatisticsView
		/// Html Table control as well as other necessary timing and possibilities
		/// statistics.
		/// </summary>
		/// <param name="table">The HtmlTable to which will be printed the results.</param>
		/// <param name="stats">The ArrayList keeping track of the
		/// resultant statistics</param>
		/// <param name="averageExecTimes">The average execution/creation times passed
		/// by reference to guarantee their values won't be changed.</param>
		public void AddTimeStats( ref HtmlTable table, ref ArrayList stats, long[] averageExecTimes )
		{
			TimeSpan expected = CalculateExpectedSolutionTime();

			for( int index = 0; index < averageExecTimes.Length + 3; ++index )
			{
				TimeSpan execTime = TimeSpan.MinValue;
				if( index < averageExecTimes.Length )
					execTime = new TimeSpan( averageExecTimes[index] );

				string statMessage = "";
				switch( index )
				{
					case 0:
						statMessage = string.Format("Avg. Dictionary Creation Time: {0} min. " +
							"{1} sec. {2} ms.", execTime.Minutes, execTime.Seconds, execTime.Milliseconds );
						break;
					case 1:
						statMessage = string.Format("Avg. Puzzle Creation Time: {0} min. {1} " +
							"sec. {2} ms.", execTime.Minutes, execTime.Seconds, execTime.Milliseconds );
						break;
					case 2:
						statMessage = string.Format("Ave. Solution Execution Time: {0} min. {1}" +
							" sec. {2} ms.", execTime.Minutes, execTime.Seconds, execTime.Milliseconds );
						break;
					case 3:
						statMessage = string.Format("Solution Algorithm Found {0} " +
							"Possibilites.", totalPossibilities);
						break;
					case 4:
						statMessage = string.Format("Log(n) Expected Time is: {0} min. {1} sec. {2} ms.",
							expected.Minutes, expected.Seconds, expected.Milliseconds );
						break;
					case 5:
						float percentage =
							((solution.TotalTime.Ticks - expected.Ticks) / expected.Ticks) * 100;
						statMessage = string.Format("Percentage Differnece is: {0:f2}%", percentage);
						break;
					default:
						break;
				}
				HtmlTableRow row = new HtmlTableRow();
				HtmlTableCell cell = new HtmlTableCell();

				cell.Controls.Add(new LiteralControl( (string)stats[stats.Add( statMessage )] ) );

				row.Controls.Add( cell );
				table.Controls.Add( row );
			}
		}
		/// <summary>
		/// This helper operation method will calculate the expected time for the
		/// current Solution Execution Time.
		/// The Log(n) calulation is expressed in seconds after having been done.
		/// </summary>
		/// <returns>The expected execution time for the current running solution.</returns>
		private TimeSpan CalculateExpectedSolutionTime()
		{
			foreach( RedBlack subList in solution.Possibilities )
			{
				int intTemp = 0;
				subList.GetActualSize( subList, ref intTemp );
				totalPossibilities += intTemp;
			}
			// The Log(n) calulation is expressed in seconds after having been done.
			TimeSpan returnValue = new TimeSpan( 0, 0,
				Convert.ToInt32( 10 * Math.Log10( Convert.ToDouble(totalPossibilities) ) )
				);
			return returnValue;
		}
	}
}
