///-------------------------------------------------------------------
/// Author:         Matthew Klump CST 407 Final Project
/// Date Created:	   November 10, 2003
/// Last Change Date:  November 19, 2003
/// Namespace:      Puzzle
/// Filename:       PuzzleWordMatching.cs
///
/// Overview: This file contains the interface for PuzzleWordMatching.
///			  This code is meant to encapsulate the implementation
///			  for PuzzleWordMatching.
///
/// Input:	  Input is accepted from a file for which defines the 
///			  entries so used for this dictionary.
///			  Input is also accepted from a file for the puzzle contents
///			  itself.
/// Output:	  Output is written to the Trace with Console.Out added
///-------------------------------------------------------------------
#region "Using Statements"
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Specialized;
using NUnit.Framework;
#endregion


namespace PuzzleWordMatching
{
	/// <summary>
	/// Summary description for PuzzleWordMatching.
	/// </summary>
	[TestFixture]
	public class HorizontalWords
	{
		/// <summary>
		/// data fields
		/// </summary>
		private static StringCollection dictionaryWords;
		private static StringCollection matchedWords;
		private static StringCollection buffer;

		/// <summary>
		/// Property MatchedWords (StringCollection)
		/// </summary>
		public static StringCollection MatchedWords
		{
			get
			{
				return matchedWords;
			}
		}
		/// <summary>
		/// Property DictionaryWords (StringCollection)
		/// </summary>
		public static StringCollection DictionaryWords
		{
			get
			{
				return dictionaryWords;
			}
			set
			{
				dictionaryWords = value;
			}
		}
		/// <summary>
		/// Property Buffer (StringCollection)
		/// </summary>
		public static StringCollection Buffer
		{
			get
			{
				return buffer;
			}
			set
			{
				buffer = value;
			}
		}
		/// <summary>
		/// default constructor
		/// </summary>
		public HorizontalWords()
		{
			dictionaryWords = new StringCollection();
			buffer = new StringCollection();
			matchedWords = new StringCollection();
		}
		/// <summary>
		/// two arguement ArrayList constructor
		/// </summary>
		/// <param name="diction"></param>
		/// <param name="puzzle"></param>
		public HorizontalWords( ref ArrayList dictionary, ref ArrayList puzzle )
			: this()
		{
			ArrayList [] lists = new ArrayList[2] { dictionary, puzzle };
			StringCollection [] strings = ArrayListToStringCollection( lists );
			dictionaryWords = strings[0];
			buffer = strings[1]; 
		}
		/// <summary>
		/// Accepts an array of the System.Collection.ArrayList(s) to be Converted.
		/// Returns a System.Collections.Specialized.StringCollection array with deep copies.
		/// </summary>
		/// <param name="arrayLists"></param>
		/// <returns></returns>
		public static
			StringCollection []
			ArrayListToStringCollection( params ArrayList[] arrayLists )
		{
			StringCollection [] strings =
				new StringCollection[arrayLists.Length];
			for( int ix = 0; ix < arrayLists.Length; ++ix )
				strings[ix] = new StringCollection();
			for( int ix = 0; ix < arrayLists.Length; ++ix )
			{
				foreach( string str in arrayLists[ix] )
					strings[ix].Add( str );
			}

			return strings;
		}
		/// <summary>
		/// Accepts an array of the System.Collections.Specialized.StringCollection(s)
		/// to be Converted. Returns a System.Collection.ArrayList array with deep copies.
		/// </summary>
		/// <param name="arrayLists"></param>
		/// <returns></returns>
		public static
			ArrayList[]
			StringCollectionToArrayList( params StringCollection[] arrayLists )
		{
			ArrayList[] strings =
				new ArrayList[arrayLists.Length];
			for( int ix = 0; ix < arrayLists.Length; ++ix )
				strings[ix] = new ArrayList();
			for( int ix = 0; ix < arrayLists.Length; ++ix )
			{
				foreach( string str in arrayLists[ix] )
					strings[ix].Add( str );
			}

			return strings;
		}
		/// <summary>
		/// Removes empty strings in the puzzle buffer
		/// </summary>
		/// <param name="puzzle"></param>
		[Test]
		public static void RemoveEmptyStrings( ref StringCollection puzzle )
		{
			while( puzzle.Contains( string.Empty ) )
				puzzle.Remove( string.Empty );
		}

		/// <summary>
		/// gets the horizontal words in the puzzle
		/// </summary>
		[Test]
		public static void GetHorizontaltWords( StringCollection strings )
		{
			RemoveEmptyStrings( ref strings );
			StringCollection buffer_ = GetSubStrings( strings );
			foreach( string sub in buffer_ )
			{
				string substring = sub;
				for(int flipflop = 0; flipflop < 2; ++flipflop )
				{
					if( dictionaryWords.Contains( substring )
							   && !matchedWords.Contains( substring )
							   && !(substring.Length < 3) )
						matchedWords.Add( substring );

					substring = Reverse( substring );
				}
			}
		}
		/// <summary>
		/// Get all conceiveable horizontal substrings of a given puzzle
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		[Test]
		public static
			StringCollection GetSubStrings( StringCollection source )
		{
			StringCollection returnStructure = new StringCollection();
			foreach( string str in source )
				for(int pos = 0; pos < str.Length; ++pos)
					for(int len = 1; pos + len <= str.Length; ++len)
							returnStructure.Add(str.Substring(pos, len));

			return returnStructure;
		}

		/// <summary>
		/// This method will reverse a C# string,
		/// Barrowed from Sagiv Hadaya --> http://www.c-sharpcenter.com/CSNET/string.asp
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		[Test]
		public static
			string
				Reverse( 
						string str
						)
		{
			/*termination condition*/
			if (1== str.Length )
			{
				return 
					str ;
			}
			else
			{
				return Reverse(str.Substring( 1 )) + str.Substring( 0, 1 );
			}
		}
		/// <summary>
		/// Sorts the matched words in alphabetized asending order
		/// </summary>
		[Test]
		public static void AlphabetizeMatchedWords()
		{
			StringCollection[] lists = new StringCollection[1] { matchedWords };
			ArrayList[] arraylists = StringCollectionToArrayList( lists );
			foreach( ArrayList list in arraylists )
				list.Sort();

			lists = ArrayListToStringCollection( arraylists );
			matchedWords = lists[0];
		}

		/// <summary>
		/// Output matched words to a file.
		/// </summary>
		/// <param name="outputFileName"></param>
		[Test]
		public static void OutputMatchedWords()
		{
			TextWriterTraceListener wordMatchWriter = new 
				TextWriterTraceListener( Console.Out );
			Trace.Listeners.Add(wordMatchWriter);

			StringEnumerator matchedEnumerator = matchedWords.GetEnumerator();
			while( matchedEnumerator.MoveNext() )
					Trace.WriteLine( matchedEnumerator.Current.ToString() );
		}
	}
}
