//---------------------------------------------------------------------
// Author:         Matthew Klump for CST 405 Analysis of Algorithms
// Date Created:   23 July 2003
// Last Change Date:  24 July 2003
// Project:        Binary search tree project
// Filename:       main.cpp
//
// Overview:  Driver program for the tree_node and the redblack_node
//			  classes.
// Input:  Input is accepted from one of two source files "200words.txt"
//		   and "1500words.txt"
//   
// Output: The output for this program is printed to a file "output.txt"
//   
//----------------------------------------------------------------------
#include <time.h>
#include "tree_node.h"
#include "redblack_node.h"

int NUM_TRANSFERS = 0;
int NUM_DATAUMS = 0;

double
Calc_Time(
		  const clock_t &t1,
		  const clock_t &t2
		  );

int main(int argc, char* argv[])
{
	ofstream oFile( "output.txt", ios::out );
	char buffer[256];
	clock_t t1, t2;
	for( int iter = 0; iter < 2; ++iter )
	{
		switch( iter )
		{
		case 0:
			argv[1] = strdup("1000words.txt");
			break;
		case 1:
			argv[1] = strdup("10000words.txt");
			break;
		case 2:
			argv[1] = strdup("100000words.txt");
			break;
		case 3:
			argv[1] = strdup("1000000words.txt");
			break;
		default:
			break;
		}
		ifstream iFile( argv[1], ios::in );
		tree_node *tree = new tree_node(), 
			*node;
		t1 = clock();
		while( iFile >> buffer )
		{
			node = new tree_node();
			node->set_Data( buffer );
			tree->Tree_Insert( tree, node );
		}
		t2 = clock();
		oFile << endl << "Test Results for " << argv[1] << " input:" << endl
			<< "It took " << NUM_TRANSFERS << " data transfers "
			<< "to complete the binary-search tree." << endl
			<< "It took " << Calc_Time( t1, t2 ) << " seconds to build the a full tree." << endl;
		t1 = clock();
		tree->Inorder_Tree_Walk( tree );
		t2 = clock();
		oFile << "It took " << Calc_Time( t1, t2 ) << " seconds to traverse the tree." << endl;
		if( iter == 0 )
			argv[2] = strdup("sideline");
		else
			argv[2] = strdup("inaccuracies");
		t1 = clock();
		tree->Tree_Search( tree, argv[2] );
		t2 = clock();
		oFile << "It took " << Calc_Time( t1, t2 ) << " seconds to lookup \"" << argv[2] 
			  << "\"." << endl
			  << "When two items had the same value while doing the insertion, it caused a" << endl
			  << "data colision, and the copy causing the collision was thrown out." << endl;
		for( int iteration = 0; iteration < NUM_DATAUMS / 2; ++iteration )
			tree->Tree_Delete( tree, tree->get_Right() );
		t1 = clock();
		tree->Inorder_Tree_Walk( tree );
		t2 = clock();
		oFile << "After roughly half the items are deleted, it takes " << Calc_Time( t1, t2 ) 
			<< " seconds to traverse the tree." << endl
			<< "For the timer's precion, there is definitely a difference in traversal time."
			<< endl;
	}
	for( int iter = 0; iter < 4; ++iter )
	{
		switch( iter )
		{
		case 0:
			argv[1] = strdup("1000words.txt");
			break;
		case 1:
			argv[1] = strdup("10000words.txt");
			break;
		case 2:
			argv[1] = strdup("100000words.txt");
			break;
		case 3:
			argv[1] = strdup("1000000words.txt");
			break;
		default:
			break;
		}

		ifstream iFile( argv[1], ios::in );
		redblack_node *tree = new redblack_node(),
			*node;
		t1 = clock();
		while( iFile >> buffer )
		{
			node = new redblack_node();
			node->set_Data( buffer );
			tree->RB_Insert( tree, node );
		}
		iFile.close();
		t2 = clock();
		oFile << endl << "Test Results for " << argv[1] << " input:" << endl
			<< "It took " << NUM_TRANSFERS << " data transfers "
			<< "to complete the Red-Black tree." << endl
			<< "It took " << Calc_Time( t1, t2 ) << " seconds to build the a full tree." << endl;
		t1 = clock();
		tree->Inorder_Tree_Walk( tree );
		t2 = clock();
		oFile << "It took " << Calc_Time( t1, t2 ) << " seconds to traverse the tree." << endl;
		if( iter == 0 )
			argv[2] = strdup("sideline");
		else
			argv[2] = strdup("inaccuracies");
		t1 = clock();
		tree->Tree_Search( tree, argv[2] );
		t2 = clock();
		oFile << "It took " << Calc_Time( t1, t2 ) << " seconds to lookup \"" << argv[2] 
			  << "\"." << endl
			  << "When two items had the same value while doing the insertion, it caused a" << endl
			  << "data colision, and the copy causing the collision was thrown out." << endl;
		for( int iteration = 0; iteration < NUM_DATAUMS / 2; ++iteration )
			tree->RB_Delete( tree, tree->get_Right() );
		t1 = clock();
		tree->Inorder_Tree_Walk( tree );
		t2 = clock();
		oFile << "After roughly half the items are deleted, it takes " << Calc_Time( t1, t2 ) 
			<< " seconds to traverse the tree." << endl
			<< "For the timer's precion, there is not a noticable in traversal time." << endl;
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