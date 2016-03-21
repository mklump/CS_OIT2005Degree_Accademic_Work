// EntryList2.cpp : Demonstrates a Linked List of Entries.
//

#include "stdafx.h"
#include "Time.h"
#include "Entry.h"
#include "List.h"


int main(int argc, char* argv[])
{
	List<StringEntry> entryList;
	StringEntry jill (12, 30, "Lunch with Jill");
	StringEntry fred (15, 30, "Meeting with Fred");
	entryList.push_front(jill);
	entryList.push_front(fred);
	cout << "Front Element is: " << entryList.front() << endl;
	cout << "Back Element is: " << entryList.back() << endl;
	entryList.print();
	for (int i = 0; !entryList.empty(); i++) {
		StringEntry p;
		entryList.pop_front (p);
		cout << i << "\t" << p << endl;
	}
	entryList.print();
	return 0;
}
