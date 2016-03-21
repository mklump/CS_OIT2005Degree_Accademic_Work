#pragma once

template <class NODETYPE>
class ListNode
{
//	friend class List<NODETYPE>;
public:
	ListNode(const NODETYPE &);
	NODETYPE getData() const;
//private:
	NODETYPE data;
	ListNode* nextPtr;

};

#include "ListNode.cpp"
