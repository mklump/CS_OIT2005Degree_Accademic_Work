//This defines the Implementation of the Time class.

#include "StdAfx.h"
#include "Time4.h"
#include <iostream>

using namespace std;

Time4::Time4(int hr, int min, int sec) :	//Must use member initialization because
	hour ((hr >= 0 && hr < 24) ? hr : 0),		//hour, minute, second are const.
	minute ((min >= 0 && min < 60) ? min : 0),
	second ((sec >= 0 && sec < 60) ? sec : 0)
{
}

Time4::~Time4(void)
{
}

Time4 Time4::operator+ (int hr) const {
	int newHour = hour + hr;
	if (newHour >= 24)
		newHour -= 24;
	Time4 result(newHour, minute, second);
	return result;
}

Time4 Time4::operator- (int hr) const {
	int newHour = hour - hr;
	if (newHour < 0)
		newHour += 24;
	Time4 result(newHour, minute, second);
	return result;
}

int Time4::operator- (const Time4& t) const {
	int t1 = hour*3600 + minute*60 + second;
	int t2 = t.hour*3600 + t.minute*60 + t.second;
	return t1 - t2;
}

Time4::operator int () const {
	return hour*3600 + minute*60 + second;	
};

//Note: This is NOT a member of the Time4 class.
//But it does need to be a friend.
//Note: The second parameter is const so we can accept const Time4 objects.

ostream& operator<< (ostream& output, const Time4& t) {
	output << (t.hour < 10 ? "0" : "") << t.hour << ":"
		 << (t.minute < 10 ? "0" : "") << t.minute << ":"
	     << (t.second < 10 ? "0" : "") << t.second;
	return output;	//enables chaining of <<
}

int Time4::getHour() const {
	return hour;
}

int Time4::getMinute() const {
	return minute;
}

int Time4::getSecond() const {
	return second;
}

void Time4::printMilitary() const {
	cout << (hour < 10 ? "0" : "") << hour << ":"
		 << (minute < 10 ? "0" : "") << minute << ":"
	     << (second < 10 ? "0" : "") << second;
}

void Time4::printStandard() const {
	cout << ((hour == 0 || hour == 12) ? 12 : hour % 12)
		 << ":" << (minute < 10 ? "0" : "") << minute
		 << ":" << (second < 10 ? "0" : "") << second
		 << (hour < 12 ? " AM" : " PM");
}
