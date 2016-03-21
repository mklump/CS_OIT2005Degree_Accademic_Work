#include "StdAfx.h"
using namespace std;

template <class NODETYPE>
List<NODETYPE>::List(void)
{
	firstPtr = NULL;
	lastPtr = NULL;
}

template <class NODETYPE>
List<NODETYPE>::~List(void)
{
	if ( !empty() ) {
		ListNode<NODETYPE>* currentPtr = firstPtr;
		ListNode<NODETYPE>* tempPtr;
		while (currentPtr != NULL) {
			tempPtr = currentPtr;
			currentPtr = currentPtr->nextPtr;
			delete tempPtr;
		}
	}
}

template <class NODETYPE>
void List<NODETYPE>::push_front(const NODETYPE& value)
{
	ListNode<NODETYPE>* newPtr = getNewNode(value);
	if (empty())
		firstPtr = lastPtr = newPtr;
	else {
		newPtr->nextPtr = firstPtr;
		firstPtr = newPtr;
	}
}

template <class NODETYPE>
void List<NODETYPE>::push_back(const NODETYPE& value)
{
	ListNode<NODETYPE>* newPtr = getNewNode(value);
	if (empty())
		firstPtr = lastPtr = newPtr;
	else {
		lastPtr->nextPtr = newPtr;
		lastPtr = newPtr;
	}
}

template <class NODETYPE>
int List<NODETYPE>::pop_front (NODETYPE& value)
{
	if (empty())
		return 0;
	else {
		ListNode<NODETYPE>* tempPtr = firstPtr;
		if (firstPtr == lastPtr)
			firstPtr = lastPtr = NULL;
		else
			firstPtr = firstPtr->nextPtr;
		value = tempPtr->data;
		delete tempPtr;
		return 1;
	}
}

template <class NODETYPE>
int List<NODETYPE>::pop_back (NODETYPE& value)
{
	if (empty())
		return 0;
	else {
		ListNode<NODETYPE>* tempPtr = lastPtr;
		if (firstPtr == lastPtr)
			firstPtr = lastPtr = NULL;
		else {
			ListNode<NODETYPE>* currentPtr = firstPtr;
			while (currentPtr->nextPtr != lastPtr)
				currentPtr = currentPtr->nextPtr;
			lastPtr = currentPtr;
			currentPtr->nextPtr = NULL;
		}
		value = tempPtr->data;
		delete tempPtr;
		return 1;
	}
}

template <class NODETYPE>
NODETYPE List<NODETYPE>::front (void) const {
	assert (firstPtr != NULL);
	return firstPtr->data;
}

template <class NODETYPE>
NODETYPE List<NODETYPE>::back (void) const {
	assert (lastPtr != NULL);
	return lastPtr->data;
}

template <class NODETYPE>
int List<NODETYPE>::empty (void) const {
	return (firstPtr == NULL);
}

template <class NODETYPE>
ListNode<NODETYPE>* List<NODETYPE>::getNewNode (const NODETYPE& value) {
    ListNode<NODETYPE>* ptr = new ListNode<NODETYPE>(value);
	assert (ptr != NULL);
	return ptr;
}

template <class NODETYPE>
void List<NODETYPE>::print (void) const {
	cout << "Head of List" << endl;
	ListNode<NODETYPE>* currentPtr = firstPtr;
	int counter = 0;
	while (currentPtr != NULL) {
		cout << counter++ << "\t" << currentPtr->data << endl;
		currentPtr = currentPtr->nextPtr;
	}
	cout << "Tail of List" << endl;
}