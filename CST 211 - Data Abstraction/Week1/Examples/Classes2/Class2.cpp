//This is the Driver program.
//This demonstrates default parameters and constructors

#include "stdafx.h"
#include "Time2.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	Time2 dinnerTime(19, 15), times[6], *timePtr;

	cout << "Dinner will be held at ";
	dinnerTime.printMilitary();
	cout << " military time, " << endl << "which is ";
	dinnerTime.printStandard();
	cout << " standard time." << endl;

	for (int i = 0; i < 6; i++) {
		timePtr = &times[i];
		timePtr->setTime(8+4*i);
	}
	for (int i = 0; i < 6; i++) {
		timePtr = &times[i];
		cout << "Meal " << i << " will be held at ";
		timePtr->printMilitary();
		cout << endl;
	}

	Time2 secondDinnerTime;
	secondDinnerTime = dinnerTime; //This performs a member copy
	secondDinnerTime.setHour(secondDinnerTime.getHour() + 1);	//This doesn't change dinnerTime
	cout << "Second Dinner service will be held at ";
	secondDinnerTime.printMilitary();
	return 0;
}

