/***********************************************************
* Author:			Matthew Klump
* Date Created:			December 1, 2001
* Last Modification Date:	December 1, 2001
* Project:			ReadNames
* Filename:			ReadNames.cpp
*
* Overview
*   Program to search a file of names for a specific key
*	name, and return that name to the screen as the name
*	found.
*
*   This program is Lab 4 for CST 116
* Input:
*   The program uses the file "names.dat" as input.
* Output:
*   The program displays to the screen the name being
*	searched for. If none exists, a message will diplay
*	that result.
***********************************************************/

#include <iostream>
#include <fstream>
#include <string>
using namespace std;

int Search(string key, string names[], int size);
//Precondition: Accept what to search for, the array
//of names to search, and the array size
//Returns the key if it exists in the array, returns -1 if not

void GetName(string& name);
//Precondition: The user is ready to correctly enter a string
 //name.
void OutPut(int& location);
//Postcondition: The location of the name found within the
//array is printed to the screen.

void main(void) {

	ifstream iFile("D:/CST 116 Work/ReadNames/names.dat");

	string names[8], name;

	int x=0, size = 8, location;

	while (iFile >> names[x] && x <= 7) {
		x++;
	};

	GetName(name);

	location = Search(name, names, size);
	
	OutPut(location);

	iFile.close();
}

int Search(string key, string names[], int size) {

	//size denotes number of elements, upper bound is one
	//less than size
	while (size > 0) {
		size--;
		if (names[size] == key) return size;
	};
	// key is not in values
	return -1;
}

void GetName(string& name) {
	cout << "Please enter a name to search for (some\n"
		<< "example names are charlie, mark, jill, matt, \n"
		<< "jeff, caroline, amy, and art): ";
	cin >> name;
}


void OutPut(int& location) {

	cout << "The location of name found within the array is: " << location << endl;
}