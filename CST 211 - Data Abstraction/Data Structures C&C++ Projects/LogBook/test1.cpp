//--------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #1
// Date Created:   June 28, 2002
// Last Change Date:  June 28, 2002
// Project:        LogBook
// Filename:       test1.cpp
//
// Overview:	Test driver for the operations in the Logbook ADT
//
// Input:		Defined in the driver below.
//   
// Output:		All output of this test is lineafter to the screen.
//
//--------------------------------------------------------------------

#include <iostream>
#include "logbook.h"

using namespace std;

int main(int argc, char* argv[])
{
    int month,   // Input month
        year,    // Input year
        day,     // Input day
        entry,   // Input logbook entry
        dofm,    // Day of Month
        stop;    // Signals end of test
        /*j;*/       // Loop counter

    // Create a logbook (not used in Test 4).

    cout << endl << endl
         << "Enter the month and year for the logbook month : ";
    cin >> month >> year;
    Logbook testLog(month,year);

    // Test 1 : Tests the month, year, and daysInMonth operations.

	cout << "Month : " << testLog.getlogMonth() << endl;
	cout << "Year  : " << testLog.getlogYear() << endl;
	cout << "# days in month : " << testLog.daysInMonth(testLog.getlogMonth() ) << endl;

    // Test 2 : Tests the putEntry and getEntry operations.

    stop = 0;
    while ( !stop )
    {
        cout << endl << "Enter day and entry (0 0 to exit Test 2) : ";
        cin >> day >> entry;
        if ( day != 0  &&  entry != 0 )
        {
		   dofm = day;
		   testLog.putEntry(day,entry);
           cout << "Calendar for this Logbook:" << endl;
		   testLog.displayCalendar();
		   /*
		   for ( day = 1 ; day <= testLog.daysInMonth(testLog.getlogMonth() ) ; day++ )
           {
               cout << day << " " << testLog.getEntry(day) << '\t';
               if ( day % 5 == 0 )
                  cout << endl;
           } */
           cout << endl;
        }
        else
			stop = 1;
	}

    // Test 3 : Tests the calendar operation.

	cout << endl << "Testing the calendar operation" << endl;
	testLog.displayCalendar();
	cout << endl;

    // Test 4 : Tests the overloaded constructor and putEntry
    //        operations.

    Logbook thisMonth;
	cout << "\nTesting the default constructor and putEntry operations:";
    cout << endl << "Logbook for this month:" << endl;
	cout << "Month : " << thisMonth.getlogMonth() << endl;
	cout << "Year  : " << thisMonth.getlogYear() << endl;
	cout << "# days in month : " << thisMonth.daysInMonth(thisMonth.getlogMonth() ) << endl;

    thisMonth.putEntry(100);	//Insert a log entry for todays date.
	thisMonth.displayCalendar();
	/*
	for ( day = 1 ; day <= thisMonth.daysInMonth(thisMonth.getlogMonth() ) ; day++ )
    {
        cout << day << " " << thisMonth.getEntry(day) << '\t';
        if ( day % 5 == 0 )
            cout << endl;
    } */
    cout << endl << endl;

    // Test 5 : Tests the [] operation.

    cout << "Testing Overloaded [] operator:" << endl
		<< "Calendar for testLog: ";
	testLog.displayCalendar();
	/*
	for ( day = 1 ; day <= testLog.daysInMonth(testLog.getlogMonth() ) ; day++ )
    {
        cout << day << " " << testLog[day] << '\t';
        if ( day % 5 == 0 )
           cout << endl;
    } */
    cout << endl;

	// Test 6 : Tests the += operation.

	Logbook logDay100(month,year),
			logDay200(month,year);

	cout << endl
		 << "Loading logbooks logDay100 and logDay200." << endl
		 << "Testing overloaded operator += :" << endl;
	for ( day = 1 ; day <= logDay100.daysInMonth(logDay100.getlogMonth() ) ; day++ )
	{
		logDay100.putEntry(day,100*day);
		logDay200.putEntry(day,200*day);
	}

	logDay100 += logDay200;

	cout << "Calendar for Combined logbooks logDay100:" << endl;
	logDay100.displayCalendar();
	/*
	for ( day = 1 ; day <= logDay100.daysInMonth(logDay100.getlogMonth() ) ; day++ )
	{
	    cout << day << " " << logDay100.getEntry(day) << '\t';
		if ( day % 5 == 0 )
            cout << endl;
	} */
	cout << endl;

	while (cin.get() != 'q')
		cout << "Enter 'q' to exit: ";
	return 0;
}