//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #1 Part 1
// Date Created:   April 7, 2002
// Last Change Date:  
// Project:        Mon on Moon
// Filename:       Mon on Moon.h
//
// Overview:  This include contains the interface for the
//			  Man on Moon program.
//     
//--------------------------------------------------------------------

#include <iostream> //Include the Input/Output stream class.
#include <string>	//Include the string class.

using namespace std;

#ifndef MANONMOON_H
#define MANONMOON_H

const int SRTING_ARRAY_SIZE = 50;

class CWord
{
public:
	string * Access_Word_String();
	CWord() : word("") {};

	~CWord();

	string * Get_Word();

	string * Print_Word_Total(const int& index, string *ptr_to_str1);

	string * Ckeck_Word_Length(string *ptr_to_str1);

	bool Ckeck_EndString_Indicator(string *ptr_to_str1);

	bool Check_Word();

protected:
	string word;
};

class CPhrase : CWord //CPhrase must inherit from CWord
{
public:
	CPhrase() : phrase() {};

	~CPhrase();

	int Put_Word_In_Phrase(const int& index, string *ptr_to_str1);

	string * Overwrite_End_Character(const int& index, string *ptr_to_str1);

	string * Reinitialize_Phrase(const int& index, string *ptr_to_str1);

	string * Alphabetize_Phrase(const int& array_size, string *ptr_to_str1);
	//Postcondition: The values in array of string objects phrase
	//are alphabetized

	string * Swap_Values(string& s1, string& s2, string *ptr_to_str1);
	//Postcondition: The values of string objects s1 and s2 are swapped
	//after the call.

	string * Arrange_Length_Order_Phrase(const int& array_size, string *ptr_to_str1);
	//Postcondition: The values in array of string objects phrase
	//are arranged according to length order lowest to highest.

	bool Find_Words_With_That_Letter(const char& letter, const int& bindex,
								 const int& array_size);
	//Precondition: Phrase is a string array, found is the number of
	//words that have the letter, index is the size of the string array.
	//Return true if the letter searched for matches a letter in
	//each word array element searched

	string * Display_Phrase(const int& array_size, string *ptr_to_str1);
	//Postcondition: Prints the output for this program to the screen

protected:
	string phrase[SRTING_ARRAY_SIZE];
};

class CWordlist : CPhrase //CWordlist must inherit from CPhrase
{
public:
	CWordlist() : matched() {};

	~CWordlist();

	string * Check_CWordlist_For_Letter(const int& index, string *ptr_to_str1);

	string * Display_Wordlist(string *ptr_to_str1);

private:
	string matched;
	char ans;
	int found;
};

#endif