#include <fstream>
#include <iostream>
#include <time.h>
#include "Heapsort.h"
#include "Bubblesort.h"

using namespace std;

int MAX_ARRAYSIZE = 0;
int NUMBER_OF_TRANSFERS = 0;

// Heapsort vs. Bubblesort.cpp : Defines the entry point for the console application.
int main(int argc, char* argv[])
{
	char *filename = strdup( argv[1] ), buffer[256];
	clock_t t1, t2;
	double total_time;
	ifstream iFile(filename, ios::in);
	ofstream oFile("output.txt", ios::out);
	if( !iFile )
	{
		cout << "Error opening " << filename << endl;
		assert(0);
	}
	while( !iFile.eof() )
	{
		iFile >> buffer;
		MAX_ARRAYSIZE++;
	}

	/*Heapsort heapsort( MAX_ARRAYSIZE );
	
	heapsort.set_Heap( iFile );

	t1 = clock();
	heapsort.Heap_sort();
	t2 = clock();
	
	heapsort.Output_Max_Heap( oFile );*/

	Bubblesort bubblesort( MAX_ARRAYSIZE );
	bubblesort.set_Bubblesort( iFile );

	t1 = clock();
	bubblesort.Bubble_sort();
	t2 = clock();

	bubblesort.output_Data( oFile );

	total_time = (double)(t2 - t1) / (double)CLOCKS_PER_SEC / (double)1000.00;
	oFile << "Total time for " << MAX_ARRAYSIZE
		  << " Heapsort elements is " << total_time << " seconds using heapsort." << endl
		  << "Total number of data transfer for 1000 element is "
		  << NUMBER_OF_TRANSFERS << endl;

	iFile.close();
	oFile.close();
	return 0;
}
