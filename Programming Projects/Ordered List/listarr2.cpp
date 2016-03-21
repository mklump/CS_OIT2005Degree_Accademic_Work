//--------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #9
// Date Created:   August 20, 2002
// Last Change Date:  August 20, 2002
// Project:        Ordered List
// Filename:       List.cpp
//
// Overview:  This include contains the implentation of the
//			  List template class.
//     
//--------------------------------------------------------------------

#include "listarr2.h"

template < class LE >
List<LE>::List( const int &maxNumber )
{
	maxSize = maxNumber;
	size = 0;
	cursor = 0;
	element = new LE[maxSize];
}

template < class LE >
List<LE>::List( const List &source )
{
	element = new LE[source.size];
	size = sizeof(element)/sizeof(element[0]);
	cursor = 0;
	for(int x = 0; x < size; ++x)
		element[x] = source.element[x];
}

template < class LE >
List<LE>::~List()
{
	delete [] element;
}

/*template < class LE >
void List<LE>::showStructure () const

// Outputs the elements in a list. If the list is empty, outputs
// "Empty list". This operation is intended for testing/debugging
// purposes only.

{
    int j;   // Loop counter

    if ( size == 0 )
       cout << "Empty list" << endl;
    else
    {
       cout << "size = " << size
            <<  "   cursor = " << cursor << endl;
       for ( j = 0 ; j < maxSize ; j++ )
           cout << j << "\t";
       cout << endl;
       for ( j = 0 ; j < size ; j++ )
           cout << element[j] << "\t";
       cout << endl;
    }
}*/

template < class LE >
void List<LE>::insert( const LE& newElement )
{
	//The list array must not be full
	if ( !full() )
	{
		//increment the size
		++size;
		//move the elements over one
		if( size > 1)
		{
			for(int x = size - 2; x > cursor; --x)
				element[x + 1] = element[x];
		}

		//insert new element
		if( size == 1 )
			element[0] = newElement;
		else
			element[++cursor] = newElement;
	}
	else
		return;
}

template < class LE >
void List<LE>::remove()
{
	LE temp;
	temp.setkey( NULL );
	if( !empty() )
	{
		if( cursor == size - 1 )
		{		
			element[size - 1] = temp;
			cursor = 0;
		}
		else
		{
			for(int x=cursor + 1, y = cursor; x < size; ++x, ++y)
				element[y] = element[x];

			element[size - 1] = temp;
		}
		--size;
	}
	else
		return;
}

template < class LE >
int List<LE>::empty () const
{
	return( size == 0 );
}

template < class LE >
int List<LE>::full() const
{
	return( size == maxSize );
}

template < class LE >
void List<LE>::replace(const LE& newElement)
{
	if ( !empty() )
		element[cursor] = newElement;
	else
		return;
}

template < class LE >
int List<LE>::find(const LE& searchElement)
{
	for(int x = 0; x < size; ++x)
	{
		if( element[x] == searchElement )
		{
			cursor = x;
			return true;
		}
	}
	return false;
}

template < class LE >
void List<LE>::clear()
{
	LE temp;
	temp.setKey( NULL );
	for(int x = 0; x < size; ++x)
		element[x] = temp;

	cursor = size = 0;
}

template < class LE >
int List<LE>::gotoPrior()
{
	if( cursor != 0 )
	{
		--cursor;
		return true;
	}
	else
		return false;
}
template < class LE >
int List<LE>::gotoNext()
{
	if( cursor != size - 1 )
	{
		++cursor;
		return true;
	}
	else
		return false;
}

template < class LE >
int List<LE>::gotoEnd()
{
	if( size != 0 )
	{
		cursor = size - 1;
		return true;
	}
	else
		return false;
}

template < class LE >
int List<LE>::gotoBeginning()
{
	if( size != 0 )
	{
		cursor = 0;
		return true;
	}
	else
		return false;
}

template < class LE >
LE List<LE>::getCursor() const
{
	return element[cursor];
}