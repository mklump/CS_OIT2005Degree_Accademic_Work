/***********************************************************
* Author:			Matthew Klump
* Date Created:		Oct. 20, 2001
* Last Modification Date:	Oct. 20, 2001
* Project:			calc_infl
* Filename:			calc_infl.cpp
*
* Overview
*   Program to call a function calc_infl to calcualtate the
*	inflation of an arbitrary item. Recalculation will not
*	be used. Calculate the Inflation for Assignment #3 page
*	169 problem #3 and #4
* Input:
*   User inputs item price a year ago, and item price today
* Output:
*   Message showing the inflation as a percent, the cost next
*	year and the cost two years from now
*
***********************************************************/
#include <iostream>
#include <cmath>
#include <cstdlib>

double calc_infl(double item_price_yearago, double item_price_today);
//calculates the inflation of the item in question for the year before.
double estimated_cost(double item_price_today, double inflation_rate);
//calculate the estimated cost of the item in question, in one year
void decimal_precision(int n);
//set the decimal precision to two places

void main(void) {
	using namespace std;

	double w, x, y, z;
	//input the variables
	cout << "Please input the price for the item a year ago: $";
	cin >> x; 
	cout << "\nPlease input the price for the item today: $";
	cin >> y;
	decimal_precision(2);
	if (y > x) {
		z = calc_infl(x,y);
	}
	else {
		z = -calc_infl(x,y);
	}
	cout << "\nThe inflation for the item between then and now is: "
		<< z << "%\n";
	w = estimated_cost(y,z)+estimated_cost(y,z)*(z/100);
	cout << "\nThe estimated price one year"
		<< "\nfrom now and two years from now is: $"
		<< estimated_cost(y,z) << " and $" << w << endl << "Pvrovided "
		<< "all other economic factors \nremain the same." << endl;
}

double calc_infl(double item_price_yearago, double item_price_today) {
	double inflation = (fabs(item_price_today-item_price_yearago) / item_price_yearago);
	return inflation*100;
}

void decimal_precision(int n) {
	using namespace std;

	cout.setf(ios::fixed);
	cout.setf(ios::showpoint);
	cout.precision(n);
}

double estimated_cost(double item_price_today, double inflation_rate) {
	using namespace std;

	inflation_rate = inflation_rate / 100.0;
	double totalprice_oneyear = item_price_today+(item_price_today * inflation_rate);
	
	return (totalprice_oneyear);
}