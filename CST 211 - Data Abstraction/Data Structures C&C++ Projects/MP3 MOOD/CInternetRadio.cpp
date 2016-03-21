//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   April 27, 2002
// Last Change Date:  April 27, 2002
// Project:        MP3 MOOD
// Filename:       CInternetRadio.cpp
//
// Overview:  This include contains the implentation of a
//			  CInternetRadio class/object.
//     
//--------------------------------------------------------------------

#include "CInternetRadio.h"

CInternetRadio::CInternetRadio(string a, string b, string c)
{
	setCInternetRadio(a, b, c);
}

void CInternetRadio::setCInternetRadio(string& song, string& album, 
					   string& name)
{
	album_title = album;
	song_title = song;
	name_of_artist = name;
}

bool CInternetRadio::IsPromo(CMoodMgr* MoodData, const int& song_number)
{
	if (MoodData[song_number].Encrypt() == "NOSECURITY")
		return true;
	else
		return false;
}

bool CInternetRadio::Streamable()
{
	int temp = atoi(file_size.c_str());
	if (temp <= 128)
		return true;
	else 
		return false;
}

void CInternetRadio::Stream(CMoodMgr* MoodData, const int& size)
{
	for (int x = 0; x < size; x++)
	{
		if (Streamable() && IsPromo(MoodData, x))
		{
			cout << "The following songs are streamable and are promotions :\n"
				<< "For song " << x + 1 << endl
				<< MoodData[x].Album_Title() << endl
				<< MoodData[x].Song_Title() << endl
				<< MoodData[x].Name_Of_Artist() << endl;
		}
		if (Streamable() && !IsPromo(MoodData, x))
		{
			cout << "The following songs are streamable and available for sale :\n"
				<< "For song " << x + 1 << endl
				<< MoodData[x].Album_Title() << endl
				<< MoodData[x].Song_Title() << endl
				<< MoodData[x].Name_Of_Artist() << endl;
		}
		if (!Streamable())
		{
			cout << "The following songs are not streamable :\n"
				<< "For song " << x + 1 << endl
				<< MoodData[x].Album_Title() << endl
				<< MoodData[x].Song_Title() << endl
				<< MoodData[x].Name_Of_Artist() << endl;
		}
	}
}