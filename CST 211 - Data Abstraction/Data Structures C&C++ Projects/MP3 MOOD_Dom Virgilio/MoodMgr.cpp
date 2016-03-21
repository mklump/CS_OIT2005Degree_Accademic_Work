// Name: Dom Virgilio and Modified by Matthew Klump for CST 136 Assignment #3 Part 2
// Class: CST 136
// Assignment #2

// MoodMgr.cpp: implementation of the CMoodMgr class.
//
//////////////////////////////////////////////////////////////////////

#include "MoodMgr.h"
#include <fstream.h>
#include "SecureSongInfo.h"
#include "PromoSongInfo.h"
#include "stdio.h"
#include "stdlib.h"
#include "ctype.h"
#include "string.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CMoodMgr::CMoodMgr()
{
}

CMoodMgr::~CMoodMgr()
{
}

void CMoodMgr::createSong(int type)
{
	int fileSize=0, transfer, encryption, id, numDays, popularity; //arguement added
	char songName[128], albumName[128], artistName[128], date[128], webLink[128];
	double duration, price;

	getInputString("Song Name: ", songName);
	getInputString("Album Name: ", albumName);
	getInputString("Artist Name: ", artistName);
	getInputInt("File Size: ", &fileSize);
	getInputInt("Transfer (1=Streamable, 2=Downloadable, 3=Both) : ", &transfer);
	getInputString("Date: ", date);
	getInputInt("Popularity (0=Lowest to 100=Highest) : ", &popularity);

	if (type == SONG_SECURE) {
		getInputDouble("Duration: ", &duration);
		getInputInt("Encryption (1=SECURE_1, 2=SECURE_2, 3=SECURE_3): ", &encryption);
		getInputInt("ID: ", &id);

		CSecureSongInfo secureSong;

		secureSong.setSongName(songName);	
		secureSong.setAlbumName(albumName);
		secureSong.setArtistName(artistName);
		secureSong.setFileSize(fileSize);
		secureSong.setTransfer(transfer);
		secureSong.setDate(date);
		secureSong.setPopularity(popularity);  //added line of code
		secureSong.setDuration(duration);
		secureSong.setEncryption(encryption);
		secureSong.setId(id);

		songList.add(&secureSong);
	}
	else if (type == SONG_PROMO) {
		getInputDouble("Price: ", &price);
		getInputString("WebLink: ", webLink);
		getInputInt("Promotion Length: ", &numDays);

		CPromoSongInfo promoSong;

		promoSong.setSongName(songName);
		promoSong.setAlbumName(albumName);
		promoSong.setArtistName(artistName);
		promoSong.setFileSize(fileSize);
		promoSong.setTransfer(transfer);
		promoSong.setDate(date);
		promoSong.setPopularity(popularity);
		promoSong.setPrice(price);
		promoSong.setWebLink(webLink);
		promoSong.setNumDays(numDays);

		songList.add(&promoSong);
	}
	
	cout << endl;
}

void CMoodMgr::editPopularity()
{
	cout << "\nYou will now be transfered to the edit menu\n"
		<< "to edit the appropriate song's popularity.\n";
	editSong();
}

