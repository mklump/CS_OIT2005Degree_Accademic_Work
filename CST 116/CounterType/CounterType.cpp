/***********************************************************
* Author:			Matthew Klump
* Date Created:			November 26, 2001
* Last Modification Date:	November 26, 2001
* Project:			CounterType
* Filename:			CounterType.cpp
*
* Overview
*   Program to count the number of times the user enters
*	an odd number, after displaying the final count. The
*	program will enter a range of test values for the input.
*
*   This program decription is taken from "Problem Solving
*	with C++", Walter Savitch, p. 361 (project 4 Counting
*	Program Project)
* Input:
*   The user enters a whole number to check.
* Output:
*   The program outputs the number of time the user entered
*	an odd number, then outputs the count result after checking
*	each value for testing.
*
***********************************************************/

#include <iostream>
#include <cmath>
using namespace std;

class CounterType {
public:
	CounterType(short num);
	//initializes the member variable count to the number specified.

	CounterType();
	//initializes the member variable count to zero.

	void GetInput(short& usernumber);
	//Precondition: The user is prepared to correctly enter a number.
	//Postcondition: A number entered by the user is stored in usernumber.

	short UpdateCount(short usernumber);
	//Precondition: Accepts variable usernumber as input
	//Returns the updated count of odd numbers entered after checking
	//the count the count remains nonzero.

	void Output(ostream& outs);
	//Precondition: If outs is a file output stream, then outs has 
	//already been connected to a file.
	//Postcondition: The count of odd numbers has been written 
	//to the stream outs.

private:
	short count, x;
};

void main(void) {

	CounterType Counter1;
	Counter1 = CounterType(0);

	char ans;
	short number_got;

	do {
		Counter1.GetInput(number_got);
		Counter1.UpdateCount(number_got);
		Counter1.Output(cout);
		cout << "Press Y if your would like to enter\n"
			<< "another number to check: ";
		cin >> ans;
	} while (ans == 'Y' || ans == 'y');

	Counter1 = CounterType();
	
	/*This portion of code for testing still needs lots of work

	cout << "Press any key to enter the following\n"
		<< "nine test values for this program's input: \n"
		<< "-32769, -32768, -32766, 4, 5, 6, 32766, 32767, and 32768\n";
	short x = 0;
	while (x <= 9) {
		x += 1;
		if (x = 1)
			number_got = -32769;
		if (x = 2)
			number_got = -32768;
		if (x = 3)
			number_got = -32767;
		if (x = 4)
			number_got = 4;
		if (x = 5)
			number_got = 5;
		if (x = 6)
			number_got = 6;
		if (x = 7)
			number_got = 32766;
		if (x = 8)
			number_got = 32767;
		if (x = 9)
			number_got = 32768;
		Counter1.GetInput(number_got);
		Counter1.UpdateCount(number_got);
		Counter1.Output(cout);
	} */
}

CounterType::CounterType(short num) {

	count = num;
	x = num;
}

CounterType::CounterType() {

	count = 0;
}

void CounterType::GetInput(short& usernumber) {
	
	cout << "Please enter a number: ";
	cin >> usernumber;
}

short CounterType::UpdateCount(short usernumber) {

	if (usernumber % short(2.0))
		count += 1;
	else
		count -= 1;

	if (count < 0)
		count = 0;
	return count;
}

void CounterType::Output(ostream& outs) {

	outs.setf(ios::fixed);
	outs.setf(ios::showpoint);
	outs.precision(0);
	outs << "The total count of odd numbers is: "
		<< count << endl;
}