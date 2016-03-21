///-------------------------------------------------------------------
/// Author:         Matthew Klump CST 407 Final Project
/// Date Created:	   November 10, 2003
/// Last Change Date:  November 23, 2003
/// Namespace:      Puzzle
/// Filename:       BackwardDiagonal.cs
///
/// Overview: This file contains the interface for BackwardDiagonal.
///			  This code is meant to encapsulate the implementation
///			  for BackwardDiagonal.
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
	/// Summary description for BackwardDiagonalWords.
	/// </summary>
	public class BackwardDiagonalWords
	{
		/// <summary>
		/// Gets the backward diagonal words of the puzzle
		/// </summary>
		[Test]
		public static void GetBackwardDiagonalWords()
		{
			StringCollection temp = new StringCollection();
			string str_ = new string(String.Empty.ToCharArray());
			int ix, iy, iz;
			for( ix = 0; ix < HorizontalWords.Buffer.Count; ++ix )
			{
				for( iy = HorizontalWords.Buffer[0].Length - 1, iz = ix;
					iz > -1 &&
					iy > -1;
					--iz, --iy )
					str_ = String.Concat( str_,	HorizontalWords.Buffer[iz][iy].ToString() );

				temp.Add( str_ );
				str_ = String.Empty;
			}
			for( ix = HorizontalWords.Buffer[HorizontalWords.Buffer.Count - 1].Length - 2;
				 ix > -1; --ix )
			{
				for( iy = ix, iz = HorizontalWords.Buffer.Count - 1;
					iz > HorizontalWords.Buffer.Count -
						 HorizontalWords.Buffer[HorizontalWords.Buffer.Count - 1].Length &&
					iy > -1;
					--iy, --iz )
					str_ = String.Concat( str_,	HorizontalWords.Buffer[iz][iy].ToString() );

				temp.Add( str_ );
				str_ = String.Empty;
			}
			HorizontalWords.GetHorizontaltWords( temp );
		}
	}
}


