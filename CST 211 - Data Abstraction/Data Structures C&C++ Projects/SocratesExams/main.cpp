//--------------------------------------------------------------------
// Author:         Matthew Klump CST 136 Assignment #4
// Date Created:   May 17, 2002
// Last Change Date:  May 17, 2002
// Project:        SocratesExams
// Filename:       main.cpp
//
// Overview:	This program is meant to practise file I/O and an options
//				driven menu
//
// Input:		User prompted questions and selections on the console
//				display.
//   
// Output:		All output is printed to the form and/or to the file
//				socrates.log
//
//--------------------------------------------------------------------

#include "Socrates.h"

bool CheckExpertFlags(CSocrates &);

int main()
{
	CSocrates socrates;
	socrates.setName_and_Skill(); 		 /* <-Part II */

	socrates.PresentExam(MAIN_MENU);	 /* <-Part I  */
	//socrates.RandomizeQuestions();
	char ans = 'y';
	if (socrates.getLevel() == EXPERT)
	{
		while (CheckExpertFlags(socrates)   /* <-Part II */
			&& (ans == 'Y' || ans == 'y'))
		{
			socrates.RetakeExpertQuestions();/* <-Part II */
			cout << "\nContinue answering missed questions? (Y/N) -> ";
			cin >> ans;
		}
	}
	if (CheckExpertFlags(socrates) == true)
		socrates.DisplayMissedQuestions();   /* <-Part II */

	cout << socrates;
	socrates.RandomizeQuestions(); //I need your feedback for an acceptable 
	cout << socrates;			   //randomize fuction for my storagetype 
							       //if you get the chance Dom.

	return 0;
}

bool CheckExpertFlags(CSocrates &s)
{
	for (int x=0; x < 7; x++)
	{
		if (s.getFlags()[x] == false)
			return true;
	}
	return false;
}