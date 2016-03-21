//
//-------------------------------------------------------------------------------
// Module: Solution Module
// SubModule: Solution_WVEEVE
// Date:   February 25, 2005
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
	/// Summary description for Solution_WVEEVE.
	/// </summary>
	public sealed class Solution_WVEEVE : Solution
	{
		private int xboundary, yboundary, zboundary;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Solution_WVEEVE()
		{
			xboundary = xbound;
			yboundary = ybound;
			zboundary = zbound;
		}
		/// <summary>
		/// This helper method will get all of the specified puzzle substring
		/// possibilities in the direction of West Vertical Edge to East Vertical Edge
		/// as well as the reverse direction along that line of movement.
		/// </summary>
		/// <param name="puzzle">Puzzle to get the substring possibilities for</param>
		public void GetPossibilities_WVEEVE( char[,,] puzzle )
		{
			int x = 0,
				y = 0,
				z = zboundary - 1;
			while( y < yboundary )
			{
				GetPuzzleSubStrings( puzzle, x, y, z, xboundary, 0, -1, 1, 0, -1, 9 );
				// begin next starting point recalculation
				z = z - 1;
				if( z < 3 )
				{
					x = x + 1;
					z = zboundary - 1;
				}
				if( x > xboundary - 3 )
				{
					y = y + 1;						
					x = 0;
				}
				// End next starting point recalculation

			} // End of while( true )
		} // End of public static void GetPossibilities_WVEEVE( char[,,] puzzle )
	} // End of public class Solution_WVEEVE
} // End of namespace Puzzle_Solution
