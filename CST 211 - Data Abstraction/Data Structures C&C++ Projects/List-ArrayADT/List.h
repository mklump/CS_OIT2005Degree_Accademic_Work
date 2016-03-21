//-------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #4
// Date Created:   July 20, 2002
// Last Change Date:  July 20, 2002
// Project:        List-ArrayADT
// Filename:       List.h
//
// Overview:	This include contains the interface for 
//				the List class.
//     
//-------------------------------------------------------------------

#pragma once
#include <iostream>
using namespace std;

const int defMaxListSize = 10;   // Default maximum list size

template < class LE >
class List
{
  public:

    // Constructor
    List ( int maxNumber = defMaxListSize );

    // Destructor
    ~List ();

    // List manipulation operations
    void insert ( const LE& newElement );	 // Insert after cursor
    void remove ();                          // Remove element
    void replace ( const LE& newElement );   // Replace element
    void clear ();                           // Clear list
	void append ( LE& newElement );			 // Add new ending element to list
	void insertBeginning ( LE& newElement ); // Insert new beginning element

    // List status operations
    int empty () const;                      // List is empty
    int full () const;                       // List is full

    // List iteration operations
    int gotoBeginning ();                    // Go to beginning
    int gotoEnd ();                          // Go to end
    int gotoNext ();                         // Go to next element
    int gotoPrior ();                        // Go to prior element
    LE getCursor () const;                   // Return element

	void operator = ( const List& rightList );
	
    // Output the list structure -- used in testing/debugging
    void showStructure () const;

    // In-lab operations
    void moveToNth ( int n );                // Move element to pos. n
    int find ( const LE& searchElement );    // Find element

  private:

    // Data members
    int maxSize,   // Maximum number of elements in the list
        size,      // Actual number of elements in the list
        cursor;    // Cursor array index
    LE* element;   // Array containing the list elements
};

#include "List.cpp"   // To successfully compile the template definitions
#include "stdafx.h"   // Other includes