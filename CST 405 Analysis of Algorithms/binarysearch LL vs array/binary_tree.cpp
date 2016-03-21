//--------------------------------------------------------------------
// Author:         Matthew Klump for CST 405 Analysis of Algorithms
// Date Created:   23 July 2003
// Last Change Date:  24 July 2003
// Project:        binarysearch LL vs array
// Filename:       binary_tree.cpp
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
#include "binary_tree.h"

binary_tree::binary_tree(
						 void
						 )
{
}

binary_tree::binary_tree(
						 const int &size
				         )
{
	A = new double[size];

	for(int index = 0; index < MAX_ARRAYSIZE; ++index)
		A[index] = 0.0;
}

binary_tree::~binary_tree()
{
	delete A;
}

void
binary_tree::set_Tree(
					  const int &index,
				      const double &entry
				      )
{
	A[index] = entry;
}

void
binary_tree::Inorder_Tree_Walk(
							   void
							   )
{
	const int ONE = 1;
	double temp;

	Build_Max_Tree( A );
	for( int index = MAX_ARRAYSIZE - 1; index > 0; --index )
	{
		temp = A[0];
		A[0] = A[index];
		A[index] = temp;

		tree_size = tree_size - 1;
		Max_Tree( A, ONE );
	}
}

void
binary_tree::Max_Tree(
					  double *Array,
					  const int &i
					  )
{
	int left = i - 1,
		right = i + 1;
	static int largest;
    double temp;

	if( left < 0 || right >= MAX_ARRAYSIZE )
		return;
	if( left <= tree_size && Array[left] > Array[i] )
		largest = left;
	else
		largest = i;

	if( right <= tree_size && Array[right] > Array[largest] )
		largest = right;

	if( largest != i )
	{
		temp = Array[i];		   NUMBER_OF_TRANSFERS++;
		Array[i] = Array[largest]; NUMBER_OF_TRANSFERS++;
		Array[largest] = temp;     NUMBER_OF_TRANSFERS++;

		Max_Tree( Array, largest );
	}
}

void
binary_tree::Build_Max_Tree(
						    double *Array
						    )
{
	tree_size = MAX_ARRAYSIZE;
	for( int index = MAX_ARRAYSIZE / 2; index > 0; --index )
		Max_Tree( Array, index );
}

int
binary_tree::Search_Tree(
						 const double &value
						 )
{
	for( int index = 0; index < MAX_ARRAYSIZE; ++index )
	{
		if( A[index] == value )
			return index;
	}
	return NULL;
}

void
binary_tree::Output_Tree(
						  ofstream &out
						  )
{
	for( int index = 0; index < MAX_ARRAYSIZE; ++index )
		out << A[index] << endl;
}
