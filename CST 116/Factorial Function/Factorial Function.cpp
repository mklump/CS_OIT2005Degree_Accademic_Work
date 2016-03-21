/***********************************************************
* Author:			Matthew Klump
* Date Created:		Oct. 27, 2001
* Last Modification Date:	Oct. 27, 2001
* Project:			Factorial Function
* Filename:			Factorial Function.cpp
*
* Overview
*   Program to call a function Factorial that will compute
*	the factorial value of a number given by the user. This
*	program is taken from "Problem Solving with C++", by 
*	Walter Savitch, page 155 (display 3.14)
* Input:
*   User input is an integer number used to compute its factorial value.
* Output:
*   Message showing the factorial value as an integerof 
*	the number providedby the user.
*
***********************************************************/

#include <iostream>
using namespace std;

long double Factorial(long double n);
//Returns factorial of n.
//The argument n should be nonnegative


void main(void) {
	long double num; //Used to compute the factorial value
	cout << "Please enter a number to compute the factorial value for: ";
	cin >> num; //Assuming user enters a nonzero integer
	
	cout << "The factorial value is " << Factorial(num) << endl;
		//output the factorial value
}

long double Factorial(long double n) {

	int product = 1;
	while(n > 0) {

		product *= n;

		n--; /*personal note: n is local to both the while loop
			 block and the Factorial function block*/
	}
	return product;
}