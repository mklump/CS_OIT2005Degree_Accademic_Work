//
//-------------------------------------------------------------------------------
// Module: Dictionary Creator Module
// Date:   January 22, 2005
// Purpose: Please see the Unit Test Plan for this completely defined.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//

using System;
using System.IO;
using System.Collections;
using System.Diagnostics;
using NUnit.Framework;
using Puzzle_Solution;
using ns_RedBlack;
using System.Net;

namespace ns_DictionaryCreator
{
	/// <summary>
	/// Summary description for DictionaryCreator.
	/// </summary>
	public class DictionaryCreator : Solution
	{
		// Place holder for private ManageDB dbconnection;	
		// Place holder for private PuzzleConfig configuration;
		/// <summary>
		/// The next word retrieved from the dictionary.
		/// </summary>
		private string nextWord;
		/// <summary>
		/// Array that has the appropriate web path referencs for the input files.
		/// </summary>
		private static string [] file;
		/// <summary>
		/// Maximum word length indicator for any given entry into the dictionary.
		/// </summary>
		private static int maximumWordLength;
		/// <summary>
		/// Dictionary list size indicator.
		/// </summary>
		private static int dictionarySize;
		/// <summary>
		/// Stream used to read the Dictionary into Solution.Dictionary RedBlack
		/// Binary Search Tree.
		/// </summary>
		private static StreamReader reader;
		/// <summary>
		/// Publicly available deep copy of the Solution.Dictionary after
		/// CreatDictionary is called.
		/// </summary>
		private static RedBlack tempTree;
		/// <summary>
		/// Property TempTree (RedBlack) Read Access Only
		/// </summary>
		public RedBlack TempTree
		{
			get { return tempTree; }
		}
		/// <summary>
		/// This SortedList is used to track what words were already selected
		/// in the NextWord() operation.
		/// </summary>
		private static SortedList usedWords;
				/// <summary>
		/// Property UsedWords (SortedList)
		/// </summary>
		public SortedList UsedWords
		{
			get{ return usedWords; }
		}

