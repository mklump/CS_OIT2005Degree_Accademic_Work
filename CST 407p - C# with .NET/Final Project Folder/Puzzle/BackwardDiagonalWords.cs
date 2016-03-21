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
using System.Collections;
using NUnit.Framework;
using System.IO;
#endregion

namespace Puzzle
{
	/// <summary>
	/// Summary Description: BackwardDiagonalWords class object
	/// is responsible for extracting all backward diagonal
	/// string possibilities.
	/// </summary>
	[TestFixture]
	public class BackwardDiagonalWords
	{
		/// <summary>
		/// Overview: Data structure containing all possible
		/// string combinations for BackwardDiagonalWords.
		/// </summary>
		public static volatile ArrayList buffer;
		/// <summary>
		/// Object reference to the Dictionary class.
		/// </summary>
		private Dictionary defs;
		/// <summary>
		/// Buffer in which each backwards diagonal string will be processed.
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
		/// Default Constructor for BackwardDiagonalWords, initializes instances.
		/// </summary>
		public BackwardDiagonalWords()
		{
			defs = new Dictionary();
			buffer = new ArrayList();
		}
		/// <summary>
		/// Gets the backward diagonal words of the puzzle
		/// </summary>
		public void GetBackwardDiagonalWords()
		{
			int ix,		// loop counter
				iy = 0, // row selector
				iz = 0, // column selector
				nextDiag = 0, // next diagonal string length in puzzle
				nextChar = 0, // next char to extract based on line orientation
				counting_Chars = 1; // counting chars state indicator

			unchecked
			{
				for( ix = Dictionary.dimentsions[0] - 1; 
					iy < Dictionary.dimentsions[1];
					--ix,
					iy = (ix < 0) ? iy + 1 : 0 )
				{
					nextChar = -1;
					nextDiag = 0;
					counting_Chars = 1;
					int iy_temp = iy,
						iz_temp = iz = (ix < 0) ? 0 : ix;
					while( counting_Chars > -1 )
					{
						//First interation counts the size of the backward diagonal word string
						//Second iteration inserts the extracted into the string comparison structure
						while( iz < Dictionary.dimentsions[0] && iy < Dictionary.dimentsions[1] )
						{
							if( counting_Chars == 0 )
								str_[++nextChar] = defs.Puzzle[iy, iz];
							else
								nextDiag++;
							iz++;
							iy++;
						}
						str_ = counting_Chars == 1 ? new Char[nextDiag] : str_;
						counting_Chars--;
						iy = iy_temp;
						iz = iz_temp;
					}
					HorizontalWords.GetSubStrings( str_, buffer );
				}
				buffer = HorizontalWords.TrimBuffers( buffer );
			}
		}
	}
}