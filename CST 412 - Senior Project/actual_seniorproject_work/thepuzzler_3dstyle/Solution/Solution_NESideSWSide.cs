//
//-------------------------------------------------------------------------------
// Module: Solution Module
// SubModule: Solution_NESideSWSide
// Date:   February 23, 2005
// Purpose: Please see the Unit Test Plan for this completely defined.
// Author: Matthew Klump
//		   
// Project: The Puzzler - 3D Style
//-------------------------------------------------------------------------------
//
using System;

namespace Puzzle_Solution
{
	/// <summary>
	/// Summary description for Solution_NESideSWSide.
	/// </summary>
	public sealed class Solution_NESideSWSide : Solution
	{
		private int xboundary, yboundary, zboundary;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Solution_NESideSWSide()
		{
			xboundary = xbound;
			yboundary = ybound;
			zboundary = zbound;
		}
		/// <summary>
		/// This helper method will get all of the specified puzzle substring
		/// possibilities in the direction of North East Side to South West Side
		/// as well as the reverse direction along that line of movement.
		/// </summary>
		/// <param name="puzzle">Puzzle to get the substring possibilities for</param>
		public void GetPossibilities_NESideSWSide( char[,,] puzzle )
		{
			int x = xboundary - 1,
				z = 0,
				y = 0;
			while( y < yboundary )
			{
				GetPuzzleSubStrings( puzzle, x, y, z, -1, 0, 0, -1, 0, 0, 4 );
				// begin next starting point recalculation
				z = z + 1;
				if( z > zboundary - 1 )
				{
					y = y + 1;
					z = 0;
				}
				// End next starting point recalculation

			} // End of while( true )
		} // End of public static void GetPossibilities_NESideSWSide( char[,,] puzzle )
	} // End of public class Solution_NESideSWSide
} // End of namespace Puzzle_Solution