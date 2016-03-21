// Name: Dom Virgilio
// Class: CST 136
// Assignment #1, Part II

// Word.h: interface for the CWord class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_WORD_H__8989E6B7_8511_47D6_AF90_34D225BE3434__INCLUDED_)
#define AFX_WORD_H__8989E6B7_8511_47D6_AF90_34D225BE3434__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#define MAX_WORD_SIZE 16

class CWord  
{
public:
	CWord();
	CWord(char *);
	virtual ~CWord();
	void SetChars(char *pChars);
	char *GetChars();
	void Print();

private:
	char *word;
};

#endif // !defined(AFX_WORD_H__8989E6B7_8511_47D6_AF90_34D225BE3434__INCLUDED_)
