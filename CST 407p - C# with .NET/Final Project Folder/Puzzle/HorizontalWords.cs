///-------------------------------------------------------------------
/// Author:         Matthew Klump CST 407 Final Project
/// Date Created:	   November 10, 2003
/// Last Change Date:  November 19, 2003
/// Namespace:      Puzzle
/// Filename:       HorizontalWords.cs
///
/// Overview: This file contains the interface for HorizontalWords.
///			  This code is meant to encapsulate the implementation
///			  for HorizontalWords.
///
/// Input:	  Input is accepted from a file for which defines the 
///			  entries so used for this dictionary.
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
	/// Summary description for HorizontalWords.
	/// </summary>
	[TestFixture]
	public class HorizontalWords
	{
		/// <summary>
		/// Overview: Data structure containing all possible
		/// string combinations for HorizontalWords.
		/// </summary>
		public static volatile ArrayList buffer;
		/// <summary>
		/// Object reference to the Dictionary class.
		/// </summary>
		private Dictionary defs;

		/// <summary>
		/// Overview: Default Constructor, initializes instance
		/// </summary>
		public HorizontalWords()
		{
			buffer = new ArrayList();
		}
		/// <summary>
		/// Property ArrayList Buffer (static)
		/// </summary>
		public ArrayList Buffer
		{
			get
			{
				return buffer;
			}
		}
		/// <summary>
		/// Overview: Retrieves the horizontal string possibilities.
		/// </summary>
		public void GetHorizontaltStrings()
		{
			unchecked
			{
				defs = new Dictionary();
				char [] nextString = new char[Dictionary.dimentsions[0]];
				for( int ix = 0; ix < Dictionary.dimentsions[1]; ++ix )
				{
					for( int iy = 0; iy < Dictionary.dimentsions[0]; ++iy )
						nextString[iy] = defs.Puzzle[ix,iy];

					GetSubStrings( nextString, buffer );
				}
				buffer = TrimBuffers( buffer );
			}
		}
		/// <summary>
		/// Overview: Trims the end of buffers
		/// Horizontal, Vertical, ForwardDiagonal,
		/// and BackwardDiagonal
		/// </summary>
		public static
			ArrayList
			TrimBuffers(
						   ArrayList 
						   targetBuffer
						   )
		{
			targetBuffer.TrimToSize();
			return targetBuffer;
		}
		/// <summary>
		/// Overview: Retrieves all possible horizontal
		/// substrings of a given puzzle line.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="target"></param>
		public static
			void
			GetSubStrings(
						  char [] source,
						  ArrayList listBuffer
						  )
		{
			unchecked
			{
				int nextChar = -1;
				for(int pos = 0; pos < source.Length; ++pos)
					for(int len = 3; pos + len <= source.Length; ++len)
					{
						char [] nextSubString = new char[len];
						for( int ix = pos; ix < pos + len; ++ix )
							nextSubString[++nextChar] = source[ix];

						nextChar = -1;
						if(
							nextSubString[nextSubString.Length - 1] == 'z'
							|| nextSubString[nextSubString.Length - 1] == 'q'
							)
							break;
						InsertString( nextSubString, listBuffer );
					}
			}									 
		}
		/// <summary>
		/// Overview: Inserts the string str and its reverse
		/// equivalence at the end of the ArrayList buffer.
		/// </summary>
		/// <param name="str"></param>
		/// <param name="target"></param>
		public static
			void
			InsertString(
						 char [] str,
						 ArrayList target
						 )
		{
			unchecked
			{
				int two = 2, ix = 0;
				while( ix < two )
				{
					if( ix == 0 )
					{
						target.Add( str );
					}
					else
						target.Add( Reverse(str) );
					ix = ix + 1;
				}
			}
		}

		/// <summary>
		/// This method will reverse a C# char[].
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static
			char []
				Reverse( 
						char [] str
						)
		{
			unchecked
			{
				char [] temp = new char[str.Length];
				int iy = -1;
				for( int ix = str.Length - 1; ix > -1; --ix )
					temp[++iy] = str[ix];

				return temp;
			}
		}
	}
}
