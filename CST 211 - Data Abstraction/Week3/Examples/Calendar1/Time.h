//This defines the Interface of the Time class
//This class provides an overloaded subtract operator
//and an overloaded << operator.

#pragma once

#include <iostream>

using namespace std;

class Time
{
public:				
	Time(int = 0, int = 0, int = 0);
	~Time(void);
	Time operator+ (int) const;
	int operator- (const Time&) const; //Must use const to accept const arguments
	Time operator- (int) const;		//Note the overloaded - operator.
	operator int () const;				//This is the cast operator to int
	int getHour() const;
	int getMinute() const;
	int getSecond() const;
	void printMilitary() const;
	void printStandard() const;
private:
	int hour;						//Note: These member variables are const
	int minute;
	int second;
friend ostream& operator<< (ostream&, const Time&);
};
