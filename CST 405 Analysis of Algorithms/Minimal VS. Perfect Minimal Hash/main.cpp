//---------------------------------------------------------------------
// Author:         Matthew Klump for CST 405 Analysis of Algorithms
// Date Created:   29 July 2003
// Last Change Date:  31 July 2003
// Project:        Minimal VS. Perfect Minimal Hash
// Filename:       main.cpp
//
// Overview:  Driver program for the minimal_hash and perfect_minimal
//			  classes.
// Input:  Input is accepted one of four input text files containing
//		   randomized words, and they are:
//		   1000words.txt
//		   10000words.txt
//		   100000words.txt
//		   1000000words.txt
//
// Output: The output for this program is printed to a file "output.txt"
//   
//----------------------------------------------------------------------
#include "perfect_minimal.h"

int	NUM_TRANSFERS = 0,
	NUM_DATAUMS = 0;

double
Calc_Time(
		  const clock_t &t1,
		  const clock_t &t2
		  );

int main(int argc, char* argv[])
{
	ofstream oFile( "output.txt", ios::app );
	char buffer[256];
	clock_t t1, t2;

	// Get the current state of the flag
	// and store it in a temporary variable
	int tmpFlag = _CrtSetDbgFlag( _CRTDBG_REPORT_FLAG );

	// Turn On (OR) - Keep freed memory blocks in the
	// heap's linked list and mark them as freed
	tmpFlag |= _CRTDBG_DELAY_FREE_MEM_DF;

	// Turn Off (AND) - prevent _CrtCheckMemory from
	// being called at every allocation request
	tmpFlag |= _CRTDBG_CHECK_ALWAYS_DF;
	tmpFlag |= _CRTDBG_ALLOC_MEM_DF;
	//_CrtSetDbgFlag( _crtDbgFlag = _CRTDBG_ALLOC_MEM_DF );

	// Set the new state for the flag
	_CrtSetDbgFlag( tmpFlag );

	//for( int iter = 0; iter < 4; ++iter )
	//{
	//	ifstream iFile;
	//	minimal_hash *minimal = new minimal_hash( iFile );
	//	record *entry = NULL;

	//	t1 = clock();
	//	while( iFile >> buffer )
	//	{
	//		entry = minimal->Hash_Insert( minimal->Get_Table(), buffer );
	//	}
	//	t2 = clock();
	//	oFile << endl << "Test Results for " 
	//		<< minimal->Get_InputFile() << " inputfile:"
	//		<< endl << "It took " << NUM_TRANSFERS << " data transfers "
	//		<< "to complete building the hash table." << endl
	//		<< "It took " << Calc_Time( t1, t2 )
	//		<< " seconds to build the a full hash table." << endl;
	//	t1 = clock();
	//	minimal->Hash_Search( minimal->Get_Table(), entry );
	//	t2 = clock();
	//	oFile << "It took " << Calc_Time( t1, t2 )
	//		<< " seconds to lookup a data"
	//		<< " item within the hash table." << endl;

	//	entry = new record;
	//	t1 = clock();
	//	minimal->Hash_Search( minimal->Get_Table(), entry );
	//	t2 = clock();
	//	oFile << "It took " << Calc_Time( t1, t2 )
	//		<< " seconds to lookup a data item not " 
	//		<< "within the table." << endl;
	//	for( int iteration = 0; iteration < NUM_DATAUMS / 2; ++iteration )
	//	{
	//		entry = minimal->Get_Table()[iteration];
	//		minimal->Hash_Delete( minimal->Get_Table(), entry );
	//	}
	//	entry = new record;
	//	t1 = clock();
	//	minimal->Hash_Search( minimal->Get_Table(), entry );
	//	t2 = clock();
	//	oFile << "After roughly half the items are deleted, " 
	//		<< "it takes " << Calc_Time( t1, t2 ) 
	//		<< " seconds to traverse the table." << endl
	//		<< "For the timer's precion, there is not a " 
	//		<< "noticable in traversal time." << endl;
	//}
	//oFile << "When two items had the same value"
	//	<< " while doing the insertion, it caused a" << endl
	//	<< "data colision, and the copy causing the " 
	//	<< "collision was chained on to that " << endl
	//	<< "slot's linked list head." << endl;

	for( int iter = 0; iter < 4; ++iter )
	{
		ifstream in;
		perfect_minimal *perfect = new perfect_minimal( in );
		record *entry = NULL;

		t1 = clock();
		while( in >> buffer )
		{
			entry = perfect->Hash_Insert( perfect->Get_Table(), buffer );
		}
		t2 = clock();
		oFile << endl << "Test Results for " 
			<< perfect->Get_InputFile() << " inputfile:"
			<< endl << "It took " << NUM_TRANSFERS << " data transfers "
			<< "to complete building the hash table." << endl
			<< "It took " << Calc_Time( t1, t2 )
			<< " seconds to build the a full hash table." << endl;
		t1 = clock();
		perfect->Hash_Search( perfect->Get_Table(), entry );
		t2 = clock();
		oFile << "It took " << Calc_Time( t1, t2 )
			<< " seconds to lookup a data"
			<< " item within the hash table." << endl;

		t1 = clock();
		perfect->Hash_Search( perfect->Get_Table(), entry );
		t2 = clock();
		oFile << "It took " << Calc_Time( t1, t2 )
			<< " seconds to lookup a data item not " 
			<< "within the table." << endl;
		for( int iteration = 0; iteration < NUM_DATAUMS / 2; ++iteration )
		{
			entry = perfect->Get_Table()[iteration][ 0 ];
			perfect->Hash_Delete( perfect->Get_Table(), entry );
		}
		entry = new record;
		t1 = clock();
		perfect->Hash_Search( perfect->Get_Table(), entry );
		t2 = clock();
		oFile << "After roughly half the items are deleted, " 
			<< "it takes " << Calc_Time( t1, t2 ) 
			<< " seconds to traverse the table." << endl
			<< "For the timer's precion, there is not a " 
			<< "noticable in traversal time." << endl;
	}
	oFile << "When two items had the same value"
		<< " while doing the insertion, it caused a" << endl
		<< "data colision, and the copy causing the " 
		<< "collision was chained on to that " << endl
		<< "slot's linked list head." << endl;
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
