//--------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #3
// Date Created:   July 15, 2002
// Last Change Date:  July 15, 2002
// Project:        STRING
// Filename:       STLstring.cpp
//
// Overview:	Test driver for the member methods and data of
//				the standard string class in the STL.
//
// Input:		Defined in the driver below.
//   
// Output:		All output of this test is sent to the std::out.
//
//--------------------------------------------------------------------

#include <iostream>
#include <fstream>
#include <string>

using namespace std;

//--------------------------------------------------------------------

int STLstringTest(void);			 // test routine
void dummy2 ( string copystring );   // copystring is passed by value
string inputFile();					 // Input function

//--------------------------------------------------------------------

int STLstringTest(void)
{
    string a("a"),                // Predefined test strings
           alp("alp"),
           alpha("alpha"),
           epsilon("epsilon"),
           empty,
           assignStr,          // Destination for assignment
           inputStr;		  // Input string
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
	        cout << alpha << endl;
            cout << "string: epsilon" << endl;
            cout << epsilon << endl;
            cout << "string: a" << endl;
            cout << a << endl;
            cout << "empty string" << endl;
            cout << empty << endl;
            break;

		case '2' :
	        // Test 2 : Tests the length operation.
	        cout << "Lengths of various strings:"  << endl;
            cout << " alpha   : " << static_cast<int>( alpha.length() ) << endl;
            cout << " epsilon : " << static_cast<int>( epsilon.length() ) << endl;
            cout << " a       : " << static_cast<int>( a.length() ) << endl;
			cout << " empty   : " << static_cast<int>( empty.length() ) << endl;
            break;

		case '3' :
            // Test 3 : Tests the subscript operation.
            cout << "Enter a subscript : ";
            cin >> n;
            ch = alpha.at(n);
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
            cout << assignStr << endl;
            cout << "assignStr = a" << endl;
            assignStr = a;
            cout << assignStr << endl;
            cout << "assignStr = empty" << endl;
            assignStr = empty;
            cout << assignStr << endl;
            cout << "assignStr = epsilon" << endl;
            assignStr = epsilon;
            cout << assignStr << endl;
            cout << "assignStr = assignStr" << endl;
            assignStr = assignStr;
            cout << assignStr << endl;
            cout << "assignStr = alpha" << endl;
            assignStr = alpha;
            cout << assignStr << endl;
            cout << "Clear assignStr" << endl;
            assignStr = "";
            cout << assignStr << endl;
            cout << "Confirm that alpha has not been cleared" << endl;
            cout << alpha << endl;
            break;

		case '5' :                                  // In-lab Exercise 2
        // Test 5 : Tests the copy constructor.
			cout << "Calls by value:" << endl;
			cout << "alpha before call" << endl;
            cout << alpha << endl;
            dummy2(alpha);
            cout << "alpha after call" << endl;
            cout << alpha << endl;
            cout << "a before call" << endl;
            cout << a << endl;
            dummy2(a);
            cout << "a after call" << endl;
			cout << a << endl;
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

		default :
			cout << "\nInactive or invalid test" << endl;
			break;
		}
	}
	return 0;
}

//--------------------------------------------------------------------

void dummy2 ( string copystring ) {

// Dummy routine that is passed a string using call by value. Outputs
// copystring and clears it.

	cout << "Copy of string: " << endl;
    cout << copystring << endl;
	cout << "Clear the copy, and show it: " << endl;
    copystring = "";
    cout << copystring << endl;
}

string inputFile()
{
	string input;
	cin.ignore();
	cin.clear();
	getline( cin, input );
	if( input == "" )
		input = "progsamp.dat";

	return input;
}