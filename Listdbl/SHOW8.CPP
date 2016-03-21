//--------------------------------------------------------------------
//
//  Laboratory 8                                          show8.cpp
//
//  Circular, doubly linked list implementation of the showStructure
//  operation for the List ADT
//
//--------------------------------------------------------------------

template < class LE >
void List<LE>:: showStructure () const

// Outputs the elements in a list. If the list is empty, outputs
// "Empty list". This operation is intended for testing and
// debugging purposes only.

{
    ListNode<LE> *p;   // Iterates through the list

    if ( head == 0 )
       cout << "Empty list" << endl;
    else
    {
       p = head;
       do
       {
          if ( p == cursor )
             cout << "[" << p->element << "] ";
          else
             cout << p->element << " ";
          p = p->next;
       }
       while ( p != head );
       cout << endl;
    }
}