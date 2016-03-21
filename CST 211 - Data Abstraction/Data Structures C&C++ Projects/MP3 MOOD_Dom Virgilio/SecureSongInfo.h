// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// SecureSongInfo.h: interface for the CSecureSongInfo class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_SECURESONGINFO_H__491A1008_400E_42F8_BDE3_948E5A1F6158__INCLUDED_)
#define AFX_SECURESONGINFO_H__491A1008_400E_42F8_BDE3_948E5A1F6158__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <iostream.h>

#include "SongInfo.h"
#include "mooddefs.h"

enum encryptionType
{ 
	SECURE_UNDEFINED=0,
	SECURE_1=1,
	SECURE_2=2, 
	SECURE_3=3
};

class CSecureSongInfo : public CSongInfo  
{
public:
	CSecureSongInfo();
	virtual ~CSecureSongInfo();

	friend istream &operator >>(istream &, CSecureSongInfo &);
	void input(istream &);

	friend ostream &operator <<(ostream &, CSecureSongInfo &);
	void output(ostream &);

	CSecureSongInfo &operator =(CSecureSongInfo &);

	void display();
	void displayDuration();
	void displaySecureInfo();

	void setDuration(double d) {duration = d;};
	double getDuration() {return duration;};

	void setEncryption(encryptionType e) {encryption = e;};
	void setEncryption(int e);
	encryptionType getEncryption() {return encryption;}; 

	void setId(int i) {id = i;};
	int getId() {return id;};

private:
	double duration;
	encryptionType encryption;
	int id;
};

#endif // !defined(AFX_SECURESONGINFO_H__491A1008_400E_42F8_BDE3_948E5A1F6158__INCLUDED_)
