// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// SecureDownloadMgr.cpp: implementation of the CSecureDownloadMgr class.
//
//////////////////////////////////////////////////////////////////////

#include "SecureDownloadMgr.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CSecureDownloadMgr::CSecureDownloadMgr()
{
}

CSecureDownloadMgr::~CSecureDownloadMgr()
{
}

void CSecureDownloadMgr::display(CSongInfoList *songList)
{
	int n = songList->length();
	CSongInfo *pSong;
	CSecureSongInfo *pSecure;
	encryptionType encryption;
	transferType transfer;
	CSongInfoList sortList;

	cout << "***** CSecureDownloadMgr Output *****" << endl;
	for (int i=0; i<n; i=i+1)
	{
		pSong = songList->get(i);
		transfer = pSong->getTransfer();
		if (pSong->getType() == SONG_SECURE)
		{
			pSecure = (CSecureSongInfo *)songList->get(i);
			encryption = pSecure->getEncryption();
			if ((encryption == SECURE_2) || (encryption == SECURE_3))
			{
				if ((transfer == TRANSFER_DOWNLOADABLE) || (transfer == TRANSFER_BOTH))
				{
					sortList.add(pSecure);
				}
			}
		}
	}

	n = sortList.length();
	for (i=0; i<n-1; i=i+1)
	{
		for (int j=i+1; j < n; j=j+1)
		{
			CSongInfo *pSongI = sortList.get(i);
			CSongInfo *pSongJ = sortList.get(j);
			if (pSongJ->getFileSize() < pSongI->getFileSize())
			{
				CSongInfo *pSongTmp = pSongI;
				sortList.set(i, pSongJ);
				sortList.set(j, pSongTmp);
			}
		}
	}

	for (i=0; i<n; i=i+1)
	{
		pSecure = (CSecureSongInfo *)sortList.get(i);
		pSecure->displaySecureInfo();
		cout << endl;
	}

	cout << endl;
}
