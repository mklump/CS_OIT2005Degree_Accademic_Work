//Arrays of Structures, and accessing data members.

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
	Time times[3];
	Time *mealTime;
	times[0].hour = 8;
	times[0].minute = 30;
	times[0].second = 0;
	times[1].hour = 12;
	times[1].minute = 15;
	times[1].second = 0;
	times[2].hour = 18;
	times[2].minute = 30;
	times[2].second = 0;
	
	for (int i = 0; i < 3; i++) {
		mealTime = &times[i];
		cout << "Meal " << i << " will be held at ";
		printMilitary(*mealTime);
		cout << " military time, " << endl << "which is ";
		printStandard(*mealTime);
		cout << " standard time." << endl;
	}
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