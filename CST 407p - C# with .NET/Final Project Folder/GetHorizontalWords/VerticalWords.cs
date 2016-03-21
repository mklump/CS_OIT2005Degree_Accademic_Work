///-------------------------------------------------------------------
/// Author:         Matthew Klump CST 407 Final Project
/// Date Created:	   November 10, 2003
/// Last Change Date:  November 20, 2003
/// Namespace:      Puzzle
/// Filename:       VerticalWords.cs
///
/// Overview: This file contains the interface for VerticalWords.
///			  This code is meant to encapsulate the implementation
///			  for VerticalWords.
///
/// Input:	  Input is accepted from a file for which defines the 
///			  entries so used for the dictionary.
///			  Input is also accepted from a file for the puzzle contents
///			  itself.
/// Output:	  Output is written to the Trace with Console.Out added
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
	/// Summary description for VerticalWords.
	/// </summary>
	[TestFixture]
	public class VerticalWords
	{
		/// <summary>
		/// Gets the vertical words within the puzzle if there
		/// exists any.
		/// </summary>
		[Test]
		public static void GetVerticalWords()
		{
			StringCollection temp = new StringCollection();
			string str_ = new string(String.Empty.ToCharArray());
			for( int ix = 0; ix < HorizontalWords.Buffer[0].Length; ++ix )
			{
				for( int iy = 0; iy < HorizontalWords.Buffer.Count; ++iy )
					str_ = String.Concat( str_, HorizontalWords.Buffer[iy][ix].ToString() );

				temp.Add( str_ );
				str_ = String.Empty;
			}
			HorizontalWords.GetHorizontaltWords( temp );
		}
	}
}
