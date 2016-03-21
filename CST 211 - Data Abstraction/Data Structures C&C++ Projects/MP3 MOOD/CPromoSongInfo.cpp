//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   April 20, 2002
// Last Change Date:  April 20, 2002
// Project:        MP3 MOOD
// Filename:       CPromoSongInfo.cpp
//
// Overview:  This include contains the implentation of a
//			  CPromoSongInfo object.
//     
//--------------------------------------------------------------------

#include "CPromoSongInfo.h"

CPromoSongInfo::CPromoSongInfo(string fullprice, string website)
{
	setCPromoSongInfo(fullprice, website);
}

void CPromoSongInfo::setCPromoSongInfo(string& fullprice, string& website)
{
	price_full_song = fullprice;
	muzix_web_link  = website;
}

bool CPromoSongInfo::CheckDuration()
{
    time_t finish, elapsedtime;
	time(&finish);
	elapsedtime = difftime(finish, start);
	if (elapsedtime > 2592000)
		return true;
	else
		return false;
}
