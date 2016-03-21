//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   March 2, 2002
// Last Change Date:  March 2, 2002
// Project:        Defining Colors
// Filename:       driver.cpp
//
// Overview:	This main part of this program is a driver that will
//				test the various functions and member data so defined
//				for the class Color.
//
// Input:		None
//   
// Output:		Lines of text displayed in a win32 console form.
//   
//--------------------------------------------------------------------

#include "colors.h"

void main()
{
	cout << "This will test the default constructor.\n";
	Color cl1, cl2;
	cout << cl1
		<< endl << cl2 << endl;
	cout << "This will test the three arguement constructor for "
		<< "black.\n";
	Color cl3(0, 0, 0), cl4(0, 0, 0);
	cout << cl3
		<< endl << cl4
		<< endl;
	cout << "This will test the three arguement constructor for "
		<< "various colors.\n";
	Color cl5(-24, 256, 784), cl6(45, 57, 26);
	cout << cl5
		<< endl << cl6
		<< endl;
	cout << "This will test the overloaded addition operator.\n";
	Color cl7(789, 98, 42), result;
	result = cl6 + cl7;
	cout << result
		<< endl;
	cout << "This will test the overloaded less than operator.\n";
	if (result < cl6)
		cout << result << endl;
	else
		cout << cl6 << endl;
	cout << "This will test the overloaded subtraction operator "
		<< "for dark colors.\n";
	Color cl8(245, 270, 23), cl9(201, 212, 794);
	result = cl8 - cl9;
	cout << result << endl;

	cout << "This will test the overloaded subtraction operator "
		<< "for light colors.\n";
	Color cl10(24, 242, 794), cl11(201, 222, 199);
	result = cl10 - cl11;
	cout << result << endl;

	cout << "This will test the overloaded less than operator "
		<< "again.\n";
	if (!(result < cl10))
		cout << result << endl;
	else
		cout << cl10 << endl;
}