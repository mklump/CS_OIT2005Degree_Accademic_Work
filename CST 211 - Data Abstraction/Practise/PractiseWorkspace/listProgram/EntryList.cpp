// EntryList.cpp : Demonstrates a Linked List of ints.
//

#include "stdafx.h"
#include "List.h"

int main(int argc, char* argv[])
{
	List<int> integerList;
	for (int i = 0; i < 100; i++) {
		integerList.push_front(i);
		integerList.push_back(i);
	}
	cout << "Front Element is: " << integerList.front() << endl;
	cout << "Back Element is: " << integerList.back() << endl;
	integerList.print();
	for (int i = 0; !integerList.empty(); i++) {
		int p, q;
		integerList.pop_front (p);
		integerList.pop_back (q);
		cout << i << "\t" << p << "\t" << q << endl;
	}
	integerList.print();
	return 0;
}

