// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// MoodMgr.h: interface for the CMoodMgr class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_MOODMGR_H__D6719E75_0E79_4F9C_BDE9_147A1FA48DC7__INCLUDED_)
#define AFX_MOODMGR_H__D6719E75_0E79_4F9C_BDE9_147A1FA48DC7__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "SongInfo.h"
#include "SongInfoList.h"
#include "Menu.h"

class CMoodMgr  
{
public:
	CMoodMgr();
	virtual ~CMoodMgr();

	void createSong(int type);
	void editSong();
	void editPopularity();
	void deleteSong();
	void input();
	void output();
	void list() {songList.display(DISPLAY_ALL);};
	void listSecure() {songList.display(DISPLAY_SECURE);};
	void listPromo() {songList.display(DISPLAY_PROMO);};
	void sortArtist() {songList.sortArtist();};
	void sortSongName() {songList.sortSongName();};
	void sortDuration() {songList.sortDuration();};
	void sortSongPopularity() {songList.sortSongPopularity();};
	void sortArtistPopularity() {songList.sortArtistPopularity();};

	void displayMenu(menuType m);
	void displayMessage(char *message, bool bShowN=false, int n=0);

	void getInputString(char *prompt, char *to, bool bHint=false, char *hint=NULL);
	void getInputInt(char *prompt, int *to, bool bHint=false, int hint=0);
	void getInputDouble(char *prompt, double *to, bool bHint=false, double hint=0.0);

	CSongInfoList * getSongList() {return &songList;};

	void test();

private:
	CMenu menu;
	CSongInfoList songList;
};

#endif // !defined(AFX_MOODMGR_H__D6719E75_0E79_4F9C_BDE9_147A1FA48DC7__INCLUDED_)