//-------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #3
// Date Created:   July 10, 2002
// Last Change Date:  July 10, 2002
// Project:        STRING
// Filename:       String.h
//
// Overview:	This include contains the interface for 
//				the array implementation of the String ADT
//     
//-------------------------------------------------------------------

#pragma once
#include <iostream>
using namespace std;

class String
{
  public:

    // Constructors
    String ( const int& numChars = 0 );     // Create an empty string
    String ( const char *charSeq );         // Initialize using char*

    // Destructor
    ~String ();

    // String operations
    int length () const;                             // number of characters
	char* getBuffer () const;						 // This buffer
    char operator[] ( int n ) const;                 // Subscript
    void operator = ( const String &rightString ) throw();// Assignment
    void clear ();                                   // Clear string

    // Output the string structure -- used in testing/debugging
    void showStructure () const;

    // In-lab operation
    String ( const String &valueString );          // Copy constructor

  private:
  // Data members
	int bufferSize;   // Size of the string
    char *buffer;     // String buffer containing a null-terminated c-string

  // Friends

  // String input/output operations (In-lab Exercise 1)
  friend istream& operator>> ( istream& input, String& inputString );

  friend ostream& operator<< ( ostream& output, const String& outputString );

  // Relational operations (In-lab Exercise 3)
  friend int operator == ( const String& leftString, const String& rightString );

  friend int operator < ( const String& leftString, const String& rightString );

  friend int operator > ( const String& leftString, const String& rightString );
};