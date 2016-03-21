// Socrates.h: interface for the CSocrates class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_SOCRATES_H__747CD24F_89CA_4774_BEF4_C8C44BF0F077__INCLUDED_)
#define AFX_SOCRATES_H__747CD24F_89CA_4774_BEF4_C8C44BF0F077__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <time.h>
#include <stdio.h>
#include "Exam.h"

enum menuItem
{
	EXIT=0,
	TAKE_CPLUSPLUSS_EXAM=1,
	TAKE_DRIVER_EXAM=2,
	TAKE_MOVIE_QUIZ=3,
	TAKE_TRUE_OR_FALSE_QUIZ=4,
	MAIN_MENU=5
};

enum Level
{
	NOVICE=0,
	EXPERT=1
};

class CSocrates : CExam
{
public:
	CSocrates();
	virtual ~CSocrates();

	friend ostream& operator << (ostream &lhs, CSocrates &rhs);
	//Please note that this overloaded insertion operators writes to the log file
	//"socrates.log" as well as to the screen.

	void PresentExam(menuItem m);
	menuItem getInput();

	void RandomizeQuestions();

	void showExam();

	void setName_and_Skill();

	void RetakeExpertQuestions();
	
	void DisplayMissedQuestions();

	inline bool* getFlags() {return expertFlags;};
	inline Level getLevel() {return level;};

private:
	string entryBuf,
		   firstEntry;
	char name[128];
	int score,
		grade;
	Level level;
	bool expertFlags[7];
};

#endif // !defined(AFX_SOCRATES_H__747CD24F_89CA_4774_BEF4_C8C44BF0F077__INCLUDED_)
