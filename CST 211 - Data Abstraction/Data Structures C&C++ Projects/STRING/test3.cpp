//--------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #3
// Date Created:   July 15, 2002
// Last Change Date:  July 15, 2002
// Project:        STRING
// Filename:       test3.cpp
//
// Overview:	Test driver for the member methods and data of
//				the String class.
//
// Input:		Defined in the driver below.
//   
// Output:		All output of this test is sent to the std::out.
//
//--------------------------------------------------------------------

#include <iostream>
#include <fstream>
#include "String.h"
#include "STLstring.h"

using namespace std;

//--------------------------------------------------------------------
//
//  Function prototype

void dummy ( String copyString );   // copyString is passed by value
string inputFile2();					// Input function

//--------------------------------------------------------------------

int main(int argc, char* argv[])
{
    String a("a"),                // Predefined test strings
           alp("alp"),
           alpha("alpha"),
           epsilon("epsilon"),
           empty,
           assignStr(5),          // Destination for assignment
           inputStr(56);		  // Input string
	ifstream iFile;				  // Input file stream
    int n,						  // Input subscript
		count = 0;				  // Tokenize count variable
    char ch,                      // Character specified by subscript
         selection = ' ';         // Input test selection

	while ( selection != 0 )
	{

		// Get user test selection.

		cout << endl << "Tests:" << endl;
		cout << "  1  Tests the constructors" << endl;
		cout << "  2  Tests the length operation" << endl;
		cout << "  3  Tests the subscript operation" << endl;
		cout << "  4  Tests the assignment and clear operations" << endl;
		cout << "  5  Tests the copy constructor         (Active : "
			 << "In-lab Exercise 2)" << endl;
		cout << "  6  Tests the relational operations    (Active : "
			 << "In-lab Exercise 3)" << endl;
		cout << "  7  Tokenize a C++ file test program progsamp.dat" << endl;
		cout << "  8  Run test3.cpp for the class string STL" << endl;
		cout << "Select the test to run or 0 to exit : ";
		cin >> selection;

		// Execute the selected test.

		cout << endl;
		switch ( selection )
		{
		case '0' :
			cout << endl << "Exiting test program" << endl;
			return 0;
		case '1' :
	        // Test 1 : Tests the constructors.
	        cout << "Structure of various strings: " << endl;
	        cout << "string: alpha" << endl;
	        alpha.showStructure();
            cout << "string: epsilon" << endl;
            epsilon.showStructure();
            cout << "string: a" << endl;
            a.showStructure();
            cout << "empty string" << endl;
            empty.showStructure();
            break;

		case '2' :
	        // Test 2 : Tests the length operation.
	        cout << "Lengths of various strings:"  << endl;
            cout << " alpha   : " << alpha.length() << endl;
            cout << " epsilon : " << epsilon.length() << endl;
            cout << " a       : " << a.length() << endl;
            cout << " empty   : " << empty.length() << endl;
            break;

		case '3' :
            // Test 3 : Tests the subscript operation.
            cout << "Enter a subscript : ";
            cin >> n;
            ch = alpha[n];
            cout << "  alpha[" << n << "] : ";
            if ( ch == '\0' )
		       cout << "\\0" << endl;
            else
               cout << ch << endl;
            break;

		case '4' :
            // Test 4 : Tests the assignment and clear operations.
            cout << "Assignments:" << endl;
            cout << "assignStr = alpha" << endl;
            assignStr = alpha;
            assignStr.showStructure();
            cout << "assignStr = a" << endl;
            assignStr = a;
            assignStr.showStructure();
            cout << "assignStr = empty" << endl;
            assignStr = empty;
            assignStr.showStructure();
            cout << "assignStr = epsilon" << endl;
            assignStr = epsilon;
            assignStr.showStructure();
            cout << "assignStr = assignStr" << endl;
            assignStr = assignStr;
            assignStr.showStructure();
            cout << "assignStr = alpha" << endl;
            assignStr = alpha;
            assignStr.showStructure();
            cout << "Clear assignStr" << endl;
            assignStr.clear();
            assignStr.showStructure();
            cout << "Confirm that alpha has not been cleared" << endl;
            alpha.showStructure();
            break;

		case '5' :                                  // In-lab Exercise 2
        // Test 5 : Tests the copy constructor.
			cout << "Calls by value:" << endl;
			cout << "alpha before call" << endl;
            alpha.showStructure();
            dummy(alpha);
            cout << "alpha after call" << endl;
            alpha.showStructure();
            cout << "a before call" << endl;
            a.showStructure();
            dummy(a);
            cout << "a after call" << endl;
			a.showStructure();
		break;

		case '6' :                                  // In-lab Exercise 3
        // Test 6 : Tests the relational operations.
			cout << "  left     right     <   ==   > " << endl;
			cout << "--------------------------------" << endl;
			cout << " alpha    epsilon    " << (alpha<epsilon)
			     << "    " << (alpha==epsilon) << "   "
			     << (alpha>epsilon) << endl;
			cout << " epsilon   alpha     " << (epsilon<alpha)
				 << "    " << (epsilon==alpha) << "   "
                 << (epsilon>alpha) << endl;
			cout << " alpha     alpha     " << (alpha<alpha) << "    "
                 << (alpha==alpha) << "   " << (alpha>alpha) << endl;
			cout << "  alp      alpha     " << (alp<alpha) << "    "
                 << (alp==alpha) << "   " << (alp>alpha) << endl;
			cout << " alpha      alp      " << (alpha<alp) << "    "
                 << (alpha==alp) << "   " << (alpha>alp) << endl;
			cout << "   a       alpha     " << (a<alpha) << "    "
                 << (a==alpha) << "   " << (a>alpha) << endl;
			cout << " alpha       a       " << (alpha<a) << "    "
                 << (alpha==a) << "   " << (alpha>a) << endl;
			cout << " empty     alpha     " << (empty<alpha) << "    "
                 << (empty==alpha) << "   " << (empty>alpha) << endl;
			cout << " alpha     empty     " << (alpha<empty) << "    "
                 << (alpha==empty) << "   " << (alpha>empty) << endl;
			cout << " empty     empty     " << (empty<empty) << "    "
			     << (empty==empty) << "   " << (empty>empty) << endl;
		 break;
		case '7' :
			cout << "Please enter the file for which to read back as tokens: ";
			cout << endl;
			iFile.open( inputFile().c_str() );
			while ( iFile >> inputStr )
			{
				count++;
				cout << count << " : " << inputStr << endl;
			}
			count = 0;
			iFile.clear(); //Clear all iosflags including EOF
			iFile.close();
			break;
		case '8' :
			cout << "\nNow running same tests for class string in the STL: \n";
			STLstringTest();
			break;

		default :
			cout << "\nInactive or invalid test" << endl;
			break;
		}
	}
}

//--------------------------------------------------------------------

void dummy ( String copyString ) {

// Dummy routine that is passed a string using call by value. Outputs
// copyString and clears it.

	cout << "Copy of string: " << endl;
    copyString.showStructure();
	cout << "Clear the copy, and show it: " << endl;
    copyString.clear();
    copyString.showStructure();
}

string inputFile2()
{
	string input;
	cin.ignore();
	cin.clear();
	getline( cin, input );
	if( input == "" )
		input = "progsamp.dat";

	return input;
}