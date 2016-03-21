#pragma once
#include <iostream>
#include <assert.h>
#include "ListNode.h"

template <class NODETYPE>
class List
{
public:
	List(void);								//Constructor
	~List(void);							//Destructor
	void push_front (const NODETYPE &);		//Add element to the head
	void push_back (const NODETYPE &);		//Add element to the tail
	int pop_front (NODETYPE &);				//Retrive element at head and remove it
	int pop_back (NODETYPE &);				//Retrive element at tail and remove it				
	NODETYPE front (void) const;			//Return element at head without removal
	NODETYPE back (void) const;				//Return element at tail without removal
	int empty(void) const;
	void print(void) const;
private:
	ListNode<NODETYPE>* firstPtr;
	ListNode<NODETYPE>* lastPtr;
	ListNode<NODETYPE>* getNewNode (const NODETYPE &);
};

#include "List.cpp"
