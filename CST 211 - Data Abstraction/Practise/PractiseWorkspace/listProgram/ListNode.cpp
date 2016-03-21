#include "StdAfx.h"

template <class NODETYPE>
ListNode<NODETYPE>::ListNode(const NODETYPE& newData)
{
	data = newData;
	nextPtr = NULL;
}

template <class NODETYPE>
NODETYPE ListNode<NODETYPE>::getData() const
{
	return data;
}

