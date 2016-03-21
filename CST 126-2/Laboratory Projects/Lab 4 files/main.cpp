//--------------------------------------------------------------------
// Author:         P. Hannan  
// Date Created:   28 Feb 2002
// Last Change Date:  
// Project:        Lab 4, cST126 F2002
// Filename:       main.cpp
//
// Overview:
//      This program allows the user to create trips
//        This is a test driver for Lab 4 part 2
//        You should create your own test main and use all
//        your functions one time prior to using this function.
//
//   YOU DO NOT NEED TO UNDERSTAND WHAT THIS PROGRAM IS DOING.
//     Just like in the real world, someone else can use your 
//      objects.
//   
// Input:
//      File that has start and stop cities with distances
//      Users choice of cities
// Output:
//      A list of trips and a sorted list of trips.
//--------------------------------------------------------------------

#include <iostream>
#include <fstream>
#include <iterator>
#include <string>
#include <vector>
#include <algorithm>
#include <time.h>
using namespace std;

#include "trips.h"

const int MAX_LEGS = 20;

//--------------------------------------------------------------------
// Prototypes
bool OpenFile (std::ifstream& input_file);

// Typedefs to make it easier to use STL
typedef std::ostream_iterator<PlaneTrip> PlaneOIter;
typedef std::vector <PlaneTrip>          PlaneContainer;
typedef PlaneContainer::iterator         PlaneIter;

typedef std::ostream_iterator<Trip> AutoOIter;
typedef std::vector <Trip>          AutoContainer;
typedef AutoContainer::iterator     AutoIter;


//--------------------------------------------------------------------
void main (void)
{
	//  Variable definitions	
	PlaneContainer Planes;      // A place to store plane trips
	AutoContainer  Autos;       // A place to store auto trips
	ifstream inFile;            // Trip INput file
	bool good_file;

    //  Work variables that are read from file
	double w_distance;      
	string w_start_city,w_end_city;
	
	// The Plane bag numbers are going to be random numbers
	//  so seed the random number generator.
	srand((unsigned) time(NULL));
	good_file = OpenFile(inFile);
	
	// Test the constructors:
	Trip t1, t2("Beaverton", "Wilsonville", 12);
	Trip t3(t2);
	
	PlaneTrip p1, p2("Portland", "Seattle", 180);
	PlaneTrip p3(p2);
	
	cout << "--- Test Auto Constructors ----" << endl;
	cout << "Auto Trip 1 : "  << t1 << endl;
	cout << "Auto Trip 2 : "  << t2 << endl;
	cout << "Auto Trip 3 : "  << t3 << endl;
	
	cout << endl;
	
	cout << "--- Test Plane Constructors ----" << endl;
	cout << "Plane Trip 1 : "  << t1 << endl;
	cout << "Plane Trip 2 : "  << p2 << endl;
	cout << "Plane Trip 3 : "  << p3 << endl;
		
	if (good_file)	{
		// Read from the input file
		while (!inFile.eof()) {
			inFile >> w_start_city;
			inFile >> w_end_city;
			inFile >> w_distance;

			// File the Plane and Auto containers.
			Planes.push_back(PlaneTrip(w_start_city,w_end_city, w_distance,rand()%60,rand()%30));
			Autos.push_back(Trip(w_start_city,w_end_city, w_distance));
		}		

		// Output the Plane and Auto trips using an output iterator
		PlaneOIter POutIter(std::cout, " \n");
		AutoOIter  AOutIter(std::cout, " \n");
		
		cout << "--- Possible Plane Trips ----" << endl;
		copy(Planes.begin(), Planes.end(), POutIter);
		cout << endl;
		cout << "--- Possible Auto Trips ----" << endl;
		copy(Autos.begin(),  Autos.end(), AOutIter);
		
		cout << endl << endl;
		
		// Sort the Plane and Auto trips using an your < sign
		//   Output the results
		cout << "--- Plane Trips sorted from shortest to longest ----" << endl;
		sort(Planes.begin(), Planes.end());
		copy(Planes.begin(), Planes.end(), POutIter);
		
		cout << endl;
		cout << "--- Auto Trips sorted from shortest to longest ----" << endl;
		sort(Autos.begin(),Autos.end());
		copy(Autos.begin(),Autos.end(), AOutIter);
	}
}

//--------------------------------------------------------------------
// Functions
//--------------------------------------------------------------------
// bool    OpenFile(file)
// Input:  file name (retrieved from user);
// Output: file pointer. 
//         Returns true if able to open file and false if 
//           unable to open file
bool OpenFile (std::ifstream& input_file)
{
	std::string filename;
	
	std::cout << "Please enter the input file name including extension : ";
	std::cin >> filename;
	
	input_file.open(filename.c_str());
	
	if (!input_file.fail())
	{
		//	std::cout << "Opened file " << filename << std::endl;
		return true;
	}
	else
	{
		std::cout << "ERROR: Unable to open file : " << filename << std::endl;
		return false;
	}
	
}
//--------------------------------------------------------------------
//  This #ifndef allows the program to compile both on Borland and MS
//--------------------------------------------------------------------

#ifndef _MSC_VER
#include "trips.cpp"
#endif