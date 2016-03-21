// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// InternetRadio.cpp: implementation of the CInternetRadio class.
//
//////////////////////////////////////////////////////////////////////

#include "InternetRadio.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CInternetRadio::CInternetRadio()
{
}

CInternetRadio::~CInternetRadio()
{
}

void CInternetRadio::stream(CSongInfoList *songList, int popMin, int popMax)
{
	int n = songList->length();
	CSongInfo *pSong;
	CPromoSongInfo *pPromo;
	transferType transfer;
	if (!(popMin < 0) && !(popMax > 100))
		songList->sortSongPopularity();

	cout << "***** InternetRadio Output *****" << endl;
	for (int i=n-1; i>=0; i=i-1)  //Please start at the end of the song list and walk through it backwards.
	{  
		pSong = songList->get(i);
		transfer = pSong->getTransfer();

		if ((transfer == TRANSFER_STREAMABLE) || (transfer == TRANSFER_BOTH))
		{
			cout << "***** Streaming Song #" << i+1 << " " << endl; // Note: user sees first word as #1, not 0
			pSong->stream();
			cout << endl;

			if (pSong->getType() == SONG_PROMO)
			{
				pPromo = (CPromoSongInfo *)songList->get(i);
				cout << "We hope you enjoyed this promotional song clip."<< endl;
				cout << "The popularity for this song is: " << pPromo->getPopularity() << endl;
				cout << "The full song costs: "<< pPromo->getPrice() << endl;
				cout << "If you would like to buy this song, Visit: "<< pPromo->getWebLink() << endl;
				cout << "Better hurry - this promotion ends in "<< pPromo->getNumDays() << " days" << endl;
				cout << endl;
			}
		}
	}

	cout << endl;
}
