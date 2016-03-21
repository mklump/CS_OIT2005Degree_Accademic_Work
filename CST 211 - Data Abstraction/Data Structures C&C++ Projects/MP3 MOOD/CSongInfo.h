//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #2 Part 1
// Date Created:   April 19, 2002
// Last Change Date:  April 19, 2002
// Project:        MP3 MOOD
// Filename:       CSongInfo.h
//
// Overview:  This include contains the interface for the
//			  CSongInfo class.
//     
//-------------------------------------------------------------------

#ifndef CSONGINFO_H
#define CSONGINFO_H

#include <cstdlib>
#include <fstream>
#include <iostream>
#include <string>
#include <time.h>
using namespace std;

class CSongInfo
{
public:
	//definition of default constructor calls setCSongInfo
	//any of the four that not initialized are set to their
	//respective default:
	CSongInfo(string="",string="",string="",string="");    //Default Constructor
	void setCSongInfo(string&, string&, string&, string&); //Constructor

	~CSongInfo() {};		//Destructor

	string Song_Title();    //Accessor function
	string Album_Title();   //Accessor function
	string Name_Of_Artist();//Accessor function
	string File_Size();		//Accessor function
	char* Entry_Date();		//Accessor function
	
	void setEntryDate();	//Set date of creation as current system date
	bool Streamable();		//Playable based on filesize
	bool Downloadable();	//Based on filesize

protected:
	string song_title,
		   album_title,
		   name_of_artist,
		   file_size;  //This is in units of kilobytes.

	char* entrydate;
	time_t start;
};

#endif //CSONGINFO_H