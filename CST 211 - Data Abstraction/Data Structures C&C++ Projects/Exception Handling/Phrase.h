// Name: Dom Virgilio & MOdified by Matthew Klump
// Class: CST 136
// Assignment #1, Part II

// Phrase.h: interface for the CPhrase class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_PHRASE_H__10E61D94_381F_4588_8CFE_7CF0CB507726__INCLUDED_)
#define AFX_PHRASE_H__10E61D94_381F_4588_8CFE_7CF0CB507726__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <new>
#include <cstdlib>
#include "WordList.h"

using namespace std;

#define MAX_PHRASE_SIZE 256

class CPhrase  
{
public:
	CPhrase();
	virtual ~CPhrase();
	void GetPhraseFromUser();
	bool Tokenize();
	bool LetterLoop();

private:
	char phrase[MAX_PHRASE_SIZE];
	CWordList wordList;
};

#endif // !defined(AFX_PHRASE_H__10E61D94_381F_4588_8CFE_7CF0CB507726__INCLUDED_)
