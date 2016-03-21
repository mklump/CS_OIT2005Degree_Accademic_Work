#include <iostream>
#include <math.h>
#include <cstdlib>
using namespace std;
/*This program was produced by Matthew Klump
on 10/13/01.*/

double factorial(double z) {
	double product = 1;
	while (z > 0) {
		product = z * product;
		z--;
	}
	return product;
}

int main() {
	double x, n=0, limit, sum=0;
	cout << "Please enter a limit value and a value for x to compute the infinite \n"
		<< "series of e^x = 1 + x + x^2/2!+x^3/3!...x^n/n! respectively: \n";
	cin >> limit;
	cin >> x;
	do {
		sum += (pow (x,n))/(factorial(n));
		n++;
		limit--;
	} while (limit >= 0);
	cout << "The computed value for the series is: " << sum << endl
		<< "Checking this, we see that: " << sum << " is equal to "
		<< exp(x) << endl << endl
		<< "Please note that a limit of 100 works the best.\n";
	return 0;
}
