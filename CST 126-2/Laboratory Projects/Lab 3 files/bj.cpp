//--------------------------------------------------------------------
// Author:         P. Hannan
// Date Created:   12 Feb 2002
// Last Change Date:  
// Project:        Black Jack
// Filename:       bj.cpp
//
// Overview:  This routine plays black jack.
//      Black Jack is a card game where the objective
//    From Microsoft Encarta:
//       The object of blackjack, which is also known as twenty-one, 
//       or vingt-et-un, is to draw cards totaling exactly 21 or to 
///      come as close to this count as possible without exceeding 
//       it. Cards have point values as follows: an ace counts as 
//       either 11 or 1 at the option of the player; any picture 
//       card counts as 10; other cards count at their face value.
//    In this program aces are 1, J are 11, Q are 12, K are 13
//    each card can have a possible value of 1-13
// Input:  None
//   
// Output: As many rounds of the game as the user wants.
//   
//--------------------------------------------------------------------

#include <iostream>
#include <time.h>
using namespace std;

# include "card.h"
# include "deck.h"
# include "player.h"

//--------------------------------------------------------------------

void main (void)
{
	
	MyDeck deck = NULL;  // LAB TASK Change the deck to a linked list of cards
    char play_continues;
    
    SPlayer player1("Fred",'w');
    SPlayer player2("Ginger",' ');
    SPlayer dealer("Dealer", 'd');
    
	srand((unsigned) time(NULL)); // initialize random cards.	
	
	//  Set the deck up.
	InitializeDeck(deck, SUIT_SIZE);
        
    do 
    {
	    //  The dealer checks to see if he needs to reshuffle
	    //   at the start of each game.
	    ShuffleIfNeeded(deck, SHUFFLE_AT); 
	    
	    // First, give back any cards in your hand.
        player1.InitializeHand();
        player2.InitializeHand();
        dealer.InitializeHand();
        
        // Then the dealer gives out 2 chards.
	    for (int i = 0; i<2;i++)
	    {
		    player1.HitMe(deck,DECK_SIZE);
		    player2.HitMe(deck,DECK_SIZE);
		    dealer.HitMe(deck,DECK_SIZE);
	    }
	    
      
	    //  Play continues until everyone has enough cards.

	    bool more_hits = true;
	    while (more_hits)
	    {
		  more_hits = player1.HitMe(deck,DECK_SIZE) || 
		              player2.HitMe(deck,DECK_SIZE) || 
	                  dealer.HitMe(deck,DECK_SIZE);

	    }
	    

        // Display and compare the dealer hand and player 1's hand.
	    dealer.DisplayHand();
	    player1.DisplayHand();
	    dealer.CompareHand(player1);
	    cout << endl;
	    
	    // Display and compare the dealer hand and player 2's hand.
	    dealer.DisplayHand();
	    player2.DisplayHand();	  
	    dealer.CompareHand(player2);
	    cout << endl;
	    
	    cout << " Do you want to continue? (Y/N) " ;
	    cin >> play_continues;
    }
    while ( toupper(play_continues) == 'Y' );
    
    DeleteRemainingCards(deck);
}


//--------------------------------------------------------------------
#ifndef _MSCVER
# include "card.cpp"
# include "deck.cpp"
# include "player.cpp"
#endif
