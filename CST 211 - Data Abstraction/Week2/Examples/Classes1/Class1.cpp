//This is the Driver program.

#include "stdafx.h"
#include "Time.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	Time dinnerTime, times[6], *timePtr;

	dinnerTime.setTime(18, 30, 0);
	cout << "Dinner will be held at ";
	dinnerTime.printMilitary();
	cout << " military time, " << endl << "which is ";
	dinnerTime.printStandard();
	cout << " standard time." << endl;

	for (int i = 0; i < 6; i++) {
		timePtr = &times[i];
		timePtr->setTime(8+4*i, 0, 0);
	}
	for (int i = 0; i < 6; i++) {
		timePtr = &times[i];
		cout << "Meal " << i << " will be held at ";
		timePtr->printMilitary();
		cout << endl;
	}
	return 0;
}

