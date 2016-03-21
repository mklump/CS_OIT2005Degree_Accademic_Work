//--------------------------------------------------------------------
// Author:         P. Hannan   
// Date Created:   18 Feb 2002
// Last Change Date:  19 Feb 2002
// Project:        Linked List demonstration
// Filename:       dict.cpp
//
// Overview:	   This provides the dict class 
//   
//   Modifications: 19 Feb 2002 P. Hannan
//       Update AddEngSorted to consider a list of one node
//       remove ; from include file.
//--------------------------------------------------------------------

#include <string>
#include <iostream>
#include <iomanip>
#include <algorithm>
  using namespace std;

#include "dict.h"

//--------------------------------------------------------------------
// Destructor
dictionary::~dictionary(void)
{
	cout << "dictionary::~dictionary"<< endl;

	ListPtr temp;
	
	while (head != NULL) {
		temp = head;
		head = head->next;
	    delete temp;
	    temp = NULL;
    }   
}

//--------------------------------------------------------------------
// Display the whole bloomin dictionary		
void dictionary::display(void) const
{
	
	cout << "dictionary::display"<< endl;
	ListPtr temp;
	
	if (head == NULL)
		cout << "The dictionary is empty"<< endl;
	else {
		temp = head;
		while (temp != NULL) {
			cout << setw(20) << temp->english_word << "\t";
			cout << setw(20) << temp->french_word << endl;
			temp = temp->next;
	    }   
    }
    cout << "OUT" << endl;
}
//--------------------------------------------------------------------
//  Append a new word to the dictionary
void dictionary::append(string  inEng, string inFr)
{
//	cout << "dictionary::append"<< endl;
//  This is insert at the top.
			
	ListPtr temp;
	
	temp = create_node(inEng,inFr);
	
	temp->next = head;	
	head = temp;
		
		
}
//-------------------------------------------------------------------
//  Create a word_list node
ListPtr create_node(string inEng, string inFr)
{
	ListPtr temp = new word_list;
		
	temp->english_word = inEng;
	temp->french_word = inFr;
	temp->next = NULL;
	
	return (temp);
}
//--------------------------------------------------------------------
// Add to dictionary in sorted order (by english word)
void dictionary::AddEngSorted(string inEng, string inFr)
{
	ListPtr temp, previous, new_node;
	temp = head;
	previous = NULL;
	
	// first create a new node for the words.
	new_node = create_node(inEng,inFr);
	
	// next find a place for the new node
	while (temp != NULL && temp->english_word < inEng) {
	    previous = temp;
		temp = temp->next;
	}
	// previous now holds the one before the place where we
	//  want to insert.
	if (temp == NULL)  // empty list;
		head = new_node;
	else if (previous == NULL) // insert at beginning of list
	{
		new_node->next = head;
		head = new_node;
	}
	else
	{
		previous->next = new_node;
		new_node->next = temp;
	}	
}
//--------------------------------------------------------------------
//  Looks to see if a word is in the dictionary.
//    returns true if found and false if not.
//    if true, returns the translation in the variable
//    translation.
bool dictionary::ValidWord(string in_word, // search word
						   string & translation,   // return translation
						   bool french = false) 
{
	bool valid = false, stop = false;
	ListPtr temp;
	
	temp = head;
		
	// find the word
	
	if (temp != NULL) {
		stop = compare_words(temp, in_word, french) == 0;
				
		while (!stop && temp != NULL) {
			temp = temp->next;
			if (temp != NULL)
				stop = compare_words(temp, in_word, french) == 0;
		}
	}
	
	//  if we reached the end
	if (temp == NULL)
		valid = false;
	else 
		valid = compare_words(temp, in_word, french) == 0;
	
	if (!valid) 
		translation = " ";
	else  {	
		if (french)  // give the english word
	  		translation = temp->english_word;
		else  // give the french word.
	  		translation = temp->french_word;
  	}
			
	return(valid);
}
//--------------------------------------------------------------------
//  compare words based on which language you are using.
//     
int compare_words(ListPtr theWord, string check_word, bool french = false)
{
	
	// the compare member function returns a negative number 
	//   the calling word is smaller lexigraphically.
	//  It returns a positive number if the calling word is
	//   larger lexigraphically and a 0 if they are equal.
	if (french)
		return (theWord->french_word.compare(check_word));
	else {
		return (theWord->english_word.compare(check_word));
	}
	
}


