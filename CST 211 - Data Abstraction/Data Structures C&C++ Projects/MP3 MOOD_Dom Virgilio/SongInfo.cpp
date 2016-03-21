// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// SongInfo.cpp: implementation of the CSongInfo class.
//
//////////////////////////////////////////////////////////////////////

#include "SongInfo.h"
#include "string.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CSongInfo::CSongInfo()
{
	transfer = TRANSFER_UNDEFINED;
}

CSongInfo::~CSongInfo()
{
}

istream &operator>>(istream &stream, CSongInfo &p)
{
	p.input(stream);
	return(stream);
}

void CSongInfo::input(istream &stream)
{
	int tmpInt;
	int tmpTransfer;

	stream >> tmpInt; setType(tmpInt);
	stream >> tmpBuf; setSongName(tmpBuf);
	stream >> tmpBuf; setAlbumName(tmpBuf);
	stream >> tmpBuf; setArtistName(tmpBuf);
	stream >> tmpInt; setFileSize(tmpInt);
	stream >> tmpTransfer; setTransfer(tmpTransfer);
	stream >> tmpBuf; setDate(tmpBuf);
	stream >> tmpBuf; setPopularity(tmpInt);
}

ostream &operator<<(ostream &stream, CSongInfo &p)
{
	p.output(stream);
	return(stream);
}

void CSongInfo::output(ostream &stream)
{
	stream << getType() << ' ';
	stream << getSongName() << ' ';
	stream << getAlbumName() << ' ';
	stream << getArtistName() << ' ';
	stream << getFileSize() << ' ';
	stream << getTransfer() << ' ';
	stream << getDate() << ' ';
	stream << getPopularity() << ' ';
}

CSongInfo & CSongInfo::operator =(CSongInfo &s)
{
	type = s.type;
	strcpy(songName, s.songName);
	strcpy(albumName, s.albumName);
	strcpy(artistName, s.artistName);
	fileSize = s.fileSize;
	transfer = s.transfer;
	strcpy(date, s.date);
	popularity = s.popularity;

	return *this;
}

void CSongInfo::display()
{
	cout << "Type = " << getType() << endl;
	cout << "Song Name = " << format(getSongName()) << endl;
	cout << "Album Name = " << format(getAlbumName()) << endl;
	cout << "Artist Name = " << format(getArtistName()) << endl;
	cout << "File Size = " << getFileSize() << endl;
	cout << "Transfer = " << getTransfer() << endl;
	cout << "Date = " << format(getDate()) << endl;
	cout << "Popularity = " << getPopularity() << endl;
}

void CSongInfo::displayArtistName()
{
	cout << "Artist Name = " << format(getArtistName()) << endl;
}

void CSongInfo::displaySongName()
{
	cout << "Song Name = " << format(getSongName()) << endl;
}

void CSongInfo::stream()
{
	cout << "Song Name = " << format(getSongName()) << endl;
	cout << "Album Name = " << format(getAlbumName()) << endl;
	cout << "Artist Name = " << format(getArtistName()) << endl;
	cout << "Song Popularity = " << getPopularity() << endl;
}


char * CSongInfo::s2u(char *a)
{
	char *pC;
	pC = strchr(a,' ');

	while (pC != NULL) {
		*pC = '_';
		pC = strchr(pC + 1,' ');
	}

	return a; // changes it
}

char * CSongInfo::format(char *a)
{
	strcpy(tmpBuf, a);
	char *pC;
	pC = strchr(tmpBuf,'_');

	while (pC != NULL) {
		*pC = ' ';
		pC = strchr(pC + 1,'_');
	}

	return tmpBuf;
}

void CSongInfo::setTransfer(int t)
{
	switch (t) {
		case 1:
			setTransfer(TRANSFER_STREAMABLE);
			break;
		case 2:
			setTransfer(TRANSFER_DOWNLOADABLE);
			break;
		case 3:
			setTransfer(TRANSFER_BOTH);
			break;
		default:
			setTransfer(TRANSFER_UNDEFINED);
			break;
		}
}

void CSongInfo::setString(char *a, char *b)
{
	char tmp[128];
	strcpy(tmp, b);
	strcpy(a, s2u(tmp));
}
