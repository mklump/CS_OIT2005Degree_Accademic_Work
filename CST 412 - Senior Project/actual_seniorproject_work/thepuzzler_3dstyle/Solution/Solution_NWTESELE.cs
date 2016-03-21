//
//-------------------------------------------------------------------------------
// Module: Solution Module
// SubModule: Solution_NWTESELE
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
	/// Summary description for Solution_NWTESELE.
	/// </summary>
	public sealed class Solution_NWTESELE : Solution
	{
		private int xboundary, yboundary, zboundary;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Solution_NWTESELE()
		{
			xboundary = xbound;
			yboundary = ybound;
			zboundary = zbound;
		}
		/// <summary>
		/// This helper method will get all of the specified puzzle substring
		/// possibilities in the direction of North West Top Edge to South East Lower Edge
		/// as well as the reverse direction along that line of movement.
		/// </summary>
		/// <param name="puzzle">Puzzle to get the substring possibilities for</param>
		public void GetPossibilities_NWTESELE( char[,,] puzzle )
		{
			int x = 0,
				y = yboundary - 1,
				z = zboundary - 1;
			while( x < xboundary )
			{
				GetPuzzleSubStrings( puzzle, x, y, z, 0, -1, -1, 0, -1, -1, 11 );
				// begin next starting point recalculation
				z = z - 1;
				if( z < 3 )
				{
					y = y - 1;
					z = zboundary - 1;
				}
				if( y < 3 )
				{
					x = x + 1;						
					y = yboundary - 1;
				}
				// End next starting point recalculation

			} // End of while( true )
		} // End of public static void GetPossibilities_NWTESELE( char[,,] puzzle )
	} // End of public class Solution_NWTESELE
} // End of namespace Puzzle_Solution
