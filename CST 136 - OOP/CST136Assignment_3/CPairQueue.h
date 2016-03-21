//-------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #3 Part 1
// Date Created:   May 3, 2002
// Last Change Date:  May 3, 2002
// Project:        CPairQueue
// Filename:       CPairQueue.h
//
// Overview:  This include contains the interface for the
//			  CPairQueue class.
//     
//-------------------------------------------------------------------


#if !defined(AFX_CPAIRQUEUE_H__3AE2550F_79A2_4C0C_8506_CD13A0A0E855__INCLUDED_)
#define AFX_CPAIRQUEUE_H__3AE2550F_79A2_4C0C_8506_CD13A0A0E855__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <iostream>
using std::cin;
using std::cout;
using std::endl;

template<class T>
class CPairQueue  
{
public:
	CPairQueue( int = 0 );		//default constructor

	virtual ~CPairQueue() { cout << "Destructing Arrays...\n"; //destructor
							delete [] queuePtr1;
							delete [] queuePtr2; };
	bool Push( const T&, const T& ); //Pushes a pair of items onto the back of the queue.
	bool Pop( T&, T& );	             //Removes a pair of items from the front of the queue.
	void ResetTopPointer();			 //Sets top pointer back to starting position

	int getSize()	 { return size;}  //Returns the number of pairs in the queue.
	T getQueuePtr1(const int& i1) { return queuePtr1[i1]; }; //Return first array pointer
	T getQueuePtr2(const int& i2) { return queuePtr2[i2]; }; //Return second array pointer
	void Display();				 //Prints the both queues to cout.
	void DisplayN(const int& n); //Prints the Nth pair in the queue to cout.

	void Clear();			   //Empty/reset/clear the entire queue.
	void ClearN(const int& n); //Empty/reset/clear the Nth pair in the queue.

private:
	int size;		   // # of elements in the queue
	int top;		   // location of the top element
	int n;			   // location of the Nth element
	T *queuePtr1;	   // pointer to the first queue
	T *queuePtr2;	   // pointer to the second queue

	bool isEmpty() const { return top == -1; }      //Utility
	bool isFull() const { return top == size - 1; } //functions
};

#endif // !defined(AFX_CPAIRQUEUE_H__3AE2550F_79A2_4C0C_8506_CD13A0A0E855__INCLUDED_)

//////////////////////////////////////////////////////////////////////
// Construction
//////////////////////////////////////////////////////////////////////

// Constructor with default size 10
template< class T >
CPairQueue< T >::CPairQueue( int s )
{
	cout << "Constructing Arrays...";
	size = s > 0 ? s : 10;
	top = -1;				  //Queue is initially empty
	n = 0;
	queuePtr1 = new T[ size ]; //Allocate space for the first queue
	queuePtr2 = new T[ size ]; //Allocate space for the second queue
}

//////////////////////////////////////////////////////////////////////
// Push() and Pop() implementations
//////////////////////////////////////////////////////////////////////

// Push an element onto the queue
// return 1 if successful, 0 otherwise
template< class T >
bool CPairQueue< T >::Push( const T &pushV1, const T &pushV2 )
{
	if ( !isFull() )
	{
		queuePtr1[ ++top ] = pushV1; // place item in queue1
		queuePtr2[ top ] = pushV2;   // place item in queue2
      return true;  // push successful
	}
   return false;     // push unsuccessful
}

// Pop an element off the queue
template< class T >
bool CPairQueue< T >::Pop( T &popV1, T &popV2 )
{
	if ( !isFull() )
	{
       popV1 = queuePtr1[ ++top ];  // remove item from queue1
	   popV2 = queuePtr2[ top ];  // remove item from queue2
       return true;  // pop successful
	}
    return false;    // pop unsuccessful
}

//////////////////////////////////////////////////////////////////////
// Display() and DisplayN() implementations
//////////////////////////////////////////////////////////////////////

template< class T >
void CPairQueue< T >::Display()
{
	for (int index = 0; index < size; index++)
	{
		cout << " ( " << queuePtr1[index] 
			<< ' ' << queuePtr2[index] << " ) ";
	}
}

template< class T >
void CPairQueue< T >::DisplayN(const int& n)
{
	cout << "Pair: " << n + 1 << " ( " 
		<< queuePtr1[n] << ' ' << queuePtr2[n] << " ) ";
}

template< class T >
void CPairQueue< T >::ResetTopPointer()
{
	top -= top + 1;
}

template< class T >
void CPairQueue< T >::Clear()
{
	for (int index = 0; index < size; index++)
	{
		queuePtr1[index] = NULL;
		queuePtr2[index] = NULL;
	}
}

template< class T >
void CPairQueue< T >::ClearN(const int& n)
{
	queuePtr1[n] = NULL;
	queuePtr2[n] = NULL;
}