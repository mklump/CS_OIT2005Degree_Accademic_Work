//This defines the Interface of the Time3 class
//This class provides an overloaded subtract operator
//and an overloaded << operator.

#pragma once

#include <iostream>

using namespace std;

class Time3
{
public:				
	Time3(int = 0, int = 0, int = 0);
	~Time3(void);
	int operator- (Time3&);
	Time3& operator+= (int);
	operator int ();	//This is the cast operator to int
	void setTime(int, int, int);
	void setTime(int, int);
	void setTime(int);
	int getHour();
	int getMinute();
	int getSecond();
	void setHour(int);
	void setMinute(int);
	void setSecond(int);
	void printMilitary();
	void printStandard();
private:
	int hour;
	int minute;
	int second;
friend ostream& operator<< (ostream&, Time3&);
};
