//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #3 Part 1
// Date Created:   May 3, 2002
// Last Change Date:  May 3, 2002
// Project:        PairQueue
// Filename:       driver.cpp
//
// Overview:	This program is meant to practise writing a program
//				using templates, and to demonstrate the use of a
//				queue.
//
// Input:		All input for this program is provided by the driver
//				program.
//   
// Output:		All output is printed to the form.
//
//--------------------------------------------------------------------

#include <string>
#include "CPairQueue.h"

int main()
{
	int s;
	cout << "Please enter the size of the queue: size = ? > ";
	cin >> s;
	cout << endl;
	CPairQueue< int > intQueueArray( s ); cout << endl;
	cout << "\nPushing elements onto intQueueArray\n";
	
	int i1 = 3 , i2 = 5;

	while ( intQueueArray.Push(i1, i2) )  // successful if true returned
	{
		i1 += 2;
		i2 += 2;
	}
	intQueueArray.Display();
	cout << "\n\nThe queues are full. Cannot push " << i1 << " and " << i2 << '.'
        << "\n\nPopping elements from intQueueArray\n";
	
	intQueueArray.ResetTopPointer();

	while ( intQueueArray.Pop( i1, i2 ) )
	{
		cout << " ( " << i1 << ' ' << i2 << " ) ";
	}
	cout << "\n\nThe queues are empty. Cannot pop\n";
	char ret=0; cout << "Press Enter: ";
	cin.get(ret); cin.get(ret);
//
	cout << endl;
	CPairQueue< float > floatQueueArray( s ); cout << endl;
	cout << "\nPushing elements onto floatQueueArray\n";

	float f1 = float(3.3), f2 = float(5.5);

	while ( floatQueueArray.Push(f1, f2) )  // successful if true returned
	{
		f1 += float(1.2);
		f2 += float(1.2);
	}
	floatQueueArray.Display();
	cout << "\n\nThe queues are full. Cannot push " << f1 << " and " << f2 << '.'
        << "\n\nPopping elements from floatQueueArray\n";
	
	floatQueueArray.ResetTopPointer();

	while ( floatQueueArray.Pop( f1, f2 ) )
	{
		cout << " ( " << f1 << ' ' << f2 << " ) ";
	}
	cout << "\n\nThe queues are empty. Cannot pop\n"
		<< "Press Enter: "; cin.get(ret); cout << endl;
//
	CPairQueue< char > charQueueArray( s ); cout << endl;
	cout << "\nPushing elements onto charQueueArray\n";

	char c1 = 'a', c2 = 'b';

	while ( charQueueArray.Push(c1, c2) )  // successful if true returned
	{
		c1 += 2;
		c2 += 3;
	}
	charQueueArray.Display();
	cout << "\n\nThe queues are full. Cannot push " << c1 << " and " << c2 << '.'
        << "\n\nPopping elements from charQueueArray\n";
	
	charQueueArray.ResetTopPointer();

	while ( charQueueArray.Pop( c1, c2 ) )
	{
		cout << " ( " << c1 << ' ' << c2 << " ) ";
	}
	cout << "\n\nThe queues are empty. Cannot pop\n"
		<< "Testing DisplayN() : \n";
//
	intQueueArray.DisplayN( 0 ); cout << endl;
	floatQueueArray.DisplayN( 1 ); cout << endl;
	charQueueArray.DisplayN( 2 ); cout << endl;

	cout << "Press Enter: "; cin.get(ret);
	cout << "\nNow testing the remaining functions for CPairQueue: \n"
		<< "Testing Clear() : \n";
	
	intQueueArray.Clear();
	intQueueArray.Display();

	cout << "\nTesting ClearN() : ";

	charQueueArray.ClearN(2);
	charQueueArray.DisplayN(2);

	cout << endl;

	//Your driver should test each of the functions 
	//listed above for integer, float, and char types.

	return 0;
}