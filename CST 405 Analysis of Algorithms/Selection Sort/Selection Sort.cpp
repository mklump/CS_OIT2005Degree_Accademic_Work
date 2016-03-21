// Selection Sort.cpp : Defines the entry point for the console application.

int main(int argc, char* argv[])
{
	int arrayA[10] = { 23, 35, 75, 12, 46, 8, 87, 52, 27, 5 },
		smallest = 0;

	for( int h = 0; h < sizeof(arrayA)/sizeof(arrayA[0]); ++h )
	{
		for( int j = h + 1; j < sizeof(arrayA)/sizeof(arrayA[0]); ++j )
		{
			if( arrayA[ j ] < arrayA[ smallest ] )
				smallest = j;
		}
		
		int temp = arrayA[h];
		arrayA[h] = arrayA[smallest];
		arrayA[smallest] = temp;
	}
	return 0;
}
