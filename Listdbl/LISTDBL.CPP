//--------------------------------------------------------------------
// Author:         Matthew Klump CST 211 Lab #8
// Date Created:   August 8, 2002
// Last Change Date:  August 8, 2002
// Project:        Listdbl
// Filename:       listdbl.cpp
//
// Overview:  This include contains the implentation of the
//			  List and the ListNode classes - 
//			  a circular doubly Linked List implementation.
//     
//--------------------------------------------------------------------

#include <iostream>
#include "stdafx.h"
#include "listdbl.h"

using namespace std;

template < class LE >
ListNode<LE>::ListNode( const LE &elem )
{
	if( elem != NULL )
	{
		prior = NULL;
		next = NULL;
		element = elem;
	}
	else
	{
		prior = this;
		next = this;
		element = NULL;
	}
}
template < class LE >
List<LE>::List( const LE& data )
{
	head = new ListNode<LE>( data );
	cursor = head;
	size = 1;
	position = 0;
}
template < class LE >
List<LE>::~List()
{
	clear();
}
template < class LE >
void List<LE>::clear()
{
	if( !empty() )
	{
		ListNode<LE> *currentPtr = head,
					 *tempPtr;
		while (currentPtr != NULL)
		{
			tempPtr = currentPtr;
			currentPtr = currentPtr->next;
			delete tempPtr;
		}
	}
}
template < class LE >
int List<LE>::empty() const
{
	if( head == NULL || head->element == 0 )
		return 1;
	else
		return 0;
}
template < class LE >
int List<LE>::full() const
{
	if( head->element != NULL )
		return 1;
	else
		return 0;
}
template < class LE >
void List<LE>::insert(const LE& newElement)
{
	char lempty = -35;
	if( empty() )
	{
		head->element = newElement;
		cursor = head;
	}
	else if( head->element == lempty )
	{
		List<LE>( newElement );
	}
	else
	{
		//insert after the cursor
		ListNode<LE> *newNode = new ListNode<LE>( newElement );
		newNode->prior = cursor;
		newNode->next = cursor->next;
		cursor->next->prior = newNode;
		cursor->next = newNode;
		//point cursor to the new ListNode with newElement
		cursor = newNode;
		++size;
		++position;
	}
}
template < class LE >
void List<LE>::remove() throw()
{
	char lempty = -35;
	if( !empty() && head->element != lempty )
	{
		//remove ListNode marked by cursor
		ListNode<LE> *temp = cursor;
		if( temp != head )
		{
			cursor->prior->next = cursor->next;
			cursor->next->prior = cursor->prior;
		}
		//point cursor to the following node
		if( cursor->next == head )
		{
			cursor = head;
			position = 0;
		}
		else
			cursor = cursor->next;
		if( temp == head )
			head = cursor;

		delete temp;
		--size;
	}
}
template < class LE >
void List<LE>::replace(const LE &newElement)
{
	if( !empty() )
		cursor->element = newElement;
}
template < class LE >
int List<LE>::gotoBeginning ()
{
	if( !empty() )
	{
		cursor = head;
		position = 0;
		return 1;
	}
	else
		return 0;
}
template < class LE >
int List<LE>::gotoEnd ()
{
	if( !empty() )
	{
		position = 0;
		cursor = head;
		for(int j=0; j < size - 1; ++j)
		{
			cursor = cursor->next;
			++position;
		}
		return 1;
	}
	else
		return 0;
}
template < class LE >
int List<LE>::gotoNext ()
{
	if( !empty() && cursor->next != head)
	{
		cursor = cursor->next;
		return 1;
	}
	else
	{
		gotoBeginning();
		return 0;
	}
}
template < class LE >
int List<LE>::gotoPrior ()
{
	if( !empty() && cursor != head )
	{
		cursor = cursor->prior;
		return 1;
	}
	else
	{
		gotoEnd();
		return 0;
	}
}
template < class LE >
LE List<LE>::getCursor () const
{
	if( !empty() )
		return cursor->element;
	else
		return 0;
}
template < class LE >
void List<LE>::reverse ()
{
	stack<LE> reverse;
	for(ListNode<LE> *x = head; x != NULL; x = x->next)
		reverse.push( x->element );
	for(cursor = head; cursor != NULL; cursor = cursor->next)
	{
		cursor->element = reverse.top();
		reverse.pop();
	}
}
template < class LE >
void List<LE>::showStructure () const
{
    ListNode<LE> *p;   // Iterates through the list
	char lempty = -35; // Checks for empty
    if ( head == NULL || head->element == 0 || head->element == lempty )
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
       while ( p != head && p != NULL);
       cout << endl;
    }
}
