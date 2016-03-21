#include <iostream>
using namespace std;

void main(void) {
	char ans;
	int x;
	do {
		cout << "Enter a char: ";
		cin >> x;
		cout << x << endl;
		cout << "Execute again? Press y for yes or any other key to quit: ";
		cin >> ans;
	} while (ans == 'y' || ans == 'Y');
}

