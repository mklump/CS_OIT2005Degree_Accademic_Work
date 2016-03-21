// Name: Dom Virgilio
// Class: CST 136
// Assignment #1, Part II

// Word.cpp: implementation of the CWord class.
//
//////////////////////////////////////////////////////////////////////

#include <iostream.h>
#include <string.h>

#include "Word.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CWord::CWord()
{
}

CWord::CWord(char *pC)
{
	word = pC;
}

CWord::~CWord()
{
}

void CWord::SetChars(char *pC)
{
	word = pC;
}

char *CWord::GetChars()
{
	return word;
}

void CWord::Print()
{
	cout << word;
}
