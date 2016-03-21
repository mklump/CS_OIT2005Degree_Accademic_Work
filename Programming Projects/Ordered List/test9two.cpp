//--------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #9
// Date Created:   August 22, 2002
// Last Change Date:  August 22, 2002
// Project:        Ordered List
// Filename:       test9two.cpp
//
// Overview:  Test program for the operations in the Ordered List ADT
//			  that manipulate two lists.
//     
//--------------------------------------------------------------------

#include "stdafx.h"
#include <iostream>
#include "listord.cpp"

using namespace std;

//--------------------------------------------------------------------

class TestData
{
  public:

    void setkey ( char newKey )
        { keyField = newKey; }   // Set the key

    char key () const
        { return keyField; }     // Returns the key

  private:

     char keyField;              // Key for the element
};

//--------------------------------------------------------------------

void main()
{
    OrdList<TestData,char> testList1(9),  // Test lists
                           testList2(9);
    TestData testElement;                 // List element
    char ch;                              // Input character

    cout << endl << "Enter first list of characters (no spaces) : ";
    cin.get(ch);
    while ( ch != '\n' )
    {
        testElement.setkey(ch);
        testList1.insert(testElement);
        cin.get(ch);
    }

    cout << endl << "Enter second list of characters (no spaces) : ";
    cin.get(ch);
    while ( ch != '\n' )
    {
        testElement.setkey(ch);
        testList2.insert(testElement);
        cin.get(ch);
    }

    cout << endl << "List 1 : " << endl;
    testList1.showStructure();
    cout << endl << "List 2 : " << endl;
    testList2.showStructure();

	char input;
	cout << endl << "Please enter m for the merge Lists test," << endl
				 << "s for the sub-List test, or b for both tests at" << endl
				 << "once, or q to quit" << endl;
	do
	{
		cout << "Selection?: ";
		cin >> input;
		switch (input)
		{
		case 'm': case 'M':
			// Merge list 2 into list 1.
			testList1.merge(testList2);
			cout << endl << "After merge -- List 1 : " << endl;
			testList1.showStructure();
			break;
		
		case 's': case 'S':
			// Check whether list 2 is a subset of list 1.
			cout << endl;
			if ( testList1.subset(testList2) )
				cout << "List 2 is a subset of list 1" << endl << endl;
			else
				cout << "List 2 is NOT a subset of list 1" << endl << endl;
			break;

		case 'b': case 'B':
			// Merge list 2 into list 1.
			testList1.merge(testList2);
			cout << endl << "After merge -- List 1 : " << endl;
			testList1.showStructure();
			// Check whether list 2 is a subset of list 1.
			cout << endl;
			if ( testList1.subset(testList2) )
				cout << "List 2 is a subset of list 1" << endl;
			else
				cout << "List 2 is NOT a subset of list 1" << endl;
			break;
		}
	}
	while( input != 'q' && input != 'Q' );

}