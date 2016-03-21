#include <iostream>
using namespace std;
int main()
{
	/*This program claculates the payrate for a
	company employee. This is completed by Matthew
	Klump on October 12, 2001 for CST 116; All rights
	resevered, All commented code line included.*/

	double hours, dependents, gross_pay, net_pay, soc_secur, federal, state, ud=10;
	const double pay_rate=16.78;
	cout << "Please input the hours worked and the number of\n"
		<< "dependents respectively and press enter after each:\n";
	//Get the inputs
	cin >> hours;
	cin >> dependents;

	//Calculate the pay
	if (hours > 40)
		gross_pay = (pay_rate*40)+(hours-40)*(pay_rate*1.5);
	else
		gross_pay = pay_rate*hours;

	soc_secur=gross_pay*0.06; federal=gross_pay*0.14;
	state=gross_pay*0.05;
	net_pay=gross_pay-soc_secur-federal-state-ud;
	if (dependents >= 3)
		net_pay -= 35;
	//set the decimal precision to two places
	cout.setf(ios::fixed);
	cout.setf(ios::showpoint);
	cout.precision(2);

	cout << "The gross pay for the week is: $" << gross_pay << endl
		<< "The withholding for social security is: $" << soc_secur << endl
		<< "The withholding for federal tax is: $" << federal << endl
		<< "The withholding for state tax is: $" << state << endl
		<< "In consideration of dependent healthcare and\n"
		<< "union dues, your take home pay for the week is: $" << net_pay << endl;
	return 0;
}