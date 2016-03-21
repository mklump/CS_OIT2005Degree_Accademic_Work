//--------------------------------------------------------------------
// Author:         Matthew Klump for CST 405 Analysis of Algorithms
// Date Created:   23 July 2003
// Last Change Date:  24 July 2003
// Project:        Binary search tree project
// Filename:       redblack_node.cpp
//
// Overview:  This class is meant to imitate the structure and
//			  properties of a red-black tree.
// Input:  None provided by this class, input is provided by the
//		   driver function main through an inputfile.
//   
// Output: The method/function Inorder_Tree_Walk prints out the
//		   current red-black tree structure as it is on one
//		   line at a time.
//   
//--------------------------------------------------------------------
#include "redblack_node.h"

redblack_node::redblack_node(void)
{
	left = NULL;
	right = NULL;
	parent = NULL;
	data = strdup( "" );
	color = strdup( "BLACK" );
}

redblack_node::~redblack_node(void)
{
}

void
redblack_node::Left_Rotate(
						   redblack_node *T,
						   redblack_node *x
						   )
{
	redblack_node *y, *temp = T;
	y = x->right;			// Set y.
	if( y == NULL )
		y = new redblack_node();
	x->right = y->left;		// Turn y's left subtree into x's right subtree
	if( y->left == NULL )
		y->left = new redblack_node();
	y->left->parent = x;
	y->parent = x->parent;	// Link x's parent to y.
	while( temp->parent != NULL )
		temp = temp->parent;// Set temp to point to the root of T
	if( x->parent == NULL )
		temp = y;
	else if( x == x->parent->left )
		x->parent->left = y;
	else
		x->parent->right = y;
	y->left = x;			// Put x on y's left.
	x->parent = y;
}

void
redblack_node::Right_Rotate(
						    redblack_node *T,
						    redblack_node *x
						    )
{
	redblack_node *y, *temp = T;
	y = x->left;			// Set y.
	if( y == NULL )
		y = new redblack_node();
	x->left = y->right;		// Turn y's right subtree into x's left subtree
	if( y->right == NULL )
		y->right = new redblack_node();
	y->right->parent = x;
	y->parent = x->parent;	// Link x's parent to y.
	while( temp->parent != NULL )
		temp = temp->parent;// Set temp to point to the root of T
	if( x->parent == NULL )
		temp = y;
	else if( x == x->parent->right )
		x->parent->right = y;
	else
		x->parent->left = y;
	y->right = x;			// Put x on y's right.
	x->parent = y;
}

void
redblack_node::RB_Insert(
						 redblack_node *T,	// pointer to entire tree T
						 redblack_node *z	// node to insert into tree T
						 )
{
	redblack_node *y = new redblack_node(),
		*x = T,
		*temp = T;

	if( Tree_Search( T, z->get_Data() ) != NULL )
		return;		// Please throw out all copies

	while( x->parent != NULL )
		temp = x = x->parent; // Point x to the root of the tree T
	while( x != NULL )
	{
		y = x;
		if( strcmp( z->data, x->data ) < 0 )
			x = x->left;
		else
			x = x->right;
	}
	z->parent = y;
	if( y == NULL )
		temp = z;
	else if( strcmp( z->data, y->data ) < 0 )
		y->left = z;
	else
		y->right = z;
	z->left = NULL;
	z->right = NULL;
	z->color = strdup( "RED" );
	RB_Insert_Fixup( T, z );
}

void
redblack_node::RB_Insert_Fixup(
							   redblack_node *T,
							   redblack_node *z
							   )
{
	redblack_node *y = new redblack_node(),
		*temp = T;
	while( temp->parent != NULL )
		temp = temp->parent; // point temp to the root of T
	while( strcmp( z->parent->color, "RED" ) == 0 )
	{
		if( z->parent == z->parent->parent->left )
		{
			y = z->parent->parent->right;
			if( y == NULL )
				y = new redblack_node();
			if( strcmp(y->color, "RED") == 0 )
			{
				z->parent->color = strdup( "BLACK" );
				y->color = strdup( "BLACK" );
				z->parent->parent->color = strdup( "RED" );
				z = z->parent->parent;
			}
			else if( z == z->parent->right )
			{
				z = z->parent;
				Left_Rotate( T, z );
			}
			z->parent->color = strdup( "BLACK" );
			z->parent->parent->color = strdup( "RED" );
			Right_Rotate( T, z->parent->parent );
		}
		else
		{
			y = z->parent->parent->left;
			if( y == NULL )
				y = new redblack_node();
			if( strcmp(y->color, "RED") == 0 )
			{
				z->parent->color = strdup( "BLACK" );
				y->color = strdup( "BLACK" );
				z->parent->parent->color = strdup( "RED" );
				z = z->parent->parent;
			}
			else if( z == z->parent->left )
			{
				z = z->parent;
				Right_Rotate( T, z );
			}
			if( z->parent == NULL )
				z->parent = new redblack_node();
			z->parent->color = strdup( "BLACK" );
			if( z->parent->parent == NULL )
				z->parent->parent = new redblack_node();
			z->parent->parent->color = strdup( "RED" );
			Left_Rotate( T, z->parent->parent );
		}
	}
	temp->color = strdup( "BLACK" );
}

