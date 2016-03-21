//--------------------------------------------------------------------
// Author:         P. Hannan
// Date Created:   12 Feb 2002
// Last Change Date:  
// Project:        Black Jack
// Filename:       card.h
//
// Overview:  This include contains the card object interface
//     
//--------------------------------------------------------------------


# ifndef CARDH // ensure only included once
# define CARDH

enum Suits {NO_SUIT = 0, HEART=1, SPADE=2, DIAMOND=3, CLUB=4};

class Card {
	public:
	  Card(void); 
	  Card(Suits s, int v);
	  void initialize(Suits s, int v);
	  int value()  {return m_value;};
	  Suits suit() {return m_suit;};
	  bool used()   {return m_used;}
	  void UpdateUsed(bool u) {m_used = u;};
	  void print(void);
	private:
      Suits m_suit;
	  int   m_value;     //  value goes from 1-13,  11=jack, 12=queen, 13=king, 1=ace              
	  bool  m_used;     //   has this card been dealt?
};


void PrintSuit(Suits s);


# endif