		/// <summary>
		/// This single argument helper operation retrieves the base dictionary
		/// input file and fills and sets the maximum word length.
		/// </summary>
		/// <param name="dictionaryNum">Specifies which dictionary to use.</param>
		private void GetDictionaryFile( int dictionaryNum )
		{
			usedWords = new SortedList();
			for(int x = 'a'; x < (int)('z' + 1); x++ )
				usedWords.Add( (char)x, 0 );
			dictionarySize = 0;
			nextWord = "";
			if( file == null )
			{	/* This will successfully access the input files if the IIS web server
				 * is running frontpage server extensions on thepuzzler_3dstyle web folder.
				 */
				file = new string [] { "base_dictionary#1.txt", "base_dictionary#2.txt",
									   "base_dictionary#3.txt", "base_dictionary#4.txt" };
				string path = Path.GetFullPath( "\\\\" + Dns.GetHostName() + "\\thepuzzler_3dstyle\\"
					+ file[dictionaryNum - 1] );
				try
				{
					reader = new StreamReader( path );
					file = null;
				}
				catch( DirectoryNotFoundException ) {}
				if( reader == null )
				{
					try
					{
						file = new string []
						{	/* This will successfully access the input files if the IIS web server
							* is running file share access on thepuzzler_3dstyle web folder.
							*/
							@"\\localhost\thepuzzler_3dstyle\base_dictionary#1.txt", 
							@"\\localhost\thepuzzler_3dstyle\base_dictionary#2.txt",
							@"\\localhost\thepuzzler_3dstyle\base_dictionary#3.txt",
							@"\\localhost\thepuzzler_3dstyle\base_dictionary#4.txt"
						};
						reader = new StreamReader( file[dictionaryNum - 1] );
						file = null;
					}
					catch( System.IO.FileNotFoundException error )
					{
						Trace.WriteLine( "You must make absolutely sure that the files base_dictionary#1.txt," + 
							"base_dictionary#2.txt, base_dictionary#3.txt, and base_dictionary#4.txt are " +
							"in the web folder http://<YourServersName>/thepuzzler_3dstyle/ !!" +
							"\nMessage:\n" + error.ToString() );
					}
				}
			}
			if( puzzle.GetUpperBound(0) + 1 > puzzle.GetUpperBound(1) + 1 &&
				puzzle.GetUpperBound(0) + 1 > puzzle.GetUpperBound(2) + 1 )
				maximumWordLength = puzzle.GetUpperBound(0) + 1;
			else if( puzzle.GetUpperBound(1) + 1 > puzzle.GetUpperBound(0) + 1 &&
				puzzle.GetUpperBound(1) + 1 > puzzle.GetUpperBound(2) + 1)
				maximumWordLength = puzzle.GetUpperBound(1) + 1;
			else
				maximumWordLength = puzzle.GetUpperBound(2) + 1;
		}
		/// <summary>
		/// Property DictionarySize (int) read access for the dictionary size;
		/// </summary>
		public int DictionarySize
		{
			get
			{
				return dictionarySize;
			}
		}
		/// <summary>
		/// The helper method determines, by the specified parameter word, wheather
		/// or not all the characters of this string instance are alphabetic.
		/// </summary>
		/// <param name="word">System.string to check.</param>
		/// <returns>True if all of word's characters are alphabetic,
		/// and false if any single character is not.</returns>
		private bool IsAphabetic( string word )
		{
			int alphaCount = 0;
			for( int x = 0; x < word.Length; x++ )
			{
				if( word[x] >= 'a' && word[x] <= 'z' || word[x] >= 'A' && word[x] <= 'Z' )
					alphaCount++;
			}
			return ( alphaCount >= word.Length );
		}
		/// <summary>
		/// Responsible for actually creating the RedBlack Tree dictionary
		/// when called from the single arguement DictionaryCreator constructor.
		/// </summary>
		/// <param name="baseDictionary">Base dictoinary selector parameter.</param>
		/// <param name="size">Dictionary size indication parameter.</param>
		/// <param name="minimumWordLength">Specifies the minimum length of a word.</param>
		/// <returns>The completed RedBlack Tree dictionary.</returns>
		public RedBlack CreateDictionary( int baseDictionary, int size, int minimumWordLength )
		{
			minimumWordLength = (minimumWordLength < 3) ? 3 : minimumWordLength;
			GetDictionaryFile( baseDictionary );
			while( reader.Peek() != -1 ) // End of the stream is reached when Peek() returns -1
			{
				nextWord = reader.ReadLine();
				if( nextWord == "" )
					continue;
				else if( nextWord.Length > maximumWordLength || nextWord.Length < 3 )
					continue;
				else if( !IsAphabetic( nextWord ) || nextWord.Length < minimumWordLength )
					continue;
				else
					dictionary.RB_Insert( ref dictionary, nextWord.ToCharArray() );
			}
			reader.Close();
			dictionary = RandomizeDictionary( dictionary, ref size );
			size = 0;
			dictionary.GetActualSize( dictionary, ref size );
			dictionarySize = size;
			return dictionary;
		}
		/// <summary>
		/// This helper method will randomize the dictionary created in the last
		/// method call, and decrease it's size to that specified by dictionarySize
		/// from the last method call.
		/// </summary>
		/// <param name="dictionary">The dictionary to randomize.</param>
		/// <param name="size">The size of the dictionary specified by the user.</param>
		/// <returns>The user specified RedBlack Tree dictionary.</returns>
		private RedBlack RandomizeDictionary( RedBlack dictionary, ref int size )
		{
			RedBlack returnValue = new RedBlack(),
				nextWord = null;
			tempTree = new RedBlack();
			tempTree.DeepCopy( dictionary, ref tempTree );
			Random random = new Random();
			for( int dictionSize = 0; dictionSize < size; dictionSize++ )
			{
				/* Next random first character in a word to select for insertion.
				 * Randomly select a lower case alphabet letter from (97)'a' to (122)'z'.
				 */
				char firstChar = (char)random.Next( 97, 123 );
				nextWord = NextWord( dictionary, firstChar );
				string word = new string( (char[])nextWord.Key );
				if( nextWord == Sentinel.Node )
				{
					dictionSize = dictionSize - 1;
					usedWords[firstChar] = 0;
					int actualSize = 0;
					dictionary.GetActualSize( dictionary, ref actualSize );
					if( actualSize == 0 && dictionSize == size - 1 )
					{
						size = dictionSize;
						return returnValue;
					}
					else if( actualSize == 0 && dictionSize != size - 1 )
						dictionary = tempTree;
				}
				else
				{
					dictionary.RB_Delete( ref dictionary, word.ToCharArray() );
					returnValue.RB_Insert( ref returnValue, word.ToCharArray() );
				}
				nextWord = null;
			}
			return returnValue;
		}
		/// <summary>
		/// This helper operation will search for a word in the base dictionary
		/// whose first letter will match the randomly generated charater in
		/// the previous method call. If nothing is found, then the Sentinel
		/// Node is returned.
		/// </summary>
		/// <param name="word">Base dictionary to look through.</param>
		/// <param name="firstChar">Randomly selected first character to look for.</param>
		/// <returns>The RedBlack node word whose key has a first character
		/// that matches the randomly generated character as an in/out passed by reference
		/// parameter.</returns>
		public RedBlack NextWord( RedBlack word, char firstChar )
		{
			string temp = null;
			int wordEncountered = 0;
			while( word != Sentinel.Node )
			{
				temp = new string((char[])word.Key);
				if( temp[0] == firstChar && 
					wordEncountered >= (int)usedWords[firstChar] )
					break;
				if( temp[0] == firstChar )
					wordEncountered++;
				if( firstChar < temp[0] )
					word = word.Left;
				else
					word = word.Right;
			}
			if( word != Sentinel.Node )
			{
				usedWords[firstChar] = (int)usedWords[firstChar] + 1;
				Assert.IsTrue( temp[0] == firstChar ); // Did the search succeed?
			}
			return word;
		}
	} // End of public class DictionaryCreator : Solution

