/***********************************************************
* Author:			Matthew Klump
* Date Created:		Nov. 4, 2001
* Last Modification Date:	Nov. 4, 2001
* Project:			OverLoadingFunctions
* Filename:			OverLoadingFunctions.cpp
*
* Overview
*   Program to demonstrate overloading the function Ave.
*	This problem is from "Problem Solving with C++", by 
*	Walter Savitch, page 157 (Display 3.15)
* Input:
*   Provided by the program itself
* Output:
*   Message showing the average of some numbers for the
*	first and second overloaded functions of Ave respectively.
***********************************************************/
#include <iostream>

double Ave(double n1, double n2);
//Returns the average of the two numbers n1 and n2.

double Ave(double n1, double n2, double n3);
//Returns the average of the three numbers n1, n2, and n3.

int main() {

	using namespace std;
	cout << "The average of 2.0, 2.5, and 3.0 is: "
		<< Ave(2.0, 2.5, 3.0) << endl;

	cout << "The average of 4.5 and 5.5 is: "
		<< Ave(4.5, 5.5) << endl;

	return 0;
}

double Ave(double n1, double n2) {

	return ((n1 + n2) / 2.0);
}

double Ave(double n1, double n2, double n3) {

	return ((n1 + n2 + n3)/3.0);
}