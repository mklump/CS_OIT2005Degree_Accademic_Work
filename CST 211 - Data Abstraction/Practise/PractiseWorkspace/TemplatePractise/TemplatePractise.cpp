#include <iostream>

using std::cout;
using std::endl;

template< class T >
double Max(const T& num1, const T& num2)
{
	if (num1 > num2)
		return num1;
	else
		return num2;
}

int main(void)
{
	cout << "Here is the max for integers: " << Max(1, 2) << endl
		<< "Here is the max for doubles: " << Max(1.23, 2.34) << endl;
	return 0;
}

double Max(const int& num1, const int& num2)
{
	if (num1 > num2)
		return num1;
	else
		return num2;
}

double Max(const double& num1, const double& num2)
{
	if (num1 > num2)
		return num1;
	else
		return num2;
}

