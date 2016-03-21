//This is the Driver program.
//This demonstrates:
//   a) The use of composition - An Entry contains a Time.
//   b) The use of new and delete - the heap versus the stack.
//   c) The use of static class variables.
//   d) The use of old style strings - char*
//	 e) The use of STL strings - in the Entry2 class.  (see Josuttis Ch 11).

#include "stdafx.h"
#include "Time.h"
#include "Entry.h"
#include <iostream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	//This section demonstrates allocation of Entries on the stack.
	const Time t1(9, 15);
	Entry fred (t1, "Meeting with Fred");
	Entry jane (10, 15, "Meeting with Jane"); //Uses the overloaded constructor
	cout << fred << endl << jane << endl;
	Entry copyOfFred (fred);				  //Uses the Copy Constructor
	//Entry copyOfFred = fred;				  //Also uses the copy constructor
	cout << "The copy of Fred is: " << copyOfFred << endl;
	Entry tina (18, 30, "Meeting with Tina");
	tina = jane;						      //Uses the overloaded assignment operator
	cout << "Tina after assignment from Jane: " << tina << endl;
	cout << "There are " << Entry::getCount() << " entries." << endl;

	//This section demonstrates dynamic allocation on the heap.
	Entry* entryPtr = new Entry (14, 15, "Siesta");
	cout << *entryPtr << endl;
	cout << "Now are " << Entry::getCount() << " entries." << endl;
	delete entryPtr;		//You must "delete" everything you "new".
							//otherwise you'll get a memory leak.
	cout << "Finally there are " << Entry::getCount() << " entries." << endl;
	return 0;
}



