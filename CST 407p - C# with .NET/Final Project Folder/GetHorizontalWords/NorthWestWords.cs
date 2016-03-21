///-------------------------------------------------------------------
/// Author:         Matthew Klump CST 407 Final Project
/// Date Created:	   November 10, 2003
/// Last Change Date:  November 20, 2003
/// Namespace:      Puzzle
/// Filename:       NorthWestWords.cs
///
/// Overview: This file contains the interface for NorthWestWords.
///			  This code is meant to encapsulate the implementation
///			  for NorthWestWords.
///
/// Input:	  Input is accepted from a file for which defines the 
///			  entries so used for the dictionary.
///			  Input is also accepted from a file for the puzzle contents
///			  itself.
/// Output:	  Output is written to the Trace for debugging only.
///-------------------------------------------------------------------
#region "Using Statements"
using System;
using System.Collections.Specialized;
using NUnit.Framework;
using System.IO;
#endregion


namespace PuzzleWordMatching
{
	/// <summary>
	/// Summary description for NorthWestWords.
	/// </summary>
	[TestFixture]
	public class NorthWestWords
	{
		/// <summary>
		/// Gets the northwest diagonal words of the puzzle
		/// </summary>
		[Test]
		public static void GetNorthWestWords()
		{
			HorizontalWords.Buffer.Clear();

			StringCollection temp = new StringCollection();
			string str_ = new string(String.Empty.ToCharArray());
			int ix = 0, iy = 0, temp_ = 0;
			while( ix + iy < HorizontalWords.Buffer.Count + 3 )
			{
				str_ = String.Concat( str_, HorizontalWords.Buffer[iy][ix].ToString() );
				temp.Add( str_ );
				str_ = String.Empty;
				iy++;
				temp_ = ix;
				ix = iy;
				iy = temp_;
			}
			HorizontalWords.Buffer = temp;

			HorizontalWords.GetHorizontaltWords();
		}

		public static void GetPuzzle( string puzzlename )
		{
			StreamReader buffreader = new StreamReader( puzzlename );
			try
			{
				while( buffreader.Peek() > -1 )
					HorizontalWords.Buffer.Add( buffreader.ReadLine() );
			}
			finally
			{
				buffreader.Close();
			}
		}
	}
}
