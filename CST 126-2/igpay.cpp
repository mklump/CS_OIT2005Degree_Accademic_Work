//--------------------------------------------------------------------
// Author:         P. Hannan
// Date Created:   27 Dec 2001 
// Last Change Date:  09 Jan 2001
// Project:        Pig Latin,  Page 675 #14
// Filename:       
//
// Overview
//   This program takes a word from the user and translates it to
//     pig latin
// Input:
//   An input word
// Output:
//   The pig latin Translation
//--------------------------------------------------------------------

#include <iostream>
#include <cstring>
using namespace std;

// STUDENT TASK: notice the following constants
const int MAX_WORD_SIZE = 20;
const char VOWELS[11] = "aeiouAEIOU";
//--------------------------------------------------------------------
// Function Prototypes go here
void SimpleIgpayAtinlay(char pig[],char word[]);  
//   SimpleIgpayAtinlay translates the word stored in the variable 
//    word to pig latin and outputs in the variable pig.
//    this function uses the simple translation of
//    removing the first letter, appending it to the end
//    and then appending the ay
void IgpayAtinlay(char pig[],char word[]);
//  IgpayAtinlay translates the word stored in the variable word to
//    pig latin and outputs in the variable pig.
//    This function considers whether the first letter is
//    a vowel before doing the translation.



//--------------------------------------------------------------------

void main (void)
{
// STUDENT TASK - Complete the following declaration user_word
//   to make a cstring.  Use the size constant declared above.
//   Complete the pig_latin declaration to store the translated
//    word.  Note that the translated word can be three characters
//    longer then the original word.  
	
	char user_word[MAX_WORD_SIZE];
	char pig_latin[MAX_WORD_SIZE+3];

	
	cout << "Welcome to the Pig Latin Translator" << endl;
	cout << "Enter the word you want to translate" << endl;
	
    cin >> user_word;
    
    SimpleIgpayAtinlay(pig_latin,user_word);
    cout << "The simple translation of " << user_word;
    cout << " is " << pig_latin << endl;
    IgpayAtinlay(pig_latin,user_word);
    cout << "The full translation of " << user_word;
    cout << " is " << pig_latin << endl;

}

//--------------------------------------------------------------------
//   SimpleIgpayAtinlay translates the word stored in the variable 
//    word to pig latin and outputs in the variable pig.
//    this function uses the simple translation of
//    removing the first letter, appending it to the end
//    and then appending the ay
void SimpleIgpayAtinlay(char pig[],char word[])
{
	// STUDENT TASK - Change this function to blindly strip off the 
	// first character and append it to the end and add "ay".
	//    Hint 1: Page 920 of your text has all the functions you need.
	//    Hint 2: What is the address of the second letter of word?
	//    Hint 3: My solution had three lines.
	strcpy(pig, word + 1);
	strncat(pig, word, 1);
	strcat(pig, "ay");
}
//--------------------------------------------------------------------
//  IgpayAtinlay translates the word stored in the variable word to
//    pig latin and outputs in the variable pig.
//    This function considers whether the first letter is
//    a vowel before doing the translation.
void IgpayAtinlay(char pig[],char word[])
{
	
	int index;
	bool is_vowel;
	index = strcspn(word, VOWELS);
	// STUDENT TASK:  Add a check to see if the first letter
	//  is a vowel.  If it isn't then use SimpleIgpayAtinlay
	//   Hint: Look up the function strcspn in the help text
	//     and remember the constants declared above

    strcpy(pig,word);  // STUDENT TASK - Remove this temporary statement
		
//	index= strcspn(word,VOWELS);
//	
//	// STUDENT TASK - add the condition to check if the first char is a vowel:
//	if () {  
//    //  STUDENT TASK - add the two lines needed to translate to pig latin		
//    //  if the word starts with a vowel.  (Refer to rules in text)
//	  	
//    }
//	else
//	  SimpleIgpayAtinlay(pig,word);
}