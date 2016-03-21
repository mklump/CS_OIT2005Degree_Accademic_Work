//--------------------------------------------------------------------
// Author:         Matthew Klump for CST 405 Analysis of Algorithms
// Date Created:   23 July 2003
// Last Change Date:  24 July 2003
// Project:        Binary search tree project
// Filename:       tree_node.cpp
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
#include "tree_node.h"

tree_node::tree_node(
					 void
					 )
{
	data = 0.0;
	left = NULL;
	right = NULL;
	parent = NULL;
}

tree_node::~tree_node(
					  void
					  )
{
}

void
tree_node::Tree_Insert(
					   tree_node *T, // pointer to tree T
					   tree_node *z  // node to insert
					   )
{
	tree_node *y = new tree_node(),
		*x = T,
		*temp;

	//if( Iterative_Tree_Search( T, z->get_Data() ) != NULL )
	//	return;		// Please throw out all copies

	NUM_DATAUMS++;
	while( x->parent != NULL )
	{
		x = x->parent; // Loop until x points to the root of T
		NUM_TRANSFERS++;
	}
	while( x != NULL )
	{
		y = x; NUM_TRANSFERS++;
		if( z->data < x->data )
		{
			x = x->left;
			NUM_TRANSFERS++;
		}
		else
		{
			x = x->right;
			NUM_TRANSFERS++;
		}
	}
	z->parent = y; NUM_TRANSFERS++;
	temp = T;	   NUM_TRANSFERS++;
	while( temp->parent != NULL )
	{
		temp = temp->parent; // Point temp to the root of T
		NUM_TRANSFERS++;
	}
	if( y == NULL )
	{
		T = temp; NUM_TRANSFERS++;
		T = z;	 // Tree T was empty 
	}
	else if( z->data < y->data )
	{
		y->left = z;
		NUM_TRANSFERS++;
	}
	else
	{
		y->right = z;
		NUM_TRANSFERS++;
	}	
}

tree_node *
tree_node::Tree_Delete(
					   tree_node *T,
					   tree_node *z
					   )
{
	tree_node *y, *x,
		*temp = T;

	while( temp->parent != NULL )
		temp = temp->parent;	// point temp to the root of tree T
	if( z->left == NULL || z->right == NULL )
		y = z;
	else
		y = Tree_Successor( z );
	if( y->left != NULL )
		x = y->left;
	else
		x = y->right;
	if( x != NULL )
		x->parent = y->parent;
	if( y->parent == NULL )
		temp = x;
	else if( y == y->parent->left )
		y->parent->left = x;
	else
		y->parent->right = x;
	if( y != z )
		z->data = y->data;
	return y;
}

tree_node *
tree_node::Tree_Successor(
						  tree_node *x
						  )
{
	tree_node *y;
	if( x->right != NULL )
		return Tree_Minimum( x->right );

	y = x->parent;
	while( y != NULL && x == y->right )
	{
		x = y;
		y = y->parent;
	}
	return y;
}

tree_node *
tree_node::Tree_Minimum(
						tree_node *x
						)
{
	while( x->left != NULL )
		x = x->left;
	return x;
}

tree_node *
tree_node::Tree_Maximum(
						tree_node *x
						)
{
	while( x->right != NULL )
		x = x->right;
	return x;
}

tree_node *
tree_node::Tree_Search(
					   tree_node *x,
					   const double &k
					   )
{
	if( x == NULL || k == x->data )
		return x;
	if( k < x->data )
		return Tree_Search( x->left, k );
	else
		return Tree_Search( x->right, k );
}

tree_node *
tree_node::Iterative_Tree_Search(
								 tree_node *x,
								 const double &k
								 )
{
	while( x != NULL && k != x->data )
	{
		if( k < x->data )
			x = x->left;
		else
			x = x->right;
	}
	return x;
}

void
tree_node::Inorder_Tree_Walk(
							 tree_node *x
							 )
{
	if( x != NULL )
	{
		Inorder_Tree_Walk( x->left );
		cout << x->data << endl;
		Inorder_Tree_Walk( x->right );
	}
}
