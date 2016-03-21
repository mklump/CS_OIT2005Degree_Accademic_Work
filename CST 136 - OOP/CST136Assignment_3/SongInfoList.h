// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// SongInfoList.h: interface for the CSongInfoList class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_SONGINFOLIST_H__07395ABE_031F_4202_AACC_3CD6451AF171__INCLUDED_)
#define AFX_SONGINFOLIST_H__07395ABE_031F_4202_AACC_3CD6451AF171__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "SongInfo.h"
#include "SecureSongInfo.h"
#include "PromoSongInfo.h"
#include <fstream.h>

enum displayType
{ 
	DISPLAY_ALL=0,
	DISPLAY_SECURE=1,
	DISPLAY_PROMO=2
};


#define MAX_NUMBER_OF_SONGS 1000

class CSongInfoList  
{
public:
	CSongInfoList();
	virtual ~CSongInfoList();

	CSongInfoList &operator =(CSongInfoList &);

	void add(CSecureSongInfo *pSong);
	void add(CPromoSongInfo *pSong);
	void remove(int index);

	void set(int index, CSongInfo *pSong) {song[index] = pSong;};
	CSongInfo *get(int index) {return song[index];};

	void input(ifstream file);
	void output(ofstream file);
	void sortArtist();
	void sortSongName();
	void sortDuration();
	void sortSongPopularity();
	void sortArtistPopularity();

	void reset();

	void display(displayType);

	int length() {return n;};

private:
	int version;
	int n;
	CSongInfo * song[MAX_NUMBER_OF_SONGS];
};

#endif // !defined(AFX_SONGINFOLIST_H__07395ABE_031F_4202_AACC_3CD6451AF171__INCLUDED_)
