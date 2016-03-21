// Name: Dom Virgilio
// Class: CST 136
// Assignment #1, Part II

// BUGS ARE INTENTIONAL FOR LECTURE #4

// WordList.h: interface for the CWordList class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_WORDLIST_H__24EB648C_FC9A_433C_92A4_CB81F0440115__INCLUDED_)
#define AFX_WORDLIST_H__24EB648C_FC9A_433C_92A4_CB81F0440115__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "Word.h"

#define MAX_NUMBER_OF_WORDS 128 // one-letter-word, space, one-letter-word, space, etc.

class CWordList  
{
public:
	CWordList();
	virtual ~CWordList();
	void AddWord(CWord *pWord);
	CWord *GetWord(int index);
	int GetNumberOfWords();
	void PrintWordList();
	void PrintByLetter();
	void PrintByLength();
private:
	int n;
	CWord word[MAX_NUMBER_OF_WORDS];
};

#endif // !defined(AFX_WORDLIST_H__24EB648C_FC9A_433C_92A4_CB81F0440115__INCLUDED_)
