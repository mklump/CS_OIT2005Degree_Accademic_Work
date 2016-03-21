//--------------------------------------------------------------------
// Author:        P. Hannan  
// Date Created:  15 Jan 2002
// Last Change Date:  
// Project:        Demo 2 arrays of string objects
// Filename:       clue.cpp
//
// Overview:   Creates an array and displays it
//   
// Input:      None
//   
// Output:		Display the array.
//   
//--------------------------------------------------------------------

#include <iostream>   // for basic I/O
#include <iomanip>    //  for io manipultors like setw
#include <string>
  using namespace std;
  
const int MAX_WORDS = 10;
const int MAX_CARDS = 3;

void display_clue(string s[]);
void display_cards(string s[][MAX_WORDS]);

void main (void)
{
	string clue[MAX_WORDS];
	
	clue[0] = "the";
	clue[1] = "butler";
	clue[2] = "did";
	clue[3] = "it";
	display_clue(clue);
	
	// Upper case the first letter of "the"
	clue[0][0] = toupper(clue[0][0]);
	display_clue(clue);
	
	// How should add a period to the end of "it"?
	display_clue(clue);
	
	string clue_cards[MAX_CARDS][MAX_WORDS];
	// Set the first card to in the pantry.
    clue_cards[0][0] = "in";
    clue_cards[0][1] = "the";
    clue_cards[0][2] = "pantry.";
	display_clue(clue_cards[0]);
	
	// Upper case the first letter of "in"
	clue_cards[0][0][0] = toupper(clue_cards[0][0][0]);
	display_clue(clue_cards[0]);

	
	for (int i = 0; i < MAX_WORDS;i++) 
		clue_cards[1][i] = clue[i];
	display_cards(clue_cards);


}
void display_clue(string s[])
{

  	for (int row=0;row<MAX_WORDS;row++) 
        cout << s[row] << " ";
	cout << endl;

}
void display_cards(string s[][MAX_WORDS]) 
{
	cout << "The cards are: " << endl;
  	for (int row=0;row<MAX_CARDS;row++) {
	  	cout << "\t";
  	  	for (int col=0;col<MAX_WORDS;col++) 
  	      cout << s[row][col] << " ";
  		cout << endl;
  	}
	
}
