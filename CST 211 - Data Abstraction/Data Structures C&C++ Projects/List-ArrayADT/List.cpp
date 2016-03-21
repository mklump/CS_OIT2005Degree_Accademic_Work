//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   July 20, 2002
// Last Change Date:  July 20, 2002
// Project:        List-ArrayADT
// Filename:       List.cpp
//
// Overview:  This include contains the implentation of the
//			  List class.
//     
//--------------------------------------------------------------------

template < class LE >
List<LE>::List( int maxNumber )
{
	maxSize = maxNumber;
	size = maxNumber;
	cursor = 0;
	element = new LE[maxSize];
}

template < class LE >
List<LE>::~List()
{
	delete [] element;
}

template < class LE >
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
}

template < class LE >
void List<LE>::insert( const LE& newElement )
{
	//The list array must not be full
	if ( !full() )
	{
		//get the range to move
		int rangeToMove = size - cursor;

		//allocate space to copy
		LE* tempLE = new LE[rangeToMove];

		int indx = cursor + 1, // loop variables
			indy = 0;
		//start copying
		while( indx < size )
		{
			tempLE[ indy ] = element[ indx ];
			++indx;
			++indy;
		}
		//insert new element
		if( element[1] == NULL )
			element[0] = newElement;
		else
			element[cursor + 1] = newElement;

		//copy back to element
		indx = cursor + 2;
		indy = 0;
		while( indx <= size )
		{
			element[indx] = tempLE[indy];
			++indx;
			++indy;
		}
		//increment the cursor
		cursor++;

		delete [] tempLE;
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
void List<LE>::remove()
{
	if( !empty() )
	{
		element[cursor] = NULL;
		cursor--;
	}
	else
		return;
}

template < class LE >
int List<LE>::find(const LE& searchElement)
{

}

template < class LE >
void List<LE>::moveToNth(int n)
{

}

template < class LE >
void List<LE>::clear()
{
	for(int indx=0; indx < size; ++indx)
		element[indx] = NULL;
}

template < class LE >
int List<LE>::gotoPrior()
{

}
template < class LE >
int List<LE>::gotoNext()
{

}

template < class LE >
int List<LE>::gotoEnd()
{

}

template < class LE >
int List<LE>::gotoBeginning()
{

}

template < class LE >
LE List<LE>::getCursor() const
{

}