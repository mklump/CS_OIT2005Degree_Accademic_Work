#include "StdAfx.h"
#include <iostream>
#include "Time.h"
#include "entry.h"

using namespace std;

Entry::Entry(const Time& t, const char* s)
: time(t)
{
	cout << "Constructor called for: " << s << endl;
	entry = new char[strlen(s) + 1];
	strcpy(entry, s);
	count++;
}

Entry::Entry(int hr, int min, const char* s)
: time(hr, min, 0)
{
	cout << "Constructor called for: " << s << endl;
	entry = new char[strlen(s) + 1];
	strcpy(entry, s);
	count++;
}

//This is the copy constructor
Entry::Entry(const Entry& e)
{
	cout << "Copy Constructor called to copy: " << e << endl;
	time = e.time;
	entry = new char[strlen(e.entry) + 1];
	strcpy(entry, e.entry);
	count++;
}

//This is the overloaded assignment operator
Entry& Entry::operator= (const Entry& e)
{
	time = e.time;
	delete [] entry;		//Return existing string to the heap.
	entry = new char[strlen(e.entry) + 1];
	strcpy(entry, e.entry);
	return *this;			//enables t1 = t2 = t;
}

Entry::~Entry(void)
{
	cout << "Destructor called for: " << entry << endl;
	delete [] entry;		//MUST reclaim this space on the heap!!!
	count--;
}

int Entry::getCount() {
	return count;
}

int Entry::count = 0;		//Note static members are initialized at file scope.

ostream& operator<< (ostream& output, const Entry& e) {
	output << e.time << "\t" << e.entry;
	return output;
}
