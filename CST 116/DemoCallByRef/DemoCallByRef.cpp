/***********************************************************
* Author:			Matthew Klump
* Date Created:		Nov. 4, 2001
* Last Modification Date:	Nov. 4, 2001
* Project:			DemoCallByRef
* Filename:			DemoCallByRef.cpp
*
* Overview
*   Program to call functions that will Demonstrate call-by-
*	reference-parameters. It will Read in two nubmers, swap,
*	the two number, and then print the numbers to the screen
*	in the reversed order. This problem is from "Problem 
*	Solving with C++", by Walter Savitch, page 184-185
*	(Display 4.4)
* Input:
*   Get_Numbers reads in exactly two numbers.
* Output:
*   Function Show_Results prints a message showing the number
*	in the reverse order.
*
***********************************************************/

#include <iostream>

void Get_Numbers(int& input1, int& input2);
//Read two integers from the key board

void Swap_Values(int& variable1, int& variable2);
//Interchange the values of variable1 and variable2.

void Show_Results(int output1, int output2);
//Show the values of variable1 and variable2, in that order.

int main() {

	int first_num, second_num;

	Get_Numbers(first_num, second_num);
	Swap_Values(first_num, second_num);
	Show_Results(first_num, second_num);
	return 0;
}

//Uses iosteam:
void Get_Numbers(int& input1, int& input2) {

	using namespace std;
	cout << "Enter two integers: ";
	cin >> input1 >> input2;
}

void Swap_Values(int& variable1, int& variable2) {

	int temp = variable1;
	variable1 = variable2;
	variable2 = temp;
}

//Uses iostream:
void Show_Results(int output1, int output2) {

	using namespace std;
	cout << "In reverse order the numbers are: "
		<< output1 << " " << output2 << endl;
}