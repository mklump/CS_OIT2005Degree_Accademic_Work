//--------------------------------------------------------------------
// Author:         P. Hannan
// Date Created:   12 Feb 2002
// Last Change Date:  
// Project:        Black Jack
// Filename:       deck.cpp
//
// Overview:  This include contains the implementation for a card Deck
//     
//--------------------------------------------------------------------

#include <iostream>
#include <cstdlib>
using namespace std;

# include "deck.h"

//--------------------------------------------------------------------
// Deck functions
//--------------------------------------------------------------------
//  This routine sets up the deck.  
void InitializeDeck(Card d[], int s_size)
{

	AddCardsToDeck(d,s_size, HEART);
	AddCardsToDeck(d,s_size, SPADE);
	AddCardsToDeck(d,s_size, DIAMOND);
	AddCardsToDeck(d,s_size, CLUB);
	     
}
//--------------------------------------------------------------------
void AddCardsToDeck(Card d[], int s_size, Suits suit)
{
	// the suit constants are:
    // 	enum Suits {NO_SUIT = 0, HEART=1, SPADE=2, DIAMOND=3, CLUB=4}; 

	// the enum Suits
	int array_offset = (suit-1) * s_size;
	for (int i=0; i < s_size; i++) 
		d[array_offset + i].initialize(suit, i);
	
}

//--------------------------------------------------------------------
//  ShuffleIfNeeded checks to see the percentage of cards that 
//     are used.  If the number used is greater then the house
//     standard, it calls the shuffle routine.
//    d is the deck, d_size is the deck size
//     s_point is the shuffle point.  If number used >= shuffle_point
//      then we will shuffle.
void ShuffleIfNeeded(Card d[], int d_size,int s_point)
{
	int count_used = 0;
    for (int j=0;j < d_size && count_used < s_point;j++)
        if ( d[j].used() == true )
          count_used++;
    if ( count_used >= s_point ) {
   		cout << "--- New Deck ---" << endl;         
    	shuffle(d,d_size);
    }
}
//  Shuffle sets all the used variables to false.
//    d is the deck, d_size is the deck size
//  When the deck is shuffled all cards are again available.
void shuffle(Card d[], int d_size)
{
    for (int j=0;j<d_size;j++)
    	d[j].UpdateUsed(false);
}
//--------------------------------------------------------------------
// Returns a new card to the player by generating a random number
//  and then pulling a card out of the deck.  If the card has
//  already been used this funciton keeps trying.
// 
int NewCard(Card d[], int d_size)
{
	int index;
	do {
		index = int(rand() % d_size);
	}
	while (d[index].used() == true);
	
	d[index].UpdateUsed(true); 
	
	if (d[index].value() > 10)
		return (10);   // Jacks, Queens and Kings are valued at 10
	else
		return (d[index].value());
}
void PrintDeck(Card d[], int d_size) 
// Prints the cards in deck d
{
	for (int i=0;i<d_size;i++)
		d[i].print();
}