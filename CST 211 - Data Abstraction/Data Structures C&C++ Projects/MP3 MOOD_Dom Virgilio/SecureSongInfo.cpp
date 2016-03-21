// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2
//
// SecureSongInfo.cpp: implementation of the CSecureSongInfo class.
//
//////////////////////////////////////////////////////////////////////

#include "SecureSongInfo.h"
#include "string.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CSecureSongInfo::CSecureSongInfo()
{
	setType(SONG_SECURE);
	encryption = SECURE_UNDEFINED;
}

CSecureSongInfo::~CSecureSongInfo()
{
}

istream &operator>>(istream &stream, CSecureSongInfo &p)
{
	p.input(stream);
	return(stream);
}

void CSecureSongInfo::input(istream &stream)
{
	int tmpInt;
	double tmpDouble;

	CSongInfo::input(stream);

	stream >> tmpDouble; setDuration(tmpDouble);
	stream >> tmpInt; setEncryption(tmpInt);
	stream >> tmpInt; setId(tmpInt);
}

ostream &operator<<(ostream &stream, CSecureSongInfo &p)
{
	p.output(stream);
	return(stream);
}

void CSecureSongInfo::output(ostream &stream)
{
	CSongInfo::output(stream);
	stream << getDuration() << ' ';
	stream << getEncryption() << ' ';
	stream << getId() << ' ';
}

CSecureSongInfo & CSecureSongInfo::operator =(CSecureSongInfo &s)
{
	CSongInfo *pSong = (CSongInfo *)this;
	*pSong = s;

	duration = s.duration;
	encryption = s.encryption;
	id = s.id;

	return *this;
}

void CSecureSongInfo::display()
{
	cout << "(SECURE SONG)" << endl;
	CSongInfo::display();
	cout << "Duration = " << getDuration() << endl;
	cout << "Encryption = " << getEncryption() << endl;
	cout << "ID = " << getId() << endl;
	cout << endl;
}

void CSecureSongInfo::displayDuration()
{
	cout << "Duration = " << getDuration() << endl;
}


void CSecureSongInfo::displaySecureInfo()
{
	cout << "Song Name = " << format(getSongName()) << endl;
	cout << "Encryption = " << getEncryption() << endl;
	cout << "File Size = " << getFileSize() << endl;
	if (getPopularity() >= 80) //added condition by Matt
	{
		cout << "*** popularity = " << getPopularity() << " ***\n"; //added output
	}
}

void CSecureSongInfo::setEncryption(int e)
{
	switch (e) {
		case 1:
			setEncryption(SECURE_1);
			break;
		case 2:
			setEncryption(SECURE_2);
			break;
		case 3:
			setEncryption(SECURE_3);
			break;
		default :
			setEncryption(SECURE_UNDEFINED);
			break;
		}
}
