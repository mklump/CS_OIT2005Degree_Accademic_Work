// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// InternetRadio.h: interface for the CInternetRadio class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_INTERNETRADIO_H__A6A68B99_849A_4444_8FEF_23F07E79DB01__INCLUDED_)
#define AFX_INTERNETRADIO_H__A6A68B99_849A_4444_8FEF_23F07E79DB01__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "SongInfoList.h"

class CInternetRadio  
{
public:
	CInternetRadio();
	virtual ~CInternetRadio();

	void stream(CSongInfoList *songList, int popMin=0, int popMax=100);
};

#endif // !defined(AFX_INTERNETRADIO_H__A6A68B99_849A_4444_8FEF_23F07E79DB01__INCLUDED_)
