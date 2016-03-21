//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   April 20, 2002
// Last Change Date:  April 20, 2002
// Project:        MP3 MOOD
// Filename:       CMoodMgr.cpp
//
// Overview:  This include contains the implentation of a
//			  CMoodMgr class/object.
//     
//--------------------------------------------------------------------

#include "CMoodMgr.h"

CMoodMgr::CMoodMgr(string album_title,string song_title,string name_of_artist,
				   string muzix_web_link,string product_id,string file_size,
				   string price_full_song,string song_duration,string encrypt)
{
	setCMoodMgr(album_title,song_title,name_of_artist,muzix_web_link,product_id,
		file_size,price_full_song,song_duration,encrypt);
	cout << "Constructor.\n";
}

void CMoodMgr::setCMoodMgr(string& album_title,string& song_title,string& name_of_artist,
						   string& muzix_web_link,string& product_id,string& file_size,
						   string& price_full_song,string& song_duration,string& encrypt)
{
	CSongInfo::CSongInfo(album_title,song_title,name_of_artist,file_size);

	CPromoSongInfo::CPromoSongInfo(price_full_song, muzix_web_link);

	CSecureSongInfo::CSecureSongInfo(song_duration, product_id, encrypt);
}

void CMoodMgr::Input_MOOD_Data(CMoodMgr* MoodData, const int& size)
{
	string album_title, song_title, name_of_artist,
				    muzix_web_link, product_id,
					song_duration,file_size, 
					price_full_song, encrypt, ans;
	
	for(int index=0; index < size; index++)
	{
		cout << "Please enter a valid value for each "
			<< "parameter you are prompted for song: " << index + 1
			<< endl << "The album_title?> ";
 		cin >> album_title; MoodData[index].album_title = album_title;

		cout << "\nThe song_title?> ";
		cin >> song_title; MoodData[index].song_title = song_title;

		cout << "\nThe name_of_artist?> ";
		cin >> name_of_artist; MoodData[index].name_of_artist = name_of_artist;

		cout << "\nThe muzix_web_link?> ";
		cin >> muzix_web_link; MoodData[index].muzix_web_link = muzix_web_link;

		cout << "\nThe product_id?> ";
		cin >> product_id; MoodData[index].product_id = product_id;

		cout << "\nThe file_size?> ";
		cin >> file_size; MoodData[index].file_size = file_size;

		cout << "\nThe price_full_song?> ";
		cin >> price_full_song; MoodData[index].price_full_song = price_full_song;

		cout << "\nThe song_duration?> ";
		cin >> song_duration; MoodData[index].song_duration = song_duration;

		cout << "\nThe encryption type?> ";
		cin >> encrypt; MoodData[index].encrypt = encrypt;
		
		MoodData[index].setCMoodMgr(album_title,song_title,name_of_artist,
			muzix_web_link,product_id,file_size,price_full_song,
			song_duration, encrypt);
		cout << "Would you like to write the Mood Data?> (Y/N) ";
		cin >> ans; 
		cout << "\nYou entered " << ans << endl;
		if (ans == "Y" || ans == "y")
			Write_Mood_Data(MoodData, index);
	}
}

void CMoodMgr::Edit_MOOD_Data(CMoodMgr* MoodData, const int& size)
{
	string album_title, song_title, name_of_artist,
				    muzix_web_link, product_id,
					price_full_song, song_duration,
					file_size, encrypt, ans;
	int song_number = size + 1;
	cout << "Would you like to edit the Mood Data?> (Y/N)";
	cin >> ans;
	cout << "\nYou entered " << ans << endl;
	while (ans == "Y" || ans == "y")
	{
		cout << "Which song would you like to edit?> ";
		cin >> song_number;
		cout << "You entered " << song_number << endl
			<< "Please enter all Mood Data as you are prompted: \n";
		Read_Mood_Data(MoodData, song_number);

		cout << "The album_title?> ";
 		cin >> album_title; MoodData[song_number].album_title = album_title;

		cout << "\nThe song_title?> ";
		cin >> song_title; MoodData[song_number].song_title = song_title;

		cout << "\nThe name_of_artist?> ";
		cin >> name_of_artist; MoodData[song_number].name_of_artist = name_of_artist;

		cout << "\nThe muzix_web_link?> ";
		cin >> muzix_web_link; MoodData[song_number].muzix_web_link = muzix_web_link;

		cout << "\nThe product_id?> ";
		cin >> product_id; MoodData[song_number].product_id = product_id;

		cout << "\nThe file_size?> ";
		cin >> file_size; MoodData[song_number].file_size = file_size;

		cout << "\nThe price_full_song?> ";
		cin >> price_full_song; MoodData[song_number].price_full_song = price_full_song;

		cout << "\nThe song_duration?> ";
		cin >> song_duration; MoodData[song_number].song_duration = song_duration;

		cout << "\nThe encryption type?> ";
		cin >> encrypt; MoodData[song_number].encrypt = encrypt;

		MoodData[song_number].setCMoodMgr(album_title,song_title,name_of_artist,
			muzix_web_link,product_id,file_size,price_full_song,song_duration,encrypt);
		cout << "Would you like to write the Mood Data?> (Y/N) ";
		cin >> ans; 
		cout << "\nYou entered " << ans << endl;
		if (ans == "Y" || ans == "y")
			Write_Mood_Data(MoodData, song_number);
		cout << "Continue Editing?> (Y/N) ";
		cin >> ans; 
		cout << "\nYou entered " << ans << endl;
	}
}

