//Structures, and accessing data members.

#include "stdafx.h"
#include <iostream>

using namespace std;

struct Time {
	int hour;
	int minute;
	int second;
};

void printMilitary(const Time&);
void printStandard(const Time&);

int _tmain(int argc, _TCHAR* argv[])
{
	Time dinnerTime, timeArray[10], *timePtr;

	dinnerTime.hour = 18;
	dinnerTime.minute = 30;
	dinnerTime.second = 0;
	
	cout << "Dinner will be held at ";
	printMilitary(dinnerTime);
	cout << " military time, " << endl << "which is ";
	printStandard(dinnerTime);
	cout << " standard time." << endl;
	return 0;
}

void printMilitary(const Time& t) {
	cout << (t.hour < 10 ? "0" : "") << t.hour << ":"
		 << (t.minute < 10 ? "0" : "") << t.minute << ":"
	     << (t.second < 10 ? "0" : "") << t.second;
}

void printStandard(const Time& t) {
	cout << ((t.hour == 0 || t.hour == 12) ? 12 : t.hour % 12)
		 << ":" << (t.minute < 10 ? "0" : "") << t.minute
		 << ":" << (t.second < 10 ? "0" : "") << t.second
		 << (t.hour < 12 ? " AM" : " PM");
}
