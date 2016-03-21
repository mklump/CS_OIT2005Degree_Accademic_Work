//--------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #9
// Date Created:   August 26, 2002
// Last Change Date:  August 26, 2002
// Project:        Ordered List
// Filename:       Exercise2&3-SetSTL.cpp
//
// Overview:  Test program that merges two sets, and checks for a set
//			  being a subset of another set Structure of the standard
//			  template library.
//     
//--------------------------------------------------------------------

#pragma warning(disable:4786)
#include <iostream>
#include <set>

using namespace std;

//--------------------------------------------------------------------

class TestData
{
  public:

	void setKey ( char newKey )
        { keyField = newKey; }   // Set the key

    char key () const
        { return keyField; }     // Returns the key

  private:

     char keyField;              // Key for the element
};

typedef set<char,less<char> > CharSet;

bool subset ( const CharSet &Set, const CharSet &subSet )
{
	int found = 0;
	CharSet::const_iterator pos2 = subSet.begin(),
							pos1 = Set.begin(),
							pos1End = Set.end();
	--pos1End;
	while( pos2 != subSet.end() )
	{
		if( pos1 == pos1End )
			++pos2;
		if( *pos1 == *pos2 )
			++found;
		++pos1;
	}
	if( found == subSet.size() - 1 )
		return true;
	else
		return false;
}

//--------------------------------------------------------------------

void main()
{
    CharSet testList1, testList2;	      // Test lists
                          
    TestData testElement;                 // List element
    char ch;                              // Input character

    cout << endl << "Enter first list of characters (no spaces) : ";
    cin.get(ch);
    while ( ch != '\n' )
    {
        testElement.setKey(ch);
        testList1.insert(testElement.key());
        cin.get(ch);
    }

    cout << endl << "Enter second list of characters (no spaces) : ";
    cin.get(ch);
    while ( ch != '\n' )
    {
        testElement.setKey(ch);
        testList2.insert(testElement.key());
        cin.get(ch);
    }

    cout << endl << "List 1 : " << endl;
	// print testList1
    copy(testList1.begin(),testList1.end(),
		 ostream_iterator<char>(cout," "));
    cout << endl << "List 2 : " << endl;
    copy(testList2.begin(),testList2.end(),
		 ostream_iterator<char>(cout," "));

	char input;
	cout << endl << "Please enter 'm' for the merge Lists test, 's'" << endl
				 << "for the sub-List test, or 'b' for both tests at" << endl
				 << "once, or q to quit";
	do
	{
		cout << endl << "Selection?: ";
		cin >> input;
		switch (input)
		{
		case 'm': case 'M':
			// Merge list 2 into list 1.
			
			copy(testList2.begin(),testList2.end(),
				 inserter(testList1,testList1.begin()));

			//testList1.insert(testList2.begin(), testList2.end());

			cout << endl << "After merge -- List 1 : " << endl;
			copy(testList1.begin(),testList1.end(),
				ostream_iterator<char>(cout," "));
			break;
		
		case 's': case 'S':
			// Check whether list 2 is a subset of list 1.
			cout << endl;
			if ( subset(testList1, testList2) )
				cout << "List 2 is a subset of list 1" << endl << endl;
			else
				cout << "List 2 is NOT a subset of list 1" << endl << endl;
			break;

		case 'b': case 'B':
			// Merge list 2 into list 1.
			
			copy(testList2.begin(),testList2.end(),
				 inserter(testList1,testList1.begin()));

			//testList1.insert(testList2.begin(), testList2.end());

			cout << endl << "After merge -- List 1 : " << endl;
			copy(testList1.begin(),testList1.end(),
				ostream_iterator<char>(cout," "));

			// Check whether list 2 is a subset of list 1.
			cout << endl;
			if ( subset(testList1, testList2) )
				cout << "List 2 is a subset of list 1" << endl;
			else
				cout << "List 2 is NOT a subset of list 1" << endl;
			break;
		}
	}
	while( input != 'q' && input != 'Q' );
}