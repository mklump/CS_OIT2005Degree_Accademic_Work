//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #1 Part 1
// Date Created:   April 3, 2002
// Last Change Date:  April 3, 2002
// Project:        Man on Moon
// Filename:       manonmoon.cpp
//
// Overview:	This program is meant to review the concepts we learned
//				in CST 126
//
// Input:		A phrase or group of words separated by spaces for
//				processing.
//   
// Output:		Information printed to the screen about the processing
//				results.
//--------------------------------------------------------------------

#include "Man on Moon.h"

int main(void)
{
	CWord word; CPhrase phrase; CWordlist wordlist;
	int index, len_sum = 0;

	cout << "Please show the end of each phrase with a space,\n"
		<< "then a period, and then press enter.\n";
	
	do
	{
		cout << "\nInput Phrase or 0 to Quit> ";
		for(index = 0; index < SRTING_ARRAY_SIZE; index++)
		{
			word.Get_Word();
			word.Ckeck_Word_Length(word.Access_Word_String());

			len_sum += phrase.Put_Word_In_Phrase(index, word.Access_Word_String());
			if ( word.Ckeck_EndString_Indicator(word.Access_Word_String()) );
				break;
		}
		
		phrase.Overwrite_End_Character(index, word.Access_Word_String());
		if (len_sum > 256)
		{
			cout << "\nThe phrase you entered must not exceed 256 letters\n"
				<< "including spaces.\n"
				<< "Please try again.\n";
			exit(2);
		}
		word.Print_Word_Total(index, word.Access_Word_String());

		phrase.Alphabetize_Phrase(index, word.Access_Word_String());
		cout << "\nAlphabetical Order: ";
		phrase.Display_Phrase(index, word.Access_Word_String());

		phrase.Arrange_Length_Order_Phrase(index, word.Access_Word_String());
		cout << "\nLength Order: ";
		phrase.Display_Phrase(index, word.Access_Word_String());

		wordlist.Check_CWordlist_For_Letter(index, word.Access_Word_String());

		phrase.Reinitialize_Phrase(index, word.Access_Word_String());
		cout.flush();
		index = 0;
	}
	while (word.Check_Word());
	return 0;
}
