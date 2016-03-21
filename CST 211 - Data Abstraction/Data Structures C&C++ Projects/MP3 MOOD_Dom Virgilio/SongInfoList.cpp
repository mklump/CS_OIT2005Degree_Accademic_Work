// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// SongInfoList.cpp: implementation of the CSongInfoList class.
//
//////////////////////////////////////////////////////////////////////

#include "SongInfoList.h"
#include "SongInfo.h"
#include <string.h>

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CSongInfoList::CSongInfoList()
{
	version = 1;
	n = 0;
}

CSongInfoList::~CSongInfoList()
{
}

CSongInfoList & CSongInfoList::operator =(CSongInfoList &s)
{
	for (int i=0; i<s.n; i=i+1) {
		song[i] = s.song[i];
	}

	return *this;
}

void CSongInfoList::add(CSecureSongInfo *pSong)
{
	CSecureSongInfo *pNew = (CSecureSongInfo *) new CSecureSongInfo;
	*pNew = *pSong;
	song[n] = pNew;
	n = n + 1;
}

void CSongInfoList::add(CPromoSongInfo *pSong)
{
	CPromoSongInfo *pNew = (CPromoSongInfo *) new CPromoSongInfo;
	*pNew = *pSong;
	song[n] = pNew;
	n = n + 1;
}

void CSongInfoList::remove(int index)
{
	for (int i=index; i<n-1; i=i+1) {
		song[i] = song[i + 1];
	}

	n = n - 1;
}

void CSongInfoList::input(ifstream file)
{
	int type;
	CSecureSongInfo *pSecure;
	CPromoSongInfo *pPromo;

	reset();

	file >> version;
	file >> n;

	for (int i=0; i<n; i=i+1) {
		file >> type;
		switch (type) {
			case SONG_SECURE:
				pSecure = new CSecureSongInfo;
				file >> *pSecure;
				song[i] = pSecure;
				break;
			case SONG_PROMO:
				pPromo = new CPromoSongInfo;
				file >> *pPromo;
				song[i] = pPromo;
				break;
		}
	}
}

void CSongInfoList::output(ofstream file)
{
	int type;
	CSongInfo *pSong;
	CSecureSongInfo *pSecure;
	CPromoSongInfo *pPromo;

	file << version << ' ';
	file << n << ' ';

	for (int i=0; i<n; i=i+1) {
		pSong = song[i];
		type = pSong->getType();
		file << type << ' ';

		switch (type) {
			case SONG_SECURE:
				pSecure = (CSecureSongInfo *)song[i];
				file << *pSecure;
				break;
			case SONG_PROMO:
				pPromo = (CPromoSongInfo *)song[i];
				file << *pPromo;
				break;
		}
	}
}

void CSongInfoList::reset()
{
	for (int i=0; i<n; i=i+1) {
		delete song[i];
		song[i] = NULL;
	}

	n = 0;
}

void CSongInfoList::display(displayType d)
{
	CSongInfo *pSong;
	CSecureSongInfo *pSecure;
	CPromoSongInfo *pPromo;
	for (int i=0; i<n; i=i+1) {
		pSong = song[i];
		int type = pSong->getType();
		switch (type) {
			case SONG_SECURE:
				pSecure = (CSecureSongInfo *)pSong;
				if (d != DISPLAY_PROMO) {
					cout << "#" << i+1 << " " << endl; // Note: user sees first word as #1, not 0
					pSecure->display();
					cout << endl;
				}
				break;
			case SONG_PROMO:
				pPromo = (CPromoSongInfo *)pSong;
				if (d != DISPLAY_SECURE) {
					cout << "#" << i+1 << " " << endl; // Note: user sees first word as #1, not 0
					pPromo->display();
					cout << endl;
				}
				break;
		}
	}

	cout << endl;
}

void CSongInfoList::sortArtist()
{
	int i;
	CSongInfoList sortList;
	sortList = *this;
	for (i=0; i<n-1; i=i+1) {
		for (int j=i+1; j < n; j=j+1) {
				CSongInfo *pSongI = sortList.get(i);
				CSongInfo *pSongJ = sortList.get(j);
				if (strcmp(pSongJ->getArtistName(), pSongI->getArtistName()) < 0) {
					CSongInfo *pSongTmp = pSongI;
					sortList.song[i] = pSongJ;
					sortList.song[j] = pSongTmp;
			}
		}
	}

	for (i=0; i<n; i=i+1) {
		cout << "#" << i+1 << " " << endl; // Note: user sees first word as #1, not 0
		sortList.get(i)->displayArtistName();
		cout << endl;
	}

	cout << endl;
}

