/***********************************************************
* Author:			Matthew Klump
* Date Created:		Oct. 27, 2001
* Last Modification Date:	Oct. 27, 2001
* Project:			Clothing Size
* Filename:			Clothing Size.cpp
*
* Overview
*   Program to call functions that will GetInput from user
*	for height, weight, and age; Calculate the user's HatSize;
*	Calculate the user's JacketSize; Calculate the user's
*	WaistSize; Call function to SetPrecision to one decimal place
*	for ShowOutput; The last function will display the user's
*	HatSize, JacketSize, and WaistSize. This problem is from 
*	"Problem Solving with C++", by Walter Savitch, page 170
*	(Project 8)
* Input:
*   Function GetInput asks for the user's height, weight, and age.
* Output:
*   Function ShowOutput prints a message showing the user's 
*	HatSize, JacketSize, and WaistSize
*
***********************************************************/
#include <iostream>

void Introduction(void);
//Postcondition: Desription of program is written to the screen.

void GetInput(double& height, double& weight, double& age);
/*Precondition: User is ready to enter values correctly.
  Postcondition: The value of height has been set equal the user's
  height in inches. The value of weight has been set equal to the user's
  weight in pounds. The value of age has been set equal to the user's
  age in years.*/

double HatSize(double weight_, double height_);
/*Precondition: weight is the weight of the user in pounds; height
  is the user's height in inches.
  Returns the hat size of the user*/

double JacketSize(double weight_, double height_, double age_);
/*Precondition: weight is the user's weight in pounds; height is the
  user's height in inches; age is the user's age.
  Returns the Jacket Size of the user.*/

double WaistSize(double weight_, double age_);
/*Precondition: weight is the user's weight in pounds; age is the user's
  age in years.
  Returns the WaistSize of the user.*/

void SetPrecision(void);

void ShowOutput(double height_,double weight_,double age_,
				double hatsize,double jacketsize,double waistsize);
/*Postcondition: Functions HatSize, JacketSize, and WaistSive are called
  to calculate the numbers, and are then printed to the screen.*/

void main(void) {
	using namespace std;
	double height_, weight_, age_;
	Introduction();
	GetInput(height_, weight_, age_);
	double hatsize = HatSize(weight_, height_);
	double jacketsize = JacketSize(weight_ , height_, age_);
	double waistsize = WaistSize(weight_ , age_);
	ShowOutput(height_, weight_, age_, hatsize, jacketsize, waistsize);
}

void Introduction(void) {
	using namespace std;
	cout << "This program will calculate your clothing sizes for\n"
		<< "your hat size, your jacket size, and your waist size by\n"
		<< "asking for three vital statistics, and then showing the\n"
		<< "calculated results of your measurements.\n";
}

void GetInput(double& height, double& weight, double& age) {
	using namespace std;
	cout << "Please type a number for your height in inches and press enter: ";
	cin >> height;
	cout << "Please type a number for your weight in pounds and press enter: ";
	cin >> weight;
	cout << "Please type a number for your age in years and press enter: ";
	cin >> age;
}

double HatSize(double weight_, double height_) {
	return (weight_ / height_) * 2.9;
}

double JacketSize(double weight_, double height_, double age_) {
	double adjustment1;
	if (age_ > 39) {
		if (age_ == 40)
			adjustment1 = 0.125;
		else 
			adjustment1 = ((age_ - 40.0) / 10.0) * 0.125;
		return ((height_ * weight_) / 288.0) + adjustment1;
	}
	else
		return (height_ * weight_) / 288.0;
}

double WaistSize(double weight_, double age_) {
	if (age_ > 29)
		return (weight_ / 5.7) + ((age_ - 28.0) / 2.0) * 0.1;
	else
		return weight_ / 5.7;
}

void ShowOutput(double height_,double weight_,double age_,
				double hatsize,double jacketsize,double waistsize) {
	using namespace std;
	SetPrecision();
	cout << "\nYou entered " << weight_ << " for your weight,\n"
		<< height_ << " for your height, and " << age_ << " for your age.\n\n"
		<< "Your measurements are " << hatsize << " for your hat size, \n"
		<< jacketsize << " for your jacket size, and \n" << waistsize << " for your waist size.\n";
}

void SetPrecision(void) {
	using namespace std;
	cout.setf(ios::fixed);
	cout.setf(ios::showpoint);
	cout.precision(1);
}