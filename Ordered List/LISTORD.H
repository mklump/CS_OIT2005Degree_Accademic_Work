//-------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #9
// Date Created:   August 20, 2002
// Last Change Date:  August 20, 2002
// Project:        Ordered List
// Filename:       listord.h
//
// Overview:	Class declaration for the array implementation of
//				the Ordered List ADT -- inherits the array 
//				implementation of the List ADT (Laboratory 4)
//     
//-------------------------------------------------------------------

#include "listarr2.cpp"

template < class LE, class KF >     // LE : List Element
class OrdList : public List<LE>     // KF : Key field
{
  public:

    // Constructor
    OrdList ( const int &maxNumber = defMaxListSize );

    // Modified (or new) list manipulation operations
    virtual void insert ( const LE &newElement );
    virtual void replace ( const LE &newElement );
    bool retrieve ( KF searchKey, LE &searchElement );

    // Output the list structure -- used in testing/debugging
    virtual void showStructure () const;

    // In-lab operations
    void merge ( const OrdList &fromL );
    bool subset ( const OrdList &subL );

  private:

    // Locates an element (or where it should be) based on its key
    bool binarySearch ( KF searchKey, int &index );
};