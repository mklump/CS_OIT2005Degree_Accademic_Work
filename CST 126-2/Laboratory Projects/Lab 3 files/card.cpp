//--------------------------------------------------------------------
// Author:         P. Hannan
// Date Created:   12 Feb 2002
// Last Change Date:  
// Project:        Black Jack
// Filename:       card.cpp
//
// Overview:  This include contains the card object implmentation
//     
//--------------------------------------------------------------------

# include <iostream>
# include <iomanip>
	using namespace std;
# include "card.h"


Card::Card(void) {
	initialize(NO_SUIT,0);
}

Card::Card(Suits s, int v) 
{
	initialize(s,v);
}

void Card::initialize(Suits s, int v) 
{
	m_suit = s;
	m_value = v;
	UpdateUsed(false);
}


void Card::print(void)
{
	cout << setw(2) << m_value << " of ";
	PrintSuit(m_suit);
	cout << endl;
}
void PrintSuit(Suits s)
{
	switch(s) {
	 case HEART:    cout << "Hearts";   break;
	 case DIAMOND:  cout << "Diamonds"; break;
	 case SPADE:    cout << "Spades";   break;
	 case CLUB:     cout << "Clubs";    break;
	 default:       cout << "Unkown";   break;
 	}
}
	


