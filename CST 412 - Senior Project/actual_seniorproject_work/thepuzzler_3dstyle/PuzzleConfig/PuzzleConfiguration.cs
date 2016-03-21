//
//-------------------------------------------------------------------------------
// Module: PuzzleConfig Module
// Date:   April 6, 2005
// Purpose: Please see the Unit Test Plan for this completely defined.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//
using System;

namespace PuzzleConfig
{
	/// <summary>
	/// This class accepts and checks the users input to The Puzzler - 3D Style
	/// and checks for validity.
	/// </summary>
	public class PuzzleConfiguration
	{
		/// <summary>
		/// Represents the dictionary specifications for passing to Main.aspx Page
		/// </summary>
		public static int [] dictionarySpecs;
		/// <summary>
		/// Represents the three puzzle dimentions for verification
		/// </summary>
		public static int [] puzzleSizes;

		/// <summary>
		/// Default constructor
		/// </summary>
		public PuzzleConfiguration()
		{
		}
		/// <summary>
		/// This public operation will check all the user's data enteries for valid values
		/// as all integers within the boundaries of a valid System.Int32
		/// </summary>
		/// <param name="baseDiction">Base Dictionary Selection</param>
		/// <param name="dictionSize">Dictionary Size Specification</param>
		/// <param name="minWord">Minimum Word Size Specification</param>
		/// <param name="Xpuzzle">X Dimentional Length Specification</param>
		/// <param name="Ypuzzle">Y Dimentional Length Specification</param>
		/// <param name="Zpuzzle">Z Dimentional Length Specification</param>
		/// <returns>The appropriate error condition if any exists and based on user input.</returns>
		public static
			string
			CheckIntegerInput (
								string baseDiction, string dictionSize, string minWord,
								string Xpuzzle, string Ypuzzle, string Zpuzzle
								)
		{
			if( baseDiction == "" )
				return string.Format("You must provide a base dictionary selection numbered 1 through 4, " + 
					"please re-enter your selection. 1");
			else if( !IsNumeric( baseDiction ) )
				return string.Format("The base dictionary selection specified is not a number, please re-enter " + 
					"your base dictionary selection as 1 through 4. 1");
			else if( dictionSize == "" )
				return string.Format("You must provide a dictionary size in the form of a number to correctly " + 
					"build the dictionary, please re-enter the size of the dictionary. 2");
			else if( !IsNumeric( dictionSize ) )
				return string.Format("The dictionary size specified is not a number, please re-enter the " + 
					"dictionary size as a number. 2");
			else if( minWord == "" )
				return string.Format("You must provide a minimum dictionary word size that is greater than " + 
				"2, please re-enter the minimum dictionary word size. 3");
			else if( !IsNumeric( minWord ) )
				return string.Format("The minimum dictionary word size specified is not a number, please " + 
					" re-enter the minimum dictionary word size as a number. 3");
			else if( Xpuzzle == "" )
				return string.Format("You must provide the X dimentional length of the puzzle to properly " + 
					"build the puzzle, please re-enter the X dimentional length. 4");
			else if( !IsNumeric( Xpuzzle ) )
				return string.Format("The X dimentional length specified for the puzzle is not a number, " + 
					"please re-enter the X dimentional length as a number. 4");
			else if( Ypuzzle == "" )
				return string.Format("You must provide the Y dimentional length of the puzzle to properly " + 
					"build the puzzle, please re-enter the Y dimentional length. 5");
			else if( !IsNumeric( Ypuzzle ) )
				return string.Format("The Y dimentional length specified for the puzzle is not a number, " + 
					"please re-enter the Y dimentional length as a number. 5");
			else if( Zpuzzle == "" )
				return string.Format("You must provide the Z dimentional length of the puzzle to properly " + 
					"build the puzzle, please re-enter the Z dimentional length. 6");
			else if( !IsNumeric( Zpuzzle ) )
				return string.Format("The Z dimentional length specified for the puzzle is not a number, " + 
					"please re-enter the Z dimentional length as a number. 6");
			else if( decimal.Parse(baseDiction) < int.MinValue )
				return string.Format("The base dictionary selection specified is less than " + 
					"the smallest supported integer arguement {0}. 1", int.MinValue );
			else if( decimal.Parse(baseDiction) > int.MaxValue )
				return string.Format("The base dictionary selection specified is greated than " + 
					"the largest supported integer arguement {0}. 1", int.MaxValue );
			else if( decimal.Parse(dictionSize) < int.MinValue )
				return string.Format("The dictionary size specified is less than the smallest supported " + 
					"integer arguement {0}. 2", int.MinValue);
			else if( decimal.Parse(dictionSize) > int.MaxValue )
				return string.Format("The dictionary size specified is greater than the largest supported " + 
					"integer arguement {0}. 2", int.MaxValue );
			else if( decimal.Parse(minWord) < int.MinValue )
				return string.Format("The minimum dictionary word size specified is less than the smallest " + 
					"supported integer arguement {0}. 3", int.MinValue);
			else if( decimal.Parse(minWord) > int.MaxValue )
				return string.Format("The minimum dictionary word size specified is greater than the " + 
					"largest supported integer arguement {0}. 3", int.MaxValue );
			else if( decimal.Parse(Xpuzzle) < int.MinValue )
				return string.Format("The X dimentional length specified for the puzzle is less than the " + 
					"smallest supported integer arguement {0}. 4", int.MinValue );
			else if( decimal.Parse(Xpuzzle) > int.MaxValue )
				return string.Format("The X dimentional length specified for the puzzle is greater than " + 
					"the largest supported integer arguement {0}. 4", int.MaxValue );
			else if( decimal.Parse(Ypuzzle) < int.MinValue )
				return string.Format("The Y dimentional length specified for the puzzle is less than the " + 
					"smallest supported integer arguement {0}. 5", int.MinValue );
			else if( decimal.Parse(Ypuzzle) > int.MaxValue )
				return string.Format("The Y dimentional length specified for the puzzle is greater than " + 
					"the largest supported integer arguement {0}. 5", int.MaxValue );
			else if( decimal.Parse(Zpuzzle) < int.MinValue )
				return string.Format("The Z dimentional length specified for the puzzle is less than the " + 
					"smallest supported integer arguement {0}. 6", int.MinValue );
			else if( decimal.Parse(Zpuzzle) > int.MaxValue )
				return string.Format("The Z dimentional length specified for the puzzle is greater than " + 
					"the largest supported integer arguement {0}. 6", int.MaxValue );

			return "0"; // No error condition
		}
		/// <summary>
		/// This helper method will validate the arguements provided by the user. The static number
		/// limitations are based solely on the known contents of each dictionary word list file.
		/// </summary>
		/// <param name="baseDictionary">The number specifying which base dictionary to use.</param>
		/// <param name="dictionarySize">The number specifying how many words to randomly select.</param>
		/// <param name="minWordSize">The number specifying the minimum dictionary word size.</param>
		/// <param name="puzzleSizes">Contains the puzzle dimentions to check minimum word length.</param>
		/// <returns>The error string specific to the dictionary's current configuration, if any.</returns>
		public static
			string
			CheckDictionaryParameters( int baseDictionary, int dictionarySize,
									   int minWordSize, int [] puzzleSizes )
		{
			if( baseDictionary <= 0 || baseDictionary >= 5 )
				return "You should specify only one the four base " + 
					"dictionaries numbered 1 through 4. 1";
			switch( baseDictionary )
			{
				case 1:
					if( dictionarySize <= 999 || dictionarySize >= 38622 )
						return "For the \"base_dictionary#1.txt\", " +
							"You should specify a dictionary size that is greater that 1000 words " +
							"and less than 38622 words. 2";
					break;
				case 2:
					if( dictionarySize <= 999 || dictionarySize >= 106249 )
						return "For the \"base_dictionary#2.txt\", " +
							"You should specify a dictionary size that is greater that 1000 words " +
							"and less than 106249 words. 2";
					break;
				case 3:
					if( dictionarySize <= 999 || dictionarySize >= 213558 )
						return "For the \"base_dictionary#3.txt\", " +
							"You should specify a dictionary size that is greater that 1000 words " +
							"and less than 213558 words. 2";
					break;
				case 4:
					if( dictionarySize <= 999 || dictionarySize >= 869230 )
						return "For the \"base_dictionary#4.txt\", " +
							"You should specify a dictionary size that is greater that 1000 words " +
							"and less than 869230 words. 2";
					break;
				default:
					break;
			}
			if( minWordSize < 3 )
				return "The Minimum Word Length should be at least 3 characters" + 
					   " and not more than any length of the puzzle. 3";
			else if( minWordSize >= puzzleSizes[0] )
				return "The Minimum Word Length should be less than the X length of the puzzle. 3";
			else if( minWordSize >= puzzleSizes[1] )
				return "The Minimum Word Length should be less than the Y height of the puzzle. 3";
			else if( minWordSize >= puzzleSizes[2] )
				return "The Minimum Word Length should be less than the Z depth of the puzzle. 3";

			return "0"; // No error condition
		}
		/// <summary>
		/// This operation checks the dimentional lengths of the puzzle as provided by the
		/// user to see if they'd considered "reasonable" not to leave the user waiting for an
		/// eternity for the creation and solution algorithms to finish processing.
		/// </summary>
		/// <param name="puzzleSizes">Specifies the dimentional lengths to check.</param>
		/// <returns>The error string specific to the puzzle's current configuration.</returns>
		public static
			string
			CheckPuzzleParameters( int [] puzzleSizes )
		{
			if( puzzleSizes[0] < 6 )
				return "It's strongly suggested that the X puzzle length be at least 6 characters long. 4";
			else if( puzzleSizes[0] > 100 )
				return "It's strongly suggested that the X puzzle length be at most 100 characters long. 4";
			else if( puzzleSizes[1] < 6 )
				return "It's strongly suggested that the Y puzzle height be at least 6 characters high. 5";
			else if( puzzleSizes[1] > 100 )
				return "It's strongly suggested that the Y puzzle height be at most 100 characters high. 5";
			else if( puzzleSizes[2] < 6 )
				return "It's strongly suggested that the Z puzzle depth be at least 6 characters deep. 6";
			else if( puzzleSizes[2] > 100 )
				return "It's strongly suggested that the Z puzzle depth be at most 100 characters deep. 6";

			return "0"; // No error condition
		}
		/// <summary>
		/// This helper method determines, by the specified parameter str, wheather
		/// or not all the characters of this string instance are numeric.
		/// </summary>
		/// <param name="str">System.string to check.</param>
		/// <returns>True if all of word's characters are numeric,
		/// and false if any single character is not other than the
		/// negative sign or the decimal point.</returns>
		private static bool IsNumeric( string str )
		{
			int commaPosition = -1;
			while( (commaPosition = str.IndexOf(',')) != -1 )
				str = str.Remove( commaPosition, 1 );
			int numCount = 0;
			for( int x = 0; x < str.Length; x++ )
			{
				if( char.IsNumber( str[x] ) || str[x] == '.' || str[x] == '-' )
					numCount++;
			}
			return ( numCount >= str.Length );
		}
	}
}
