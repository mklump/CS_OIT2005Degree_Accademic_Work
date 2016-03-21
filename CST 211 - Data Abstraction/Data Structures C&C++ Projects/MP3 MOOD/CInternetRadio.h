//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #2 Part II
// Date Created:   April 21, 2002
// Last Change Date:  April 21, 2002
// Project:        MP3 MOOD
// Filename:       CInternetRadio.h
//
// Overview:  This include contains the interface for the
//			  CInternetRadio class/object.
//     
//-------------------------------------------------------------------

#ifndef CINTERNETRADIO_H
#define CINTERNETRADIO_H

#include "CMoodMgr.h"

class CInternetRadio : CMoodMgr
{
public:
	CInternetRadio(string="",string="",string="");

	void setCInternetRadio(string& song_title, string& album_title,
		string& name_of_artist);

	bool IsPromo(CMoodMgr* MoodData, const int& song_number);
	//Returns true if the song in question is a promotion.

	bool Streamable(); //Returns true if file size is small enough.

	void Stream(CMoodMgr* MoodData, const int& size);
	//This Outputs the song stream basics.

	string Song_Title()	       {return song_title;};//Accessor function
	string Album_Title()      {return album_title;};//Accessor function
	string Name_Of_Artist(){return name_of_artist;};//Accessor function

	~CInternetRadio() {};
private:
	string song_title,
		album_title,
		name_of_artist;
};

#endif //CINTERNETRADIO_H