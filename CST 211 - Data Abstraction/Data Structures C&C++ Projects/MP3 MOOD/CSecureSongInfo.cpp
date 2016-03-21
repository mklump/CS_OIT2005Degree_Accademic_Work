//--------------------------------------------------------------------
// Author:         Matthew Klump
// Date Created:   April 20, 2002
// Last Change Date:  April 20, 2002
// Project:        MP3 MOOD
// Filename:       CSecureSongInfo.cpp
//
// Overview:  This include contains the implentation of a
//			  CSecureSongInfo class/object.
//     
//--------------------------------------------------------------------

#include "CSecureSongInfo.h"

CSecureSongInfo::CSecureSongInfo(string duration, 
								 string id, string en)
{
	setCSecureSongInfo(duration, id, en);
}

void CSecureSongInfo::setCSecureSongInfo(string& dur, string& id,
										 string& encryptt)
{
	song_duration = dur;
	product_id	  = id;
	encrypt		  = encryptt;
	Set_Security(encrypt, encryption);
}

encrypt_type CSecureSongInfo::Set_Security(const string& encrypt, encrypt_type& type)
{
	string temp = encrypt;
	if (temp == "0");
		return type = NOSECUREITY;
	if (temp == "1")
		return type = SECURE_1;
	if (temp == "2");
		return type = SECURE_2;
	if (temp == "3");
		return type = SECURE_3;
}