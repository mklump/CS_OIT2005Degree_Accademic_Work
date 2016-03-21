//
//-------------------------------------------------------------------------------
// Module: Puzzle Creator Module
// Date:   January 31, 2005
// Purpose: Please see the Unit Test Plan for this completely defined.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//

using System;
using System.Diagnostics;
using NUnit.Framework;
using ns_RedBlack;
using ns_DictionaryCreator;
using Puzzle_Solution;

namespace Puzzle_Creation
{
	/// <summary>
	/// This class is responsible for random creating an appropriate 3D puzzle.
	/// </summary>
	public class PuzzleCreator : Solution
	{
		/// <summary>
		/// This is an index variable that will navigate the the puzzle char[,,] structure.
		/// </summary>
		private static int direction;
		/// <summary>
		/// This boundary variable will define the limits of the puzzle.
		/// </summary>
		protected static int xBoundary, yBoundary, zBoundary;
		/// <summary>
		/// DictionaryCreator reference needed for the puzzle's constructon.
		/// </summary>
		protected DictionaryCreator dictionaryCreator;
		/// <summary>
		/// Random number generator of the puzzle construction.
		/// </summary>
		protected Random random;

		private CCTS_LN ccts_ln;
		private CCTN_LS cctn_ls;
		private CCTE_LW ccte_lw;
		private CCTW_LE cctw_le;
		private SWTE_NELE swte_nele;
		private SETE_NWLE sete_nwle;
		private NETE_SWLE nete_swle;
		private NWTE_SELE nwte_sele;
		private WVE_EVE wve_eve;
		private NVE_SVE nve_sve;
		private Top_Bottom top_bottom;
		private NWSide_SESide nwside_seside;
		private NESide_SWSide neside_swside;

		/// <summary>
		/// Property Direction (int) read access to directional argorithm indicator.
		/// </summary>
		public int Direction
		{
			get{ return direction; }
		}
		/// <summary>
		/// Public helper method for getting the puzzle boundaries.
		/// </summary>
		/// <returns>The boundaries in the form of an int[] of three elements
		/// each containing the respective boundaries.</returns>
		public int[] GetBoundaries()
		{
			return new int[] { xBoundary, yBoundary, zBoundary };
		}
		/// <summary>
		/// Default Constructor for the PuzzleCreator class.
		/// </summary>
		public PuzzleCreator()
		{
			dictionaryCreator = new DictionaryCreator();
			random = new Random();
			GetLengthDimentions();
			// Fill the puzzle initially with the "empty puzzle character" space.
			if( puzzle[0,0,0] == 0 &&
				puzzle[xBoundary - 1,yBoundary - 1,zBoundary - 1] == 0 )
			{
				for( z = 0; z < zBoundary; z++ )
					for( y = 0; y < yBoundary; y++ )
						for( x = 0; x < xBoundary; x++ )
							puzzle[x,y,z] = ' ';
			}
		}
		/// <summary>
		/// Polymorphically overrideable method for respective parsing.
		/// </summary>
		/// <param name="head">This RedBlack Tree node is the head node of the
		/// tree representing the dictionary.</param>
		protected virtual void Parse( RedBlack head )
		{
			// Randomly select one of all of the derived call Parse() methods
			// and call is here.
			direction = new Random().Next( 1, 13 );
			try
			{
				switch( direction )
				{
					case 1:
						ccts_ln = new CCTS_LN();
						ccts_ln.Parse( head );
						break;
					case 2:
						cctn_ls = new CCTN_LS();
						cctn_ls.Parse( head );
						break;
					case 3:
						ccte_lw = new CCTE_LW();
						ccte_lw.Parse( head );
						break;
					case 4:
						cctw_le = new CCTW_LE();
						cctw_le.Parse( head );
						break;
					case 5:
						swte_nele = new SWTE_NELE();
						swte_nele.Parse( head );
						break;
					case 6:
						sete_nwle = new SETE_NWLE();
						sete_nwle.Parse( head );
						break;
					case 7:
						nete_swle = new NETE_SWLE();
						nete_swle.Parse( head );
						break;
					case 8:
						nwte_sele = new NWTE_SELE();
						nwte_sele.Parse( head );
						break;
					case 9:
						wve_eve = new WVE_EVE();
						wve_eve.Parse( head );
						break;
					case 10:
						nve_sve = new NVE_SVE();
						nve_sve.Parse( head );
						break;
					case 11:
						top_bottom = new Top_Bottom();
						top_bottom.Parse( head );
						break;
					case 12:
						nwside_seside = new NWSide_SESide();
						nwside_seside.Parse( head );
						break;
					case 13:
						neside_swside = new NESide_SWSide();
						neside_swside.Parse( head );
						break;
					default:
						break;
				}
				FillRemainingCubes();
			}
			catch( System.IndexOutOfRangeException e )
			{
				Trace.WriteLine( "There was an error caused by an Indexer going" +
					"\nout of the puzzle's set boundaries, the details are:" +
					"\n\n" + e.ToString() );
			}
		}
		/// <summary>
		/// This method is responsible for cheching the remaining empty cubes in
		/// the puzzle, and then fill them with a random character from a to z
		/// lowercase.
		/// </summary>
		private void FillRemainingCubes()
		{
			for( x = 0; x < xBoundary; x++ )
				for( y = 0; y < yBoundary; y++ )
					for( z = 0; z < zBoundary; z++ )
						if( puzzle[x,y,z] == ' ' )
							puzzle[x,y,z] = (char)
								new Random(z * y + x + 999).Next( (int)'a', (int)'z' + 1 );
		}
		/// <summary>
		/// This method calls all of the overriden Parse() methods and merges all of the
		/// resultant puzzle directions into one puzzle.
		/// </summary>
		/// <returns>The method will return the Randomly Generated Puzzle.</returns>
		public char[,,] GeneratePuzzle()
		{
			// Start generating the puzzle from the randomly created dictionary
			Parse( dictionary );
			// Stop generating the puzzle from the randomly created dictionary
			// Now return the fully assembled puzzle
			return puzzle;
		}
		/// <summary>
		/// This helper method will will get the length of each x, y, and z side
		/// of the char[,,] puzzle
		/// </summary>
		public void GetLengthDimentions()
		{
			xBoundary = puzzle.GetUpperBound( 0 ) + 1;
			yBoundary = puzzle.GetUpperBound( 1 ) + 1;
			zBoundary = puzzle.GetUpperBound( 2 ) + 1;
		}
		/// <summary>
		/// This method will reverse a C# char[].
		/// </summary>
		/// <param name="str">This parameter is the char[] string to reverse.</param>
		/// <returns>The reversed char[] str string.</returns>
		public char[] Reverse( char [] str )
		{
			char [] temp = new char[str.Length];
			int iy = -1;
			for( int ix = str.Length - 1; ix > -1; --ix )
				temp[++iy] = str[ix];

			return temp;
		}
	}
	/// <summary>
	/// Means for Testing the PuzzleCreator
	/// </summary>
	[TestFixture]
	public class PuzzleCreator_TestClass
	{
		private PuzzleCreator puzzleCreator;
		private Solution solution;

