//
//-------------------------------------------------------------------------------
// Module: Solution Module
// SubModule: Solution_NWSideSESide
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
	/// Summary description for Solution_NWSideSESide.
	/// </summary>
	public sealed class Solution_NWSideSESide : Solution
	{
		private int xboundary, yboundary, zboundary;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Solution_NWSideSESide()
		{
			xboundary = xbound;
			yboundary = ybound;
			zboundary = zbound;
		}
		/// <summary>
		/// This helper method will get all of the specified puzzle substring
		/// possibilities in the direction of North West Side to South East Side
		/// as well as the reverse direction along that line of movement.
		/// </summary>
		/// <param name="puzzle">Puzzle to get the substring possibilities for</param>
		public void GetPossibilities_NWSideSESide( char[,,] puzzle )
		{
			int z = zboundary - 1,
				x = 0,
				y = 0;
			while( y < yboundary )
			{
				GetPuzzleSubStrings( puzzle, x, y, z, 0, 0, -1, 0, 0, -1, 5 );
				// begin next starting point recalculation
				x = x + 1;
				if( x > xboundary - 1 )
				{
					y = y + 1;
					x = 0;
				}
				// End next starting point recalculation
			} // End of while( true )
		} // End of public static void GetPossibilities_NWSideSESide( char[,,] puzzle )
	} // End of public class Solution_NWSideSESide
} // End of namespace Puzzle_Solution
