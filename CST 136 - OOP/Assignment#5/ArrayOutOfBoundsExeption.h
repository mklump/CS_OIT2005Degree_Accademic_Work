//-------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #5
// Date Created:   June 4, 2002
// Last Change Date:  June 4, 2002
// Project:        OOGA
// Filename:       ArrayOutOfBoundsExeption.h
//
// Overview:  This include contains the interface for the
//			  ArrayOutOfBoundsExeption class.
//     
//-------------------------------------------------------------------

#if !defined(AFX_ARRAYOUTOFBOUNDSEXEPTION_H__FCE2AB21_7C99_4D33_9B93_837EC2AC408C__INCLUDED_)
#define AFX_ARRAYOUTOFBOUNDSEXEPTION_H__FCE2AB21_7C99_4D33_9B93_837EC2AC408C__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
#include <string>

class ArrayOutOfBoundsExeption
{
public:
	ArrayOutOfBoundsExeption() : index(0), error_encountered(false), Array("") {}

	void setArrayOutOfBoundsExeption(string &array, const int& i)
	{
		Array = array;
		index = i;
	}
	void check_ARRAY(const int& upperbound)
	{
		if( index < 0 || index >= upperbound) //check the array boundaries
		{
			error_encountered = true;
			throw ArrayOutOfBoundsExeption();
		}
	}
	int what() const
	{
		cout << "Exception occurred: Attempted to use invalid index "
			 << index << "\nin array " << Array.c_str() << " status code ";
		return 1;
	}
	virtual ~ArrayOutOfBoundsExeption() {};

private:
	int index;
	bool error_encountered;
	string Array;
};

#endif // !defined(AFX_ARRAYOUTOFBOUNDSEXEPTION_H__FCE2AB21_7C99_4D33_9B93_837EC2AC408C__INCLUDED_)
