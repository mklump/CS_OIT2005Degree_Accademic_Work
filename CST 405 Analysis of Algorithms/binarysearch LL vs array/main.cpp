//---------------------------------------------------------------------
// Author:         Matthew Klump for CST 405 Analysis of Algorithms
// Date Created:   23 July 2003
// Last Change Date:  24 July 2003
// Project:        Binary search tree project
// Filename:       main.cpp
//
// Overview:  Driver program for the binary_tree and tree_array classes.
// Input:  Input is accepted from a random number gererator of integers.
//		   Three tests will be conducted for each class:
//		   One for 1000 random integers.
//		   One for 10000 random integers.
//		   And one for 1000000 random integers.
//   
// Output: The output for this program is printed to a file "output.txt"
//   
//----------------------------------------------------------------------
#include <time.h>
#include "binary_tree.h"

int MAX_ARRAYSIZE;
int NUMBER_OF_TRANSFERS;

double
Calc_Time(
		  const clock_t &t1,
		  const clock_t &t2
		  );
void
Initialize_Tree(
				binary_tree *tree,
				const int &index
				);

int main(int argc, char* argv[])
{
	ofstream oFile( "output.txt", ios::out );
	clock_t t1, t2;
	for( int iter = 0; iter < 3; ++iter )
	{
		int limit = 0;
		switch(iter)
		{
		case 0:
			limit = 1000;
			break;
		case 1:
			limit = 10000;
			break;
		case 2:
			limit = 1000000;
			break;
		default:
			break;
		}
		NUMBER_OF_TRANSFERS = 0;
		binary_tree *tree = new binary_tree(MAX_ARRAYSIZE = limit);
		t1 = clock();
		for( int loop = 0; loop < limit; ++loop )
			Initialize_Tree( tree, loop );
		t2 = clock();
		oFile << endl << "Test Results for " << limit
			<< " random numbers input:" << endl
			<< "It took " << NUMBER_OF_TRANSFERS << " data transfers "
			<< "to complete the binary-search tree." << endl
			<< "It took " << Calc_Time( t1, t2 )
			<< " seconds to build the a full tree." << endl;
		t1 = clock();
		tree->Inorder_Tree_Walk();
		t2 = clock();
		oFile << "It took " << Calc_Time( t1, t2 ) 
		      << " seconds to traverse the tree." << endl;
		
		t1 = clock();
		tree->Search_Tree( limit );
		t2 = clock();
		oFile << "It took " << Calc_Time( t1, t2 )
			  << " seconds to lookup " << limit << "." << endl
			  << "When two items had the same value while doing the " 
			  << "insertion, it caused a" << endl
			  << "data colision, and the copy causing the collision " 
			  << "was thrown out." << endl;
		for( loop = MAX_ARRAYSIZE / 2; loop < MAX_ARRAYSIZE; ++loop )
			tree->set_Tree( loop, NULL );
		t1 = clock();
		tree->Inorder_Tree_Walk();
		t2 = clock();
		oFile << "After roughly half the items are deleted, it takes "
			<< Calc_Time( t1, t2 ) << " seconds to traverse the tree." << endl
			<< "For the timer's precion, there is definitely a difference " 
			<< "in traversal time."	<< endl;
	}
	oFile.close();
	return 0;
}

double
Calc_Time(
		  const clock_t &t1,
		  const clock_t &t2
		  )
{
	return (double)(t2 - t1) / (double)CLOCKS_PER_SEC / (double)1000.00;
}

void
Initialize_Tree(
				binary_tree *tree,
				const int &index
				)
{
	double value;
	srand( (unsigned)time( NULL ) );/* Seed the random-number generator with current time so that
									 * the numbers will be different every time this is run.
									 */
	value = rand();
	tree->set_Tree( index, value );
	tree->Build_Max_Tree( tree->get_Tree() );
	return;
}
