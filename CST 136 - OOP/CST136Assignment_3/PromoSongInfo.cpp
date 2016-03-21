// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

//// PromoSongInfo.cpp: implementation of the CPromoSongInfo class.
//
//////////////////////////////////////////////////////////////////////

#include "PromoSongInfo.h"
#include "string.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CPromoSongInfo::CPromoSongInfo()
{
	setType(SONG_PROMO);
}

CPromoSongInfo::~CPromoSongInfo()
{
}

istream &operator>>(istream &stream, CPromoSongInfo &p)
{
	p.input(stream);
	return(stream);
}

void CPromoSongInfo::input(istream &stream)
{
	int tmpInt;
	double tmpDouble;

	CSongInfo::input(stream);

	stream >> tmpDouble; setPrice(tmpDouble);
	stream >> tmpBuf; setWebLink(tmpBuf);
	stream >> tmpInt; setNumDays(tmpInt);
}

ostream &operator<<(ostream &stream, CPromoSongInfo &p)
{
	p.output(stream);
	return(stream);
}

void CPromoSongInfo::output(ostream &stream)
{
	CSongInfo::output(stream);
	stream << getPrice() << ' ';
	stream << getWebLink() << ' ';
	stream << getNumDays() << ' ';
}

CPromoSongInfo & CPromoSongInfo::operator =(CPromoSongInfo &s)
{
	CSongInfo *pSong = (CSongInfo *)this;
	*pSong = s;

	price = s.price;
	strcpy(webLink, s.webLink);
	numDays = s.numDays;

	return *this;
}

void CPromoSongInfo::display()
{
	cout << "(PROMO SONG)" << endl;
	CSongInfo::display();
	cout << "Price = " << getPrice() << endl;
	cout << "WebLink = " << format(getWebLink()) << endl;
	cout << "Promotional Length = " << getNumDays() << endl;
	cout << endl;
}

void CPromoSongInfo::edit()
{
}
