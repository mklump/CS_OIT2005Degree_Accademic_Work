//--------------------------------------------------------------------
// Author:         Matthew Klump for CST 405 Analysis of Algorithms
// Date Created:   23 July 2003
// Last Change Date:  24 July 2003
// Project:        binarysearch LL vs array
// Filename:       binary_tree.h
//
// Overview:  This class is meant to imitate the structure and
//			  properties of a binary-search tree implemented
//			  as an array.
// Input:  None provided by this class, input is provided by the
//		   driver function main through a random number generator.
//   
// Output: The method/function Inorder_Tree_Walk prints out the
//		   current binary search tree structure as it is on one
//		   line at a time.
//   
//--------------------------------------------------------------------
#include <fstream>

#pragma once

using namespace std;
extern int MAX_ARRAYSIZE;
extern int NUMBER_OF_TRANSFERS;

class binary_tree
{
public:
	binary_tree(
				void
				);
	binary_tree(
				const int &size
				);
	~binary_tree(void);

	double *
	get_Tree()
	{
		return A;
	}
	void
	binary_tree::set_Tree(
					      const int &index,
				          const double &entry
				          );
	void
	Max_Tree(
			 double *Array,
			 const int &i
			 ); 
    void
	Build_Max_Tree(
				   double *Array
				   );
	void
	Inorder_Tree_Walk(
					  void
					  );
	void
	Output_Tree(
				ofstream &out
				);
	int
	Search_Tree(
				const double &value
				);
private:
	double *A;		// Array[] implementation of the binary-search tree
	int tree_size;	// Actual size of the heap
};
