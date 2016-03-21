//
//-------------------------------------------------------------------------------
// Module: Solution Module
// SubModule: Solution_CCTSLN
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
	/// Summary description for Solution_CCTSLN.
	/// </summary>
	public sealed class Solution_CCTSLN : Solution
	{
		private int xboundary, yboundary, zboundary;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Solution_CCTSLN()
		{
			xboundary = xbound;
			yboundary = ybound;
			zboundary = zbound;
		}
		/// <summary>
		/// This helper method will get all of the specified puzzle substring
		/// possibilities in the direction of Corner to Corner Top South to Lower
		/// North as well as the reverse direction along that line of movement.
		/// </summary>
		/// <param name="puzzle">Puzzle to get the substring possibilities for</param>
		public void GetPossibilities_CCTSLN( char[,,] puzzle )
		{
			int y = yboundary - 1,
				x = 0,
				z = 0;
			while( y > -1 )
			{
				GetPuzzleSubStrings( puzzle, x, y, z, xboundary, -1, zboundary, 1, -1, 1, 3 );
				// begin next starting point recalculation
				x = x + 1;
				if( x > xboundary - 3 )
				{
					z = z + 1;
					x = 0; // reset x back to starting point;
				}
				if( z > zboundary - 3 )
				{
					y = y - 1;
					z = 0; // reset z back to starting point;
				}
				// End next starting point recalculation

			} // End of while( true )
		} // End of public static void GetPossibilities_CCTSLN( char[,,] puzzle )
	} // End of public class Solution_CCTSLN : Solution
} // End of namespace Puzzle_Solution
