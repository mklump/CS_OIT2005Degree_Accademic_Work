//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   June 28, 2002
// Last Change Date:  June 28, 2002
// Project:        Logbook
// Filename:       Logbook.cpp
//
// Overview:  This include contains the implentation of the
//			  Logbook class.
//     
//--------------------------------------------------------------------

#include <iostream>
#include <iomanip>
#include <time.h>
#include "Logbook.h"

using namespace std;

Logbook::Logbook(const int &month, const int &year)
{
	logMonth = (month >= 1 && month <= 12) ? month : 1;
	logYear = (year >= 1901 && year <= 2099) ? year : 1901;
	int ldays = daysInMonth(logMonth);
	for (int day=1; day <= ldays; day++)
		entry[day] = 0;
}

Logbook::Logbook()
{
	time_t* ltime = new time_t;
	struct tm* thistime;
    time(ltime);					    // Get OS date and time
    thistime = localtime(ltime);		// Convert to numbers we can see
	
	logYear = thistime->tm_year + 1900;	// Current time components are now available
	logMonth = thistime->tm_mon + 1;    // through pointer thistime as a string.

	int ldays = daysInMonth(logMonth);
	for (int day=1; day <= ldays; day++)
		entry[day] = 0;
}

Logbook::~Logbook()
{
	cout << "\nCalling Destructor\n";
}

int Logbook::operator [] (int& day) const
{
	int ltemp = this->entry[day];
	return ltemp;
}

Logbook* Logbook::operator += (const Logbook& rightBook)
{
	Logbook* leftBook = this;
	int ldays = daysInMonth(logMonth);
	for(int day=1; day <= ldays; day++)
		leftBook->entry[day] += rightBook.entry[day];
	return leftBook;
}

void Logbook::putEntry(const int& day, const int& value)
{
	if(!(day >= 1 && day <= daysInMonth(logMonth) ) )
		cout << "\nDAY OUT OF RANGE ERROR\n";
	this->entry[day] = value;
}

void Logbook::putEntry(const int& value)
{
	struct tm* thistime;
	time_t ltime;
	time( &ltime );						// Get OS date and time
	thistime = localtime( &ltime );		// Convert time to struct tm form */
	
	int day = thistime->tm_mday;		// Current time components are now available
										// through pointer thistime as a string.
	this->entry[day] = value;
}

int Logbook::getEntry(int day) const
{
	if(!(day >= 1 && day <= daysInMonth(logMonth) ) )
		cout << "\nDAY OUT OF RANGE ERROR\n";
	return entry[day];
}

bool Logbook::isLeapYear() const
{
	if( logYear % 4 == 0 )
		return true;
	else
		return false;
}

int Logbook::daysToMonth() const
{
	int DaysToMonth = 0;
	if( isLeapYear() )
		DaysToMonth = 366;
	else
		DaysToMonth = 365;

	for(int month = 12; month >= logMonth; month-- )
        DaysToMonth -= daysInMonth(month);

	return DaysToMonth;
}

void Logbook::dayOfWeek(int day, int DayOfWeek) const
{
	switch (DayOfWeek)
	{
	case 0:
		if ( day == 7 || day == 14 || day == 21 || day == 28 )
			cout << endl;
		break;
	case 1:
		if ( day == 6 || day == 13 || day == 20 || day == 27)
			cout << endl;
		break;
	case 2:
		if ( day == 5 || day == 12 || day == 19 || day == 26 )
			cout << endl;
		break;
	case 3:
		if ( day == 4 || day == 11 || day == 18 || day == 25 )
			cout << endl;
		break;
	case 4:
		if ( day == 3 || day == 10 || day == 17 || day == 24 )
			cout << endl;
		break;
	case 5:
		if ( day == 2 || day == 9 || day == 16 || day == 23 )
			cout << endl;
		break;
	case 6:
		if ( day == 1 || day == 8 || day == 15 || day == 22 || day == 29)
			cout << endl;
		break;
	default:
		break;
	}
}

void Logbook::displayCalendar() const
{
	int nYears = logYear - 1901,
		nLeapYears = int(nYears / 4),
		nDaysToMonth = daysToMonth(),
		dayNum = 1;
		if (logMonth == 11)
			dayNum++;
	int DayOfWeek = ( 1 + nYears + nLeapYears + nDaysToMonth + dayNum ) % 7;
	
	cout << "Displaying Calendar:\n"
		<< resetiosflags( ios::left ) << setw(28) << logMonth << " / " << logYear << endl
		 << "  Sun      Mon      Tue      Wed      Thu      Fri      Sat  \n";
	
	for (int day=1; day <= daysInMonth(logMonth); day++ )
	{
		if( day == 1 )
		{
			for(int loop=0; loop < DayOfWeek; loop++)
				cout << "         ";
		}
		cout << setw(3) << resetiosflags(ios::left) << day << ' '
			 << setw(5) << setiosflags(ios::left) << getEntry(day);
		dayOfWeek(day, DayOfWeek);
	}
	cout << endl;
}

int Logbook::daysInMonth(int month) const
{
	int ltemp = 0;
	switch (month)
	{
	case 1:
		return ltemp = 31;
	case 2:
		if( isLeapYear() )
			return ltemp = 29;
		else
			return ltemp = 28;
	case 3:
		return ltemp = 31;
	case 4:
		return ltemp = 30;
	case 5:
		return ltemp = 31;
	case 6:
		return ltemp = 30;
	case 7:
		return ltemp = 31;
	case 8:
		return ltemp = 31;
	case 9:
		return ltemp = 30;
	case 10:
		return ltemp = 31;
	case 11:
		return ltemp = 30;
	case 12:
		return ltemp = 31;
	default:
		return ltemp;
	}
}