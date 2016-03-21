//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   2 March 2002
// Last Change Date:  
// Project:        Lab 4 Defining Colors
// Filename:       colors.cpp
//
// Overview:  This include contains the colors object implementation.
//     
//--------------------------------------------------------------------

#include "colors.h"

Color::Color()
{
	Red_Part = 255;
	Green_Part = 255;
	Blue_Part = 255;
}

Color::Color(int color1, int color2)
{
	cout << "Please enter exactly three numbers to properly define the color.\n"
		<< "Press the enter key to continue.";
	char ret(0);
	cin.get(ret);
}

Color::Color(int red, int green, int blue)
{
	if (Red_Part < 0) Red_Part = 0;
	if (Green_Part < 0) Green_Part = 0;
	if (Blue_Part < 0) Blue_Part = 0;
	if (red > 255) Red_Part = 255;
	if (red < 0) Red_Part = 0;
	if (green > 255) Green_Part = 255;
	if (green < 0) Green_Part = 0;
	if (blue > 255) Blue_Part = 255;
	if (blue < 0) Blue_Part = 0;
	if (red >= 0 && red <= 255) Red_Part = red;
	if (green >= 0 && green <= 255) Green_Part = green;
	if (blue >= 0 && blue <= 255) Blue_Part = blue;
}

Color operator + (const Color& lhs, const Color& rhs)
{
	Color temp;
	temp.Blue_Part = lhs.Blue_Part + rhs.Blue_Part;
	temp.Green_Part = lhs.Green_Part + rhs.Green_Part;
	temp.Red_Part = lhs.Red_Part + rhs.Red_Part;
	temp = Color(temp.Blue_Part, temp.Green_Part, temp.Red_Part);
	return temp;
}

Color operator - (const Color& lhs, const Color& rhs)
{
	Color temp;
	if (lhs < rhs) Swap(lhs, rhs);

	temp.Blue_Part = lhs.Blue_Part - rhs.Blue_Part;
	temp.Green_Part = lhs.Green_Part - rhs.Green_Part;
	temp.Red_Part = lhs.Red_Part - rhs.Red_Part;
	temp = Color(temp.Blue_Part, temp.Green_Part, temp.Red_Part);
	return temp;
}

bool operator < (const Color& lhs, const Color& rhs)
{
	int sumlhs, sumrhs;
	sumlhs = lhs.Blue_Part + lhs.Green_Part + lhs.Red_Part;
	sumrhs = rhs.Blue_Part + rhs.Green_Part + rhs.Red_Part;
	return(sumlhs < sumrhs);
}

ostream& operator << (ostream& lhs, const Color& rhs)
{
	lhs.precision(0);
	lhs << "R = " << rhs.Red_Part << ", G = " 
		<< rhs.Green_Part << ", B = " << rhs.Blue_Part;
	return lhs;
}

void Swap(Color cl1, Color cl2)
{
	Color temp;
	temp = cl1;
	cl1 = cl2;
	cl2 = temp;
}