//This defines the Interface of the Time4 class
//In this example Time4 objects are immutable.
//This class provides an overloaded subtract operator
//and an overloaded << operator.

#pragma once

#include <iostream>

using namespace std;

class Time4
{
public:				
	Time4(int = 0, int = 0, int = 0);
	~Time4(void);
	Time4 operator+ (int) const;
	int operator- (const Time4&) const; //Must use const to accept const arguments
	Time4 operator- (int) const;		//Note the overloaded - operator.
	operator int () const;				//This is the cast operator to int
	int getHour() const;
	int getMinute() const;
	int getSecond() const;
	void printMilitary() const;
	void printStandard() const;
private:
	const int hour;						//Note: These member variables are const
	const int minute;
	const int second;
friend ostream& operator<< (ostream&, const Time4&);
};
