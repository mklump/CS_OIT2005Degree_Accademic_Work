//-------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #9
// Date Created:   August 20, 2002
// Last Change Date:  August 20, 2002
// Project:        Ordered List
// Filename:       List.h
//
// Overview:	This include contains the interface for 
//				the List class.
//     
//-------------------------------------------------------------------

#pragma once
#include <iostream>
#include "stdafx.h"   // Other includes
using namespace std;

const int defMaxListSize = 10;   // Default maximum list size

template < class LE >
class List
{
  public:

    // Constructors
    List ( const int &maxNumber = defMaxListSize );
	List ( const List& source );

    // Destructor
    ~List ();

    // List manipulation operations
    virtual void insert ( const LE& newElement );	 // Insert after cursor
	virtual void replace ( const LE& newElement );   // Replace element
    void remove ();                          // Remove element @ cursor
    void clear ();                           // Clear list

    // List status operations
    int empty () const;                      // List is empty
    int full () const;                       // List is full

    // List iteration operations
    int gotoBeginning ();                    // Go to beginning
    int gotoEnd ();                          // Go to end
    int gotoNext ();                         // Go to next element
    int gotoPrior ();                        // Go to prior element
    LE getCursor () const;                   // Return element

    // Output the list structure -- used in testing/debugging
    virtual void showStructure () const = 0;

    // In-lab operation
    int find ( const LE& searchElement );   // Find element

  protected:

    // Data members
    int maxSize,   // Maximum number of elements in the list
        size,      // Actual number of elements in the list
        cursor;    // Cursor array index
    LE* element;   // Array containing the list elements
};
