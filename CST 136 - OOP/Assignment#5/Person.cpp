//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #5
// Date Created:   June 1, 2002
// Last Change Date:  June 1, 2002
// Project:        Person Overload
// Filename:       Person.cpp
//
// Overview:  This include contains the implentation of the
//			  CPerson class.
//     
//--------------------------------------------------------------------

#include "Person.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CPerson::CPerson()
{
	strcpy(Name, "");
	Age = 0;
}

CPerson::CPerson(char *n, int a)
{
	SetName(n);
	SetAge(a);
}

CPerson::~CPerson()
{
}

//////////////////////////////////////////////////////////////////////
// Further Implementation
//////////////////////////////////////////////////////////////////////

ostream& operator<<(ostream &lhs, CPerson *rhs)
{
	lhs << "Name and Age is [ " << rhs->GetName() << ", " << rhs->GetAge() << " ]";
	return lhs;
}

ostream& operator<<(ostream &lhs, CPerson &rhs)
{
	lhs << "Name and Age is [ " << rhs.GetName() << ", " << rhs.GetAge() << " ]";
	return lhs;
}

void CPerson::operator=(CPerson &parameter)
{
	SetAge(parameter.GetAge());
	SetName(parameter.GetName());
}

bool operator==(CPerson &lhs, CPerson &rhs)
{
	if( !(lhs.GetAge() == rhs.GetAge()) )
		return false;
	else if( !(strcmp(lhs.GetName(), rhs.GetName()) == 0) )
		return false;
	else
		return true;
}

bool operator!=(CPerson &lhs, CPerson &rhs)
{
	if( lhs.GetAge() == rhs.GetAge() )
		return false;
	else if( strcmp(lhs.GetName(), rhs.GetName()) == 0 )
		return false;
	else
		return true;
}

bool CPerson::operator !() const
{
	if(Age <= 0 || strcmp(Name, "") == 0)
		return true;
	else
		return false;
}

CPerson::operator int() const
{
	return Age;
}

CPerson::operator char *() const
{
	return (char *)Name;
}