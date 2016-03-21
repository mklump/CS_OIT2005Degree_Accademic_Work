//--------------------------------------------------------------------
// Author:        P. Hannan 
// Date Created:    4 Mar 2002
// Last Change Date:  
// Project:        Inheritance Hands on
// Filename:       
//
// Overview:       This program has objects to represent students
//   
// Input:          None
//   
// Output:         Some student samples:
//   
//--------------------------------------------------------------------

#include <iostream>
#include <string>
	using namespace std;

// Note:  Normally I would make a .h and a .cpp for the objects
class Student {
	public:
		Student() : m_name(""), m_gpa(0.0) {};
		Student(const string & name, const double & gpa = 0.0) 
	    	: m_name(name), m_gpa(gpa) {};
		//friend ostream & operator<< (ostream & lhs, const Student & rhs);
	protected :
		string m_name;
		double m_gpa;
};

class GradStudent : public Student {
	public:
		GradStudent() {};
		GradStudent(const string & name, const double & gpa = 0.0, 
		                                 const double & stipend=0.0) 
		    {m_name = name; m_gpa = gpa; m_stipend = stipend;};
	    
    	friend ostream & operator<< (ostream & lhs, const GradStudent & rhs);

	private:
		//string m_name; //inherited
		//double m_gpa;  //inherited
		double m_stipend;
};


//--------------------------------------------------------------------

void main (void)
{
	Student chaz("Charlie",3.36);
	Student bess("Bess",3.5);
	GradStudent parker("Parker", 3.8);
	GradStudent joe("Joe", 3.5,2000.0);
	
	cout << "--- STUDENTS -- " << endl;
	cout << chaz << endl;
	cout << bess << endl;
	cout << "--- GRAD STUDENTS -- " << endl;
	cout << parker << endl;
	cout << joe << endl;
    
}

//--------------------------------------------------------------------
// Functions
//--------------------------------------------------------------------
ostream & operator<< (ostream & lhs, const Student & rhs) 
{
	lhs << rhs.m_name << " " << rhs.m_gpa;
	return (lhs);
}
ostream & operator<< (ostream & lhs, const GradStudent & rhs) 
{
	lhs << rhs.m_name << " " << rhs.m_gpa;
	if (rhs.m_stipend != 0)
		lhs << " " << rhs.m_stipend;
	return (lhs);
}

