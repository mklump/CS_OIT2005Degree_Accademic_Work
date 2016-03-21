//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #5
// Date Created:   May 17, 2002
// Last Change Date:  May 17, 2002
// Project:        SocratesExams
// Filename:       main.cpp
//
// Overview:	This program is meant to practise file I/O and an options
//				driven menu
//
// Input:		User prompted questions and selections on the console
//				display.
//   
// Output:		All output is printed to the form and/or to the file
//				socrates.log
//
//--------------------------------------------------------------------

#include "person.h"

int main( void )
{
	int errorCount=0;
	CPerson *person;
	person = new CPerson;

	//Exercise #1 "Person Overload" Part 1
	person->SetName("??Dom Virgilio??");
	person->SetAge(42);
	ostream outGoing = cout;

	if(!outGoing)
	{
		cerr << "This ostream outGoing IS NOT out going!! Aborting ...";
		clog << "Total homeboyishness is " << ++errorCount;
		exit(1);
	}
	outGoing << person << endl << endl;

	//Exercise #2 "Person Overload" Part 2
	CPerson Matt("Matt", 28);

	// testing the assignment operator
	CPerson Matt2;
	Matt2 = Matt; 
	outGoing << Matt2 << endl;

	// testing the equality operator
	CPerson Jill("Jill", 27);
	if (Matt == Jill)
		outGoing << "Matt equals Jill" << endl;
	if (Matt == Matt2)
		outGoing << "Matt equals Matt2" << endl;

	// testing the inequality operator
	if (Matt != Jill)
		outGoing << "Matt does not equal Jill" << endl;
	if (Matt != Matt2)
		outGoing << "Matt does not equal Matt2" << endl;

	//Exercise #3 "Person Overload" Part 3
	CPerson john("John", 50);
	CPerson jack;

	//testing the not operator
	if (!john)
		outGoing << "Age and Name are defined for john" << endl;
	if (!jack)
		outGoing << "Age &/or Name are not defined for jack" << endl;

	//Exercise #4 "Person Overload" Part 4
	//Using CPerson, now implement conversion constructors to support:

	//testing the int cast operator
	outGoing << "John's Age = " << (int)john << endl;
	//testing the char * cast operator
	outGoing << "John's Name = " << (char *)john << endl;

	delete person;

	time_t ltime;
	time( &ltime );
	outGoing << "\nThis file " << __FILE__ << " last complied on " 
		 << __DATE__ << ' ' << __TIME__ << endl
		 << "\nThe run time is " << ctime( &ltime ) << endl;
	return 0;
}

