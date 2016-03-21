/***********************************************************
* Author:			Sun Murthy
* Date Created:		Nov. 07, 2001
* Last Modification Date:	Nov. 07, 2001
* Project:			Classes
* Filename:			DateClass.cpp
*
* Overview
*   Defines Date class and demonstrates constructors
* Input:
*   None.
* Output:
*   Various diagnostics.
*
***********************************************************/
#include <iostream>
using namespace std;

class Date {
	unsigned short year, month, day;

	public:

	// default constructor
	// the date is Jan. 1, 1980 by default
	Date() {
		year = 1980; month = day = 1;
	}

	// copy constructor
	// the date is given by the parameter
	Date(const Date& dt) {
		year = dt.year; month = dt.month; day = dt.day;
	}

	// the initial date is supplied by the user
	Date(unsigned short y, unsigned short m, unsigned short d) {
		year = y; month = m; day = d;
	}

	// naive method of moving to next year
	void moveToNextYear() {
		year++;
	}

	//send formatted date to cout
	void print() {
		cout << month << '/' << day << '/' << year;
	}

};


/* This program creates instances of Date and prints them 
*/
void main(void){
	// create a defualt date
	Date defaultDate;
	cout << "Default date: ";
	defaultDate.print();
	cout << endl;
	
	// create a custom date
	Date customDate(2001, 11, 7);
	cout << "Custom date: ";
	customDate.print();
	cout << endl;

	//create a date from another date
	Date copiedDate(customDate);
	cout << "Copied date: ";
	copiedDate.print();
	cout << endl;
}
