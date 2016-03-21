#include <iostream>
using namespace std;
int main() {
	const double NORMAL = 98.6; //degrees in Fahrenheit
	double temperature;

	cout << "Enter your temperature: ";
	cin >> temperature;

	if (temperature > NORMAL) {
		cout << "You have a fever.\n"
			<< "Drink lots of liquids (preferably water) and get to bed.\n";
	}
	else {
		cout << "You don't have a fever.\n"
			<< "Go study.\n";
	}
	return 0;
}