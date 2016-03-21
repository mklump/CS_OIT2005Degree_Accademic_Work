//--------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #9
// Date Created:   August 22, 2002
// Last Change Date:  August 22, 2002
// Project:        Ordered List
// Filename:       test9.cpp
//
// Overview:  Test program for the operations in the Ordered List ADT
//     
//--------------------------------------------------------------------

#include "stdafx.h"
#include <iostream>
#include "listord.cpp"

using namespace std;

//--------------------------------------------------------------------
//
// Declaration for the list element class
//

class TestData
{
  public:

    void setKey ( int newKey )
        { keyField = newKey; }   // Set the key

    int key () const
        { return keyField; }     // Returns the key

  private:

    int keyField;                // Key for the element
};

//--------------------------------------------------------------------

void main()
{
    OrdList<TestData,int> testList(9);  // Test list
    TestData testElement;               // List element
    int inputKey;                       // User input key
    char cmd;                           // Input command

	do
    {
		cout << endl << "Commands:" << endl;
		cout << "  +key : Insert (or update) element" << endl;
		cout << "  ?key : Retrieve the element with the specified key"
		     << endl;
		cout << "  =key : Replace the element marked by the cursor"
		     << endl;
		cout << "  -    : Remove the element marked by the cursor"
		     << endl;
		cout << "  @    : Display the element marked by the cursor"
		     << endl;
		cout << "  <    : Go to the beginning of the list" << endl;
		cout << "  >    : Go to the end of the list" << endl;
		cout << "  N    : Go to the next element" << endl;
		cout << "  P    : Go to the prior element" << endl;
		cout << "  C    : Clear the list" << endl;
		cout << "  E    : Empty list?" << endl;
		cout << "  F    : Full list?" << endl;
		cout << "  Q    : Quit the test program" << endl;
		cout << endl;

        testList.showStructure();                     // Output list

        cout << endl << "Command: ";                  // Read command
        cin >> cmd;
        if ( cmd == '+'  ||  cmd == '='  ||  cmd == '?' )
           cin >> inputKey;

        switch ( cmd )
        {
          case '+' :                                  // insert
               testElement.setKey(inputKey);
               cout << "Insert : key = " << testElement.key()
                    << endl;
               testList.insert(testElement);
               break;

          case '?' :                                  // retrieve
               if ( testList.retrieve(inputKey,testElement) )
                  cout << "Retrieved : key = "
                       << testElement.key() << endl;
               else
                  cout << "Not found" << endl;
               break;

          case '=' :                                  // replace
               testElement.setKey(inputKey);
               cout << "Replace current element :"
                    << " key = " << testElement.key() << endl;
               testList.replace(testElement);
               break;

          case '-' :                                  // remove
               cout << "Remove current element" << endl;
               testList.remove();
               break;

          case '@' :                                  // getCursor
               cout << "Element marked by the cursor : key = "
                    << testList.getCursor().key() << endl;
               break;

          case '<' :                                  // gotoBeginning
               if ( testList.gotoBeginning() )
                  cout << "Go to beginning of list" << endl;
               else
                  cout << "Failed -- list is empty" << endl;
               break;

          case '>' :                                  // gotoEnd
               if ( testList.gotoEnd() )
                  cout << "Go to end of list" << endl;
               else
                  cout << "Failed -- list is empty" << endl;
               break;

          case 'N' : case 'n' :                       // gotoNext
               if ( testList.gotoNext() )
                  cout << "Go to next element" << endl;
               else
                  cout << "Failed -- either at end of list "
                       << "or list is empty" << endl;
               break;

          case 'P' : case 'p' :                       // gotoPrior
               if ( testList.gotoPrior() )
                  cout << "Go to the prior element" << endl;
               else
                  cout << "Failed -- either at beginning of list "
                       << "or list is empty" << endl;
               break;

          case 'C' : case 'c' :                       // clear
               cout << "Clear the list" << endl;
               testList.clear();
               break;

          case 'E' : case 'e' :                       // empty
               if ( testList.empty() )
                  cout << "List is empty" << endl;
               else
                  cout << "List is NOT empty" << endl;
               break;

          case 'F' : case 'f' :                       // full
               if ( testList.full() )
                  cout << "List is full" << endl;
               else
                  cout << "List is NOT full" << endl;
               break;

          case 'Q' : case 'q' :                   // Quit test program
               break;

          default :                               // Invalid command
               cout << "Invalid command" << endl;
        }
    }
    while ( ( cmd != 'Q' ) && ( cmd != 'q' ) );
}