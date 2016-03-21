#include <iostream> 
#include <conio.h>
using namespace std;
int main()
{
	double package_weight;
	char ans;
	/*This c++ program will accept a given weight in ounces
	from the user for a cereal box. It will first convert the
	box's weight into tons, and then show how many cereal boxes
	it will take to weight a ton.*/

	do {
	//if (ans == 'y' || ans == 'Y')
		//clear();
		//clrscr();
	cout << "Please enter a number for the weight of a cereal\n"
		<< "box in ounces and press return:\n";
	cin >> package_weight;
	cout << "The weight of that cereal box in tons is: " << package_weight / 35273.92 << endl
		<< "\nThe number of cereal boxes it would take \n"
		<< "to yeild a ton is: " << 35273.92 / package_weight << endl << endl
		<< "Would you like to recalculate this with a different package weight?\n"
		<< "Press y for yes or any other key to quit and then press enter: " << endl;
	cin >> ans;
	} while (ans == 'y' || ans == 'Y');
	return 0;
}