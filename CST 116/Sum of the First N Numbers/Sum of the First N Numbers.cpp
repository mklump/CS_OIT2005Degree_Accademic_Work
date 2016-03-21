#include <iostream>
using namespace std;

void main(void)
{
	//accept the limit
	unsigned long limit;
	cout << "Enter the limit: ";
	cin >> limit;
	//find the sum
	unsigned long index=1, sum=0;
	while (index<=limit) {
		sum += index;
		index++;
	}
	//display the sum
	cout << "The sum is: " << sum << endl;
}
