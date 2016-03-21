//--------------------------------------------------------------------
// Author:         P. Hannan
// Date Created:   12 Feb 2002
// Last Change Date:  
// Project:        Black Jack
// Filename:       player.h
//
// Overview:  This include contains the SPlayer object interface
//     
//--------------------------------------------------------------------

# ifndef PLAYERH // ensure only included once
# define PLAYERH
#include "card.h"
class SPlayer {
	public:
	    SPlayer(char name[], char type);
	    void InitializeHand(void);
	    void change_type(char type);
	    bool HitMe(Card d[], int d_size);
	    void DisplayHand(void);
		void CompareHand(SPlayer player);
		void PrintName(void);
		int  hand(void) {return m_hand;};	    
	   
	private:
	    char   m_name[30];    // LAB TASK Change the name to a string
	    char   m_type;
   	    int    m_hand;

};
#endif