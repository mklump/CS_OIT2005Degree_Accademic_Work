/***********************************************************
* Author:			Matthew
* Date Created:			November 10, 2001
* Last Modification Date:	November 10, 2001
* Project:			Chapter 6 A Structure Definition
* Filename:			CDAcount.cpp
*
* Overview
*   Program to determine the new new balance for a given
*	CD account after maturity.
*   This program is taken from "Problem Solving with
*   C++", Walter Savitch, p. 302, 303, 307 (display 6.1)
* Input:
*   The user Inputs their account balance, interest rate, and
*	term until maturity for their CD account.
* Output:
*   The program outputs the new balance after maturity.
*
***********************************************************/

//Program to demostrate the CDAccount structure type

#include <iostream>

using namespace std;

//Structure for a bank certificate of deposit:
struct CDAccount {

	float balance;
	float interest_rate;
	short term; //mounths until maturity
};

void Get_Data(CDAccount& the_account);
//Postcondition: the_account.balance and the_account.interest_rate
//have been given values that the user entered at the keyboard.

CDAccount Shrink_Wrap(float the_balance, float the_rate, short the_term);
//Postcondition: The values for the_balance, the_rate, and
//the term get assigned to the new instance of CDAccount
//with a structure tag of my_account when called.

int main() {
	CDAccount account, my_account;
	Get_Data(account);
	my_account = Shrink_Wrap(50000.00, 8.5,	11); //Put these values into the new instance of my_account

	float rate_fraction, interest;
	rate_fraction = account.interest_rate / 100.0;
	interest = account.balance * rate_fraction * (account.term / 12.0);
	account.balance = account.balance + interest;

	cout.setf(ios::fixed);
	cout.setf(ios::showpoint);
	cout.precision(2);
	cout << "\nWhen you CD matures in "
		<< account.term << " months,\n"
		<< "it will have a balance of $"
		<< account.balance << endl
		<< "\nThe values stored in the structure variable my_account \n"
		<< "of type CDAccount are :\n" << my_account.balance << ", " 
		<< my_account.interest_rate << ", " << my_account.term << endl << endl;
	return 0;
}

void Get_Data(CDAccount& the_account) {

	cout << "Enter account balance: $";
	cin >> the_account.balance;
	cout << "Enter account interest rate: ";
	cin >> the_account.interest_rate;
	cout << "Enter the number of months until maturity\n"
		<< "(must be 12 or fewer months): ";
	cin >> the_account.term;
}

CDAccount Shrink_Wrap(float the_balance,
					  float the_rate, short the_term) {
	CDAccount temp;
	temp.balance = the_balance;
	temp.interest_rate = the_rate;
	temp.term = the_term;
	return temp;
}