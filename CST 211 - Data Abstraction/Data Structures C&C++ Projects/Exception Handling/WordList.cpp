// Name: Dom Virgilio & Modified by Matthew Klump
// Class: CST 136
// Assignment #1, Part II

// WordList.cpp: implementation of the CWordList class.
//
//////////////////////////////////////////////////////////////////////

#include <iostream.h>
#include <string.h>

#include "WordList.h"
#include "Word.h"
#include "ArrayOutOfBoundsExeption.h"

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
	ArrayOutOfBoundsExeption exception;
	try
	{
		for (int i=0; i<n; i=i+1)
		{
			word[i].Print();

			string temp = "word";							//if n is a number less than zero,
			exception.setArrayOutOfBoundsExeption(temp, i);//or if i incremented enough to be
			exception.check_ARRAY(n);						//equal to n, function check_ARRAY will throw
															//an ArrayOutOfBoundsExeption.
			if (i < (n-1))
			{
				cout << ", ";
			}
		}
	}
	catch ( ArrayOutOfBoundsExeption exception )
	{
		cerr << exception.what() << endl;
	}

	cout << endl;
}

void CWordList::PrintByLetter()
{
	char *w[MAX_NUMBER_OF_WORDS];
	ArrayOutOfBoundsExeption exception;
	
	try
	{
	    for(int i=0; i < n; i = i+1)
		{
			CWord *pWord = &word[i];

			string temp = "pWord";							//if n is a number less than zero,
			exception.setArrayOutOfBoundsExeption(temp, i); //or if i incremented enough to be
			exception.check_ARRAY(n);						//equal to n, function check_ARRAY will throw
															//an ArrayOutOfBoundsExeption.
			w[i] = pWord->GetChars();
		}
	
		for (i=0; i<n-1; i=i+1)
		{
			for (int j=i+1; j < n; j=j+1)
			{
				if (strcmp(w[j], w[i]) < 0)
				{
					char *tmp = w[i];

					string temp = "tmp";							//if n is a number less than zero,
					exception.setArrayOutOfBoundsExeption(temp, j); //or if j incremented enough to be
					exception.check_ARRAY(n);						//equal to n, function check_ARRAY will throw
					 												//an ArrayOutOfBoundsExeption.
					w[i] = w[j];
					w[j] = tmp;
				}
			}
		}
		
		cout << "Alphabetical Order: ";
		for (i=0; i<n; i=i+1)
		{
			cout << w[i];
			string temp = "w";								//if n is a number less than zero,
			exception.setArrayOutOfBoundsExeption(temp, i); //or if i incremented enough to be
			exception.check_ARRAY(n);						//equal to n, function check_ARRAY will throw
															//an ArrayOutOfBoundsExeption.
			if (i < (n-1))
			{
				cout << ", ";
			}
		}
	}
	catch ( ArrayOutOfBoundsExeption exception )
	{
		cerr << exception.what() << endl;
	}


	cout << endl;
}



void CWordList::PrintByLength()
{
	int position[MAX_NUMBER_OF_WORDS];
	char *w[MAX_NUMBER_OF_WORDS];

	ArrayOutOfBoundsExeption exception;
	try
	{
		for(int i=0; i < n; i = i+1)
		{
			position[i] = i;

			string temp = "position";						//if n is a number less than zero,
			exception.setArrayOutOfBoundsExeption(temp, i); //or if i incremented enough to be
			exception.check_ARRAY(n);						//equal to n, function check_ARRAY will throw
															//an ArrayOutOfBoundsExeption.
			CWord *pWord = &word[i];
			w[i] = pWord->GetChars();
		}

		for (i=0; i<n-1; i=i+1) //again there exists a possibility of out of bounds
		{
			string temp = "";
			exception.setArrayOutOfBoundsExeption(temp, i);
			exception.check_ARRAY(n);
			for (int j=i+1; j < n; j=j+1) //again there exists a possibility of out of bounds
			{
				string temp = "w";
				exception.setArrayOutOfBoundsExeption(temp, j);
				exception.check_ARRAY(n);
				if (strlen(w[j]) < strlen(w[i]))
				{
					char *tmp = w[i];
					w[i] = w[j];
					w[j] = tmp;

					int tmpPosition = position[i];
					position[i] = position[j];
					position[j] = tmpPosition;
				}
			}
		}

		for (i=0; i<n-1; i=i+1)
		{
			bool bSwap = false;
			int index = i;
			for (int j=i+1; j < n; j=j+1)
			{
				string temp = "w";								//if n is a number less than zero,
				exception.setArrayOutOfBoundsExeption(temp, j); //or if j incremented enough to be
				exception.check_ARRAY(n);						//equal to n, function check_ARRAY will throw
					 											//an ArrayOutOfBoundsExeption.
				if (strlen(w[j]) == strlen(w[i]))
				{
					if ((position[j] < position[i]))
					{
						if (position[j] < position[index])
						{
							bSwap = true;
							index = j;
						}
					}
				}
			}

			if (bSwap)
			{
				char *tmp = w[i];
				w[i] = w[index];
				w[index] = tmp;

				int tmpPosition = position[i];
				position[i] = position[index];
				position[index] = tmpPosition;
			}
		}

		cout << "Length Order: ";
		for (i=0; i<n; i=i+1)
		{
			cout << w[i];
			string temp = "w";								//if n is a number less than zero,
			exception.setArrayOutOfBoundsExeption(temp, i); //or if i incremented enough to be
			exception.check_ARRAY(n);						//equal to n, function check_ARRAY will throw
															//an ArrayOutOfBoundsExeption.
			if (i < (n-1))
			{
				cout << ", ";
			}
		}
	}
	catch ( ArrayOutOfBoundsExeption exception )
	{
		cerr << exception.what() << endl;
	}


	cout << endl;
}