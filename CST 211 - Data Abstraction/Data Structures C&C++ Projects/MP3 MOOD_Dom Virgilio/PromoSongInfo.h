// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// PromoSongInfo.h: interface for the CPromoSongInfo class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_PROMOSONGINFO_H__9B00A698_0937_4701_9BAA_06A9CC78D5E0__INCLUDED_)
#define AFX_PROMOSONGINFO_H__9B00A698_0937_4701_9BAA_06A9CC78D5E0__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <iostream.h>

#include "SongInfo.h"
#include "mooddefs.h"

class CPromoSongInfo : public CSongInfo  
{
public:
	CPromoSongInfo();
	virtual ~CPromoSongInfo();

	friend istream &operator >>(istream &, CPromoSongInfo &);
	void input(istream &);

	friend ostream &operator <<(ostream &, CPromoSongInfo &);
	void output(ostream &);

	CPromoSongInfo &operator =(CPromoSongInfo &);

	void display();
	void edit();

	void setPrice(double p) {price = p;};
	double getPrice() {return price;};

	void setWebLink(char *wl){setString(webLink, wl);};
	char *getWebLink() {return webLink;};

	void setNumDays(int n) {numDays = n;};
	int getNumDays() {return numDays;};

private:
	double price;
	char webLink[128];
	int numDays;
};

#endif // !defined(AFX_PROMOSONGINFO_H__9B00A698_0937_4701_9BAA_06A9CC78D5E0__INCLUDED_)
