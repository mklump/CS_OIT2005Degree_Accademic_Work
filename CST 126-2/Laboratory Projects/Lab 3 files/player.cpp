//--------------------------------------------------------------------
// Author:         P. Hannan
// Date Created:   12 Feb 2002
// Last Change Date:  
// Project:        Black Jack
// Filename:       card.h
//
// Overview:  This include contains the player object implementation.
//     
//--------------------------------------------------------------------
#include <cstring>
#include <iostream>
using namespace std;

#include "card.h"
#include "player.h"
#include "deck.h"

//  This is the player constructor.  
SPlayer::SPlayer (char the_name[], char t)
{
	strcpy(m_name, the_name);
	m_type = t;
	InitializeHand();
	
}
void SPlayer::InitializeHand(void)
{
	m_hand = 0;
}

// This function displays a players hand.
void SPlayer::DisplayHand()
{
	PrintName();
 	cout << " has " << m_hand << endl;
}
//--------------------------------------------------------------------
//  This function decides whether a player wants another card.
//     There are three player types which have different
//     rules about when to take a card.
//     A dealer must take a card if his hand score is less then
//      16
//     A Wild player (type w) takes a card if her hand score is 
//      thess then 18
//     Any other player type takes a crard if their hand is < 17
bool SPlayer::HitMe(MyDeck & d, int d_size)
{

	bool got_card = false;
	
	if (m_type == 'd')
	{
		if (m_hand < 16)
		{
			m_hand += NewCard(d,d_size);
			got_card = true;
		}
		
	}
	else if (m_type == 'w')
	{
		if (m_hand < 18)
		{
		   m_hand += NewCard(d,d_size);
		   got_card = true;
		}
	}
	else if (m_hand < 17)
	{
		   m_hand += NewCard(d,d_size);
		   got_card = true;
	}
	
	return (got_card);
	
}
//--------------------------------------------------------------------
//  This compares a player hand with the dealers hand and
//   displays the winner on the screen.
void SPlayer::CompareHand(SPlayer player)
{

	if (player.hand() > 21) {
	   player.PrintName();
	   cout << " Busted " << endl;
    }
	if (m_hand > 21) {
  	   PrintName();
	   cout << " Busted ";
	   if (player.hand() <= 21 ) {
		  player.PrintName();
	      cout << " You Win! ";
      }
	  cout << endl;
    }
    else {
	    player.PrintName();
      	if (player.hand() >= m_hand && player.hand() < 22)
        	cout << " You Win! " << endl;
      	else
           cout << " Sorry.  You Lose." << endl;
    }
}
//--------------------------------------------------------------------
//  Prints the player name to the screen.
void SPlayer::PrintName(void)
{
	if (m_type == 'd')
		cout << "Dealer";
	else
		cout << m_name;
}
