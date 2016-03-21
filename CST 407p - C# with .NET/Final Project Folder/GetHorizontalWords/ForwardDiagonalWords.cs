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
	/// Summary description for NorthWestWords.
	/// </summary>
	[TestFixture]
	public class ForwardDiagonalWords
	{
		/// <summary>
		/// Gets the forward diagonal words of the puzzle
		/// </summary>
		[Test]
		public static void GetForwardDiagonalWords()
		{
			StringCollection temp = new StringCollection(),
						   buffer = HorizontalWords.Buffer;
			string str_ = new string(String.Empty.ToCharArray());
			int ix, iy, iz;
			HorizontalWords.RemoveEmptyStrings( ref buffer );
			for( ix = 0; ix < buffer.Count; ++ix )
			{
				for( iy = 0, iz = ix;
					iz > -1 &&
					iy < buffer[0].Length;
					--iz, ++iy )
					str_ = String.Concat( str_,	buffer[iz][iy].ToString() );

				temp.Add( str_ );
				str_ = String.Empty;
			}
			for( ix = 1; ix < buffer[buffer.Count - 1].Length ; ++ix )
			{
				for( iy = ix, iz = buffer.Count - 1;
					iz > buffer.Count - buffer[buffer.Count - 1].Length &&
					iy < buffer[buffer.Count - 1].Length;
					++iy, --iz )
					str_ = String.Concat( str_,	buffer[iz][iy].ToString() );

				temp.Add( str_ );
				str_ = String.Empty;
			}
			HorizontalWords.GetHorizontaltWords( temp );
		}
	}
}