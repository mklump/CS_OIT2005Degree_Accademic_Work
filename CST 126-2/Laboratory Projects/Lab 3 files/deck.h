//--------------------------------------------------------------------
// Author:         P. Hannan
// Date Created:   12 Feb 2002
// Last Change Date:  
// Project:        Black Jack
// Filename:       deck.h
//
// Overview:  This include contains the implementation of a card deck
//     
//--------------------------------------------------------------------
# ifndef DECKH // ensure only included once
# define DECKH

#include "card.h"

struct CardNode {
	Card c;
	CardNode * next;
};

typedef CardNode * MyDeck;

const int DECK_SIZE = 52;   
//  If we declare the deck size this way we can use the deck for 
//  other games that have more or less cards for example two-deck 
//  solitaire.
const int SUIT_SIZE = 13;  
// If we declare the suit size this way we can play games that 
// discared some of the cards.
const int SHUFFLE_AT = 26;  
//  If more then this number of cards are used the house will reshuffle.

//--------------------------------------------------------------------
int  NewCard(MyDeck & d,int d_size);
//  this routine deals a new card.  
//  d is the deck, d_size is the deck size, 
void InitializeDeck(MyDeck & d, int s_size);
//  This routine sets up the deck.  
//    d is the deck, d_size is the deck size, and s_size is the
//    suit size.
void shuffle(MyDeck & d, int d_size);
//  Shuffle sets all the used variables to false.
//    d is the deck, d_size is the deck size
void ShuffleIfNeeded(MyDeck & d, int s_point);
//  ShuffleIfNeeded checks to see the percentage of cards that 
//     are used.  If the number used is greater then the house
//     standard, it calls the shuffle routine.
//    d is the deck, d_size is the deck size
void shuffle(MyDeck & d);
// Shuffles the deck by reseting the used flag.

void AddCardsToDeck(MyDeck & d, int s_size, Suits suit);
//  Adds all the cards for one suit to the deck.
MyDeck CreateCardNode(int value, Suits suit);
// Creates a single Card Node
void DeleteRemainingCards(MyDeck & d);
// Deletes any cards left in deck d
int DeckCount(MyDeck d);
//  Counts the cards in deck d
void PrintDeck(MyDeck d);
// Prints the cards in deck d

#endif