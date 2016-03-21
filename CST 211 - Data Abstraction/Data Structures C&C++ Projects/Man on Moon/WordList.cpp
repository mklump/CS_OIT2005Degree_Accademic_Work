// Name: Dom Virgilio
// Class: CST 136
// Assignment #1, Part II

// WordList.cpp: implementation of the CWordList class.
//
//////////////////////////////////////////////////////////////////////

#include <iostream.h>
#include <string.h>

#include "WordList.h"
#include "Word.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CWordList::CWordList()
{
	n = 0;
}

CWordList::~CWordList()
{
}

void CWordList::AddWord(CWord *pWord)
{
	word[n].SetChars(pWord->GetChars());
	n = n + 1;
}

CWord *CWordList::GetWord(int index)
{
	return &word[index];
}

int CWordList::GetNumberOfWords()
{
	return n;
}

void CWordList::PrintWordList()
{
	for (int i=0; i<n; i=i+1) {
		word[i].Print();
		if (i < (n-1)) {
			cout << ", ";
		}
	}

	cout << endl;
}

void CWordList::PrintByLetter()
{
	char *w[MAX_NUMBER_OF_WORDS];
    for(int i=0; i < n; i = i+1) {
		CWord *pWord = &word[i];
		w[i] = pWord->GetChars();
	}
	
	for (i=0; i<n-1; i=i+1) {
		for (int j=i+1; j < n; j=j+1) {
			if (strcmp(w[j], w[i]) < 0) {
				char *tmp = w[i];
				w[i] = w[j];
				w[j] = tmp;
			}
		}
	}

	cout << "Alphabetical Order: ";
	for (i=0; i<n; i=i+1) {
		cout << w[i];
		if (i < (n-1)) {
			cout << ", ";
		}
	}

	cout << endl;
}



void CWordList::PrintByLength()
{
	int position[MAX_NUMBER_OF_WORDS];
	char *w[MAX_NUMBER_OF_WORDS];
    for(int i=0; i < n; i = i+1) {
		position[i] = i;
		CWord *pWord = &word[i];
		w[i] = pWord->GetChars();
	}

	for (i=0; i<n-1; i=i+1) {
		for (int j=i+1; j < n; j=j+1) {
			if (strlen(w[j]) < strlen(w[i])) {
				char *tmp = w[i];
				w[i] = w[j];
				w[j] = tmp;

				int tmpPosition = position[i];
				position[i] = position[j];
				position[j] = tmpPosition;
			}
		}
	}

	for (i=0; i<n-1; i=i+1) {
		bool bSwap = false;
		int index = i;
		for (int j=i+1; j < n; j=j+1) {
			if (strlen(w[j]) == strlen(w[i])) {
				if ((position[j] < position[i])) {
					if (position[j] < position[index]) {
						bSwap = true;
						index = j;
					}
				}
			}
		}

		if (bSwap) {
			char *tmp = w[i];
			w[i] = w[index];
			w[index] = tmp;

			int tmpPosition = position[i];
			position[i] = position[index];
			position[index] = tmpPosition;
		}
	}

	cout << "Length Order: ";
	for (i=0; i<n; i=i+1) {
		cout << w[i];
		if (i < (n-1)) {
			cout << ", ";
		}
	}

	cout << endl;
}