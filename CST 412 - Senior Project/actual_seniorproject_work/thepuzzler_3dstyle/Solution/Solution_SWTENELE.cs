//
//-------------------------------------------------------------------------------
// Module: Solution Module
// SubModule: Solution_SWTENELE
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
	/// Summary description for Solution_SWTENELE.
	/// </summary>
	public sealed class Solution_SWTENELE : Solution
	{
		private int xboundary, yboundary, zboundary;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Solution_SWTENELE()
		{
			xboundary = xbound;
			yboundary = ybound;
			zboundary = zbound;
		}
		/// <summary>
		/// This helper method will get all of the specified puzzle substring
		/// possibilities in the direction of South West Top Edge to North East Lower Edge
		/// as well as the reverse direction along that line of movement.
		/// </summary>
		/// <param name="puzzle">Puzzle to get the substring possibilities for</param>
		public void GetPossibilities_SWTENELE( char[,,] puzzle )
		{
			int x = 0, 
				z = 0,
				y = yboundary - 1;
			while( z < zboundary )
			{
				GetPuzzleSubStrings( puzzle, x, y, z, xboundary, -1, 0, 1, -1, 0, 7 );
				// begin next starting point recalculation
				x = x + 1;
				if( x > xboundary - 3 )
				{
					y = y - 1;
					x = 0;
				}
				if( y < 3 )
				{
					z = z + 1;						
					y = yboundary - 1;
				}
				// End next starting point recalculation

			} // End of while( true )
		} // End of public static void GetPossibilities_SWTENELE( char[,,] puzzle )
	} // End of public class Solution_SWTENELE
} // End of namespace Puzzle_Solution
