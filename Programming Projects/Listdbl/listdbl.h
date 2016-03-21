//-------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #8
// Date Created:   August 8, 2002
// Last Change Date:  August 8, 2002
// Project:        Listdbl
// Filename:       listdbl.h
//
// Overview:	This include contains the interface for 
//				the circular, doubly linked list implementation
//				of the List ADT.
//     
//-------------------------------------------------------------------

#ifndef LISTDBL_H
#define LISTDBL_H

template < class LE > class List;

template < class LE >
class ListNode                 // Facilitator class for the List class
{
  private:

    // Constructor
    ListNode ( const LE &elem );

    // Data members
    LE element;         // List element
    ListNode *prior,    // Pointer to the previous element
             *next;     // Pointer to the next element

  friend class List<LE>;
};

//--------------------------------------------------------------------

template < class LE >
class List
{
public:

    // Constructor
    List ( const LE& data = NULL );

    // Destructor
    ~List ();

    // List manipulation operations
    void insert ( const LE &newElement );    // Insert after cursor
    void remove () throw();                  // Remove element
    void replace ( const LE &newElement );   // Replace element
    void clear ();                           // Clear list

    // List status operations
    int empty () const;                      // List is empty
    int full () const;                       // List is full

    // List iteration operations
    int gotoBeginning ();                    // Go to beginning
    int gotoEnd ();                          // Go to end
    int gotoNext ();                         // Go to next element
    int gotoPrior ();                        // Go to prior element
    LE getCursor () const;                   // Return the element marked by the cursor

	inline int getSize () const { return size; }
	inline int getPosition () const { return position; }

    // Output the list structure -- used in testing/debugging
    void showStructure () const;

    // In-lab opertions
    void reverse ();

private:

    // Data members
    ListNode<LE> *head,     // Pointer to the beginning of the list
                 *cursor;   // Cursor pointer

	int size,		// The number of elements in a List
		position;	// The numeric position of the cursor, where the elements are
					// numbered from beginning to end, starting with 0.
};

#endif // LISTDBL_H