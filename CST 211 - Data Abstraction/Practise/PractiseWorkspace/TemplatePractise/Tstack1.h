// Fig. 12.3: tstack1.h
// Class template Stack
#ifndef TSTACK1_H
#define TSTACK1_H

template< class T >
class Stack
{
public:
   Stack( int = 10 );    // default constructor (stack size 10)
   ~Stack() { delete [] stackPtr; } // destructor
   bool push( const T& ); // push an element onto the stack
   bool pop( T& );        // pop an element off the stack
private:
   int size;             // # of elements in the stack
   int top;              // location of the top element
   T *stackPtr;          // pointer to the stack

   bool isEmpty() const { return top == -1; }      // utility
   bool isFull() const { return top == size - 1; } // functions
};

// Constructor with default size 10
template< class T >
Stack< T >::Stack( int s )
{
   size = s > 0 ? s : 10;  
   top = -1;               // Stack is initially empty
   stackPtr = new T[ size ]; // allocate space for elements
}

// Push an element onto the stack
// return 1 if successful, 0 otherwise
template< class T >
bool Stack< T >::push( const T &pushValue )
{
   if ( !isFull() ) {
      stackPtr[ ++top ] = pushValue; // place item in Stack
      return true;  // push successful
   }
   return false;     // push unsuccessful
}

// Pop an element off the stack
template< class T > 
bool Stack< T >::pop( T &popValue )
{
   if ( !isEmpty() ) {
      popValue = stackPtr[ top-- ];  // remove item from Stack
      return true;  // pop successful
   }
   return false;     // pop unsuccessful
}

#endif


/**************************************************************************
 * (C) Copyright 2000 by Deitel & Associates, Inc. and Prentice Hall.     *
 * All Rights Reserved.                                                   *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