void CMoodMgr::editSong()
{
	int i;
	int length = songList.length();

	if (length == 0) {
		displayMessage("The song list is empty.");
		return;
	}
	
	getInputInt("Enter song number you wish to edit: ", &i);
	if ((i < 1) || (i > length)) { // Note: first song is displayed as #1
		displayMessage("You must enter a song number from 1 to ", true, length);
		cout << endl;
		return;
	}

	i = i - 1;  // adjustment, see above

	int fileSize=0, transfer, encryption, id, numDays, popularity;
	char songName[128], albumName[128], artistName[128], date[128], webLink[128];
	double duration, price;

	CSongInfo *pSong;
	CSecureSongInfo *pSecure;
	CPromoSongInfo *pPromo;

	pSong = songList.get(i);
	int type = pSong->getType();

	if (type == SONG_SECURE) {
		pSecure = (CSecureSongInfo *)songList.get(i);

		getInputString("Song Name: ", songName, true, pSecure->getSongName());
		getInputString("Album Name: ", albumName, true, pSecure->getAlbumName());
		getInputString("Artist Name: ", artistName, true, pSecure->getArtistName());
		getInputInt("File Size: ", &fileSize, true, pSecure->getFileSize());
		getInputInt("Transfer (1=Streamable, 2=Downloadable, 3=Both: ", &transfer, true, pSecure->getTransfer());
		getInputString("Date: ", date, true, pSecure->getDate());
		getInputInt("Popularity (0=Lowest to 100=Highest) : ", &popularity, true, pSecure->getPopularity());
		getInputDouble("Duration: ", &duration, true, pSecure->getDuration());
		getInputInt("Encryption (1=SECURE_1, 2=SECURE_2, 3=SECURE_3): ", &encryption, true, pSecure->getEncryption());
		getInputInt("ID: ", &id, true, pSecure->getId());

		pSecure->setSongName(songName);	
		pSecure->setAlbumName(albumName);
		pSecure->setArtistName(artistName);
		pSecure->setFileSize(fileSize);
		pSecure->setTransfer(transfer);
		pSecure->setDate(date);
		pSecure->setPopularity(popularity);
		pSecure->setDuration(duration);
		pSecure->setEncryption(encryption);
		pSecure->setId(id);
	}
	else if (type == SONG_PROMO) {
		pPromo = (CPromoSongInfo *)songList.get(i);

		getInputString("Song Name: ", songName, true, pPromo->getSongName());
		getInputString("Album Name: ", albumName, true, pPromo->getAlbumName());
		getInputString("Artist Name: ", artistName, true, pPromo->getArtistName());
		getInputInt("File Size: ", &fileSize, true, pPromo->getFileSize());
		getInputInt("Transfer (1=Streamable, 2=Downloadable, 3=Both: ", &transfer, true, pPromo->getTransfer());
		getInputString("Date: ", date, true, pPromo->getDate());
		getInputInt("Popularity (0=Lowest to 100=Highest) : ", &popularity, true, pPromo->getPopularity());
		getInputDouble("Price: ", &price, true, pPromo->getPrice());
		getInputString("WebLink: ", webLink, true, pPromo->getWebLink());
		getInputInt("Promotion Length: ", &numDays, true, pPromo->getNumDays());

		pPromo->setSongName(songName);
		pPromo->setAlbumName(albumName);
		pPromo->setArtistName(artistName);
		pPromo->setFileSize(fileSize);
		pPromo->setTransfer(transfer);
		pPromo->setDate(date);
		pPromo->setPopularity(popularity);
		pPromo->setPrice(price);
		pPromo->setWebLink(webLink);
		pPromo->setNumDays(numDays);
	}
	
	cout << endl;
}

void CMoodMgr::deleteSong()
{
	int i;
	int length = songList.length();

	if (length == 0) {
		displayMessage("The song list is empty.");
		return;
	}
	
	getInputInt("Enter song number you wish to delete: ", &i);
	if ((i < 1) || (i > length)) { // Note: first song is displayed as #1
		displayMessage("You must enter a song number from 1 to ", true, length);
		return;
	}

	songList.remove(i-1); // adjustment, see above
}

void CMoodMgr::input()
{
	char fileName[128];
	getInputString("Enter file name: ", fileName, true, "mood.dat");
	cout << endl;

	ifstream file;
	file.open (fileName, ios::in);
	songList.input(file);
	file.close();
}

void CMoodMgr::output()
{
	char fileName[128];
	getInputString("Enter file name: ", fileName, true, "mood.dat");
	cout << endl;

	ofstream file;
	file.open (fileName, ios::out | ios::trunc); 
	songList.output(file);
	file.close();
}

