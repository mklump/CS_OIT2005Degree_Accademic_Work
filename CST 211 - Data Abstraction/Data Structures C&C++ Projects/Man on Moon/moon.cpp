//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #1 Part 1
// Date Created:   April 7 2002
// Last Change Date:  
// Project:        Man on Moon
// Filename:       Man on Moon.cpp
//
// Overview:  This include contains the implentation of the
//			  Man on Moon program.
//     
//--------------------------------------------------------------------

#include "Man on Moon.h"

string * CWordlist::Check_CWordlist_For_Letter(const int& index, string *ptr_to_str1)
{
	ans = ' '; found = 0;
	while (ans != '0')
	{
		cout << "\nEnter [a-z] or 0 to Quit> ";
		cin >> ans;
		if (ans == '0')
			break;
		for (int bindex = 0; bindex < index; bindex++)
		{
			if (Find_Words_With_That_Letter(ans, bindex, index))
			{
				found++;
				matched = matched + phrase[bindex] + ", ";
			}
		}
		Display_Wordlist(ptr_to_str1);
		matched = "";
	}
	return ptr_to_str1;
}

string * CWordlist::Display_Wordlist(string *ptr_to_str1)
{
	cout << "\nNumber of words with " << ans << ": " << found
	<< "\nList of words with " << ans << ": " << matched;
	return ptr_to_str1;
}

string * CPhrase::Overwrite_End_Character(const int& index, string *ptr_to_str1)
{
	phrase[index] = "";
	return ptr_to_str1;
}

int CPhrase::Put_Word_In_Phrase(const int& index, string *ptr_to_str1)
{
	int length_sum = 0;
	phrase[index] += *ptr_to_str1;
	length_sum += phrase[index].length();
	return length_sum;
}

string * CPhrase::Reinitialize_Phrase(const int& index, string *ptr_to_str1)
{
	for (int bindex = 0; bindex < index; bindex++)
		phrase[bindex] = "";
	return ptr_to_str1;
}

bool CWord::Check_Word()
{
	if (word != " 0")
		return true;
	else
		return false;
}

string * CWord::Get_Word()
{
	typedef string *ptr_to_str;
	ptr_to_str ptr_to_str1;
	ptr_to_str1 = &word;
	cin.clear();
	cin >> word;
	*ptr_to_str1 = ' ' + word;
	return ptr_to_str1;
}

string * CWord::Print_Word_Total(const int& index, string *ptr_to_str1)
{
	cout << "\nNumber of words: " << index;
	return ptr_to_str1;
}

string * CWord::Ckeck_Word_Length(string *ptr_to_str1)
{
	if (word.length() > 16)
	{
		cout << "\nEnter only 16 letters per word.\n"
			<< "Please try again.";
		exit(1);
	}
	else
		return ptr_to_str1;
}

bool CWord::Ckeck_EndString_Indicator(string *ptr_to_str1)
{
	if (*ptr_to_str1 == " .")
		return true;
	else if (*ptr_to_str1 == " 0")
	{
		char ret = 0;
		cout << "Press the enter key to end program.\n";
		cin.get(ret);
		exit(3);
	}
	return false;
}

string * CPhrase::Alphabetize_Phrase(const int& array_size, string *ptr_to_str1)
{
	for (int y = 0; y < array_size; y++)
	{
		for (int z = 0; z < array_size; z++)
		{
			if (phrase[y] < phrase[z])
				Swap_Values(phrase[y], phrase[z], ptr_to_str1);
		}
	}
	return ptr_to_str1;
}

string * CPhrase::Arrange_Length_Order_Phrase(const int& array_size, string *ptr_to_str1)
{
	for (int y = 0; y < array_size; y++)
	{
		for (int z = 0; z < array_size; z++)
		{
			if (phrase[y].length() < phrase[z].length())
				Swap_Values(phrase[y], phrase[z], ptr_to_str1);
		}
	}
	return ptr_to_str1;
}

bool CPhrase::Find_Words_With_That_Letter(const char& letter, const int& bindex,
								 const int& array_size)
{
	for (int z = 0; z < phrase[bindex].length(); z++)
	{
		if (phrase[bindex].at(z) == letter)
			return true;
		else
			continue;
	}
	return false;
}

string * CPhrase::Swap_Values(string& s1, string& s2, string *ptr_to_str1)
{
	string temp;
	temp = s1;
	s1 = s2;
	s2 = temp;
	return ptr_to_str1;
}

string * CPhrase::Display_Phrase(const int& array_size, string *ptr_to_str1)
{
	for (int index = 0; index < array_size; index++)
			cout << phrase[index] << ",";
	return ptr_to_str1;
}

CPhrase::~CPhrase()
{

}

CWord::~CWord()
{

}

CWordlist::~CWordlist()
{

}

string * CWord::Access_Word_String()
{
	typedef string *ptr_to_str;
	ptr_to_str ptr_to_str1;
	ptr_to_str1 = &word;
	return ptr_to_str1;
}
