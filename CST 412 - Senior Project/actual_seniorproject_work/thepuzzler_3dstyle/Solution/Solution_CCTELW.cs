//
//-------------------------------------------------------------------------------
// Module: Solution Module
// SubModule: Solution_CCTELW
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
	/// Summary description for Solution_CCTELW.
	/// </summary>
	public sealed class Solution_CCTELW : Solution
	{
		/// <summary>
		/// Private copies of the puzzle boudary values
		/// </summary>
		private int xboundary, yboundary, zboundary;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Solution_CCTELW()
		{
			xboundary = xbound;
			yboundary = ybound;
			zboundary = zbound;
		}
		/// <summary>
		/// This helper method will get all of the specified puzzle substring
		/// possibilities in the direction of Corner to Corner Top East to Lower
		/// West as well as the reverse direction along that line of movement.
		/// </summary>
		/// <param name="puzzle">Puzzle to get the substring possibilities for</param>
		public void GetPossibilities_CCTELW( char[,,] puzzle )
		{
			int x = xboundary - 1,
				y = yboundary - 1,
				z = 0;
			while( y > -1 )
			{
				GetPuzzleSubStrings( puzzle, x, y, z, -1, -1, zboundary, -1, -1, 1, 0 );
				// begin next starting point recalculation
				x = x - 1;
				if( x < 3 )
				{
					z = z + 1;
					x = xboundary - 1; // reset x back to start value
				}
				if( z > zboundary - 3 )
				{
					y = y - 1;
					z = 0; // reset z back to their start value
				}
				// End next starting point recalculation

			} // End of while( true )
		} // End of private void GetPossibilities_CCTELW( char[,,] puzzle )
	} // End of public static class Solution_CCTELW
}
