/***********************************************************
* Author:			Matthew Klump
* Date Created:		Oct. 31, 2001
* Last Modification Date:	Oct. 26, 2001
* Project:			Interest
* Filename:			Interest.cpp
*
* Overview
*   Program will compute the the interest due, amount due, and
*	the minimum payment for a given revolving credit account.
*	Re-rerunning the program is not implemented in this version.
* Input:
*   User inputs the account balance
* Output:
*   Message showing interest due, amount due, and minimum payment.
*
***********************************************************/

#include <iostream>
#include <math.h>
using namespace std;
void main(void) {
	double balance, interest, amount_due, minimum_balance;

	cout << "\nPlease enter the account balance: $";
	cin >> balance;
	//calculate the interest
	if (balance > 1000)
		interest = balance*0.025;
	else
		interest = balance*0.015;
	//calculate the balnce
	amount_due = balance + interest;

	if (balance < 10)
		minimum_balance = balance;
	else {
		if (0.01*balance > 10)
			minimum_balance = 0.01*balance;
		else
			minimum_balance = 10; }
	//set decimal precision
	cout.setf(ios::fixed);
	cout.setf(ios::showpoint);
	cout.precision(2);
	//output the numbers
	cout << "The interest due is: $" << interest << endl
		<< "The amount due is: $" << amount_due << endl
		<< "The minimum payment is: $" << minimum_balance << endl;

}