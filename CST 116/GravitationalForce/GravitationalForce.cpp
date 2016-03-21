/***********************************************************
* Author:			Matthew Klump
* Date Created:		Oct. 20, 2001
* Last Modification Date:	Oct. 20, 2001
* Project:			GravitationalForce
* Filename:			GravitationalForce.cpp
*
* Overview
*   Program to call a function gravit_force to calcualtate the
*	gravitational force between two bodies. Recalculation will
*	not be used.
* Input:
*   User inputs are the masses of the two bodies, and the 
*	distance between them. 
* Output:
*   Message showing the gravitation force in units of
*	dynes for 1 dyne = (g * cm) / sec^2
*
***********************************************************/
#include <iostream>
#include <cmath>
#include <cstdlib>

const double G = 6.673e-8; //units of [cm^3 / (g * sec^2)]

double gravit_force (double mass1, double mass2, double distance);
//calculate the gravitational force

void main(void) {
	using namespace std;

	double x, y, z;

	cout << "Please enter a number for the mass of the first body: ";
	do {
		cin >> x;
		if (x <= 0) cout << "Please enter a positive, nonzero number for the first mass: ";
	} while (x <= 0);
	cout << "\nPlease enter a number for the mass of the second body: ";
	do {
		cin >> y;
		if (y <= 0) cout << "Please enter a positive, nonzero number for the second mass: ";
	} while (y <= 0);
	cout << "\nPlease enter a number for the distance between the two bodies: ";
	cin >> z;
	cout << "\nThe gravitational force in units of dynes is: "
		<< gravit_force(x, y, z) << endl << endl;
}

double gravit_force (double mass1, double mass2, double distance) {
	using namespace std;

	double force = (G * mass1 * mass2) / pow(distance,2);
	return force;
}