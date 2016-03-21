//--------------------------------------------------------------------
// Author:           P. Hannan 
// Date Created:     18 Feb 2002
// Last Change Date:  19 Feb 2002
// Project:          Linked List demonstration
// Filename:         LinkL3
//
// Overview:         Provides an english to french translation.
//   
// Input:            file that contains the dictionary
//      				a word the user wants to look up.             
//   
// Output:           different sorting of the words
//
//  Modifications:   19 Feb 2002 P. Hanna
//                     Comment out include of dict.cpp   
//--------------------------------------------------------------------

#include <iostream>
#include <fstream>
#include "dict.h"
using namespace std;



//--------------------------------------------------------------------

void main (void)
{
	ifstream dFile("francaisdesaffaires.txt");
	string french_word, english_word;
	dictionary d;
	
	if (dFile.fail())
		cout << "Could not read dictionary file " << endl;
	else	{
		while (!dFile.eof())
		{
			dFile >> french_word;
			dFile >> english_word;
			d.AddEngSorted(english_word, french_word);
		}
		cout << "------- English Sorted -------" << endl;
		d.display();
		
		char cont;
		string theWord, translation;
		do {
			cout << "Enter an english word: ";
			cin >> theWord;
			if (d.ValidWord(theWord, translation,false))
				cout << "The french is: " << translation << endl;
			else
				cout << "Sorry. " << theWord << " not in dicitonary" << endl;
			cout << endl;
			cout << "Do you want to continue? (y/n)" ;
			cin >> cont;
			
		}while (cont == 'y' || cont == 'Y');
	}
		
		
			
	
    
}
// #include "dict.cpp"