//This is the Driver program.
//This demonstrates operator overloading

#include "stdafx.h"
#include "Time3.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	Time3 resultTime;
	Time3 dinnerTime(19, 15);
	cout << "Dinner will be held at " << dinnerTime << endl;

	Time3 lunchTime(19, 14);
	cout << "Lunch will be held at " << lunchTime << endl;

	int difference = dinnerTime - lunchTime;
	cout << "There are " << difference << " seconds between lunch and dinner." << endl;
	
	resultTime = ((dinnerTime += 1) += 1);
	cout << "Dinner has been moved to " << dinnerTime << "!!!" << endl;
	cout << "This is " << (int) dinnerTime << " seconds after midnight." << endl;
	cout << "resultTime is " << resultTime;
	return 0;
}