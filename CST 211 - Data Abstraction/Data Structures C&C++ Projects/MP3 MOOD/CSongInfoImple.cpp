//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   April 19, 2002
// Last Change Date:  April 20, 2002
// Project:        MP3 MOOD
// Filename:       CSongInfoImple.cpp
//
// Overview:  This include contains the implentation of a CSongInfo
//			  object.
//     
//--------------------------------------------------------------------

#include "CSongInfo.h"

CSongInfo::CSongInfo(string song, string album, 
					 string artist, string filesize)
{
	setCSongInfo(song, album, artist, filesize);
}

void CSongInfo::setCSongInfo(string& song, string& album,
							 string& artist, string& filesize)
{
	song_title     = song;
	album_title    = album;
	name_of_artist = artist;
	file_size      = filesize;
	setEntryDate();
}

bool CSongInfo::Streamable()
{
	int temp = atoi(file_size.c_str());
	if (temp <= 128)
		return true;
	else 
		return false;
}

bool CSongInfo::Downloadable()
{
	int temp = int(file_size.c_str());
	if (temp <= 1024)
		return true;
	else
		return false;
}

string CSongInfo::Song_Title()
{
	return song_title;
}
string CSongInfo::Album_Title()
{
	return album_title;
}
string CSongInfo::Name_Of_Artist()
{
	return name_of_artist;
}

string CSongInfo::File_Size()
{
	return file_size;
}

char* CSongInfo::Entry_Date()
{
	return entrydate;
}

void CSongInfo::setEntryDate()
{
	time(&start);
}