//-------------------------------------------------------------------------------
// Module: Dictionary Creator Module
// Date:   January 22, 2005
// Purpose: Please see the Unit Test Plan for this completely defined.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------

using System;
using System.IO;
using System.Diagnostics;
using NUnit.Framework;

using Puzzle_Solution;
using ns_RedBlack;

namespace ns_DictionaryCreator
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class DictionaryCreator : Solution
	{
		// Place holder for private ManageDB dbconnection;	
		// Place holder for private PuzzleConfig configuration;
		private string nextWord;
		private string [] file;

		/// <summary>
		/// Default Class Constructor.
		/// </summary>
		public DictionaryCreator()
		{
			nextWord = "";
			file = new string [] { "base_dictionary#1.txt", "base_dictionary#2.txt",
								   "base_dictionary#3.txt", "base_dictionary#4.txt" };
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
		/// <param name="dictionarySize">Dictionary size indication parameter.</param>
		/// <returns>The completed RedBlack Tree dictionary.</returns>
		public RedBlack CreateDictionary( int baseDictionary, int dictionarySize )
		{
			if( baseDictionary <= 0 || baseDictionary >= 5 )
				throw new ApplicationException(
					"You must specify only one the four base " + 
					"dictionaries numbered one through four." );
			switch( baseDictionary )
			{
				case 1:
					if( dictionarySize <= 999 || dictionarySize >= 38622 )
						throw new ApplicationException( "For the \"base_dictionary#1.txt\", " +
							"you must specify a dictionary size that is greater that 1000 words " +
							"and less than 38622 words.");
					break;
				case 2:
					if( dictionarySize <= 999 || dictionarySize >= 106249 )
						throw new ApplicationException( "For the \"base_dictionary#2.txt\", " +
							"you must specify a dictionary size that is greater that 1000 words " +
							"and less than 106249 words.");
					break;
				case 3:
					if( dictionarySize <= 999 || dictionarySize >= 213558 )
						throw new ApplicationException( "For the \"base_dictionary#3.txt\", " +
							"you must specify a dictionary size that is greater that 1000 words " +
							"and less than 213558 words.");
					break;
				case 4:
					if( dictionarySize <= 999 || dictionarySize >= 869230 )
						throw new ApplicationException( "For the \"base_dictionary#4.txt\", " +
							"you must specify a dictionary size that is greater that 1000 words " +
							"and less than 869230 words.");
					break;
				default:
					break;
			}
			StreamReader reader = new StreamReader( file[baseDictionary - 1] );
			while( reader.Peek() != -1 ) // End of the stream is reached when Peek() returns -1
			{
				nextWord = reader.ReadLine();
				if( nextWord == "" )
					continue;
				else if( nextWord.Length > 32 || nextWord.Length < 3 )
					continue;
				else if( !IsAphabetic( nextWord ) )
					continue;
				else
					dictionary.RB_Insert( ref dictionary, nextWord.ToCharArray() );
			}
			reader.Close();
			dictionary = RandomizeDictionary( dictionary, dictionarySize );
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
		private RedBlack RandomizeDictionary( RedBlack dictionary, int size )
		{
			RedBlack returnValue = new RedBlack(),
				nextWord = new RedBlack(),
				proxy = dictionary;
			
			Random random = new Random();
			int index = 0;
			for( int x = 0; x < size; x++ )
			{
				// Next random first character in a word to select for insertion
				char firstChar = (char)random.Next( 97, 122 );
				// dictionary.Inorder_Tree_Walk( dictionary );
				nextWord = NextWord( proxy, firstChar );
				if( nextWord.Key == null )
				{
					x--;
					continue;
				}
				returnValue.RB_Insert( ref returnValue, nextWord.Key );
				index = x;
			}
			return returnValue;
		}
		/// <summary>
		/// This helper method will search for a word in the base dictionary
		/// whose first letter will match the randomly generated charater in
		/// the previous method call. If nothing is found, then the Sentinel
		/// Node is returned.
		/// </summary>
		/// <param name="word">Base dictionary to look through.</param>
		/// <param name="firstChar">Randomly selected first character to look for.</param>
		/// <returns>The RedBlack node word whose key has a first character
		/// that matches the randomly generated character.</returns>
		private RedBlack NextWord( RedBlack word, char firstChar )
		{
			char[] array = (char[]) word.Key;
			while( word != Sentinel.Node && firstChar != array[0] )
			{
				if( firstChar < array[0] )
					word = word.Left;
				else
					word = word.Right;
			}
			if( word != Sentinel.Node )
				// Did the search succeed?
				Assert.IsTrue( array[0] == firstChar );
			return word;
		}
	}
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
//			TextWriterTraceListener textWriterTraceListener =
//				new TextWriterTraceListener( new StreamWriter("output.txt", false) );
//			Trace.Listeners.Add( textWriterTraceListener );
			creator.Dictionary.Inorder_Tree_Walk( creator.Dictionary );
		}
		/// <summary>
		/// Test1 method.
		/// </summary>
		[Test]
		public void Test1()
		{
			dictionaryCreators[0] = new DictionaryCreator();
			dictionaryCreators[0].CreateDictionary( 1, 13456 );
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
			dictionaryCreators[1].CreateDictionary( 2, 34768 );
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
			dictionaryCreators[2].CreateDictionary( 3, 63456 );
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
			dictionaryCreators[3].CreateDictionary( 4, 796453 );
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
			TextWriterTraceListener writer = new TextWriterTraceListener( Console.Out ); 
			Trace.Listeners.Add( writer );
			DateTime timer1, timer2;
			DictionaryCreator_TestClass Test = new DictionaryCreator_TestClass();
			timer1 = new DateTime( DateTime.Now.Ticks );
			Test.Test1();
			timer2 = new DateTime( DateTime.Now.Ticks );
			Trace.WriteLine( string.Format("Dictionary #1 took \"{0}\" time to Create.", timer2.Subtract(timer1).ToString()) );
			timer1 = new DateTime( DateTime.Now.Ticks );
			Test.Test2();
			timer2 = new DateTime( DateTime.Now.Ticks );
			Trace.WriteLine( string.Format("Dictionary #1 took \"{0}\" time to Create.", timer2.Subtract(timer1).ToString()) );
			timer1 = new DateTime( DateTime.Now.Ticks );
			Test.Test3();
			timer2 = new DateTime( DateTime.Now.Ticks );
			Trace.WriteLine( string.Format("Dictionary #1 took \"{0}\" time to Create.", timer2.Subtract(timer1).ToString()) );
			timer1 = new DateTime( DateTime.Now.Ticks );
			Test.Test4();
			timer2 = new DateTime( DateTime.Now.Ticks );
			Trace.WriteLine( string.Format("Dictionary #1 took \"{0}\" time to Create.", timer2.Subtract(timer1).ToString()) );
		}
	}
}
