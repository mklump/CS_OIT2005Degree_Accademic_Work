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
using NUnit.Framework;
using System.Collections;
using System.IO;
#endregion

namespace Puzzle
{
	/// <summary>
	/// Summary Description: ForwardDiagonalWords class object
	/// is responsible for extracting all the Forward Diagonal
	/// string possibilities in the puzzle.
	/// </summary>
	[TestFixture]
	public class ForwardDiagonalWords
	{
		/// <summary>
		/// Overview: Data structure containing all possible
		/// string combinations for ForwardDiagonalWords.
		/// </summary>
		public static volatile ArrayList buffer;
		/// <summary>
		/// Object reference to the Dictionary class object.
		/// </summary>
		private Dictionary defs;
		/// <summary>
		/// Buffer for processing the forward diagonal strings.
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
		/// Default constructor for ForwardDiagonalWords, initializes instances.
		/// </summary>
		public ForwardDiagonalWords()
		{
			defs = new Dictionary();
			buffer = new ArrayList();
		}
		/// <summary>
		/// Overview: Retrieves the forward diagonal 
		/// string possibilities in the puzzle.
		/// </summary>
		public void GetForwardDiagonalWords()
		{
			int ix,		//loop counter
				iy = 0, // row selector
				iz = 0, // column selector
				nextDiag = 0, // next diagonal string length in puzzle
				nextChar = 0, // next char to extract based on line orientation
				counting_Chars = 1; // counting chars state indicator

			unchecked
			{
				for( ix = 0;
					iy < Dictionary.dimentsions[1];
					++ix,
					iy = (ix > Dictionary.dimentsions[0] - 1) ? iy + 1 : 0 )
				{
					nextChar = -1;
					nextDiag = 0;
					counting_Chars = 1;
					int iy_temp = iy,
						iz_temp = iz = (ix > Dictionary.dimentsions[0] - 1) ?
						Dictionary.dimentsions[0] - 1 :
						ix;
					while( counting_Chars > -1 )
					{
						//First interation counts the size of the backward diagonal word string
						//Second iteration inserts the extracted into the string comparison structure
						while( iz > -1 && iy < Dictionary.dimentsions[1] )
						{
							if( counting_Chars == 0 )
								str_[++nextChar] = defs.Puzzle[iy, iz];
							else
								nextDiag++;
							iz--;
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