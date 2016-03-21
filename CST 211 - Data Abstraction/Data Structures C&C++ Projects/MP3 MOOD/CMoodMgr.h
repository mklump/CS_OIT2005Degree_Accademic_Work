//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #2 Part 1
// Date Created:   April 21, 2002
// Last Change Date:  April 21, 2002
// Project:        MP3 MOOD
// Filename:       CMoodMrg.h
//
// Overview:  This include contains the interface for the
//			  CMoodMgr class/object.
//     
//-------------------------------------------------------------------

#ifndef CMOODMGR_H
#define CMOODMGR_H

#include "CSongInfo.h"
#include "CPromoSongInfo.h"
#include "CSecureSongInfo.h"

class CMoodMgr
{
public:
	CMoodMgr(string="",string="",string="",string="",string="",string="",
		string="",string="",string=""); //Default constructor

	void setCMoodMgr(string& album_title,string& song_title,string& name_of_artist,
		string& muzix_web_link,string& product_id,string& file_size,
		string& price_full_song,string& song_duration,string& encrypt);
	
	void Input_MOOD_Data(CMoodMgr* MoodData, const int& size);
	
	void Edit_MOOD_Data(CMoodMgr* MoodData, const int& size);

	void Write_Mood_Data(CMoodMgr* MoodData, const int& size);

	void Read_Mood_Data(CMoodMgr* MoodData, const int& size);

	CMoodMgr* Sort_Data(CMoodMgr* MoodData, const int& size);

	void Swap_Values(CMoodMgr& MoodData1, CMoodMgr& MoodData2);

	string Album_Title()        {return album_title;}; //Accessor function
	string Song_Title()          {return song_title;}; //Accessor function
	string Name_Of_Artist()  {return name_of_artist;}; //Accessor function
	string Muzix_Web_Link()  {return muzix_web_link;}; //Accessor function
	string Product_Id()          {return product_id;}; //Accessor function
	string File_Size()            {return file_size;}; //Accessor function
	string Price_Full_Song(){return price_full_song;}; //Accessor function
	string Song_Duration()    {return song_duration;}; //Accessor function
	string Encrypt()                {return encrypt;}; //Accessor function

	~CMoodMgr() {cout << "Destructor.\n";};
protected:
	string album_title,
		song_title,
		name_of_artist,
		muzix_web_link,
		product_id,
		file_size,
		price_full_song,
		song_duration,
		encrypt;
};

#endif //CMOODMGR_H