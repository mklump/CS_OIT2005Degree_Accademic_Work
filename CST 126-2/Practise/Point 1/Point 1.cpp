//--------------------------------------------------------------------
// Author:        P. Hannan 
// Date Created:    4 Mar 2002
// Last Change Date:  
// Project:        Overloaded Operator Hands On
// Filename:       
//
// Overview:       This object represnts a point on a graph
//   
// Input:          User inputs x and y
//   
// Output:         A nice printout of the point.
//   
//--------------------------------------------------------------------

#include <iostream>
	using namespace std;
// Note:  Normally I would make a .h and a .cpp for the point object.
class Point {
	public :
		Point() : m_x(0), m_y(0) {};
		Point(const int & x, const int & y) : m_x(x), m_y(y) {};
		friend Point operator+(const Point &lhs, const Point & rhs);
		friend ostream & operator << (ostream & lhs, const Point & rhs);
	protected : 
		int m_x, m_y;
};
class ThreeDPoint : public Point {
	public :
		ThreeDPoint() : m_z(0) {m_x = 0;m_y = 0;};
		ThreeDPoint(const int & x, const int & y, const int & z = 0) 
			: m_z(z) {m_x = x;m_y = y;};
		friend ThreeDPoint operator+(const ThreeDPoint &lhs, const ThreeDPoint & rhs);
		friend ostream & operator << (ostream & lhs, const ThreeDPoint & rhs);

	private:
		int m_z;		

};

//--------------------------------------------------------------------
// Prototypes


//--------------------------------------------------------------------

void main (void)
{
	int x, y;
	cout << "Enter your x coordinate" << endl;
	cin >> x;
	cout << "Enter your y coordinate" << endl;
	cin >> y;
	
	// 2-D (two dimensional) Points
	Point p1(x,y);
	Point p2;        // Notice I didnt do p2();
	Point p3(0,2);
	Point result;
	
	cout << "Your point is: " << p1 << endl;
	cout << p1 << " + " << p2 << " = " << p1 + p2 << endl;
	result = p1 + p3;
	cout << p1 << " + " << p3 << " = " << result << endl;
    char ret(0);
	cin.get(ret);
}

//--------------------------------------------------------------------
// Point Functions
//--------------------------------------------------------------------
// Adding to points together means adding the two component parts together.
Point operator+(const Point &lhs, const Point & rhs)
{
	Point temp;
	temp.m_x = lhs.m_x + rhs.m_x;
	temp.m_y = lhs.m_y + rhs.m_y;
	
	return temp;
}
//  Points print as (x,y)
ostream & operator << (ostream & lhs, const Point & rhs) {
	lhs << "(" << rhs.m_x << "," << rhs.m_y << ")";
	return (lhs);
}
//--------------------------------------------------------------------
// ThreeDPoint Functions
//--------------------------------------------------------------------
// Adding to ThreeDPoints together means adding the three component parts together.
ThreeDPoint operator+(const ThreeDPoint &lhs, const ThreeDPoint & rhs)
{
	ThreeDPoint temp;
	temp.m_x = lhs.m_x + rhs.m_x;
	temp.m_y = lhs.m_y + rhs.m_y;
	temp.m_z = lhs.m_z + rhs.m_z;
	
	return temp;
}
//  Points print as (x,y)
ostream & operator << (ostream & lhs, const ThreeDPoint & rhs) {
	lhs << "(" << rhs.m_x << "," << rhs.m_y << "," << rhs.m_z << ")";
	return (lhs);
}
