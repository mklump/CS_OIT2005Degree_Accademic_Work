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
using System.Collections;
using NUnit.Framework;
#endregion

namespace Puzzle
{
	/// <summary>
	/// Summary Description: VerticalWords class object is
	/// responsible for handling all the vertical string
	/// possibilities.
	/// </summary>
	[TestFixture]
	public class VerticalWords
	{
		/// <summary>
		/// Overview: Data structure containing all possible
		/// string combinations for VerticalWords.
		/// </summary>
		public static volatile ArrayList buffer;
		/// <summary>
		/// Reference to the Dictionary class object.
		/// </summary>
		private Dictionary defs;
		/// <summary>
		/// Buffer for processing the vertical strings.
		/// </summary>
		private char [] str_;

		/// <summary>
		/// Property ArrayList Buffer
		/// </summary>
		public ArrayList Buffer
		{
			get
			{
				return buffer;
			}
		}
		/// <summary>
		/// Default constructor for VerticalWords, initializes instances.
		/// </summary>
		public VerticalWords()
		{
			defs = new Dictionary();
			buffer = new ArrayList();
			str_ = new char[Dictionary.dimentsions[1]];
		}
		/// <summary>
		/// Overview: Gets the vertical string possibilities
		/// within the puzzle.
		/// </summary>
		public void GetVerticalStrings()
		{
			unchecked
			{
				int nextChar = -1;
				for( int ix = 0; ix < Dictionary.dimentsions[0]; ++ix )
				{
					for( int iy = 0; iy < Dictionary.dimentsions[1]; ++iy )
						str_[++nextChar] = defs.Puzzle[iy,ix];

					nextChar = -1;
					HorizontalWords.GetSubStrings( str_, buffer );
					str_ = new char[Dictionary.dimentsions[1]];
				}
				buffer = HorizontalWords.TrimBuffers( buffer );
			}
		}
	}
}
