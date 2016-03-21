//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #2 Part 1
// Date Created:   April 27, 2002
// Last Change Date:  April 27, 2002
// Project:        MP3 MOOD files
// Filename:       main.cpp
//
// Overview:	This program is meant to practise the concepts of
//				inheritance
//
// Input:		All input for this program is provided by the user
//				for each MP3 song characteristic.
//   
// Output:		This program allows the user the option of writing
//				to a file called c:\Matt'sOutPut.txt
//--------------------------------------------------------------------
#include "CInternetRadio.h"

int main()
{
	typedef CMoodMgr* ptrCMoodMgr;
	ptrCMoodMgr MoodData;
	CInternetRadio TheStream;
	char ans; int size = 0;

	cout << "How many songs would you like to input data for?> ";
	cin >> size; 
	cout << "You entered " << size << endl;
	MoodData = new CMoodMgr[size];
	do
	{
		MoodData->Input_MOOD_Data(MoodData, size);
		MoodData->Edit_MOOD_Data(MoodData, size);
		MoodData->Sort_Data(MoodData, size);
		TheStream.Stream(MoodData, size);
		cout << "Continue?> (Y/N)";
		cin >> ans;
	} while (ans == 'Y' || ans == 'y');
	delete [] MoodData;
	return 0;
}