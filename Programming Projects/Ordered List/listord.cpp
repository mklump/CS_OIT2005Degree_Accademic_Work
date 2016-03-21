//--------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #9
// Date Created:   August 22, 2002
// Last Change Date:  August 22, 2002
// Project:        Ordered List
// Filename:       listord.cpp
//
// Overview:  This include contains the implentation of the
//			  OrdList template class.
//     
//--------------------------------------------------------------------

#include "listord.h"

template < class LE, class KF >
OrdList<LE,KF>::OrdList( const int &maxNum )
{
	List<LE>( int(maxNum) );
}

template < class LE, class KF >
void OrdList<LE,KF>::insert ( const LE &newElement )
{
	//The list array must not be full
	if ( !full() )
	{

		int indexFound = 0; // index to insert after
		++size;

		if( binarySearch(newElement.key(), indexFound) )
		{
			element[indexFound] = newElement;
			--size;
			return;
		}
		if( size == 1 )
		//insert here if true
			element[0] = newElement;
		else
		//move the elements over one and insert
		{
			for(int x = size - 2; x > indexFound; --x)
				element[x + 1] = element[x];
			if( indexFound < size - 1 )
				cursor = indexFound + 1;
			else
				cursor = indexFound;
			element[cursor] = newElement;
		}
	}
	else
		return;
}

template < class LE, class KF >
void OrdList<LE,KF>::replace ( const LE &newElement )
{
	remove();
	insert( newElement );
}

template < class LE, class KF >
bool OrdList<LE,KF>::retrieve ( KF searchKey, LE &searchElement )
{
	int indexFound = 0;
	if( binarySearch(searchKey, indexFound) )
	{
		cursor = indexFound;
		searchElement = element[cursor];
		return true;
	}
	else
		return false;
}

template < class LE, class KF >
void OrdList<LE,KF>::merge ( const OrdList &fromL )
{
	int indexFound = 0; // index to insert after
	for(int x = 0; x < fromL.size; ++x)
	{
		++size;
		if( binarySearch(fromL.element[x].key(), indexFound) )
		{
			element[indexFound] = fromL.element[x];
			--size;
		}
		else
		{
			if( size == 1 )
			//insert here if true
				element[0] = fromL.element[x];
			else
			//move the elements over one and insert
			{
				for(int y = size - 2; y > indexFound; --y)
					element[y + 1] = element[y];
				if( indexFound < size - 1 )
					cursor = indexFound + 1;
				else
					cursor = indexFound;
				element[cursor] = fromL.element[x];
			}
		}
	}
}

template < class LE, class KF >
bool OrdList<LE,KF>::subset ( const OrdList &subL )
{
	int temp, found = 0;
	
	for(int x = 0; x < subL.size; ++x)
	{
		if( binarySearch(subL.element[x].key(), temp) )
		++found;
	}

	if( found == subL.size)
		return true;
	else
		return false;
}

template < class LE, class KF >
bool OrdList<LE,KF>::binarySearch ( KF searchKey, int &index )
// Locates an element (or where it should be) based on its key

// Binary search routine. Searches the first group of keys in element[]
// for searchKey. If searchKey is found, then returns true with
// the array index of the entry containing searchKey as an out parameter.
// Otherwise, returns false with index returning the array index of the
// entry containing the largest key that is smaller than searchKey
// (or -1 if there is no such key).
{
    int low  = 0,             // Low index of current search range
        high = size - 1;      // High index of current search range
    bool result;              // Success of failure status

    while ( low <= high )
    {
        index = ( low + high ) / 2;              // Compute midpoint
        if ( searchKey < element[index].key() )
           high = index - 1;                     // Search lower half
        else if ( searchKey > element[index].key() )
           low = index + 1;                      // Search upper half
        else
           break;                                // searchKey found
    }

    if ( low <= high )
       result = true;    // searchKey found
    else
    {
       index = high;     // searchKey not found, adjust index
       result = false;
    }

    return result;
}

template < class LE, class KF >
void OrdList<LE,KF>:: showStructure () const
// Outputs the keys of the elements in the list. If the list is empty,
// outputs "Empty list". This operation is intended for testing and
// debugging purposes only.
{
    int j;   // Loop counter

    if ( size == 0 )
       cout << "Empty list" << endl;
    else
    {
       cout << "size = " << size
            <<  "   cursor = " << cursor << endl;
       for ( j = 0 ; j < maxSize ; ++j )
           cout << j << "\t";
       cout << endl;
       for ( j = 0 ; j < size ; ++j )
           cout << element[j].key() << "\t";
       cout << endl;
    }
}