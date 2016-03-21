/***********************************************************
* Author:			Matthew Klump
* Date Created:			November 20, 2001
* Last Modification Date:	November 20, 2001
* Project:			ClassBankAccount
* Filename:			ClassBankAccount.cpp
*
* Overview
*   Program to demonstrate the use of a class to build
*	your program.
*   This program is taken from "Problem Solving with
*   C++", Walter Savitch, p. 330-332, 339-340 (display 6.5 & 6.6)
* Input:
*   The user Inputs their account balance & interest rate.
* Output:
*   The program outputs the acount information to a properly
*	constructed format.
*
***********************************************************/

//Program to demonstrate the class BankAccount.
#include <iostream>
using namespace std;

//Class for a bank account:
class BankAccount {
public:
	BankAccount(short dollars, short cents, float rate);
	//Initializes the account balance to $dollars.cents and
	//Initializes the interest rate to rate percent.

	BankAccount(short dollars, float rate);
	//Initializes the account balance to $dollars.00 and
	//Initializes the interest rate to rate percent.

	BankAccount();
	//Initializes the account balance to $0.00 and the interest rate to 0.0%.

	/* void Set(int dollars, int cents, double rate);
	//Postcondition: The account balance has been set to $dollars.cents;
	//The interest rate has been set to rate percent.
											
	void Set(int dollars, double rate);
	//Postcondition: The account balance has been set to $dollars.00.
	//The interest rate has been set to rate percent.

	void Update();
	//Postcondition: One year of simeple interest has been
	//added to the account balance.

	float GetBalance();
	//Returns the current account balance.

	float GetRate();
	//Returns the current account interest rate as a percent. */

	void Output(ostream& outs);
	//Precondition: If outs is a file output stream, then
	//outs has already been connected to a file.
	//Postcondition: Account Balance and interest rate have been written to the
	//stream outs.
private:
	float balance;
	float interest_rate;

	//float Fraction(float percent);
	//Converts a percent to a fraction, For example, Fraction(50.3) returns 0.503.
};

void main(void) {
	BankAccount account1(100, float (2.3)), account2;

	//cout << "Start of Test:\n"; This portion commented out 
	//for the code revision in display 6.6

	//account1.Set(123 , 99, 3.0);

	cout << "account1 initialized as follows:\n";
	account1.Output(cout);
	
	//account1.Set(100, 5.0);

	cout << "account2 initialized as follows:\n";
	account2.Output(cout);

	account1 = BankAccount(999, 99, 5.5);
	cout << "account1 reset to the following:\n";
	account1.Output(cout);

	/* account1.Update();
	cout << "account1 after update:\n";
	account1.Output(cout);              
							This portion of code commented out same as above.
	account2 = account1;
	cout << "account2:\n";
	account2.Output(cout); */
}

BankAccount::BankAccount(short dollars, short cents, float rate) {

	balance = dollars + 0.01*cents;
	interest_rate = rate;
}

BankAccount::BankAccount(short dollars, float rate) {

	balance = dollars;
	interest_rate = rate;
}

BankAccount::BankAccount() {

	balance = 0;
	interest_rate = 0.0;
}

void BankAccount::Output(ostream& outs) {

	outs.setf(ios::fixed);
	outs.setf(ios::showpoint);
	outs.precision(2);
	outs << "Account balance $" << balance << endl;
	outs << "Interest rate " << interest_rate << "%" << endl;
}

/* float BankAccount::Fraction(float percent) {

	return (percent/100.0);
}

float BankAccount::GetBalance() {

	return balance;
}

float BankAccount::GetRate() {

	return interest_rate;
}

void BankAccount::Update() {

	balance += Fraction(interest_rate)*balance;
}

void BankAccount::Set(int dollars, int cents, double rate) {

	balance = dollars + 0.01*cents;
	interest_rate = rate;
}

void BankAccount::Set(int dollars, double rate) {

	balance = dollars;
	interest_rate = rate;
} */