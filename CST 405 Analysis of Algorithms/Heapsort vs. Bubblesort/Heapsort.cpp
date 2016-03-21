#include "Heapsort.h"

Heapsort::Heapsort(
				   const int &size
				   )
{
	A = new char*[size];
	for(int index = 0; index < MAX_ARRAYSIZE; ++index)
	{
		A[index] = new char[256];
		strcpy( A[index], "" );
	}
}

void
Heapsort::set_Heap(
				   ifstream &in
				   )
{
	in.clear();
	in.seekg( ios::beg );
	char entry[256];
	for( int index = 0; !in.eof() && index < MAX_ARRAYSIZE; ++index )
	{
		in >> entry;
		strcpy( A[index], entry );
	}
	in.clear();
	in.seekg( ios::beg );
}

void
Heapsort::Heap_sort(
					void
					)
{
	const int ONE = 1;
	char temp[256] = "";

	Build_Max_Heap( A );
	for( int index = MAX_ARRAYSIZE - 1; index > 0; --index )
	{
		strcpy( temp, A[0] );
		strcpy( A[0], A[index] );
		strcpy( A[index], temp );

		heap_size = heap_size - 1;
		Max_Heapify( A, ONE );
	}
}

void
Heapsort::Max_Heapify(
					  char *Array[],
					  const int &i
					  )
{
	int left = i - 1,
		right = i + 1;
	static int largest;
    char temp[256];

	if( left < 0 || right >= MAX_ARRAYSIZE )
		return;
	if( left <= heap_size && strcmp(Array[left], Array[i]) > 0 )
		largest = left;
	else
		largest = i;

	if( right <= heap_size && strcmp(Array[right], Array[largest]) > 0 )
		largest = right;

	if( largest != i )
	{
		strcpy( temp, Array[i] );			NUMBER_OF_TRANSFERS++;
		strcpy( Array[i], Array[largest] ); NUMBER_OF_TRANSFERS++;
		strcpy( Array[largest], temp );     NUMBER_OF_TRANSFERS++;

		Max_Heapify( Array, largest );
	}
}

void
Heapsort::Build_Max_Heap(
						 char *Array[]
						 )
{
	heap_size = MAX_ARRAYSIZE;
	for( int index = MAX_ARRAYSIZE / 2; index > 0; --index )
		Max_Heapify( Array, index );
}

void
Heapsort::Output_Max_Heap(
						  ofstream &out
						  )
{
	for( int index = 0; index < MAX_ARRAYSIZE; ++index )
		out << A[index] << endl;
}
