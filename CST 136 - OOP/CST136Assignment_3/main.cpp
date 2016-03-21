// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

#include <iostream.h>
#include "MoodMgr.h"
#include "InternetRadio.h"
#include "SecureDownloadMgr.h"

int main(int argc, char* argv[])
{
	// Part I
	CMoodMgr moodMgr;
	moodMgr.test();
	moodMgr.displayMenu(MENU_TOP);

	// Part II - A
	CInternetRadio internetRadio;
	internetRadio.stream(moodMgr.getSongList());

	// Part II - B
	CSecureDownloadMgr secureDownloadMgr;
	secureDownloadMgr.display(moodMgr.getSongList());

	return 0;
}