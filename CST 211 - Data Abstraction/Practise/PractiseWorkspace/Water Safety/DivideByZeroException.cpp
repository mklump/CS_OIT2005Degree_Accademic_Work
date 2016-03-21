#include <iostream>

using std::cout;
using std::endl;

#include <new>

using std::bad_alloc;

int main()
{
	double *ptr[1000];

	try
	{
		for (int i = 0; i < 1000; i++)
		{
			ptr[ i ] = new double[ 5000000 ];
			cout << "Allocated 5000000 doubles in ptr[ " << i << " ]\n";
		}
	}
	catch ( bad_alloc exception )
	{
		cout << "Exception occurred: " << exception.what() << endl;
	}

	return 0;
}
