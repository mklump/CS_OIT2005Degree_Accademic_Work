//This is the Driver program.
//This demonstrates heavy use of const objects, and
//operator overloading.

#include "stdafx.h"
#include "Time4.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	const Time4 dinnerTime(19, 15);  //const declares dinnerTime to be immutable.
									 //You cannot use a nonconst method on dinnerTime.
	cout << "Dinner will be held at " << dinnerTime << endl;

	const Time4 lunchTime(12);
	cout << "Lunch will be held at " << lunchTime << endl;

	int difference = dinnerTime - lunchTime;
	cout << "There are " << difference << " seconds between lunch and dinner." << endl;
	
	const Time4 supperTime = dinnerTime - 3;
	cout << "Supper will be held at " << supperTime << endl;
	cout << "This is " << (int) supperTime << " seconds after midnight." << endl;
	
	return 0;
}



