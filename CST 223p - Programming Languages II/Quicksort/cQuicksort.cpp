//--------------------------------------------------------------------
// Author:         Matthew Klump
//				   CST 223 Programming Languages II
//				   C++ Assignment
// Date Created:   May 31, 2002
// Last Change Date:  May 31, 2002
// Project:        Quicksort
// Filename:       cQuicksort.cpp
//
// Overview:  This include contains the implentation of the
//			  cQuicksort class.
//     
//--------------------------------------------------------------------

// Quicksort.cpp : Defines the methods for the cQuicksort class.
#include <fstream>

int compare( const void* key, const void* value );

template <class LE>
cQuicksort<LE>::cQuicksort( const int& iSize )
{
	size = iSize;
    Tarray = new LE[size];
	for( int i = 0; i < size; ++i )
		Tarray[i] = 0;
}

template <class LE>
cQuicksort<LE>::~cQuicksort(void)
{
	Tarray = NULL;
}

template <class LE>
void
cQuicksort<LE>::Read_File(const char* file_name)
{
	char element[256]; // Next element in array
	ifstream iFile; // Input file stream
	int index = 0; // Loop variable

	iFile.open(file_name, ios::in);
	if( !iFile || iFile.fail() ) // overloaded ! operator, wheather or not iFile opened
		cout << "Input file " << file_name << " did not successfully open." << endl;

	while( iFile >> element )
	{
		Tarray[index] = strdup( element );
		strcpy( element, "" );
		index++;
	}
}

template <class LE>
void
cQuicksort<LE>::Sort_File(const int& l, const int& r)
{	// l is left, r is right
	LE   v,	 // Key to search for
		 t;  // temporary value
	int  i = 0,	// index variable
		 j = 0;	// index variable

	if( r < l )
	{
		v = Tarray[r];
		i = l - 1;
		j = r;
		while( j >= i )
		{
			while( Tarray[i] <= v )
				i++; // repeat i = i++ until Tarray[i] >= v
				
			while( Tarray[j] >= v )
				j--; // repeat j = j - 1 until Tarray[j] <= v

			t = Tarray[i];
			Tarray[i] = Tarray[j];
			Tarray[j] = t;
		}
		t = Tarray[i];
		Tarray[i] = Tarray[r];
		Tarray[j] = t;
		Sort_File( l, i - 1 );
		Sort_File( i + 1, r );
	}
	qsort( Tarray, size, sizeof(Tarray), compare );

	char ans = ' ';
	while( ans != 'a' && ans != 'd' )
	{
		cout << "Sort how?" << endl
			 << "['a' for ascending (Z - A) or 'd' for descending (A - z)]: ";
		cin >> ans;
		if( ans != 'a' && ans != 'd' )
			 cout << "Enter either 'a' or 'd'" << endl;
	}

	for( int x = 0; x < size; ++x )
	{
		for(int y = 0; y < size; ++y )
		{
			if( strcmp(Tarray[x], Tarray[y]) < 0 && ans == 'd' )
			{
				t = Tarray[x];
				Tarray[x] = Tarray[y];
				Tarray[y] = t;
			}
			if( strcmp(Tarray[x], Tarray[y]) > 0 && ans == 'a' )
			{
				t = Tarray[x];
				Tarray[x] = Tarray[y];
				Tarray[y] = t;
			}
		} // for( int y = 0 ...
	} // for( int x = 0 ...
}

int compare( const void* key, const void* value )
{
	if( key < value )
		return -1;
	else
		return 1;
}

template <class LE>
void
cQuicksort<LE>::Print_File(const char* file_name)
{
	cout << endl << file_name << " sorted is: ";
	for( int index = 0; index < size; ++index )
	{
		cout << Tarray[index];
		if( index < size - 1 )
			cout << ", ";
		else
			cout << endl;
	}
}
