//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   2 March 2002
// Last Change Date:  
// Project:        Lab 4 Defining Colors
// Filename:       colors.h
//
// Overview:  This include contains the interface of a color object.
//     
//--------------------------------------------------------------------

#ifndef COLORS_H
#define COLORS_H

#include <iostream>
using namespace std;

class Color
{
public:
	//Constructor to set the class default to white.
	Color();

	//Constructor for two arguement checking.
	Color(int color1, int color2);

	//Constructor to set the range of acceptable color values.
	Color(int red, int green, int blue);

	//Overloaded operator + to add two objects of type Color.
	friend Color operator + (const Color& lhs, const Color& rhs);

	//Overloaded operator - to subtract two objects of type Color.
	friend Color operator - (const Color& lhs, const Color& rhs);

	//Overloaded operator < will test if one color is darker than another.
	friend bool operator<(const Color& lhs, const Color& rhs);

	//Overloader operator << (insertion) will print out the color components
	friend ostream& operator << (ostream& lhs, const Color& rhs);

	//Swap Color values.
	friend void Swap(Color cl1, Color cl2);
private:
	int Red_Part,
		Green_Part,
		Blue_Part;
};

#endif // COLORS_H