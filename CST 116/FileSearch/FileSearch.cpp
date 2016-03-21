/***********************************************************
* Author:			Matthew Klump
* Date Created:			November 27, 2001
* Last Modification Date:	November 27, 2001
* Project:			CounterType
* Filename:			CounterType.cpp
*
* Overview
*   Program to search a file of numbers of type int and write
*	the largest and smallest numbers to the screen. The file
*	contains nothing but numbers of type int separated by blanks
*	or line breaks.
*
*   This program decription is taken from "Problem Solving
*	with C++", Walter Savitch, p. 291 (project 1
*	Program Project)
* Input:
*   The program take a file called "numbers.txt" as input
* Output:
*   The program outputs the largest and the smallest numbers
*	to the screen.
*
***********************************************************/

#include <iostream>
#include <fstream>
using namespace std;

void main(void){

	ifstream iFile("D:/CST 116 Work/FileSearch/numbers.txt"); 
	double large, small, x;
	
	iFile >> x;

	large = small = x;

	while (iFile >> x) {
	
		if (x > large)
			large = x;

		if (x < small)
			small = x;
	}
		cout << "The smallest of these numbers is: " << small << endl
			<< "The largest of these numbers is: " << large << endl;
	iFile.close();
}

/*Solution:
ifstream infile("C:\\input.dat");
int large, small, n;
infile >> n;
large = small = n;
while (infile >> n) {
	if(n > large) large = n;
	if(n < small) small = n;
}
cout << "Output Statement";  */