void CMoodMgr::Write_Mood_Data(CMoodMgr* MoodData, const int& size)
{
	ofstream oFile("c:\\Matt'sOutPut.txt");
	cout << "Writing output to c:\\Matt'sOutPut.txt"
		<< " for song number " << size + 1 << endl;
	if (oFile.fail())
		cout << "The ofstream failed to open.\n";
	for (int x = 0; x < size; x++)
	{
		oFile << MoodData[x].album_title << endl
			<< MoodData[x].song_title << endl
			<< MoodData[x].name_of_artist << endl
			<< MoodData[x].muzix_web_link << endl
			<< MoodData[x].price_full_song << endl
			<< MoodData[x].file_size << endl
			<< MoodData[x].price_full_song << endl
			<< MoodData[x].song_duration << endl
			<< MoodData[x].encrypt << endl << endl;
	}
	oFile.close();
}

void CMoodMgr::Read_Mood_Data(CMoodMgr* MoodData, const int& size)
{
	ifstream iFile("c:\\Matt'sOutPut.txt");
	if (iFile.fail())
		cout << "The ifstream failed to open,\n";
	for (int x = 0; x < size; x++)
	{
		iFile >> MoodData[x].album_title
			>> MoodData[x].song_title
			>> MoodData[x].name_of_artist
			>> MoodData[x].muzix_web_link
			>> MoodData[x].price_full_song
			>> MoodData[x].file_size
			>> MoodData[x].price_full_song
			>> MoodData[x].song_duration
			>> MoodData[x].encrypt;
	}
	iFile.close();
}

CMoodMgr* CMoodMgr::Sort_Data(CMoodMgr* MoodData, const int& size)
{
	for (int y = 0; y < size; y++)
	{
		for (int z = 0; z < size; z++)
		{
			if (MoodData[y].name_of_artist < 
				MoodData[z].name_of_artist)
				Swap_Values(MoodData[y], MoodData[z]);
		}
	}
	cout << "\nHeres the data you entered sorted by name of artist: \n";
	for (int x=0; x < size; x++)
	{
		
		cout << "For song " << x + 1 << endl
			<< MoodData[x].album_title << endl
			<< MoodData[x].song_title << endl
			<< MoodData[x].name_of_artist << endl
			<< MoodData[x].muzix_web_link << endl
			<< MoodData[x].price_full_song << endl
			<< MoodData[x].file_size << endl
			<< MoodData[x].price_full_song << endl
			<< MoodData[x].song_duration << endl
			<< MoodData[x].encrypt << endl;
	}
		
	for (y = 0; y < size; y++)
	{
		for (int z = 0; z < size; z++)
		{
			if (MoodData[y].song_title < 
				MoodData[z].song_title)
				Swap_Values(MoodData[y],
				MoodData[z]);
		}
	}
	cout << "\nHeres the data you entered sorted by song title: \n";
	for (x=0; x < size; x++)
	{
		cout << "For song " << x + 1 << endl
			<< MoodData[x].album_title << endl
			<< MoodData[x].song_title << endl
			<< MoodData[x].name_of_artist << endl
			<< MoodData[x].muzix_web_link << endl
			<< MoodData[x].price_full_song << endl
			<< MoodData[x].file_size << endl
			<< MoodData[x].price_full_song << endl
			<< MoodData[x].song_duration << endl
			<< MoodData[x].encrypt << endl;
	}
	for (y = 0; y < size; y++)
	{
		for (int z = 0; z < size; z++)
		{
			if (MoodData[y].song_duration < 
				MoodData[z].song_duration)
				Swap_Values(MoodData[y],
				MoodData[z]);
		}
	}
	cout << "\nHeres the data you entered sorted by song duration: \n";
	for (x=0; x < size; x++)
	{
		cout << "For song " << x + 1 << endl
			<< MoodData[x].album_title << endl
			<< MoodData[x].song_title << endl
			<< MoodData[x].name_of_artist << endl
			<< MoodData[x].muzix_web_link << endl
			<< MoodData[x].price_full_song << endl
			<< MoodData[x].file_size << endl
			<< MoodData[x].price_full_song << endl
			<< MoodData[x].song_duration << endl
			<< MoodData[x].encrypt << endl;
	}
	return MoodData;
}

void CMoodMgr::Swap_Values(CMoodMgr& MoodData1, CMoodMgr& MoodData2)
{
	CMoodMgr temp;
	temp.album_title = MoodData1.album_title;
	temp.encrypt = MoodData1.encrypt;
	temp.file_size = MoodData1.file_size;
	temp.muzix_web_link = MoodData1.muzix_web_link;
	temp.name_of_artist = MoodData1.name_of_artist;
	temp.price_full_song = MoodData1.price_full_song;
	temp.product_id = MoodData1.product_id;
	temp.song_duration = MoodData1.song_duration;
	temp.song_title = MoodData1.song_title;
	MoodData1.album_title = MoodData2.album_title;
	MoodData1.encrypt = MoodData2.encrypt;
	MoodData1.file_size = MoodData2.file_size;
	MoodData1.muzix_web_link = MoodData2.muzix_web_link;
	MoodData1.name_of_artist = MoodData2.name_of_artist;
	MoodData1.price_full_song = MoodData2.price_full_song;
	MoodData1.product_id = MoodData2.product_id;
	MoodData1.song_duration = MoodData2.song_duration;
	MoodData1.song_title = MoodData2.song_title;
	MoodData2.album_title = temp.album_title;
	MoodData2.encrypt = temp.encrypt;
	MoodData2.file_size = temp.file_size;
	MoodData2.muzix_web_link = temp.muzix_web_link;
	MoodData2.name_of_artist = temp.name_of_artist;
	MoodData2.price_full_song = temp.price_full_song;
	MoodData2.product_id = temp.product_id;
	MoodData2.song_duration = temp.song_duration;
	MoodData2.song_title = temp.song_title;
}