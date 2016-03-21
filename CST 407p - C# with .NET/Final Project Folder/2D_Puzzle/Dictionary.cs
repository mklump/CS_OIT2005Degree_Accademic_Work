///-------------------------------------------------------------------
/// Author:         Matthew Klump CST 407 Final Project
/// Date Created:	   November 10, 2003
/// Last Change Date:  November 19, 2003
/// Namespace:      Puzzle
/// Filename:       Dictionary.cs
///
/// Overview: This file contains the interface for the Dictionary.
///			  This code is meant to encapsulate the implementation
///			  for the Dictionary.
///
/// Input:	  Input is accepted from a file "english-words.10" for
///			  which defines the entries so used for this dictionary.
/// Output:	  Output is written to the Trace with Console.Out added
///-------------------------------------------------------------------
///</Intro>
#region "Using Statements"
using System;
using System.IO;
using NUnit.Framework;
using System.Collections;
using System.Diagnostics;
using System.Threading;
#endregion // "Using Statements"

namespace Puzzle
{
	/// <summary>
	/// Summary description for a Dictionary.
	/// </summary>
	[TestFixture]
	public class Dictionary
	{
		/// <summary>
		/// Original puzzle reference
		/// </summary>
		private char [,] puzzle;
		/// <summary>
		/// Static puzzle reference used everywhere
		/// </summary>
		private static char [,] staticPuzzleRef;
		/// <summary>
		/// Two dimentional static integer representing
		/// the length and the width of the puzzle.
		/// </summary>
		public static int [] dimentsions;
		/// <summary>
		/// dims[0] = length of each puzzle line,
		/// dims[1] = total number of lines in the puzzle
		/// </summary>
		public int [] dims;

		/// <summary>
		/// Filestream used in WordMatching
		/// </summary>
		private FileStream dictionary;
		/// <summary>
		/// Object reference to the HorizontalWords structure
		/// </summary>
		public HorizontalWords horizon;
		/// <summary>
		/// Object reference to the VerticalWords structure
		/// </summary>
		public VerticalWords vert;
		/// <summary>
		/// Object reference to the ForwardDiagonalWords structure
		/// </summary>
		public ForwardDiagonalWords forward;
		/// <summary>
		/// Object reference to the BackwardDiagonalWords structure
		/// </summary>
		public BackwardDiagonalWords backward;
		/// <summary>
		/// Delegate to the void Horizon.GetHorizontaltStrings() method
		/// </summary>
		public delegate void HorizontaltStringsDelegate();