	/// <summary>
	/// Test Class Harness for DictionaryCreator
	/// </summary>
	[TestFixture]
	public class DictionaryCreator_TestClass
	{
		private static DictionaryCreator [] dictionaryCreators;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public DictionaryCreator_TestClass()
		{
			dictionaryCreators = new DictionaryCreator[4];
		}
		/// <summary>
		/// OutPutDictionary() will write the entire contents of a given DictionaryCreator
		/// object as specified by the dictionary_ parameter.
		/// Special Note: Beware! This method will take serveral minutes and consume much
		/// system resources to print an ENTIRE dictionary to a file because the actual base
		/// dictionary are extremely large!
		/// </summary>
		/// <param name="creator">The parameter specifies which DictionaryCreator object 
		/// to write out to the file "output.txt"</param>
		public static void OutPutDictionary( DictionaryCreator creator )
		{
			creator.Dictionary.Inorder_Tree_Walk( creator.Dictionary );
		}
		/// <summary>
		/// Test1 method.
		/// </summary>
		[Test]
		public void Test1()
		{
			dictionaryCreators[0] = new DictionaryCreator();
			dictionaryCreators[0].CreateDictionary( 1, 13456, 3 );
//			Assert.IsTrue( "yearned" == new string((char[])dictionaries[0].Dictionary.Tree_Minimum(dictionaries[0].Dictionary).Key)
//				&& "my" == new string((char[])dictionaries[0].Dictionary.Tree_Maximum( dictionaries[0].Dictionary ).Key ));
		}
		/// <summary>
		/// Test2 method.
		/// </summary>
		[Test]
		public void Test2()
		{
			dictionaryCreators[1] = new DictionaryCreator();
			dictionaryCreators[1].CreateDictionary( 2, 34768, 3 );
//			Assert.IsTrue( "a" == new string((char[])dictionaries[1].Dictionary.Tree_Minimum(dictionaries[1].Dictionary).Key)
//				&& "zzzzzzzz" == new string((char[])dictionaries[1].Dictionary.Tree_Maximum( dictionaries[1].Dictionary ).Key ));
		}
		/// <summary>
		/// Test3 method.
		/// </summary>
		[Test]
		public void Test3()
		{
			dictionaryCreators[2] = new DictionaryCreator();
			dictionaryCreators[2].CreateDictionary( 3, 63456, 3 );
//			Assert.IsTrue( "aa" == new string((char[])dictionaries[2].Dictionary.Tree_Minimum(dictionaries[2].Dictionary).Key)
//				&& "zyzzogeton" == new string((char[])dictionaries[2].Dictionary.Tree_Maximum( dictionaries[2].Dictionary ).Key ));
		}
		/// <summary>
		/// Test4 method.
		/// </summary>
		[Test]
		public void Test4()
		{
			dictionaryCreators[3] = new DictionaryCreator();
			dictionaryCreators[3].CreateDictionary( 4, 796453, 3 );
//			Assert.IsTrue( "aA" == new string((char[])dictionaries[3].Dictionary.Tree_Minimum(dictionaries[3].Dictionary).Key)
//				&& "Karntnerstrasse-Rotenturmstrasse" == new string((char[])dictionaries[3].Dictionary.Tree_Maximum( dictionaries[3].Dictionary ).Key ));
		}
		/// <summary>
		/// Test class entry point, the point of these tests will be to estimate about
		/// how long it will take to put all four base dictionary into variously separate
		/// RedBlack Trees for later manipulation.
		/// </summary>
		/// <param name="args">test class arguments</param>
		public static void Main( string[] args )
		{
			DateTime timer1, timer2;
			DictionaryCreator_TestClass Test = new DictionaryCreator_TestClass();

//			timer1 = new DateTime( DateTime.Now.Ticks );
//			Test.Test1();
//			timer2 = new DateTime( DateTime.Now.Ticks );
//			Trace.WriteLine( string.Format("Dictionary #1 took \"{0}\" time to Create.", timer2.Subtract(timer1).ToString()) );

			timer1 = new DateTime( DateTime.Now.Ticks );
			Test.Test2();
			timer2 = new DateTime( DateTime.Now.Ticks );
			Trace.WriteLine( string.Format("Dictionary #2 took \"{0}\" time to Create.", timer2.Subtract(timer1).ToString()) );

//			timer1 = new DateTime( DateTime.Now.Ticks );
//			Test.Test3();
//			timer2 = new DateTime( DateTime.Now.Ticks );
//			Trace.WriteLine( string.Format("Dictionary #3 took \"{0}\" time to Create.", timer2.Subtract(timer1).ToString()) );
//
//			timer1 = new DateTime( DateTime.Now.Ticks );
//			Test.Test4();
//			timer2 = new DateTime( DateTime.Now.Ticks );
//			Trace.WriteLine( string.Format("Dictionary #4 took \"{0}\" time to Create.", timer2.Subtract(timer1).ToString()) );
		}
	}
}
