/***********************************************************
* Author:			Matthew Klump
* Date Created:		Oct. 31, 2001
* Last Modification Date:	Oct. 26, 2001
* Project:			Fiboncci
* Filename:			Fiboncci.cpp
*
* Overview
*   Program will print the Fibonacci number sequence, repeated
*	printing the sequence not implemented
* Input:
*   User inputs the number of numbers in the sequence to print
* Output:
*   Message showing Fiboncci sequence to n specified numbers
*
***********************************************************/

#include <iostream>
#include <math.h>
using namespace std;

void main(void) {

	cout << "Please type a number to use for how many times you would like\n"
		<< "this program to print the Fibonacci numbers and press enter: ";
	double count, x = 1, y = 1;
	cin >> count;
		do {
			cout << x << " " << y << " ";
			x += y;
			y += x;
			count--;
		} while (count >= 0);
	
	cout << endl;
}