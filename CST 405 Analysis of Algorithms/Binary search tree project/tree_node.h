//--------------------------------------------------------------------
// Author:         Matthew Klump for CST 405 Analysis of Algorithms
// Date Created:   23 July 2003
// Last Change Date:  24 July 2003
// Project:        Binary search tree project
// Filename:       tree_node.h
//
// Overview:  This class is meant to imitate the structure and
//			  properties of a binary search tree.
// Input:  None provided by this class, input is provided by the
//		   driver function main through an inputfile.
//   
// Output: The method/function Inorder_Tree_Walk prints out the
//		   current binary search tree structure as it is on one
//		   line at a time.
//   
//--------------------------------------------------------------------
#pragma once

#include <fstream>
#include <iostream>
using namespace std;

extern int NUM_TRANSFERS;
extern int NUM_DATAUMS;

class tree_node
{
public:
	friend class redblack_node;
	tree_node(
			  void
			  );
	~tree_node(
			   void
			   );
	void
	Inorder_Tree_Walk(
					  tree_node *x
					  );
	void
	Tree_Insert(
				tree_node *T,	// pointer to tree T
				tree_node *z	// node to insert into tree T
				);
	tree_node *
	Tree_Delete(
				tree_node *T,	// pointer to tree T
				tree_node *z	// node to delete in tree T
				);
	tree_node *
	Tree_Successor(
				   tree_node *x
				   );
	tree_node *
	Tree_Minimum(
				 tree_node *x
				 );
	tree_node *
	Tree_Maximum(
				 tree_node *x
				 );
	tree_node *
	Tree_Search(
				tree_node *T,	// pointer to tree T
				char *k			// data to search for
				);
	tree_node *
	Iterative_Tree_Search(
						  tree_node *T,	// pointer to tree T
						  char *k		// data to search for
						  );
	void
	set_Data(
			 const char *d
			 )		{ data = strdup( d ); }
	char *
	get_Data(
			 void
			 )	 { return data; }

	tree_node *
	get_Right(
			  void
			  )	   { return right; }
private:
	char *data;
	tree_node *left;
	tree_node *right;
	tree_node *parent;
};