void CMoodMgr::displayMenu(menuType m)
{
	actionType action = menu.display(m);
	while(action != ACTION_EXIT) {
		switch(action) {
			case ACTION_NEW_SECURE:
				displayMessage("CREATE SECURE SONG"); createSong(SONG_SECURE);
				break;
			case ACTION_NEW_PROMO:
				displayMessage("CREATE PROMO SONG"); createSong(SONG_PROMO);
				break;
			case ACTION_EDIT_SONG:
				displayMessage("EDIT SONG"); editSong();
				break;
			case ACTION_DELETE_SONG:
				displayMessage("DELETE SONG"); deleteSong();
				break;
			case ACTION_READ_FILE:
				displayMessage("READ FILE"); input();
				break;
			case ACTION_WRITE_FILE:
				displayMessage("WRITE FILE"); output();
				break;
			case ACTION_LIST_ALL:
				displayMessage("LIST ALL SONGS"); list();
				break;
			case ACTION_LIST_SECURE:
				displayMessage("LIST SECURE SONGS"); listSecure();
				break;
			case ACTION_LIST_PROMO:
				displayMessage("LIST PROMO SONGS"); listPromo();
				break;
			case ACTION_SORT_ARTIST:
				displayMessage("SORT BY ARTIST NAME"); sortArtist();
				break;
			case ACTION_SORT_SONGNAME:
				displayMessage("SORT BY SONG NAME"); sortSongName();
				break;
			case ACTION_SORT_DURATION:
				displayMessage("SORT BY DURATION");	sortDuration();
				break;
			case ACTION_MODIFY_POPULARITY:
				displayMessage("MODIFY SONG POPULARITY"); editPopularity();
				break;
			case ACTION_SORT_SONGS_POPULARITY:
				displayMessage("SORT SONGS BY POPULARITY"); sortSongPopularity();
				break;
			case ACTION_SORT_ARTISTS_POPULARITY:
				displayMessage("SORT ARTISTS BY POPULARITY"); sortArtistPopularity();
				break;
			case ACTION_MENU_TOP:
				m = MENU_TOP;
				break;
			case ACTION_MENU_NEW:
				m = MENU_NEW;
				break;
			case ACTION_MENU_EDIT:
				m = MENU_EDIT;
				break;
			case ACTION_MENU_FILE:
				m = MENU_FILE;
				break;
			case ACTION_MENU_LIST:
				m = MENU_LIST;
				break;
			case ACTION_MENU_SORT:
				m = MENU_SORT;
				break;
			case ACTION_MENU_POPULARITY:
				m = MENU_POPULARITY;
				break;
			default:
				break;
		}
		action = menu.display(m);

	}
}

void CMoodMgr::displayMessage(char *message, bool bShowN, int n)
{
	cout << endl;
	cout << endl;
	cout << "****************************************" << endl;
	cout << message;
	if (bShowN) cout << n;
	cout << endl;
	cout << "****************************************" << endl;
	cout << endl;
	cout << endl;
}

void CMoodMgr::getInputString(char *prompt, char *to, bool bHint, char *hint)
{
	char tmpBuf[128];

	cout << prompt;
	if (bHint) cout << " (" << hint << ") ";
	cout << flush;
	gets(tmpBuf);
	if (bHint && strlen(tmpBuf) == 0) {
		strcpy(to, hint);
	}
	else {
		strcpy(to, tmpBuf);
	}
}

void CMoodMgr::getInputInt(char *prompt, int *to, bool bHint, int hint)
{
	char tmpBuf[128];

	cout << prompt;
	if (bHint) cout << " (" << hint << ") ";
	cout << flush;
	gets(tmpBuf);
	if (bHint && strlen(tmpBuf) == 0) {
		*to = hint;
	}
	else {
		*to = atoi(tmpBuf);
	}
}

