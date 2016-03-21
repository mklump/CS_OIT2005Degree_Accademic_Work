//
//-------------------------------------------------------------------------------
// Module: Puzzle Creator Module
// SubModule: "North East Top Edge to South West Lower Edge"
// Date:   February 8, 2005
// Purpose: Please see the Unit Test Plan for this completely defined.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//

using System;
using ns_RedBlack;
using System.Diagnostics;

namespace Puzzle_Creation
{
	/// <summary>
	/// Summary description for NETP_SWLE.
	/// </summary>
	public sealed class NETE_SWLE : PuzzleCreator
	{
		/// <summary>
		/// Available spaces to insert the next word.
		/// </summary>
		private int slots;
		/// <summary>
		/// Top half of the puzzle checking switch.
		/// </summary>
		private int checkAgain;
		/// <summary>
		/// Default Constructor for North East Top Edge to South West Lower Edge.
		/// </summary>
		public NETE_SWLE()
		{
			checkAgain = slots = 0;
			x = xBoundary - 1;
			y = yBoundary - 1;
			z = 0;
		}
		/// <summary>
		/// Polymorphically overrideable method for respective parsing.
		/// </summary>
		/// <param name="head">This RedBlack Tree node is the head node of the
		/// tree representing the dictionary.</param>
		protected override void Parse( RedBlack head )
		{
			int threeSlot = 0;
			while( z < zBoundary ) // stop condition
			{
				char firstChar = (char)( random.Next( 97, 123 ) );
				RedBlack tempNode = dictionaryCreator.NextWord( head, firstChar );
				if( tempNode == Sentinel.Node )
				{
					dictionaryCreator.UsedWords[firstChar] = 0;
					continue;
				}
				char[] word = (char[]) tempNode.Key;
				if( ( random.Next( 2 ) ) == 1 )
					word = Reverse( word );
				slots = CountInsertLength( x, y, z );
				if( word.Length <= slots )
					InsertWord( word, x, y, z );
				else if( slots > 2 && word.Length > slots && threeSlot < 10 )
				{
					// Last insert failed, leave both for loops to get next word
					// and available set of slots.
					threeSlot = (slots == 3) ? threeSlot + 1 : threeSlot;
					continue;
				}
				if( (slots = slots - word.Length) > 2 )
					// Check for slots remaining after the last InsertWord()
					continue;
				else
				{
					x = x - 1;
					if( x < 3 )
					{
						y = y - 1;
						x = xBoundary - 1;
					}
					if( y < 3 )
					{
						z = z + 1;						
						y = yBoundary - 1;
					}
					if( z >= zBoundary )
					{
						switch( checkAgain )
						{
							case 0:
								z = zBoundary - 1;
								checkAgain++;
								break;
							case 1:
								z = zBoundary;
								break;
							default:
								break;
						}
					}
				}
				threeSlot = 0;
			} // end of while( z < zBoundary )
		}

		/// <summary>
		/// This helper method count the next available set of cells to insert into.
		/// </summary>
		/// <returns>The next available amount of cells.</returns>
		/// <param name="posx">X start position.</param>
		/// <param name="posy">Y start position.</param>
		/// <param name="posz">Z start position.</param>
		private int CountInsertLength( int posx, int posy, int posz )
		{
			int insertLength;
			for( insertLength = 0;
				posx > -1 && posy > -1;
				--posx, --posy )
			{
				if( puzzle[posx,posy,posz] == ' ' )
					insertLength++;
//				else
//					Trace.Write( puzzle[posx,posy,posz].ToString() );
			}
			return insertLength;
		}
		/// <summary>
		/// This helper method will insert the specified word starting at the
		/// (posx,posy,posz) position along the CCTS_LN direction inside the puzzle.
		/// </summary>
		/// <param name="word">Next word to insert.</param>
		/// <param name="posx">X start position to insert.</param>
		/// <param name="posy">Y start position to insert.</param>
		/// <param name="posz">Z start position to insert.</param>
		private void InsertWord( char[] word, int posx, int posy, int posz )
		{
			for( int nextChar = 0;
				posx > -1 && posy > -1 && nextChar < word.Length;
				--posx, --posy )
			{
				if( puzzle[posx,posy,posz] == ' ' )
					puzzle[posx, posy, posz] = word[nextChar++];
			}
		}
	}
}
