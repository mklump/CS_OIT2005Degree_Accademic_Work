//
//-------------------------------------------------------------------------------
// Module: Solution Module
// Date:   January 31, 2005
// Purpose: Please see the Unit Test Plan for this completely defined.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//

using System;
using System.IO;
using ns_RedBlack;
using PuzzleConfig;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace Puzzle_Solution
{
	/// <summary>
	/// Summary description for Solution.
	/// </summary>
	public class Solution
	{
		/// <summary>
		/// The puzzle itself (The data structure that perpetually
		/// represents the puzzle in memory as its data structure).
		/// </summary>
		protected static char [,,] puzzle;
		/// <summary>
		/// This RedBlack Tree represents the dictionary that
		/// will contain the list of words to look for.
		/// </summary>
		protected static RedBlack dictionary;
		/// <summary>
		/// This RedBlack Tree represents the complete list
		/// of words in the dictionary that were found in the
		/// puzzle.
		/// </summary>
		protected static RedBlack wordsFound;
		/// <summary>
		/// The total TimeSpan taken to execute the Solution.
		/// </summary>
		private static TimeSpan totalTime;
		/// <summary>
		/// Property TotalTime (TimeSpan) Read Only.
		/// </summary>
		public TimeSpan TotalTime
		{
			get { return totalTime; }
		}
		/// <summary>
		/// Words found conuter.
		/// </summary>
		protected static int numWordsFound;
		/// <summary>
		/// This boundary variable defines one of the
		/// limits of the puzzle.
		/// </summary>
		protected static int xbound, ybound, zbound;
		/// <summary>
		/// Puzzle construction naviagtor variables
		/// </summary>
		protected static int x, y, z;
		/// <summary>
		/// This RedBlack Tree represents all the puzzle
		/// substring possibilities.
		/// </summary>
		protected static RedBlack [] possibilities;
		/// <summary>
		/// Property Possibilities (RedBlack[]) ReadOnly
		/// </summary>
		public RedBlack[] Possibilities
		{
			get { return possibilities; }
		}
		/// <summary>
		/// Solution Threads for the multithreaded solution
		/// </summary>
		private Thread [] solutions;
		/// <summary>
		/// The current running thread for the Solve() operation
		/// </summary>
		private Thread solve;
		/// <summary>
		/// This static integer array is needed for maintaining concurrent
		/// writes to numWordsFound static int reference.
		/// </summary>
		private static int [] numWordsCOPY;
		/// <summary>
		/// This static RedBlack Tree array is needed for maintaining
		/// concurrent writes to the static RedBlack wordsFound final
		/// collection.
		/// </summary>
		private static RedBlack [] wordFindings;
		/// <summary>
		/// Bit flag to run the solution as single or multi-threaded.
		/// </summary>
		private static bool isMultiThreaded;
		/// <summary>
		/// Property Bool IsMultiThreaded (bool)
		/// </summary>
		public static bool IsMultiThreaded
		{
			set { isMultiThreaded = value; }
			get { return isMultiThreaded; }
		}

		private static Solution_CCTELW cctelw;
		private static Solution_CCTNLS cctnls;
		private static Solution_CCTSLN cctsln;
		private static Solution_CCTWLE cctwle;
		private static Solution_NESideSWSide nesideswside;
		private static Solution_NETESWLE neteswle;
		private static Solution_NVESVE nvesve;
		private static Solution_NWSideSESide nwsideseside;
		private static Solution_NWTESELE nwtesele;
		private static Solution_SETENWLE setenwle;
		private static Solution_SWTENELE swtenele;
		private static Solution_TOPBOTTOM topbottom;
		private static Solution_WVEEVE wveeve;

		/// <summary>
		/// Default Solution Constuctor Sets up all of the Solution Class Components
		/// </summary>
		public Solution()
		{
			if( possibilities == null && dictionary == null &&
				puzzle == null && wordsFound == null )
			{
				numWordsFound = 0;
				wordsFound = new RedBlack();

				possibilities = new RedBlack[ 13 ];
				numWordsCOPY = new int[ 13 ];
				wordFindings = new RedBlack[ 13 ];
				for( int x = 0; x < 13; ++x )
				{
					possibilities[x] = new RedBlack();
					wordFindings[x] = new RedBlack();
					numWordsCOPY[x] = 0;
				}
				dictionary = new RedBlack();

				puzzle = new char[
					PuzzleConfiguration.puzzleSizes[0],
					PuzzleConfiguration.puzzleSizes[1],
					PuzzleConfiguration.puzzleSizes[2]
					]; // <-- Set the puzzle's dimentions here!

				xbound = puzzle.GetUpperBound( 0 ) + 1;
				ybound = puzzle.GetUpperBound( 1 ) + 1;
				zbound = puzzle.GetUpperBound( 2 ) + 1;
                
				isMultiThreaded = true;
			}
		} // End of public Solution() default constructor

		/// <summary>
		/// Initialize the appropriate delgates
		/// </summary>
		private void InitializeThreads()
		{
			// Initialize the solution thread objects
			cctelw = new Solution_CCTELW();
			cctnls = new Solution_CCTNLS();
			cctsln = new Solution_CCTSLN();
			cctwle = new Solution_CCTWLE();
			nesideswside = new Solution_NESideSWSide();
			neteswle = new Solution_NETESWLE();
			nvesve = new Solution_NVESVE();
			nwsideseside = new Solution_NWSideSESide();
			nwtesele = new Solution_NWTESELE();
			setenwle = new Solution_SETENWLE();
			swtenele = new Solution_SWTENELE();
			topbottom = new Solution_TOPBOTTOM();
			wveeve = new Solution_WVEEVE();

			// Initialize the list of delegates
			solutions = new Thread[13];
			solutions[0] = new Thread( new ThreadStart( Thread1 ) );
			solutions[0].Name = "Thread1";
			solutions[1] = new Thread( new ThreadStart( Thread2 ) );
			solutions[1].Name = "Thread2";
			solutions[2] = new Thread( new ThreadStart( Thread3 ) );
			solutions[2].Name = "Thread3";
			solutions[3] = new Thread( new ThreadStart( Thread4 ) );
			solutions[3].Name = "Thread4";
			solutions[4] = new Thread( new ThreadStart( Thread5 ) );
			solutions[4].Name = "Thread5";
			solutions[5] = new Thread( new ThreadStart( Thread6 ) );
			solutions[5].Name = "Thread6";
			solutions[6] = new Thread( new ThreadStart( Thread7 ) );
			solutions[6].Name = "Thread7";
			solutions[7] = new Thread( new ThreadStart( Thread8 ) );
			solutions[7].Name = "Thread8";
			solutions[8] = new Thread( new ThreadStart( Thread9 ) );
			solutions[8].Name = "Thread9";
			solutions[9] = new Thread( new ThreadStart( Thread10 ) );
			solutions[9].Name = "Thread10";
			solutions[10] = new Thread( new ThreadStart( Thread11 ) );
			solutions[10].Name = "Thread11";
			solutions[11] = new Thread( new ThreadStart( Thread12 ) );
			solutions[11].Name = "Thread12";
			solutions[12] = new Thread( new ThreadStart( Thread13 ) );
			solutions[12].Name = "Thread13";
			for( int j = 0; j < 13; ++j )
			{
				solutions[j].ApartmentState = ApartmentState.MTA;
				solutions[j].Priority = ThreadPriority.AboveNormal;
				solutions[j].IsBackground = true;
			}
		}
		/// <summary>
		/// Property WordsFound (RedBlack)
		/// Read access for wordsFound.
		/// </summary>
		public RedBlack WordsFound
		{
			get{ return wordsFound; }
		}
		/// <summary>
		/// Property Dictionary (RedBlack)
		/// Read access for dictionary.
		/// </summary>
		public RedBlack Dictionary
		{
			get{ return dictionary; }
		}
		/// <summary>
		/// Property Puzzle (char[,,])
		/// Read access for puzzle.
		/// </summary>
		public char[,,] Puzzle
		{
			get{ return puzzle; }
		}
		/// <summary>
		/// This method will restart The Puzzler - 3D Style web application
		/// This is not implemented in the Solution Class. This is implemented in the
		/// ASP.NET code behind layer.
		/// </summary>
		public void Restart()
		{
		}
		/// <summary>
		/// This operation will select a different crossectional view of the puzzle
		/// This is not implemented in the Solution Class. This is implemented in the
		/// ASP.NET code behind layer.
		/// </summary>
		public void SelectLayer()
		{
		}
		/// <summary>
		/// The use case Exit was activated by the use clicking on the EXIT Button.
		/// This is not implemented in the Solution Class. This is implemented in the
		/// ASP.NET code behind layer.
		/// </summary>
		public void GoToExitPage()
		{
		}
		/// <summary>
		/// This operation will Solve the randomly generated puzzle with a separate solution
		/// algorithm.
		/// </summary>
		/// <returns>The total number of words found in the puzzle that matched the
		/// dictionary.</returns>
		public int Solve()
		{
			/* Begin retrieving the sub string possibilities and place them into the
			 * possibilities RedBlack Binary Search Tree of this Solution class.
			 * Please see the operation InitializeThreads() for how the threads are
			 * setup. (Remember that there is always room for improvement.)
			 * Added Note to self: You must use the fully qualified name
			 * System.Threading.ThreadState to access the ThreadState enumeration.
			 */
			InitializeThreads();

			if( true == isMultiThreaded )
			{
				solve = Thread.CurrentThread;
				solve.IsBackground = false;
				// solve.Priority = ThreadPriority.Normal;

				for( int index = 0; index < 13; ++index )
					solutions[index].Start();

				// Cause execution for the current thread Solve() to pause until all
				// threads have finished.
				DateTime timeBefore = DateTime.Now;
				foreach( Thread trailingThread in solutions )
					while( trailingThread.IsAlive );
				totalTime = DateTime.Now - timeBefore;
			}
			else
			{
				Solution_TestClass singleThreaded = new Solution_TestClass();
				singleThreaded.SetUpSingleThread();

				DateTime timeBefore = DateTime.Now;
				singleThreaded.RunSingleThreadedSolution();
				totalTime = DateTime.Now - timeBefore;
			}
			// Stop retrieving the sub string possibilities.

			// Begin collecting the final results
			for( int j = 0; j < 13; ++j )
				numWordsFound += numWordsCOPY[j];

			GetFoundWords();
			// Stop collecting the final results

			return numWordsFound;
		}
		/// <summary>
		/// This helper method consolidates the wordFindings sub
		/// lists into the single wordsFound list.
		/// </summary>
		private void GetFoundWords()
		{
			for( int x = 0; x < 13; ++ x )
			{
				VisitWordFoundSubList( wordFindings[x] );
			}
		}
		/// <summary>
		/// This helper method visits all of the individual sub lists
		/// for this words found and combines them into on wordsFound list.
		/// </summary>
		/// <param name="nextFoundWord">Specifies the next words found
		/// sub list to sort through all it's individual nodes.</param>
		private void VisitWordFoundSubList( RedBlack nextFoundWord )
		{
			if( nextFoundWord != Sentinel.Node )
			{
				VisitWordFoundSubList( nextFoundWord.Left );

				wordsFound.RB_Insert( ref wordsFound, nextFoundWord.Key );

				VisitWordFoundSubList( nextFoundWord.Right );
			}
		}
		/// <summary>
		/// This helper method will retrieve each dictionary word (those found in the
		/// randomly generated dictonary), in desending order, one at a time, and check
		/// each one of them against every sub list entry in the possibilities RedBlack Binary
		/// Search Tree which represents every word in the puzzle with three or more
		/// characters. Each matched word is then added to a separate RedBlack Tree called
		/// wordsFound.
		/// </summary>
		/// <param name="nextDictionaryWord">The root RedBlack node of the dictionary
		/// tree list.</param>
		/// <param name="direction">This specifies which direction to search all the word
		/// possibilities that matchup with something, if anything, inside the
		/// dictionary.</param>
		private void GetMatchedWords( RedBlack nextDictionaryWord, int direction )
		{
			if( nextDictionaryWord != Sentinel.Node )
			{
				GetMatchedWords( nextDictionaryWord.Left, direction );
				RedBlack foundWord = possibilities[direction].Iterative_Tree_Search(
					possibilities[direction],
					nextDictionaryWord.Key );

				if( foundWord != Sentinel.Node )
				{
					wordFindings[direction].RB_Insert( ref wordFindings[direction], foundWord.Key );
					numWordsCOPY[direction] = numWordsCOPY[direction] + 1;
				}
				GetMatchedWords( nextDictionaryWord.Right, direction );
			}
		}
		/// <summary>
		/// This helper method will retrieve all of the substring possibilities at
		/// a specified starting point and an increment or decrement in the specified direction
		/// of the horizontal, vertical, or diagonal 26 possible directions in the puzzle.
		/// </summary>
		/// <param name="puzzle">Used to get a local copy of the puzzle for thread multiple
		/// read access.</param>
		/// <param name="initX">Specifies the starting point for X as 0 or the X boudary value.</param>
		/// <param name="initY">Specifies the starting point for Y as 0 or the Y boudary value.</param>
		/// <param name="initZ">Specifies the starting point for Z as 0 or the Z boudary value.</param>
		/// <param name="endX">Specifies the ending point for X as -1 for "greater than" -1 or
		/// the X boundary value for "less than" the X boundary value.</param>
		/// <param name="endY">Specifies the ending point for Y as -1 for "greater than" -1 or
		/// the Y boundary value for "less than" the Y boundary value.</param>
		/// <param name="endZ">Specifies the ending point for Z as -1 for "greater than" -1 or
		/// the Z boundary value for "less than" the Z boundary value.</param>
		/// <param name="incX">Specifies how X increments or decrements as 1, 0, or -1 added to X.</param>
		/// <param name="incY">Specifies how Y increments or decrements as 1, 0, or -1 added to Y.</param>
		/// <param name="incZ">Specifies how Z increments or decrements as 1, 0, or -1 added to Z.</param>
		/// <param name="direction">Spedifies what direction is being solved.</param>
		protected void GetPuzzleSubStrings( char[,,] puzzle, int initX, int initY, int initZ,
			int endX, int endY, int endZ, int incX, int incY, int incZ, int direction )
		{
			string puzzlestring = ""; // buffer for complete puzzle string line processing
			int xGS = initX,
				yGS = initY,
				zGS = initZ;
			while( true )
			{
				// begin checking stop condtions
				if( endX == -1 && xGS <= endX )
					break;
				else if( endX == xbound && xGS >= endX )
					break;
				else if( endY == -1 && yGS <= endY )
					break;
				else if( endY == ybound && yGS >= endY )
					break;
				else if( endZ == -1 && zGS <= endZ )
					break;
				else if( endZ == zbound && zGS >= endZ )
					break;
				// end checking stop conditions
				
				// get next character in increment/decrement direction
				// (build up string line into buffer)
				puzzlestring = puzzlestring + puzzle[ xGS, yGS, zGS ];
				xGS = xGS + incX;
				yGS = yGS + incY;
				zGS = zGS + incZ;
			}
			// begin get substring possibilities
			int nextChar = -1;
			for(int pos = 0; pos < puzzlestring.Length; ++pos)
				for(int len = 3; pos + len <= puzzlestring.Length; ++len)
				{
					char [] nextSubString = new char[len];
					for( int ix = pos; ix < pos + len; ++ix )
						nextSubString[ ++nextChar ] = puzzlestring[ ix ];

					nextChar = -1;
					for( int reverse = 0; reverse < 2; ++reverse )
					{
						if( reverse == 0 )
							possibilities[direction].RB_Insert(
								ref possibilities[direction], nextSubString );
						else
							possibilities[direction].RB_Insert(
								ref possibilities[direction], Reverse(nextSubString) );
					}
				}
			// end get substring possibilities
		}
		/// <summary>
		/// This helper method will reverse a C# char[].
		/// </summary>
		/// <param name="str">This parameter is the char[] string to reverse.</param>
		/// <returns>The reversed char[] str string.</returns>
		private char[] Reverse( char [] str )
		{
			char [] temp = new char[str.Length];
			int iy = -1;
			for( int ix = str.Length - 1; ix > -1; --ix )
				temp[++iy] = str[ix];

			return temp;
		}
		/// <summary>
		/// This operation will output the puzzle in Row-Major order, in a vertical crossection
		/// by crossection manner.
		/// </summary>
		public void OutputPuzzle()
		{
			Trace.Write( "\n\n" );
			for( int z = 0; z < puzzle.GetUpperBound( 2 ) + 1; z++ )
			{
				Trace.WriteLine( string.Format("Vertical crossection " + 
					"(along the Z axis) with Z = {0}", z ) );
				for( int y = puzzle.GetUpperBound( 1 ); y > -1; y-- )
				{
					for(int x = 0; x < puzzle.GetUpperBound( 0 ) + 1; x++ )
					{
						Trace.Write( puzzle[x,y,z].ToString() );
						if( y == 0 && x == puzzle.GetUpperBound( 0 ) )
						{
							Trace.Write( "\n\n" );
							break;
						}
						else if( x == puzzle.GetUpperBound( 0 ) )
							Trace.Write( '\n' );
					}
				}
			}
		} // End of public void OutputPuzzle()
		/// <summary>
		/// Thread that starts solving direction 1
		/// </summary>
		public void Thread1()
		{
			cctelw.GetPossibilities_CCTELW( puzzle );
			// Start matching words in the dictionary with words in the puzzle for this direction.
			cctelw.GetMatchedWords( dictionary, 0 );
			// Stop matching words in the dictionary with words in the puzzle for this direction.
		}
		/// <summary>
		/// Thread that starts solving direction 2
		/// </summary>
		public void Thread2()
		{
			cctwle.GetPossibilities_CCTWLE( puzzle );
			cctwle.GetMatchedWords( dictionary, 1 );
		}
		/// <summary>
		/// Thread that starts solving direction 3
		/// </summary>
		public void Thread3()
		{
			cctnls.GetPossibilities_CCTNLS( puzzle );
			cctnls.GetMatchedWords( dictionary, 2 );
		}
		/// <summary>
		/// Thread that starts solving direction 4
		/// </summary>
		public void Thread4()
		{
			cctsln.GetPossibilities_CCTSLN( puzzle );
			cctsln.GetMatchedWords( dictionary, 3 );
		}
		/// <summary>
		/// Thread that starts solving direction 5
		/// </summary>
		public void Thread5()
		{
			nesideswside.GetPossibilities_NESideSWSide( puzzle );
			nesideswside.GetMatchedWords( dictionary, 4 );
		}
		/// <summary>
		/// Thread that starts solving direction 6
		/// </summary>
		public void Thread6()
		{
			nwsideseside.GetPossibilities_NWSideSESide( puzzle );
			nwsideseside.GetMatchedWords( dictionary, 5 );
		}
		/// <summary>
		/// Thread that starts solving direction 7
		/// </summary>
		public void Thread7()
		{
			neteswle.GetPossibilities_NETESWLE( puzzle );
			neteswle.GetMatchedWords( dictionary, 6 );
		}
		/// <summary>
		/// Thread that starts solving direction 8
		/// </summary>
		public void Thread8()
		{
			swtenele.GetPossibilities_SWTENELE( puzzle );
			swtenele.GetMatchedWords( dictionary, 7 );
		}
		/// <summary>
		/// Thread that starts solving direction 9
		/// </summary>
		public void Thread9()
		{
			nvesve.GetPossibilities_NVESVE( puzzle );
			nvesve.GetMatchedWords( dictionary, 8 );
		}
		/// <summary>
		/// Thread that starts solving direction 10
		/// </summary>
		public void Thread10()
		{
			wveeve.GetPossibilities_WVEEVE( puzzle );
			wveeve.GetMatchedWords( dictionary, 9 );
		}
		/// <summary>
		/// Thread that starts solving direction 11
		/// </summary>
		public void Thread11()
		{
			setenwle.GetPossibilities_SETENWLE( puzzle );
			setenwle.GetMatchedWords( dictionary, 10 );
		}
		/// <summary>
		/// Thread that starts solving direction 12
		/// </summary>
		public void Thread12()
		{
			nwtesele.GetPossibilities_NWTESELE( puzzle );
			nwtesele.GetMatchedWords( dictionary, 11 );
		}
		/// <summary>
		/// Thread that starts solving direction 13
		/// </summary>
		public void Thread13()
		{
			topbottom.GetPossibilities_TOPBOTTOM( puzzle );
			topbottom.GetMatchedWords( dictionary, 12 );
		}
	} // End of public class Solution
	/// <summary>
	/// Test class for the Solution implementation base class
	/// </summary>
	[TestFixture]
	public class Solution_TestClass
	{
		private Solution solution;

		/// <summary>
		/// SetUp method for Solution_TestClass
		/// </summary>
		[SetUp]
		public void SetUpSingleThread()
		{
			solution = new Solution();
		}
		/// <summary>
		/// This helper method is being used to call all of the
		/// solution sub task without threading to trouble shoot
		/// an index out of range exception problem.
		/// </summary>
		[Test]
		public void RunSingleThreadedSolution()
		{
			solution.Thread1();
			solution.Thread2();
			solution.Thread3();
			solution.Thread4();
			solution.Thread5();
			solution.Thread6();
			solution.Thread7();
			solution.Thread8();
			solution.Thread9();
			solution.Thread10();
			solution.Thread11();
			solution.Thread12();
			solution.Thread13();
		}
		/// <summary>
		/// Test1 counts the size of the dictionary and the wordsFound
		/// RedBlack Binary Search Trees and compares their totals, if
		/// the size of the wordsFound list is larger than the dictionary,
		/// then the test fails.
		/// </summary>
		[Test]
		public void Test1()
		{
			int count1 = 0, count2 = 0;
			solution.Dictionary.GetActualSize( solution.Dictionary, ref count1 );
			solution.WordsFound.GetActualSize( solution.WordsFound, ref count2 );
			Assert.IsTrue( count1 >= count2 );
		}
		/// <summary>
		/// Test2 prints the contents of the dictionary and the wordsFound to
		/// the Trace.Writeline() operation so that the contents of each list
		/// maybe visually inspected. This may also be printed to a file by un-
		/// commenting the TraceListener.
		/// </summary>
		[Test]
		public void Test2()
		{
//			StreamWriter output = new StreamWriter( "./output.txt", false );
//			TextWriterTraceListener writer = new TextWriterTraceListener( output ); 
//			Trace.Listeners.Add( writer );
			solution.Dictionary.Inorder_Tree_Walk( solution.Dictionary );
			solution.WordsFound.Inorder_Tree_Walk( solution.WordsFound );
		}
		/// <summary>
		/// Solution_TestClass entry point
		/// </summary>
		/// <param name="args"></param>
		public void Main( string [] args )
		{
			this.SetUpSingleThread();
			this.Test1();
			this.Test2();
			this.RunSingleThreadedSolution();
		}
	}
}
