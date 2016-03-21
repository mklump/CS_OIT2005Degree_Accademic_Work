//This is the Driver program.
//This demonstrates the use of class and function templates.
//It allows Entry objects of type string and of type double.

#include "stdafx.h"
#include "Time.h"
#include "Entry.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	//This section demonstrates allocation of string Entries on the stack.
	const Time t1(9, 15);
	Entry<string> fred (t1, "Meeting with Fred");	//Using the Template
	StringEntry jane (10, 15, "Meeting with Jane"); //typedef equivalent
	cout << fred << endl << jane << endl;
	Entry<string> copyOfFred (fred);				  //Uses the Copy Constructor
	//Entry<string> copyOfFred = fred;				  //Also uses the copy constructor
	cout << "The copy of Fred is: " << copyOfFred << endl;
	Entry<string> tina (18, 30, "Meeting with Tina");
	tina = jane;						      //Uses the overloaded assignment operator
	cout << "Tina after assignment from Jane: " << tina << endl;
	cout << "There are " << StringEntry::getCount() << " string entries." << endl;

	//This section demonstrates dynamic allocation on the heap.
	Entry<string>* entryPtr = new Entry<string> (14, 15, "Siesta");
	cout << *entryPtr << endl;
	cout << "Now there are " << Entry<string>::getCount() << " string entries." << endl;

	//This section demonstrates the use of Entries of type double.
	Entry<double> one (18, 0, 123.45);
	NumberEntry two (19, 30, 55.21);
	cout << "The value of one is: " << one << endl;
	cout << "The value of two is: " << two << endl;
	cout << "There are " << NumberEntry::getCount() << " number entries." << endl;

	delete entryPtr;		
	return 0;
}



