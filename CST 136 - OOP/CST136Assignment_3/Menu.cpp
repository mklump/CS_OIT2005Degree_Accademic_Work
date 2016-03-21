// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// Menu.cpp: implementation of the CMenu class.
//
//////////////////////////////////////////////////////////////////////

#include "Menu.h"
#include "stdio.h"
#include "stdlib.h"
#include "ctype.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CMenu::CMenu()
{
}

CMenu::~CMenu()
{
}

actionType CMenu::display(menuType m)
{
	switch (m) {
		case MENU_TOP:
			cout << "*** Muzix Main Menu ***" << endl;
			cout << endl;
			cout << "1. New Song" << endl;
			cout << "2. Edit/Delete Song" << endl;
			cout << "3. Read/Write MOOD File" << endl;
			cout << "4. List Songs" << endl;
			cout << "5. Sort Songs" << endl;
			cout << "6. Popularity Menu" << endl;
			cout << endl;
			cout << "0. Exit Muzix Program" << endl;
			switch (getInput()) {
				case 0:
					cout << "Thank you for using Musix." << endl;
					cout << endl;
					return ACTION_EXIT;
					break;
				case 1:
					return ACTION_MENU_NEW;
					break;
				case 2:
					return ACTION_MENU_EDIT;
					break;
				case 3:
					return ACTION_MENU_FILE;
					break;
				case 4:
					return ACTION_MENU_LIST;
					break;
				case 5:
					return ACTION_MENU_SORT;
					break;
				case 6:
					return ACTION_MENU_POPULARITY;
					break;
				default:
					cout << endl;
					cout << "Please choose a number 0-6" << endl;
					cout << endl;
					return ACTION_MENU_TOP;
					break;
			}
			break;
		case MENU_NEW:
			cout << "*** Muzix New Menu ***" << endl;
			cout << endl;
			cout << "1. Create a New Secure Song" << endl;
			cout << "2. Create a New Promo Song" << endl;
			cout << endl;
			cout << "0. Exit to Main Menu" << endl;
			switch (getInput()) {
				case 0:
					return ACTION_MENU_TOP;
					break;
				case 1:
					return ACTION_NEW_SECURE;
					break;
				case 2:
					return ACTION_NEW_PROMO;
					break;
				default:
					cout << endl;
					cout << "Please choose a number 0-2" << endl;
					cout << endl;
					return ACTION_MENU_NEW;
					break;
			}
			break;
		case MENU_EDIT:
			cout << "*** Muzix Edit Menu ***" << endl;
			cout << endl;
			cout << "1. Edit a Song" << endl;
			cout << "2. Delete a Song" << endl;
			cout << endl;
			cout << "0. Exit to Main Menu" << endl;
			switch (getInput()) {
				case 0:
					return ACTION_MENU_TOP;
					break;
				case 1:
					return ACTION_EDIT_SONG;
					break;
				case 2:
					return ACTION_DELETE_SONG;
					break;
				default:
					cout << endl;
					cout << "Please choose a number 0-2" << endl;
					cout << endl;
					return ACTION_MENU_EDIT;
					break;
			}
			break;
		case MENU_FILE:
			cout << "*** Muzix File Menu ***" << endl;
			cout << endl;
			cout << "1. Read a MOOD File" << endl;
			cout << "2. Write a MOOD File" << endl;
			cout << endl;
			cout << "0. Exit to Main Menu" << endl;
			switch (getInput()) {
				case 0:
					return ACTION_MENU_TOP;
					break;
				case 1:
					return ACTION_READ_FILE;
					break;
				case 2:
					return ACTION_WRITE_FILE;
					break;
				default:
					cout << endl;
					cout << "Please choose a number 0-2" << endl;
					cout << endl;
					return ACTION_MENU_FILE;
					break;
			}
			break;
		case MENU_LIST:
			cout << "*** Muzix List Menu ***" << endl;
			cout << endl;
			cout << "1. List All Songs" << endl;
			cout << "2. List Secure Songs" << endl;
			cout << "3. List Promo Songs" << endl;
			cout << endl;
			cout << "0. Exit to Main Menu" << endl;
			switch (getInput()) {
				case 0:
					return ACTION_MENU_TOP;
					break;
				case 1:
					return ACTION_LIST_ALL;
					break;
				case 2:
					return ACTION_LIST_SECURE;
					break;
				case 3:
					return ACTION_LIST_PROMO;
					break;
				default:
					cout << endl;
					cout << "Please choose a number 0-3" << endl;
					cout << endl;
					return ACTION_MENU_LIST;
					break;
			}
			break;
		case MENU_SORT:
			cout << "*** Muzix Sort Menu ***" << endl;
			cout << endl;
			cout << "1. Sort by Artist" << endl;
			cout << "2. Sort by Song Title" << endl;
			cout << "3. Sort by Duration" << endl;
			cout << endl;
			cout << "0. Exit to Main Menu" << endl;
			switch (getInput()) {
				case 0:
					return ACTION_MENU_TOP;
					break;
				case 1:
					return ACTION_SORT_ARTIST;
					break;
				case 2:
					return ACTION_SORT_SONGNAME;
					break;
				case 3:
					return ACTION_SORT_DURATION;
					break;
				default:
					cout << endl;
					cout << "Please choose a number 0-3" << endl;
					cout << endl;
					return ACTION_MENU_SORT;
					break;
			}
			break;
		case MENU_POPULARITY:
			cout << "*** Muzix Popularity Menu ***" << endl;
			cout << endl;
			cout << "1. Modify the Popularity of a Song" << endl;
			cout << "2. Sort Songs by Popularity" << endl;
			cout << "3. Sort Artists by Popularity" << endl;
			cout << endl;
			cout << "0. Exit to Main Menu" << endl;
			switch (getInput()) {
			case 0:
				return ACTION_MENU_TOP;
				break;
			case 1:
				return ACTION_MODIFY_POPULARITY;
				break;
			case 2:
				return ACTION_SORT_SONGS_POPULARITY;
				break;
			case 3:
				return ACTION_SORT_ARTISTS_POPULARITY;
				break;
			default:
				cout << endl;
				cout << "Plese choose a number 0-2" << endl;
				cout << endl;
				return ACTION_MENU_POPULARITY;
				break;
			}
			break;
		default:
			cout << endl;
			cout << "Please choose a number 0-6" << endl;
			cout << endl;
			return ACTION_MENU_TOP;
			break;
	}

	return ACTION_MENU_TOP;
}

int CMenu::getInput()
{
	cout << endl;
	cout << "Selection: " << flush;
	gets(tmpBuf);
	cout << endl;
	cout << endl;

	if (!isdigit(tmpBuf[0])) {
		return (int)-1;
	}
	else {
		return atoi(tmpBuf);
	}
}