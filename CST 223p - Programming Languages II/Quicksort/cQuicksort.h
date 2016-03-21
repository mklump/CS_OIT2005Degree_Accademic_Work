//--------------------------------------------------------------------
// Author:         Matthew Klump
//				   CST 223 Programming Languages II
//				   C++ Assignment
// Date Created:   May 31, 2002
// Last Change Date:  May 31, 2002
// Project:        Quicksort
// Filename:       cQuicksort.h
//
// Overview:  This include contains the interface of the
//			  cQuicksort class.
// Purpose:   To perform a quicksort on a small set of unsorted
//			  data of no particular data type.
//
//--------------------------------------------------------------------

#pragma once

#include <iostream>
#include <algorithm>
using namespace std;

#define DEFAULT_SIZE 256

template <class LE>
class cQuicksort
{
public:

	inline cQuicksort(const int& iSize = DEFAULT_SIZE);

	inline virtual ~cQuicksort(void);

	void Read_File(const char* file_name); // Read the contents of source file into Tarray

	void Sort_File(const int& left, const int& right); // Quicksort the contents of Tarray

	void Print_File(const char* file_name); // Print the contents of Tarray to the screen

	int get_Size(void) { return size; }
	void set_Size(const int& SIZE) { size = SIZE; }

private:
	LE *Tarray; // Class data storage structure
	int size; // Tarray size
};

#include "cQuicksort.cpp"  // Technically this violates the priciple of
						   // data abstraction, but is needed to successfully
						   // compile the template class.
