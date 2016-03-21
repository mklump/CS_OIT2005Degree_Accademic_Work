//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #2 Part 1
// Date Created:   April 20, 2002
// Last Change Date:  April 20, 2002
// Project:        MP3 MOOD
// Filename:       CPromoSongInfo.h
//
// Overview:  This include contains the interface for the
//			  CPromoSongInfo class.
//     
//-------------------------------------------------------------------

#ifndef CPROMOSONGINFO_H
#define CPROMOSONGINFO_H

#include "CSongInfo.h"

class CPromoSongInfo : CSongInfo
{
public:
	CPromoSongInfo(string="", string="");
	void setCPromoSongInfo(string&, string&);
	
	~CPromoSongInfo() {};

	bool CheckDuration(); //Returns true if the promo expired

private:
	string price_full_song;
	string muzix_web_link;
};

#endif //CPROMOSONGINFO_H