		/// <summary>
		/// Overview: Default constructor for Dictionary Class.
		/// </summary>
		public Dictionary()
		{
			horizon = new HorizontalWords();
			puzzle = staticPuzzleRef;
		}
		/// <summary>
		/// Overview: Constructor accepts a ref string containing
		/// the dictionary words to check for. It also accepts a
		/// ref string for the text file containing the puzzle to
		/// solve.
		/// </summary>
		/// <param name="filediction"></param>
		/// <param name="filepuzzle"></param>
		public Dictionary( ref string filediction, ref string filepuzzle )
		{
			FileStream ifilePuzzle;
			WordMatching matching = new WordMatching();
			matching.DictionaryRef = this;
			try
			{
				ifilePuzzle = new FileStream(
					filepuzzle,
					FileMode.Open,
					FileAccess.Read
					);
				dictionary = new FileStream(
					filediction,
					FileMode.Open,
					FileAccess.Read
					);
			}
			catch( System.IO.DirectoryNotFoundException exception )
			{
				Trace.WriteLine(String.Format(
								"The sprecified file does " + 
								"not exist in this directory {0}",
								exception.Message));
				throw new FileNotFoundException("File not found.");
			}
			GetPuzzle( ifilePuzzle );
			horizon = new HorizontalWords();
			vert = new VerticalWords();
			forward = new ForwardDiagonalWords();
			backward = new BackwardDiagonalWords();
		}
		/// <summary>
		/// Property Puzzle (ArrayList)
		/// </summary>
		public char [,] Puzzle
		{
			get
			{
				return puzzle;
			}
		}
		/// <summary>
		/// Property Dictionary (FileStream)
		/// </summary>
		public FileStream DictionaryStream
		{
			get
			{
				return this.dictionary;
			}
		}
		/// <summary>
		/// Overview: Get the dimentions of the char [,] buffer
		/// representing the data structure that contains the
		/// puzzle to solve.
		/// </summary>
		/// <param name="puzzleStream"></param>
		/// <returns type="int []"></returns>
		public int [] GetDimentions( ref StreamReader puzzleStream )
		{
			dims = new int[2];
			char [] temp = new char[512];
			while( puzzleStream.Peek() != -1 )
			{
				temp = puzzleStream.ReadLine().ToCharArray();
				if( temp.Length != 0 )
				{
					dims[1]++;
					dims[0] = temp.Length;
				}
			}

			puzzleStream.BaseStream.Seek( 0, SeekOrigin.Begin );
			return dims;
		}
		/// <summary>
		/// Overview: Gets the puzzle file and stores it into 
		/// the char [,] buffer data structure.
		/// </summary>
		/// <param name="ifilePuzzle"></param>
		public void GetPuzzle( FileStream ifilePuzzle )
		{
			StreamReader buffReader = new StreamReader( ifilePuzzle );
			dimentsions = dims = GetDimentions( ref buffReader );
			puzzle = new char[dims[1],dims[0]];
			try
			{
				int ix = 0, iy = 0;
				char [] temp = new char[512];
				//Get the puzzle
				while( (temp = buffReader.ReadLine().ToCharArray()) != null )
				{
					while(  iy < dims[0] )
					{
						puzzle[ix, iy] = temp[iy++];
					}
					ix++;
					iy = 0;
					if( ix == dims[1] )
						break;
				}
			}
			finally 
			{
				staticPuzzleRef = puzzle;
				buffReader.Close();
			}							  
		}
		/// <summary>
		/// Calls a series of exceptions if the number
		/// of application argurements are not correct
		/// </summary>
		private void CallMainException()
		{
			throw new Exception("Take this!",
   		   		  new ArgumentException("And this!",
				  new ApplicationException(
				      "And that for specifying invalid argement(s).\n" +
					  "Usage: puzzle.exe [dictionary.txt] [puzzle.txt]"
					  )));
		}
		/// <summary>
		/// Checks the number of arguements supplied to Main for validity
		/// </summary>
		/// <param name="args"></param>
		public void CheckMainArguements( string [] args )
		{
			for( int ix = 0; ix < 2; ++ix )
				if( args[ix].CompareTo(string.Empty) == 0 )
					CallMainException();
		}
		/// <summary>
		/// Main sub method call
		/// </summary>
		[Test]		
		public static int Main_()
		{
			Thread Main = Thread.CurrentThread;

			ThreadStart Fire1 = new ThreadStart( Firing1 );
			ThreadStart Fire2 = new ThreadStart( Firing2 );
			ThreadStart Fire3 = new ThreadStart( Firing3 );
			ThreadStart Fire4 = new ThreadStart( Firing4 );

			Thread thread1 = new Thread( Fire1 );
			Thread thread2 = new Thread( Fire2 );
			Thread thread3 = new Thread( Fire3 );
			Thread thread4 = new Thread( Fire4 );

			thread1.Start();
			thread2.Start();
			thread3.Start();
			thread4.Start();
			Main.Join();

			return 0;
		}
		/// <summary>
		/// Overview: First thread executed to solve the first puzzle.
		/// </summary>
		public static void Firing1()
		{
			Main( "english-words.10", "puzzle0.txt" );
		}
		/// <summary>
		/// Overview: Second thread executed to solve the second puzzle.
		/// </summary>
		public static void Firing2()
		{
			Main( "english-words.10", "puzzle1.txt" );
		}
		/// <summary>
		/// Overview: Third thread executed to solve the third puzzle.
		/// </summary>
		public static void Firing3()
		{
			Main( "english-words.95", "puzzle4.txt" );
		}
		/// <summary>
		/// Overview: Fourth thread executed to solve the fourth puzzle.
		/// </summary>
		public static void Firing4()
		{
			Main( "english-words.95", "superpuzzle.txt" );
		}
		/// <summary>
		/// Entry point for the application puzzle.exe
		/// </summary>
		/// <param name="args"></param>
		[Test]
		public static int Main(params string[] args)
		{
			Thread Main = Thread.CurrentThread;
			DateTime t1 = new DateTime( DateTime.Now.Ticks );
			Dictionary dictionary = new Dictionary( ref args[0], ref args[1] );
			dictionary.CheckMainArguements( args );
			WordMatching matchedWords = new WordMatching();

//			HorizontaltStringsDelegate myDelegate = new
//				HorizontaltStringsDelegate(
//				dictionary.horizon.GetHorizontaltStrings
//				);
//			Thread thread1 = new Thread( new ThreadStart
//				( 
//				myDelegate
//				));
//			Thread thread2 = new Thread( new ThreadStart
//				( 
//				dictionary.vert.GetVerticalStrings
//				));
//			Thread thread3 = new Thread( new ThreadStart
//				(
//				dictionary.forward.GetForwardDiagonalWords
//				));
//			Thread thread4 = new Thread( new ThreadStart
//				(
//				dictionary.backward.GetBackwardDiagonalWords
//				));
//			Thread thread5 = new Thread( new ThreadStart
//				(
//				matchedWords.GetMatchedWords
//				));
//
//			thread1.Start();
//			thread2.Start();
//			thread3.Start();
//			thread4.Start();
//			Main.Join();
//			thread5.Start();

			dictionary.horizon.GetHorizontaltStrings();
			dictionary.vert.GetVerticalStrings();
			dictionary.forward.GetForwardDiagonalWords();
			dictionary.backward.GetBackwardDiagonalWords();
			matchedWords.GetMatchedWords();

			DateTime t2 = new DateTime( DateTime.Now.Ticks );
            TimeSpan t3 = t2.Subtract( t1 );
			string message = String.Format("Execution Time is: {0} Minutes {1}" + 
								" Seconds {2} Milliseconds", t3.Minutes,
								t3.Seconds, t3.Milliseconds );

			Trace.WriteLine( string.Format("{0}", message) );
			Console.WriteLine( string.Format("{0}", message) );
			return 0;
		}
	}
}