// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// SongInfo.h: interface for the CSongInfo class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_SONGINFO_H__15155C72_8648_4AC1_A439_57725AABD92B__INCLUDED_)
#define AFX_SONGINFO_H__15155C72_8648_4AC1_A439_57725AABD92B__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <iostream.h>

enum transferType
{ 
	TRANSFER_UNDEFINED=0,
	TRANSFER_STREAMABLE=1,
	TRANSFER_DOWNLOADABLE=2, 
	TRANSFER_BOTH=3
};

class CSongInfo  
{
public:
	CSongInfo();
	virtual ~CSongInfo();

	friend istream &operator >>(istream &, CSongInfo &);
	void input(istream &);

	friend ostream &operator <<(ostream &, CSongInfo &);
	void output(ostream &);

	CSongInfo &operator =(CSongInfo &);

	void display();
	void displayArtistName();
	void displaySongName();

	void stream();

	char *s2u(char *a); // space to underscore, changes original
	char *format(char *a); // underscore to space, uses displayCopy

	void setType(int t) {type = t;};
	int getType() {return type;};

	void setSongName(char *s) {setString(songName, s);};	
	char *getSongName() {return songName;};

	void setAlbumName(char *a) {setString(albumName, a);};
	char *getAlbumName() {return albumName;};

	void setArtistName(char *a) {setString(artistName, a);};
	char *getArtistName() {return artistName;};

	void setFileSize(int f) {fileSize = f;};
	int getFileSize() {return fileSize;};

	void setTransfer(transferType t) {transfer = t;};
	void setTransfer(int t);
	transferType getTransfer() {return transfer;};

	void setDate(char *d) {setString(date, d);};
	char *getDate() {return date;};

	void setPopularity(int p)   //added by Matthew Klump
	{
		if (p < 0)  p = 0;
		if (p > 100) p = 100;
		popularity = p;
	};
	int getPopularity() {return popularity;}; //added line of code

	void setString(char *a, char *b);

	char tmpBuf[128];

private:
	int type;
	char songName[128];
	char albumName[128];
	char artistName[128];
	int fileSize;
	transferType transfer;
	char date[128];
	int popularity;	 //added for Assignment 3 part 2 by Matthew Klump
};

#endif // !defined(AFX_SONGINFO_H__15155C72_8648_4AC1_A439_57725AABD92B__INCLUDED_)
