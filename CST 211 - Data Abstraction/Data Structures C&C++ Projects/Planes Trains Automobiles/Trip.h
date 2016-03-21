//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   9 March 2002
// Last Change Date:  
// Project:        Lab 4 Planes, Trains, and Automobiles
// Filename:       trip.h
//
// Overview:  This include contains the interface of a Trip object,
//			  and a PlaneTrip object.
//     
//--------------------------------------------------------------------

#ifndef TRIP_H
#define TRIP_H

#include <iostream>
using namespace std;

class Trip
{
public:
	//This default constructor will blank the cities and makes the distance 0.
	Trip() : start_city(""), end_city(""), Distance(0.0) {};

	//Practise copy constructor (not really used)
	Trip(const Trip& t);

	//This constructor sets the distance to 0 if a negative distance is passed in.
	//All appropriate memeber data is initialized here.
	Trip(const string& start, const string& end, const double& distance = 0.0)
		: start_city(start), end_city(end), Distance(distance)
		{if(distance < 0) Distance = 0.0;};

	//This compares the distance to determine if the trip is shorter.
	friend bool less(const Trip& lhs, const Trip& rhs);

	//Uses the memberfunction less to determine whether one trip is shorter
	//than another.
	friend bool operator < (const Trip& lhs, const Trip& rhs);

	//Nicely prints out member data of object Trip;
	friend ostream& operator << (ostream& lhs, const Trip& rhs);

protected:
	string start_city, 
		   end_city;
	double Distance;
};

class PlaneTrip : public Trip
{
public:
	//This is the default constructor for class PlaneTrip
	PlaneTrip() : Trip(), Bag_1_ticket(0), Bag_2_ticket(0){};

	//Practise copy constructor (not really used)
	PlaneTrip(const PlaneTrip& t);

	//Five arguement constructor for the class PlaneTrip
	PlaneTrip(const string& start, const string& end, const double& distance,
		const int& bag1 = 0, const int& bag2 = 0) : Trip(), Bag_1_ticket(bag1),
		Bag_2_ticket(bag2) {};

	//Uses the memberfunction less to determine whether one trip is shorter
	//than another.
	friend bool operator < (const PlaneTrip& lhs, const PlaneTrip& rhs);

	//Nicely prints out member data of object Trip;
	friend ostream& operator << (ostream& lhs, const PlaneTrip& rhs);
private:
	int Bag_1_ticket,
		Bag_2_ticket;
};

#endif //TRIP_H