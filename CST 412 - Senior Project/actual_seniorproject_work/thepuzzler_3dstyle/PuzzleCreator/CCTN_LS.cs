//
//-------------------------------------------------------------------------------
// Module: Puzzle Creator Module
// SubModule: "Corner to Coner, Top North to the Lower South"
// Date:   January 31, 2005
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
	/// Summary description for CCTN_LS.
	/// </summary>
	public sealed class CCTN_LS : PuzzleCreator
	{
		/// <summary>
		/// Part of temporary helper interger variable.
		/// </summary>
		private int slots, topHalf;
		/// <summary>
		/// Default Constructor for Corner to Corner Top North to Lower South Class.
		/// </summary>
		public CCTN_LS()
		{
			slots = topHalf = 0;
			y = yBoundary - 1;
			x = xBoundary - 1;
			z = zBoundary - 1;
		}
		/// <summary>
		/// Polymorphically overrideable method for respective parsing.
		/// </summary>
		/// <param name="node">This RedBlack Tree node is the next node in the
		/// tree representing the dictionary.</param>
		protected override void Parse( RedBlack node )
		{
			int threeSlot = 0;
			while( y > -1 ) // stop condition
			{
				char firstChar = (char)( random.Next( 97, 123 ) );
				RedBlack tempNode = dictionaryCreator.NextWord( node, firstChar );
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
						z = z - 1;
						x = xBoundary - 1;
					}
					if( z < 3 )
					{
						y = y - 1;
						x = xBoundary - 1;
						z = zBoundary - 1;
					}
					if( y <= -1 )
					{
						switch( topHalf )
						{
							case 0:
								x = xBoundary - 1;
								y = yBoundary - 1;
								z = zBoundary - 1;
								topHalf++;
								break;
							case 1:
								y = -1;
								break;
							default:
								break;
						}
					}
				}
				threeSlot = 0;
			} // end while( y > -1 )
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
			int insertLength = 0;
			for( /*posx = posx, posy = posy, posz = posz*/;
				posx > -1 && posy > -1 && posz > -1;
				--posx, --posy, --posz )
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
			int nextChar = 0;
			for( /*x = posx, y = posy, z = posz*/;
				posx > -1 && posy > -1 && posz > -1 && nextChar < word.Length;
				--posx, --posy, --posz )
			{
				if( puzzle[posx,posy,posz] == ' ' )
					puzzle[posx, posy, posz] = word[nextChar++];
			}
		}
	}
}
