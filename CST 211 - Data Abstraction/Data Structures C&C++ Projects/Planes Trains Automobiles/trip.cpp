//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   9 March 2002
// Last Change Date:  
// Project:        Lab 4 Planes, Trains, and Automobiles
// Filename:       trip.cpp
//
// Overview:  This include contains the implentation of a Trip object,
//			  and a PlaneTrip object.
//     
//--------------------------------------------------------------------

#include <string>
#include "trip.h"

Trip::Trip(const Trip& t)
{
	//cout << "	-- Beginning Copy Constructor Call --";
	start_city = t.start_city;
	end_city = t.end_city;
	Distance = t.Distance;
	//cout << "	-- Ending Copy Constructor Call --";
}

bool less(const Trip& lhs, const Trip& rhs)
{
	if(lhs.Distance < rhs.Distance)
		return true;
	else
		return false;
}

bool operator < (const Trip& lhs, const Trip& rhs)
{
	if(less(lhs, rhs))
		return true;
	else
		return false;
}

ostream& operator << (ostream& lhs, const Trip& rhs)
{	
	lhs.width(15);
	lhs << rhs.start_city << " - ";
	lhs.width(15);
	lhs << rhs.end_city << " is ";
	lhs.width(4);
	lhs << rhs.Distance << " Miles";
	return lhs;
}

bool operator < (const PlaneTrip& lhs, const PlaneTrip& rhs)
{
	if(less(lhs, rhs))
		return true;
	else
		return false;
}

ostream& operator << (ostream& lhs, const PlaneTrip& rhs)
{	
	lhs.width(15);
	lhs << rhs.start_city << " - ";
	lhs.width(15);
	lhs << rhs.end_city << " is ";
	lhs.width(4);
	lhs << rhs.Distance << " Miles" << " Bag 1: ";
	lhs.width(4);
	lhs << rhs.Bag_1_ticket << " Bag 2: ";
	lhs.width(4);
	lhs << rhs.Bag_2_ticket;

	return lhs;
}

PlaneTrip::PlaneTrip(const PlaneTrip& t)
{
	//cout << "	-- Beginning Copy Constructor Call --";
	Bag_1_ticket = t.Bag_1_ticket;
	Bag_2_ticket = t.Bag_2_ticket;
	//cout << "	-- Ending Copy Constructor Call --";
}