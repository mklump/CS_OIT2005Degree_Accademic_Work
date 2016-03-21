//
//-------------------------------------------------------------------------------
// Module: Solution Module
// SubModule: Solution_NETESWLE
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
	/// Summary description for Solution_NETESWLE.
	/// </summary>
	public sealed class Solution_NETESWLE : Solution
	{
		private int xboundary, yboundary, zboundary;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Solution_NETESWLE()
		{
			xboundary = xbound;
			yboundary = ybound;
			zboundary = zbound;
		}
		/// <summary>
		/// This helper method will get all of the specified puzzle substring
		/// possibilities in the direction of North East Top Edge to South West Lower Edge
		/// as well as the reverse direction along that line of movement.
		/// </summary>
		/// <param name="puzzle">Puzzle to get the substring possibilities for</param>
		public void GetPossibilities_NETESWLE( char[,,] puzzle )
		{
			int x = xboundary - 1,
				y = yboundary - 1,
				z = 0;
			while( z < zboundary )
			{
				GetPuzzleSubStrings( puzzle, x, y, z, -1, -1, 0, -1, -1, 0, 6 );
				// begin next starting point recalculation
				x = x - 1;
				if( x < 3 )
				{
					y = y - 1;
					x = xboundary - 1;
				}
				if( y < 3 )
				{
					z = z + 1;						
					y = yboundary - 1;
				}
				// End next starting point recalculation

			} // End of while( true )
		} // End of public static void GetPossibilities_NETESWLE( char[,,] puzzle )
	} // End of public class Solution_NETESWLE
} // End of namespace Puzzle_Solution
