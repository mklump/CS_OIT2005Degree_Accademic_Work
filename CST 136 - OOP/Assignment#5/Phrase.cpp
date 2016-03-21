// Name: Dom Virgilio
// Class: CST 136
// Assignment #1, Part II

//// Phrase.cpp: implementation of the CPhrase class.
//
//////////////////////////////////////////////////////////////////////

#include <iostream.h>
#include <string.h>

#include "Phrase.h"
#include "Word.h"
#include "ArrayOutOfBoundsExeption.h"

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
	bad_alloc exception1;

	word = strtok(phrase, seps);
	try
	{
		CWord *pWord = new CWord(word); //if user entered enough words separated by
										//spaces, new could throw a bad_alloc here.
		//throw exception1; //used for testing

		if (pWord->GetChars() != NULL)
		{		
			if (strcmp(pWord->GetChars(), "0") == 0)
				return false;

			wordList.AddWord(pWord);

			while(word != NULL)
			{
				word = strtok(NULL, seps);
				if (word != NULL)
				{
					CWord *pWord = new CWord(word); //if user entered enough words separated
													//by spaces, new could throw a bad_alloc here.
					//throw exception1;  //used for testing
					wordList.AddWord(pWord);
				}
			}

			cout << "Number of words: " << wordList.GetNumberOfWords() << endl;

			wordList.PrintByLetter();
			wordList.PrintByLength();
		}
	}
	catch ( bad_alloc exception )
	{
		cerr << "Exception occurred: " << exception.what() << endl;
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

	if (strcmp(input, "0") == 0)
		return false;

	int count = 0;
	ArrayOutOfBoundsExeption exception2;
	char letter = input[0];

	try
	{
	   for(int i=0; i < wordList.GetNumberOfWords(); i = i+1)
		{
			CWord *pWord = wordList.GetWord(i); //if wordList.GetNumberOfWords() returned a number
			string temp = "pWord";				//less than zero, or if i incremented enough to be
												//equal to the int returned by wordList.GetNumberOfWords(),
												//function check_ARRAY will throw an ArrayOutOfBoundsExeption
			exception2.setArrayOutOfBoundsExeption(temp, i);
			exception2.check_ARRAY(wordList.GetNumberOfWords());

			//throw exception2; //used for testing
			if (strchr(pWord->GetChars(), letter) != NULL)
			{
				matchedWord[count] = pWord->GetChars();
				count = count + 1;
			}
		}

		cout << "Number of words with " << letter << " : " << count << endl;

		cout << "List of words with " << letter << " : ";
		for (i=0; i<count; i=i+1)
		{
			cout << matchedWord[i];

			string temp = "matchedWord";					//if count is a number less than zero,
			exception2.setArrayOutOfBoundsExeption(temp, i);//or if i incremented enough to be
			exception2.check_ARRAY(count);					//equal to count, function check_ARRAY will throw
															//an ArrayOutOfBoundsExeption.
			if (i < (count-1))
			{
				cout << ", ";
			}
		}
	}
	catch ( ArrayOutOfBoundsExeption exception2 )
	{
		cerr << exception2.what() << endl;
	}

	cout << endl;

	return true;
}
