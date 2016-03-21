//--------------------------------------------------------------------
// Author:         Matthew Klump
//				   CST 223 Programming Languages II
//				   C++ Assignment
// Date Created:   May 31, 2002
// Last Change Date:  May 31, 2002
// Project:        Quicksort
// Filename:       cQuicksort.cpp
//
// Overview:  This source file contains the main procedure. This
//			  is the entry point for Quicksort.exe test program.
//     
//--------------------------------------------------------------------

#include "cQuicksort.h"

int main(int argc, char* argv[])
{
	/*cQuicksort<int> quicksort1(10);
	char file1[] = "sort1.dat";

	quicksort1.Read_File( file1 );
	quicksort1.Sort_File( 1, quicksort1.get_Size() );
	quicksort1.Print_File( file1 );*/

	cQuicksort<char *> quicksort2(13);
	char file2[] = "sort2.dat";

	quicksort2.Read_File( file2 );
	quicksort2.Sort_File( 1, quicksort2.get_Size() );
	quicksort2.Print_File( file2 );

	return 0;
}
