// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// SecureDownloadMgr.h: interface for the CSecureDownloadMgr class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_SECUREDOWNLOADMGR_H__4996E657_D724_4E86_B8B8_FC5D090174E1__INCLUDED_)
#define AFX_SECUREDOWNLOADMGR_H__4996E657_D724_4E86_B8B8_FC5D090174E1__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "SongInfoList.h"

class CSecureDownloadMgr  
{
public:
	CSecureDownloadMgr();
	virtual ~CSecureDownloadMgr();

	void display(CSongInfoList *songList);
};

#endif // !defined(AFX_SECUREDOWNLOADMGR_H__4996E657_D724_4E86_B8B8_FC5D090174E1__INCLUDED_)
