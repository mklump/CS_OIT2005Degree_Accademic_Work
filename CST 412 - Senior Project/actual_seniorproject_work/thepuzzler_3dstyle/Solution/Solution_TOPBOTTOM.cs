//
//-------------------------------------------------------------------------------
// Module: Solution Module
// SubModule: Solution_TOPBOTTOM
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
	/// Summary description for Solution_TOPBOTTOM.
	/// </summary>
	public sealed class Solution_TOPBOTTOM : Solution
	{
		private int xboundary, yboundary, zboundary;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Solution_TOPBOTTOM()
		{
			xboundary = xbound;
			yboundary = ybound;
			zboundary = zbound;
		}
		/// <summary>
		/// This helper method will get all of the specified puzzle substring
		/// possibilities in the direction of Top Side to the Bottom Side
		/// as well as the reverse direction along that line of movement.
		/// </summary>
		/// <param name="puzzle">Puzzle to get the substring possibilities for</param>
		public void GetPossibilities_TOPBOTTOM( char[,,] puzzle )
		{
			int y = yboundary - 1,
				x = 0,
				z = 0;
			while( x < xboundary ) // While loop stop condition MUST be correct, NO EXCEPTIONS!
			{
				GetPuzzleSubStrings( puzzle, x, y, z, 0, -1, 0, 0, -1, 0, 12 );
				// begin next starting point recalculation
				z = z + 1;
				if( z > zboundary - 1 )
				{
					x = x + 1;
					z = 0;
				}
				// End next starting point recalculation

			} // End of while( true )
		} // End of public static void GetPossibilities_TOPBOTTOM( char[,,] puzzle )
	} // End of public class Solution_TOPBOTTOM
} // End of namespace Puzzle_Solution