void CMoodMgr::getInputDouble(char *prompt, double *to, bool bHint, double hint)
{
	char tmpBuf[128];

	cout << prompt;
	if (bHint) cout << " (" << hint << ") ";
	cout << flush;
	gets(tmpBuf);
	if (bHint && strlen(tmpBuf) == 0) {
		*to = hint;
	}
	else {
		*to = atof(tmpBuf);
	}
}

void CMoodMgr::test()
{
	// create a test SecureSongInfo object
	CSecureSongInfo secureSong;

	secureSong.setSongName("Spaces Screw Things Up");	
	secureSong.setAlbumName("Album");
	secureSong.setArtistName("Artist");
	secureSong.setFileSize(100);
	secureSong.setTransfer(TRANSFER_DOWNLOADABLE);
	secureSong.setDate("04/27/02");
	secureSong.setPopularity(int(56.0));
    secureSong.setDuration(180.0);
	secureSong.setEncryption(SECURE_3);
	secureSong.setId(11455);

	songList.add(&secureSong);

	// create a test SecureSongInfo object
	CSecureSongInfo secureSong2;

	secureSong2.setSongName("Comfortably Numb");	
	secureSong2.setAlbumName("The Wall");
	secureSong2.setArtistName("Pink Floyd");
	secureSong2.setFileSize(35600);
	secureSong2.setTransfer(TRANSFER_BOTH);
	secureSong2.setDate("02/01/02");
	secureSong2.setPopularity(int(100.0));
	secureSong2.setDuration(205.0);
	secureSong2.setEncryption(SECURE_2);
	secureSong2.setId(112266599);

	songList.add(&secureSong2);

	// create a test SecureSongInfo object
	CSecureSongInfo secureSong3;

	secureSong3.setSongName("The Secure Song");	
	secureSong3.setAlbumName("The Secure Album");
	secureSong3.setArtistName("The Securities");
	secureSong3.setFileSize(111);
	secureSong3.setTransfer(TRANSFER_BOTH);
	secureSong3.setDate("09/15/99");
	secureSong3.setPopularity(int(95.0));
	secureSong3.setDuration(102.0);
	secureSong3.setEncryption(SECURE_2);
	secureSong3.setId(898098);

	songList.add(&secureSong3);

	// create a test SecureSongInfo object
	CSecureSongInfo secureSong4;

	secureSong4.setSongName("We're So Secure");	
	secureSong4.setAlbumName("The Album of Security");
	secureSong4.setArtistName("The Secure Ones");
	secureSong4.setFileSize(356999);
	secureSong4.setTransfer(TRANSFER_STREAMABLE);
	secureSong4.setDate("04/26/93");
	secureSong4.setPopularity(int(60.0));
	secureSong4.setDuration(25.0);
	secureSong4.setEncryption(SECURE_3);
	secureSong4.setId(34234);

	songList.add(&secureSong4);

	// create a test PromoSongInfo object
	CPromoSongInfo promoSong;

	promoSong.setSongName("Layla");
	promoSong.setAlbumName("Unplugged");
	promoSong.setArtistName("Clapton");
	promoSong.setFileSize(200000);
	promoSong.setTransfer(TRANSFER_STREAMABLE);
	promoSong.setDate("04/26/02");
	promoSong.setPopularity(int(70.0));
	promoSong.setPrice(1.49);
	promoSong.setWebLink("www.rockstar.com/clapton/layla.html");
	promoSong.setNumDays(15);

	songList.add(&promoSong);

	// create a test PromoSongInfo object
	CPromoSongInfo promoSong2;

	promoSong2.setSongName("Beast of Burden");
	promoSong2.setAlbumName("Wheels");
	promoSong2.setArtistName("Rolling Stones");
	promoSong2.setFileSize(55);
	promoSong2.setTransfer(TRANSFER_BOTH);
	promoSong2.setDate("04/27/02");
	promoSong2.setPopularity(int(123.4));
	promoSong2.setPrice(1.29);
	promoSong2.setWebLink("www.rockstar.com/rollingstones/beast.html");
	promoSong2.setNumDays(29);

	songList.add(&promoSong2);
}