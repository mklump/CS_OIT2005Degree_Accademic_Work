#include <fstream>
#include <string>
#include <assert.h>

#pragma once

using namespace std;
extern int MAX_ARRAYSIZE;
extern int NUMBER_OF_TRANSFERS;

class Heapsort
{
public:
	Heapsort(
			 const int &size
			 );
	~Heapsort(void) { ; }

	char **
	get_Heap() { return A; }
	void
	set_Heap(
			 ifstream &in
			 );
	void
	Max_Heapify(
				char *Array[],
				const int &i
				); 
    void
	Build_Max_Heap(
				   char *Array[]
				   );
	void
	Heap_sort(
			  void
			  );
	void
	Output_Max_Heap(
					ofstream &out
					);
private:
	char **A;		// Array[] implementation of the heap
	int heap_size;	// Actual size of the heap
};
