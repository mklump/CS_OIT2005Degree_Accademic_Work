///-------------------------------------------------------------------
/// Author:         Matthew Klump CST 407 Final Project
/// Date Created:	   January 25, 2004
/// Last Change Date:  January 25, 2004
/// Namespace:      Puzzle
/// Filename:       WordMatcing.cs
///
/// Overview: This file contains the interface for WordMatching.
///			  This code is meant to encapsulate the implementation
///			  for WordMatching.
///
/// Input:	  Input for this class is accepted from the dictionary stream
///			  of the Dictionary class.
/// Output:	  Output of this class is written to Console.Out.
///-------------------------------------------------------------------
#region "Using Statements"
using System;
using System.IO;
using System.Collections;
using System.Diagnostics;
#endregion

namespace Puzzle
{
	/// <summary>
	/// Summary description: This class WordMatching derives
	/// from IComparer for sorting and searching analysis.
	/// </summary>
	public class WordMatching : IComparer
	{
		/// <summary>
		/// Object reference to the Dictionary class.
		/// </summary>
		private static Dictionary dictionaryRef;

		/// <summary>
		/// Deafault constructor for the WordMatching class, does nothing.
		/// </summary>
		public WordMatching()
		{
		}
		/// <summary>
		/// Property DictionaryRef (Dictionary)
		/// </summary>
		public Dictionary DictionaryRef
		{
			set
			{
				dictionaryRef = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public void GetMyWords()
		{
		}
		/// <summary>
		/// Overview: Brings together all four buffers
		/// as a single unit for processing into the
		/// HorizontalWords buffer
		/// </summary>
		public void GatherBuffers()
		{
			dictionaryRef.horizon.Buffer.AddRange(
				dictionaryRef.vert.Buffer
				);
			dictionaryRef.horizon.Buffer.AddRange(
				dictionaryRef.forward.Buffer
				);
			dictionaryRef.horizon.Buffer.AddRange(
				dictionaryRef.backward.Buffer
				);
			dictionaryRef.horizon.Buffer.Sort( this );
		}
		/// <summary>
		/// Overview: Retrieves the dictionary words that matched
		/// the string possibilities within the puzzle.
		/// </summary>
		public void GetMatchedWords()
		{
			ArrayList col = new ArrayList();
			StreamReader dictionReader =
				new StreamReader( dictionaryRef.DictionaryStream );

			GatherBuffers();
			while( dictionReader.Peek() > -1 )
			{
				char [] str = dictionReader.ReadLine().ToCharArray();
				if( str.Length < 3 || str[str.Length - 2] == '\'' )
					continue;
				else if( dictionaryRef.horizon.Buffer.BinarySearch( str, this ) > 0
					&& col.BinarySearch( str, this ) < 0
					)
				{
					OutputCharArray( ref str );
					col.Insert( ~col.BinarySearch( str, this ), str );
				}
			}
		}
		/// <summary>
		/// Overview: This method is the implementation for
		/// the interface IComparer for two objects of type
		/// char [].
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public 
			int Compare(object x, object y)
		{
			char[] array1 = (char [])x;
			char[] array2 = (char [])y;
			//Assign the longer string length to length
			int length = (array2.Length < array1.Length) ?
				array1.Length :
				array2.Length ;

			for( int ix = 0; ix < length; ++ix )
			{
				if(ix == array1.Length)
					//array1 is the larger string
					return -1;
				else if(ix == array2.Length)
					//array2 is the larger string
					return 1;

				if( array1[ix] < array2[ix] )
					return -1;
				else if( array1[ix] > array2[ix] )
					return 1;
			}
			//char arrays are identical, return 0
			return 0;
		}
		/// <summary>
		/// Accepts a ref char [] data structure, and
		/// outputs it to the Trace.
		/// </summary>
		/// <param name="charArray"></param>
		public void OutputCharArray( ref char [] charArray )
		{
			IEnumerator myEnum = charArray.GetEnumerator();
			while( myEnum.MoveNext() )
			{
				Trace.Write( myEnum.Current.ToString() );
				Console.Write( myEnum.Current.ToString() );
			}

			Trace.WriteLine( string.Empty );
			Console.WriteLine( string.Empty );
		}
		// End WordMatching class
	}
	// End Puzzle namespace
}
