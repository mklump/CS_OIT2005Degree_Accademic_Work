//-------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #1
// Date Created:   June 28, 2002
// Last Change Date:  June 28, 2002
// Project:        LogBook
// Filename:       Logbook.h
//
// Overview:  This include contains the interface for the
//			  Logbook class.
//     
//-------------------------------------------------------------------

#ifndef LOGBOOK_H
#define LOGBOOK_H

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class Logbook
{
public:
	Logbook(const int& year, const int& month);
	//Creates and initializes a logbook of the
	//month specified by the year and the month.
	Logbook();
	//Default Constructor
	~Logbook();
	//Destructor

	int operator [] (int& day) const;
	//Overloaded Subscript Operator
	Logbook* operator += (const Logbook& rightBook);
	//Overloaded += Operator

	void putEntry(const int& day, const int& value);
	//Requires that day is <= the number of days in the logbook month.
	//Postcondition: Stores the value(s) as the logbook entry for the specified day.
	void putEntry(const int& value);
	//Same as the last method with one integer value.
	int getEntry(int day) const;
	//Requires that day is <= the number of days in the logbook month.
	//Returns the logbook entry for the specified day.

	inline int getlogMonth() const {return logMonth;}
	inline int getlogYear() const {return logYear;}

	int daysInMonth(int month) const;
	//Method that returns the days in a given month.
	int daysToMonth() const;
	//Returns the number of days from 1st of Jan to the 1st of logMonth
	void displayCalendar() const;
	//Uses daysInMonth() and dayOfWeek(int& day) to display calendar year

private:
	int logMonth,
		logYear,
		entry[32];

	void dayOfWeek(int day, int DayOfWeek) const;
	//Helper method for printing the monthly calendar
	bool isLeapYear() const;
	//Helper method for determining the if logYear is a leap year.
};

#endif //LOGBOOK_H