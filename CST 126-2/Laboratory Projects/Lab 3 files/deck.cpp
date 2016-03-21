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

# include "card.h"
# include "deck.h"

//--------------------------------------------------------------------
// Deck functions
//--------------------------------------------------------------------
//  This routine sets up the deck.  
void InitializeDeck(MyDeck & d, int s_size)
{

	AddCardsToDeck(d, s_size, HEART);
	AddCardsToDeck(d, s_size, SPADE);
	AddCardsToDeck(d, s_size, CLUB);
	AddCardsToDeck(d, s_size, DIAMOND);
    
}
//--------------------------------------------------------------------
void AddCardsToDeck(MyDeck & d, int s_size, Suits suit)
{
	
	MyDeck temp;
	
	for (int i=1; i <= s_size; i++) {
		temp = CreateCardNode(i,suit);
		temp->next = d;
		d = temp;
	}
}
//--------------------------------------------------------------------
MyDeck CreateCardNode(int value, Suits suit)
{
	
	MyDeck temp;
	temp = new CardNode;
	temp->c.initialize(suit, value);
	temp->next = NULL;

	return(temp);

}
//--------------------------------------------------------------------
//  ShuffleIfNeeded checks to see the percentage of cards that 
//     are used.  If the number used is greater then the house
//     standard, it calls the shuffle routine.
//    d is the deck, d_size is the deck size
//     s_point is the shuffle point.  If number used >= shuffle_point
//      then we will shuffle.
void ShuffleIfNeeded(MyDeck & d, int s_point)
{
	
    int count = DeckCount(d);
    if ( count < s_point ) {
   		cout << endl << "-- New Deck -- " << endl;
		shuffle(d);
	}
}
//--------------------------------------------------------------------
void DeleteRemainingCards(MyDeck & d)
{
	MyDeck temp = d;
	cout << "Deleting Deck" << endl;	
	while (d != NULL) {
		temp = d;
		d = d->next;
		delete temp;
		temp = NULL;
	}
	if (d != NULL)
		cout << "Theres a problem" << endl;

}
//--------------------------------------------------------------------
int DeckCount(MyDeck d)
{
	MyDeck temp = d;
	int count = 0;

	while (temp != NULL) {
		temp = temp->next;
		if (temp != NULL && !temp->c.used())
			count++;
	}
	return(count);
}

//--------------------------------------------------------------------
// Returns a new card to the player by generating a random number
//  and then pulling a card out of the deck.  If the card has
//  already been used this funciton keeps trying.
// 
//   Precondition:  Assumes that there are available cards in deck.
int NewCard(MyDeck & d, int d_size)
{
	int index;
	MyDeck temp;
	int r_value;
	

			
	index = int(rand() % d_size);

	temp = d;
 
	int i;   
	for (i = 0; i< index && temp != NULL; i++ ) 
		temp = temp->next;
	
	while (temp != NULL && temp->c.used())	
		temp = temp->next;
		
	if (temp == NULL || temp->c.used()) {
		// haven't found one yet, start at beginning of deck
		temp = d;
		while (temp != NULL && temp->c.used())	
			temp = temp->next;
	}
	if (temp == NULL)
		return 0;
	else {
		
		r_value = temp->c.value();
		temp->c.UpdateUsed(true);

		if (r_value > 10)
			return (10);   // Jacks, Queens and Kings are valued at 10
		else
			return (r_value);
	}
}
void PrintDeck(MyDeck d)
{
	MyDeck temp=d;
	cout << "Your Deck is " << endl;
	while (temp != NULL) {
		temp->c.print();
		temp = temp->next;
	}
}
void shuffle(MyDeck & d) 
{
	MyDeck temp = d;
	while (temp != NULL) {
		temp->c.UpdateUsed(false);
		temp = temp->next;
	}
}