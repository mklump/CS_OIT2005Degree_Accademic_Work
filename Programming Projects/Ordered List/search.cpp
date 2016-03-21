//--------------------------------------------------------------------
//
//  Laboratory 15, In-lab Exercise 1                      search.cpp
//
//  Implementation of a set of searching routines
//
//--------------------------------------------------------------------

template < class LE >
int linearSearch ( LE keyList [], int numKeys,
                   LE searchKey, int &index    )

// Linear search routine. Searches the first numKeys keys in keyList
// for searchKey. If searchKey is found, then returns 1 with index
// returning the array index of the entry containing searchKey.
// Otherwise, returns 0 with index returning the array index of the
// entry containing the largest key that is smaller than searchKey
// (or -1 if there is no such key).

{
    int result;   // Result returned

    index = 0;
    while ( index < numKeys  &&  searchKey > keyList[index] )
          index++;

    if ( index < numKeys  &&  searchKey == keyList[index] )
       result = 1;   // searchKey found
    else
    {
       index--;      // searchKey not found
       result = 0;
    }

    return result;
}

//--------------------------------------------------------------------

template < class LE >
int binarySearch ( LE keyList [], int numKeys,
                   LE searchKey, int &index    )
// Binary search routine. Searches the first numKeys keys in keyList
// for searchKey. If searchKey is found, then returns 1 with index
// returning the array index of the entry containing searchKey.
// Otherwise, returns 0 with index returning the array index of the
// entry containing the largest key that is smaller than searchKey
// (or -1 if there is no such key).
{
    int low  = 0,             // Low index of current search range
        high = numKeys - 1,   // High index of current search range
        result;               // Result returned

    while ( low <= high )
    {
        index = ( low + high ) / 2;              // Compute midpoint
        if ( searchKey < keyList[index] )
           high = index - 1;                     // Search lower half
        else if ( searchKey > keyList[index] )
           low = index + 1;                      // Search upper half
        else
           break;                                // searchKey found
    }

    if ( low <= high )
       result = 1;       // searchKey found
    else
    {
       index = high;     // searchKey not found, adjust index
       result = 0;
    }

    return result;
}

//--------------------------------------------------------------------

template < class LE >
int unknownSearch ( LE keyList [], int numKeys,
                    LE searchKey, int &index    )

// Unknown search routine. Searches the first numKeys keys in keyList
// for searchKey. If searchKey is found, then returns 1 with index
// returning the array index of the entry containing searchKey.
// Otherwise, returns 0 with index returning the array index of the
// entry containing the largest key that is smaller than searchKey
// (or -1 if there is no such key).

{
    int result;   // Result returned

    index = 0;
    while ( index < numKeys  &&  searchKey != keyList[index] )
          index++;

    if ( index < numKeys )
       result = 1;   // searchKey found
    else
    {
       index--;      // searchKey not found
       result = 0;
    }

    return result;
}

