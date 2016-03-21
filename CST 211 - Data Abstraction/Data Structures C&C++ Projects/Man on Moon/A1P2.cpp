// Name: Dom Virgilio
// Class: CST 136
// Assignment #1, Part II

// A1P2.cpp
//

#include <iostream.h>
#include <string.h>
#include <stdio.h>

#include "phrase.h"
#include "word.h"
#include "wordlist.h"

int main(int argc, char* argv[])
{
	bool bLoop = true;

	while (bLoop) {
		CPhrase phrase;
		phrase.GetPhraseFromUser();
		bLoop = phrase.Tokenize();
	}

	return 0;
}

