/***********************************************************
* Author:			Sun Murthy
* Date Created:		Oct. 17, 2001
* Last Modification Date:	Oct. 17, 2001
* Project:			Functions
* Filename:			charclassify.cpp
*
* Overview
*   Program to classify a character as digit/letter/other.
*	If the character is letter, further classify its case.
* Input:
*   User inputs a charcter
* Output:
*   Message clasifiying the input character
*
***********************************************************/
#include <iostream>
#include <cstdlib> 
using namespace std;

void main(void){
	// get a character from user
	char c;
	cout << "Enter a character: ";
	cin >> c;

	// classify character
	if (isdigit(c))
		cout << "You entered a digit";
	else if (isalpha(c))
		// a letter may be further classified based on its case
		if (islower(c))
			cout << "You entered a lower case letter";
		else
			cout << "You entered an upper case letter";
	else
		cout << "You entered a non-digit, non-letter character";

	// go to next line, no matter what we print above
	cout << endl;
}
