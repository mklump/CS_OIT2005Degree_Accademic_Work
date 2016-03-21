// Name: Dom Virgilio
// Class: CST 136
// Assignment #1, Part II

// BUGS ARE INTENTIONAL FOR LECTURE #4

//// Phrase.cpp: implementation of the CPhrase class.
//
//////////////////////////////////////////////////////////////////////

#include <iostream.h>
#include <string.h>

#include "Phrase.h"
#include "Word.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CPhrase::CPhrase()
{
}

CPhrase::~CPhrase()
{
}

void CPhrase::GetPhraseFromUser()
{
	cout << "Input Phrase or 0 to Quit: ";
	cin.getline(phrase, MAX_PHRASE_SIZE);
}

bool CPhrase::Tokenize()
{
	char *word;
	char seps[]   = " ,\t\n";

	word = strtok(phrase, seps);
	CWord *pWord = new CWord(word);

	if (pWord->GetChars() != NULL) {
		
		if (strcmp(pWord->GetChars(), "0") == 0) return false;

		wordList.AddWord(pWord);

		while(word != NULL){
			word = strtok(NULL, seps);
			if (word != NULL) {
				CWord *pWord = new CWord(word);
				wordList.AddWord(pWord);
			}
		}

		cout << "Number of words: " << wordList.GetNumberOfWords() << endl;

		wordList.PrintByLetter();
		wordList.PrintByLength();
	}

	while (LetterLoop());

	return true;
}

	
bool CPhrase::LetterLoop()
{
	char *matchedWord[MAX_NUMBER_OF_WORDS];
	cout << "Enter [a-z] or 0 to Quit: ";

	char input[MAX_PHRASE_SIZE];
	cin.getline(input, MAX_PHRASE_SIZE);

	if (strcmp(input, "0") == 0) return false;

	int count = 0;
	char letter = input[0];
    for(int i=0; i < wordList.GetNumberOfWords(); i = i+1) {
		CWord *pWord = wordList.GetWord(i);
		if (strchr(pWord->GetChars(), letter) != NULL) {
			matchedWord[count] = pWord->GetChars();
			count = count + 1;
		}
	}

	cout << "Number of words with " << letter << " : " << count << endl;

	cout << "List of words with " << letter << " : ";
	for (i=0; i<count; i=i+1) {
		cout << matchedWord[count];
		if (i < (count-1)) {
			cout << ", ";
		}
	}

	cout << endl;

	return true;
}
