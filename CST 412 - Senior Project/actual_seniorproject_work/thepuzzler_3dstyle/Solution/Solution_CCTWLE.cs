//
//-------------------------------------------------------------------------------
// Module: Solution Module
// SubModule: Solution_CCTWLE
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
	public sealed class Solution_CCTWLE : Solution
	{
		private int xboundary, yboundary, zboundary;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Solution_CCTWLE()
		{
			xboundary = xbound;
			yboundary = ybound;
			zboundary = zbound;
		}
		/// <summary>
		/// This helper method will get all of the specified puzzle substring
		/// possibilities in the direction of Corner to Corner Top West to Lower
		/// East as well as the reverse direction along that line of movement.
		/// </summary>
		/// <param name="puzzle">Puzzle to get the substring possibilities for</param>
		public void GetPossibilities_CCTWLE( char[,,] puzzle )
		{
			int x = 0,
				y = yboundary - 1,
				z = zboundary - 1;
			while( y > -1 )
			{
				GetPuzzleSubStrings( puzzle, x, y, z, xboundary, -1, -1, 1, -1, -1, 1 );
				// begin next starting point recalculation
				x = x + 1;
				if( x > xboundary - 3 )
				{
					z = z - 1;
					x = 0; // reset x back to starting point
				}
				if( z < 3 )
				{
					y = y - 1;
					z = zboundary - 1; // reset z back to starting point
				}
				// End next starting point recalculation

			} // End of while( true )
		} // End of private void GetPossibilities_CCTWLE( char[,,] puzzle )
	} // End of public class Solution_CCTWLE
}
