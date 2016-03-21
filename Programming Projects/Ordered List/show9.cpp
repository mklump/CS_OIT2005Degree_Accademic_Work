//--------------------------------------------------------------------
//
//  Laboratory 9                                          show9.cpp
//
//  Array implementation of the showStructure operation for the
//  Ordered List ADT
//
//--------------------------------------------------------------------

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
       for ( j = 0 ; j < maxSize ; j++ )
           cout << j << "\t";
       cout << endl;
       for ( j = 0 ; j < size ; j++ )
           cout << element[j].key() << "\t";
       cout << endl;
    }
}