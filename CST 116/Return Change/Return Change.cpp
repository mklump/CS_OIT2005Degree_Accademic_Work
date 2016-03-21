/***********************************************************
* Author:			Matthew Klump
* Date Created:		Nov. 5, 2001
* Last Modification Date:	Nov. 5, 2001
* Project:			Return Change
* Filename:			Return Change.cpp
*
* Overview
*   Program to call functions that will comput the amount of
*	quarters, dimes, and pennies from a given amount of cents
*	from the user within 1 to 99. Then the amount of quarters
*	dimes and pennies is outputed to the screen. This problem 
*	is from "Problem Solving with C++", by Walter Savitch, 
*	page 216 - 217. (Programming Project 3)
* Input:
*   GetInput reads in a number for the cents amount from the
*	user.
* Output:
*   Function ShowOuput prints a message to the screen showing 
*	the amount of quarters, dimes, and pennies.
*
***********************************************************/

#include <iostream>

const int QUARTER = 25;
const int DIME = 10;

void Introduction(void);
//Postcondition: Description of program is written to the screen.

void GetInput(int& cents);
//Precondition: User is ready to enter value correctly.

void ComputeQuarters(int& quarters, int& amount_left);
/*Precondition: number is the amount of quarters needed;
  amount_left is the amount of cents remaining after needed
  quarters is computed.*/

void ComputeDimes(int& dimes, int& amount_left);
/*Precondition: number is the amount of dimes needed;
  amount_left is the amount of cents remaining after needed
  dimes is computed.*/

void ShowOutput(int cents, int quarters, int dimes, int pennies);
/*Precondition: cents is the amount of cents the user entered;
  quarters is the amount of quarters needed; dimes is the amount
  of dimes needed; pennies is the amount of pennies needed.*/

void main(void) {

	int amount_left, quarters, dimes, pennies;

	Introduction(); //display what the program will do
	
	GetInput(amount_left); //get the user's input

	int cents = amount_left; //store amount_left into cents for ouput later
	
	ComputeQuarters(quarters, amount_left); //compute the quarters needed
	
	ComputeDimes(dimes, amount_left); //compute the dimes needed

	pennies = amount_left;  //the amount_left must be the pennies left over

	ShowOutput(cents, quarters, dimes, pennies); //now show the output
}

//Uses iostream:
void Introduction(void) {
	
	using namespace std;
	cout << "This program accepts a number from you that is from\n"
		<< "1 to 99 for the amount of cents, and will display for\n"
		<< "you your change in quarters, dimes, and pennies.\n\n";
}

//Uses iostream:
void GetInput(int& cents) {

	using namespace std;
	cout << "Please enter the amount of cents to calculate: ";
	cin >> cents;
	int x = 1;
	while(x < 0) {
		cout << x;
		x++;
	}
}

//Uses constant QUARTER:
void ComputeQuarters(int& quarters, int& amount_left) {

	quarters =  (int)amount_left / QUARTER;
	amount_left -= (quarters * QUARTER);
}

//Uses constant DIME:
void ComputeDimes(int& dimes, int& amount_left) {

	dimes = (int)amount_left / DIME;
	amount_left -= (dimes * DIME);
}

//Uses iostream:
void ShowOutput(int cents, int quarters, int dimes, int pennies) {

	using namespace std;
	cout << "\nYou entered " << cents << " to make change for:\n\n"
		<< "That makes " << quarters << " quarter(s), " << dimes
		<< " dime(s), and " << pennies << " penny(pennies).\n";
}