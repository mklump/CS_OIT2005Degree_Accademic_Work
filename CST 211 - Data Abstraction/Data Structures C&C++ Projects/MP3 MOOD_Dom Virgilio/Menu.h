// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// Menu.h: interface for the CMenu class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_MENU_H__9B728625_3CE0_44B7_95E5_28609483DAC4__INCLUDED_)
#define AFX_MENU_H__9B728625_3CE0_44B7_95E5_28609483DAC4__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <iostream.h>

enum menuType
{ 
	MENU_TOP=0,
	MENU_NEW=1,
	MENU_EDIT=2,
	MENU_FILE=3,
	MENU_LIST=4,
	MENU_SORT=5,
	MENU_POPULARITY=6
};

enum actionType
{ 
	ACTION_NEW_SECURE=0,
	ACTION_NEW_PROMO=1,
	ACTION_EDIT_SONG=2,
	ACTION_DELETE_SONG=3,
	ACTION_READ_FILE=4,
	ACTION_WRITE_FILE=5,
	ACTION_LIST_ALL=6,
	ACTION_LIST_SECURE=7,
	ACTION_LIST_PROMO=8,
	ACTION_SORT_ARTIST=9,
	ACTION_SORT_SONGNAME=10,
	ACTION_SORT_DURATION=11,
	ACTION_EXIT=12,
	ACTION_MENU_TOP=13,
	ACTION_MENU_NEW=14,
	ACTION_MENU_EDIT=15,
	ACTION_MENU_FILE=16,
	ACTION_MENU_LIST=17,
	ACTION_MENU_SORT=18,
	ACTION_MODIFY_POPULARITY=19,
	ACTION_SORT_SONGS_POPULARITY=20,
	ACTION_SORT_ARTISTS_POPULARITY=21,
	ACTION_MENU_POPULARITY=22
};

class CMenu  
{
public:
	CMenu();
	virtual ~CMenu();

	actionType display(menuType m);
	int getInput();
private:
	char tmpBuf[1];
};

#endif // !defined(AFX_MENU_H__9B728625_3CE0_44B7_95E5_28609483DAC4__INCLUDED_)