		/// <summary>
		/// Test Class default constructor
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			puzzleCreator = new PuzzleCreator();
			solution = new Solution();
		}
		/// <summary>
		/// The method will test the GetLengthDimentions() method for accuratly counting the
		/// side lengths / maximum dimentions of the puzzle.
		/// </summary>
		[Test]
		public void TestGetLengthDimentions()
		{
			Assert.IsTrue(
				puzzleCreator.GetBoundaries()[0] == puzzleCreator.Puzzle.GetUpperBound(0) &&
				puzzleCreator.GetBoundaries()[1] == puzzleCreator.Puzzle.GetUpperBound(1) &&
				puzzleCreator.GetBoundaries()[2] == puzzleCreator.Puzzle.GetUpperBound(2)
				);
		}
		/// <summary>
		/// Test method to Gererate the entire puzzle.
		/// </summary>
		[Test]
		public void TestGeneratePuzzle()
		{
			puzzleCreator.GeneratePuzzle();
			if( puzzleCreator.Puzzle.GetUpperBound(0) > 5 &&
				puzzleCreator.Puzzle.GetUpperBound(1) > 5 &&
				puzzleCreator.Puzzle.GetUpperBound(2) > 5 )
			Assert.IsTrue(
				puzzleCreator.Puzzle[0,0,0] != ' ' &&
				puzzleCreator.Puzzle[0,1,1] != ' ' &&
				puzzleCreator.Puzzle[0,5,0] != ' ' &&
				puzzleCreator.Puzzle[1,4,1] != ' ' &&
				puzzleCreator.Puzzle[0,0,5] != ' ' &&
				puzzleCreator.Puzzle[1,1,4] != ' ' &&
				puzzleCreator.Puzzle[0,5,5] != ' ' &&
				puzzleCreator.Puzzle[1,4,4] != ' ' &&
				puzzleCreator.Puzzle[5,5,5] != ' ' &&
				puzzleCreator.Puzzle[4,4,4] != ' ' &&
				puzzleCreator.Puzzle[5,0,5] != ' ' &&
				puzzleCreator.Puzzle[4,1,4] != ' ' &&
				puzzleCreator.Puzzle[5,0,0] != ' ' &&
				puzzleCreator.Puzzle[4,1,1] != ' ' &&
				puzzleCreator.Puzzle[5,5,0] != ' ' &&
				puzzleCreator.Puzzle[4,4,1] != ' '
				);
			solution.OutputPuzzle();
		}
		/// <summary>
		/// Entry point for PuzzleCreator_TestClass
		/// </summary>
		/// <param name="args">Arguements specified with PuzzlerCreator when
		/// the puzzle is built as a Console App for testing.</param>
		public void Main( string[] args )
		{
			TextWriterTraceListener writer = new TextWriterTraceListener( Console.Out ); 
			Trace.Listeners.Add( writer );
			this.SetUp();
			this.TestGetLengthDimentions();
			DictionaryCreator_TestClass.Main( new string[] {} );

			DateTime t1, t2;
			t1 = new DateTime( DateTime.Now.Ticks );
			this.TestGeneratePuzzle();
			t2 = new DateTime( DateTime.Now.Ticks );

			TimeSpan timespan = t2.Subtract( t1 );
			Trace.WriteLine(
				string.Format( "Time taken to Create the Puzzle: {0} min. {1} sec. {2} ms." +
				"\n\nThe Puzzle Dimentions for the last puzzle created were {3} x {4} x {5}",
				timespan.Minutes, timespan.Seconds, timespan.Milliseconds,
				puzzleCreator.GetBoundaries()[0], puzzleCreator.GetBoundaries()[1],
				puzzleCreator.GetBoundaries()[2] )
				);
		}
	}
}
