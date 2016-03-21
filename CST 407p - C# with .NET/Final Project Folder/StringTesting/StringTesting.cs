#region "Using Statements"
using System;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Collections.Specialized;
#endregion // "Using Statements"

namespace StringTesting
{
	/// <summary>
	/// This class used to test the puzzle word reading.
	/// </summary>
	class Class1
	{
		/// <summary>
		/// This method will reverse a C# string,
		/// Barrowed from Sagiv Hadaya --> http://www.c-sharpcenter.com/CSNET/string.asp
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public 
			static string Reverse( 
			string str)
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
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			StringCollection dictionaryWord = new StringCollection(),
				buffer = new StringCollection();
			StreamReader dictionReader = new StreamReader( args[0] ),
				buffReader = new StreamReader( args[1] );
			try
			{
				//Get the Dictionary
				while( dictionReader.Peek() > -1 )
					dictionaryWord.Add( dictionReader.ReadLine() );

				//Get the puzzle
				while( buffReader.Peek() > -1 )
					buffer.Add( buffReader.ReadLine() );
			}
			finally 
			{
				dictionReader.Close();
				buffReader.Close();
			}
			

			// Ger the northwest words
			StringCollection temp = new StringCollection();
			string str_ = new string(String.Empty.ToCharArray());
			for( int ix = 0; ix < buffer[0].Length; ++ix )
			{
				for( int iy = 0; iy < buffer.Count; ++iy )
					str_ = String.Concat( str_, buffer[iy][ix].ToString() );

				temp.Add( str_ );
				str_ = String.Empty;
			}
			buffer = temp;

			//Compare Dictionary to substrings in the puzzle horizontally
			StringCollection matchedWords = new StringCollection();
			foreach( string buff in buffer )
			{
				string tempBuff = buff;
				foreach( string diction in dictionaryWord )
				{
					string tempDiction = diction;
					for(int flipflop = 0; flipflop < 2; ++flipflop )
					{
						for(int pos = 0; pos < tempBuff.Length; ++pos)
						{
							for(int len = 0; pos + len <= tempBuff.Length; ++len)
							{
								if(tempDiction.CompareTo(tempBuff.Substring(pos, len)) == 0)
									if( !matchedWords.Contains(tempDiction) )
										matchedWords.Add( tempDiction );
							} // for(int len
						} // for(int pos
						tempBuff = Reverse( tempBuff );
					}
				} // foreach ( string diction
			} // foreach( string buff
			TextWriterTraceListener console =
				new TextWriterTraceListener( Console.Out );
			Trace.Listeners.Add( console );
			foreach( string str in matchedWords )
				Trace.WriteLine( str );
		} // Main()
	}
}
