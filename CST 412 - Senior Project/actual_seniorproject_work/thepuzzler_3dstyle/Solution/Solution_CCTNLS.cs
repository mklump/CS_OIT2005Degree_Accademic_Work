//
//-------------------------------------------------------------------------------
// Module: Solution Module
// SubModule: Solution_CCTNLS
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
	/// Summary description for Solution_CCTNLS.
	/// </summary>
	public sealed class Solution_CCTNLS : Solution
	{
		private int xboundary, yboundary, zboundary;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Solution_CCTNLS()
		{
			xboundary = xbound;
			yboundary = ybound;
			zboundary = zbound;
		}
		/// <summary>
		/// This helper method will get all of the specified puzzle substring
		/// possibilities in the direction of Corner to Corner Top North to Lower
		/// South as well as the reverse direction along that line of movement.
		/// </summary>
		/// <param name="puzzle">Puzzle to get the substring possibilities for</param>
		public void GetPossibilities_CCTNLS( char[,,] puzzle )
		{
			int x = xboundary - 1,
				y = yboundary - 1,
				z = zboundary - 1;
			while( y > -1 )
			{
				GetPuzzleSubStrings( puzzle, x, y, z, -1, -1, -1, -1, -1, -1, 2 );
				// begin next starting point recalculation
				x = x - 1;
				if( x < 3 )
				{
					z = z - 1;
					x = xboundary - 1; // reset x back to start value
				}
				if( z < 3 )
				{
					y = y - 1;
					z = zboundary - 1; // reset z back to their start value
				}
				// End next starting point recalculation

			} // End of while( true )
		} // End of public static void GetPossibilities_CCTNLS( char[,,] puzzle )
	} // End of public class Solution_CCTNLS : Solution
} // End of namespace Puzzle_Solution