redblack_node *
redblack_node::RB_Delete(
						 redblack_node *T,
						 redblack_node* z
						 )
{
	redblack_node *y, *x, *temp = T;
	while( temp->parent != NULL )
		temp = temp->parent; // point temp to the root of T
	if( z == NULL )
		z = new redblack_node;
	if( z->left == NULL || z->right == NULL )
		y = z;
	else
		y = static_cast<redblack_node *>(Tree_Successor( z ));
	if( y == NULL )
		y = new redblack_node();
	if( y->left != NULL )
		x = y->left;
	else
		x = y->right;
	if( x == NULL )
		x = new redblack_node;
	x->parent = y->parent;
	if( y->parent == NULL )
		temp = x;
	else if( y == y->parent->left )
		y->parent->left = x;
	else
		y->parent->right = x;
	if( y != z )
		z->data = strdup( y->data );
	if( strcmp( y->color, "BLACK" ) == 0 )
		RB_Delete_Fixup( T, x );
	return y;
}

void
redblack_node::RB_Delete_Fixup(
							   redblack_node *T,
							   redblack_node *x
							   )
{
	redblack_node *w, *temp = T;
	while( temp->parent != NULL )
		temp = temp->parent; // point temp to the root of T
	while( x != temp && strcmp( x->color, "BLACK" ) == 0 )
	{
		if( x->parent == NULL )
			x->parent = new redblack_node;
		if( x == x->parent->left )
		{
			w = x->parent->right;
			if( strcmp( w->color, "RED" ) == 0 )
			{
				w->color = strdup( "BLACK" );
				x->parent->color = strdup( "RED" );
				Left_Rotate( T, x->parent );
				w = x->parent->right;
			}
			if( strcmp( w->left->color, "BLACK" ) == 0 
				&& strcmp( w->right->color, "BLACK" ) == 0 )
			{
				w->color = strdup( "RED" );
				x = x->parent;
			}
			else if( strcmp( w->right->color, "BLACK" ) == 0 )
			{
				w->left->color = strdup( "BLACK" );
				w->color = strdup( "RED" );
				Right_Rotate( T, w );
				w = x->parent->right;
			}
			w->color = strdup( x->parent->color );
			x->parent->color = strdup( "BLACK" );
			w->right->color = strdup( "BLACK" );
			Left_Rotate( T, x->parent );
			x = temp;
		}
		else
		{
			w = x->parent->left;
			if( w == NULL )
				w = new redblack_node();
			if( strcmp( w->color, "RED" ) == 0 )
			{
				w->color = strdup( "BLACK" );
				x->parent->color = strdup( "RED" );
				Left_Rotate( T, x->parent );
				w = x->parent->left;
			}
			if( w->right == NULL )
				w->right = new redblack_node();
			if( w->left == NULL )
				w->left = new redblack_node();
			if( strcmp( w->right->color, "BLACK" ) == 0 
				&& strcmp( w->left->color, "BLACK" ) == 0 )
			{
				w->color = strdup( "RED" );
				x = x->parent;
			}
			else if( strcmp( w->left->color, "BLACK" ) == 0 )
			{
				w->right->color = strdup( "BLACK" );
				w->color = strdup( "RED" );
				Right_Rotate( T, w );
				w = x->parent->left;
			}
			if( x->parent == NULL )
				x->parent = new redblack_node();
			w->color = strdup( x->parent->color );
			x->parent->color = strdup( "BLACK" );
			w->left->color = strdup( "BLACK" );
			Left_Rotate( T, x->parent );
			x = temp;
		}
	}
	x->color = strdup( "BLACK" );
}
