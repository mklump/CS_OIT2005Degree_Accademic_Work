//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #2 Part 1
// Date Created:   April 20, 2002
// Last Change Date:  April 20, 2002
// Project:        MP3 MOOD
// Filename:       CSecureSongInfo.h
//
// Overview:  This include contains the interface for the
//			  CSecureSongInfo class.
//     
//-------------------------------------------------------------------
#ifndef CSECURESONGINFO_H
#define CSECURESONGINFO_H

#include "CSongInfo.h"

enum encrypt_type {NOSECUREITY=0, SECURE_1=1, SECURE_2=2, SECURE_3=3};

class CSecureSongInfo : CSongInfo
{
public:
	CSecureSongInfo(string="",string="",string="");
	void setCSecureSongInfo(string&, string&, string&);

	encrypt_type Set_Security(const string& encrypt, encrypt_type& type);

	~CSecureSongInfo() {};
	string Song_Duration()  {return song_duration;}; //Accessor fuction
	string Product_Id()     {return product_id;};	 //Accessor fuction
	encrypt_type Encrypt()  {return encryption;};	 //Accessor fuction
	
private:
	string song_duration, //In units of seconds
		   product_id,
		   encrypt;		  //Used for setting the security
	encrypt_type encryption;
};

#endif //CSECURESONGINFO_H