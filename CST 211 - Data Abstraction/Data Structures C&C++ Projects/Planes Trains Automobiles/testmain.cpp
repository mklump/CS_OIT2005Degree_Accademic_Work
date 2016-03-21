//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   March 2, 2002
// Last Change Date:  March 9, 2002
// Project:        Planes, Trains, and Automobiles
// Filename:       testmain.cpp
//
// Overview:	This main part of this program is a driver that will
//				test the various functions and member data so defined
//				for the class Color.
//
// Input:		None
//   
// Output:		Lines of text displayed in a win32 console form.
//   
//--------------------------------------------------------------------

//#include <iostream>
//using namespace std;

#include <string>
#include <fstream>

#include "Trip.h"

void main()
{
	//Plane Class Test
	Trip trip3;
	cout << trip3 << endl;

	Trip trip1("Portland", "Seattle", 2900);
	cout << trip1 << endl;

	Trip trip2("Ten'buck too", "Singapore", -4567);
	cout << trip2 << endl;

	Trip trip4("BangDrumSlowly", "Crow's Nest", 567);
	cout << trip4 << endl;
	if (trip1 < trip4)
		cout << trip1 << endl;
	else
		cout << trip4 << endl;
	PlaneTrip PlaneTrip3;
	//PlaneTrip Class Test
	cout << PlaneTrip3 << endl;

	PlaneTrip PlaneTrip1("Portland", "Seattle", 2900);
	cout << PlaneTrip1 << endl;

	PlaneTrip PlaneTrip2("Ten'buck too", "Singapore", -4567);
	cout << PlaneTrip2 << endl;

	PlaneTrip PlaneTrip4("BangDrumSlowly", "Crow's Nest", 567);
	cout << PlaneTrip4 << endl;
	if (PlaneTrip1 < PlaneTrip4)
		cout << PlaneTrip1 << endl;
	else
		cout << PlaneTrip4 << endl;

}