void CSongInfoList::sortSongName()
{
	int i;
	CSongInfoList sortList;
	sortList = *this;
	for (i=0; i<n-1; i=i+1) {
		for (int j=i+1; j < n; j=j+1) {
				CSongInfo *pSongI = sortList.get(i);
				CSongInfo *pSongJ = sortList.get(j);
				if (strcmp(pSongJ->getSongName(), pSongI->getSongName()) < 0) {
					CSongInfo *pSongTmp = pSongI;
					sortList.song[i] = pSongJ;
					sortList.song[j] = pSongTmp;
			}
		}
	}

	for (i=0; i<n; i=i+1) {
		cout << "#" << i+1 << " " << endl; // Note: user sees first word as #1, not 0
		sortList.get(i)->displaySongName();
		cout << endl;
	}

	cout << endl;
}

void CSongInfoList::sortSongPopularity()
{
	cout << "\nThe song list was successfully sorted\n"
		<< "by each Song's popularity.\n";
	int i;
	double popularityI, popularityJ;
	CSongInfo *pSongI, *pSongJ;
	
	CSongInfoList sortList;
	sortList = *this;

	for (i=0; i < n-1; i++)
	{
		for (int j=i+1; j < n; i++)
		{
			pSongI = sortList.get(i);
			pSongJ = sortList.get(j);

			if (i == n) break;

			popularityI = pSongI->getPopularity();
			popularityJ = pSongJ->getPopularity();

			if (popularityI < popularityJ)
			{
				CSongInfo *pSongTmp = pSongI;
				sortList.song[i] = pSongJ;
				sortList.song[j] = pSongTmp;
			}
		}
	}
}

void CSongInfoList::sortArtistPopularity()
{
	cout << "\nNote:\nEach song's popularity is same as\n"
		<< "the artists popularity.\n";
	int i;
	double popularityI, popularityJ,
		artistsPopularityI, artistsPopularityJ;
	CSongInfo *pSongI, *pSongJ;
	
	CSongInfoList sortList;
	sortList = *this;

	for (i=0; i < n-1; i++)
	{
		for (int j=i+1; j < n; i++)
		{
			pSongI = sortList.get(i);
			pSongJ = sortList.get(j);

			if (i == n) break;

			popularityI = pSongI->getPopularity();
			popularityJ = pSongJ->getPopularity();

			artistsPopularityI = popularityI;
			artistsPopularityJ = popularityJ;

			if (artistsPopularityI < artistsPopularityJ)
			{
				CSongInfo *pSongTmp = pSongI;
				sortList.song[i] = pSongJ;
				sortList.song[j] = pSongTmp;
			}
		}
	}
}

void CSongInfoList::sortDuration()
{
	int i, type;
	double durationI, durationJ;
	CSongInfo *pSong, *pSongI, *pSongJ;
	CSecureSongInfo *pSecure;
	CPromoSongInfo *pPromo;

	CSongInfoList sortList;
	sortList = *this;

	for (i=0; i<n-1; i=i+1) {
		for (int j=i+1; j < n; j=j+1) {
				pSongI = sortList.get(i);
				type = pSongI->getType();

				if (type == SONG_SECURE) {
					pSecure = (CSecureSongInfo *)sortList.get(i);
					durationI = pSecure->getDuration();
				}
				else if (type == SONG_PROMO) {
					pPromo = (CPromoSongInfo *)sortList.get(i);
					durationI = 30.0; // Promos are 30 seconds long
				}
				
				pSongJ = sortList.get(j);
				type = pSongJ->getType();

				if (type == SONG_SECURE) {
					pSecure = (CSecureSongInfo *)sortList.get(j);
					durationJ = pSecure->getDuration();
				}
				else if (type == SONG_PROMO) {
					pPromo = (CPromoSongInfo *)sortList.get(j);
					durationJ = 30.0; // Promos are 30 seconds long
				}
				
				
				if (durationJ < durationI) {
				CSongInfo *pSongTmp = pSongI;
				sortList.song[i] = pSongJ;
				sortList.song[j] = pSongTmp;
			}
		}
	}

	for (i=0; i<n; i=i+1) {
		cout << "#" << i+1 << " " << endl; // Note: user sees first word as #1, not 0
		pSong = sortList.get(i);
		type = pSong->getType();

		if (type == SONG_SECURE) {
			pSecure = (CSecureSongInfo *)sortList.get(i);
			pSecure->displayDuration();
		}
		else if (type == SONG_PROMO) {
			cout << "Duration = 30.0 (PROMO)" << endl; // Promos are 30 seconds long
		}

		cout << endl;
	}

	cout << endl;
}

