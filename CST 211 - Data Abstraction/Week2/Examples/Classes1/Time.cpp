//This defines the Implementation of the Time class.

#include "StdAfx.h"
#include "time.h"
#include <iostream>

using namespace std;

Time::Time(void)
{
	hour = minute = second = 0;
}

Time::~Time(void)
{
}

void Time::setTime(int h, int m, int s) {
	hour = (h >= 0 && h < 24) ? h : 0;
	minute = (m >= 0 && h < 60) ? m : 0;
	second = (s >= 0 && s < 60) ? s : 0;
}

void Time::printMilitary() {
	cout << (hour < 10 ? "0" : "") << hour << ":"
		 << (minute < 10 ? "0" : "") << minute << ":"
	     << (second < 10 ? "0" : "") << second;
}

void Time::printStandard() {
	cout << ((hour == 0 || hour == 12) ? 12 : hour % 12)
		 << ":" << (minute < 10 ? "0" : "") << minute
		 << ":" << (second < 10 ? "0" : "") << second
		 << (hour < 12 ? " AM" : " PM");
}
