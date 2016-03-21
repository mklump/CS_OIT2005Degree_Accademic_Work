#include "bubblesort.h"

Bubblesort::Bubblesort(
					   const int &size
					   )
{
	Array = new char*[size];
	for(int index = 0; index < MAX_ARRAYSIZE; ++index)
	{
		Array[index] = new char[256];
		strcpy( Array[index], "" );
	}
}

Bubblesort::~Bubblesort(
						void
						)
{
}

void
Bubblesort::set_Bubblesort(
						   ifstream &in
						   )
{
	in.clear();
	in.seekg( ios::beg );
	char entry[256];
	for( int index = 0; !in.eof() && index < MAX_ARRAYSIZE; ++index )
	{
		in >> entry;
		strcpy( Array[index], entry );
	}
	in.clear();
	in.seekg( ios::beg );
}

void
Bubblesort::Bubble_sort(
						void
						)
{
	char temp[256];
	for( int x = 0; x < MAX_ARRAYSIZE; ++x )
	{
		for( int y = x + 1; y < MAX_ARRAYSIZE; ++y )
		{
			if( strcmp( Array[x], Array[y] ) > 0 )
			{
				strcpy( temp, Array[x] );		NUMBER_OF_TRANSFERS++;
				strcpy( Array[x], Array[y] );	NUMBER_OF_TRANSFERS++;
				strcpy( Array[y], temp );		NUMBER_OF_TRANSFERS++;
			}
		}
	}
}

void
Bubblesort::reverse_Data(
						 void
						 )
{
	char *temp[256];
	for( int x = 0, y = 0; x < MAX_ARRAYSIZE; ++x )
		temp[x] = strdup( Array[x] );
	for( x = MAX_ARRAYSIZE - 1; x >= 0; --x, ++y )
		strcpy( Array[y], temp[x] );
}

void
Bubblesort::output_Data(
						ofstream &out
						)
{
	for( int index = 0; index < MAX_ARRAYSIZE; ++index )
		out << Array[index] << endl;
}
