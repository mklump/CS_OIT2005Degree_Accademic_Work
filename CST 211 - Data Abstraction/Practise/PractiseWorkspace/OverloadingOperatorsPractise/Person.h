//-------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #5
// Date Created:   June 1, 2002
// Last Change Date:  June 1, 2002
// Project:        Person Overloaded
// Filename:       CPerson.h
//
// Overview:  This include contains the interface for the
//			  CPerson class.
//
//-------------------------------------------------------------------

#if !defined(AFX_PERSON_H__A770496A_2683_4567_87E1_8078155EB4C5__INCLUDED_)
#define AFX_PERSON_H__A770496A_2683_4567_87E1_8078155EB4C5__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <time.h>
#include <assert.h>
#include <iostream>
using namespace std;

class CPerson
{
public:
	CPerson();
	CPerson(char *n, int a);
	virtual ~CPerson();

	inline void SetAge(int a) {Age = a;};
	inline int GetAge() {return Age;};

	inline void SetName(char *n) {strcpy(Name, n);};
	inline char * GetName() {return Name;};

	friend ostream& operator<<(ostream &, CPerson *);
	friend ostream& operator<<(ostream &, CPerson &);
	//insertion operators as a nonmember function

	void operator = (CPerson &);
	//assignment operator as a memberfunction

	friend bool operator == (CPerson &, CPerson &);
	//equality operator also a nonmemberfunction

	friend bool operator != (CPerson &, CPerson &);
	//equality operator as a nonmemberfunction

	bool operator ! () const;
	//not operator as a non-static member function
	
	operator int() const;
	//int cast operator as a non-static member function

	operator char *() const;
	//char * cast operator as a non-static member function
private:
	int Age;
	char Name[128];
};

#endif // !defined(AFX_PERSON_H__A770496A_2683_4567_87E1_8078155EB4C5__INCLUDED_)
