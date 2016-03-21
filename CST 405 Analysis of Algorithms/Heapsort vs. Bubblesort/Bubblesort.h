#pragma once
#include <fstream>
#include <iostream>
using namespace std;

extern int MAX_ARRAYSIZE;
extern int NUMBER_OF_TRANSFERS;

class Bubblesort
{
public:
	Bubblesort(
			   const int &size
			   );
	~Bubblesort(
				void
				);

	void
	set_Bubblesort(
				   ifstream &in
				   );
	void
	Bubble_sort(
				void
				);
	void
	output_Data(
				ofstream &out
				);
	void
	reverse_Data(
				 void
				 );
private:
	char **Array;
};
