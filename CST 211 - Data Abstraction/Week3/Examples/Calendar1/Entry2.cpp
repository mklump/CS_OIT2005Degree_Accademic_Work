#include "StdAfx.h"
#include <iostream>
#include <string>
#include "Time.h"
#include "Entry2.h"

using namespace std;

Entry2::Entry2(const Time& t, string s)
: time(t)
{
	cout << "Constructor called for: " << s << endl;
	entry = s;
	count++;
}

Entry2::Entry2(int hr, int min, string s)
: time(hr, min, 0), entry(s)
{
	cout << "Constructor called for: " << s << endl;
	count++;
}

Entry2::~Entry2(void)
{
	cout << "Destructor called for: " << entry << endl;
	//Note: You do NOT need to delete entry
	//since it is of type string and not string*
	count--;
}

int Entry2::getCount() {
	return count;
}

int Entry2::count = 0;		//Note static members are initialized at file scope.

ostream& operator<< (ostream& output, const Entry2& e) {
	output << e.time << "\t" << e.entry;
	return output;
}
